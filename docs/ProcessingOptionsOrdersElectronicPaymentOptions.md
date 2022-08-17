# ZuoraClient.Model.ProcessingOptionsOrdersElectronicPaymentOptions
Container for the electronic payment options. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PaymentGatewayId** | **string** | Specifies the ID of a payment gateway to override the default gateway. If this field is not specified, the default payment gateway will be used to process the payment.  | [optional] 
**PaymentMethodId** | **string** | Specifies an electronic payment method. It can be one that has already been associated with an invoice owner, or an orphan payment method, which is not associated with any invoice owner. For an orphan payment method, this operation will then associate it with the account that this order will be created under.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

