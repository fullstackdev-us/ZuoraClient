# ZuoraClient.Model.TaxInfo
Information about the tax exempt status of a customer account. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VATId** | **string** | EU Value Added Tax ID.  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  | [optional] 
**CompanyCode** | **string** | Unique code that identifies a company account in Avalara. Use this field to calculate taxes based on origin and sold-to addresses in Avalara.  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  | [optional] 
**ExemptCertificateId** | **string** | ID of the customer tax exemption certificate. Applicable if you use Zuora Tax or Connect tax engines.  | [optional] 
**ExemptCertificateType** | **string** | Type of tax exemption certificate that the customer holds. Applicable if you use Zuora Tax or Connect tax engines.  | [optional] 
**ExemptDescription** | **string** | Description of the tax exemption certificate that the customer holds. Applicable if you use Zuora Tax or Connect tax engines.  | [optional] 
**ExemptEffectiveDate** | **DateTime** | Date when the customer tax exemption starts, in YYYY-MM-DD format. Applicable if you use Zuora Tax or Connect tax engines.  | [optional] 
**ExemptExpirationDate** | **DateTime** | Date when the customer tax exemption expires, in YYYY-MM-DD format. Applicable if you use Zuora Tax or Connect tax engines.  | [optional] 
**ExemptIssuingJurisdiction** | **string** | Jurisdiction in which the customer tax exemption certificate was issued.  | [optional] 
**ExemptStatus** | **string** | Status of the account tax exemption. Applicable if you use Zuora Tax or Connect tax engines. Required if you use Zuora Tax.   | [optional] [default to ExemptStatusEnum.No]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

