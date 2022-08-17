# ZuoraClient.Model.PUTCreditMemoItemTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the credit memo item. For tax-inclusive credit memo items, the amount indicates the credit memo item amount including tax. For tax-exclusive credit memo items, the amount indicates the credit memo item amount excluding tax  | [optional] 
**Comment** | **string** | Comments about the credit memo item.  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude the credit memo item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] [default to false]
**FinanceInformation** | [**CreditMemoItemFromInvoiceItemTypeAllOfFinanceInformation**](CreditMemoItemFromInvoiceItemTypeAllOfFinanceInformation.md) |  | [optional] 
**Id** | **string** | The ID of the credit memo item.  | 
**Quantity** | **double** | The number of units for the credit memo item.  | [optional] 
**ServiceEndDate** | **DateTime** | The service end date of the credit memo item.  | [optional] 
**ServiceStartDate** | **DateTime** | The service start date of the credit memo item.  | [optional] 
**SkuName** | **string** | The name of the SKU.  | [optional] 
**TaxItems** | [**List&lt;PutCreditMemoTaxItemType&gt;**](PutCreditMemoTaxItemType.md) | Container for credit memo taxation items.  | [optional] 
**UnitOfMeasure** | **string** | The definable unit that you measure when determining charges.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

