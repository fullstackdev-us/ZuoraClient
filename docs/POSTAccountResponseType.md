# ZuoraClient.Model.POSTAccountResponseType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | Auto-generated account ID.  | [optional] 
**AccountNumber** | **string** | Account number.  | [optional] 
**BillToContactId** | **string** | The ID of the bill-to contact.  | [optional] 
**ContractedMrr** | **decimal** | Contracted monthly recurring revenue of the subscription.  | [optional] 
**CreditMemoId** | **string** | The credit memo ID, if a credit memo is generated during the subscription process.  **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  | [optional] 
**InvoiceId** | **string** | ID of the invoice generated at account creation, if applicable.  | [optional] 
**PaidAmount** | **decimal** | Amount collected on the invoice generated at account creation, if applicable.  | [optional] 
**PaymentId** | **string** | ID of the payment collected on the invoice generated at account creation, if applicable.  | [optional] 
**PaymentMethodId** | **string** | ID of the payment method that was set up at account creation, which automatically becomes the default payment method for this account.  | [optional] 
**SoldToContactId** | **string** | The ID of the sold-to contact.  | [optional] 
**SubscriptionId** | **string** | ID of the subscription that was set up at account creation, if applicable.  | [optional] 
**SubscriptionNumber** | **string** | Number of the subscription that was set up at account creation, if applicable.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TotalContractedValue** | **decimal** | Total contracted value of the subscription.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

