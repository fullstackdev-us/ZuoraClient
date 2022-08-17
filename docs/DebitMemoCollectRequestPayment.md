# ZuoraClient.Model.DebitMemoCollectRequestPayment
Some detail info that would be used to processed an electronic payment. The info would only effect when `collect` set to `true`. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**GatewayId** | **string** | The ID of the gateway instance that processes the payment. The ID must be a valid gateway instance ID and this gateway must support the specific payment method. If no gateway ID is specified in the request body, the default gateway for the customer account is used automatically, if this default one is not configured, the default gateway of the tenant would be used.  | [optional] 
**PaymentMethodId** | **string** | The unique ID of the payment method that the customer used to make the payment. If no payment method ID is specified in the request body, the default payment method for the customer account is used automatically. If the default payment method is different from the type of payments that you want to create, an error occurs.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

