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

    Public Sub RemoveBackupSet(ByVal ID As Integer)
        If (Me.BackupSetExists(ID)) Then
            Me._BackUpSets.Remove(ID)
        Else
            Throw New Exception(String.Format("There isn't any backup set with the specified ID({0}) on the list.", ID))
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

    Public Sub SaveProperties(ByRef document As XmlDocument, ByRef parent As XmlElement, ByRef currentNode As FileProperty)
        Dim n_property As XmlElement

        If (currentNode.IsArray) Then
            For Each _Property As String In currentNode.ChildrenList
                n_property = document.CreateElement("property")
                n_property.SetAttribute("type", currentNode.Property(_Property).Type)
                n_property.SetAttribute("name", currentNode.Property(_Property).Name)
                If (currentNode.Property(_Property).IsArray) Then
                    Me.SaveProperties(document, n_property, currentNode.Property(_Property))
                Else
                    n_property.SetAttribute("value", currentNode.Property(_Property).Value)
                End If
                parent.AppendChild(n_property)
            Next
        End If
    End Sub

    Public Sub Save()
        Dim xmld As XmlDocument
        Dim n_backsets As XmlElement
        Dim n_set As XmlElement
        Dim n_items As XmlElement
        Dim n_item As XmlElement

        'Creates the document
        xmld = New XmlDocument()

        ' Create the XML Declaration, and append it to XML document
        xmld.AppendChild(xmld.CreateXmlDeclaration("1.0", "UTF-8", Nothing))

        'Creates the <backupsets> element
        n_backsets = xmld.CreateElement("backupsets")

        'Creates each <set> element
        For Each _Set As Integer In Me.BackupSetsList
            n_set = xmld.CreateElement("set")
            n_set.SetAttribute("id", Me.BackupSet(_Set).ID)
            n_set.SetAttribute("title", Me.BackupSet(_Set).Name)

            n_items = xmld.CreateElement("items")
            For Each _Item As Integer In Me.BackupSet(_Set).ItemsList
                n_item = xmld.CreateElement("item")
                n_item.SetAttribute("id", _Item)
                n_item.SetAttribute("src", Me.BackupSet(_Set).Item(_Item).FileURL)

                If (Me.BackupSet(_Set).Item(_Item).IsFile) Then
                    n_item.SetAttribute("type", "file")
                Else
                    n_item.SetAttribute("type", "folder")
                End If

                Me.SaveProperties(xmld, n_item, Me.BackupSet(_Set).Item(_Item).Properties)
            Next

            n_set.AppendChild(n_items)
            n_backsets.AppendChild(n_set)
        Next
        xmld.AppendChild(n_backsets)
    End Sub

    Public Sub New(ByVal FileURL As String)
        Me._FileURL = FileURL
    End Sub
End Class
