# ZuoraClient.Model.PUTPMCreditCardInfo

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExpirationMonth** | **int** | One or two digits expiration month (1-12).           | [optional] 
**ExpirationYear** | **int** | Four-digit expiration year.  | [optional] 
**SecurityCode** | **string** | Optional. It is the CVV or CVV2 security code specific for the credit card or debit card. To ensure PCI compliance, this value is not stored and cannot be queried.   If securityCode code is not passed in the request payload, this operation only updates related fields in the payload. It does not validate the payment method through the gateway.  If securityCode is passed in the request payload, this operation retrieves the credit card information from payload and validates them through the gateway.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

