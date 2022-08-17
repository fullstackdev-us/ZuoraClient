# ZuoraClient.Model.ChargeOverrideBilling
Billing information about the charge. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BillCycleDay** | **int** | Day of the month that each billing period begins on. Only applicable if the value of the &#x60;billCycleType&#x60; field is &#x60;SpecificDayofMonth&#x60;.  | [optional] 
**BillCycleType** | **string** | Specifies how Zuora determines the day that each billing period begins on.    * &#x60;DefaultFromCustomer&#x60; - Each billing period begins on the bill cycle day of the account that owns the subscription.   * &#x60;SpecificDayofMonth&#x60; - Use the &#x60;billCycleDay&#x60; field to specify the day of the month that each billing period begins on.   * &#x60;SubscriptionStartDay&#x60; - Each billing period begins on the same day of the month as the start date of the subscription.   * &#x60;ChargeTriggerDay&#x60; - Each billing period begins on the same day of the month as the date when the charge becomes active.   * &#x60;SpecificDayofWeek&#x60; - Use the &#x60;weeklyBillCycleDay&#x60; field to specify the day of the week that each billing period begins on.  | [optional] 
**BillingPeriod** | **string** | Billing frequency of the charge. The value of this field controls the duration of each billing period.  If the value of this field is &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;, use the &#x60;specificBillingPeriod&#x60; field to specify the duration of each billing period.  | [optional] 
**BillingPeriodAlignment** | **string** | Specifies how Zuora determines when to start new billing periods. You can use this field to align the billing periods of different charges.  * &#x60;AlignToCharge&#x60; - Zuora starts a new billing period on the first billing day that falls on or after the date when the charge becomes active. * &#x60;AlignToSubscriptionStart&#x60; - Zuora starts a new billing period on the first billing day that falls on or after the start date of the subscription. * &#x60;AlignToTermStart&#x60; - For each term of the subscription, Zuora starts a new billing period on the first billing day that falls on or after the start date of the term.  See the &#x60;billCycleType&#x60; field for information about how Zuora determines the billing day.  | [optional] 
**BillingTiming** | **string** | Specifies whether to invoice for a billing period on the first day of the billing period (billing in advance) or the first day of the next billing period (billing in arrears).  | [optional] 
**SpecificBillingPeriod** | **int** | Duration of each billing period in months or weeks, depending on the value of the &#x60;billingPeriod&#x60; field. Only applicable if the value of the &#x60;billingPeriod&#x60; field is &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;.  | [optional] 
**WeeklyBillCycleDay** | **string** | Day of the week that each billing period begins on. Only applicable if the value of the &#x60;billCycleType&#x60; field is &#x60;SpecificDayofWeek&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

