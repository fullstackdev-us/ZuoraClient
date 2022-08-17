# ZuoraClient.Model.DataQueryJobCancelled
A cancelled data query job. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedBy** | **Guid** | The query job creator&#39;s Id.  | [optional] 
**Id** | **Guid** | Internal identifier of the query job.  | [optional] 
**Query** | **string** | The query that was submitted.  | [optional] 
**RemainingRetries** | **int** | The number of times that Zuora will retry the query if Zuora is unable to perform the query.  | [optional] 
**UpdatedOn** | **DateTime** | Date and time when the query job was last updated, in ISO 8601 format.  | [optional] 
**QueryStatus** | **string** | Status of the query job.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

