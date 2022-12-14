# ZuoraClient.Model.POSTRevenueScheduleByChargeType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **decimal** | The revenue schedule amount, which is the sum of all revenue items. This field cannot be null and must be formatted based on the currency, such as &#x60;JPY 30&#x60; or &#x60;USD 30.15&#x60;. Test out the currency to ensure you are using the proper formatting otherwise, the response will fail and this error message is returned: &#x60;Allocation amount with wrong decimal places.&#x60;  | 
**DeferredRevenueAccountingCode** | **string** | The accounting code for deferred revenue, such as Monthly Recurring Liability. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, this value is ignored.  | [optional] 
**DeferredRevenueAccountingCodeType** | **string** | The type of the deferred revenue accounting code, such as Deferred Revenue. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, this value is ignored.  | [optional] 
**Notes** | **string** | Additional information about this record.  Character Limit: 2,000  | [optional] 
**OverrideChargeAccountingCodes** | **bool** | When overriding accounting codes from a charge, &#x60;recognizedRevenueAccountingCode&#x60; and &#x60;deferredRevenue AccountingCode&#x60; must be in the request body and can have the empty value.  | [optional] [default to false]
**RecognizedRevenueAccountingCode** | **string** | The accounting code for recognized revenue, such as Monthly Recurring Charges or Overage Charges. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, the value is ignored.  | [optional] 
**RecognizedRevenueAccountingCodeType** | **string** | The type of the recognized revenue accounting code, such as Sales Revenue or Sales Discount. Required only when &#x60;overrideChargeAccountingCodes&#x60; is &#x60;true&#x60;. Otherwise, this value is ignored.  | [optional] 
**ReferenceId** | **string** | Reference ID is used only in the custom unlimited rule to create a revenue schedule. In this scenario, the revenue schedule is not linked to an invoice item or invoice item adjustment.  Character Limit: 100  | [optional] 
**RevenueDistributions** | [**List&lt;POSTDistributionItemType&gt;**](POSTDistributionItemType.md) | An array of revenue distributions. Represents how you want to distribute revenue for this revenue schedule. You can distribute revenue into a maximum of 250 accounting periods with one revenue schedule.  The sum of the newAmount fields must be equal to the amount field.  | [optional] 
**RevenueEvent** | [**POSTRevenueScheduleByChargeTypeRevenueEvent**](POSTRevenueScheduleByChargeTypeRevenueEvent.md) |  | [optional] 
**RevenueScheduleDate** | **DateTime** | The effective date of the revenue schedule. For example, the revenue schedule date for bookings-based revenue recognition is typically set to the order date or contract date.  The date cannot be in a closed accounting period. The date must be in &#x60;yyyy-mm-dd&#x60; format.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

