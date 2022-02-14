
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Public Class Funciones
    Public Sub New()
    End Sub

    Public Function EnviarPricat() As String

        Dim clsErrores As New Estructura.Errores()
        Dim sError As String = ""

        Dim blEXO As blEXO = Nothing

        Dim oXml As New XmlDocument()

        Dim xmlSerializador As XmlSerializer = Nothing
        Dim ns As XmlSerializerNamespaces = New XmlSerializerNamespaces()
        Dim sw As StringWriter = New StringWriter

        Dim clsPricat As New Estructura.Pricat
        Dim clsLinea As New Estructura.ArticleIdentification
        Dim listlineas As List(Of Estructura.ArticleIdentification)
        Dim spricat As String = ""

        Dim dtArticulos As System.Data.DataTable = Nothing
        Try
            blEXO = New blEXO
            listlineas = New List(Of Estructura.ArticleIdentification)



            Dim sSQL As String = ""
            Dim sPrecio As String = ""

            sSQL = "SELECT t1.U_SEI_CATEGORY1 as MARQUE, t1.U_SEI_WIDTH as WIDTH, t1.U_SEI_ASPECT as ASPECTO, t1.U_SEI_RAD_BIAS as RADIAL, "
            sSQL += " t1.U_SEI_INCH as INCH, t1.U_SEI_INDEXLOAD as IC, t1.U_SEI_RF_XL as XL_RF, t1.U_SEI_COMMPATTERN as PROFIL, t1.ItemCode as CODE,"
            sSQL += " t1.ItemName as DESCRIPTION, t1.U_SEICATEGORY4 as REMISE, t1.U_SEI_JANCODE as EAN_LABEL, t1.U_SEI_OE as MARQUAGE, "
            sSQL += " t1.U_SEI_ROLLINREGI as RR, t1.U_SEI_WETGRIP as WG, t1.U_SEI_EXTERNALN as dB, t1.U_SEI_EXTERNALNO as WAVE, "
            sSQL += " t1.U_SEI_TIRECATEGORY as CAT"
            sSQL += " From OITM t1 WITH (NOLOCK) "
            sSQL += " Where (t1.U_SEI_CATEGORY1='Yokohama-Tires'  or t1.U_SEI_CATEGORY1='Alliance-Tires') "
            sSQL += " and (t1.U_SEICATEGORY6='Summer'  or t1.U_SEICATEGORY6='Winter')  "
            sSQL += " ORDER BY t1.U_SEI_CATEGORY1, t1.U_SEICATEGORY6, t1.ItemCode, t1.U_SEI_JANCODE, t1.ItemName"
            dtArticulos = New System.Data.DataTable("Articulos")
            blEXO.FillDtDB(dtArticulos, sSQL)

            For I = 0 To dtArticulos.Rows.Count - 1

                clsLinea = New Estructura.ArticleIdentification
                Select Case dtArticulos.Rows.Item(I).Item("MARQUE").ToString
                    Case "Yokohama-Tires"
                        clsLinea.MARQUE = "YOKOHAMA"
                    Case "Alliance-Tires"
                        clsLinea.MARQUE = "ALLIANCE"
                    Case Else
                        clsLinea.MARQUE = " SIN DEFINIR"
                End Select
                clsLinea.WIDTH = dtArticulos.Rows.Item(I).Item("WIDTH").ToString
                clsLinea.ASPECTO = dtArticulos.Rows.Item(I).Item("ASPECTO").ToString
                clsLinea.RADIAL = dtArticulos.Rows.Item(I).Item("RADIAL").ToString
                clsLinea.INCH = dtArticulos.Rows.Item(I).Item("INCH").ToString
                clsLinea.IC = dtArticulos.Rows.Item(I).Item("IC").ToString
                clsLinea.XL_RF = dtArticulos.Rows.Item(I).Item("XL_RF").ToString
                clsLinea.PROFIL = dtArticulos.Rows.Item(I).Item("PROFIL").ToString
                clsLinea.CODE = dtArticulos.Rows.Item(I).Item("CODE").ToString
                clsLinea.DESCRIPTION = dtArticulos.Rows.Item(I).Item("DESCRIPTION").ToString
                clsLinea.REMISE = dtArticulos.Rows.Item(I).Item("REMISE").ToString
                clsLinea.EAN_LABEL = dtArticulos.Rows.Item(I).Item("EAN_LABEL").ToString
                clsLinea.MARQUAGE = dtArticulos.Rows.Item(I).Item("MARQUAGE").ToString
                clsLinea.RR = dtArticulos.Rows.Item(I).Item("RR").ToString
                clsLinea.WG = dtArticulos.Rows.Item(I).Item("WG").ToString
                clsLinea.dB = dtArticulos.Rows.Item(I).Item("dB").ToString
                clsLinea.WAVE = dtArticulos.Rows.Item(I).Item("WAVE").ToString
                clsLinea.CAT = dtArticulos.Rows.Item(I).Item("CAT").ToString
                'Para sacar el precio del artículo
                sPrecio = blEXO.GetValueDB("""ITM1""", """Price""", """PriceList"" = 21 And ""ItemCode""='" & dtArticulos.Rows.Item(I).Item("CODE").ToString & "'")
                clsLinea.BF_N28 = sPrecio


                listlineas.Add(clsLinea)
            Next

            clsPricat.Articles = listlineas

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Pricat))

            xmlSerializador.Serialize(sw, clsPricat, ns)

        Catch exCOM As System.Runtime.InteropServices.COMException
            If exCOM.InnerException IsNot Nothing AndAlso exCOM.InnerException.Message <> "" Then
                sError = exCOM.InnerException.Message
            Else
                sError = exCOM.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso ex.InnerException.Message <> "" Then
                sError = ex.InnerException.Message
            Else
                sError = ex.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Finally
            Dim Res As String = Nothing
            Res = sw.ToString
            Res = Replace(Res, "Pricat", "ew:PRICAT_A2")
            Res = Replace(Res, "utf-16", "UTF-8")
            EnviarPricat = Res

            If oXml IsNot Nothing Then
                oXml = Nothing
            End If

            If sw IsNot Nothing Then
                sw.Close()
                sw.Dispose()
                sw = Nothing
            End If
            If dtArticulos IsNot Nothing Then
                dtArticulos.Dispose()
                dtArticulos = Nothing
            End If

            xmlSerializador = Nothing
            clsErrores = Nothing

            clsPricat = Nothing
            clsLinea = Nothing
            listlineas = Nothing
            ns = Nothing

        End Try
    End Function
    Public Function SolicitudStock(ByVal sxml As String) As String

        Dim clsErrores As New Estructura.Errores()
        Dim sError As String = ""

        Dim clsStock As New Estructura.Stock()
        clsStock.ErrorHead = New Estructura.LineaErrorHead()
        clsStock.BuyerParty = New Estructura.LineaBuyerParty()
        'clsStock.Consignee = New Estructura.LineaBuyerParty()


        Dim sSQL As String = Nothing
        Dim blEXO As blEXO = Nothing
        Dim dtStock As System.Data.DataTable = Nothing

        Dim oXml As New XmlDocument()

        Dim xmlSerializador As XmlSerializer = Nothing
        Dim ns As XmlSerializerNamespaces = New XmlSerializerNamespaces()
        Dim sw As StringWriter = New StringWriter
        Try
            blEXO = New blEXO
            Dim sCab As String = "<?xml version=""1.0"" encoding=""UTF-8""?> <ew:order_A2 xmlns:ew=""http//www.reifen.net"" xmlns:px=""http://www.reifen.net/Core"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">"
            Dim sPie As String = "</ew:order_A2>"
            oXml.LoadXml(sCab & sxml.Trim & sPie)

            clsStock.DocumentID = oXml.FirstChild.NextSibling.Item("DocumentID").InnerText
            clsStock.Variante = oXml.FirstChild.NextSibling.Item("Variant").InnerText

            clsStock.ErrorHead.ErrorCode = 0

            clsStock.BuyerParty.PartyID = oXml.FirstChild.NextSibling.Item("BuyerParty").Item("PartyID").InnerText
            clsStock.BuyerParty.AgencyCode = oXml.FirstChild.NextSibling.Item("BuyerParty").Item("AgencyCode").InnerText
            Dim iOrderline As Integer = 0
            ReDim clsStock.OrderLine(iOrderline)
            clsStock.OrderLine(iOrderline) = New Estructura.Lineas

            For Each xmlnode As XmlNode In oXml.FirstChild.NextSibling.Item("OrderLine")
                If xmlnode.LocalName.ToString.Trim = "LineID" Then
                    ReDim Preserve clsStock.OrderLine(iOrderline)
                    clsStock.OrderLine(iOrderline) = New Estructura.Lineas
                    Dim Linea As Estructura.Lineas = New Estructura.Lineas
                    Linea.OrderedArticle = New Estructura.LineasOrderedArticle()
                    Linea.OrderedArticle.ArticleIdentification = New Estructura.LineasArticleIdentificacion()
                    Linea.OrderedArticle.ArticleDescription = New Estructura.LineasArticleDescription()
                    Linea.OrderedArticle.RequestedQuantity = New Estructura.LineasRequestedQuantity()
                    Linea.OrderedArticle.ErrorLIN = New Estructura.LineasError()
                    Linea.OrderedArticle.ScheduleDetails = New Estructura.LineasScheduleDateils()
                    Linea.OrderedArticle.ScheduleDetails.AvailableQuantity = New Estructura.LineasAvailableQuantity()

                    Linea.LineID = oXml.FirstChild.NextSibling.Item("OrderLine").Item("LineID").InnerText

                    Linea.OrderedArticle.ArticleIdentification.EANUCCArticleID = DirectCast(DirectCast(oXml.FirstChild.NextSibling.Item("OrderLine").Item("OrderedArticle").FirstChild, System.Xml.XmlElement).LastChild, System.Xml.XmlElement).InnerText
                    'oXml.FirstChild.NextSibling.Item("OrderLine").NextSibling.Item("OrderedArticle").NextSibling.Item("RequestedQuantity").Item("QuantityValue").InnerText
                    'Linea.OrderedArticle.Availability = DirectCast(DirectCast(oXml.FirstChild.NextSibling.Item("OrderLine").Item("OrderedArticle").LastChild, System.Xml.XmlElement).LastChild, System.Xml.XmlElement).InnerText


                    sSQL = "SELECT t1.ItemCode as Codigo, t1.U_SEI_JANCODE as EAN, t1.ItemName as Descripcion, SUM(t2.OnHand - t2.IsCommited) as Stock "
                    sSQL += " From OITM t1 WITH (NOLOCK) INNER JOIN OITW t2 WITH (NOLOCK) on t1.ItemCode=t2.ItemCode "
                    sSQL += " Where t1.U_SEI_JANCODE='" & Linea.OrderedArticle.ArticleIdentification.EANUCCArticleID & "' "
                    sSQL += " GROUP BY t1.ItemCode, t1.U_SEI_JANCODE, t1.ItemName"
                    dtStock = New System.Data.DataTable("Stock")
                    blEXO.FillDtDB(dtStock, sSQL)
                    If dtStock.Rows.Count > 0 Then

                        Dim sCodigo As String = dtStock.Rows.Item(0).Item("Codigo").ToString
                        Dim sDescripcion As String = dtStock.Rows.Item(0).Item("Descripcion").ToString
                        Dim sStock As String = dtStock.Rows.Item(0).Item("Stock").ToString
                        sStock = Replace(sStock, ",000000", "")
                        'Comprobar Stock
                        Dim iPedido As Integer = CType(DirectCast(DirectCast(oXml.FirstChild.NextSibling.Item("OrderLine").Item("OrderedArticle").LastChild, System.Xml.XmlElement).LastChild, System.Xml.XmlElement).InnerText, Integer)
                        Dim iStock As Integer = CType(sStock, Integer)
                        If iStock >= iPedido Then
                            Linea.OrderedArticle.Availability = 1
                        ElseIf iStock = 0 Then
                            Linea.OrderedArticle.Availability = 3
                        Else
                            Linea.OrderedArticle.Availability = 2
                        End If
                        Linea.OrderedArticle.ArticleIdentification.ManufacturersArticleID = sCodigo
                        Linea.OrderedArticle.ArticleDescription.ArticleDescriptionText = sDescripcion
                        Linea.OrderedArticle.RequestedQuantity.QuantityValue = sStock
                        clsStock.ErrorHead.ErrorCode = 0
                        Linea.OrderedArticle.ErrorLIN.ErrorCode = 0
                        Linea.OrderedArticle.ScheduleDetails.AvailableQuantity.QuantityValue = sStock
                        If sStock <> "0.000000" Then
                            Linea.OrderedArticle.ScheduleDetails.DeliveryDate = oXml.FirstChild.NextSibling.Item("OrderLine").Item("OrderedArticle").Item("RequestedDeliveryDate").InnerText
                        Else
                            Linea.OrderedArticle.ScheduleDetails.DeliveryDate = "9999-12-31"
                        End If

                    Else
                        Linea.OrderedArticle.Availability = 3
                        Linea.OrderedArticle.ArticleIdentification.ManufacturersArticleID = "SIN_VALOR"
                        Linea.OrderedArticle.ArticleDescription.ArticleDescriptionText = "NO LO ENCUENTRA"
                        Linea.OrderedArticle.RequestedQuantity.QuantityValue = 0
                        Linea.OrderedArticle.ScheduleDetails.AvailableQuantity.QuantityValue = 0
                        clsStock.ErrorHead.ErrorCode = 1 ' Preguntar si cuando no encuentra el codigo EAN que error devolvemos
                        Linea.OrderedArticle.ErrorLIN.ErrorCode = 1
                        Linea.OrderedArticle.ScheduleDetails.DeliveryDate = "9999-12-31"
                    End If
                    clsStock.OrderLine(iOrderline) = Linea
                    iOrderline += 1
                End If
            Next



            ns.Add("ew", "http://www.reifen.net")
            xmlSerializador = New XmlSerializer(GetType(Estructura.Stock))

            xmlSerializador.Serialize(sw, clsStock, ns)

        Catch exCOM As System.Runtime.InteropServices.COMException
            If exCOM.InnerException IsNot Nothing AndAlso exCOM.InnerException.Message <> "" Then
                sError = exCOM.InnerException.Message
            Else
                sError = exCOM.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso ex.InnerException.Message <> "" Then
                sError = ex.InnerException.Message
            Else
                sError = ex.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Finally
            Dim Res As String = Nothing
            Res = sw.ToString
            Res = Replace(Res, "<string xmlns=""http://schemas.microsoft.com/2003/10/Serialization/"">", "")
            Res = Replace(Res, "Stock", "ew:quote_A2")
            Res = Replace(Res, "utf-16", "UTF-8")
            Res = Replace(Res, "ErrorLIN", "Error")
            Res = Replace(Res, "Lineas", "OrderLine")
            Res = Replace(Res, "Variante", "Variant")
            SolicitudStock = Res

            If oXml IsNot Nothing Then
                oXml = Nothing
            End If
            If dtStock IsNot Nothing Then
                dtStock.Dispose()
                dtStock = Nothing
            End If

            If sw IsNot Nothing Then
                sw.Close()
                sw.Dispose()
                sw = Nothing
            End If

            xmlSerializador = Nothing
            clsErrores = Nothing
            clsStock = Nothing

            ns = Nothing
        End Try
    End Function
    Public Function CrearPedido(ByVal sxml As String) As String

        Dim clsErrores As New Estructura.Errores()
        Dim sError As String = ""

        Dim blEXO As blEXO = Nothing

        Dim oXml As New XmlDocument()

        Dim xmlSerializador As XmlSerializer = Nothing
        Dim ns As XmlSerializerNamespaces = New XmlSerializerNamespaces()
        Dim sw As StringWriter = New StringWriter

        Dim clsPedidoCreado As New Estructura.PEDIDOSAP()
        Dim sPedido As String = ""

        Try
            blEXO = New blEXO
            Dim sCab As String = "<?xml version=""1.0"" encoding=""UTF-8""?> <ew:order_A2 xmlns:ew=""http//www.reifen.net"" xmlns:px=""http://www.reifen.net/Core"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">"
            Dim sPie As String = "</ew:order_A2>"
            oXml.LoadXml(sCab & sxml.Trim & sPie)
            sPedido = blEXO.AddUpdateORDR(oXml)

            clsPedidoCreado.DocumentID = sPedido

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.PEDIDOSAP))

            xmlSerializador.Serialize(sw, clsPedidoCreado, ns)

        Catch exCOM As System.Runtime.InteropServices.COMException
            If exCOM.InnerException IsNot Nothing AndAlso exCOM.InnerException.Message <> "" Then
                sError = exCOM.InnerException.Message
            Else
                sError = exCOM.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso ex.InnerException.Message <> "" Then
                sError = ex.InnerException.Message
            Else
                sError = ex.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Finally
            Dim Res As String = Nothing
            Res = sw.ToString
            Res = Replace(Res, "PEDIDOSAP", "ew:order_A2")
            Res = Replace(Res, "utf-16", "UTF-8")
            CrearPedido = Res

            If oXml IsNot Nothing Then
                oXml = Nothing
            End If

            If sw IsNot Nothing Then
                sw.Close()
                sw.Dispose()
                sw = Nothing
            End If

            xmlSerializador = Nothing
            clsErrores = Nothing
            ns = Nothing

        End Try
    End Function
    Public Function OrderStatus(ByVal sxml As String) As String

        Dim clsErrores As New Estructura.Errores()
        Dim sError As String = ""

        Dim clsStatus As New Estructura.order_status_request_A2()
        clsStatus.BuyerParty = New Estructura.order_status_request_A2BuyerParty()
        clsStatus.OrderingParty = New Estructura.order_status_request_A2OrderingParty()
        clsStatus.Consignee = New Estructura.order_status_request_A2Consignee()
        clsStatus.ReferencedOrder = New Estructura.order_status_request_A2RefOrder()


        Dim sSQL As String = Nothing
        Dim blEXO As blEXO = Nothing
        Dim dtStock As System.Data.DataTable = Nothing

        Dim oXml As New XmlDocument()

        Dim xmlSerializador As XmlSerializer = Nothing
        Dim ns As XmlSerializerNamespaces = New XmlSerializerNamespaces()
        Dim sw As StringWriter = New StringWriter
        Try
            blEXO = New blEXO
            Dim sCab As String = "<?xml version=""1.0"" encoding=""UTF-8""?> <ew:order_status_A2 xmlns:ew=""http://www.reifen.net"">"
            Dim sPie As String = "</ew:order_status_A2>"
            oXml.LoadXml(sCab & sxml.Trim & sPie)

            clsStatus.DocumentID = oXml.FirstChild.NextSibling.Item("DocumentID").InnerText
            clsStatus.Variant = oXml.FirstChild.NextSibling.Item("Variant").InnerText
            clsStatus.OrderDateFrom = oXml.FirstChild.NextSibling.Item("OrderDateFrom").InnerText
            clsStatus.OrderDateTo = oXml.FirstChild.NextSibling.Item("OrderDateTo").InnerText
            clsStatus.BuyerParty.PartyID = oXml.FirstChild.NextSibling.Item("BuyerParty").Item("PartyID").InnerText
            clsStatus.BuyerParty.AgencyCode = oXml.FirstChild.NextSibling.Item("BuyerParty").Item("AgencyCode").InnerText
            Dim sPedido As String = oXml.FirstChild.NextSibling.Item("ReferencedOrder").Item("SupplierOrderNumber").Item("DocumentID").InnerText
            Dim sReferencia As String = oXml.FirstChild.NextSibling.Item("ReferencedOrder").Item("OrderReference").Item("DocumentID").InnerText
            'clsStatus.ReferencedOrder = New Estructura.order_status_request_A2RefOrder
            'clsStatus.ReferencedOrder.SupplierOrderNumber = New Estructura.order_status_request_A2ReferencedOrderSupplierOrderNumber
            'clsStatus.ReferencedOrder.SupplierOrderNumber.DocumentID = sPedido
            'clsStatus.ReferencedOrder.OrderReference = New Estructura.order_status_request_A2ReferencedOrderOrderReference
            'clsStatus.ReferencedOrder.OrderReference.DocumentID = sReferencia
            Dim sEstado As String = blEXO.GetValueDB("ORDR", "DocStatus", "DocNum=" & sPedido)
            If sEstado = "" Then
                'No existe el pedido
                Throw New Exception("El pedido " & sPedido & " No existe. Revise los datos.")
            End If
            Select Case sEstado
                Case "C" : clsStatus.OrderStatusIndicator = "2"
                Case Else : clsStatus.OrderStatusIndicator = "1"
            End Select
            clsStatus.OrderStatusIndicatorSpecified = True
            ns.Add("ew", "http://www.reifen.net")
            xmlSerializador = New XmlSerializer(GetType(Estructura.order_status_request_A2))

            xmlSerializador.Serialize(sw, clsStatus, ns)

        Catch exCOM As System.Runtime.InteropServices.COMException
            If exCOM.InnerException IsNot Nothing AndAlso exCOM.InnerException.Message <> "" Then
                sError = exCOM.InnerException.Message
            Else
                sError = exCOM.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Catch ex As Exception
            If ex.InnerException IsNot Nothing AndAlso ex.InnerException.Message <> "" Then
                sError = ex.InnerException.Message
            Else
                sError = ex.Message
            End If

            clsErrores.TextError = sError

            ns = New XmlSerializerNamespaces()
            ns.Add("ew", "http://www.reifen.net")

            sw = New StringWriter
            xmlSerializador = New XmlSerializer(GetType(Estructura.Errores))

            xmlSerializador.Serialize(sw, clsErrores, ns)
        Finally
            Dim Res As String = Nothing
            Res = sw.ToString
            Res = Replace(Res, "Stock", "ew:quote_A2")
            Res = Replace(Res, "utf-16", "UTF-8")
            Res = Replace(Res, "ErrorLIN", "Error")
            Res = Replace(Res, "<OrderStatusIndicatorSpecified>true</OrderStatusIndicatorSpecified>", "")
            OrderStatus = Res

            If oXml IsNot Nothing Then
                oXml = Nothing
            End If
            If dtStock IsNot Nothing Then
                dtStock.Dispose()
                dtStock = Nothing
            End If

            If sw IsNot Nothing Then
                sw.Close()
                sw.Dispose()
                sw = Nothing
            End If

            xmlSerializador = Nothing
            clsErrores = Nothing
            clsStatus = Nothing

            ns = Nothing
        End Try
    End Function
End Class
