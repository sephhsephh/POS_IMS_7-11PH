<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductDetails
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
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.numPrice = New System.Windows.Forms.NumericUpDown()
        Me.numCost = New System.Windows.Forms.NumericUpDown()
        Me.NumStock = New System.Windows.Forms.NumericUpDown()
        Me.numReorderLevel = New System.Windows.Forms.NumericUpDown()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numReorderLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(270, 152)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(357, 50)
        Me.txtBarcode.TabIndex = 0
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(270, 230)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(357, 50)
        Me.txtName.TabIndex = 1
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(270, 295)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(357, 118)
        Me.txtDescription.TabIndex = 2
        '
        'txtCategory
        '
        Me.txtCategory.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(270, 429)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(357, 50)
        Me.txtCategory.TabIndex = 3
        '
        'numPrice
        '
        Me.numPrice.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPrice.Location = New System.Drawing.Point(943, 165)
        Me.numPrice.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numPrice.Name = "numPrice"
        Me.numPrice.Size = New System.Drawing.Size(283, 50)
        Me.numPrice.TabIndex = 4
        '
        'numCost
        '
        Me.numCost.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCost.Location = New System.Drawing.Point(943, 224)
        Me.numCost.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numCost.Name = "numCost"
        Me.numCost.Size = New System.Drawing.Size(283, 50)
        Me.numCost.TabIndex = 5
        '
        'NumStock
        '
        Me.NumStock.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumStock.Location = New System.Drawing.Point(943, 296)
        Me.NumStock.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumStock.Name = "NumStock"
        Me.NumStock.Size = New System.Drawing.Size(162, 50)
        Me.NumStock.TabIndex = 6
        '
        'numReorderLevel
        '
        Me.numReorderLevel.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numReorderLevel.Location = New System.Drawing.Point(943, 356)
        Me.numReorderLevel.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numReorderLevel.Name = "numReorderLevel"
        Me.numReorderLevel.Size = New System.Drawing.Size(162, 50)
        Me.numReorderLevel.TabIndex = 7
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.BackColor = System.Drawing.Color.Transparent
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.ForeColor = System.Drawing.Color.White
        Me.chkActive.Location = New System.Drawing.Point(943, 417)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(150, 54)
        Me.chkActive.TabIndex = 8
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSave.Location = New System.Drawing.Point(1066, 572)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(186, 75)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Location = New System.Drawing.Point(44, 572)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(186, 75)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(113, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 40)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Barcode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(37, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(222, 40)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Product Name"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(44, 302)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 83)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Product Description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(113, 429)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 40)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Category"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(774, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 40)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Sale Price"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(638, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(290, 40)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Cost From Supplier"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(833, 302)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 40)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Stock"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Black", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(714, 362)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(214, 40)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Reorder Level"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Location = New System.Drawing.Point(383, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(583, 86)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "PRODUCT EDITOR"
        '
        'frmProductDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.numReorderLevel)
        Me.Controls.Add(Me.NumStock)
        Me.Controls.Add(Me.numCost)
        Me.Controls.Add(Me.numPrice)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtBarcode)
        Me.Name = "frmProductDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmProductDetails"
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numReorderLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents numPrice As NumericUpDown
    Friend WithEvents numCost As NumericUpDown
    Friend WithEvents NumStock As NumericUpDown
    Friend WithEvents numReorderLevel As NumericUpDown
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class
