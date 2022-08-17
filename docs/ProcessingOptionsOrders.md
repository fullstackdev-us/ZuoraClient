# ZuoraClient.Model.ProcessingOptionsOrders
Invoice or Payment.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ApplicationOrder** | **List&lt;string&gt;** | The priority order to apply credit memos and/or unapplied payments to an invoice. Possible item values are: &#x60;CreditMemo&#x60;, &#x60;UnappliedPayment&#x60;.  **Note:**   - This field is valid only if the &#x60;applyCredit&#x60; field is set to &#x60;true&#x60;.   - If no value is specified for this field, the default priority order is used, [\&quot;CreditMemo\&quot;, \&quot;UnappliedPayment\&quot;], to apply credit memos first and then apply unapplied payments.   - If only one item is specified, only the items of the spedified type are applied to invoices. For example, if the value is &#x60;[\&quot;CreditMemo\&quot;]&#x60;, only credit memos are used to apply to invoices.  | [optional] 
**ApplyCredit** | **bool** | Whether to automatically apply credit memos or unapplied payments, or both to an invoice.  If the value is &#x60;true&#x60;, the credit memo or unapplied payment, or both will be automatically applied to the invoice. If no value is specified or the value is &#x60;false&#x60;, no action is taken.  **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  | [optional] 
**ApplyCreditBalance** | **bool** | Indicates if any credit balance on a customer&#39;s account is automatically applied to invoices. If no value is specified then this field defaults to false. This feature is not available if you have enabled the Invoice Settlement feature.  | [optional] 
**BillingOptions** | [**ProcessingOptionsOrdersBillingOptions**](ProcessingOptionsOrdersBillingOptions.md) |  | [optional] 
**CollectPayment** | **bool** | Indicates if the current request needs to collect payments. This value can not be &#39;true&#39; when &#39;runBilling&#39; flag is &#39;false&#39;.  | [optional] 
**ElectronicPaymentOptions** | [**ProcessingOptionsOrdersElectronicPaymentOptions**](ProcessingOptionsOrdersElectronicPaymentOptions.md) |  | [optional] 
**RunBilling** | **bool** | Indicates if the current request needs to generate an invoice. The invoice will be generated against all subscriptions included in this order.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

