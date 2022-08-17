# ZuoraClient.Model.DetailedWorkflow
A workflow. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CallType** | **string** | The call type of the active workflow version.  | [optional] 
**CalloutTrigger** | **bool** | Indicates whether the callout trigger is enabled for the retrieved workflow.  | [optional] 
**CreatedAt** | **string** | The date and time when the workflow is created, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 
**Description** | **string** | The description of the workflow.  | [optional] 
**FinishedAt** | **string** | The date and time when the instance of the workflow version finished at.  | [optional] 
**Id** | **int** | The unique ID of the workflow.  | [optional] 
**Interval** | **string** | The schedule of the workflow, in a CRON expression. Returns null if the schedued trigger is disabled.  | [optional] 
**Name** | **string** | The name of the workflow.  | [optional] 
**OndemandTrigger** | **bool** | Indicates whether the ondemand trigger is enabled for the workflow.  | [optional] 
**OriginalWorkflowId** | **int** | The unique ID of the original workflow version.  | [optional] 
**Priority** | **string** | The priority of the active workflow version.   | [optional] 
**ScheduledTrigger** | **bool** | Indicates whether the scheduled trigger is enabled for the workflow.  | [optional] 
**StartedAt** | **string** | The date and time when the instance of the workflow version started at.  | [optional] 
**Status** | **int** | The status of the active workflow version.  | [optional] 
**SyncTrigger** | **bool** | Indicates whether the workflow version is enabled for the sync mode.  | [optional] 
**Timezone** | **string** | The timezone that is configured for the scheduler of the workflow. Returns null if the scheduled trigger is disabled.  | [optional] 
**Type** | **string** | The type of the workflow. Currently the only valid value is &#39;Workflow::Setup&#39;.  | [optional] 
**UpdatedAt** | **string** | The date and time when the workflow is updated the last time, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 
**_Version** | **string** | The version number of the active workflow version.              | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

