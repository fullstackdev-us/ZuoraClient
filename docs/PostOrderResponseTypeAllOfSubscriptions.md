# ZuoraClient.Model.PostOrderResponseTypeAllOfSubscriptions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Status** | **string** | Status of the subscription. &#x60;Pending Activation&#x60; and &#x60;Pending Acceptance&#x60; are only applicable for an order that contains a &#x60;CreateSubscription&#x60; order action. | [optional] 
**SubscriptionId** | **string** | Subscription ID of the subscription included in this order. This field is returned instead of the &#x60;subscriptionNumber&#x60; field if the &#x60;returnIds&#x60; query parameter is set to &#x60;true&#x60;. | [optional] 
**SubscriptionNumber** | **string** | Subscription number of the subscription included in this order. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

