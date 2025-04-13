Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports System.Threading
Imports System.Media
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class frmBarcodeScanner
    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice
    Private isScanning As Boolean = False
    Private previousFrame As Bitmap = Nothing
    Private closingForm As Boolean = False
    Private lastScanTime As DateTime = DateTime.MinValue
    Private scanDelay As Integer = 1 ' milliseconds between scans
    Private scanTimeout As Integer = 30000 ' 30 second timeout
    Private scanStartTime As DateTime

    Public Event BarcodeScanned(barcode As String)

    Private Sub frmBarcodeScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up UI
        pbCamera.SizeMode = PictureBoxSizeMode.Zoom
        pbCamera.BorderStyle = BorderStyle.FixedSingle
        lblStatus.Text = "Initializing scanner..."

        ' Initialize camera
        InitializeCameraSelection()

        ' Set scan timeout
        scanStartTime = DateTime.Now
        tmrScanTimeout.Interval = 1000
        tmrScanTimeout.Start()



        ApplyRoundedCornersToAllButtons(Me)

        ' Make form borderless and apply rounded corners
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, 30, 30))
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
    Private Sub InitializeCameraSelection()
        Try
            videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            cboCameras.Items.Clear()

            If videoDevices.Count > 0 Then
                For Each device As FilterInfo In videoDevices
                    cboCameras.Items.Add(device.Name)
                Next
                cboCameras.SelectedIndex = 0
                lblStatus.Text = "Ready to scan - point at barcode"
            Else
                lblStatus.Text = "No cameras found!"
                MessageBox.Show("No cameras detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
            lblStatus.Text = "Camera initialization failed"
            MessageBox.Show($"Camera initialization error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub cboCameras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCameras.SelectedIndexChanged
        If cboCameras.SelectedIndex >= 0 AndAlso cboCameras.SelectedIndex < videoDevices.Count Then
            lblStatus.Text = "Switching camera..."
            StopCamera()
            StartCamera(videoDevices(cboCameras.SelectedIndex).MonikerString)
            lblStatus.Text = "Ready to scan - point at barcode"
        End If
    End Sub

    Private Sub StartCamera(monikerString As String)
        Try
            videoSource = New VideoCaptureDevice(monikerString)

            ' Select optimal resolution (balance between quality and performance)
            If videoSource.VideoCapabilities.Length > 0 Then
                ' Find resolution closest to 640x480 for best performance
                Dim bestResolution = videoSource.VideoCapabilities.
                    OrderBy(Function(r) Math.Abs(r.FrameSize.Width - 640)).First()
                videoSource.VideoResolution = bestResolution
            End If

            AddHandler videoSource.NewFrame, AddressOf VideoSource_NewFrame
            videoSource.Start()
            isScanning = True
            lblStatus.Text = "Ready to scan - point at barcode"
        Catch ex As Exception
            lblStatus.Text = "Camera start failed"
            MessageBox.Show($"Failed to start camera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub StopCamera()
        If videoSource IsNot Nothing Then
            isScanning = False
            lblStatus.Text = "Stopping camera..."

            ' Signal to stop
            If videoSource.IsRunning Then
                videoSource.SignalToStop()
            End If

            ' Wait with timeout
            Dim stopWatch As New Stopwatch()
            stopWatch.Start()

            While videoSource.IsRunning AndAlso stopWatch.ElapsedMilliseconds < 3000
                Application.DoEvents()
                Thread.Sleep(100)
            End While

            ' Force stop if needed
            If videoSource.IsRunning Then
                videoSource.Stop()
            End If

            RemoveHandler videoSource.NewFrame, AddressOf VideoSource_NewFrame
            videoSource = Nothing
        End If
    End Sub

    Private Sub VideoSource_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        If Not isScanning OrElse closingForm Then Return

        ' Limit scan rate to prevent CPU overload
        If (DateTime.Now - lastScanTime).TotalMilliseconds < scanDelay Then Return

        Try
            Dim bitmap As Bitmap = Nothing
            Try
                ' Get the frame
                bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)

                ' Clean up previous frame
                If previousFrame IsNot Nothing Then
                    previousFrame.Dispose()
                    previousFrame = Nothing
                End If
                previousFrame = bitmap.Clone()

                ' Update UI on main thread
                Me.Invoke(Sub()
                              If closingForm Then Return

                              If pbCamera.Image IsNot Nothing Then
                                  pbCamera.Image.Dispose()
                              End If
                              pbCamera.Image = DirectCast(bitmap.Clone(), Bitmap)
                          End Sub)

                ' Configure barcode reader
                Dim barcodeReader As New BarcodeReader() With {
                    .AutoRotate = True,
                    .Options = New ZXing.Common.DecodingOptions With {
                        .PossibleFormats = New List(Of BarcodeFormat) From {
                            BarcodeFormat.EAN_13,  ' Standard product barcodes
                            BarcodeFormat.UPC_A,   ' UPC codes
                            BarcodeFormat.CODE_128 ' Some product codes
                        },
                        .TryHarder = True
                    }
                }

                ' Scan for barcodes
                Dim result = barcodeReader.Decode(bitmap)
                lastScanTime = DateTime.Now

                If result IsNot Nothing Then
                    isScanning = False
                    Me.Invoke(Sub()
                                  If Not String.IsNullOrWhiteSpace(result.Text) Then
                                      SystemSounds.Beep.Play() ' Audible feedback
                                      lblStatus.Text = "Barcode found!"

                                      ' Stop the camera first
                                      closingForm = True ' Set this flag first
                                      If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
                                          videoSource.SignalToStop()
                                      End If

                                      ' Raise the event before closing
                                      RaiseEvent BarcodeScanned(result.Text)

                                      ' Use BeginInvoke to close the form asynchronously
                                      Me.BeginInvoke(Sub() Me.Close())
                                  Else
                                      lblStatus.Text = "Invalid barcode - try again"
                                      isScanning = True ' Continue scanning
                                  End If
                              End Sub)
                End If
            Finally
                If bitmap IsNot Nothing Then
                    bitmap.Dispose()
                End If
            End Try
        Catch ex As Exception
            Me.Invoke(Sub()
                          lblStatus.Text = "Scan error - try again"
                          If MessageBox.Show("Scanner error: " & ex.Message & vbCrLf & "Try again?",
                             "Scan Error",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Error) = DialogResult.No Then
                              Me.Close()
                          End If
                      End Sub)
        End Try
    End Sub

    Private Sub tmrScanTimeout_Tick(sender As Object, e As EventArgs) Handles tmrScanTimeout.Tick
        ' Auto-close after timeout period
        If (DateTime.Now - scanStartTime).TotalMilliseconds > scanTimeout Then
            Me.Invoke(Sub()
                          lblStatus.Text = "Scan timeout - closing"
                          Me.Close()
                      End Sub)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmBarcodeScanner_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        closingForm = True
        tmrScanTimeout.Stop()
        StopCamera()

        ' Clean up resources
        If pbCamera.Image IsNot Nothing Then
            pbCamera.Image.Dispose()
            pbCamera.Image = Nothing
        End If

        If previousFrame IsNot Nothing Then
            previousFrame.Dispose()
            previousFrame = Nothing
        End If

        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub frmBarcodeScanner_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Allow closing with Escape key
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
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