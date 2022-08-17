# ZuoraClient.Model.Workflow
A workflow. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CalloutTrigger** | **bool** | Indicates whether the callout trigger is enabled for the retrieved workflow.  | [optional] 
**CreatedAt** | **string** | The date and time when the workflow is created, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 
**Description** | **string** | The description of the workflow.  | [optional] 
**Id** | **int** | The unique ID of the workflow.  | [optional] 
**Interval** | **string** | The schedule of the workflow, in a CRON expression. Returns null if the schedued trigger is disabled.  | [optional] 
**Name** | **string** | The name of the workflow.  | [optional] 
**OndemandTrigger** | **bool** | Indicates whether the ondemand trigger is enabled for the workflow.  | [optional] 
**ScheduledTrigger** | **bool** | Indicates whether the scheduled trigger is enabled for the workflow.  | [optional] 
**Timezone** | **string** | The timezone that is configured for the scheduler of the workflow. Returns null if the scheduled trigger is disabled.  | [optional] 
**Type** | **string** | The type of the workflow. Currently the only valid value is &#39;Workflow::Setup&#39;.  | [optional] 
**UpdatedAt** | **string** | The date and time when the workflow is updated the last time, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format.  | [optional] 
**_Version** | **string** | The version number of the workflow.   | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

