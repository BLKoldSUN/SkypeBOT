Public Class Configurare

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

    '' Salveaza mesajele in DB
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.trigger1 = Txtmsg1.Text
        My.Settings.trigger1_1 = Txtmsg1_1.Text
        My.Settings.trigger2 = Txtmsg2.Text
        My.Settings.trigger2_2 = Txtmsg2_2.Text
        My.Settings.trigger3 = Txtmsg3.Text
        My.Settings.trigger3_3 = Txtmsg3_3.Text
        My.Settings.trigger4 = Txtmsg4.Text
        My.Settings.trigger4_4 = Txtmsg4_4.Text
        My.Settings.trigger5 = Txtmsg5.Text
        My.Settings.trigger5_5 = Txtmsg5_5.Text
        My.Settings.trigger6 = Txtmsg6.Text
        My.Settings.trigger6_6 = Txtmsg6_6.Text
        My.Settings.trigger7 = Txtmsg7.Text
        My.Settings.trigger7_7 = Txtmsg7_7.Text
        My.Settings.trigger8 = Txtmsg8.Text
        My.Settings.trigger8_8 = Txtmsg8_8.Text
        My.Settings.trigger9 = Txtmsg9.Text
        My.Settings.trigger9_9 = Txtmsg9_9.Text
        My.Settings.trigger10 = Txtmsg10.Text
        My.Settings.trigger10_10 = Txtmsg10_10.Text
        My.Settings.botname = botname.Text
        My.Settings.Save()
        PicSaveMsg.Visible = True

    End Sub

    Private Sub Configurare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PicSaveMsg.Visible = False
        My.Settings.Reload()
        Txtmsg1.Text = My.Settings.trigger1
        Txtmsg1_1.Text = My.Settings.trigger1_1
        Txtmsg2.Text = My.Settings.trigger2
        Txtmsg2_2.Text = My.Settings.trigger2_2
        Txtmsg3.Text = My.Settings.trigger3
        Txtmsg3_3.Text = My.Settings.trigger3_3
        Txtmsg4.Text = My.Settings.trigger4
        Txtmsg4_4.Text = My.Settings.trigger4_4
        Txtmsg5.Text = My.Settings.trigger5
        Txtmsg5_5.Text = My.Settings.trigger5_5
        Txtmsg6.Text = My.Settings.trigger6
        Txtmsg6_6.Text = My.Settings.trigger6_6
        Txtmsg7.Text = My.Settings.trigger7
        Txtmsg7_7.Text = My.Settings.trigger7_7
        Txtmsg8.Text = My.Settings.trigger8
        Txtmsg8_8.Text = My.Settings.trigger8_8
        Txtmsg9.Text = My.Settings.trigger9
        Txtmsg9_9.Text = My.Settings.trigger9_9
        Txtmsg10.Text = My.Settings.trigger10
        Txtmsg10_10.Text = My.Settings.trigger10_10
        botname.Text = My.Settings.botname
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.ContextMenuStrip1.Show(Me.Button3, New Point(0, 0))
    End Sub
End Class
