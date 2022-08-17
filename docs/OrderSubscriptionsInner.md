# ZuoraClient.Model.OrderSubscriptionsInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BaseVersion** | **int** | The base version of the subscription. | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of a Subscription object.  | [optional] 
**ExternallyManagedBy** | **string** | An enum field on the Subscription object to indicate the name of a third-party store. This field is used to represent subscriptions created through third-party stores.  | [optional] 
**NewVersion** | **int** | The latest version of the subscription. | [optional] 
**OrderActions** | [**List&lt;OrderAction&gt;**](OrderAction.md) |  | [optional] 
**Quote** | [**QuoteObjectFields**](QuoteObjectFields.md) |  | [optional] 
**Ramp** | **Object** | **Note**: This field is only available if you have the Ramps feature enabled. The [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) feature must be enabled before you can access the [Ramps](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/A_Overview_of_Ramps_and_Ramp_Metrics) feature. The Ramps feature is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information coming October 2020.  The ramp definition.  | [optional] 
**Sequence** | **int** | The sequence number of a certain subscription processed by the order. | [optional] 
**SubscriptionNumber** | **string** | The new subscription number for a new subscription created, or the existing subscription number. Unlike the order request, the subscription number here always has a value. | [optional] 
**SubscriptionOwnerAccountNumber** | **string** | The number of the account that owns the subscription. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

