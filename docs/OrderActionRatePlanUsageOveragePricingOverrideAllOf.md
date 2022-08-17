# ZuoraClient.Model.OrderActionRatePlanUsageOveragePricingOverrideAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**IncludedUnits** | **decimal** | Number of free units that may be consumed.  | [optional] 
**NumberOfPeriods** | **int** | Number of periods that Zuora considers when calculating overage charges with overage smoothing.  | [optional] 
**OveragePrice** | **decimal** | Price per overage unit consumed.  | [optional] 
**OverageUnusedUnitsCreditOption** | **string** | Specifies whether to credit the customer for unused units.  If the value of this field is &#x60;CreditBySpecificRate&#x60;, use the &#x60;unusedUnitsCreditRates&#x60; field to specify the rate at which to credit the customer for unused units.  | [optional] 
**UnusedUnitsCreditRates** | **decimal** | Per-unit rate at which to credit the customer for unused units. Only applicable if the value of the &#x60;overageUnusedUnitsCreditOption&#x60; field is &#x60;CreditBySpecificRate&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

