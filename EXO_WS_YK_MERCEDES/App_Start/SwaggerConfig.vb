Imports System.Web.Http
Imports Swashbuckle.Application
<Assembly: PreApplicationStartMethod(GetType(SwaggerConfig), "Register")>

Public Class SwaggerConfig
    Public Shared Sub Register()
        Dim thisAssembly = GetType(SwaggerConfig).Assembly

        GlobalConfiguration.Configuration.EnableSwagger(Function(c) c.SingleApiVersion("v1", "WS_YK_MERCEDES")).EnableSwaggerUi()
    End Sub

End Class