# ZuoraClient.Model.GETPaymentMethodTypeCardHolderInfo
Container for the name and billing address for the card holder. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AddressLine1** | **string** | First address line, 255 characters or less.  | [optional] 
**AddressLine2** | **string** | Second address line, 255 characters or less.  | [optional] 
**CardHolderName** | **string** | The full name as it appears on the card, e.g., \&quot;John J Smith\&quot;, 50 characters or less.  | [optional] 
**City** | **string** | City, 40 characters or less.  | [optional] 
**Country** | **string** | Country, must be a valid country name or abbreviation. When creating a payment method through a translated UI or Payment Page, a country name in a translated language might be selected. Regardless of the country texts selected when creating the payment method, only the country name listed in [Country Names and Their ISO Standard 2- and 3-Digit Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) returns in this field. Internationalization is not supported for the API field value.  | [optional] 
**Email** | **string** | Card holder&#39;s email address, 80 characters or less.  | [optional] 
**Phone** | **string** | Phone number, 40 characters or less.  | [optional] 
**State** | **string** | State, must be a valid state name or 2-character abbreviation.  | [optional] 
**ZipCode** | **string** | Zip code, 20 characters or less.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

