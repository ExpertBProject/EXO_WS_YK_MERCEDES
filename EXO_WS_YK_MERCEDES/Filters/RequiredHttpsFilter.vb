Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Web
Imports System.Web.Http.Controllers
Imports System.Web.Http.Filters


Namespace EXO_WS_YK_MERCEDES.Filters



    Public Class RequiredHttpsFilter
        Inherits AuthorizationFilterAttribute
        Public Overrides Sub OnAuthorization(actionContext As HttpActionContext)
            Dim req As HttpRequestMessage = actionContext.Request
            If (req.RequestUri.Scheme <> Uri.UriSchemeHttps) Then
                Dim html As String = "<p>HTTPS is mandatory</p>"

                Dim content As StringContent = New StringContent(html, Encoding.UTF8, "text/html")
                actionContext.Response = req.CreateResponse(HttpStatusCode.NotFound)
                actionContext.Response.Content = content
            End If
        End Sub
    End Class

End Namespace

