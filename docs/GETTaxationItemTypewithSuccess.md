# ZuoraClient.Model.GETTaxationItemTypewithSuccess

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedById** | **string** | The ID of the Zuora user who created the taxation item.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the taxation item was created in the Zuora system, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**ExemptAmount** | **double** | The calculated tax amount excluded due to the exemption.  | [optional] 
**FinanceInformation** | [**GETCMTaxItemTypeAllOfFinanceInformation**](GETCMTaxItemTypeAllOfFinanceInformation.md) |  | [optional] 
**Id** | **string** | The ID of the taxation item.  | [optional] 
**Jurisdiction** | **string** | The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city.  | [optional] 
**LocationCode** | **string** | The identifier for the location based on the value of the &#x60;taxCode&#x60; field.  | [optional] 
**MemoItemId** | **string** | The ID of the credit or debit memo associated with the taxation item.  | [optional] 
**Name** | **string** | The name of the taxation item.  | [optional] 
**SourceTaxItemId** | **string** | The ID of the taxation item of the invoice, which the credit or debit memo is created from.  | [optional] 
**TaxAmount** | **double** | The amount of the tax applied to the credit or debit memo.  | [optional] 
**TaxCode** | **string** | The tax code identifies which tax rules and tax rates to apply to a specific credit or debit memo.  | [optional] 
**TaxCodeDescription** | **string** | The description of the tax code.  | [optional] 
**TaxDate** | **DateTime** | The date when the tax is applied to the credit or debit memo.  | [optional] 
**TaxRate** | **double** | The tax rate applied to the credit or debit memo.  | [optional] 
**TaxRateDescription** | **string** | The description of the tax rate.  | [optional] 
**TaxRateType** | **string** | The type of the tax rate applied to the credit or debit memo.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the taxation item.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the taxation item was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

