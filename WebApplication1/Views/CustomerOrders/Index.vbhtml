@ModelType IEnumerable(Of WebApplication1.CustomerOrder)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Customer.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Product.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Amount)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.OrderDate)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Customer.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Product.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Amount)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.OrderDate)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
