# ZuoraClient.Model.GETAccountSummaryPaymentType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EffectiveDate** | **DateTime** | Effective date as &#x60;yyyy-mm-dd&#x60;.  | [optional] 
**Id** | **string** | Payment ID.  | [optional] 
**PaidInvoices** | [**List&lt;GETAccountSummaryPaymentInvoiceType&gt;**](GETAccountSummaryPaymentInvoiceType.md) | Container for paid invoices for this subscription.  | [optional] 
**PaymentNumber** | **string** | Payment number.  | [optional] 
**PaymentType** | **string** | Payment type; possible values are: &#x60;External&#x60;, &#x60;Electronic&#x60;.  | [optional] 
**Status** | **string** | Payment status. Possible values are: &#x60;Draft&#x60;, &#x60;Processing&#x60;, &#x60;Processed&#x60;, &#x60;Error&#x60;, &#x60;Voided&#x60;, &#x60;Canceled&#x60;, &#x60;Posted&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

