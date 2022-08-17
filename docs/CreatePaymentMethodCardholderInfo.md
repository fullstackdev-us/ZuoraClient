# ZuoraClient.Model.CreatePaymentMethodCardholderInfo
Container for cardholder information. This container field is required for credit card payment methods. The nested `cardHolderName` field is required. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AddressLine1** | **string** | First address line, 255 characters or less.  | [optional] 
**AddressLine2** | **string** | Second address line, 255 characters or less.  | [optional] 
**CardHolderName** | **string** | The card holder&#39;s full name as it appears on the card, e.g., \&quot;John J Smith\&quot;, 50 characters or less.  | 
**City** | **string** | City, 40 characters or less. It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.  | [optional] 
**Country** | **string** | Country, must be a valid country name or abbreviation. It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.  | [optional] 
**Email** | **string** | Card holder&#39;s email address, 80 characters or less.  | [optional] 
**Phone** | **string** | Phone number, 40 characters or less.  | [optional] 
**State** | **string** | State; must be a valid state name or 2-character abbreviation.  | [optional] 
**ZipCode** | **string** | Zip code, 20 characters or less.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

