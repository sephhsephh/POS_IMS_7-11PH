Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' 7-Eleven colors with smoother transition
        Dim colors As Color() = {
        Color.FromArgb(255, 237, 28, 36),   ' Red
        Color.FromArgb(255, 255, 127, 39),  ' Orange
        Color.FromArgb(255, 255, 174, 66),  ' Light Orange
        Color.FromArgb(255, 34, 177, 76)    ' Green
    }

        Dim positions As Single() = {0.0F, 0.3F, 0.7F, 1.0F}

        Dim gradientBrush As New LinearGradientBrush(
        New Point(0, 0),
        New Point(Me.ClientSize.Width, Me.ClientSize.Height),
        Color.Red,
        Color.Green)

        Dim colorBlend As New ColorBlend()
        colorBlend.Colors = colors
        colorBlend.Positions = positions
        gradientBrush.InterpolationColors = colorBlend

        e.Graphics.FillRectangle(gradientBrush, Me.ClientRectangle)
        gradientBrush.Dispose()
    End Sub

    'Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
    '    ' Redraw the gradient when the form resizes
    '    Me.Invalidate()
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New frmMain()
        form.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Loop through all controls in the form
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)

                ' Make it flat and visually clean
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0

                ' Attach custom paint event for rounded effect
                AddHandler btn.Paint, AddressOf RoundButton_Paint
            End If
        Next

        ' Make form borderless and apply rounded corners
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, 30, 30))



    End Sub


    Private Sub RoundButton_Paint(sender As Object, e As PaintEventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim radius As Integer = 20
        Dim rect As Rectangle = New Rectangle(0, 0, btn.Width, btn.Height)

        Dim path As New GraphicsPath()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(rect.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, rect.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        btn.Region = New Region(path)

        ' Optional: Custom border (can remove this if you just want shape)
        Using pen As New Pen(Color.Gray, 1)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    ''round form
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(
    nLeftRect As Integer,
    nTopRect As Integer,
    nRightRect As Integer,
    nBottomRect As Integer,
    nWidthEllipse As Integer,
    nHeightEllipse As Integer) As IntPtr
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class

