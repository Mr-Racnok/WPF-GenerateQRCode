Imports QRCoder
Imports System.Drawing
Imports System.IO

Class MainWindow
    Private Sub Start_GenerateQR()
        GenerateQRCode()
    End Sub
    Private Sub GenerateQRCode()
        ' Menentukan ukuran pixel per modul untuk ukuran QR Code yang lebih besar
        Dim pixelsPerModule As Integer = 20 ' Misalnya, mengatur lebar dan tinggi setiap modul QR Code

        ' Membuat QR Code generator dan menghasilkan data QR Code
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(Input.Text, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As New QRCode(qrCodeData)
        Dim qrCodeImage As Bitmap = qrCode.GetGraphic(pixelsPerModule, Color.Black, Color.White, True)

        ' Menghitung dimensi QR Code dalam pixel
        Dim qrCodeWidth As Integer = MyQRCodeImage.Width
        Dim qrCodeHeight As Integer = MyQRCodeImage.Height

        ' Convert Bitmap to BitmapImage for WPF
        Dim bitmapImage As New BitmapImage()
        Using memory As New MemoryStream()
            qrCodeImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png)
            memory.Position = 0
            bitmapImage.BeginInit()
            bitmapImage.StreamSource = memory
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad
            bitmapImage.EndInit()
        End Using

        ' Mengatur ukuran kontrol Image sesuai ukuran QR Code
        MyQRCodeImage.Width = qrCodeWidth
        MyQRCodeImage.Height = qrCodeHeight
        MyQRCodeImage.Source = bitmapImage
    End Sub
End Class
