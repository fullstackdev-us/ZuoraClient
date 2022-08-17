# ZuoraClient.Model.DebitMemoFromInvoiceTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoPay** | **bool** | Whether debit memos are automatically picked up for processing in the corresponding payment run.  By default, debit memos are automatically picked up for processing in the corresponding payment run.  | [optional] 
**AutoPost** | **bool** | Whether to automatically post the debit memo after it is created.  Setting this field to &#x60;true&#x60;, you do not need to separately call the [Post debit memo](https://www.zuora.com/developer/api-reference/#operation/PUT_PostDebitMemo) operation to post the debit memo.  | [optional] [default to false]
**Comment** | **string** | Comments about the debit memo.   | [optional] 
**EffectiveDate** | **DateTime** | The date when the debit memo takes effect.  | [optional] 
**InvoiceId** | **string** | The ID of the invoice that the debit memo is created from. * If this field is specified, its value must be the same as the value of the &#x60;invoiceId&#x60; path parameter. Otherwise, its value overrides the value of the &#x60;invoiceId&#x60; path parameter.  * If this field is not specified, the value of the &#x60;invoiceId&#x60; path parameter is used.   | [optional] 
**Items** | [**List&lt;DebitMemoItemFromInvoiceItemType&gt;**](DebitMemoItemFromInvoiceItemType.md) | Container for items. The maximum number of items is 1,000.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code.  | [optional] 
**TaxAutoCalculation** | **bool** | Whether to automatically calculate taxes in the debit memo.  | [optional] [default to true]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

