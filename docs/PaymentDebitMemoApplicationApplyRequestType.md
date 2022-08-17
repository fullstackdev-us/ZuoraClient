# ZuoraClient.Model.PaymentDebitMemoApplicationApplyRequestType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount that is applied from the payment to the debit memo.  | 
**DebitMemoId** | **string** | The unique ID of the debit memo that the payment is applied to.  | [optional] 
**DebitMemoNumber** | **string** | The number of the debit memo that the payment is applied to.  | [optional] 
**Items** | [**List&lt;PaymentDebitMemoApplicationItemApplyRequestType&gt;**](PaymentDebitMemoApplicationItemApplyRequestType.md) | Container for debit memo items. The maximum number of items is 1,000.  **Note:** This field is only available if you have the [Invoice Item Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/C_Invoice_Item_Settlement) feature enabled. Invoice Item Settlement must be used together with other Invoice Settlement features (Unapplied Payments, and Credit and Debit memos).  If you wish to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

