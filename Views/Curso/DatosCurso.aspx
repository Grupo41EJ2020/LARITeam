<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVCLaboratorio.Models.Curso>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Datos del Curso</title>
</head>
<body>
    <table>
        <h1>Listado de Cursos
       </h1>
        <tr>
            <th></th>
            <th>
                IdCurso
            </th>
           
            <th>
                IdEmpleado
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "CursoEdit", new {id=item.IdCurso}) %> |
                <%: Html.ActionLink("Detalles", "CursoDetails", new {id=item.IdCurso })%> |
                <%: Html.ActionLink("Borrar", "CursoDelete", new {id=item.IdCurso })%>
            </td>
            <td>
                <%: item.IdCurso %>
            </td>

            <td>
                <%: item.IdEmpleado %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear nuevo Curso", "Create") %>
    </p>
    <a href="/Home/Index">Regresar al inicio</a>
</body>
</html>

