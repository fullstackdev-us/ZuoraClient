# ZuoraClient.Model.GETCreditMemoItemTypewithSuccessAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the credit memo item. For tax-inclusive credit memo items, the amount indicates the credit memo item amount including tax. For tax-exclusive credit memo items, the amount indicates the credit memo item amount excluding tax.  | [optional] 
**AmountWithoutTax** | **double** | The credit memo item amount excluding tax.  | [optional] 
**AppliedAmount** | **double** | The applied amount of the credit memo item.  | [optional] 
**AppliedToItemId** | **string** | The unique ID of the credit memo item that the discount charge is applied to.  | [optional] 
**Comment** | **string** | Comments about the credit memo item.  **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the credit memo item.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the credit memo item was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10.  | [optional] 
**CreditFromItemId** | **string** | The ID of the credit from item.  | [optional] 
**CreditFromItemSource** | **string** | The type of the credit from item.  | [optional] 
**CreditTaxItems** | [**List&lt;GETCMTaxItemType&gt;**](GETCMTaxItemType.md) | Container for the taxation items of the credit memo item.   **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;239.0&#x60; or later.  | [optional] 
**Description** | **string** | The description of the credit memo item.  **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude the credit memo item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**FinanceInformation** | [**GETCreditMemoItemTypewithSuccessAllOfFinanceInformation**](GETCreditMemoItemTypewithSuccessAllOfFinanceInformation.md) |  | [optional] 
**Id** | **string** | The ID of the credit memo item.  | [optional] 
**ProcessingType** | **string** | The kind of the charge for the credit memo item. Its possible values are &#x60;Charge&#x60; and &#x60;Discount&#x60;.   | [optional] 
**Quantity** | **double** | The number of units for the credit memo item.  | [optional] 
**RefundAmount** | **double** | The amount of the refund on the credit memo item.  | [optional] 
**ServiceEndDate** | **DateTime** | The service end date of the credit memo item.   | [optional] 
**ServiceStartDate** | **DateTime** | The service start date of the credit memo item.  | [optional] 
**Sku** | **string** | The SKU for the product associated with the credit memo item.  | [optional] 
**SkuName** | **string** | The name of the SKU.  | [optional] 
**SourceItemId** | **string** | The ID of the source item.  - If the value of the &#x60;sourceItemType&#x60; field is &#x60;SubscriptionComponent&#x60; , the value of this field is the ID of the corresponding rate plan charge. - If the value of the &#x60;sourceItemType&#x60; field is &#x60;InvoiceDetail&#x60;, the value of this field is the ID of the corresponding invoice item. - If the value of the &#x60;sourceItemType&#x60; field is &#x60;ProductRatePlanCharge&#x60; , the value of this field is the ID of the corresponding product rate plan charge.  | [optional] 
**SourceItemType** | **string** | The type of the source item.  - If a credit memo is not created from an invoice or a product rate plan charge, the value of this field is &#x60;SubscriptionComponent&#x60;.  - If a credit memo is created from an invoice, the value of this field is &#x60;InvoiceDetail&#x60;. - If a credit memo is created from a product rate plan charge, the value of this field is &#x60;ProductRatePlanCharge&#x60;.                | [optional] 
**SubscriptionId** | **string** | The ID of the subscription associated with the credit memo item.  | [optional] 
**TaxMode** | **string** | The tax mode of the credit memo item, indicating whether the amount of the credit memo item includes tax.  | [optional] 
**TaxationItems** | [**GETCreditMemoItemTypeAllOfTaxationItems**](GETCreditMemoItemTypeAllOfTaxationItems.md) |  | [optional] 
**UnappliedAmount** | **double** | The unapplied amount of the credit memo item.  | [optional] 
**UnitOfMeasure** | **string** | The units to measure usage.  | [optional] 
**UnitPrice** | **double** | The per-unit price of the credit memo item.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the credit memo item.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the credit memo item was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-02 15:36:10.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

