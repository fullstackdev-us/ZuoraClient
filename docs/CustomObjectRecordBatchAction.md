# ZuoraClient.Model.CustomObjectRecordBatchAction
The batch action on custom object records

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AllowPartialSuccess** | **bool** | Indicates whether the records that pass the schema validation should be updated when not all records in the request pass the schema validation.  Only applicable when &#x60;type&#x60; is &#x60;update&#x60;.  | [optional] [default to false]
**Ids** | **List&lt;Guid&gt;** | Ids of the custom object records that you want to delete. Only applicable when &#x60;type&#x60; is &#x60;delete&#x60;. | [optional] 
**Records** | **Dictionary&lt;string, Object&gt;** | Object records that you want to update. Only applicable when &#x60;type&#x60; is &#x60;update&#x60;. | [optional] 
**Type** | **string** | The type of the batch action | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

