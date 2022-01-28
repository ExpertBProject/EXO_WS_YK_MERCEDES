Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports EXO_WS_YK_MERCEDES.EXO_WS_YK_MERCEDES.Filters

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)

        'config.Filters.Add(New RequiredHttpsFilter())

        ' Configuración y servicios de API web
        config.Filters.Add(New WsRestBasicAuthorizeAttribute())

        ' Rutas de API web
        config.MapHttpAttributeRoutes()



        'config.Routes.MapHttpRoute(
        '    name:="DefaultApi",
        '    routeTemplate:="api/{controller}/{id}",
        '    defaults:=New With {.id = RouteParameter.Optional}
        ')
    End Sub
End Module
