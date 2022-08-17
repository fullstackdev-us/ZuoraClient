# ZuoraClient.Model.RampIntervalChargeMetrics

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ChargeNumber** | **string** | The number of the charge. | [optional] 
**DiscountTcb** | **decimal** | The discount amount for the TCB. | [optional] 
**DiscountTcv** | **decimal** | The discount amount for the TCV. | [optional] 
**EndDate** | **DateTime** | The end date of the rate plan charge in the current ramp interval. | [optional] 
**GrossTcb** | **decimal** | The gross TCB value before discount charges are applied. | [optional] 
**GrossTcv** | **decimal** | The gross TCV value before discount charges are applied. | [optional] 
**Mrr** | [**List&lt;RampIntervalChargeMetricsMrrInner&gt;**](RampIntervalChargeMetricsMrrInner.md) | The MRR changing history of the current rate plan charge in the current ramp interval. | [optional] 
**NetTcb** | **decimal** | The net TCB value after discount charges are applied. | [optional] 
**NetTcv** | **decimal** | The net TCV value after discount charges are applied. | [optional] 
**ProductRatePlanChargeId** | **string** | The ID of the corresponding product rate plan charge. | [optional] 
**Quantity** | **decimal** | The quantity of the rate plan charge. | [optional] 
**RatePlanChargeId** | **string** | The ID of the rate plan charge. | [optional] 
**StartDate** | **DateTime** | The start date of the rate plan charge in the current ramp interval. | [optional] 
**SubscriptionNumber** | **string** | The number of the subscription that the current rate plan charge belongs to. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

