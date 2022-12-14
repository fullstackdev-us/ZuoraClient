# ZuoraClient.Model.InvoiceItemAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingCode** | **string** | The accounting code associated with the invoice item. | [optional] 
**AdjustmentLiabilityAccountingCode** | **string** | The accounting code for adjustment liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**AdjustmentRevenueAccountingCode** | **string** | The accounting code for adjustment revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**AppliedToItemId** | **string** | The unique ID of the invoice item that the discount charge is applied to. | [optional] 
**AvailableToCreditAmount** | **decimal** | The amount of the invoice item that is available to credit.          | [optional] 
**Balance** | **decimal** | The balance of the invoice item. | [optional] 
**BookingReference** | **string** | The booking reference of the invoice item.  | [optional] 
**ChargeAmount** | **decimal** | The amount of the charge.   This amount does not include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive.  | [optional] 
**ChargeDescription** | **string** | The description of the charge. | [optional] 
**ChargeId** | **string** | The unique ID of the charge. | [optional] 
**ChargeName** | **string** | The name of the charge. | [optional] 
**ContractAssetAccountingCode** | **string** | The accounting code for contract asset.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**ContractLiabilityAccountingCode** | **string** | The accounting code for contract liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**ContractRecognizedRevenueAccountingCode** | **string** | The accounting code for contract recognized revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**DeferredRevenueAccountingCode** | **string** | The deferred revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled.  | [optional] 
**Description** | **string** | The description of the invoice item. | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude the invoice item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**Id** | **string** | Item ID. | [optional] 
**ItemType** | **string** | The type of the invoice item.  | [optional] 
**ProductName** | **string** | Name of the product associated with this item. | [optional] 
**ProductRatePlanChargeId** | **string** | The ID of the product rate plan charge that the invoice item is created from.  | [optional] 
**PurchaseOrderNumber** | **string** | The purchase order number associated with the invoice item.  | [optional] 
**Quantity** | **decimal** | The quantity of this item, in the configured unit of measure for the charge. | [optional] 
**RecognizedRevenueAccountingCode** | **string** | The recognized revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled.  | [optional] 
**RevRecCode** | **string** | The revenue recognition code.  | [optional] 
**RevRecTriggerCondition** | **string** | The date when revenue recognition is triggered.  | [optional] 
**RevenueRecognitionRuleName** | **string** | The tevenue recognition rule of the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled.  | [optional] 
**ServiceEndDate** | **DateTime** | The end date of the service period for this item, i.e., the last day of the service period, as _yyyy-mm-dd_. | [optional] 
**ServiceStartDate** | **DateTime** | The start date of the service period for this item, as _yyyy-mm-dd_. For a one-time fee item, the date of the charge. | [optional] 
**Sku** | **string** | The SKU of the invoice item.  | [optional] 
**SourceItemType** | **string** | The type of the source item.  | [optional] 
**SubscriptionId** | **string** | The ID of the subscription for this item. | [optional] 
**SubscriptionName** | **string** | The name of the subscription for this item. | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully. | [optional] 
**TaxAmount** | **decimal** | Tax applied to the charge. | [optional] 
**TaxCode** | **string** | The tax code of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented.  | [optional] 
**TaxMode** | **string** | The tax mode of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented.  | [optional] 
**TaxationItems** | [**InvoiceItemAllOfTaxationItems**](InvoiceItemAllOfTaxationItems.md) |  | [optional] 
**UnbilledReceivablesAccountingCode** | **string** | The accounting code for unbilled receivables.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**UnitOfMeasure** | **string** | Unit used to measure consumption. | [optional] 
**UnitPrice** | **double** | The per-unit price of the invoice item. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

