# ZuoraClient.Model.DiscountPricingUpdate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ApplyDiscountTo** | **string** | Specifies which type of charge the discount charge applies to.  | [optional] 
**DiscountLevel** | **string** | Application scope of the discount charge. For example, if the value of this field is &#x60;subscription&#x60; and the value of the &#x60;applyDiscountTo&#x60; field is &#x60;RECURRING&#x60;, the discount charge applies to all recurring charges in the same subscription as the discount charge.  | [optional] 
**DiscountPercentage** | **decimal** | The amount of the discount as a percentage. This field is only used for percentage discounts.  | [optional] 
**PriceChangeOption** | **string** | Specifies how Zuora changes the price of the charge each time the subscription renews.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

