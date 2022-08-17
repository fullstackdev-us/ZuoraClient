# ZuoraClient.Model.GETAccountSummaryType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BasicInfo** | [**GETAccountSummaryTypeBasicInfo**](GETAccountSummaryTypeBasicInfo.md) |  | [optional] 
**BillToContact** | [**GETAccountSummaryTypeBillToContact**](GETAccountSummaryTypeBillToContact.md) |  | [optional] 
**Invoices** | [**List&lt;GETAccountSummaryInvoiceType&gt;**](GETAccountSummaryInvoiceType.md) | Container for invoices. Only returns the last 6 invoices.  | [optional] 
**Payments** | [**List&lt;GETAccountSummaryPaymentType&gt;**](GETAccountSummaryPaymentType.md) | Container for payments. Only returns the last 6 payments.  | [optional] 
**SoldToContact** | [**GETAccountSummaryTypeSoldToContact**](GETAccountSummaryTypeSoldToContact.md) |  | [optional] 
**Subscriptions** | [**List&lt;GETAccountSummarySubscriptionType&gt;**](GETAccountSummarySubscriptionType.md) | Container for subscriptions.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TaxInfo** | [**GETAccountSummaryTypeTaxInfo**](GETAccountSummaryTypeTaxInfo.md) |  | [optional] 
**Usage** | [**List&lt;GETAccountSummaryUsageType&gt;**](GETAccountSummaryUsageType.md) | Container for usage data. Only returns the last 6 months of usage.  **Note:** If the Active Rating feature is enabled, no usage data is returned in the response body field.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

