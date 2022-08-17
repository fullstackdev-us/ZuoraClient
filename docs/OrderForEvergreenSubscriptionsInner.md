# ZuoraClient.Model.OrderForEvergreenSubscriptionsInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BaseVersion** | **int** | The base version of the subscription. | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of a Subscription object.  | [optional] 
**NewVersion** | **int** | The latest version of the subscription. | [optional] 
**OrderActions** | [**List&lt;OrderActionForEvergreen&gt;**](OrderActionForEvergreen.md) |  | [optional] 
**Quote** | [**QuoteObjectFields**](QuoteObjectFields.md) |  | [optional] 
**Sequence** | **int** | The sequence number of a certain subscription processed by the order. | [optional] 
**SubscriptionNumber** | **string** | The new subscription number for a new subscription created, or the existing subscription number. Unlike the order request, the subscription number here always has a value. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

