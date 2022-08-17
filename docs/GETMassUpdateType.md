# ZuoraClient.Model.GETMassUpdateType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActionType** | **string** | Type of mass action.  | [optional] 
**EndedOn** | **DateTime** | Date and time that the mass action was completed. The format is &#x60;yyyy-MM-dd hh:mm:ss&#x60;.  | [optional] 
**ErrorCount** | **string** | Total number of failed records.  This field is updated in real time. When the mass action **status** is Processing, this field returns the number of records that have failed so far. When the mass action **status** is Pending, this field is null.  | [optional] 
**InputSize** | **long** | Size of the input file in bytes.  | [optional] 
**OutputSize** | **long** | Size of the response file in bytes.  | [optional] 
**OutputType** | **string** | Type of output for the response file. The following table describes the output type.  | Output Type    | Description                         | |- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | (url:.csv.zip) | URL pointing to a zipped .csv file. |  | [optional] 
**OutputURL** | **string** | URL to download the response file. The response file is a zipped .csv file.  The response file is identical to the file you uploaded to perform the mass action, with additional columns providing information about the outcome of each record.  This field only returns a value when the mass action **status** is Completed or Stopped. Otherwise, this field is null.  | [optional] 
**ProcessedCount** | **string** | Total number of processed records. This field is equal to the sum of &#x60;errorCount&#x60; and &#x60;successCount&#x60;.  This field is updated in real time. When the mass action **status** is Processing, this field returns the number of records that have been processed so far. When the mass action **status** is Pending, this field is null.  | [optional] 
**StartedOn** | **DateTime** | Date and time that Zuora started processing the mass action. The format is &#x60;yyyy-MM-dd hh:mm:ss&#x60;.  | [optional] 
**Status** | **string** | Status of the mass action. The following table describes the mass action statuses.  | Status     | Description                                                                | |- -- -- -- -- -- -|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | Pending    | Mass action has not yet started being processed.                           | | Processing | Mass action is in progress.                                                | | Stopping   | Mass action is in the process of stopping, but has not yet stopped.        | | Stopped    | Mass action has stopped.                                                   | | Completed  | Mass action was successfully completed. There may still be failed records. | | Failed     | Mass action failed. No records are processed. No response file is created. |  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**SuccessCount** | **string** | Total number of successful records. This field is updated in real time. When the mass action **status** is Processing, this field returns the number of records that have succeeded so far. When the mass action **status** is Pending, this field is null.  | [optional] 
**TotalCount** | **string** | Total number of records in the uploaded mass action file. When the mass action **status** is Pending, this field is null.  | [optional] 
**UploadedBy** | **string** | Email of the person who uploaded the mass action file.  | [optional] 
**UploadedOn** | **DateTime** | Date and time that the mass action file was uploaded. The format is &#x60;yyyy-MM-dd hh:mm:ss&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

