# ZuoraClient.Model.InvoiceItems1

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingCode** | **string** | The accounting code associated with the invoice item.  | [optional] 
**AdjustmentLiabilityAccountingCode** | **string** | The accounting code for adjustment liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**AdjustmentRevenueAccountingCode** | **string** | The accounting code for adjustment revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**Amount** | **decimal** | The amount of the invoice item.   - For tax-inclusive invoice items, the amount indicates the invoice item amount including tax.  - For tax-exclusive invoice items, the amount indicates the invoice item amount excluding tax.  | 
**BookingReference** | **string** | The booking reference of the invoice item.  | [optional] 
**ChargeDate** | **DateTime** | The date when the invoice item is charged, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**ChargeName** | **string** | The name of the charge associated with the invoice item.   This field is required if the &#x60;productRatePlanChargeId&#x60; field is not specified in the request.  | [optional] 
**ContractAssetAccountingCode** | **string** | The accounting code for contract asset.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**ContractLiabilityAccountingCode** | **string** | The accounting code for contract liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**ContractRecognizedRevenueAccountingCode** | **string** | The accounting code for contract recognized revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**DeferredRevenueAccountingCode** | **string** | The accounting code for the deferred revenue, such as Monthly Recurring Liability.  **Note:** This field is only available if you have Zuora Finance enabled.  | [optional] 
**Description** | **string** | The description of the invoice item.  | [optional] 
**DiscountItems** | [**List&lt;PostDiscountItemType&gt;**](PostDiscountItemType.md) | Container for discount items. The maximum number of discount items is 10.  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude the invoice item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**ItemType** | **string** | The type of the invoice item.  | [optional] 
**ProductRatePlanChargeId** | **string** | The ID of the product rate plan charge that the invoice item is created from.  If you specify a value for the &#x60;productRatePlanChargeId&#x60; field in the request, Zuora directly copies the values of the following fields from the corresponding product rate plan charge, regardless of the values specified in the request body: - &#x60;chargeName&#x60; - &#x60;sku&#x60; - &#x60;uom&#x60; - &#x60;taxCode&#x60; - &#x60;taxMode&#x60; - &#x60;accountingCode&#x60; - &#x60;deferredRevenueAccountingCode&#x60;  - &#x60;recognizedRevenueAccountingCode&#x60;  | [optional] 
**PurchaseOrderNumber** | **string** | The purchase order number associated with the invoice item.  | [optional] 
**Quantity** | **decimal** | The number of units for the invoice item.  | [optional] [default to "1"]
**RecognizedRevenueAccountingCode** | **string** | The accounting code for the recognized revenue, such as Monthly Recurring Charges or Overage Charges.  **Note:** This field is only available if you have Zuora Finance enabled.  | [optional] 
**RevRecCode** | **string** | The revenue recognition code.  | [optional] 
**RevRecTriggerCondition** | **string** | The date when revenue recognition is triggered.  | [optional] 
**RevenueRecognitionRuleName** | **string** | The name of the revenue recognition rule governing the revenue schedule.  **Note:** This field is only available if you have Zuora Finance enabled.  | [optional] 
**ServiceEndDate** | **DateTime** | The service end date of the invoice item.  | [optional] 
**ServiceStartDate** | **DateTime** | The service start date of the invoice item.  | 
**Sku** | **string** | The SKU of the invoice item. The SKU of the invoice item must be different from the SKU of any existing product.  | [optional] 
**TaxCode** | **string** | The tax code identifies which tax rules and tax rates to apply to the invoice item.  **Note**: This field is only available only if you have Taxation enabled.  | [optional] 
**TaxItems** | [**List&lt;PostTaxationItemType&gt;**](PostTaxationItemType.md) | Container for taxation items. The maximum number of taxation items is 5.  | [optional] 
**TaxMode** | **string** | The tax mode of the invoice item, indicating whether the amount of the invoice item includes tax.  **Note**: This field is only available only if you have Taxation enabled.  | [optional] 
**UnbilledReceivablesAccountingCode** | **string** | The accounting code for unbilled receivables.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**UnitPrice** | **decimal** | The per-unit price of the invoice item.  | [optional] 
**Uom** | **string** | The unit of measure.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

