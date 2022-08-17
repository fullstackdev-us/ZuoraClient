# ZuoraClient.Model.GETJournalRunType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AggregateCurrency** | **bool** |  | [optional] 
**ExecutedOn** | **DateTime** | Date and time the journal run was executed.  | [optional] 
**JournalEntryDate** | **DateTime** | Date of the journal entry.  | [optional] 
**Number** | **string** | Journal run number.  | [optional] 
**SegmentationRuleName** | **string** | Name of GL segmentation rule used in the journal run.  | [optional] 
**Status** | **string** | Status of the journal run.   | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TargetEndDate** | **DateTime** | The target end date of the journal run.  | [optional] 
**TargetStartDate** | **DateTime** | The target start date of the journal run.  | [optional] 
**TotalJournalEntryCount** | **long** | Total number of journal entries in the journal run.  | [optional] 
**TransactionTypes** | [**List&lt;GETJournalRunTransactionType&gt;**](GETJournalRunTransactionType.md) | Transaction types included in the journal run.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

