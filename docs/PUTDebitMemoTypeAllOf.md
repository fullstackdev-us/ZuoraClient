# ZuoraClient.Model.PUTDebitMemoTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoPay** | **bool** | Whether debit memos are automatically picked up for processing in the corresponding payment run.   By default, debit memos are automatically picked up for processing in the corresponding payment run.  | [optional] 
**Comment** | **string** | Comments about the debit memo.  | [optional] 
**DueDate** | **DateTime** | The date by which the payment for the debit memo is due, in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**EffectiveDate** | **DateTime** | The date when the debit memo takes effect.  | [optional] 
**Items** | [**List&lt;PUTDebitMemoItemType&gt;**](PUTDebitMemoItemType.md) | Container for debit memo items.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code  | [optional] 
**TransferredToAccounting** | **string** | Whether the debit memo is transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite.   | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

