# ZuoraClient.Model.OrderDeltaTcb
Order Delta Tcb. This is a metric that reflects the change to the estimated billing on Rate Plan Charge object, or the estimated billing for an Order Line Item as the result of the order 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ChargeNumber** | **string** | The charge number for the associated Rate Plan Charge. This field can be null if the metric is generated for an Order Line Item.  | [optional] 
**Currency** | **string** | ISO 3-letter currency code (uppercase). For example, USD.  | [optional] 
**EndDate** | **DateTime** | The end date for the order delta metric.  | [optional] 
**GrossAmount** | **decimal** | The gross amount for the metric. The is the amount excluding applied discount.  | [optional] 
**NetAmount** | **decimal** | The net amount for the metric. The is the amount with discounts applied  | [optional] 
**OrderActionId** | **string** | The Id for the related Order Action. This field can be null if the metric is generated for an Order Line Item.  | [optional] 
**OrderActionSequence** | **string** | The sequence for the related Order Action. This field can be null if the metric is generated for an Order Line Item.  | [optional] 
**OrderActionType** | **string** | The type for the related Order Action. This field can be null if the metric is generated for an Order Line Item.  | [optional] 
**OrderLineItemNumber** | **string** | A sequential number auto-assigned for each of order line items in a order, used as an index, for example, \&quot;1\&quot;.  | [optional] 
**ProductRatePlanChargeId** | **string** | The Id for the associated Product Rate Plan Charge. This field can be null if the Order Line Item is not associated with a Product Rate Plan Charge.  | [optional] 
**RatePlanChargeId** | **string** | The id for the associated Rate Plan Charge. This field can be null if the metric is generated for an Order Line Item.  | [optional] 
**StartDate** | **DateTime** | The start date for the order delta metric.  | [optional] 
**SubscriptionNumber** | **string** | The number of the subscription. This field can be null if the metric is generated for an Order Line Item.  | [optional] 
**OrderLineItemId** | **Guid** | The sytem generated Id for the Order Line Item. This field can be null if the metric is generated for a Rate Plan Charge.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

