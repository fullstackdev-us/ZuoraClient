# ZuoraClient.Model.ProxyGetProductRatePlanChargeTier

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedById** | **string** | The ID of the Zuora user who created the ProductRatePlanChargeTier object. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** | The date when the ProductRatePlanChargeTier object was created. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**Currency** | **string** | The code corresponding to the currency for the tier&#39;s price. **Character limit**: 3 **Values**: a valid currency code  | [optional] 
**EndingUnit** | **double** | The end number of a range of units for the tier. **Character limit**: 16 **Values**: any positive decimal value  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**Price** | **double** |  The price of the tier if the charge is a flat fee, or the price of each unit in the tier if the charge model is tiered pricing. **Character limit**: 16 **Values**: a valid currency value  | [optional] 
**PriceFormat** | **string** | Indicates if pricing is a flat fee or is per unit. This field is for tiered and volume pricing models only. **Character limit**: 8 **Values**: &#x60;FlatFee&#x60;, &#x60;PerUnit&#x60; **Note:** The values &#x60;Flat Fee&#x60; and &#x60;Per Unit&#x60; (with spaces) is valid for create or update calls.  | [optional] 
**StartingUnit** | **double** |  The starting number of a range of units for the tier. **Character limit**: 16 **Values**: any positive decimal value  | [optional] 
**Tier** | **int** |  A unique number that identifies the tier that the price applies to. **Character limit**: 20 **Values**: automatically generated  | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the product rate plan charge tier. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the product rate plan charge tier was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

