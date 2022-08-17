# ZuoraClient.Model.PaymentInvoiceApplicationApplyRequestType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount that is applied from the payment to the invoice.  | 
**InvoiceId** | **string** | The unique ID of the invoice that the payment is applied to.  | [optional] 
**InvoiceNumber** | **string** | The number of the invoice that the payment is applied to. For example, &#x60;INV00000001&#x60;.   **Note:** When both the &#x60;invoiceNumber&#x60; and &#x60;invoiceId&#x60; fields are specified, the two fields must match with each other.  | [optional] 
**Items** | [**List&lt;PaymentInvoiceApplicationItemApplyRequestType&gt;**](PaymentInvoiceApplicationItemApplyRequestType.md) | Container for invoice items. The maximum number of items is 1,000.  **Note:** This field is only available if you have the [Invoice Item Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/C_Invoice_Item_Settlement) feature enabled. Invoice Item Settlement must be used together with other Invoice Settlement features (Unapplied Payments, and Credit and Debit memos).  If you wish to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

