# ZuoraClient.Model.OrderActionForEvergreen
Represents the processed order action.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AddProduct** | [**RatePlanOverrideForEvergreen**](RatePlanOverrideForEvergreen.md) |  | [optional] 
**CancelSubscription** | [**CancelSubscription**](CancelSubscription.md) |  | [optional] 
**CreateSubscription** | [**CreateSubscriptionForEvergreen**](CreateSubscriptionForEvergreen.md) |  | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Order Action object.  | [optional] 
**Id** | **string** | The Id of the order action processed in the order. | [optional] 
**OrderMetrics** | [**List&lt;OrderMetricsForEvergreen&gt;**](OrderMetricsForEvergreen.md) | Shows the delta metrics caused by a specific order action on a specific charge.  | [optional] 
**OwnerTransfer** | [**OwnerTransfer**](OwnerTransfer.md) |  | [optional] 
**RemoveProduct** | [**RemoveProduct**](RemoveProduct.md) |  | [optional] 
**RenewSubscription** | [**RenewSubscription**](RenewSubscription.md) |  | [optional] 
**Resume** | [**GetOrderResume**](GetOrderResume.md) |  | [optional] 
**Sequence** | **int** | The sequence of the order actions processed in the order. | [optional] 
**Suspend** | [**GetOrderSuspend**](GetOrderSuspend.md) |  | [optional] 
**TermsAndConditions** | [**TermsAndConditions**](TermsAndConditions.md) |  | [optional] 
**TriggerDates** | [**List&lt;TriggerDate&gt;**](TriggerDate.md) | Container for the contract effective, service activation, and customer acceptance dates of the order action.   If [Zuora is configured to require service activation](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) and the &#x60;ServiceActivation&#x60; field is not set for a &#x60;CreateSubscription&#x60; order action, a &#x60;Pending&#x60; order and a &#x60;Pending Activation&#x60; subscription are created.  If [Zuora is configured to require customer acceptance](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Customer_Acceptance_of_Orders.3F) and the &#x60;CustomerAcceptance&#x60; field is not set for a &#x60;CreateSubscription&#x60; order action, a &#x60;Pending&#x60; order and a &#x60;Pending Acceptance&#x60; subscription are created. At the same time, if the service activation date field is also required and not set, a &#x60;Pending&#x60; order and a &#x60;Pending Activation&#x60; subscription are created instead.  If [Zuora is configured to require service activation](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) and the &#x60;ServiceActivation&#x60; field is not set for either of the following order actions, a &#x60;Pending&#x60; order is created. The subscription status is not impacted. **Note:** This feature is in **Limited Availability**. If you want to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions  If [Zuora is configured to require customer acceptance](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Customer_Acceptance_of_Orders.3F) and the &#x60;CustomerAcceptance&#x60; field is not set for either of the following order actions, a &#x60;Pending&#x60; order is created. The subscription status is not impacted. **Note:** This feature is in **Limited Availability**. If you want to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions  | [optional] 
**Type** | **string** | Type of the order action. | [optional] 
**UpdateProduct** | [**RatePlanUpdateForEvergreen**](RatePlanUpdateForEvergreen.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

