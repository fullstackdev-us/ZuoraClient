# ZuoraClient.Model.GETPaymentRunSummaryResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NumberOfCreditBalanceAdjustments** | **int** | **Note:** This field is only available if you have the Credit Balance feature enabled.  The number of credit balance adjustments that are successfully processed in the payment run.  | [optional] 
**NumberOfCreditMemos** | **int** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total number of credit memos that are successfully processed in the payment run.  | [optional] 
**NumberOfDebitMemos** | **int** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total number of debit memos that are picked up for processing in the payment run.  | [optional] 
**NumberOfErrorInputData** | **int** | The number of input data that are processed with errors.  | [optional] 
**NumberOfErrors** | **int** | The number of payments with the status of &#x60;Error&#x60; and &#x60;Processing&#x60;.  | [optional] 
**NumberOfInputData** | **int** | The total number of input data.  | [optional] 
**NumberOfInvoices** | **int** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The total number of invoices that are picked up for processing in the payment run.  | [optional] 
**NumberOfPayments** | **int** | The number of payments that are successfully processed in the payment run.  | [optional] 
**NumberOfProcessedInputData** | **int** | The number of input data that are successfully processed.  | [optional] 
**NumberOfReceivables** | **int** | The total number of receivables that are picked up for processing in the payment run.  The value of this field is the sum of the value of the &#x60;numberOfInvoices&#x60; field and that of the &#x60;numberOfDebitMemos&#x60; field.  | [optional] 
**NumberOfUnappliedPayments** | **int** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The number of unapplied payments that are successfully processed in the payment run.  | [optional] 
**NumberOfUnprocessedDebitMemos** | **int** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The number of debit memos with remaining positive balances after the payment run is completed.  | [optional] 
**NumberOfUnprocessedInvoices** | **int** | **Note:** This field is only available if you have the Invoice Settlement feature enabled.  The number of invoices with remaining positive balances after the payment run is completed.  | [optional] 
**NumberOfUnprocessedReceivables** | **int** | The number of receivables with remaining positive balances after the payment run is completed.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TotalValues** | [**List&lt;GETPaymentRunSummaryTotalValues&gt;**](GETPaymentRunSummaryTotalValues.md) | Container for total values.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

