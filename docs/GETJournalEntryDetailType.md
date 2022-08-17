# ZuoraClient.Model.GETJournalEntryDetailType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingPeriodName** | **string** | Name of the accounting period that the journal entry belongs to.  | [optional] 
**AggregateCurrency** | **bool** | Returns true if the journal entry is aggregating currencies. That is, if the journal entry was created when the &#x60;Aggregate transactions with different currencies during a Journal Run&#x60; setting was configured to &#x60;Yes&#x60;. Otherwise, returns &#x60;false&#x60;.  | [optional] 
**Currency** | **string** | Currency used.  | [optional] 
**HomeCurrency** | **string** | Home currency used.  | [optional] 
**JournalEntryDate** | **DateTime** | Date of the journal entry.  | [optional] 
**JournalEntryItems** | [**List&lt;GETJournalEntryItemType&gt;**](GETJournalEntryItemType.md) | Key name that represents the list of journal entry items.  | [optional] 
**Notes** | **string** |  Additional information about this record. Character limit: 2,000  | [optional] 
**Number** | **string** | Journal entry number in the format JE-00000001.  | [optional] 
**Segments** | [**List&lt;GETJournalEntrySegmentType&gt;**](GETJournalEntrySegmentType.md) | List of segments that apply to the summary journal entry.  | [optional] 
**Status** | **string** | Status of journal entry.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TimePeriodEnd** | **DateTime** | End date of time period included in the journal entry.  | [optional] 
**TimePeriodStart** | **DateTime** | Start date of time period included in the journal entry.  | [optional] 
**TransactionType** | **string** | Transaction type of the transactions included in the summary journal entry.  | [optional] 
**TransferDateTime** | **DateTime** | Date and time that transferredToAccounting was changed to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;.  | [optional] 
**TransferredBy** | **string** | User ID of the person who changed transferredToAccounting to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;.  | [optional] 
**TransferredToAccounting** | **string** | Status shows whether the journal entry has been transferred to an accounting system.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

