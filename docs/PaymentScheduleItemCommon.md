# ZuoraClient.Model.PaymentScheduleItemCommon

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **decimal** | The amount that needs to be collected by this payment schedule item.  | 
**Currency** | **string** | The currency of the payment.  **Note**: - This field is optional. If not specified, the default value is the currency set for the account.  | [optional] 
**Description** | **string** | Description of the payment schedule item.  | [optional] 
**PaymentGatewayId** | **string** | The ID of the payment gateway.  **Note**: - This field is optional. If not specified, the default value is the payment gateway id set for the account.  | [optional] 
**PaymentMethodId** | **string** | The ID of the payment method.  **Note**: - This field is optional. If not specified, the default value is the payment method id set for the account.  | [optional] 
**RunHour** | **string** | At which hour of the day in the tenant’s timezone this payment will be collected. Available values:&#x60;[0,1,2,~,22,23]&#x60;. The default value is &#x60;0&#x60;.  | [optional] 
**ScheduledDate** | **DateTime** | The date to collect the payment.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

