# ZuoraClient.Model.UpdatePaymentTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Comment** | **string** | Comments about the payment.  | [optional] 
**FinanceInformation** | [**UpdatePaymentTypeAllOfFinanceInformation**](UpdatePaymentTypeAllOfFinanceInformation.md) |  | [optional] 
**PaymentScheduleNumber** | **string** | The number of the payment schedule to be linked with the payment. See [Link payments to payment schedules](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Payment_Schedules/Link_payments_with_payment_schedules) for more information. | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Zuora Payments.  You can only update the reference ID for external payments.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

