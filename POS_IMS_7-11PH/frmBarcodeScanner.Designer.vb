<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarcodeScanner
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
        Me.pbCamera = New System.Windows.Forms.PictureBox()
        Me.cboCameras = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tmrScanTimeout = New System.Windows.Forms.Timer(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.pbCamera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbCamera
        '
        Me.pbCamera.BackColor = System.Drawing.Color.Transparent
        Me.pbCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbCamera.Location = New System.Drawing.Point(419, 12)
        Me.pbCamera.Name = "pbCamera"
        Me.pbCamera.Size = New System.Drawing.Size(833, 657)
        Me.pbCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCamera.TabIndex = 0
        Me.pbCamera.TabStop = False
        '
        'cboCameras
        '
        Me.cboCameras.FormattingEnabled = True
        Me.cboCameras.Location = New System.Drawing.Point(50, 104)
        Me.cboCameras.Name = "cboCameras"
        Me.cboCameras.Size = New System.Drawing.Size(314, 21)
        Me.cboCameras.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(41, 139)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(323, 136)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tmrScanTimeout
        '
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(129, 319)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(127, 47)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmBarcodeScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cboCameras)
        Me.Controls.Add(Me.pbCamera)
        Me.Name = "frmBarcodeScanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBarcodeScanner"
        CType(Me.pbCamera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbCamera As PictureBox
    Friend WithEvents cboCameras As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents tmrScanTimeout As Timer
    Friend WithEvents btnCancel As Button
End Class
