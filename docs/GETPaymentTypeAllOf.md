# ZuoraClient.Model.GETPaymentTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountID** | **string** | Customer account ID.  | [optional] 
**AccountName** | **string** | Customer account name.  | [optional] 
**AccountNumber** | **string** | Customer account number.  | [optional] 
**Amount** | **decimal** | Payment amount.  | [optional] 
**EffectiveDate** | **DateTime** | Effective payment date as _yyyy-mm-dd_.  | [optional] 
**GatewayTransactionNumber** | **string** | Transaction ID from payment gateway.  | [optional] 
**Id** | **string** | PaymentID.  | [optional] 
**PaidInvoices** | [**List&lt;GETPaidInvoicesType&gt;**](GETPaidInvoicesType.md) | Information about one or more invoices to which this payment was applied:  | [optional] 
**PaymentMethodID** | **string** | Payment method.  | [optional] 
**PaymentNumber** | **string** | Unique payment number.  | [optional] 
**Status** | **string** | Possible values are: &#x60;Draft&#x60;, &#x60;Processing&#x60;, &#x60;Processed&#x60;, &#x60;Error&#x60;, &#x60;Voided&#x60;, &#x60;Canceled&#x60;, &#x60;Posted.  | [optional] 
**Type** | **string** | Possible values are: &#x60;External&#x60;, &#x60;Electronic&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

