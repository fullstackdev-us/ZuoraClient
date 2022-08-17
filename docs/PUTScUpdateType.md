# ZuoraClient.Model.PUTScUpdateType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BillingPeriodAlignment** | **string** | Aligns charges within the same subscription if multiple charges begin on different dates.  Values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60;  Available for the following charge types:  * Recurring * Usage-based  | [optional] 
**ChargeModelConfiguration** | [**ChargeModelConfigurationType**](ChargeModelConfigurationType.md) |  | [optional] 
**Description** | **string** | Description of the charge.  | [optional] 
**IncludedUnits** | **decimal** | Specifies the number of units in the base set of units for this charge. Must be &gt;&#x3D;0.  Available for the following charge type for the Overage charge model: * Usage-based  | [optional] 
**OveragePrice** | **decimal** | Price for units over the allowed amount.   Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based  | [optional] 
**Price** | **decimal** | Price for units in the subscription rate plan.  Supports all charge types for the Flat Fee and Per Unit charge models  | [optional] 
**PriceChangeOption** | **string** | Applies an automatic price change when a termed subscription is renewed. The Billing Admin setting **Enable Automatic Price Change When Subscriptions are Renewed?** must be set to Yes to use this field.  Values:  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60;  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model.  | [optional] 
**PriceIncreasePercentage** | **decimal** | Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Required if you set the &#x60;PriceChangeOption&#x60; field to &#x60;SpecificPercentageValue&#x60;.  Decimal between &#x60;-100&#x60; and &#x60;100&#x60;.  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model.  | [optional] 
**Quantity** | **decimal** | Quantity of units; must be greater than zero.  | [optional] 
**RatePlanChargeId** | **string** | ID of a rate-plan charge for this subscription. It can be the latest version or any history version of ID.  | 
**Tiers** | [**List&lt;POSTTierType&gt;**](POSTTierType.md) | Container for Volume, Tiered or Tiered with Overage charge models. Supports the following charge types:  * One-time * Recurring * Usage-based  | [optional] 
**TriggerDate** | **DateTime** | Specifies when to start billing the customer for the charge. Required if the &#x60;triggerEvent&#x60; field is set to USD.  &#x60;triggerDate&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model  | [optional] 
**TriggerEvent** | **string** | Specifies when to start billing the customer for the charge.  Values:  * &#x60;UCE&#x60; * &#x60;USA&#x60; * &#x60;UCA&#x60; * &#x60;USD&#x60;  This is the date when charge changes in the REST request become effective.  &#x60;triggerEvent&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

