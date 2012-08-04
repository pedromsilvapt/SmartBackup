Imports System.IO
Imports System.Xml

Public Class DataFile
    Private _FileURL As String
    Private _BackUpSets As New Dictionary(Of Integer, BackupSet)

    Public ReadOnly Property BackupSetsList As Dictionary(Of Integer, BackupSet).KeyCollection
        Get
            Return Me._BackUpSets.Keys
        End Get
    End Property

    Public Property BackupSet(ByVal SetID As Integer) As BackupSet
        Get
            If (Me.BackupSetExists(SetID)) Then
                Return Me._BackUpSets(SetID)
            Else
                Throw New Exception(String.Format("The ID you specified ({0}) doesn't exist in the list!", SetID))
            End If
        End Get
        Set(ByVal value As BackupSet)
            If (Me.BackupSetExists(SetID)) Then
                Me._BackUpSets(SetID) = value
            Else
                Throw New Exception(String.Format("The ID you specified ({0}) doesn't exist in the list!", SetID))
            End If
        End Set
    End Property


    Public Function BackupSetExists(ByVal BackupID As Integer) As Boolean
        Return Me._BackUpSets.ContainsKey(BackupID)
    End Function

    Public Sub AddBackupSet(ByVal ID As Integer, ByVal SetName As String)
        If (Not Me.BackupSetExists(ID)) Then
            Me._BackUpSets.Add(ID, New BackupSet(ID, SetName))
        Else
            Throw New Exception(String.Format("Already exists a backup set with the same ID({0}) on the list.", ID))
        End If
    End Sub

    Private Function ReadProperties(ByRef Node As XmlNode) As Dictionary(Of String, FileProperty)
        Dim Properties As New Dictionary(Of String, FileProperty)
        Dim pType As String
        Dim pName As String
        Dim newProperty As FileProperty


        For Each _Property As XmlNode In Node.SelectNodes("./property")
            pType = _Property.Attributes.GetNamedItem("type").Value.ToLower()
            pName = _Property.Attributes.GetNamedItem("name").Value
            newProperty = Nothing

            If (Properties.ContainsKey(pName)) Then
                Continue For
            End If

            If (pType = "string") Then
                newProperty = New FileProperty(pName, "string", CType(_Property.Attributes.GetNamedItem("value").Value, String))
            ElseIf (pType = "integer" Or pType = "int") Then
                newProperty = New FileProperty(pName, "integer", CType(_Property.Attributes.GetNamedItem("value").Value, Integer))
            ElseIf pType = "double" Then
                newProperty = New FileProperty(pName, "double", CType(_Property.Attributes.GetNamedItem("value").Value, Double))
            ElseIf (pType = "date") Then
                newProperty = New FileProperty(pName, "date", CType(_Property.Attributes.GetNamedItem("value").Value, Date))
            ElseIf (pType = "datetime") Then
                newProperty = New FileProperty(pName, "datetime", CType(_Property.Attributes.GetNamedItem("value").Value, DateTime))
            ElseIf (pType = "boolean" Or pType = "bool") Then
                newProperty = New FileProperty(pName, "boolean", CType(_Property.Attributes.GetNamedItem("value").Value, Boolean))
            ElseIf (pType = "array") Then
                newProperty = New FileProperty(pName, "array")
                newProperty.RegisterProperties(Me.ReadProperties(_Property))
            End If

            If (newProperty IsNot Nothing) Then
                Properties.Add(pName, newProperty)
            End If
        Next

        Return Properties
    End Function

    Public Sub Read()
        'Clears the current data
        Me._BackUpSets.Clear()

        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            Dim ItemInfo As FileRecord
            Dim sName As String
            'Create the XML Document
            m_xmld = New XmlDocument()
            'Load the Xml file
            m_xmld.Load(_FileURL)
            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes("/backupsets/set")
            'Loop through the nodes
            For Each m_node In m_nodelist
                sName = m_node.Attributes.GetNamedItem("id").Value

                'Adds a new backup set
                AddBackupSet(sName, m_node.Attributes.GetNamedItem("title").Value)

                'Get's its files.
                For Each _file As XmlNode In m_node.SelectNodes("./items/item")
                    If (_file.Attributes.GetNamedItem("type").Value = "folder") Then
                        ItemInfo = New FileRecord(_file.Attributes.GetNamedItem("id").Value, _file.Attributes.GetNamedItem("src").Value, False)
                    Else
                        ItemInfo = New FileRecord(_file.Attributes.GetNamedItem("id").Value, _file.Attributes.GetNamedItem("src").Value, True)
                    End If

                    ItemInfo.RegisterProperties(Me.ReadProperties(_file))

                    Me.BackupSet(sName).AddItem(_file.Attributes.GetNamedItem("id").Value, ItemInfo)
                Next
                ''Get the firstName Element Value
                'Dim firstNameValue = m_node.ChildNodes.Item(0).InnerText
                ''Get the lastName Element Value
                'Dim lastNameValue = m_node.ChildNodes.Item(1).InnerText
            Next
        Catch errorVariable As Exception
            'Error trapping
            MessageBox.Show(errorVariable.Message)
        End Try
    End Sub

    Public Sub New(ByVal FileURL As String)
        Me._FileURL = FileURL
    End Sub
End Class
