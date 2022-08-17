# ZuoraClient.Model.PUTPaymentScheduleItemRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **decimal** | The amount of the payment.  | [optional] 
**Currency** | **string** | The currency of the payment.  | [optional] 
**Description** | **string** | The description of the payment schedule item.  | [optional] 
**PaymentGatewayId** | **string** | ID of the payment gateway of the payment schedule item.  | [optional] 
**PaymentId** | **string** | ID of the payment that is created by the payment schedule item， or linked to the payment schedule item.   | [optional] 
**PaymentMethodId** | **string** | ID of the payment method of the payment schedule item.  | [optional] 
**RunHour** | **int** | At which hour of the day in the tenant’s timezone this payment will be collected.  | [optional] 
**ScheduledDate** | **DateTime** | The scheduled date when the payment is processed.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

