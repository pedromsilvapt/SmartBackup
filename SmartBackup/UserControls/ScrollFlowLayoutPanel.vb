Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Friend Class ScrollFlowLayoutPanel
    Inherits FlowLayoutPanel
    Implements IMessageFilter
    Private WM_MOUSEWHEEL As Integer = &H20A
    Private panel As Panel
    Private panelHasFocus As Boolean = False

    <DllImport("user32.dll")> _
    Private Shared Function GetCursorPos(ByRef lpPoint As Point) As Boolean
    End Function
    <DllImport("User32.dll")> _
    Private Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Int32
    End Function

    Public Sub New()
        'Go through each control on the panel and add an event handler.
        'We need to know if a control on the panel has focus to prevent sending
        'the scroll message a second time
        AddFocusEvent(Me)
    End Sub

    Private Sub AddFocusEvent(ByVal parentControl As Control)
        For Each control As Control In parentControl.Controls
            If control.Controls.Count = 0 Then
                AddHandler control.GotFocus, New EventHandler(AddressOf control_GotFocus)
                AddHandler control.LostFocus, New EventHandler(AddressOf control_LostFocus)
            Else
                AddFocusEvent(control)
            End If
        Next
    End Sub

    Private Sub control_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
        panelHasFocus = True
    End Sub

    Private Sub control_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        panelHasFocus = False
    End Sub

#Region "IMessageFilter Members"

    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        'filter out all other messages except than mousewheel
        'also only proceed with processing if the panel is focusable, no controls on the panel have focus
        'and the vertical scroll bar is visible
        If m.Msg = WM_MOUSEWHEEL AndAlso Me.CanFocus AndAlso Not panelHasFocus Then
            'is mouse cordinates over the panel display rectangle?
            Dim rect As Rectangle = Me.RectangleToScreen(Me.ClientRectangle)
            Dim cursorPoint As New Point()
            GetCursorPos(cursorPoint)
            If (cursorPoint.X > rect.X AndAlso cursorPoint.X < rect.X + rect.Width) AndAlso (cursorPoint.Y > rect.Y AndAlso cursorPoint.Y < rect.Y + rect.Height) Then
                'send the mouse wheel message to the panel.
                SendMessage(CInt(Me.Handle), m.Msg, CType(m.WParam, Int32), CType(m.LParam, Int32))
                Return True
            End If
        End If
        Return False
    End Function
#End Region

End Class
