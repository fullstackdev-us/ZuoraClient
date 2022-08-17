# ZuoraClient.Model.WorkflowInstance
A instance workflow object.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedAt** | **string** | The date and time when the workflow is created, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 
**Id** | **int** | The unique ID of the workflow.  | [optional] 
**Name** | **string** | The run number of this workflow instance  | [optional] 
**OriginalWorkflowId** | **int** | The identifier of the workflow template that is used to create this instance.  | [optional] 
**Status** | **string** | Describes the current state of this workflow instance:   - Queued: The workflow is in queue for being processed.   - Processing: The workflow is in process.  | [optional] 
**UpdatedAt** | **string** | The date and time the last time when the workflow is updated, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

