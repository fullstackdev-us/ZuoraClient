# ZuoraClient.Model.OrderActionRatePlanChargeUpdate
The JSON object containing the information for a charge update in the 'UpdateProduct' type order action.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Billing** | [**OrderActionRatePlanBillingUpdate**](OrderActionRatePlanBillingUpdate.md) |  | [optional] 
**ChargeNumber** | **string** | Read only. Identifies the charge to be updated.  | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of a Rate Plan Charge object.  | [optional] 
**Description** | **string** |  | [optional] 
**EffectiveDate** | [**OrderActionRatePlanTriggerParams**](OrderActionRatePlanTriggerParams.md) |  | [optional] 
**Pricing** | [**OrderActionRatePlanPricingUpdate**](OrderActionRatePlanPricingUpdate.md) |  | [optional] 
**UniqueToken** | **string** | description: |   A unique string to represent the rate plan charge in the order. The unique token is used to perform multiple actions against a newly added rate plan. For example, if you want to add and update a product in the same order, you would assign a unique token to the product rate plan when added and use that token in future order actions.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

