# ZuoraClient.Model.POSTPaymentMethodType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountKey** | **string** | ID of the customer account. To create an orphan payment method that is not associated with any customer account, you do not need to specify this field during creation. However, you must associate the orphan payment method with a customer account within 10 days. Otherwise, this orphan payment method will be deleted. | [optional] 
**CardHolderInfo** | [**CreatePaymentMethodCardholderInfo**](CreatePaymentMethodCardholderInfo.md) |  | [optional] 
**CreditCardNumber** | **string** | Credit card number, a string of up to 16 characters. This field can only be set when creating a new payment method; it cannot be queried or updated.  | 
**CreditCardType** | **string** | The type of the credit card.  Possible values  include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways).  | 
**DefaultPaymentMethod** | **bool** | Specify true to make this card the default payment method; otherwise, omit this parameter to keep the current default payment method.  | [optional] 
**ExpirationMonth** | **int** | One or two digits expiration month (1-12).  | 
**ExpirationYear** | **int** | Four-digit expiration year.  | 
**GatewayOptions** | [**CreatePaymentMethodCommonGatewayOptions**](CreatePaymentMethodCommonGatewayOptions.md) |  | [optional] 
**MitConsentAgreementRef** | **string** | Specifies your reference for the stored credential consent agreement that you have established with the customer. Only applicable if you set the &#x60;mitProfileAction&#x60; field.  | [optional] 
**MitConsentAgreementSrc** | **string** | Required if you set the &#x60;mitProfileAction&#x60; field.  | [optional] 
**MitNetworkTransactionId** | **string** | Specifies the ID of a network transaction. Only applicable if you set the &#x60;mitProfileAction&#x60; field to &#x60;Persist&#x60;.  | [optional] 
**MitProfileAction** | **string** | If you set this field, Zuora creates a stored credential profile within the payment method.  * &#x60;Activate&#x60; - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;.  | [optional] 
**MitProfileAgreedOn** | **DateTime** | The date on which the profile is agreed. The date format is &#x60;yyyy-mm-dd&#x60;.    | [optional] 
**MitProfileType** | **string** | Required if you set the &#x60;mitProfileAction&#x60; field. Indicates the type of the stored credential profile to process recurring or unsecheduled transactions.  | [optional] 
**NumConsecutiveFailures** | **int** | The number of consecutive failed payments for this payment method. It is reset to &#x60;0&#x60; upon successful payment.   | [optional] 
**SecurityCode** | **string** | The CVV or CVV2 security code for the credit card or debit card. Only required if changing expirationMonth, expirationYear, or cardHolderName. To ensure PCI compliance, this value isn&#39;t stored and can&#39;t be queried.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

