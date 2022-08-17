# ZuoraClient.Model.Task
A task. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActionType** | **string** | The type of the task.  | [optional] 
**CallType** | **string** | The type of API used.  | [optional] 
**ConcurrentLimit** | **int** | the number of concurrent tasks that are allowed to run simultaneously | [optional] 
**Data** | **Object** | The data payload for the task.  | [optional] 
**EndTime** | **string** | If **Instance** is **true**, the end time of the task instance.  | [optional] 
**Error** | **string** | If **Instance** is **true** and **status** is **Error**, the error reason of the task instance failure.  | [optional] 
**ErrorClass** | **string** | If **Instance** is **true** and **status** is **Error**, the error class of the task instance failure.  | [optional] 
**ErrorDetails** | **string** | If **Instance** is **true** and **status** is **Error**, the error details of the task instance failure.  | [optional] 
**Id** | **int** | The unique ID of the task.  | [optional] 
**Instance** | **bool** | Indicates whether this task belongs to an instance of a workflow.  | [optional] 
**Name** | **string** | The name of the task.  | [optional] 
**Object** | **string** | The selected object for the task.  | [optional] 
**ObjectId** | **string** | The id of the selected object of the task.  | [optional] 
**OriginalTaskId** | **int** | If **Instance** is **true**, the ID of the original task in the original workflow.  | [optional] 
**OriginalWorkflowId** | **int** | If **Instance** is **true**, the ID of the original workflow.  | [optional] 
**Parameters** | **Object** | The configuration of the task.  | [optional] 
**StartTime** | **string** | If **Instance** is **true**, the start time of the task instance.  | [optional] 
**Status** | **string** | If **Instance** is **true**, the status of the task instance.  | [optional] 
**Tags** | **List&lt;string&gt;** | The array of filter tags.  | [optional] 
**TaskId** | **int** | the id of this task&#39;s parent task. Will be null if this is the first task of the workflow | [optional] 
**WorkflowId** | **int** | The ID of the workflow that the task belongs to.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

