# ZuoraClient.Model.CreatePaymentMethodCommonMandateInfo
The mandate information for the Credit Card, Credit Card Reference Transaction, ACH, or Bank Transfer payment method. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MandateId** | **string** | The mandate ID.  When creating an ACH payment method, if you need to pass in tokenized information, use the &#x60;mandateId&#x60; instead of &#x60;tokenId&#x60; field.  | [optional] 
**MandateReason** | **string** | The reason of the mandate from the gateway side.  | [optional] 
**MandateStatus** | **string** | The status of the mandate from the gateway side.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

