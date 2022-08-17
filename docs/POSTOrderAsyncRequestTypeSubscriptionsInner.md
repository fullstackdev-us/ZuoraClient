# ZuoraClient.Model.POSTOrderAsyncRequestTypeSubscriptionsInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of a Subscription object.  | [optional] 
**OrderActions** | [**List&lt;CreateOrderOrderAction&gt;**](CreateOrderOrderAction.md) | The actions to be applied to the subscription. Order actions will be stored with the sequence when it was provided in the request. | [optional] 
**Quote** | [**QuoteObjectFields**](QuoteObjectFields.md) |  | [optional] 
**Ramp** | [**RampRequest**](RampRequest.md) |  | [optional] 
**SubscriptionNumber** | **string** | Leave this empty to represent new subscription creation. Specify a subscription number to update an existing subscription.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

