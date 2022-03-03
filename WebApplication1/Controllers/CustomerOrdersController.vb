Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports WebApplication1

Namespace Controllers
    Public Class CustomerOrdersController
        Inherits System.Web.Mvc.Controller

        Private db As New CiberSalesDbcontext

        ' GET: CustomerOrders
        Function Index() As ActionResult
            Dim customerOrders = db.CustomerOrders.Include(Function(c) c.Customer).Include(Function(c) c.Product)
            Return View(customerOrders.ToList())
        End Function

        ' GET: CustomerOrders/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customerOrder As CustomerOrder = db.CustomerOrders.Find(id)
            If IsNothing(customerOrder) Then
                Return HttpNotFound()
            End If
            Return View(customerOrder)
        End Function

        ' GET: CustomerOrders/Create
        Function Create() As ActionResult
            ViewBag.CustomerId = New SelectList(db.Customers, "Id", "Name")
            ViewBag.ProductId = New SelectList(db.Products, "Id", "Name")
            Return View()
        End Function

        ' POST: CustomerOrders/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,CustomerId,ProductId,Amount,OrderDate")> ByVal customerOrder As CustomerOrder) As ActionResult
            If ModelState.IsValid Then
                db.CustomerOrders.Add(customerOrder)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CustomerId = New SelectList(db.Customers, "Id", "Name", customerOrder.CustomerId)
            ViewBag.ProductId = New SelectList(db.Products, "Id", "Name", customerOrder.ProductId)
            Return View(customerOrder)
        End Function

        ' GET: CustomerOrders/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customerOrder As CustomerOrder = db.CustomerOrders.Find(id)
            If IsNothing(customerOrder) Then
                Return HttpNotFound()
            End If
            ViewBag.CustomerId = New SelectList(db.Customers, "Id", "Name", customerOrder.CustomerId)
            ViewBag.ProductId = New SelectList(db.Products, "Id", "Name", customerOrder.ProductId)
            Return View(customerOrder)
        End Function

        ' POST: CustomerOrders/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,CustomerId,ProductId,Amount,OrderDate")> ByVal customerOrder As CustomerOrder) As ActionResult
            If ModelState.IsValid Then
                db.Entry(customerOrder).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CustomerId = New SelectList(db.Customers, "Id", "Name", customerOrder.CustomerId)
            ViewBag.ProductId = New SelectList(db.Products, "Id", "Name", customerOrder.ProductId)
            Return View(customerOrder)
        End Function

        ' GET: CustomerOrders/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customerOrder As CustomerOrder = db.CustomerOrders.Find(id)
            If IsNothing(customerOrder) Then
                Return HttpNotFound()
            End If
            Return View(customerOrder)
        End Function

        ' POST: CustomerOrders/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim customerOrder As CustomerOrder = db.CustomerOrders.Find(id)
            db.CustomerOrders.Remove(customerOrder)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
