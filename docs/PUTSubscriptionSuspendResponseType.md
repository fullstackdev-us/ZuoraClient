# ZuoraClient.Model.PUTSubscriptionSuspendResponseType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreditMemoId** | **string** | The credit memo ID, if a credit memo is generated during the subscription process.  **Note:** This container is only available if you set the Zuora REST API minor version to 207.0 or later in the request header, and you have  [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  | [optional] 
**InvoiceId** | **string** | Invoice ID, if an invoice is generated during the subscription process.  | [optional] 
**PaidAmount** | **decimal** | Payment amount, if a payment is collected.  | [optional] 
**PaymentId** | **string** | Payment ID, if a payment is collected.  | [optional] 
**ResumeDate** | **DateTime** | The date when subscription resumption takes effect, in the format yyyy-mm-dd.  | [optional] 
**SubscriptionId** | **string** | The subscription ID.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**SuspendDate** | **DateTime** | The date when subscription suspension takes effect, in the format yyyy-mm-dd.  | [optional] 
**TermEndDate** | **DateTime** | The date when the new subscription term ends, in the format yyyy-mm-dd.  | [optional] 
**TotalDeltaTcv** | **decimal** | Change in the total contracted value of the subscription as a result of the update.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

