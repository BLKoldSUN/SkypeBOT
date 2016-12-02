Imports SKYPE4COMLib
Imports System.Net

Public Class MassMessage

    '' START // cod ptr mutare aplicatie fara bara de titlu
    Private Moving As Boolean
    Private offset As Size
    Private Sub Form1_Mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Moving = True
        offset = CType(e.Location, Drawing.Size)
    End Sub
    Private Sub Form1_Mousemove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Moving Then
            Location = Point.Subtract(PointToScreen(e.Location), offset)
        End If
    End Sub
    Private Sub Form1_Mouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Moving = False
    End Sub
    '' STOP // cod ptr mutare aplicatie fara bara de titlu

    Public WithEvents oSkype As New SKYPE4COMLib.Skype

    '' Buton trimite mass
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        '' Aici aplicam conditiile de trimitere
        '' Mesajul mass are doua conditii
        '' 1. Trimite mesaj global daca e bifata casuta
        '' 2. Trimite messaj doar la cei selectati din lista
        If ChkToAll.CheckState = CheckState.Checked Then
            For Each user In oSkype.Friends
                oSkype.SendMessage(user.Handle, RichTxtMsg2.Text)
                PicSaveMsg3.Visible = True
            Next
            'ElseIf ChkToAll.CheckState = CheckState.Unchecked Then
            '   For Each item In ListView1.CheckedItems
            '  oSkype.SendMessage((ListView1.Items).Handle, RichTxtMsg2.Text)
            ' Next
        Else MsgBox("Nu ai bifat casuta de trimitere")
        End If
    End Sub

    '' Load fereastra
    Private Sub MassMessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PicSaveMsg3.Visible = False

        '' ### Adauga o coloana in ListView1 ###
        ''ListView1.Columns.Add("Utilizator", 150, HorizontalAlignment.Left)
        ''ListView1.View = View.Details

        '' Populeaza lista de frieteni de pe skype
        ''For Each u As SKYPE4COMLib.User In oSkype.Friends
        ''ListView1.Items.Add(u.Handle)
        ''Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
