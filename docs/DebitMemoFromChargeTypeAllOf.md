# ZuoraClient.Model.DebitMemoFromChargeTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the account associated with the debit memo.  **Note**: When creating debit memos from product rate plan charges, you must specify &#x60;accountNumber&#x60;, &#x60;accountId&#x60;, or both in the request body. If both fields are specified, they must correspond to the same account.  | [optional] 
**AccountNumber** | **string** | The number of the account associated with the debit memo.  **Note**: When creating debit memos from product rate plan charges, you must specify &#x60;accountNumber&#x60;, &#x60;accountId&#x60;, or both in the request body. If both fields are specified, they must correspond to the same account.  | [optional] 
**AutoPay** | **bool** | Whether debit memos are automatically picked up for processing in the corresponding payment run.   By default, debit memos are automatically picked up for processing in the corresponding payment run.  | [optional] 
**AutoPost** | **bool** | Whether to automatically post the debit memo after it is created.   Setting this field to &#x60;true&#x60;, you do not need to separately call the [Post a debit memo](https://www.zuora.com/developer/api-reference/#operation/PUT_PostDebitMemo) operation to post the debit memo.  | [optional] [default to false]
**Charges** | [**List&lt;DebitMemoFromChargeDetailType&gt;**](DebitMemoFromChargeDetailType.md) | Container for product rate plan charges. The maximum number of items is 1,000.  | [optional] 
**Comment** | **string** | Comments about the debit memo.  | [optional] 
**DueDate** | **DateTime** | The date by which the payment for the debit memo is due, in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**EffectiveDate** | **DateTime** | The date when the debit memo takes effect.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

