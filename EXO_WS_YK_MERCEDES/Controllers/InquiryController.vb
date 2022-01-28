Imports System.Net
Imports System.Web.Http
Imports System.Xml
Imports CN

Namespace Controllers

    <RoutePrefix("api/Inquiry")>
    Public Class InquiryController
        Inherits ApiController
        <HttpPost>
        <Route("")>
        Public Function Inquiry(<FromBody()> mensaje As XmlElement) As String
            Dim ofun As CN.Funciones = New Funciones
            Dim sResultado As String = ""

            Dim sInquiry As String = mensaje.InnerXml.Trim
            sResultado = ofun.SolicitudStock(sInquiry)
            Inquiry = sResultado

        End Function
    End Class
End Namespace