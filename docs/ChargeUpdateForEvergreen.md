# ZuoraClient.Model.ChargeUpdateForEvergreen
The JSON object containing the information for a charge update in the 'UpdateProduct' type order action.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Billing** | [**BillingUpdate**](BillingUpdate.md) |  | [optional] 
**ChargeNumber** | **string** | The number of the charge to be updated. The value of this field is inherited from the &#x60;subscriptions&#x60; &gt; &#x60;orderActions&#x60; &gt; &#x60;addProduct&#x60; &gt; &#x60;chargeOverrides&#x60; &gt; &#x60;chargeNumber&#x60; field.  | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of a Rate Plan Charge object.  | [optional] 
**Description** | **string** |  | [optional] 
**EffectiveDate** | [**TriggerParams**](TriggerParams.md) |  | [optional] 
**Pricing** | [**PricingUpdateForEvergreen**](PricingUpdateForEvergreen.md) |  | [optional] 
**UniqueToken** | **string** | A unique string to represent the rate plan charge in the order. The unique token is used to perform multiple actions against a newly added rate plan charge. For example, if you want to add and update a product in the same order, assign a unique token to the newly added rate plan charge and use that token in future order actions.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

