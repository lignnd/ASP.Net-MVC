Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Customer")>
Partial Public Class Customer
    Public Sub New()
        CustomerOrders = New HashSet(Of CustomerOrder)()
    End Sub

    Public Property Id As Long

    <Required>
    <StringLength(255)>
    Public Property Name As String

    <Required>
    <StringLength(255)>
    Public Property Address As String

    Public Overridable Property CustomerOrders As ICollection(Of CustomerOrder)
End Class
