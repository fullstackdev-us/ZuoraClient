# ZuoraClient.Model.GETAccountTypeMetrics
Container for account metrics. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Balance** | **decimal** | The customer&#39;s total invoice balance minus credit balance.  | [optional] 
**ContractedMrr** | **decimal** | Future expected MRR that accounts for future upgrades, downgrades, upsells and cancellations.  | [optional] 
**CreditBalance** | **decimal** | Current credit balance.  | [optional] 
**TotalDebitMemoBalance** | **decimal** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Total balance of all posted debit memos.  | [optional] 
**TotalInvoiceBalance** | **decimal** | Total balance of all posted invoices.  | [optional] 
**UnappliedCreditMemoAmount** | **decimal** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Total unapplied amount of all posted credit memos.  | [optional] 
**UnappliedPaymentAmount** | **decimal** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Total unapplied amount of all posted payments.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

