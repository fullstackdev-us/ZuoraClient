# ZuoraClient.Model.GETAccountSummaryTypeTaxInfo
Container for tax exempt information, used to establish the tax exempt status of a customer account. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VATId** | **string** | EU Value Added Tax ID.  | [optional] 
**CompanyCode** | **string** | Unique code that identifies a company account in Avalara.  | [optional] 
**ExemptCertificateId** | **string** | ID of the customer tax exemption certificate.  | [optional] 
**ExemptCertificateType** | **string** | Type of tax exemption certificate that the customer holds.  | [optional] 
**ExemptDescription** | **string** | Description of the tax exemption certificate that the customer holds.  | [optional] 
**ExemptEffectiveDate** | **DateTime** | Date when the customer tax exemption starts.  | [optional] 
**ExemptEntityUseCode** | **string** | A unique entity use code to apply exemptions in Avalara AvaTax.  This account-level field is required only when you choose Avalara as your tax engine. See [Exempt Transactions](https://developer.avalara.com/avatax/handling-tax-exempt-customers/)for more details.  | [optional] 
**ExemptExpirationDate** | **DateTime** | Date when the customer tax exemption expires.  | [optional] 
**ExemptIssuingJurisdiction** | **string** | Jurisdiction in which the customer tax exemption certificate was issued.  | [optional] 
**ExemptStatus** | **string** | Status of the account tax exemption.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

