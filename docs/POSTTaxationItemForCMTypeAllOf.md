# ZuoraClient.Model.POSTTaxationItemForCMTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExemptAmount** | **double** | The calculated tax amount excluded due to the exemption.  | [optional] 
**FinanceInformation** | [**POSTTaxationItemForCMTypeAllOfFinanceInformation**](POSTTaxationItemForCMTypeAllOfFinanceInformation.md) |  | [optional] 
**Jurisdiction** | **string** | The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city.  | 
**LocationCode** | **string** | The identifier for the location based on the value of the &#x60;taxCode&#x60; field.  | [optional] 
**MemoItemId** | **string** | The ID of the credit memo that the taxation item is created for.  | [optional] 
**Name** | **string** | The name of the taxation item.  | 
**SourceTaxItemId** | **string** | The ID of the taxation item of the invoice, which the credit memo is created from.   If you want to use this REST API to create taxation items for a credit memo created from an invoice, the taxation items of the invoice must be created or imported through the SOAP API call.  **Note:**    - This field is only used if the credit memo is created from an invoice.    - If you do not contain this field in the request body, Zuora will automatically set a value for the &#x60;sourceTaxItemId&#x60; field based on the tax location code, tax jurisdiction, and tax rate.  | [optional] 
**TaxAmount** | **double** | The amount of the tax applied to the credit memo.  | 
**TaxCode** | **string** | The tax code identifies which tax rules and tax rates to apply to a specific credit memo.  | [optional] 
**TaxCodeDescription** | **string** | The description of the tax code.  | [optional] 
**TaxDate** | **DateTime** | The date when the tax is applied to the credit memo.  | [optional] 
**TaxRate** | **double** | The tax rate applied to the credit memo.  | 
**TaxRateDescription** | **string** | The description of the tax rate.  | [optional] 
**TaxRateType** | **string** | The type of the tax rate applied to the credit memo.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

