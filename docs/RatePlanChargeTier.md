# ZuoraClient.Model.RatePlanChargeTier

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedById** | **string** | The ID of the Zuora user who created the RatePlanChargeTier object.  **Character limit**: 32   **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date when the RatePlanChargeTier object was created.   **Character limit**: 29   **Values**: automatically generated  | [optional] 
**EndingUnit** | **double** |  The end number of a range of units for the tier. This field is only required if the charge mode is &#x60;Tiered Pricing&#x60; or &#x60;Tierred with Overage Pricing&#x60;.   **Character limit**: 16   **Values**: any positive decimal value  | [optional] 
**IsOveragePrice** | **bool** |  Indicates if the price is an overage price. An overage occurs when usage surpasses the last defined tier. This field is applicable only to tier pricing and volume pricing models.    **Values**: true, false  | [optional] 
**Price** | **double** |  The price of the tier if the charge is a flat fee, or the price of each unit in the tier if the change model is tiered pricing.   **Character limit**: 16   **Values**: any positive decimal value  | [optional] 
**PriceFormat** | **string** |  Indicates if the price is a flat fee or is per unit.   **Character limit**: 8   **Values**: &#x60;FlatFee&#x60;, &#x60;PerUnit&#x60;  | [optional] 
**RatePlanChargeId** | **string** |  The ID of the subscription or amendment rate plan charge associated with this tier. You can&#39;t create an unassociated tier.   **Character limit**: 32   **Values**: inherited from &#x60;RatePlanCharge&#x60;.&#x60;Id&#x60;  | 
**StartingUnit** | **double** |  The start number of a range of units for the tier. This field is only required if the charge mode is &#x60;Tiered Pricing&#x60; or &#x60;Tierred with Overage Pricing&#x60;.   **Character limit**: 16   **Values**: any positive decimal value  | [optional] 
**Tier** | **int** |  A unique number that identifies the tier that the price applies to.   **Character limit**: 20   **Values**: automatically generated  | [optional] 
**UpdatedById** | **string** | The ID of the last user to update the object.  **Character limit**: 32   **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the object was last updated.   **Character limit**: 29   **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

