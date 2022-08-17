# ZuoraClient.Model.GETRsRevenueItemTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingPeriodEndDate** | **DateTime** | The accounting period end date. The accounting period end date of the open-ended accounting period is null.  | [optional] 
**AccountingPeriodName** | **string** | The name of the accounting period. The open-ended accounting period is named &#x60;Open-Ended&#x60;.  | [optional] 
**AccountingPeriodStartDate** | **DateTime** | The accounting period start date.  | [optional] 
**Amount** | **decimal** | The amount of the revenue item.  | [optional] 
**Currency** | **string** | The type of currency used.  | [optional] 
**DeferredRevenueAccountingCode** | **string** | The accounting code for deferred revenue, such as Monthly Recurring Liability. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, this value is ignored.  | [optional] 
**DeferredRevenueAccountingCodeType** | **string** | The type of the deferred revenue accounting code, such as Deferred Revenue. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, this value is ignored.  | [optional] 
**IsAccountingPeriodClosed** | **bool** | Indicates if the accounting period is closed or open.  | [optional] 
**RecognizedRevenueAccountingCode** | **string** | The accounting code for recognized revenue, such as Monthly Recurring Charges or Overage Charges. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, the value is ignored.  | [optional] 
**RecognizedRevenueAccountingCodeType** | **string** | The type of the recognized revenue accounting code, such as Sales Revenue or Sales Discount. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, this value is ignored.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

