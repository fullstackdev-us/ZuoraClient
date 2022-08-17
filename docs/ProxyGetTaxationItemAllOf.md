# ZuoraClient.Model.ProxyGetTaxationItemAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingCode** | **string** |  The Chart of Accounts  | [optional] 
**CreatedById** | **string** |  The ID of the user who created the taxation item. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date when the payment was created in the Zuora system. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**ExemptAmount** | **double** |  The calculated tax amount excluded due to the exemption. **Character limit**: 16 **Values**: a decimal value  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**InvoiceItemId** | **string** |  The ID of the specific invoice item that the taxation information applies to. **Character limit**: 32 **Values**: a valid invoice item ID  | [optional] 
**Jurisdiction** | **string** |  The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city. **Character limit**: 32 **Values**: a string of 32 characterrs or fewer  | [optional] 
**LocationCode** | **string** |  The identifier for the location based on the value of the &#x60;TaxCode&#x60; field. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**Name** | **string** |  The name of the tax rate, such as sales tax or GST. This name is displayed on invoices. **Character limit**: 128 **Values**: a string of 128 characters or fewer  | [optional] 
**TaxAmount** | **double** |  The amount of the tax applied to the charge. **Character limit**: 16 **Values**: a decimal value  | [optional] 
**TaxCode** | **string** |  The tax code identifies which tax rules and tax rates to apply to a specific charge. **Character limit**: 32 **Values**: a string of 32 characters or fewer  | [optional] 
**TaxCodeDescription** | **string** |  The description for the tax code. **Character limit**: 255 **Values**: a string of 255 characters or fewer  | [optional] 
**TaxDate** | **DateTime** |  The date that the tax is applied to the charge, in &#x60;yyyy-mm-dd&#x60; format. **Character limit**: 29  | [optional] 
**TaxRate** | **double** |  The tax rate applied to the charge. **Character limit**: 16 **Values**: a valid decimal value  | [optional] 
**TaxRateDescription** | **string** |  The description of the tax rate. **Character limit**: 255 **Values**: a string of 255 characters or fewer  | [optional] 
**TaxRateType** | **string** |  The type of the tax rate applied to the charge. **Character limit**: 10 **Values**: &#x60;Percentage&#x60;, &#x60;FlatFee&#x60;  | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the taxation item. **Character limit**: **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** | The date when the taxation item was last updated. **Character limit**: **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

