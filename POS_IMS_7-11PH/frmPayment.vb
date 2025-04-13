Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class frmPayment
    Public Property PaymentMethod As String
    Public Property CashTendered As Decimal
    Public Property ChangeAmount As Decimal

    Private ReadOnly _totalAmount As Decimal

    Public Sub New(totalAmount As Decimal)
        InitializeComponent()
        _totalAmount = totalAmount
        lblTotalAmount.Text = totalAmount.ToString("₱#,##0.00")
    End Sub

    Private Sub txtCashTendered_TextChanged(sender As Object, e As EventArgs) Handles txtCashTendered.TextChanged
        Dim cash As Decimal
        If Decimal.TryParse(txtCashTendered.Text, cash) AndAlso cash >= _totalAmount Then
            lblChangeAmount.Text = (cash - _totalAmount).ToString("₱#,##0.00")
        Else
            lblChangeAmount.Text = "₱0.00"
        End If
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        If cboPaymentMethod.SelectedIndex = -1 Then
            MessageBox.Show("Please select payment method!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cash As Decimal
        If cboPaymentMethod.Text = "Cash" AndAlso Not Decimal.TryParse(txtCashTendered.Text, cash) Then
            MessageBox.Show("Please enter valid cash amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboPaymentMethod.Text = "Cash" AndAlso cash < _totalAmount Then
            MessageBox.Show("Cash tendered is less than total amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Me.PaymentMethod = cboPaymentMethod.Text
        Me.CashTendered = If(cboPaymentMethod.Text = "Cash", cash, _totalAmount)
        Me.ChangeAmount = If(cboPaymentMethod.Text = "Cash", cash - _totalAmount, 0)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cboPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaymentMethod.SelectedIndexChanged
        If cboPaymentMethod.Text = "Cash" Then
            txtCashTendered.Enabled = True
            txtCashTendered.Focus()
        Else
            txtCashTendered.Enabled = False
            txtCashTendered.Text = _totalAmount.ToString()
        End If
    End Sub

    Private Sub frmPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    ''gradient paint for form
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

End Class