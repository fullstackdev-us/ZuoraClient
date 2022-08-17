# ZuoraClient.Model.GetWorkflowResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CpuTime** | **string** | The overall CPU time for the execution of the workflow.  | [optional] 
**CreatedAt** | **string** | The date and time when the workflow is created, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format..  | [optional] 
**FinishedAt** | **string** | The date and time when the execution of the workflow completes, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 
**Id** | **int** | The unique ID of the workflow.  | [optional] 
**Messages** | **Object** | Messages from tasks.   **Note:** This field is only returned in Production.  | [optional] 
**Name** | **string** | The unique run number of the workflow.  | [optional] 
**OriginalWorkflowId** | **string** | The ID of the workflow setup.  | [optional] 
**RunTime** | **double** | The execution time of the workflow including the waiting time, in seconds.  | [optional] 
**Status** | **string** | The status of the workflow:   - Queued: The workflow is in queue for being processed.   - Processing: The workflow is in process.   - Stopping: The workflow is being stopped through Zuora UI.   - Stopped: The workflow is stopped through Zuora UI.   - Finished: The workflow is finished. When a workflow is finished, it might have tasks pending for retry or delay. Pending tasks do not block the onfinish branch of the workflow, but they block the oncomplete branch of the iterate.   | [optional] 
**Tasks** | [**GetWorkflowResponseTasks**](GetWorkflowResponseTasks.md) |  | [optional] 
**Type** | **string** | The type of the current workflow. Possible values:   - &#x60;Workflow::Setup&#x60;: The workflow is a setup and is used for creating workflow instances.   - &#x60;Workflow::Instance&#x60;: The workflow is an execution that has data.  | [optional] 
**UpdatedAt** | **string** | The date and time when the workflow is updated the last time, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

