# ZuoraClient.Model.ProxyGetInvoiceItemAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingCode** | **string** |  The accounting code for the item&#39;s charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;RatePlanCharge.AccountingCode&#x60;  | [optional] 
**AppliedToInvoiceItemId** | **string** |  Associates a discount invoice item to a specific invoice item.  **Character limit**: 32  **Values**: inherited from &#x60;InvoiceItem.Id&#x60; for the invoice item that the discount charge is applied to  | [optional] 
**ChargeAmount** | **double** |  The amount being charged for the invoice item. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. **Character limit**: **Values**: automatically calculated from multiple fields in multiple objects  | [optional] 
**ChargeDate** | **DateTime** |  The date when the Invoice Item is created . **Character limit**: 29 **Values**: automatically generated  | [optional] 
**ChargeName** | **string** |  The name of the invoice item&#39;s charge. **Character limi**t: 50 **Values: **inherited from &#x60;RatePlanCharge.Name&#x60;  | [optional] 
**CreatedById** | **string** |  The user ID of the person who created the invoice item. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date the invoice item was created. **Character limit:** 29 **Values**: automatically generated  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** |  Whether excluding item from revenue accounting. The flag to exclude non-revenue related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting. **Note**: This field is only available if you have the RevPro Integration feature enabled. And you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;116&#x60; or later. Otherwise, an error occurs. **Character limit**: 8 **Values**: Default value is false, inherited from order line item.  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**InvoiceId** | **string** |  The ID of the invoice that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Invoice.Id&#x60;  | [optional] 
**ProcessingType** | **double** |  Identifies the kind of charge where 0 is a charge, 1 is a discount, 2 is a prepayment, and 3 is a tax. The returned value is text not decimal on data sources. **Character limit**: **Values: **  - 0: charge - 1: discount - 2: prepayment - 3: tax  | [optional] 
**ProductDescription** | **string** |  A description of the product associated with this invoice item.  **Character limit**: 500  **Values**: inherited from &#x60;Product.Description&#x60;  **Note**: This value changes if &#x60;Product.Description&#x60; is updated. The values of &#x60;UpdatedById&#x60; and &#x60;UpdatedDate&#x60; for the &#x60;InvoiceItem&#x60; do not change when &#x60;Product.Description&#x60; is updated.  | [optional] 
**ProductName** | **string** |  The name of the product associated with this invoice item.  **Character limit**: 255  **Values**: inherited from &#x60;Product.Name&#x60;  **Note**: This value changes if &#x60;Product.Name&#x60; is updated. The values of &#x60;UpdatedById&#x60; and &#x60;UpdatedDate&#x60; for the &#x60;InvoiceItem&#x60; do not change when &#x60;Product.Name&#x60; is updated.  | [optional] 
**Quantity** | **double** |  The number of units for this invoice item. **Values**: inherited from &#x60;RatePlanCharge.Quantity&#x60;  | [optional] 
**RatePlanChargeId** | **string** |  The ID of the rate plan charge that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60;  | [optional] 
**RevRecStartDate** | **DateTime** |  The date when revenue recognition is triggered. **Character limit**: 29 **Values**: generated from &#x60;InvoiceItem.RevRecTriggerCondition&#x60;  | [optional] 
**SKU** | **string** |  The unique SKU for the product associated with this invoice item. **Character limit**: 255 **Values**: inherited from &#x60;Product.SKU&#x60;  | [optional] 
**ServiceEndDate** | **DateTime** |  The end date of the service period associated with this invoice item. Service ends one second before the date in this value. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**ServiceStartDate** | **DateTime** |  The start date of the service period associated with this invoice item. If the associated charge is a one-time fee, then this date is the date of that charge. **Character limit:** 29 **Values**: automatically generated  | [optional] 
**SourceItemType** | **string** |  The type of the source item. **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;118&#x60; or later. Otherwise, an error occurs. **Character limit**: 16 **Values**: one of the following enum values:  -  SubscriptionComponent  -  Rounding  -  ProductRatePlanCharge  -  None  -  OrderLineItem  | [optional] 
**SubscriptionId** | **string** |  The ID of the subscription associated with the invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Subscription.Id&#x60;  | [optional] 
**TaxAmount** | **double** |  The amount of tax applied to the invoice item&#39;s charge. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object  | [optional] 
**TaxCode** | **string** |  Specifies the tax code for taxation rules. **Character limit**: 6 **Values**: inherited from &#x60;ProductRatePlanCharge.TaxCode&#x60;  | [optional] 
**TaxExemptAmount** | **double** |  The calculated tax amount excluded due to the exemption. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object  | [optional] 
**TaxMode** | **string** |  The tax mode of the invoice item. **Character limit**: 12 **Values**: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60;  | [optional] 
**UOM** | **string** |  Specifies the units to measure usage. **Character limit**: **Values**: inherited from &#x60;ProductRatePlanCharge.UOM&#x60;  | [optional] 
**UnitPrice** | **double** |  The per-unit price of the invoice item. **Character limit**: **Values**: calculated from multiple fields in ProductRatePlanCharge and ProductRatePlanChargeTier objets  | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the invoice item. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the invoice item was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

