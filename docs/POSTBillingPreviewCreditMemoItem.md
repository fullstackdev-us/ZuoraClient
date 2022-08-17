# ZuoraClient.Model.POSTBillingPreviewCreditMemoItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the credit memo item. For tax-inclusive credit memo items, the amount indicates the credit memo item amount including tax. For tax-exclusive credit memo items, the amount indicates the credit memo item amount excluding tax  | [optional] 
**AmountWithoutTax** | **double** | The credit memo item amount excluding tax.  | [optional] 
**AppliedToItemId** | **string** | The unique ID of the credit memo item that the discount charge is applied to.  | [optional] 
**ChargeDate** | **DateTime** | The date when the credit memo item is created.  | [optional] 
**ChargeNumber** | **string** | Number of the charge.  | [optional] 
**ChargeType** | **string** | The type of charge.   Possible values are &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, and &#x60;Usage&#x60;.  | [optional] 
**Comment** | **string** | Comment of the credit memo item.  | [optional] 
**Id** | **string** | Credit memo item id.  | [optional] 
**ProcessingType** | **string** | Identifies the kind of charge.   Possible values: * charge * discount * prepayment * tax  | [optional] 
**Quantity** | **decimal** | Quantity of this item, in the configured unit of measure for the charge.  | [optional] 
**RatePlanChargeId** | **string** | Id of the rate plan charge associated with this item.  | [optional] 
**ServiceEndDate** | **DateTime** | End date of the service period for this item, i.e., the last day of the service period, in yyyy-mm-dd format.  | [optional] 
**ServiceStartDate** | **DateTime** | Start date of the service period for this item, in yyyy-mm-dd format. If the charge is a one-time fee, this is the date of that charge.  | [optional] 
**Sku** | **string** | Unique SKU for the product associated with this item.  | [optional] 
**SkuName** | **string** | Name of the unique SKU for the product associated with this item.  | [optional] 
**SubscriptionId** | **string** | ID of the subscription associated with this item.  | [optional] 
**SubscriptionNumber** | **string** | Name of the subscription associated with this item.  | [optional] 
**UnitOfMeasure** | **string** | Unit used to measure consumption.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

