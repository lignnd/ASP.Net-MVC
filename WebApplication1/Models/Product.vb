Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Product")>
Partial Public Class Product
    Public Sub New()
        CustomerOrders = New HashSet(Of CustomerOrder)()
    End Sub

    Public Property Id As Long

    <Required>
    <StringLength(255)>
    Public Property Name As String

    Public Property Price As Decimal

    <StringLength(255)>
    Public Property Description As String

    Public Property CategoryId As Long

    Public Overridable Property Category As Category

    Public Overridable Property CustomerOrders As ICollection(Of CustomerOrder)
End Class
