# ZuoraClient.Model.PUTPaymentMethodTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AddressLine1** | **string** | First address line, 255 characters or less.  | [optional] 
**AddressLine2** | **string** | Second address line, 255 characters or less.  | [optional] 
**CardHolderName** | **string** | The full name as it appears on the card, e.g., \&quot;John J Smith\&quot;, 50 characters or less.  | [optional] 
**City** | **string** | City, 40 characters or less.  | [optional] 
**Country** | **string** | Country; must be a valid country name or abbreviation.  | [optional] 
**DefaultPaymentMethod** | **bool** | Specify \&quot;true\&quot; to make this card the default payment method; otherwise, omit this parameter to keep the current default payment method.  | [optional] 
**Email** | **string** | Card holder&#39;s email address, 80 characters or less.  | [optional] 
**ExpirationMonth** | **int** | One or two digit(s) expiration month (1-12).  | [optional] 
**ExpirationYear** | **int** | Four-digit expiration year.  | [optional] 
**GatewayOptions** | [**CreatePaymentMethodCommonGatewayOptions**](CreatePaymentMethodCommonGatewayOptions.md) |  | [optional] 
**NumConsecutiveFailures** | **int** | The number of consecutive failed payments for this payment method. It is reset to &#x60;0&#x60; upon successful payment.   | [optional] 
**Phone** | **string** | Phone number, 40 characters or less.  | [optional] 
**SecurityCode** | **string** | The CVV or CVV2 security code for the credit card or debit card. Only required if changing expirationMonth, expirationYear, or cardHolderName. To ensure PCI compliance, this value isn&#39;t stored and can&#39;t be queried.   | [optional] 
**State** | **string** | State; must be a valid state name or 2-character abbreviation.  | [optional] 
**ZipCode** | **string** | Zip code, 20 characters or less.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

