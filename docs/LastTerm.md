# ZuoraClient.Model.LastTerm
The length of the period for the current subscription term.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Period** | **int** | Specify only when the termType is &#39;TERMED&#39;. | [optional] 
**PeriodType** | **string** | Specify only when the termType is &#39;TERMED&#39;. | [optional] 
**StartDate** | **DateTime** | The start date of the current term. You can change the term start date of a renewed subscription through a T&amp;Cs order action. However, when changing it to an earlier date, this date must not be earlier than the term start date of the current term before this T&amp;Cs.  | [optional] 
**TermType** | **string** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

