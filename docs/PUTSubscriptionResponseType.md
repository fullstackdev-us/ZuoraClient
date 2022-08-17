# ZuoraClient.Model.PUTSubscriptionResponseType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **decimal** | Invoice amount. Preview mode only.  | [optional] 
**AmountWithoutTax** | **decimal** | Invoice amount minus tax. Preview mode only.  | [optional] 
**ChargeMetrics** | [**PUTSubscriptionResponseTypeChargeMetrics**](PUTSubscriptionResponseTypeChargeMetrics.md) |  | [optional] 
**CreditMemo** | [**PUTSubscriptionResponseTypeCreditMemo**](PUTSubscriptionResponseTypeCreditMemo.md) |  | [optional] 
**CreditMemoId** | **string** | The credit memo ID, if a credit memo is generated during the subscription process.  **Note:** This container is only available if you set the Zuora REST API minor version to 207.0 or later in the request header, and you have  [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  | [optional] 
**Invoice** | [**PUTSubscriptionResponseTypeInvoice**](PUTSubscriptionResponseTypeInvoice.md) |  | [optional] 
**InvoiceId** | **string** | Invoice ID, if an invoice is generated during the update.  | [optional] 
**InvoiceItems** | [**List&lt;PUTSubscriptionPreviewInvoiceItemsType&gt;**](PUTSubscriptionPreviewInvoiceItemsType.md) | Container for invoice items.  | [optional] 
**InvoiceTargetDate** | **DateTime** | Date through which charges are calculated on the invoice, as yyyy-mm-dd. Preview mode only.  **Note:** This field is only available if you do not specify the Zuora REST API minor version or specify the minor version to 186.0, 187.0, 188.0, 189.0, and 196.0. See [Zuora REST API Versions](https://www.zuora.com/developer/api-reference/#section/API-Versions) for more information.  | [optional] 
**PaidAmount** | **decimal** | Payment amount, if a payment is collected  | [optional] 
**PaymentId** | **string** | Payment ID, if a payment is collected.  | [optional] 
**SubscriptionId** | **string** | The ID of the resulting new subscription.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TargetDate** | **DateTime** | Date through which to calculate charges if an invoice is generated, as yyyy-mm-dd. Default is current date.  **Note:** This field is only available if you set the Zuora REST API minor version to 207.0 or later in the request header. See [Zuora REST API Versions](https://www.zuora.com/developer/api-reference/#section/API-Versions) for more information.  | [optional] 
**TaxAmount** | **decimal** | Tax amount on the invoice.  | [optional] 
**TotalDeltaMrr** | **decimal** | Change in the subscription monthly recurring revenue as a result of the update.  | [optional] 
**TotalDeltaTcv** | **decimal** | Change in the total contracted value of the subscription as a result of the update.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

