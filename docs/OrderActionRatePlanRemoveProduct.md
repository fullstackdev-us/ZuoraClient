# ZuoraClient.Model.OrderActionRatePlanRemoveProduct
Information about an order action of type `RemoveProduct`. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RatePlanId** | **string** | Internal identifier of the rate plan to remove.  | [optional] 
**UniqueToken** | **string** | A unique string to represent the rate plan charge in the order. The unique token is used to perform multiple actions against a newly added rate plan. For example, if you want to add and update a product in the same order, you would assign a unique token to the product rate plan when added and use that token in future order actions.A unique string in the order to represent the rate plan. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

