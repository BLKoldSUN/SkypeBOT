Imports System.Windows.Forms

Public Class Fundal

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

    '' #### Culorile pentru Form1 ### / sunt imagini in My.Resources > jpg ###
    Private Sub PicColorGri_Click(sender As Object, e As EventArgs) Handles PicColorGri.Click
        Form1.BackgroundImage = My.Resources.gri
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "gri"
    End Sub

    Private Sub PicColorMaro_Click(sender As Object, e As EventArgs) Handles PicColorMaro.Click
        Form1.BackgroundImage = My.Resources.maro
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "maro"
    End Sub

    Private Sub PicColorPorto_Click(sender As Object, e As EventArgs) Handles PicColorPorto.Click
        Form1.BackgroundImage = My.Resources.portocaliu
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "portocaliu"
    End Sub

    Private Sub PicColorRozDeschis_Click(sender As Object, e As EventArgs) Handles PicColorRozDeschis.Click
        Form1.BackgroundImage = My.Resources.rozdeschis
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "rozdeschis"
    End Sub

    Private Sub PicColorVerdeDeschis_Click(sender As Object, e As EventArgs) Handles PicColorVerdeDeschis.Click
        Form1.BackgroundImage = My.Resources.verdedeschis
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "verdedeschis"
    End Sub

    Private Sub PicColorBlueSky_Click(sender As Object, e As EventArgs) Handles PicColorBlueSky.Click
        Form1.BackgroundImage = My.Resources.blueky
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "bluesky"
    End Sub

    Private Sub PicColorAlbastru_Click(sender As Object, e As EventArgs) Handles PicColorAlbastru.Click
        Form1.BackgroundImage = My.Resources.albastru
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "albastru"
    End Sub

    Private Sub PicColorRoz_Click(sender As Object, e As EventArgs) Handles PicColorRoz.Click
        Form1.BackgroundImage = My.Resources.roz
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "roz"
    End Sub

    Private Sub PicColorVerde_Click(sender As Object, e As EventArgs) Handles PicColorVerde.Click
        Form1.BackgroundImage = My.Resources.verde
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "verde"
    End Sub

    Private Sub PicColorAlbastruVerzui_Click(sender As Object, e As EventArgs) Handles PicColorAlbastruVerzui.Click
        Form1.BackgroundImage = My.Resources.albastruverzui
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "albastruverzui"
    End Sub

    Private Sub PicColorRozInchis_Click(sender As Object, e As EventArgs) Handles PicColorRozInchis.Click
        Form1.BackgroundImage = My.Resources.rozinchis
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "rozinchis"
    End Sub

    Private Sub PicColorNegru_Click(sender As Object, e As EventArgs) Handles PicColorNegru.Click
        Form1.BackgroundImage = My.Resources.negru
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "negru"
    End Sub

    Private Sub PicColorCrem_Click(sender As Object, e As EventArgs) Handles PicColorCrem.Click
        Form1.BackgroundImage = My.Resources.crem
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "crem"
    End Sub

    Private Sub PicColorAlbastruInchis_Click(sender As Object, e As EventArgs) Handles PicColorAlbastruInchis.Click
        Form1.BackgroundImage = My.Resources.albastruInchis
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "albastruinchis"
    End Sub

    Private Sub PicColorGalben_Click(sender As Object, e As EventArgs) Handles PicColorGalben.Click
        Form1.BackgroundImage = My.Resources.Galben
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "galben"
    End Sub

    Private Sub PicColorVerdeCopac_Click(sender As Object, e As EventArgs) Handles PicColorVerdeCopac.Click
        Form1.BackgroundImage = My.Resources.verzuicopac
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "verzuicopac"
    End Sub

    Private Sub PicColorRosu_Click(sender As Object, e As EventArgs) Handles PicColorRosu.Click
        Form1.BackgroundImage = My.Resources.rosu
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "rosu"
    End Sub

    Private Sub PicColorGriDeschis_Click(sender As Object, e As EventArgs) Handles PicColorGriDeschis.Click
        Form1.BackgroundImage = My.Resources.verdedeschis
        Form1.BackgroundImageLayout = ImageLayout.Tile
        My.Settings.fundalApp = "grideschis"
    End Sub

    '' // Salveaza & Inchide
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBoxSaved.Visible = True
        My.Settings.Save()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Fundal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBoxSaved.Visible = False
    End Sub
End Class
