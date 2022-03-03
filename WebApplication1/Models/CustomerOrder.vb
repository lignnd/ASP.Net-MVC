Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("CustomerOrder")>
Partial Public Class CustomerOrder
    Public Property Id As Long

    Public Property CustomerId As Long

    Public Property ProductId As Long

    Public Property Amount As Integer

    Public Property OrderDate As Date

    Public Overridable Property Customer As Customer

    Public Overridable Property Product As Product
End Class
