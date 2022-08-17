# ZuoraClient.Model.GETProductRatePlanTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Description** | **string** | Rate plan description.  | [optional] 
**EffectiveEndDate** | **DateTime** | Final date the rate plan is active, as &#x60;yyyy-mm-dd&#x60;. After this date, the rate plan status is &#x60;Expired&#x60;.  | [optional] 
**EffectiveStartDate** | **DateTime** | First date the rate plan is active (i.e., available to be subscribed to), as &#x60;yyyy-mm-dd&#x60;.  Before this date, the status is &#x60;NotStarted&#x60;.  | [optional] 
**Grade** | **decimal** | The Grade of the product rate plan.  **Note**: This field is in the **Early Adopter** phase. We are actively soliciting feedback from a small set of early adopters before releasing it as generally available. If you want to join this early adopter program, submit a request at [Zuora Global Support](http://support.zuora.com/).  | [optional] 
**Id** | **string** | Unique product rate-plan ID.  | [optional] 
**Name** | **string** | Name of the product rate-plan charge. (Not required to be unique.)  | [optional] 
**ProductRatePlanCharges** | [**List&lt;GETProductRatePlanChargeType&gt;**](GETProductRatePlanChargeType.md) | Field attributes describing the product rate plan charges:  | [optional] 
**Status** | **string** | Possible vales are: &#x60;Active&#x60;, &#x60;Expired&#x60;, &#x60;NotStarted&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

