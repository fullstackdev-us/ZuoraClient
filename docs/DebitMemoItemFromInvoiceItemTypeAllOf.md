# ZuoraClient.Model.DebitMemoItemFromInvoiceItemTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the debit memo item.  | 
**Comment** | **string** | Comments about the debit memo item. **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | [optional] 
**Description** | **string** | The description of the debit memo item. **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | [optional] 
**FinanceInformation** | [**DebitMemoItemFromInvoiceItemTypeAllOfFinanceInformation**](DebitMemoItemFromInvoiceItemTypeAllOfFinanceInformation.md) |  | [optional] 
**InvoiceItemId** | **string** | The ID of the invoice item.  | [optional] 
**Quantity** | **double** | The number of units for the debit memo item.  | [optional] 
**ServiceEndDate** | **DateTime** | The service end date of the debit memo item.  | [optional] 
**ServiceStartDate** | **DateTime** | The service start date of the debit memo item.   | [optional] 
**SkuName** | **string** | The name of the charge associated with the invoice.  | 
**TaxItems** | [**List&lt;DebitMemoTaxItemFromInvoiceTaxItemType&gt;**](DebitMemoTaxItemFromInvoiceTaxItemType.md) | Container for taxation items.  | [optional] 
**TaxMode** | **string** | The tax mode of the debit memo item, indicating whether the amount of the debit memo item includes tax.  **Note**: You can set this field to &#x60;TaxInclusive&#x60; only if the &#x60;taxAutoCalculation&#x60; field is set to &#x60;true&#x60;.  If you set &#x60;taxMode&#x60; to &#x60;TaxInclusive&#x60;, you cannot input tax amounts for debit memo items. The corresponding invoice item must use the same tax engine as the debit memo item to calculate tax amounts.  | [optional] [default to TaxModeEnum.TaxExclusive]
**UnitOfMeasure** | **string** | The definable unit that you measure when determining charges.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

