Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports Dapper

Public Class frmProductManagement
    Private Sub frmProductManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()

        ApplyRoundedCornersToAllButtons(Me)

        ' Make form borderless and apply rounded corners
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, 30, 30))
    End Sub

    Private Sub ApplyRoundedCornersToAllButtons(ctrl As Control)
        For Each child As Control In ctrl.Controls
            If TypeOf child Is Button Then
                Dim btn As Button = CType(child, Button)

                ' Attach the paint handler
                AddHandler btn.Paint, AddressOf RoundButton_Paint
                ' Optional for visual consistency
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
            End If

            ' Recurse into nested containers (like Panel, GroupBox, etc.)
            If child.HasChildren Then
                ApplyRoundedCornersToAllButtons(child)
            End If
        Next
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

        ' Optional border
        Using pen As New Pen(Color.Gray, 1)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub


    Private Sub LoadProducts()
        Dim products = DatabaseHelper.Query(Of Product)("SELECT * FROM Products WHERE IsActive = 1 ORDER BY ProductName")
        dgvProducts.DataSource = products
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New frmProductDetails()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadProducts()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvProducts.SelectedRows.Count = 0 Then Return

        Dim productId = CInt(dgvProducts.SelectedRows(0).Cells("ProductID").Value)
        Dim frm As New frmProductDetails(productId)
        If frm.ShowDialog() = DialogResult.OK Then
            LoadProducts()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then Return

        If MessageBox.Show("Are you sure you want to deactivate this product?", "Confirm",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim productId = CInt(dgvProducts.SelectedRows(0).Cells("ProductID").Value)
            DatabaseHelper.Execute("UPDATE Products SET IsActive = 0 WHERE ProductID = @ProductID",
                                 New With {.ProductID = productId})
            LoadProducts()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub


    Private Sub NavPanel_Paint(sender As Object, e As PaintEventArgs) Handles NavPanel.Paint
        ' Define 7-Eleven color gradient
        Dim colors As Color() = {
        Color.FromArgb(255, 34, 177, 76),    ' Green
        Color.FromArgb(255, 255, 174, 66),   ' Light Orange
        Color.FromArgb(255, 255, 127, 39),   ' Orange
        Color.FromArgb(255, 237, 28, 36)     ' Red
    }

        Dim positions As Single() = {0.0F, 0.3F, 0.7F, 1.0F}

        ' Create gradient brush
        Dim gradientBrush As New LinearGradientBrush(
        NavPanel.ClientRectangle,
        Color.Empty,
        Color.Empty,
        LinearGradientMode.ForwardDiagonal)

        Dim colorBlend As New ColorBlend()
        colorBlend.Colors = colors
        colorBlend.Positions = positions
        gradientBrush.InterpolationColors = colorBlend

        ' Define radius for corner rounding
        Dim radius As Integer = 20
        Dim path As New GraphicsPath()
        Dim rect As Rectangle = NavPanel.ClientRectangle

        ' Avoid drawing outside bounds
        rect.Width -= 1
        rect.Height -= 1

        ' Build path: top-left (sharp), top-right (rounded), bottom-right (rounded), bottom-left (sharp)
        path.StartFigure()
        path.AddLine(rect.Left, rect.Top, rect.Right - radius, rect.Top) ' Top edge to top-right arc
        path.AddArc(New Rectangle(rect.Right - radius, rect.Top, radius, radius), 270, 90) ' Top-right corner
        path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius) ' Right edge
        path.AddArc(New Rectangle(rect.Right - radius, rect.Bottom - radius, radius, radius), 0, 90) ' Bottom-right corner
        path.AddLine(rect.Right - radius, rect.Bottom, rect.Left, rect.Bottom) ' Bottom edge
        path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top) ' Left edge
        path.CloseFigure()

        ' Fill with gradient and apply smoothing
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.FillPath(gradientBrush, path)

        ' Clean up
        gradientBrush.Dispose()
        path.Dispose()
    End Sub


    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(
   nLeftRect As Integer,
   nTopRect As Integer,
   nRightRect As Integer,
   nBottomRect As Integer,
   nWidthEllipse As Integer,
   nHeightEllipse As Integer) As IntPtr
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Dim form As New frmMain()
        form.Show()
    End Sub
End Class