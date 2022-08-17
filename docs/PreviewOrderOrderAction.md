# ZuoraClient.Model.PreviewOrderOrderAction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AddProduct** | [**PreviewOrderRatePlanOverride**](PreviewOrderRatePlanOverride.md) |  | [optional] 
**CancelSubscription** | [**CancelSubscription**](CancelSubscription.md) |  | [optional] 
**ChangePlan** | [**CreateChangePlan**](CreateChangePlan.md) |  | [optional] 
**ChangeReason** | **string** | The change reason set for an order action when an order is created.  | [optional] 
**CreateSubscription** | [**PreviewOrderCreateSubscription**](PreviewOrderCreateSubscription.md) |  | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Order Action object.  | [optional] 
**OwnerTransfer** | [**OwnerTransfer**](OwnerTransfer.md) |  | [optional] 
**RemoveProduct** | [**RemoveProduct**](RemoveProduct.md) |  | [optional] 
**RenewSubscription** | [**RenewSubscription**](RenewSubscription.md) |  | [optional] 
**Resume** | [**CreateOrderResume**](CreateOrderResume.md) |  | [optional] 
**Suspend** | [**CreateOrderSuspend**](CreateOrderSuspend.md) |  | [optional] 
**TermsAndConditions** | [**CreateOrderTermsAndConditions**](CreateOrderTermsAndConditions.md) |  | [optional] 
**TriggerDates** | [**List&lt;TriggerDate&gt;**](TriggerDate.md) | Container for the contract effective, service activation, and customer acceptance dates of the order action.   If the service activation date is set as a required field in Default Subscription Settings, skipping this field in a &#x60;CreateSubscription&#x60; order action of your JSON request will result in a &#x60;Pending&#x60; order and a &#x60;Pending Activation&#x60; subscription.  If the customer acceptance date is set as a required field in Default Subscription Settings, skipping this field in a &#x60;CreateSubscription&#x60; order action of your JSON request will result in a &#x60;Pending&#x60; order and a &#x60;Pending Acceptance&#x60; subscription. If the service activation date field is at the same time required and skipped (or set as null), it will be a &#x60;Pending Activation&#x60; subscription.  | [optional] 
**Type** | **string** | Type of order action.  Unless the type of order action is &#x60;RenewSubscription&#x60;, you must use the corresponding field to provide information about the order action. For example, if the type of order action is &#x60;AddProduct&#x60;, you must set the &#x60;addProduct&#x60; field.  Zuora returns an error if you set a field that corresponds to a different type of order action. For example, if the type of order action is &#x60;AddProduct&#x60;, Zuora returns an error if you set the &#x60;updateProduct&#x60; field.  **Note**: The change plan type of order action is in the **Early Adopter** phase. We are actively soliciting feedback from a small set of early adopters before releasing it as generally available. If you want to join this early adopter program, submit a request at [Zuora Global Support](http://support.zuora.com/).  | 
**UpdateProduct** | [**PreviewOrderRatePlanUpdate**](PreviewOrderRatePlanUpdate.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

