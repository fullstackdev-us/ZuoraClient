# ZuoraClient.Model.GETTierType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EndingUnit** | **decimal** | Decimal defining end of tier range.  | [optional] 
**Price** | **decimal** | The decimal value of the tiered charge model. If the charge model is not a tiered type then this price field will be null and the &#x60;price&#x60; field directly under the &#x60;productRatePlanCharges&#x60; applies.  | [optional] 
**PriceFormat** | **string** | Tier price format. Allowed values: &#x60;flat fee&#x60;, &#x60;per unit&#x60;.  | [optional] 
**StartingUnit** | **decimal** | Decimal defining start of tier range.  | [optional] 
**Tier** | **long** | Unique number of the tier.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

