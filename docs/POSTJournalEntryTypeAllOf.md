# ZuoraClient.Model.POSTJournalEntryTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingPeriodName** | **string** | Name of the accounting period. The open-ended accounting period is named &#x60;Open-Ended&#x60;.  | 
**Currency** | **string** | The type of currency used. Currency must be active.  | 
**JournalEntryDate** | **DateTime** | Date of the journal entry.  | 
**JournalEntryItems** | [**List&lt;POSTJournalEntryItemType&gt;**](POSTJournalEntryItemType.md) | Key name that represents the list of journal entry items.  | 
**Notes** | **string** | The number associated with the revenue event.  Character limit: 2,000  | [optional] 
**Segments** | [**List&lt;POSTJournalEntrySegmentType&gt;**](POSTJournalEntrySegmentType.md) | List of segments that apply to the summary journal entry.  | [optional] 
**TransferredToAccounting** | **string** | Status shows whether the journal entry has been transferred to an accounting system.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

