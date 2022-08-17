# ZuoraClient.Model.GETAccountingPeriodWithoutSuccessType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedBy** | **string** | ID of the user who created the accounting period.  | [optional] 
**CreatedOn** | **DateTime** | Date and time when the accounting period was created.  | [optional] 
**EndDate** | **DateTime** | The end date of the accounting period.  | [optional] 
**FileIds** | [**GETAccountingPeriodTypeAllOfFileIds**](GETAccountingPeriodTypeAllOfFileIds.md) |  | [optional] 
**FiscalYear** | **string** | Fiscal year of the accounting period.  | [optional] 
**FiscalQuarter** | **long** |  | [optional] 
**Id** | **string** | ID of the accounting period.  | [optional] 
**Name** | **string** | Name of the accounting period.  | [optional] 
**Notes** | **string** | Any optional notes about the accounting period.  | [optional] 
**RunTrialBalanceEnd** | **DateTime** | Date and time that the trial balance was completed. If the trial balance status is &#x60;Pending&#x60;, &#x60;Processing&#x60;, or &#x60;Error&#x60;, this field is &#x60;null&#x60;.  | [optional] 
**RunTrialBalanceErrorMessage** | **string** | If trial balance status is Error, an error message is returned in this field.  | [optional] 
**RunTrialBalanceStart** | **DateTime** | Date and time that the trial balance was run. If the trial balance status is &#x60;Pending&#x60;, this field is &#x60;null&#x60;.  | [optional] 
**RunTrialBalanceStatus** | **string** | Status of the trial balance for the accounting period. Possible values:  * &#x60;Pending&#x60; * &#x60;Processing&#x60; * &#x60;Completed&#x60; * &#x60;Error&#x60;  | [optional] 
**StartDate** | **DateTime** | The start date of the accounting period.  | [optional] 
**Status** | **string** | Status of the accounting period. Possible values:  * &#x60;Open&#x60; * &#x60;PendingClose&#x60; * &#x60;Closed&#x60;  | [optional] 
**UpdatedBy** | **string** | D of the user who last updated the accounting period.  | [optional] 
**UpdatedOn** | **DateTime** | Date and time when the accounting period was last updated.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

