﻿Option Explicit On
Option Strict On

Imports SAPbobsCOM
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml
Public Class blEXO
    Inherits SDEXO

#Region " Constructor"
    Public Sub New()
        'constructor por defecto
    End Sub
#End Region

#Region "Métodos SQL Server"
    Public Function GetValueDB(ByRef sTable As String, ByRef sField As String, ByRef sCondition As String) As String
        Dim cmd As SqlCommand = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim dt As System.Data.DataTable = Nothing
        Dim sSQL As String = ""

        Try
            MyBase.ConnectSQLServer()

            If sCondition = "" Then
                sSQL = "SELECT " & sField & " FROM " & sTable
            Else
                sSQL = "SELECT " & sField & " FROM " & sTable & " WHERE " & sCondition
            End If

            cmd = New SqlCommand(sSQL, Me.EXO_db)
            cmd.CommandTimeout = 0

            da = New SqlDataAdapter

            da.SelectCommand = cmd
            dt = New System.Data.DataTable
            da.Fill(dt)

            If dt.Rows.Count <= 0 Then
                Return ""
            Else
                If Not IsDBNull(dt.Rows(0).Item(0).ToString) Then
                    Return dt.Rows(0).Item(0).ToString
                Else
                    Return ""
                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not dt Is Nothing Then
                dt.Dispose()
                dt = Nothing
            End If

            If Not cmd Is Nothing Then
                cmd.Dispose()
                cmd = Nothing
            End If

            If Not da Is Nothing Then
                da.Dispose()
                da = Nothing
            End If

            MyBase.DisconnectSQLServer()
        End Try
    End Function
    Public Sub FillDtDB(ByRef dt As System.Data.DataTable, ByVal sSQL As String)
        Dim cmd As SqlCommand = Nothing
        Dim da As SqlDataAdapter = Nothing

        Try
            MyBase.ConnectSQLServer()

            cmd = New SqlCommand(sSQL, Me.EXO_db)
            cmd.CommandTimeout = 0

            da = New SqlDataAdapter

            da.SelectCommand = cmd
            da.Fill(dt)

        Catch ex As Exception
            Throw ex
        Finally
            If Not cmd Is Nothing Then
                cmd.Dispose()
                cmd = Nothing
            End If

            If Not da Is Nothing Then
                da.Dispose()
                da = Nothing
            End If

            MyBase.DisconnectSQLServer()
        End Try
    End Sub
    Public Function ExecuteSqlDB(ByVal sSQL As String) As Boolean
        Dim cmd As SqlCommand = Nothing

        ExecuteSqlDB = False

        Try
            MyBase.ConnectSQLServer()

            cmd = New SqlCommand(sSQL, Me.EXO_db)
            cmd.ExecuteNonQuery()

            ExecuteSqlDB = True

        Catch ex As Exception
            Throw ex
        Finally
            If Not cmd Is Nothing Then
                cmd.Dispose()
                cmd = Nothing
            End If

            MyBase.DisconnectSQLServer()
        End Try
    End Function
#End Region

#Region "Métodos SAP"
    'Crear Pedido
    Public Function AddUpdateORDR(ByRef oxml As XmlDocument) As String
        Dim oORDR As SAPbobsCOM.Documents = Nothing
        Dim sDocEntry As String = ""
        Dim strNumSerie As String = ""

        Dim strExiste As String = ""
        Dim strCliente As String = ""
        Dim blEXO As blEXO = Nothing
        Dim strFecha As String = ""
        Dim strFechaEnvio As String = ""

        Dim sNumDoc As String = ""
        Dim strRef As String = ""
        Dim strCodArt As String = ""
        Dim strComprobar As String = ""
        Dim strFP As String = ""
        Dim strEstado As String = ""
        Dim strDestino As String = ""
        Dim sAnno As String = ""

        AddUpdateORDR = ""

        Try
            MyBase.ConnectSAP()
            blEXO = New blEXO
            sAnno = Right(Year(Now).ToString, 2)
            oORDR = CType(Me.Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders), SAPbobsCOM.Documents)
            strNumSerie = GetValueDB("""NNM1""", """Series""", """ObjectCode"" = 17 And ""SeriesName""='FA" & sAnno & "'")
            If strNumSerie.Trim = "" Then
                'No existe la serie
                Throw New Exception("No encuentra la serie para generar el pedido")
            End If

            strCliente = oxml.FirstChild.NextSibling.Item("BuyerParty").Item("PartyID").InnerText
            strComprobar = GetValueDB("""OCRD""", """CardCode""", """U_EXO_BUYERPARTY"" ='" & strCliente & "'")
            If strComprobar = "" Then
                'No existe el cliente
                Throw New Exception("El cliente " & strCliente & " no existe en la base de datos")
            Else
                strCliente = strComprobar
            End If

            strDestino = GetValueDB("""OCRD""", """ShipToDef""", """CardCode"" ='" & strCliente & "'")
            oORDR.ShipToCode = strDestino
            'Hacer consulta getvaluedb para saber si existe el pedido ORDR
            strRef = oxml.FirstChild.NextSibling.Item("CustomerReference").Item("DocumentID").InnerText
            strExiste = GetValueDB("""ORDR""", """DocEntry""", """CardCode""='" & strCliente & "' and ""NumAtCard""='" & strRef & "'")
            If strExiste <> "" Then
                'MODIFICAR
                'Antes de modificar, comprobar el estado, y si es diferente de C, dejo continuar, sino mensaje y me salgo
                strEstado = GetValueDB("""ORDR""", """DocStatus""", """DocEntry""=" & CInt(strExiste) & "")
                If strEstado <> "C" Then
                    oORDR.GetByKey(CInt(strExiste))
                    'recorrer lineas y borrar y las hago de nuevo
                    For i = 0 To oORDR.Lines.Count - 1
                        oORDR.Lines.SetCurrentLine(0)
                        oORDR.Lines.Delete()
                    Next
                Else
                    Throw New Exception("El estado del documento: " & strRef & " es cerrado o cancelado, no se puede modificar")
                End If
            Else
                'Nuevo datos cabecera

                Try
                    oORDR.Series = CInt(strNumSerie)
                Catch ex As Exception
                    Throw New Exception("No encuentra la serie para generar el pedido")
                End Try
                oORDR.CardCode = strCliente
            End If

            'Datos cabecera para crear o modificar
            'Formato para fechas
            strFecha = Year(Now).ToString & "-" & Month(Now).ToString & "-" & Day(Now)

            oORDR.TaxDate = CDate(strFecha)
            oORDR.DocDate = CDate(strFecha)
            'Fecha de envio
            Try
                strFechaEnvio = oxml.FirstChild.NextSibling.Item("EarliestDeliveryDate").InnerText

            Catch ex As Exception
                strFechaEnvio = ""
            End Try
            If strFechaEnvio = "" Then
                strFechaEnvio = oxml.FirstChild.NextSibling.Item("OrderLine").Item("OrderedArticle").Item("RequestedDeliveryDate").InnerText
            End If
            oORDR.DocDueDate = CDate(strFechaEnvio)

            'Referencia del Cliente
            oORDR.NumAtCard = strRef

            'Forma de pago
            Try
                strFP = oxml.FirstChild.NextSibling.Item("PaymentTerms").Item("PaymentMethod").InnerText
            Catch ex As Exception
                strFP = ""
            End Try

            If strFP <> "" Then
                strComprobar = GetValueDB("""OPYM""", """PayMethCod""", """PayMethCod"" ='" & strFP & "'")
                If strComprobar = "" Then
                    ''no existe la forma de pago, excepcion y me salgo
                    'Throw New Exception("La forma de pago " & strFP & " no existe en la base de datos")
                Else
                    oORDR.PaymentMethod = strFP
                End If
            End If

            'Comentarios
            oORDR.Comments = " Pedido MERCEDES creado a través de WEB SERVICE. Agency Code " & oxml.FirstChild.NextSibling.Item("BuyerParty").Item("AgencyCode").InnerText

            'Comprobar que exista el articulo
            Dim sJANCODE As String = oxml.FirstChild.NextSibling.Item("OrderLine").Item("OrderedArticle").Item("ArticleIdentification").Item("EANUCCArticleID").InnerText
            strCodArt = GetValueDB("""OITM""", """ItemCode""", """U_SEI_JANCODE"" ='" & sJANCODE & "'")
            If strCodArt = "" Then
                'No existe el articulo, excepcion y me salgo
                Throw New Exception("El artículo " & sJANCODE & " no existe en la base de datos")
            End If

            oORDR.Lines.ItemCode = strCodArt
            Try
                oORDR.Lines.Quantity = CDbl(oxml.FirstChild.NextSibling.Item("OrderLine").Item("OrderedArticle").Item("RequestedQuantity").Item("QuantityValue").InnerText)
            Catch ex As Exception
                Throw New Exception("El artículo " & sJANCODE & " no tiene indicado la cantidad.")
            End Try


            If strExiste <> "" Then
                If oORDR.Update() <> 0 Then
                    Throw New Exception(Me.Company.GetLastErrorCode & " / " & Me.Company.GetLastErrorDescription)
                End If
            Else
                If oORDR.Add() <> 0 Then
                    Throw New Exception(Me.Company.GetLastErrorCode & " / " & Me.Company.GetLastErrorDescription)
                End If
            End If
            Me.Company.GetNewObjectCode(sDocEntry)
            sNumDoc = GetValueDB("""ORDR""", """DocNum""", """DocEntry"" = " & CInt(sDocEntry) & "")

            AddUpdateORDR = CStr(sNumDoc)

            'Creación de la alerta.
            EnviarAlerta(sDocEntry, sNumDoc, strExiste)

        Catch exCOM As System.Runtime.InteropServices.COMException
            Throw exCOM
        Catch ex As Exception
            Throw ex
        Finally
            MyBase.DisconnectSAP()
            If oORDR IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oORDR)
        End Try

    End Function

    'crear alerta sap
    Public Sub EnviarAlerta(ByVal strDocEntry As String, ByVal strPedido As String, ByVal strExiste As String)
        Dim oCompany As SAPbobsCOM.Company = Nothing
        Dim pMessageDataColumns As SAPbobsCOM.MessageDataColumns = Nothing
        Dim pMessageDataColumn As SAPbobsCOM.MessageDataColumn = Nothing
        Dim oLines As SAPbobsCOM.MessageDataLines = Nothing
        Dim oLine As SAPbobsCOM.MessageDataLine = Nothing
        Dim oRecipientCollection As SAPbobsCOM.RecipientCollection = Nothing

        Dim oMessageService As SAPbobsCOM.MessagesService = Nothing
        Dim oMessage As SAPbobsCOM.Message = Nothing

        Dim oDBSAP As SqlConnection = Nothing
        Dim sSQL As String = ""
        Dim oDtSAP As System.Data.DataTable = Nothing

        Dim blEXO As blEXO = Nothing


        Try
            MyBase.ConnectSAP()
            blEXO = New blEXO

            sSQL = "Select t1.USER_CODE " &
                       "FROM OUSR t1 With (NOLOCK) " &
                       "WHERE ISNULL(t1.U_EXO_RESWS, 'N') = 'Y'"

            oDtSAP = New System.Data.DataTable
            FillDtDB(oDtSAP, sSQL)
            If oDtSAP.Rows.Count > 0 Then 'Si hay usuarios con esta alerta activada, enviamos alertas
                oMessageService = CType(Me.Company.GetCompanyService.GetBusinessService(SAPbobsCOM.ServiceTypes.MessagesService), SAPbobsCOM.MessagesService)
                oMessage = CType(oMessageService.GetDataInterface(SAPbobsCOM.MessagesServiceDataInterfaces.msdiMessage), SAPbobsCOM.Message)
                If strExiste <> "" Then
                    oMessage.Subject = "Pedido MERCEDES Número " & strPedido & " modificado por Web Serive correctamente"
                    oMessage.Text = "Se ha modificado el Pedido MERCEDES Número " & strPedido & " correctamente "
                Else
                    oMessage.Subject = "Pedido MERCEDES Número " & strPedido & " creado por Web Serive correctamente"
                    oMessage.Text = "Se ha creado el Pedido MERCEDES Número " & strPedido & " correctamente "
                End If
                oRecipientCollection = oMessage.RecipientCollection

                For j As Integer = 0 To oDtSAP.Rows.Count - 1
                    oRecipientCollection.Add()
                    oRecipientCollection.Item(j).SendInternal = SAPbobsCOM.BoYesNoEnum.tYES
                    oRecipientCollection.Item(j).UserCode = oDtSAP.Rows.Item(j).Item("USER_CODE").ToString
                Next

                pMessageDataColumns = oMessage.MessageDataColumns

                pMessageDataColumn = pMessageDataColumns.Add()
                pMessageDataColumn.ColumnName = "Número interno"
                pMessageDataColumn.Link = SAPbobsCOM.BoYesNoEnum.tYES
                oLines = pMessageDataColumn.MessageDataLines
                oLine = oLines.Add()
                oLine.Value = strDocEntry
                oLine.Object = "17"
                oLine.ObjectKey = strDocEntry

                pMessageDataColumn = pMessageDataColumns.Add()
                pMessageDataColumn.ColumnName = "Número Pedido"
                oLines = pMessageDataColumn.MessageDataLines
                oLine = oLines.Add()
                oLine.Value = strPedido

                oMessageService.SendMessage(oMessage)

            End If
        Catch exCOM As System.Runtime.InteropServices.COMException
            Throw exCOM
        Catch ex As Exception
            Throw ex
        Finally

            If oDtSAP IsNot Nothing Then oDtSAP.Dispose()
            If pMessageDataColumns IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(pMessageDataColumns)
            If pMessageDataColumn IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(pMessageDataColumn)
            If oLines IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oLines)
            If oLine IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oLine)
            If oRecipientCollection IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oRecipientCollection)
            'If oCmpSrv IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oCmpSrv)
            If oMessageService IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oMessageService)
            If oMessage IsNot Nothing Then System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oMessage)

            MyBase.DisconnectSAP()
        End Try
    End Sub
#End Region

End Class
