# ZuoraClient.Model.PUTCreditMemoWriteOffAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Comment** | **string** | Comments about the debit memo.  | [optional] 
**MemoDate** | **DateTime** | The creation date of the debit memo and the effective date of the credit memo. Credit memos are applied to the corresponding debit memos on &#x60;memoDate&#x60;. By default, &#x60;memoDate&#x60; is set to the current date.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty. The default value is &#x60;Write-off&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

