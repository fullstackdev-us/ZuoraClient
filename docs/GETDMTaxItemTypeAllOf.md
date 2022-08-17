# ZuoraClient.Model.GETDMTaxItemTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AppliedAmount** | **double** | The applied amount of the taxation item.  | [optional] 
**CreditAmount** | **double** | The amount of credit memos applied to the debit memo.   | [optional] 
**ExemptAmount** | **double** | The calculated tax amount excluded due to the exemption.  | [optional] 
**FinanceInformation** | [**GETDMTaxItemTypeAllOfFinanceInformation**](GETDMTaxItemTypeAllOfFinanceInformation.md) |  | [optional] 
**Id** | **string** | The ID of the taxation item.  | [optional] 
**Jurisdiction** | **string** | The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city.  | [optional] 
**LocationCode** | **string** | The identifier for the location based on the value of the &#x60;taxCode&#x60; field.  | [optional] 
**Name** | **string** | The name of the taxation item.  | [optional] 
**PaymentAmount** | **double** | The amount of payments applied to the debit memo.   | [optional] 
**RefundAmount** | **double** | The amount of the refund on the taxation item.  | [optional] 
**SourceTaxItemId** | **string** | The ID of the source taxation item.  | [optional] 
**TaxAmount** | **double** | The amount of taxation.  | [optional] 
**TaxCode** | **string** | The tax code identifies which tax rules and tax rates to apply to a specific debit memo.  | [optional] 
**TaxCodeDescription** | **string** | The description of the tax code.  | [optional] 
**TaxDate** | **DateTime** | The date that the tax is applied to the debit memo, in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**TaxRate** | **double** | The tax rate applied to the debit memo.  | [optional] 
**TaxRateDescription** | **string** | The description of the tax rate.  | [optional] 
**TaxRateType** | **string** | The type of the tax rate.  | [optional] 
**UnappliedAmount** | **double** | The unapplied amount of the taxation item.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

