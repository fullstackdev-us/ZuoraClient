# ZuoraClient.Model.GETPaymentScheduleResponseAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | ID of the account that owns the payment schedule.  | [optional] 
**AccountNumber** | **string** | Number of the account that owns the payment schedule.  | [optional] 
**BillingDocument** | [**GETPaymentScheduleItemResponseAllOfBillingDocument**](GETPaymentScheduleItemResponseAllOfBillingDocument.md) |  | [optional] 
**CreatedById** | **string** | The ID of the user who created this payment schedule.  | [optional] 
**CreatedDate** | **DateTime** | The date and time the payment schedule is created.  | [optional] 
**Description** | **string** | The description of the payment schedule.  | [optional] 
**Id** | **string** | ID of the payment schedule.  | [optional] 
**IsCustom** | **bool** | Indicates if the payment schedule is a custom payment schedule.  | [optional] 
**Items** | [**List&lt;PaymentScheduleItemCommonResponse&gt;**](PaymentScheduleItemCommonResponse.md) | Container for payment schedule items.  | [optional] 
**NextPaymentDate** | **DateTime** | The date the next payment will be processed.  | [optional] 
**Occurrences** | **int** | The number of payment schedule items that are created by this payment schedule.  | [optional] 
**PaymentScheduleNumber** | **string** | Number of the payment schedule.  | [optional] 
**Period** | **string** | For recurring payment schedule only. The period of payment generation. Available values include: &#x60;Monthly&#x60;, &#x60;Weekly&#x60;, &#x60;BiWeekly&#x60;.  Return &#x60;null&#x60; for custom payment schedules.  | [optional] 
**RecentPaymentDate** | **DateTime** | The date the last payment was processed.  | [optional] 
**RunHour** | **int** | [0,1,2,~,22,23]  At which hour in the day in the tenant’s timezone this payment will be collected.  Return &#x60;0&#x60; for custom payment schedules.  | [optional] 
**Standalone** | **bool** | Indicates if the payments that the payment schedule created are standalone payments.  | [optional] 
**StartDate** | **DateTime** | The date when the first payment of this payment schedule is proccessed.  | [optional] 
**Status** | **string** | The status of the payment schedule.  - Active: There is still payment schedule item to process. - Canceled: After a payment schedule is canceled by the user, the schedule is marked as &#x60;Canceled&#x60;. - Completed: After all payment schedule items are processed, the schedule is marked as &#x60;Completed&#x60;.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.          | [optional] 
**TotalPaymentsErrored** | **int** | The number of errored payments.  | [optional] 
**TotalPaymentsProcessed** | **int** | The number of processed payments.  | [optional] 
**UpdatedById** | **string** | The ID of the user who last updated this payment schedule.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time the payment schedule is last updated.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

