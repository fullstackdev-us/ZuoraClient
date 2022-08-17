# ZuoraClient.Model.PostTaxationItemType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExemptAmount** | **decimal** | The calculated tax amount excluded due to the exemption.  | [optional] 
**Jurisdiction** | **string** | The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city.  | [optional] 
**LocationCode** | **string** | The identifier for the location based on the value of the &#x60;taxCode&#x60; field.  | [optional] 
**Name** | **string** | The name of taxation.  | 
**TaxAmount** | **decimal** | The amount of the taxation item in the invoice item.  | 
**TaxCode** | **string** | The tax code identifies which tax rules and tax rates to apply to a specific invoice item.  | 
**TaxCodeDescription** | **string** | The description of the tax code.  | [optional] 
**TaxDate** | **DateTime** | The date that the tax is applied to the invoice item, in &#x60;yyyy-mm-dd&#x60; format.  | 
**TaxMode** | **string** | The tax mode of the invoice item, indicating whether the amount of the invoice item includes tax.  | 
**TaxRate** | **decimal** | The tax rate applied to the invoice item.  | 
**TaxRateDescription** | **string** | The description of the tax rate.  | [optional] 
**TaxRateType** | **string** | The type of the tax rate applied to the invoice item.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

