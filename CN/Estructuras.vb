Namespace Estructura
    <Serializable()>
    Public Class Errores

#Region "Atributos"
        Private _TextError As String
#End Region

#Region "Propiedades"
        Public Property TextError() As String
            Get
                Return _TextError
            End Get
            Set(ByVal Value As String)
                _TextError = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class Pricat

#Region "Atributos"
        Private _Articles As List(Of ArticleIdentification)
#End Region
#Region "Propiedades"
        Public Property Articles() As List(Of ArticleIdentification)
            Get
                Return _Articles
            End Get
            Set(ByVal Value As List(Of ArticleIdentification))
                _Articles = Value
            End Set
        End Property
#End Region
    End Class

    <Serializable()>
    Public Class ArticleIdentification

#Region "Atributos"
        Private _MARQUE As String
        Private _WIDTH As String
        Private _ASPECTO As String
        Private _RADIAL As String
        Private _INCH As String
        Private _IC As String
        Private _XL_RF As String
        Private _PROFIL As String
        Private _CODE As String
        Private _DESCRIPTION As String
        Private _REMISE As String
        Private _EAN_LABEL As String
        Private _BF_N28 As String
        Private _MARQUAGE As String
        Private _RR As String
        Private _WG As String
        Private _dB As String
        Private _WAVE As String
        Private _CAT As String
#End Region

#Region "Propiedades"
        Public Property MARQUE() As String
            Get
                Return _MARQUE
            End Get
            Set(ByVal Value As String)
                _MARQUE = Value
            End Set
        End Property
        Public Property WIDTH() As String
            Get
                Return _WIDTH
            End Get
            Set(ByVal Value As String)
                _WIDTH = Value
            End Set
        End Property
        Public Property ASPECTO() As String
            Get
                Return _ASPECTO
            End Get
            Set(ByVal Value As String)
                _ASPECTO = Value
            End Set
        End Property
        Public Property RADIAL() As String
            Get
                Return _RADIAL
            End Get
            Set(ByVal Value As String)
                _RADIAL = Value
            End Set
        End Property
        Public Property INCH() As String
            Get
                Return _INCH
            End Get
            Set(ByVal Value As String)
                _INCH = Value
            End Set
        End Property
        Public Property IC() As String
            Get
                Return _IC
            End Get
            Set(ByVal Value As String)
                _IC = Value
            End Set
        End Property
        Public Property XL_RF() As String
            Get
                Return _XL_RF
            End Get
            Set(ByVal Value As String)
                _XL_RF = Value
            End Set
        End Property
        Public Property PROFIL() As String
            Get
                Return _PROFIL
            End Get
            Set(ByVal Value As String)
                _PROFIL = Value
            End Set
        End Property
        Public Property CODE() As String
            Get
                Return _CODE
            End Get
            Set(ByVal Value As String)
                _CODE = Value
            End Set
        End Property
        Public Property DESCRIPTION() As String
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal Value As String)
                _DESCRIPTION = Value
            End Set
        End Property
        Public Property REMISE() As String
            Get
                Return _REMISE
            End Get
            Set(ByVal Value As String)
                _REMISE = Value
            End Set
        End Property
        Public Property EAN_LABEL() As String
            Get
                Return _EAN_LABEL
            End Get
            Set(ByVal Value As String)
                _EAN_LABEL = Value
            End Set
        End Property
        Public Property BF_N28() As String
            Get
                Return _BF_N28
            End Get
            Set(ByVal Value As String)
                _BF_N28 = Value
            End Set
        End Property
        Public Property MARQUAGE() As String
            Get
                Return _MARQUAGE
            End Get
            Set(ByVal Value As String)
                _MARQUAGE = Value
            End Set
        End Property
        Public Property RR() As String
            Get
                Return _RR
            End Get
            Set(ByVal Value As String)
                _RR = Value
            End Set
        End Property
        Public Property WG() As String
            Get
                Return _WG
            End Get
            Set(ByVal Value As String)
                _WG = Value
            End Set
        End Property
        Public Property dB() As String
            Get
                Return _dB
            End Get
            Set(ByVal Value As String)
                _dB = Value
            End Set
        End Property
        Public Property WAVE() As String
            Get
                Return _WAVE
            End Get
            Set(ByVal Value As String)
                _WAVE = Value
            End Set
        End Property
        Public Property CAT() As String
            Get
                Return _CAT
            End Get
            Set(ByVal Value As String)
                _CAT = Value
            End Set
        End Property
#End Region
    End Class

    <Serializable()>
    Public Class PEDIDOSAP

#Region "Atributos"
        Private _DocumentID As String
#End Region

#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return _DocumentID
            End Get
            Set(ByVal Value As String)
                _DocumentID = Value
            End Set
        End Property
#End Region
    End Class

    <Serializable()>
    Public Class Stock

#Region "Atributos"
        Private _DocumentID As String
        Private _Variant As String
        Private _ErrorHead As LineaErrorHead
        Private _BuyerParty As LineaBuyerParty
        Private _Consignee As LineaBuyerParty
        Private _OrderLine() As Lineas
#End Region

#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return _DocumentID
            End Get
            Set(ByVal Value As String)
                _DocumentID = Value
            End Set
        End Property
        Public Property Variante() As String
            Get
                Return _Variant
            End Get
            Set(ByVal Value As String)
                _Variant = Value
            End Set
        End Property
        Public Property ErrorHead() As LineaErrorHead
            Get
                Return _ErrorHead
            End Get
            Set(ByVal Value As LineaErrorHead)
                _ErrorHead = Value
            End Set
        End Property
        Public Property BuyerParty() As LineaBuyerParty
            Get
                Return _BuyerParty
            End Get
            Set(ByVal Value As LineaBuyerParty)
                _BuyerParty = Value
            End Set
        End Property
        Public Property Consignee() As LineaBuyerParty
            Get
                Return _Consignee
            End Get
            Set(ByVal Value As LineaBuyerParty)
                _Consignee = Value
            End Set
        End Property
        Public Property OrderLine() As Lineas()
            Get
                Return Me._OrderLine
            End Get
            Set
                Me._OrderLine = Value
            End Set
        End Property
#End Region
    End Class

    <Serializable()>
    Public Class LineaErrorHead

#Region "Atributos"
        Private _ErrorCode As String

#End Region

#Region "Propiedades"
        Public Property ErrorCode() As String
            Get
                Return _ErrorCode
            End Get
            Set(ByVal Value As String)
                _ErrorCode = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class LineaBuyerParty

#Region "Atributos"
        Private _PartyID As String
        Private _AgencyCode As String
#End Region

#Region "Propiedades"
        Public Property PartyID() As String
            Get
                Return _PartyID
            End Get
            Set(ByVal Value As String)
                _PartyID = Value
            End Set
        End Property
        Public Property AgencyCode() As String
            Get
                Return _AgencyCode
            End Get
            Set(ByVal Value As String)
                _AgencyCode = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class Lineas

#Region "Atributos"
        Private _LineID As String
        Private _OrderedArticle As LineasOrderedArticle
#End Region

#Region "Propiedades"
        Public Property LineID() As String
            Get
                Return _LineID
            End Get
            Set(ByVal Value As String)
                _LineID = Value
            End Set
        End Property
        Public Property OrderedArticle() As LineasOrderedArticle
            Get
                Return _OrderedArticle
            End Get
            Set(ByVal Value As LineasOrderedArticle)
                _OrderedArticle = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class LineasOrderedArticle

#Region "Atributos"
        Private _ArticleIdentification As LineasArticleIdentificacion
        Private _ArticleDescription As LineasArticleDescription
        Private _Availability As String
        Private _RequestedQuantity As LineasRequestedQuantity
        Private _Error As LineasError
        Private _ScheduleDetails As LineasScheduleDateils
#End Region

#Region "Propiedades"
        Public Property ArticleIdentification() As LineasArticleIdentificacion
            Get
                Return _ArticleIdentification
            End Get
            Set(ByVal Value As LineasArticleIdentificacion)
                _ArticleIdentification = Value
            End Set
        End Property
        Public Property ArticleDescription() As LineasArticleDescription
            Get
                Return _ArticleDescription
            End Get
            Set(ByVal Value As LineasArticleDescription)
                _ArticleDescription = Value
            End Set
        End Property
        Public Property Availability() As String
            Get
                Return _Availability
            End Get
            Set(ByVal Value As String)
                _Availability = Value
            End Set
        End Property
        Public Property RequestedQuantity() As LineasRequestedQuantity
            Get
                Return _RequestedQuantity
            End Get
            Set(ByVal Value As LineasRequestedQuantity)
                _RequestedQuantity = Value
            End Set
        End Property
        Public Property ErrorLIN() As LineasError
            Get
                Return _Error
            End Get
            Set(ByVal Value As LineasError)
                _Error = Value
            End Set
        End Property
        Public Property ScheduleDetails() As LineasScheduleDateils
            Get
                Return _ScheduleDetails
            End Get
            Set(ByVal Value As LineasScheduleDateils)
                _ScheduleDetails = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class LineasArticleIdentificacion

#Region "Atributos"
        Private _ManufacturersArticleID As String
        Private _EANUCCArticleID As String
#End Region

#Region "Propiedades"
        Public Property ManufacturersArticleID() As String
            Get
                Return _ManufacturersArticleID
            End Get
            Set(ByVal Value As String)
                _ManufacturersArticleID = Value
            End Set
        End Property
        Public Property EANUCCArticleID() As String
            Get
                Return _EANUCCArticleID
            End Get
            Set(ByVal Value As String)
                _EANUCCArticleID = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class LineasArticleDescription

#Region "Atributos"
        Private _ArticleDescriptionText As String
#End Region

#Region "Propiedades"
        Public Property ArticleDescriptionText() As String
            Get
                Return _ArticleDescriptionText
            End Get
            Set(ByVal Value As String)
                _ArticleDescriptionText = Value
            End Set
        End Property

#End Region

    End Class

    <Serializable()>
    Public Class LineasRequestedQuantity

#Region "Atributos"
        Private _QuantityValue As String
#End Region

#Region "Propiedades"
        Public Property QuantityValue() As String
            Get
                Return _QuantityValue
            End Get
            Set(ByVal Value As String)
                _QuantityValue = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class LineasError

#Region "Atributos"
        Private _ErrorCode As String
#End Region

#Region "Propiedades"
        Public Property ErrorCode() As String
            Get
                Return _ErrorCode
            End Get
            Set(ByVal Value As String)
                _ErrorCode = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class LineasScheduleDateils

#Region "Atributos"
        Private _DeliveryDate As String
        Private _AvailableQuantity As LineasAvailableQuantity
#End Region

#Region "Propiedades"
        Public Property DeliveryDate() As String
            Get
                Return _DeliveryDate
            End Get
            Set(ByVal Value As String)
                _DeliveryDate = Value
            End Set
        End Property
        Public Property AvailableQuantity() As LineasAvailableQuantity
            Get
                Return _AvailableQuantity
            End Get
            Set(ByVal Value As LineasAvailableQuantity)
                _AvailableQuantity = Value
            End Set
        End Property
#End Region

    End Class

    <Serializable()>
    Public Class LineasAvailableQuantity

#Region "Atributos"
        Private _QuantityValue As String
#End Region

#Region "Propiedades"
        Public Property QuantityValue() As String
            Get
                Return _QuantityValue
            End Get
            Set(ByVal Value As String)
                _QuantityValue = Value
            End Set
        End Property
#End Region
    End Class

    <Serializable()>
    Public Class order_status_A2

#Region "Atributos"
        Private documentIDField As String
        Private variantField As String
        Private orderDateFromField As String
        Private orderDateToField As String
        Private orderStatusIndicatorField As String
        Private orderStatusIndicatorFieldSpecified As Boolean
        Private errorHeadField As order_status_A2ErrorHead
        Private buyerPartyField As order_status_A2BuyerParty
        Private orderingPartyField As order_status_A2OrderingParty
        Private consigneeField As order_status_A2Consignee
        Private referencedOrderField() As order_status_A2ReferencedOrder
#End Region

#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return documentIDField
            End Get
            Set(ByVal Value As String)
                documentIDField = Value
            End Set
        End Property
        Public Property [Variant]() As String
            Get
                Return Me.variantField
            End Get
            Set
                Me.variantField = Value
            End Set
        End Property
        Public Property OrderDateFrom() As String
            Get
                Return Me.orderDateFromField
            End Get
            Set
                Me.orderDateFromField = Value
            End Set
        End Property
        Public Property OrderDateTo() As String
            Get
                Return Me.orderDateToField
            End Get
            Set
                Me.orderDateToField = Value
            End Set
        End Property
        Public Property OrderStatusIndicator() As String
            Get
                Return Me.orderStatusIndicatorField
            End Get
            Set
                Me.orderStatusIndicatorField = Value
            End Set
        End Property
        Public Property OrderStatusIndicatorSpecified() As Boolean
            Get
                Return Me.orderStatusIndicatorFieldSpecified
            End Get
            Set
                Me.orderStatusIndicatorFieldSpecified = Value
            End Set
        End Property
        Public Property ErrorHead() As order_status_A2ErrorHead
            Get
                Return Me.errorHeadField
            End Get
            Set
                Me.errorHeadField = Value
            End Set
        End Property
        Public Property BuyerParty() As order_status_A2BuyerParty
            Get
                Return Me.buyerPartyField
            End Get
            Set
                Me.buyerPartyField = Value
            End Set
        End Property
        Public Property OrderingParty() As order_status_A2OrderingParty
            Get
                Return Me.orderingPartyField
            End Get
            Set
                Me.orderingPartyField = Value
            End Set
        End Property
        Public Property Consignee() As order_status_A2Consignee
            Get
                Return Me.consigneeField
            End Get
            Set
                Me.consigneeField = Value
            End Set
        End Property
        Public Property ReferencedOrder() As order_status_A2ReferencedOrder()
            Get
                Return Me.referencedOrderField
            End Get
            Set
                Me.referencedOrderField = Value
            End Set
        End Property
#End Region

    End Class
    Partial Public Class order_status_A2ErrorHead
#Region "Atributos"
        Private errorCodeField As order_status_A2ErrorHeadErrorCode
#End Region

#Region "Propiedades"
        Public Property ErrorCode() As order_status_A2ErrorHeadErrorCode
            Get
                Return Me.errorCodeField
            End Get
            Set
                Me.errorCodeField = Value
            End Set
        End Property
#End Region
        Public Enum order_status_A2ErrorHeadErrorCode

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("0")>
            Item0

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("1")>
            Item1

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("303")>
            Item303

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("304")>
            Item304

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("399")>
            Item399

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("405")>
            Item405

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("499")>
            Item499

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("901")>
            Item901

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("913")>
            Item913

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("914")>
            Item914

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("915")>
            Item915

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("916")>
            Item916

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("917")>
            Item917

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("920")>
            Item920

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("921")>
            Item921

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("924")>
            Item924

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("925")>
            Item925

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("926")>
            Item926

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("927")>
            Item927

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("932")>
            Item932

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("936")>
            Item936

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("937")>
            Item937

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("946")>
            Item946

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("947")>
            Item947

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("948")>
            Item948

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("949")>
            Item949

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("950")>
            Item950

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("951")>
            Item951

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("952")>
            Item952

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("953")>
            Item953

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("999")>
            Item999
        End Enum
    End Class


    Partial Public Class ReferenceType
#Region "Atributos"
        Private documentIDField As String

        Private lineIDField As String
#End Region
#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return Me.documentIDField
            End Get
            Set
                Me.documentIDField = Value
            End Set
        End Property
        Public Property LineID() As String
            Get
                Return Me.lineIDField
            End Get
            Set
                Me.lineIDField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class DespatchAdviceReference
        Inherits ReferenceType
    End Class

    Partial Public Class QuantityType
#Region "Atributos"
        Private quantityValueField As Decimal
#End Region
#Region "Propiedades"
        Public Property QuantityValue() As Decimal
            Get
                Return Me.quantityValueField
            End Get
            Set
                Me.quantityValueField = Value
            End Set
        End Property
#End Region

    End Class
    Partial Public Class OrderedQuantity
        Inherits QuantityType
    End Class
    Partial Public Class OpenQuantity
        Inherits QuantityType
    End Class
    Partial Public Class DespatchedQuantity
        Inherits QuantityType
    End Class
    Partial Public Class ConfirmedQuantityType
        Inherits QuantityType
    End Class
    Partial Public Class CancelledQuantity
        Inherits QuantityType
    End Class
    Partial Public Class order_status_A2BuyerParty
#Region "Atributos"
        Private partyIDField As String
        Private agencyCodeField As order_status_A2BuyerPartyAgencyCode
#End Region
#Region "Propiedades"
        Public Property PartyID() As String
            Get
                Return Me.partyIDField
            End Get
            Set
                Me.partyIDField = Value
            End Set
        End Property
        Public Property AgencyCode() As order_status_A2BuyerPartyAgencyCode
            Get
                Return Me.agencyCodeField
            End Get
            Set
                Me.agencyCodeField = Value
            End Set
        End Property
#End Region
        Public Enum order_status_A2BuyerPartyAgencyCode

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("9")>
            Item9

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("91")>
            Item91

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("92")>
            Item92
        End Enum
    End Class
    Partial Public Class order_status_A2OrderingParty
#Region "Atributos"
        Private partyIDField As String

        Private agencyCodeField As order_status_A2OrderingPartyAgencyCode
#End Region

#Region "Propiedades"
        Public Property PartyID() As String
            Get
                Return Me.partyIDField
            End Get
            Set
                Me.partyIDField = Value
            End Set
        End Property
        Public Property AgencyCode() As order_status_A2OrderingPartyAgencyCode
            Get
                Return Me.agencyCodeField
            End Get
            Set
                Me.agencyCodeField = Value
            End Set
        End Property
#End Region
        Public Enum order_status_A2OrderingPartyAgencyCode

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("9")>
            Item9

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("91")>
            Item91

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("92")>
            Item92
        End Enum
    End Class

    Partial Public Class order_status_A2Consignee
#Region "Atributos"
        Private partyIDField As String
        Private agencyCodeField As order_status_A2ConsigneeAgencyCode
#End Region
#Region "Propiedades"
        Public Property PartyID() As String
            Get
                Return Me.partyIDField
            End Get
            Set
                Me.partyIDField = Value
            End Set
        End Property
        Public Property AgencyCode() As order_status_A2ConsigneeAgencyCode
            Get
                Return Me.agencyCodeField
            End Get
            Set
                Me.agencyCodeField = Value
            End Set
        End Property
#End Region
        Public Enum order_status_A2ConsigneeAgencyCode

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("91")>
            Item91

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("92")>
            Item92
        End Enum
    End Class
    Partial Public Class order_status_A2ReferencedOrder
#Region "Atributos"
        Private errorField As order_status_A2ReferencedOrderError
        Private supplierOrderNumberField As order_status_A2ReferencedOrderSupplierOrderNumber
        Private orderReferenceField As order_status_A2ReferencedOrderOrderReference
        Private orderLineField() As order_status_A2ReferencedOrderOrderLine
#End Region
#Region "Propiedades"
        Public Property [Error]() As order_status_A2ReferencedOrderError
            Get
                Return Me.errorField
            End Get
            Set
                Me.errorField = Value
            End Set
        End Property
        Public Property SupplierOrderNumber() As order_status_A2ReferencedOrderSupplierOrderNumber
            Get
                Return Me.supplierOrderNumberField
            End Get
            Set
                Me.supplierOrderNumberField = Value
            End Set
        End Property
        Public Property OrderReference() As order_status_A2ReferencedOrderOrderReference
            Get
                Return Me.orderReferenceField
            End Get
            Set
                Me.orderReferenceField = Value
            End Set
        End Property
        Public Property OrderLine() As order_status_A2ReferencedOrderOrderLine()
            Get
                Return Me.orderLineField
            End Get
            Set
                Me.orderLineField = Value
            End Set
        End Property
#End Region

    End Class
    Partial Public Class order_status_A2ReferencedOrderError
#Region "Atributos"
        Private errorCodeField As order_status_A2ReferencedOrderErrorErrorCode
        Private errorTextField As String
#End Region

#Region "Propiedades"
        Public Property ErrorCode() As order_status_A2ReferencedOrderErrorErrorCode
            Get
                Return Me.errorCodeField
            End Get
            Set
                Me.errorCodeField = Value
            End Set
        End Property
        Public Property ErrorText() As String
            Get
                Return Me.errorTextField
            End Get
            Set
                Me.errorTextField = Value
            End Set
        End Property
#End Region
        Public Enum order_status_A2ReferencedOrderErrorErrorCode

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("970")>
            Item970

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("971")>
            Item971

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("999")>
            Item999
        End Enum
    End Class
    Partial Public Class order_status_A2ReferencedOrderSupplierOrderNumber

#Region "Atributos"
        Private documentIDField As String
#End Region
#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return Me.documentIDField
            End Get
            Set
                Me.documentIDField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderReference
#Region "Atributos"
        Private documentIDField As String
#End Region
#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return Me.documentIDField
            End Get
            Set
                Me.documentIDField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderLine
#Region "Atributos"
        Private lineIDField As String
        Private customerLineItemNumberField As String
        Private additionalCustomerReferenceNumberField As order_status_A2ReferencedOrderOrderLineAdditionalCustomerReferenceNumber
        Private orderedArticleField As order_status_A2ReferencedOrderOrderLineOrderedArticle
#End Region
#Region "Propiedades"
        Public Property LineID() As String
            Get
                Return Me.lineIDField
            End Get
            Set
                Me.lineIDField = Value
            End Set
        End Property
        Public Property CustomerLineItemNumber() As String
            Get
                Return Me.customerLineItemNumberField
            End Get
            Set
                Me.customerLineItemNumberField = Value
            End Set
        End Property
        Public Property AdditionalCustomerReferenceNumber() As order_status_A2ReferencedOrderOrderLineAdditionalCustomerReferenceNumber
            Get
                Return Me.additionalCustomerReferenceNumberField
            End Get
            Set
                Me.additionalCustomerReferenceNumberField = Value
            End Set

        End Property
        Public Property OrderedArticle() As order_status_A2ReferencedOrderOrderLineOrderedArticle
            Get
                Return Me.orderedArticleField
            End Get
            Set
                Me.orderedArticleField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderLineAdditionalCustomerReferenceNumber
#Region "Atributos"
        Private documentIDField As String
#End Region
#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return Me.documentIDField
            End Get
            Set
                Me.documentIDField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderLineOrderedArticle
#Region "Atributos"
        Private articleIdentificationField As order_status_A2ReferencedOrderOrderLineOrderedArticleArticleIdentification
        Private articleDescriptionField As order_status_A2ReferencedOrderOrderLineOrderedArticleArticleDescription
        Private requestedDeliveryDateField As String
        Private articleCommentField As String
        Private scheduleDetailsField() As order_status_A2ReferencedOrderOrderLineOrderedArticleScheduleDetails
        Private orderedQuantityField As OrderedQuantity
#End Region

#Region "Propiedades"
        Public Property ArticleIdentification() As order_status_A2ReferencedOrderOrderLineOrderedArticleArticleIdentification
            Get
                Return Me.articleIdentificationField
            End Get
            Set
                Me.articleIdentificationField = Value
            End Set
        End Property
        Public Property ArticleDescription() As order_status_A2ReferencedOrderOrderLineOrderedArticleArticleDescription
            Get
                Return Me.articleDescriptionField
            End Get
            Set
                Me.articleDescriptionField = Value
            End Set

        End Property
        Public Property RequestedDeliveryDate() As String
            Get
                Return Me.requestedDeliveryDateField
            End Get
            Set
                Me.requestedDeliveryDateField = Value
            End Set
        End Property
        Public Property ArticleComment() As String
            Get
                Return Me.articleCommentField
            End Get
            Set
                Me.articleCommentField = Value
            End Set
        End Property
        Public Property ScheduleDetails() As order_status_A2ReferencedOrderOrderLineOrderedArticleScheduleDetails()
            Get
                Return Me.scheduleDetailsField
            End Get
            Set
                Me.scheduleDetailsField = Value
            End Set
        End Property
        Public Property OrderedQuantity() As OrderedQuantity
            Get
                Return Me.orderedQuantityField
            End Get
            Set
                Me.orderedQuantityField = Value
            End Set
        End Property

#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderLineOrderedArticleArticleIdentification
#Region "Atributos"
        Private buyersArticleIDField As String
        Private manufacturersArticleIDField As String
        Private eANUCCArticleIDField As String
#End Region
#Region "Propiedades"
        Public Property BuyersArticleID() As String
            Get
                Return Me.buyersArticleIDField
            End Get
            Set
                Me.buyersArticleIDField = Value
            End Set
        End Property
        Public Property ManufacturersArticleID() As String
            Get
                Return Me.manufacturersArticleIDField
            End Get
            Set
                Me.manufacturersArticleIDField = Value
            End Set
        End Property
        Public Property EANUCCArticleID() As String
            Get
                Return Me.eANUCCArticleIDField
            End Get
            Set
                Me.eANUCCArticleIDField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderLineOrderedArticleArticleDescription
#Region "Atributos"
        Private articleDescriptionTextField As String
#End Region
#Region "Propiedades"
        Public Property ArticleDescriptionText() As String
            Get
                Return Me.articleDescriptionTextField
            End Get
            Set
                Me.articleDescriptionTextField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderLineOrderedArticleScheduleDetails
#Region "Atributos"
        Private deliveryDateField As String
        Private confirmedQuantityField As ConfirmedQuantityType
        Private cancelledQuantityField As CancelledQuantity
        Private openQuantityField As OpenQuantity
        Private scheduledArticleDespatchDetailsField() As order_status_A2ReferencedOrderOrderLineOrderedArticleScheduleDetailsScheduledArticleDespatchDetails
#End Region
#Region "Propiedades"
        Public Property DeliveryDate() As String
            Get
                Return Me.deliveryDateField
            End Get
            Set
                Me.deliveryDateField = Value
            End Set
        End Property
        Public Property ConfirmedQuantity() As ConfirmedQuantityType
            Get
                Return Me.confirmedQuantityField
            End Get
            Set
                Me.confirmedQuantityField = Value
            End Set
        End Property
        Public Property CancelledQuantity() As CancelledQuantity
            Get
                Return Me.cancelledQuantityField
            End Get
            Set
                Me.cancelledQuantityField = Value
            End Set
        End Property
        Public Property OpenQuantity() As OpenQuantity
            Get
                Return Me.openQuantityField
            End Get
            Set
                Me.openQuantityField = Value
            End Set
        End Property
        Public Property ScheduledArticleDespatchDetails() As order_status_A2ReferencedOrderOrderLineOrderedArticleScheduleDetailsScheduledArticleDespatchDetails()
            Get
                Return Me.scheduledArticleDespatchDetailsField
            End Get
            Set
                Me.scheduledArticleDespatchDetailsField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_A2ReferencedOrderOrderLineOrderedArticleScheduleDetailsScheduledArticleDespatchDetails
#Region "Atributos"
        Private despatchDateField As String
        Private despatchAdviceReferenceField As DespatchAdviceReference
        Private despatchedQuantityField As DespatchedQuantity
#End Region
#Region "Propiedades"
        Public Property DespatchDate() As String
            Get
                Return Me.despatchDateField
            End Get
            Set
                Me.despatchDateField = Value
            End Set
        End Property
        Public Property DespatchAdviceReference() As DespatchAdviceReference
            Get
                Return Me.despatchAdviceReferenceField
            End Get
            Set
                Me.despatchAdviceReferenceField = Value
            End Set
        End Property
        Public Property DespatchedQuantity() As DespatchedQuantity
            Get
                Return Me.despatchedQuantityField
            End Get
            Set
                Me.despatchedQuantityField = Value
            End Set
        End Property
#End Region
    End Class

    Partial Public Class order_status_request_A2
#Region "Atributos"
        Private documentIDField As String
        Private variantField As String
        Private orderDateFromField As String
        Private orderDateToField As String
        Private orderStatusIndicatorField As OrderStatusIndicatorEnum
        Private orderStatusIndicatorFieldSpecified As Boolean
        Private buyerPartyField As order_status_request_A2BuyerParty
        Private orderingPartyField As order_status_request_A2OrderingParty
        Private consigneeField As order_status_request_A2Consignee
        Private referencedOrderField As order_status_request_A2RefOrder
#End Region
#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return Me.documentIDField
            End Get
            Set
                Me.documentIDField = Value
            End Set
        End Property
        Public Property [Variant]() As String
            Get
                Return Me.variantField
            End Get
            Set
                Me.variantField = Value
            End Set
        End Property
        Public Property OrderDateFrom() As String
            Get
                Return Me.orderDateFromField
            End Get
            Set
                Me.orderDateFromField = Value
            End Set
        End Property
        Public Property OrderDateTo() As String
            Get
                Return Me.orderDateToField
            End Get
            Set
                Me.orderDateToField = Value
            End Set
        End Property
        Public Property OrderStatusIndicator() As OrderStatusIndicatorEnum
            Get
                Return Me.orderStatusIndicatorField
            End Get
            Set
                Me.orderStatusIndicatorField = Value
            End Set
        End Property
        Public Property OrderStatusIndicatorSpecified() As Boolean
            Get
                Return Me.orderStatusIndicatorFieldSpecified
            End Get
            Set
                Me.orderStatusIndicatorFieldSpecified = Value
            End Set
        End Property
        Public Property BuyerParty() As order_status_request_A2BuyerParty
            Get
                Return Me.buyerPartyField
            End Get
            Set
                Me.buyerPartyField = Value
            End Set
        End Property
        Public Property OrderingParty() As order_status_request_A2OrderingParty
            Get
                Return Me.orderingPartyField
            End Get
            Set
                Me.orderingPartyField = Value
            End Set
        End Property
        Public Property Consignee() As order_status_request_A2Consignee
            Get
                Return Me.consigneeField
            End Get
            Set
                Me.consigneeField = Value
            End Set
        End Property
        Public Property ReferencedOrder() As order_status_request_A2RefOrder
            Get
                Return Me.referencedOrderField
            End Get
            Set
                Me.referencedOrderField = Value
            End Set
        End Property
#End Region
        Public Enum OrderStatusIndicatorEnum
            <System.Xml.Serialization.XmlEnumAttribute("1")>
            Item1
            <System.Xml.Serialization.XmlEnumAttribute("2")>
            Item2
        End Enum
    End Class
    Partial Public Class order_status_request_A2BuyerParty
#Region "Atributos"
        Private partyIDField As String
        Private agencyCodeField As String
#End Region
#Region "Propiedades"
        Public Property PartyID() As String
            Get
                Return Me.partyIDField
            End Get
            Set
                Me.partyIDField = Value
            End Set
        End Property
        Public Property AgencyCode() As String
            Get
                Return Me.agencyCodeField
            End Get
            Set
                Me.agencyCodeField = Value
            End Set
        End Property
#End Region

    End Class
    Partial Public Class order_status_request_A2OrderingParty
#Region "Atributos"
        Private partyIDField As String
        Private agencyCodeField As order_status_request_A2OrderingPartyAgencyCode
#End Region
#Region "Propiedades"
        Public Property PartyID() As String
            Get
                Return Me.partyIDField
            End Get
            Set
                Me.partyIDField = Value
            End Set
        End Property
        Public Property AgencyCode() As order_status_request_A2OrderingPartyAgencyCode
            Get
                Return Me.agencyCodeField
            End Get
            Set
                Me.agencyCodeField = Value
            End Set
        End Property
#End Region
        Public Enum order_status_request_A2OrderingPartyAgencyCode

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("9")>
            Item9

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("91")>
            Item91

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("92")>
            Item92
        End Enum
    End Class
    Partial Public Class order_status_request_A2Consignee
#Region "Atributos"
        Private partyIDField As String
        Private agencyCodeField As order_status_request_A2ConsigneeAgencyCode
#End Region
#Region "Propiedades"
        Public Property PartyID() As String
            Get
                Return Me.partyIDField
            End Get
            Set
                Me.partyIDField = Value
            End Set
        End Property
        Public Property AgencyCode() As order_status_request_A2ConsigneeAgencyCode
            Get
                Return Me.agencyCodeField
            End Get
            Set
                Me.agencyCodeField = Value
            End Set
        End Property
#End Region
        Public Enum order_status_request_A2ConsigneeAgencyCode

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("91")>
            Item91

            '''<comentarios/>
            <System.Xml.Serialization.XmlEnumAttribute("92")>
            Item92
        End Enum
    End Class
    Partial Public Class order_status_request_A2RefOrder
#Region "Atributos"
        Private supplierOrderNumberField As order_status_request_A2ReferencedOrderSupplierOrderNumber
        Private orderReferenceField As order_status_request_A2ReferencedOrderOrderReference
#End Region
#Region "Propiedades"
        Public Property SupplierOrderNumber() As order_status_request_A2ReferencedOrderSupplierOrderNumber
            Get
                Return Me.supplierOrderNumberField
            End Get
            Set
                Me.supplierOrderNumberField = Value
            End Set
        End Property
        Public Property OrderReference() As order_status_request_A2ReferencedOrderOrderReference
            Get
                Return Me.orderReferenceField
            End Get
            Set
                Me.orderReferenceField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_request_A2ReferencedOrderSupplierOrderNumber
#Region "Atributos"
        Private documentIDField As String
#End Region

#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return Me.documentIDField
            End Get
            Set
                Me.documentIDField = Value
            End Set
        End Property
#End Region
    End Class
    Partial Public Class order_status_request_A2ReferencedOrderOrderReference
#Region "Atributos"
        Private documentIDField As String
#End Region

#Region "Propiedades"
        Public Property DocumentID() As String
            Get
                Return Me.documentIDField
            End Get
            Set
                Me.documentIDField = Value
            End Set
        End Property
#End Region
    End Class
End Namespace

