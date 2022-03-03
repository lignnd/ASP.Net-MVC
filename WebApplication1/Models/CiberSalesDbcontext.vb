Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class CiberSalesDbcontext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=CiberSalesDbcontext")
    End Sub

    Public Overridable Property Categories As DbSet(Of Category)
    Public Overridable Property Customers As DbSet(Of Customer)
    Public Overridable Property CustomerOrders As DbSet(Of CustomerOrder)
    Public Overridable Property Products As DbSet(Of Product)
    Public Overridable Property sysdiagrams As DbSet(Of sysdiagram)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Category)() _
            .HasMany(Function(e) e.Products) _
            .WithRequired(Function(e) e.Category) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Customer)() _
            .HasMany(Function(e) e.CustomerOrders) _
            .WithRequired(Function(e) e.Customer) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Product)() _
            .Property(Function(e) e.Price) _
            .HasPrecision(8, 2)

        modelBuilder.Entity(Of Product)() _
            .HasMany(Function(e) e.CustomerOrders) _
            .WithRequired(Function(e) e.Product) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
