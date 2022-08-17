# ZuoraClient.Model.CreditMemoFromInvoiceTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoApplyToInvoiceUponPosting** | **bool** | Whether the credit memo automatically applies to the invoice upon posting.  | [optional] 
**AutoPost** | **bool** | Whether to automatically post the credit memo after it is created.  Setting this field to &#x60;true&#x60;, you do not need to separately call the [Post credit memo](https://www.zuora.com/developer/api-reference/#operation/PUT_PostCreditMemo) operation to post the credit memo.  | [optional] [default to false]
**Comment** | **string** | Comments about the credit memo.  | [optional] 
**EffectiveDate** | **DateTime** | The date when the credit memo takes effect.  | [optional] 
**ExcludeFromAutoApplyRules** | **bool** | Whether the credit memo is excluded from the rule of automatically applying credit memos to invoices.  | [optional] 
**InvoiceId** | **string** | The ID of the invoice that the credit memo is created from. * If this field is specified, its value must be the same as the value of the &#x60;invoiceId&#x60; path parameter. Otherwise, its value overrides the value of the &#x60;invoiceId&#x60; path parameter.  * If this field is not specified, the value of the &#x60;invoiceId&#x60; path parameter is used.  | [optional] 
**Items** | [**List&lt;CreditMemoItemFromInvoiceItemType&gt;**](CreditMemoItemFromInvoiceItemType.md) | Container for items. The maximum number of items is 1,000.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code.  | [optional] 
**TaxAutoCalculation** | **bool** | Whether to automatically calculate taxes in the credit memo.  | [optional] [default to true]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

