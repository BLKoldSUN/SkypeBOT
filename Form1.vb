Imports SKYPE4COMLib '' Se va face import la aceasta librarie Skype
 TreImports System.Net

Public Class Form1

    '' START // cod ptr mutare aplicatie fara bara de titlu
    Private Moving As Boolean
    Private offset As Size
    Private Sub Form1_Mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Moving = True
        offset = CType(e.Location, Drawing.Size)
'    End Sub
    Private Sub Form1_Mousemove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Moving Then
            Location = Point.Subtract(PointToScreen(e.Location), offset)
        End If
    End Sub
    Private Sub Form1_Mouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Moving = False
    End Sub
    '' STOP // cod ptr mutare aplicatie fara bara de titlu


    Dim User As User
    Dim valid As Boolean = False
    Dim WithEvents oSkype As New Skype
    Dim Trigger As String = "!" 'nu este obligatoriu sa se foloseasca semnul exclamarii



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '' // Verifica daca clientul skype este pornit
        '' // In caz contract, il va deschide
        If Not oSkype.Client.IsRunning Then
            oSkype.Client.Start()
            '' // notifica utilizatorul de actiune
            NotifyIcon1.ShowBalloonTip(3000, "Info", "Skype nu ruleaza, il voi porni", ToolTipIcon.Info)
        End If
        '' // ataseaza aplicatia la skype
        oSkype.Attach(7, False)
        ''StatusLblTxt.Text = "Conectat la Skype"
        '' Load mesaje din DB/settings
        '' Trebuie sa se creeze in My.Settings [Trigger - Mesaj default] - acestea vor aparea in fereastra de dialog de configurare a mesajelor
        My.Settings.Reload()
        Configurare.Txtmsg1.Text = My.Settings.trigger1
        Configurare.Txtmsg1_1.Text = My.Settings.trigger1_1
        Configurare.Txtmsg2.Text = My.Settings.trigger2
        Configurare.Txtmsg2_2.Text = My.Settings.trigger2_2
        Configurare.Txtmsg3.Text = My.Settings.trigger3
        Configurare.Txtmsg3_3.Text = My.Settings.trigger3_3
        Configurare.Txtmsg4.Text = My.Settings.trigger4
        Configurare.Txtmsg4_4.Text = My.Settings.trigger4_4
        Configurare.Txtmsg5.Text = My.Settings.trigger5
        Configurare.Txtmsg5_5.Text = My.Settings.trigger5_5
        Configurare.Txtmsg6.Text = My.Settings.trigger6
        Configurare.Txtmsg6_6.Text = My.Settings.trigger6_6
        Configurare.Txtmsg7.Text = My.Settings.trigger7
        Configurare.Txtmsg7_7.Text = My.Settings.trigger7_7
        Configurare.Txtmsg8.Text = My.Settings.trigger8
        Configurare.Txtmsg8_8.Text = My.Settings.trigger8_8
        Configurare.Txtmsg9.Text = My.Settings.trigger9
        Configurare.Txtmsg9_9.Text = My.Settings.trigger9_9
        Configurare.Txtmsg10.Text = My.Settings.trigger10
        Configurare.Txtmsg10_10.Text = My.Settings.trigger10_10

        '' // incarca fundalul aplicatiei din My.Settings si My.Resources
        If My.Settings.fundalApp = "gri" Then
            Me.BackgroundImage = My.Resources.gri
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "maro" Then
            Me.BackgroundImage = My.Resources.maro
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "portocaliu" Then
            Me.BackgroundImage = My.Resources.portocaliu
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "rozdeschis" Then
            Me.BackgroundImage = My.Resources.rozdeschis
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "verdedeschis" Then
            Me.BackgroundImage = My.Resources.verdedeschis
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "bluesky" Then
            Me.BackgroundImage = My.Resources.blueky
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "albastru" Then
            Me.BackgroundImage = My.Resources.albastru
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "roz" Then
            Me.BackgroundImage = My.Resources.roz
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "verde" Then
            Me.BackgroundImage = My.Resources.verde
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "albastruverzui" Then
            Me.BackgroundImage = My.Resources.albastruverzui
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "rozinchis" Then
            Me.BackgroundImage = My.Resources.rozinchis
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "negru" Then
            Me.BackgroundImage = My.Resources.negru
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "crem" Then
            Me.BackgroundImage = My.Resources.crem
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "albastruinchis" Then
            Me.BackgroundImage = My.Resources.albastruInchis
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "galben" Then
            Me.BackgroundImage = My.Resources.Galben
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "verzuicopac" Then
            Me.BackgroundImage = My.Resources.verzuicopac
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "rosu" Then
            Me.BackgroundImage = My.Resources.rosu
            Me.BackgroundImageLayout = ImageLayout.Tile
        ElseIf My.Settings.fundalApp = "grideschis" Then
            Me.BackgroundImage = My.Resources.grideschis
            Me.BackgroundImageLayout = ImageLayout.Tile
        End If
    End Sub


    Private Sub oSkype_MessageStatus(pMessage As ChatMessage, Status As TChatMessageStatus) Handles oSkype.MessageStatus
        If Status = TChatMessageStatus.cmsReceived Then
            Dim Msg As String = pMessage.Body
            Dim c As Chat = pMessage.Chat
            '' Cand un user tasteaza un cuvant <trigger1_1> se citeste in My.Settings
            '' Daca acel cuvant corespunde, botul va prelua <trigger1_1>
            If Msg = (My.Settings.trigger1.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger1_1)
            ElseIf Msg = (My.Settings.trigger2.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger2_2)
            ElseIf Msg = (My.Settings.trigger3.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger3_3)
            ElseIf Msg = (My.Settings.trigger4.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger4_4)
            ElseIf Msg = (My.Settings.trigger5.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger5_5)
            ElseIf Msg = (My.Settings.trigger6.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger6_6)
            ElseIf Msg = (My.Settings.trigger7.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger7_7)
            ElseIf Msg = (My.Settings.trigger8.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger8_8)
            ElseIf Msg = (My.Settings.trigger9.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger9_9)
            ElseIf Msg = (My.Settings.trigger10.ToString) Then
                c.SendMessage(My.Settings.botname & " " & My.Settings.trigger10_10)
            End If
        End If
    End Sub

    '' butonul - Ruleaza pe fundal
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
        NotifyIcon1.ShowBalloonTip(3000, "Info", "Aplicatia ruleaza pe fundal", ToolTipIcon.Info)
    End Sub
    '' butonul - Ruleaza pe fundal
    Private Sub RuleazaPeFundalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
        NotifyIcon1.ShowBalloonTip(3000, "Info", "Aplicatia ruleaza pe fundal", ToolTipIcon.Info)
    End Sub
    '' Inchide programul
    Private Sub IesireToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    '' Arata panou configurare
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Configurare.Show()
    End Sub

    '' Icoana de notificare ##################################
    ''########################################################
    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub
    '' Restaureaza aplicatia
    Private Sub RestaureazaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaureazaToolStripMenuItem.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub
    '' Inchide aplicatia
    Private Sub InchideSkypeBotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InchideSkypeBotToolStripMenuItem.Click
        Me.Close()
    End Sub

    '' Arata panou configurare
    Private Sub ConfigurareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurareToolStripMenuItem.Click
        Configurare.Show()
    End Sub

    '' Trimite mass pe skype
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MassMessage.Show()
    End Sub
    '' Arata optiunile de fundal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Fundal.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    '' minimizeaza aplicatia
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub
End Class
