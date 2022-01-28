Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports Swashbuckle.Application
Imports System.Web.Http

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapHttpRoute(name:="swagger_root", routeTemplate:="", defaults:=Nothing, constraints:=Nothing, handler:=New RedirectHandler((Function(message) message.RequestUri.ToString()), "swagger"))


        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )
    End Sub
End Module