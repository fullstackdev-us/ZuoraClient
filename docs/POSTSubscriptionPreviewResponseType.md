# ZuoraClient.Model.POSTSubscriptionPreviewResponseType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **decimal** | Invoice amount.  | [optional] 
**AmountWithoutTax** | **decimal** | Invoice amount minus tax.  | [optional] 
**ChargeMetrics** | [**POSTSubscriptionPreviewResponseTypeChargeMetrics**](POSTSubscriptionPreviewResponseTypeChargeMetrics.md) |  | [optional] 
**ContractedMrr** | **decimal** | Monthly recurring revenue of the subscription.  | [optional] 
**CreditMemo** | [**POSTSubscriptionPreviewResponseTypeCreditMemo**](POSTSubscriptionPreviewResponseTypeCreditMemo.md) |  | [optional] 
**Invoice** | [**POSTSubscriptionPreviewResponseTypeInvoice**](POSTSubscriptionPreviewResponseTypeInvoice.md) |  | [optional] 
**InvoiceItems** | [**List&lt;POSTSubscriptionPreviewInvoiceItemsType&gt;**](POSTSubscriptionPreviewInvoiceItemsType.md) | Container for invoice items.  | [optional] 
**InvoiceTargetDate** | **DateTime** | Date through which charges are calculated on the invoice, as yyyy-mm-dd.  **Note:** This field is only available if you do not specify the Zuora REST API minor version or specify the minor version to 186.0, 187.0, 188.0, 189.0, and 196.0. See [Zuora REST API Versions](https://www.zuora.com/developer/api-reference/#section/API-Versions) for more information.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TargetDate** | **DateTime** | Date through which to calculate charges if an invoice is generated, as yyyy-mm-dd. Default is current date.  **Note:** This field is only available if you set the Zuora REST API minor version to 207.0 or later in the request header. See [Zuora REST API Versions](https://www.zuora.com/developer/api-reference/#section/API-Versions) for more information.  | [optional] 
**TaxAmount** | **decimal** | Tax amount on the invoice.  | [optional] 
**TotalContractedValue** | **decimal** | Total contracted value of the subscription.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

