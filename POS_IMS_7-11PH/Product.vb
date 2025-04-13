Public Class Product
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