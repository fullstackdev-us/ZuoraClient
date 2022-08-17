# ZuoraClient.Model.AccountCreditCardHolder
Information about the cardholder of a credit card payment method associated with an account. If you do not provide information about the cardholder, Zuora uses the account's bill-to contact. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AddressLine1** | **string** | First line of the cardholder&#39;s address.  | [optional] 
**AddressLine2** | **string** | Second line of the cardholder&#39;s address.  | [optional] 
**CardHolderName** | **string** | Full name of the cardholder as it appears on the card. For example, \&quot;John J Smith\&quot;.  | [optional] 
**City** | **string** | City of the cardholder&#39;s address.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.  | [optional] 
**Country** | **string** | Country of the cardholder&#39;s address. The value of this field must be a valid country name or abbreviation.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.  | [optional] 
**Email** | **string** | Email address of the cardholder.  | [optional] 
**Phone** | **string** | Phone number of the cardholder.  | [optional] 
**State** | **string** | State or province of the cardholder&#39;s address.  | [optional] 
**ZipCode** | **string** | ZIP code or other postal code of the cardholder&#39;s address.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

