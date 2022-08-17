# ZuoraClient.Model.POSTAccountTypeBillToContact
Container for bill-to contact information for this account. If you do not provide a sold-to contact, the bill-to contact is copied to sold-to contact. Once the sold-to contact is created, changes to billToContact will not affect soldToContact and vice versa. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Address1** | **string** | First address line, 255 characters or less.  | [optional] 
**Address2** | **string** | Second address line, 255 characters or less.  | [optional] 
**City** | **string** | City, 40 characters or less.  | [optional] 
**Country** | **string** | Country; must be a valid country name or abbreviation. If using Zuora Tax, you must specify a country in the sold-to contact to calculate tax. A bill-to contact may be used if no sold-to contact is provided.  | [optional] 
**County** | **string** | County; 32 characters or less. May optionally be used by Zuora Tax to calculate county tax.  | [optional] 
**Fax** | **string** | Fax phone number, 40 characters or less.  | [optional] 
**FirstName** | **string** | First name, 100 characters or less.  | 
**HomePhone** | **string** | Home phone number, 40 characters or less.  | [optional] 
**LastName** | **string** | Last name, 100 characters or less.  | 
**MobilePhone** | **string** | Mobile phone number, 40 characters or less.  | [optional] 
**Nickname** | **string** | Nickname for this contact  | [optional] 
**OtherPhone** | **string** | Other phone number, 40 characters or less.  | [optional] 
**OtherPhoneType** | **string** | Possible values are: &#x60;Work&#x60;, &#x60;Mobile&#x60;, &#x60;Home&#x60;, &#x60;Other&#x60;.  | [optional] 
**PersonalEmail** | **string** | Personal email address, 80 characters or less.  | [optional] 
**State** | **string** | State; must be a valid state or province name or 2-character abbreviation. If using Zuora Tax, be aware that Zuora tax requires a state (in the US) or province (in Canada) in this field for the sold-to contact to calculate tax, and that a bill-to contact may be used if no sold-to contact is provided.  | [optional] 
**TaxRegion** | **string** | If using Zuora Tax, a region string as optionally defined in your tax rules. Not required.  | [optional] 
**WorkEmail** | **string** | Work email address, 80 characters or less.  | [optional] 
**WorkPhone** | **string** | Work phone number, 40 characters or less.  | [optional] 
**ZipCode** | **string** | Zip code, 20 characters or less.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

