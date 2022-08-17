# ZuoraClient.Model.GETDebitMemoItemTypewithSuccess

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the debit memo item. For tax-inclusive debit memo items, the amount indicates the debit memo item amount including tax. For tax-exclusive debit memo items, the amount indicates the debit memo item amount excluding tax.  | [optional] 
**AmountWithoutTax** | **double** | The debit memo item amount excluding tax.  | [optional] 
**AppliedToItemId** | **string** | The parent debit memo item that this debit memo items is applied to if this item is discount.  | [optional] 
**Balance** | **double** | The balance of the debit memo item.  | [optional] 
**BeAppliedAmount** | **double** | The applied amount of the debit memo item.  | [optional] 
**Comment** | **string** | Comments about the debit memo item.  **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the debit memo item.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the debit memo item was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10.  | [optional] 
**Description** | **string** | The description of the debit memo item.  **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude the debit memo item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**FinanceInformation** | [**GETDebitMemoItemTypeAllOfFinanceInformation**](GETDebitMemoItemTypeAllOfFinanceInformation.md) |  | [optional] 
**Id** | **string** | The ID of the debit memo item.  | [optional] 
**ProcessingType** | **string** | The kind of the charge for the debit memo item. Its possible values are &#x60;Charge&#x60; and &#x60;Discount&#x60;.   | [optional] 
**Quantity** | **double** | The number of units for the debit memo item.  | [optional] 
**ServiceEndDate** | **DateTime** | The end date of the service period associated with this debit memo item. Service ends one second before the date specified in this field.  | [optional] 
**ServiceStartDate** | **DateTime** | The start date of the service period associated with this debit memo item. If the associated charge is a one-time fee, this date is the date of that charge.  | [optional] 
**Sku** | **string** | The SKU for the product associated with the debit memo item.  | [optional] 
**SkuName** | **string** | The name of the SKU.  | [optional] 
**SourceItemId** | **string** | The ID of the source item.  | [optional] 
**SourceItemType** | **string** | The type of the source item.  | [optional] 
**SubscriptionId** | **string** | The ID of the subscription associated with the debit memo item.  | [optional] 
**TaxItems** | [**List&lt;GETDMTaxItemType&gt;**](GETDMTaxItemType.md) | Container for the taxation items of the debit memo item.   **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;239.0&#x60; or later.  | [optional] 
**TaxMode** | **string** | The tax mode of the debit memo item, indicating whether the amount of the debit memo item includes tax.  | [optional] 
**TaxationItems** | [**GETDebitMemoItemTypewithSuccessAllOfTaxationItems**](GETDebitMemoItemTypewithSuccessAllOfTaxationItems.md) |  | [optional] 
**UnitOfMeasure** | **string** | The units to measure usage.  | [optional] 
**UnitPrice** | **double** | The per-unit price of the debit memo item.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the debit memo item.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the debit memo item was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-02 15:36:10.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

