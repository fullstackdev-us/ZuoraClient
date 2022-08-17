# ZuoraClient.Model.PUTCreditMemoTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoApplyUponPosting** | **bool** | Whether the credit memo automatically applies to the invoice upon posting.  | [optional] 
**Comment** | **string** | Comments about the credit memo.  | [optional] 
**EffectiveDate** | **DateTime** | The date when the credit memo takes effect.  | [optional] 
**ExcludeFromAutoApplyRules** | **bool** | Whether the credit memo is excluded from the rule of automatically applying unapplied credit memos to invoices and debit memos during payment runs. If you set this field to &#x60;true&#x60;, a payment run does not pick up this credit memo or apply it to other invoices or debit memos.  | [optional] 
**Items** | [**List&lt;PUTCreditMemoItemType&gt;**](PUTCreditMemoItemType.md) | Container for credit memo items.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code.  | [optional] 
**TransferredToAccounting** | **string** | Whether the credit memo is transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite.   | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

