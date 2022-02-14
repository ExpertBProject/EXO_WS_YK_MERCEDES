Imports System.Net
Imports System.Web.Http
Imports System.Xml
Imports CN

Namespace Controllers

    <RoutePrefix("api/OrderStatus")>
    Public Class OrderStatusController
        Inherits ApiController

        <HttpPost>
        <Route("")>
        Public Function OrderStatus(<FromBody()> mensaje As XmlElement) As XElement
            Dim ofun As CN.Funciones = New Funciones
            Dim sResultado As String = ""
            Dim sOrderStatus As String = mensaje.InnerXml.Trim
            sResultado = ofun.OrderStatus(sOrderStatus)
            OrderStatus = XElement.Parse(sResultado)
        End Function
    End Class
End Namespace