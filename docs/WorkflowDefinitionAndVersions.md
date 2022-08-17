# ZuoraClient.Model.WorkflowDefinitionAndVersions
A workflow. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActiveVersion** | [**WorkflowDefinitionActiveVersion**](WorkflowDefinitionActiveVersion.md) |  | [optional] 
**CalloutTrigger** | **bool** | Indicates whether the callout trigger is enabled for the retrieved workflow.  | [optional] 
**CreatedAt** | **string** | The date and time when the workflow is created, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 
**Description** | **string** | The description of the workflow definition.  | [optional] 
**Id** | **int** | The unique ID of the workflow definition.  | [optional] 
**Interval** | **string** | The schedule of the workflow, in a CRON expression. Returns null if the schedued trigger is disabled.  | [optional] 
**LatestInactiveVerisons** | [**List&lt;Workflow&gt;**](Workflow.md) | The list of inactive workflow versions retrieved. Maximum number of versions retrieved is 10.    | [optional] 
**Name** | **string** | The name of the workflow definition.  | [optional] 
**OndemandTrigger** | **bool** | Indicates whether the ondemand trigger is enabled for the workflow.  | [optional] 
**ScheduledTrigger** | **bool** | Indicates whether the scheduled trigger is enabled for the workflow.  | [optional] 
**Status** | **string** | The status of the workflow definition.  | [optional] 
**Timezone** | **string** | The timezone that is configured for the scheduler of the workflow. Returns null if the scheduled trigger is disabled.  | [optional] 
**UpdatedAt** | **string** | The date and time when the workflow is updated the last time, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

