# ZuoraClient.Model.CreatePaymentMethodCreditCard

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CardHolderInfo** | [**CreatePaymentMethodCardholderInfo**](CreatePaymentMethodCardholderInfo.md) |  | [optional] 
**CardNumber** | **string** | Credit card number. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;.  | [optional] 
**CardType** | **string** | The type of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;.  Possible values include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways).  | [optional] 
**CheckDuplicated** | **bool** | Indicates whether the duplication check is performed when you create a new credit card payment method. The default value is &#x60;false&#x60;.  With this field set to &#x60;true&#x60;, Zuora will check all active payment methods associated with the same billing account to ensure that no duplicate credit card payment methods are created. An error is returned if a duplicate payment method is found.          The following fields are used for the duplication check:   * &#x60;cardHolderName&#x60;   * &#x60;expirationMonth&#x60;   * &#x60;expirationYear&#x60;   * &#x60;creditCardMaskNumber&#x60;. It is the masked credit card number generated by Zuora. For example:     &#x60;&#x60;&#x60;     ************1234     &#x60;&#x60;&#x60;  | [optional] 
**ExpirationMonth** | **int** | One or two digit expiration month (1-12) of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;.  | [optional] 
**ExpirationYear** | **int** | Four-digit expiration year of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;.  | [optional] 
**MitConsentAgreementRef** | **string** | Specifies your reference for the stored credential consent agreement that you have established with the customer. Only applicable if you set the &#x60;mitProfileAction&#x60; field.  | [optional] 
**MitConsentAgreementSrc** | **string** | Required if you set the &#x60;mitProfileAction&#x60; field.  | [optional] 
**MitNetworkTransactionId** | **string** | Specifies the ID of a network transaction. Only applicable if you set the &#x60;mitProfileAction&#x60; field to &#x60;Persist&#x60;.  | [optional] 
**MitProfileAction** | **string** | If you set this field, Zuora creates a stored credential profile within the payment method.  * &#x60;Activate&#x60; - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;.  | [optional] 
**MitProfileAgreedOn** | **DateTime** | The date on which the profile is agreed. The date format is &#x60;yyyy-mm-dd&#x60;.  | [optional] 
**MitProfileType** | **string** | Required if you set the &#x60;mitProfileAction&#x60; field. Indicates the type of the stored credential profile to process recurring or unsecheduled transactions.  | [optional] 
**SecurityCode** | **string** | CVV or CVV2 security code of the credit card.  To ensure PCI compliance, this value is not stored and cannot be queried.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

