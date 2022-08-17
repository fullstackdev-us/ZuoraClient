# ZuoraClient.Model.GETPaymentRunSummaryTotalValues

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TotalValueOfCreditBalance** | **string** | **Note:** This field is only available if you have the Credit Balance feature enabled.  The total amount of credit balance after the payment run is completed.  | [optional] 
**TotalValueOfCreditMemos** | **string** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total amount of credit memos that are successfully processed in the payment run.  | [optional] 
**TotalValueOfDebitMemos** | **string** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total amount of debit memos that are picked up for processing in the payment run.  | [optional] 
**TotalValueOfErrors** | **string** | The total amount of receivables associated with the payments with the status of &#x60;Error&#x60; and &#x60;Processing&#x60;.  | [optional] 
**TotalValueOfInvoices** | **string** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total amount of invoices that are picked up for processing in the payment run.  | [optional] 
**TotalValueOfPayments** | **string** | The total amount of payments that are successfully processed in the payment run.  | [optional] 
**TotalValueOfReceivables** | **string** | The total amount of receivables associated with the payment run.  The value of this field is the sum of the value of the &#x60;totalValueOfInvoices&#x60; field and that of the &#x60;totalValueOfDebitMemos&#x60; field.  | [optional] 
**TotalValueOfUnappliedPayments** | **int** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total amount of unapplied payments that are successfully processed in the payment run.  | [optional] 
**TotalValueOfUnprocessedDebitMemos** | **string** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total amount of debit memos with remaining positive balances after the payment run is completed.  | [optional] 
**TotalValueOfUnprocessedInvoices** | **string** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total amount of invoices with remaining positive balances after the payment run is completed.  | [optional] 
**TotalValueOfUnprocessedReceivables** | **string** | The total amount of receivables with remaining positive balances after the payment run is completed.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

