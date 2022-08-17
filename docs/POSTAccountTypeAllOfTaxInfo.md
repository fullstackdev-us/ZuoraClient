# ZuoraClient.Model.POSTAccountTypeAllOfTaxInfo
Container for tax exempt information, used to establish the tax exempt status of a customer account. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VATId** | **string** | EU Value Added Tax ID.   **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  | [optional] 
**CompanyCode** | **string** | Unique code that identifies a company account in Avalara. Use this field to calculate taxes based on origin and sold-to addresses in Avalara.  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).   | [optional] 
**ExemptCertificateId** | **string** | ID of the customer tax exemption certificate. Requires Zuora Tax.  | [optional] 
**ExemptCertificateType** | **string** | Type of tax exemption certificate that the customer holds. Requires Zuora Tax.  | [optional] 
**ExemptDescription** | **string** | Description of the tax exemption certificate that the customer holds. Requires Zuora Tax.  | [optional] 
**ExemptEffectiveDate** | **DateTime** | Date when the customer tax exemption starts. Requires Zuora Tax.  Format: &#x60;yyyy-mm-dd&#x60;. Defaults to the current date.  | [optional] 
**ExemptEntityUseCode** | **string** | A unique entity use code to apply exemptions in Avalara AvaTax.  This account-level field is required only when you choose Avalara as your tax engine. See [Exempt Transactions](https://developer.avalara.com/avatax/handling-tax-exempt-customers/)for more details.  | [optional] 
**ExemptExpirationDate** | **DateTime** | Date when the customer tax exemption expires. Requires Zuora Tax.  Format: &#x60;yyyy-mm-dd&#x60;. Defaults to the current date.  | [optional] 
**ExemptIssuingJurisdiction** | **string** | Jurisdiction in which the customer tax exemption certificate was issued.  | [optional] 
**ExemptStatus** | **string** | Status of the account tax exemption. Requires Zuora Tax.  Required if you use Zuora Tax. This field is unavailable if Zuora Tax is not used.  Values: &#x60;Yes&#x60;, &#x60;No&#x60;(default), &#x60;pendingVerification&#x60;. Note that the value will be set to &#x60;No&#x60; if no input.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

