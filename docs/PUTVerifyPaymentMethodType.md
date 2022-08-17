# ZuoraClient.Model.PUTVerifyPaymentMethodType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrencyCode** | **string** | The currency used for payment method authorization.   | [optional] 
**GatewayOptions** | [**CreatePaymentMethodCommonGatewayOptions**](CreatePaymentMethodCommonGatewayOptions.md) |  | [optional] 
**PaymentGatewayName** | **string** | The name of the payment gateway instance. If no value is specified for this field, the default payment gateway of the customer account will be used.  | [optional] 
**SecurityCode** | **string** | The CVV or CVV2 security code for the credit card or debit card. To ensure PCI compliance, the value of this field is not stored and cannot be queried.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

