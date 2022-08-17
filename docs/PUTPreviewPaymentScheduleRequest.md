# ZuoraClient.Model.PUTPreviewPaymentScheduleRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **decimal** | Indicates the updated amount of the pending payment schedule items.  | [optional] 
**Currency** | **string** | Indicates the updated currency of the pending payment schedule items.        | [optional] 
**Occurrences** | **int** | Indicates the updated number of payment schedule items that are created by the payment schedule.  | [optional] 
**PaymentGatewayId** | **string** | Indicates the updated payment gateway ID of the pending payment schedule items.   | [optional] 
**PaymentMethodId** | **string** | Indicates the updated payment method ID of the pending payment schedule items.   | [optional] 
**Period** | **string** | Indicates the updated period of the pending payment schedule items.  | [optional] 
**PeriodStartDate** | **DateTime** | Indicates the updated collection date for the next pending payment schedule item.  | [optional] 
**RunHour** | **int** | Specifies at which hour of the day in the tenant’s time zone this payment will be collected. Available values: &#x60;[0,1,2,~,22,23]&#x60;.    If the time difference between your tenant’s timezone and the timezone where Zuora servers are is not in full hours, for example, 2.5 hours, the payment schedule items will be triggered half hour later than your scheduled time.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

