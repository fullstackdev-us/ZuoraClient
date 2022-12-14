# ZuoraClient.Model.ProxyGetRatePlanChargeTier

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedById** | **string** | The ID of the Zuora user who created the RatePlanChargeTier object. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date when the RatePlanChargeTier object was created. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**EndingUnit** | **double** |  The end number of a range of units for the tier. **Character limit**: 16 **Values**: any positive decimal value  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**Price** | **double** |  The price of the tier if the charge is a flat fee, or the price of each unit in the tier if the change model is tiered pricing. **Character limit**: 16 **Values**: any positive decimal value  | [optional] 
**PriceFormat** | **string** |  Indicates if the price is a flat fee or is per unit. **Character limit**: 8 **Values**: &#x60;Flat Fee&#x60;, &#x60;Per Unit&#x60;  | [optional] 
**RatePlanChargeId** | **string** |  The ID of the subscription or amendment rate plan charge associated with this tier. You can&#39;t create an unassociated tier. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60;.  | [optional] 
**StartingUnit** | **double** |  The start number of a range of units for the tier. **Character limit**: 16 **Values**: any positive decimal value  | [optional] 
**Tier** | **int** |  A unique number that identifies the tier that the price applies to. **Character limit**: 20 **Values**: automatically generated  | [optional] 
**UpdatedById** | **string** | The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

