Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Category")>
Partial Public Class Category
    Public Sub New()
        Products = New HashSet(Of Product)()
    End Sub

    Public Property Id As Long

    <Required>
    <StringLength(255)>
    Public Property Name As String

    <StringLength(255)>
    Public Property Description As String

    Public Overridable Property Products As ICollection(Of Product)
End Class
