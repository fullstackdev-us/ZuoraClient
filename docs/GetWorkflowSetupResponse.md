# ZuoraClient.Model.GetWorkflowSetupResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CalloutTrigger** | **bool** | If true, the workflow will run upon an API callout. This field must be &#x60;true&#x60; for integrating with the Configurable Payment Retry feature or the Collections Window feature in Collect.  | [optional] 
**CreatedAt** | **string** | The date and time when the workflow was created, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format  | [optional] 
**Description** | **string** | The description of the workflow definition  | [optional] 
**Id** | **int** | The unique ID of the workflow definition  | [optional] 
**Interval** | **string** | The cron expression for workflows with scheduled_trigger as &#x60;true&#x60;  | [optional] 
**Name** | **string** | The name of the workflow definition  | [optional] 
**OndemandTrigger** | **bool** | If true, the workflow will run when manually initiated.  | [optional] 
**Priority** | **string** | Can be &#x60;High&#x60;, &#x60;Medium&#x60;, or &#x60;Low&#x60;. Higher-priority workflows take precedence over lower-priority workflows. When a workflow of higher priority is initiated, it will be placed ahead of lower-priority workflows that are running. Depending on the available resources, lower-priority workflows may be paused until resources are released.  | [optional] 
**ScheduledTrigger** | **bool** | If true, the workflow will run based on the configured schedule with the interval field.  | [optional] 
**Status** | **string** | Can be &#x60;Active&#x60; or &#x60;Inactive&#x60;. Active workfow definitions run like normal. Inactive workflow definitions cannot be run.  | [optional] 
**Timezone** | **string** | The timezone that corresponds with the cron expression in the interval field. See the [list of accepted timezone values](https://docs.google.com/spreadsheets/d/1skhepi-q5l9LyaMUPZjU_V9gzTphNMqNyV6ST5mygEo/edit?usp&#x3D;sharing).  | [optional] 
**UpdatedAt** | **string** | The date and time when the workflow was updated the last time, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

