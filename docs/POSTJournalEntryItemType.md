# ZuoraClient.Model.POSTJournalEntryItemType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingCodeName** | **string** | Name of the accounting code.  | 
**AccountingCodeType** | **string** | Accounting code type. This field is required if &#x60;accountingCodeName&#x60; is not unique.  Note that &#x60;On-Account Receivable&#x60; is only available if you enable the Invoice Settlement feature.   | [optional] 
**Amount** | **decimal** | Journal entry item amount in transaction currency.  | 
**HomeCurrencyAmount** | **decimal** | Journal entry item amount in home currency.  This field is required if you have set your home currency for foreign currency conversion. Otherwise, do not pass this field.  | [optional] 
**Type** | **string** | Type of journal entry item.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

