# ZuoraClient.Model.PutDebitMemoTaxItemType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the taxation item in the debit memo item.  | [optional] 
**FinanceInformation** | [**PutDebitMemoTaxItemTypeAllOfFinanceInformation**](PutDebitMemoTaxItemTypeAllOfFinanceInformation.md) |  | [optional] 
**Id** | **string** | The ID of the taxation item in the debit memo item.  | 
**Jurisdiction** | **string** | The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city.  | [optional] 
**LocationCode** | **string** | The identifier for the location based on the value of the &#x60;taxCode&#x60; field.  | [optional] 
**TaxCode** | **string** | The tax code identifies which tax rules and tax rates to apply to a specific debit memo.  | [optional] 
**TaxCodeDescription** | **string** | The description of the tax code.  | [optional] 
**TaxDate** | **DateTime** | The date that the tax is applied to the debit memo, in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**TaxExemptAmount** | **double** | The calculated tax amount excluded due to the exemption.  | [optional] 
**TaxName** | **string** | The name of taxation.  | [optional] 
**TaxRate** | **double** | The tax rate applied to the debit memo.  | [optional] 
**TaxRateDescription** | **string** | The description of the tax rate.  | [optional] 
**TaxRateType** | **string** | The type of the tax rate applied to the debit memo.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

