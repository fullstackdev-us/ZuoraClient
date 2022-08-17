# ZuoraClient.Model.PUTDebitMemoItemTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the debit memo item. For tax-inclusive debit memo items, the amount indicates the debit memo item amount including tax. For tax-exclusive debit memo items, the amount indicates the debit memo item amount excluding tax.  | [optional] 
**Comment** | **string** | Comments about the debit memo item.  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude the debit memo item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.              | [optional] [default to false]
**FinanceInformation** | [**DebitMemoItemFromInvoiceItemTypeAllOfFinanceInformation**](DebitMemoItemFromInvoiceItemTypeAllOfFinanceInformation.md) |  | [optional] 
**Id** | **string** | The ID of the debit memo item.  | 
**Quantity** | **double** | The number of units for the debit memo item.  | [optional] 
**ServiceEndDate** | **DateTime** | The service end date of the debit memo item.  | [optional] 
**ServiceStartDate** | **DateTime** | The service start date of the debit memo item.   | [optional] 
**SkuName** | **string** | The name of the SKU.  | [optional] 
**TaxItems** | [**List&lt;PutDebitMemoTaxItemType&gt;**](PutDebitMemoTaxItemType.md) | Container for debit memo taxation items.  | [optional] 
**UnitOfMeasure** | **string** | The definable unit that you measure when determining charges.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

