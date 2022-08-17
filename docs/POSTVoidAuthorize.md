# ZuoraClient.Model.POSTVoidAuthorize

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account. This field is generally required, but is optional if you are using the Ingenico ePayments gateway. | [optional] 
**AccountNumber** | **string** | The number of the customer account. This field is generally required, but is optional if you are using the Ingenico ePayments gateway. | [optional] 
**GatewayOptions** | [**CreatePaymentMethodCommonGatewayOptions**](CreatePaymentMethodCommonGatewayOptions.md) |  | [optional] 
**GatewayOrderId** | **string** | The order ID for the specific gateway.  The specified order ID will be used in transaction authorization. If you specify an empty value for this field, Zuora will generate an ID and you will have to associate this ID with your order ID by yourself if needed. It is recommended to specify an ID for this field.  | 
**PaymentGatewayId** | **string** | The ID of the payment gateway instance. This field is required if you do not specify the &#x60;accountId&#x60; and &#x60;accountNumber&#x60; fields. | [optional] 
**TransactionId** | **string** | The ID of the transaction. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

