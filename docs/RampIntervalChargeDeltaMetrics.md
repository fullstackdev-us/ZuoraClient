# ZuoraClient.Model.RampIntervalChargeDeltaMetrics

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ChargeNumber** | **string** | The number of the rate plan charge. | [optional] 
**DeltaDiscountTcb** | **decimal** | The discount delta amount for the TCB. | [optional] 
**DeltaDiscountTcv** | **decimal** | The discount delta amount for the TCV. | [optional] 
**DeltaGrossTcb** | **decimal** | The TCB delta value before discount charges are applied. | [optional] 
**DeltaGrossTcv** | **decimal** | The TCV delta value before discount charges are applied. | [optional] 
**DeltaMrr** | [**List&lt;RampIntervalChargeDeltaMetricsDeltaMrrInner&gt;**](RampIntervalChargeDeltaMetricsDeltaMrrInner.md) | The MRR changing history of the current rate plan charge in the current ramp interval. | [optional] 
**DeltaNetTcb** | **decimal** | The TCB delta value after discount charges are applied. | [optional] 
**DeltaNetTcv** | **decimal** | The TCV delta value after discount charges are applied. | [optional] 
**DeltaQuantity** | [**List&lt;RampIntervalChargeDeltaMetricsDeltaQuantityInner&gt;**](RampIntervalChargeDeltaMetricsDeltaQuantityInner.md) | The charge quantity changing history of the current rate plan charge in the current ramp interval. | [optional] 
**ProductRatePlanChargeId** | **string** | The ID of the corresponding product rate plan charge. | [optional] 
**SubscriptionNumber** | **string** | The number of the subscription that the current rate plan charge belongs to. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

