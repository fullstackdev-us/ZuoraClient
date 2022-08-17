# ZuoraClient.Model.UsageTieredWithOveragePricingOverride
Pricing information about a usage charge that uses the \"tiered with overage\" charge model. In this charge model, the charge has cumulative pricing tiers that become effective as units are consumed. The charge also has a fixed price per unit consumed beyond the limit of the final tier. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PriceChangeOption** | **string** | Specifies how Zuora changes the price of the charge each time the subscription renews.  If the value of this field is &#x60;SpecificPercentageValue&#x60;, use the &#x60;priceIncreasePercentage&#x60; field to specify how much the price of the charge should change.  | [optional] 
**PriceIncreasePercentage** | **decimal** | Specifies the percentage by which the price of the charge should change each time the subscription renews. Only applicable if the value of the &#x60;priceChangeOption&#x60; field is &#x60;SpecificPercentageValue&#x60;.  | [optional] 
**NumberOfPeriods** | **int** | Number of periods that Zuora considers when calculating overage charges with overage smoothing.  | [optional] 
**OveragePrice** | **decimal** | Price per overage unit consumed.  | [optional] 
**OverageUnusedUnitsCreditOption** | **string** | Specifies whether to credit the customer for unused units.  If the value of this field is &#x60;CreditBySpecificRate&#x60;, use the &#x60;unusedUnitsCreditRates&#x60; field to specify the rate at which to credit the customer for unused units.  | [optional] 
**Tiers** | [**List&lt;ChargeTier&gt;**](ChargeTier.md) | List of cumulative pricing tiers in the charge.  | [optional] 
**UnusedUnitsCreditRates** | **decimal** | Per-unit rate at which to credit the customer for unused units. Only applicable if the value of the &#x60;overageUnusedUnitsCreditOption&#x60; field is &#x60;CreditBySpecificRate&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

