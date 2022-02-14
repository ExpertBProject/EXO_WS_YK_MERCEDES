Imports System.Net
Imports System.Web.Http
Imports System.Xml
Imports CN
Namespace Controllers

    <RoutePrefix("api/Order")>
    Public Class OrderController
        Inherits ApiController

        <HttpPost>
        <Route("")>
        Public Function Order(<FromBody()> mensaje As XmlElement) As XElement
            Dim ofun As CN.Funciones = New Funciones
            Dim sResultado As String = ""
            Dim sOrder As String = mensaje.InnerXml.Trim
            sResultado = ofun.CrearPedido(sOrder)
            Order = XElement.Parse(sResultado)
        End Function
    End Class
End Namespace