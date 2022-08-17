# ZuoraClient.Model.OrderForEvergreen
Represents the order information that will be returned in the GET call.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedBy** | **string** | The ID of the user who created this order. | [optional] 
**CreatedDate** | **string** | The time that the order gets created in the system, in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format. | [optional] 
**Currency** | **string** | Currency code. | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Order object.  | [optional] 
**Description** | **string** | A description of the order. | [optional] 
**ExistingAccountNumber** | **string** | The account number that this order has been created under. This is also the invoice owner of the subscriptions included in this order. | [optional] 
**OrderDate** | **string** | The date when the order is signed. All the order actions under this order will use this order date as the contract effective date if no additinal contractEffectiveDate is provided. | [optional] 
**OrderNumber** | **string** | The order number of the order. | [optional] 
**Status** | **string** | The status of the order. | [optional] 
**Subscriptions** | [**List&lt;OrderForEvergreenSubscriptionsInner&gt;**](OrderForEvergreenSubscriptionsInner.md) | Represents a processed subscription, including the origin request (order actions) that create this version of subscription and the processing result (order metrics). The reference part in the request will be overridden with the info in the new subscription version. | [optional] 
**UpdatedBy** | **string** | The ID of the user who updated this order. | [optional] 
**UpdatedDate** | **string** | The time that the order gets updated in the system (for example, an order description update), in the &#x60;YYYY-MM-DD HH:MM:SS&#x60; format. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

