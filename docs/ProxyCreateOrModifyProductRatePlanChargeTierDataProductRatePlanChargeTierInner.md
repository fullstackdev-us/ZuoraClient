# ZuoraClient.Model.ProxyCreateOrModifyProductRatePlanChargeTierDataProductRatePlanChargeTierInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Currency** | **string** | The code corresponding to the currency for the tier&#39;s price.  | [optional] 
**DiscountAmount** | **double** | The specific amount for a fixed discount. Required if the charge model of the product rate plan charge is &#x60;Discount-Fixed Amount&#x60;.  | [optional] 
**DiscountPercentage** | **double** | The percentage of discount for a percentage discount. Required if the charge model of the product rate plan charge is &#x60;Discount-Percentage&#x60;.  | [optional] 
**EndingUnit** | **double** | The end number of a range of units for the tier. Required if the charge model of the product rate plan charge is &#x60;Tiered Pricing&#x60; or &#x60;Tiered with Overage Pricing&#x60;.  | [optional] 
**IsOveragePrice** | **bool** | Indicates if the price is an overage price, which is the price when usage surpasses the last defined tier.  | [optional] 
**Price** | **double** | The price of the tier if the charge is a flat fee, or the price of each unit in the tier if the charge model is tiered pricing.  | [optional] 
**PriceFormat** | **string** | Indicates if pricing is a flat fee or is per unit. This field is for tiered and volume pricing models only.  | [optional] 
**StartingUnit** | **double** | The starting number of a range of units for the tier. Required if the charge model of the product rate plan charge is &#x60;Tiered Pricing&#x60; or &#x60;Tiered with Overage Pricing&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

