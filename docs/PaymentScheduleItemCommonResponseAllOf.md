# ZuoraClient.Model.PaymentScheduleItemCommonResponseAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | ID of the customer account that owns the payment schedule item, for example &#x60;402880e741112b310149b7343ef81234&#x60;.  | [optional] 
**Amount** | **decimal** | The amount of the payment.  | [optional] 
**BillingDocument** | [**POSTPaymentScheduleResponseAllOfBillingDocument**](POSTPaymentScheduleResponseAllOfBillingDocument.md) |  | [optional] 
**CreatedById** | **string** | The ID of the user who created the payment schedule item.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the payment schedule item was created.  | [optional] 
**Currency** | **string** | The currency of the payment.  | [optional] 
**Description** | **string** | The description of the payment schedule item.  | [optional] 
**ErrorMessage** | **string** | The error message indicating if the error is related to configuration or payment collection.  | [optional] 
**Id** | **string** | ID of the payment schedule item. For example, &#x60;412880e749b72b310149b7343ef81346&#x60;.  | [optional] 
**Number** | **string** | Number of the payment schedule item.  | [optional] 
**PaymentGatewayId** | **string** | ID of the payment gateway of the payment schedule item.  | [optional] 
**PaymentId** | **string** | ID of the payment that is created by the payment schedule item， or linked to the payment schedule item.   | [optional] 
**PaymentMethodId** | **string** | ID of the payment method of the payment schedule item.  | [optional] 
**PaymentScheduleId** | **string** | ID of the payment schedule that contains the payment schedule item, for example, &#x60;ID402880e749b72b310149b7343ef80005&#x60;.  | [optional] 
**PaymentScheduleNumber** | **string** | Number of the payment schedule that contains the payment schedule item, for example, &#x60;ID402880e749b72b310149b7343ef80005&#x60;.  | [optional] 
**RunHour** | **int** | At which hour in the day in the tenant’s timezone this payment will be collected.  | [optional] 
**ScheduledDate** | **DateTime** | The scheduled date when the payment is processed.  | [optional] 
**Standalone** | **bool** | Indicates if the payment created by the payment schedule item is a standalone payment or not.  | [optional] 
**Status** | **string** | ID of the payment method of the payment schedule item.  - &#x60;Pending&#x60;: Payment schedule item is waiting for processing. - &#x60;Processed&#x60;: The payment has been collected. - &#x60;Error&#x60;: Failed to collect the payment. - &#x60;Canceled&#x60;: After a pending payment schedule item is canceled by the user, the item is marked as &#x60;Canceled&#x60;.  | [optional] 
**UpdatedById** | **string** | The ID of the user who updated the payment schedule item.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the payment schedule item was last updated.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

