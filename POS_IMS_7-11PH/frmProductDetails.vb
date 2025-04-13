Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports Dapper

Public Class frmProductDetails
    Private _productId As Integer = 0
    Private _isEditMode As Boolean = False

    Public Sub New()
        ' This constructor is for adding new products
        InitializeComponent()
        _isEditMode = False
    End Sub

    Public Sub New(productId As Integer)
        ' This constructor is for editing existing products
        InitializeComponent()
        _productId = productId
        _isEditMode = True
        LoadProductData()
    End Sub

    Private Sub LoadProductData()
        If _productId = 0 Then Return

        Dim product = DatabaseHelper.Query(Of Product)(
            "SELECT * FROM Products WHERE ProductID = @ProductID",
            New With {.ProductID = _productId}).FirstOrDefault()

        If product IsNot Nothing Then
            txtBarcode.Text = product.Barcode
            txtName.Text = product.ProductName
            txtDescription.Text = product.Description
            txtCategory.Text = product.Category
            numPrice.Value = product.Price
            numCost.Value = product.Cost
            NumStock.Value = product.StockQuantity
            numReorderLevel.Value = product.ReorderLevel
            chkActive.Checked = product.IsActive
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Try
            If _isEditMode Then
                ' Update existing product
                DatabaseHelper.Execute(
                    "UPDATE Products SET " &
                    "Barcode = @Barcode, " &
                    "ProductName = @ProductName, " &
                    "Description = @Description, " &
                    "Category = @Category, " &
                    "Price = @Price, " &
                    "Cost = @Cost, " &
                    "StockQuantity = @StockQuantity, " &
                    "ReorderLevel = @ReorderLevel, " &
                    "IsActive = @IsActive " &
                    "WHERE ProductID = @ProductID",
                    New With {
                        .ProductID = _productId,
                        .Barcode = txtBarcode.Text.Trim(),
                        .ProductName = txtName.Text.Trim(),
                        .Description = txtDescription.Text.Trim(),
                        .Category = txtCategory.Text.Trim(),
                        .Price = numPrice.Value,
.Cost = numCost.Value,
                        .StockQuantity = CInt(NumStock.Value),
                        .ReorderLevel = CInt(numReorderLevel.Value),
                        .IsActive = chkActive.Checked
                    })
            Else
                ' Insert new product
                _productId = DatabaseHelper.Query(Of Integer)(
                    "INSERT INTO Products (" &
                    "Barcode, ProductName, Description, Category, " &
                    "Price, Cost, StockQuantity, ReorderLevel, IsActive) " &
                    "VALUES (" &
                    "@Barcode, @ProductName, @Description, @Category, " &
                    "@Price, @Cost, @StockQuantity, @ReorderLevel, @IsActive); " &
                    "SELECT SCOPE_IDENTITY()",
                    New With {
                        .Barcode = txtBarcode.Text.Trim(),
                        .ProductName = txtName.Text.Trim(),
                        .Description = txtDescription.Text.Trim(),
                        .Category = txtCategory.Text.Trim(),
                        .Price = numPrice.Value,
.Cost = numCost.Value,
                        .StockQuantity = CInt(NumStock.Value),
                        .ReorderLevel = CInt(numReorderLevel.Value),
                        .IsActive = chkActive.Checked
                    }).First()
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving product: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            MessageBox.Show("Please enter a barcode", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter a product name", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If numPrice.Value <= 0 Then
            MessageBox.Show("Price must be greater than 0", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numPrice.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmProductDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(
   nLeftRect As Integer,
   nTopRect As Integer,
   nRightRect As Integer,
   nBottomRect As Integer,
   nWidthEllipse As Integer,
   nHeightEllipse As Integer) As IntPtr
    End Function
End Class