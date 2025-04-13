<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayment
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
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblChangeAmount = New System.Windows.Forms.Label()
        Me.txtCashTendered = New System.Windows.Forms.TextBox()
        Me.cboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI Semibold", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalAmount.Location = New System.Drawing.Point(512, 242)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(230, 50)
        Me.lblTotalAmount.TabIndex = 0
        Me.lblTotalAmount.Text = "totalamount"
        '
        'lblChangeAmount
        '
        Me.lblChangeAmount.AutoSize = True
        Me.lblChangeAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblChangeAmount.Font = New System.Drawing.Font("Segoe UI Semibold", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeAmount.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblChangeAmount.Location = New System.Drawing.Point(512, 416)
        Me.lblChangeAmount.Name = "lblChangeAmount"
        Me.lblChangeAmount.Size = New System.Drawing.Size(275, 50)
        Me.lblChangeAmount.TabIndex = 1
        Me.lblChangeAmount.Text = "changeamount"
        '
        'txtCashTendered
        '
        Me.txtCashTendered.Font = New System.Drawing.Font("Segoe UI Semibold", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashTendered.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtCashTendered.Location = New System.Drawing.Point(521, 339)
        Me.txtCashTendered.Name = "txtCashTendered"
        Me.txtCashTendered.Size = New System.Drawing.Size(303, 54)
        Me.txtCashTendered.TabIndex = 2
        Me.txtCashTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPaymentMethod
        '
        Me.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMethod.Font = New System.Drawing.Font("Segoe UI Semibold", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPaymentMethod.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboPaymentMethod.FormattingEnabled = True
        Me.cboPaymentMethod.Items.AddRange(New Object() {"Cash", "Credit Card", "Debit Card", "GCash", "Paypal", "Paymaya"})
        Me.cboPaymentMethod.Location = New System.Drawing.Point(514, 155)
        Me.cboPaymentMethod.Name = "cboPaymentMethod"
        Me.cboPaymentMethod.Size = New System.Drawing.Size(394, 55)
        Me.cboPaymentMethod.TabIndex = 3
        '
        'btnProcess
        '
        Me.btnProcess.AutoSize = True
        Me.btnProcess.BackColor = System.Drawing.Color.Green
        Me.btnProcess.Font = New System.Drawing.Font("Segoe UI Semibold", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcess.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnProcess.Location = New System.Drawing.Point(471, 609)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(316, 60)
        Me.btnProcess.TabIndex = 4
        Me.btnProcess.Text = "Process Payment"
        Me.btnProcess.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(90, 242)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 50)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Amount To Be Payed:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(337, 416)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 50)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Change:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Black", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(210, 339)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(305, 50)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Amount Given: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Black", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(159, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(347, 50)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Payment Method:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Black", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(451, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(360, 86)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "PAYMENT"
        '
        'frmPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.cboPaymentMethod)
        Me.Controls.Add(Me.txtCashTendered)
        Me.Controls.Add(Me.lblChangeAmount)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Name = "frmPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPayment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblChangeAmount As Label
    Friend WithEvents txtCashTendered As TextBox
    Friend WithEvents cboPaymentMethod As ComboBox
    Friend WithEvents btnProcess As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
