Imports System
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Security.Principal
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web.Http.Controllers
Imports System.Web.Http.Filters

Namespace EXO_WS_YK_MERCEDES.Filters


    Public Class WsRestBasicAuthorizeAttribute
        Inherits AuthorizationFilterAttribute
#Region "PRIVATE METHODS"

        Private Sub HandleUnauthorized(actionContext As HttpActionContext)
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized)
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic scheme='ADManagement' location='http://localhost:53447/api/WsRest'")
        End Sub

        Private Function GetUserName(input As String) As String

            Dim regex As Regex = New Regex("^([^:]+?):")
            Return regex.Match(input).Groups(1).Value
        End Function

        Private Function GetPassword(input As String) As String
            Dim Regex As Regex = New Regex(":(.*)")
            Return Regex.Match(input).Groups(1).Value
        End Function



        'Este método es el encargado de comprobar si el usuario y la contraseña son correctos
        Private Function ValidateUser(userName As String, password As String) As Boolean
            'Password codificado: JEFOZ2U3NUBiWnZr
            'DECODE BASE64 DE PASSWORD PARA COMPARAR
            Dim b64password As String = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(password))

            If userName = "YkMercedes" And b64password = "$ANge75@bZvk" Then
                Return True
            Else
                Return False
            End If

        End Function

        Private Function BasicAuthentication(actionContext As HttpActionContext) As Boolean
            BasicAuthentication = True
            If Thread.CurrentPrincipal.Identity.IsAuthenticated Then
                Dim sRoles As String() = Nothing
                Dim authHeader As AuthenticationHeaderValue = actionContext.Request.Headers.Authorization
                If authHeader IsNot Nothing Then
                    If ((authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase)) And Not (String.IsNullOrWhiteSpace(authHeader.Parameter))) Then
                        Dim rawCredentials As String = authHeader.Parameter
                        Dim Encoding As Encoding = Encoding.GetEncoding("iso-8859-1")
                        Dim credentials As String = Encoding.GetString(Convert.FromBase64String(rawCredentials))
                        Dim userName As String = GetUserName(credentials)
                        Dim password As String = GetPassword(credentials)
                        If (ValidateUser(userName, password)) Then
                            Thread.CurrentPrincipal = New GenericPrincipal(New GenericIdentity(userName), sRoles)
                            Return True
                        End If
                    End If
                End If
                HandleUnauthorized(actionContext)
            End If
            BasicAuthentication = False

        End Function
#End Region

#Region "PUBLIC METHODS"
        Public Overrides Sub OnAuthorization(actionContext As HttpActionContext)
            BasicAuthentication(actionContext)
        End Sub
#End Region
    End Class

End Namespace
