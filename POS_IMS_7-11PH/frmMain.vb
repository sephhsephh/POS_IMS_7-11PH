Imports System.Data.SqlClient
Imports Dapper
Imports System.Media
Imports System.Text
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Globalization

Public Class frmMain
    Private currentCart As New List(Of CartItem)
    Private currentTransactionNumber As String

    ' Product class to match database structure
    Private Class Product
        Public Property ProductID As Integer
        Public Property Barcode As String
        Public Property ProductName As String
        Public Property Description As String
        Public Property Category As String
        Public Property Price As Decimal
        Public Property Cost As Decimal
        Public Property StockQuantity As Integer
        Public Property ReorderLevel As Integer
        Public Property LastRestockedDate As DateTime?
        Public Property IsActive As Boolean
    End Class

    Private Class CartItem
        Public Property ProductID As Integer
        Public Property Barcode As String
        Public Property Name As String
        Public Property Price As Decimal
        Public Property Quantity As Integer
        Public Property Subtotal As Decimal
    End Class

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDataGridView()
        GenerateTransactionNumber()
        UpdateDateTimeDisplay()
        lblCashier.Text = "Cashier: " & Environment.UserName
        Timer1.Interval = 1000
        Timer1.Start()


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
    Private Sub InitializeDataGridView()
        With dgvCart
            .Columns.Clear()
            .Columns.Add("Barcode", "Barcode")
            .Columns.Add("Name", "Product Name")
            .Columns.Add("Price", "Price")
            .Columns.Add("Quantity", "Qty")
            .Columns.Add("Subtotal", "Subtotal")

            ' Format currency columns
            .Columns("Price").DefaultCellStyle.Format = "₱0.00"
            .Columns("Subtotal").DefaultCellStyle.Format = "₱0.00"

            ' Make readonly
            .ReadOnly = True
            .AllowUserToAddRows = False
        End With
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateDateTimeDisplay()
    End Sub
    Private Sub UpdateDateTimeDisplay()
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Sub
    Private Sub GenerateTransactionNumber()
        currentTransactionNumber = "TXN-" & DateTime.Now.ToString("yyyyMMddHHmmss")
        lblTransactionNo.Text = "Transaction #: " & currentTransactionNumber
    End Sub
    Private Sub btnScanBarcode_Click(sender As Object, e As EventArgs) Handles btnScanBarcode.Click
        Dim scanner As New frmBarcodeScanner()
        AddHandler scanner.BarcodeScanned, AddressOf BarcodeScannedHandler
        If Not scanner.IsDisposed AndAlso Not scanner.Disposing Then
            scanner.ShowDialog()
        End If
    End Sub

    Private Sub BarcodeScannedHandler(barcode As String)
        Try
            ' Look up product in database
            Dim product = GetProductByBarcode(barcode)

            If product IsNot Nothing Then
                ' Check stock availability
                If product.StockQuantity <= 0 Then
                    MessageBox.Show($"Product '{product.ProductName}' is out of stock!",
                                  "Out of Stock",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning)
                    Return
                End If

                ' Add to cart
                AddProductToCart(product)

                ' Play success sound
                SystemSounds.Beep.Play()
            Else
                MessageBox.Show($"Product with barcode {barcode} not found!",
                              "Product Not Found",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error processing barcode: {ex.Message}",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetProductByBarcode(barcode As String) As Product
        Using conn = DatabaseHelper.GetConnection()
            Return conn.QueryFirstOrDefault(Of Product)(
                "SELECT * FROM Products WHERE Barcode = @Barcode AND IsActive = 1",
                New With {.Barcode = barcode})
        End Using
    End Function

    Private Sub AddProductToCart(product As Product)
        ' Check if product already in cart
        Dim existingItem = currentCart.FirstOrDefault(Function(ci) ci.Barcode = product.Barcode)

        If existingItem IsNot Nothing Then
            ' Check if we have enough stock
            If (existingItem.Quantity + 1) > product.StockQuantity Then
                MessageBox.Show($"Cannot add more. Only {product.StockQuantity} available in stock!",
                              "Stock Limit",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning)
                Return
            End If

            ' Update existing item
            existingItem.Quantity += 1
            existingItem.Subtotal = existingItem.Quantity * existingItem.Price
        Else
            ' Add new item
            currentCart.Add(New CartItem With {
                .ProductID = product.ProductID,
                .Barcode = product.Barcode,
                .Name = product.ProductName,
                .Price = product.Price,
                .Quantity = 1,
                .Subtotal = product.Price
            })
        End If

        UpdateCartDisplay()
        CalculateTotals()
    End Sub

    Private Sub UpdateCartDisplay()
        dgvCart.Rows.Clear()

        For Each item In currentCart
            dgvCart.Rows.Add(item.Barcode, item.Name, item.Price, item.Quantity, item.Subtotal)
        Next
    End Sub

    Private Sub CalculateTotals()
        Dim subtotal = currentCart.Sum(Function(item) item.Subtotal)
        Dim vatRate As Decimal = 0.12D ' 12% VAT
        Dim vatAmount = subtotal * vatRate
        Dim total = subtotal + vatAmount

        lblSubtotal.Text = subtotal.ToString("₱#,##0.00")
        lblVAT.Text = vatAmount.ToString("₱#,##0.00")
        lblTotal.Text = total.ToString("₱#,##0.00")
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvCart.SelectedRows.Count = 0 Then Return

        Dim barcode = dgvCart.SelectedRows(0).Cells("Barcode").Value.ToString()
        Dim itemToRemove = currentCart.FirstOrDefault(Function(ci) ci.Barcode = barcode)

        If itemToRemove IsNot Nothing Then
            If itemToRemove.Quantity > 1 Then
                ' Decrease quantity
                itemToRemove.Quantity -= 1
                itemToRemove.Subtotal = itemToRemove.Quantity * itemToRemove.Price
            Else
                ' Remove item completely
                currentCart.Remove(itemToRemove)
            End If

            UpdateCartDisplay()
            CalculateTotals()
        End If
    End Sub

    Private Sub btnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click
        If currentCart.Count = 0 Then
            MessageBox.Show("No items in cart!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim subtotal = currentCart.Sum(Function(item) item.Subtotal)
        Dim paymentForm As New frmPayment(subtotal)

        If paymentForm.ShowDialog() = DialogResult.OK Then
            ProcessTransaction(paymentForm)
        End If
    End Sub

    Private Sub ProcessTransaction(paymentForm As frmPayment)
        Try
            ' Parse total amount safely
            Dim totalAmount As Decimal
            If Not Decimal.TryParse(lblTotal.Text.Replace("₱", "").Trim(), NumberStyles.Currency, CultureInfo.InvariantCulture, totalAmount) Then
                MessageBox.Show("Invalid total amount format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Using conn = DatabaseHelper.GetConnection()
                conn.Open()

                Using transaction = conn.BeginTransaction()
                    Try
                        ' Process sale header with OUTPUT parameter
                        Dim parameters = New DynamicParameters()
                        parameters.Add("@TransactionNumber", currentTransactionNumber)
                        parameters.Add("@TotalAmount", totalAmount)
                        parameters.Add("@CashTendered", paymentForm.CashTendered)
                        parameters.Add("@ChangeAmount", paymentForm.ChangeAmount)
                        parameters.Add("@PaymentMethod", paymentForm.PaymentMethod)
                        parameters.Add("@CashierName", Environment.UserName)
                        parameters.Add("@SaleID", dbType:=DbType.Int32, direction:=ParameterDirection.Output)

                        conn.Execute("sp_ProcessSale", parameters, transaction, commandType:=CommandType.StoredProcedure)

                        ' Get the output parameter value safely
                        Dim saleId As Integer? = parameters.Get(Of Integer?)("@SaleID")

                        If Not saleId.HasValue OrElse saleId.Value <= 0 Then
                            transaction.Rollback()
                            MessageBox.Show("Failed to create sale record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        ' Process each sale item with inventory validation
                        For Each item In currentCart
                            ' Verify stock before processing
                            Dim currentStock = conn.QueryFirstOrDefault(Of Integer?)(
                            "SELECT StockQuantity FROM Products WHERE ProductID = @ProductID",
                            New With {.ProductID = item.ProductID}, transaction)

                            If Not currentStock.HasValue OrElse currentStock.Value < item.Quantity Then
                                transaction.Rollback()
                                MessageBox.Show(
                                $"Insufficient stock for {item.Name}. Available: {If(currentStock.HasValue, currentStock.Value, 0)}",
                                "Stock Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                                Return
                            End If

                            conn.Execute("sp_AddSaleItem", New With {
                            .SaleID = saleId.Value,
                            .ProductID = item.ProductID,
                            .Quantity = item.Quantity,
                            .UnitPrice = item.Price,
                            .Subtotal = item.Subtotal
                        }, transaction, commandType:=CommandType.StoredProcedure)
                        Next

                        transaction.Commit()
                        CompleteTransaction(saleId.Value, paymentForm)

                    Catch ex As SqlException When ex.Number = 547 ' Constraint check violation
                        transaction.Rollback()
                        MessageBox.Show("Database constraint violation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show($"Transaction processing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Transaction initialization failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CompleteTransaction(saleId As Integer, paymentForm As frmPayment)
        ' Print receipt
        PrintReceipt(saleId, paymentForm.PaymentMethod, paymentForm.CashTendered, paymentForm.ChangeAmount)

        ' Reset for new transaction
        currentCart.Clear()
        dgvCart.Rows.Clear()
        lblSubtotal.Text = "₱0.00"
        lblVAT.Text = "₱0.00"
        lblTotal.Text = "₱0.00"
        GenerateTransactionNumber()

        MessageBox.Show("Transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub PrintReceipt(saleId As Integer, paymentMethod As String, cashTendered As Decimal, changeAmount As Decimal)
        ' Basic receipt printing implementation
        Dim receipt As New StringBuilder()

        receipt.AppendLine("7-11 PHILIPPINES")
        receipt.AppendLine("----------------------------")
        receipt.AppendLine($"TXN#: {currentTransactionNumber}")
        receipt.AppendLine($"DATE: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}")
        receipt.AppendLine($"CASHIER: {Environment.UserName}")
        receipt.AppendLine("----------------------------")

        For Each item In currentCart
            receipt.AppendLine($"{item.Name}")
            receipt.AppendLine($"{item.Quantity} x {item.Price.ToString("₱0.00")} = {item.Subtotal.ToString("₱0.00")}")
        Next

        receipt.AppendLine("----------------------------")
        receipt.AppendLine($"SUBTOTAL: {lblSubtotal.Text}")
        receipt.AppendLine($"VAT (12%): {lblVAT.Text}")
        receipt.AppendLine($"TOTAL: {lblTotal.Text}")
        receipt.AppendLine("----------------------------")
        receipt.AppendLine($"PAYMENT METHOD: {paymentMethod}")

        If paymentMethod = "Cash" Then
            receipt.AppendLine($"CASH TENDERED: {cashTendered.ToString("₱0.00")}")
            receipt.AppendLine($"CHANGE: {changeAmount.ToString("₱0.00")}")
        End If

        receipt.AppendLine("----------------------------")
        receipt.AppendLine("THANK YOU FOR SHOPPING!")

        ' TODO: Replace with actual printer code
        MessageBox.Show(receipt.ToString(), "Receipt Preview", MessageBoxButtons.OK)

        ' For actual printing you would use:
        ' PrintDocument class or a reporting tool
    End Sub

    Private Sub btnNewTransaction_Click(sender As Object, e As EventArgs) Handles btnNewTransaction.Click
        If currentCart.Count > 0 Then
            If MessageBox.Show("Start new transaction? Current cart will be cleared.",
                             "Confirm",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question) = DialogResult.Yes Then
                currentCart.Clear()
                dgvCart.Rows.Clear()
                lblSubtotal.Text = "₱0.00"
                lblVAT.Text = "₱0.00"
                lblTotal.Text = "₱0.00"
                GenerateTransactionNumber()
            End If
        End If
    End Sub

    Private Sub btnManageProducts_Click(sender As Object, e As EventArgs) Handles btnManageProducts.Click
        Dim form As New frmProductManagement()
        form.ShowDialog()
        Me.Close()
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

    ''for round form
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(
    nLeftRect As Integer,
    nTopRect As Integer,
    nRightRect As Integer,
    nBottomRect As Integer,
    nWidthEllipse As Integer,
    nHeightEllipse As Integer) As IntPtr
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

End Class