# ZuoraClient.Model.GETSubscriptionRatePlanType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExternallyManagedPlanId** | **string** | Indicates the unique identifier for the rate plan purchased on a third-party store. This field is used to represent a subscription rate plan created through third-party stores.  | [optional] 
**Id** | **string** | Rate plan ID.  | [optional] 
**LastChangeType** | **string** | The last amendment on the rate plan.  Possible Values:  * &#x60;Add&#x60; * &#x60;Update&#x60; * &#x60;Remove&#x60;  | [optional] 
**ProductId** | **string** |  | [optional] 
**ProductName** | **string** |  | [optional] 
**ProductRatePlanId** | **string** |  | [optional] 
**ProductSku** | **string** | The unique SKU for the product.  | [optional] 
**RatePlanCharges** | [**List&lt;GETSubscriptionRatePlanChargesType&gt;**](GETSubscriptionRatePlanChargesType.md) | Container for one or more charges.  | [optional] 
**RatePlanName** | **string** | Name of the rate plan.  | [optional] 
**SubscriptionProductFeatures** | [**List&lt;GETSubscriptionProductFeatureType&gt;**](GETSubscriptionProductFeatureType.md) | Container for one or more features.   Only available when the following settings are enabled:  * The Entitlements feature in your tenant.  * The Enable Feature Specification in Product and Subscriptions setting in Zuora Billing Settings | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

