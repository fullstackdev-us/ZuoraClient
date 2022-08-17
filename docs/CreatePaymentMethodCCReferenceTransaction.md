# ZuoraClient.Model.CreatePaymentMethodCCReferenceTransaction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreditCardMaskNumber** | **string** | The masked credit card number, such as: &#x60;&#x60;&#x60; *********1112 &#x60;&#x60;&#x60;  This field is specific for the CC Reference Transaction payment method. It is an optional field that you can use to distinguish different CC Reference Transaction payment methods.  Though there are no special restrictions on the input string, it is highly recommended to specify a card number that is masked.  | [optional] 
**SecondTokenId** | **string** | A gateway unique identifier that replaces sensitive payment method data.   &#x60;secondTokenId&#x60; is conditionally required only when &#x60;tokenId&#x60; is being used to represent a gateway customer profile. &#x60;secondTokenId&#x60; is used in the CC Reference Transaction payment method.  | [optional] 
**TokenId** | **string** | A gateway unique identifier that replaces sensitive payment method data or represents a gateway&#39;s unique customer profile. &#x60;tokenId&#x60; is required for the CC Reference Transaction payment method.  When &#x60;tokenId&#x60; is used to represent a customer profile, &#x60;secondTokenId&#x60; is conditionally required for representing the underlying tokenized payment method.  When creating an ACH payment method, if you need to pass in tokenized information, use the &#x60;mandateId&#x60; instead of &#x60;tokenId&#x60; field.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

