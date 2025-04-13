<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblCashier = New System.Windows.Forms.Label()
        Me.lblTransactionNo = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnScanBarcode = New System.Windows.Forms.Button()
        Me.btnProcessPayment = New System.Windows.Forms.Button()
        Me.btnNewTransaction = New System.Windows.Forms.Button()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.btnManageProducts = New System.Windows.Forms.Button()
        Me.NavPanel = New System.Windows.Forms.Panel()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDateTime.Location = New System.Drawing.Point(374, 622)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(143, 40)
        Me.lblDateTime.TabIndex = 0
        Me.lblDateTime.Text = "DateTime"
        '
        'lblCashier
        '
        Me.lblCashier.AutoSize = True
        Me.lblCashier.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashier.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblCashier.Location = New System.Drawing.Point(24, 34)
        Me.lblCashier.Name = "lblCashier"
        Me.lblCashier.Size = New System.Drawing.Size(114, 40)
        Me.lblCashier.TabIndex = 1
        Me.lblCashier.Text = "Cashier"
        '
        'lblTransactionNo
        '
        Me.lblTransactionNo.AutoSize = True
        Me.lblTransactionNo.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTransactionNo.Location = New System.Drawing.Point(374, 34)
        Me.lblTransactionNo.Name = "lblTransactionNo"
        Me.lblTransactionNo.Size = New System.Drawing.Size(134, 40)
        Me.lblTransactionNo.TabIndex = 2
        Me.lblTransactionNo.Text = "transac#"
        '
        'Timer1
        '
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTotal.Location = New System.Drawing.Point(181, 548)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(34, 40)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "0"
        '
        'btnScanBarcode
        '
        Me.btnScanBarcode.AutoSize = True
        Me.btnScanBarcode.BackColor = System.Drawing.Color.DarkGreen
        Me.btnScanBarcode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScanBarcode.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanBarcode.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnScanBarcode.Location = New System.Drawing.Point(826, 612)
        Me.btnScanBarcode.Margin = New System.Windows.Forms.Padding(0)
        Me.btnScanBarcode.Name = "btnScanBarcode"
        Me.btnScanBarcode.Size = New System.Drawing.Size(129, 50)
        Me.btnScanBarcode.TabIndex = 4
        Me.btnScanBarcode.Text = "Scan"
        Me.btnScanBarcode.UseVisualStyleBackColor = False
        '
        'btnProcessPayment
        '
        Me.btnProcessPayment.AutoSize = True
        Me.btnProcessPayment.BackColor = System.Drawing.Color.DarkGreen
        Me.btnProcessPayment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcessPayment.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcessPayment.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnProcessPayment.Location = New System.Drawing.Point(28, 612)
        Me.btnProcessPayment.Margin = New System.Windows.Forms.Padding(0)
        Me.btnProcessPayment.Name = "btnProcessPayment"
        Me.btnProcessPayment.Size = New System.Drawing.Size(293, 50)
        Me.btnProcessPayment.TabIndex = 5
        Me.btnProcessPayment.Text = "Proceed To Payment"
        Me.btnProcessPayment.UseVisualStyleBackColor = False
        '
        'btnNewTransaction
        '
        Me.btnNewTransaction.AutoSize = True
        Me.btnNewTransaction.BackColor = System.Drawing.Color.DarkGreen
        Me.btnNewTransaction.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNewTransaction.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewTransaction.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnNewTransaction.Location = New System.Drawing.Point(977, 612)
        Me.btnNewTransaction.Margin = New System.Windows.Forms.Padding(0)
        Me.btnNewTransaction.Name = "btnNewTransaction"
        Me.btnNewTransaction.Size = New System.Drawing.Size(129, 50)
        Me.btnNewTransaction.TabIndex = 6
        Me.btnNewTransaction.Text = "New"
        Me.btnNewTransaction.UseVisualStyleBackColor = False
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.AutoSize = True
        Me.btnRemoveItem.BackColor = System.Drawing.Color.DarkGreen
        Me.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveItem.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveItem.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnRemoveItem.Location = New System.Drawing.Point(1120, 612)
        Me.btnRemoveItem.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(132, 50)
        Me.btnRemoveItem.TabIndex = 7
        Me.btnRemoveItem.Text = "Remove"
        Me.btnRemoveItem.UseVisualStyleBackColor = False
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.AllowUserToDeleteRows = False
        Me.dgvCart.AllowUserToResizeColumns = False
        Me.dgvCart.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCart.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvCart.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCart.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCart.GridColor = System.Drawing.Color.DarkGreen
        Me.dgvCart.Location = New System.Drawing.Point(381, 77)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowFrame
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCart.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Green
        Me.dgvCart.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCart.Size = New System.Drawing.Size(871, 511)
        Me.dgvCart.TabIndex = 8
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblSubtotal.Location = New System.Drawing.Point(181, 446)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(34, 40)
        Me.lblSubtotal.TabIndex = 9
        Me.lblSubtotal.Text = "0"
        '
        'lblVAT
        '
        Me.lblVAT.AutoSize = True
        Me.lblVAT.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVAT.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblVAT.Location = New System.Drawing.Point(181, 499)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(34, 40)
        Me.lblVAT.TabIndex = 10
        Me.lblVAT.Text = "0"
        '
        'btnManageProducts
        '
        Me.btnManageProducts.AutoSize = True
        Me.btnManageProducts.BackColor = System.Drawing.Color.DarkGreen
        Me.btnManageProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManageProducts.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageProducts.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnManageProducts.Location = New System.Drawing.Point(49, 178)
        Me.btnManageProducts.Margin = New System.Windows.Forms.Padding(0)
        Me.btnManageProducts.Name = "btnManageProducts"
        Me.btnManageProducts.Size = New System.Drawing.Size(257, 50)
        Me.btnManageProducts.TabIndex = 11
        Me.btnManageProducts.Text = "Manage Products"
        Me.btnManageProducts.UseVisualStyleBackColor = False
        '
        'NavPanel
        '
        Me.NavPanel.BackColor = System.Drawing.Color.Transparent
        Me.NavPanel.Controls.Add(Me.Label3)
        Me.NavPanel.Controls.Add(Me.Label2)
        Me.NavPanel.Controls.Add(Me.Label1)
        Me.NavPanel.Controls.Add(Me.lblVAT)
        Me.NavPanel.Controls.Add(Me.btnProcessPayment)
        Me.NavPanel.Controls.Add(Me.lblTotal)
        Me.NavPanel.Controls.Add(Me.btnManageProducts)
        Me.NavPanel.Controls.Add(Me.lblSubtotal)
        Me.NavPanel.Controls.Add(Me.lblCashier)
        Me.NavPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavPanel.Location = New System.Drawing.Point(0, 0)
        Me.NavPanel.Name = "NavPanel"
        Me.NavPanel.Size = New System.Drawing.Size(358, 681)
        Me.NavPanel.TabIndex = 12
        '
        'closeBtn
        '
        Me.closeBtn.AutoSize = True
        Me.closeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.closeBtn.Font = New System.Drawing.Font("Segoe UI Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.Red
        Me.closeBtn.Location = New System.Drawing.Point(1204, 9)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(31, 31)
        Me.closeBtn.TabIndex = 13
        Me.closeBtn.Text = "X"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(28, 446)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 40)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Subtotal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(3, 499)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 40)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "VAT (12%):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(77, 548)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 40)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Total:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.btnScanBarcode)
        Me.Controls.Add(Me.closeBtn)
        Me.Controls.Add(Me.NavPanel)
        Me.Controls.Add(Me.dgvCart)
        Me.Controls.Add(Me.btnRemoveItem)
        Me.Controls.Add(Me.btnNewTransaction)
        Me.Controls.Add(Me.lblTransactionNo)
        Me.Controls.Add(Me.lblDateTime)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavPanel.ResumeLayout(False)
        Me.NavPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblCashier As Label
    Friend WithEvents lblTransactionNo As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnScanBarcode As Button
    Friend WithEvents btnProcessPayment As Button
    Friend WithEvents btnNewTransaction As Button
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblVAT As Label
    Friend WithEvents btnManageProducts As Button
    Friend WithEvents NavPanel As Panel
    Friend WithEvents closeBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
