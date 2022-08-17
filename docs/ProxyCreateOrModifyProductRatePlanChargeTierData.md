# ZuoraClient.Model.ProxyCreateOrModifyProductRatePlanChargeTierData
Container for pricing information associated with the product rate plan charge. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ProductRatePlanChargeTier** | [**List&lt;ProxyCreateOrModifyProductRatePlanChargeTierDataProductRatePlanChargeTierInner&gt;**](ProxyCreateOrModifyProductRatePlanChargeTierDataProductRatePlanChargeTierInner.md) | Array of product rate plan charge tiers.  You should specify all relevant fields of all tiers, including pricing information for each currency.  For each currency, ensure that the tiers appear in ascending order of &#x60;StartingUnit&#x60;.  For example:  &#x60;&#x60;&#x60; [   {     \&quot;StartingUnit\&quot;: \&quot;1\&quot;,     \&quot;EndingUnit\&quot;: \&quot;150\&quot;,     \&quot;Currency\&quot;: \&quot;USD\&quot;,     \&quot;Price\&quot;: 1.95,     \&quot;PriceFormat\&quot;: \&quot;Per Unit\&quot;   },   {     \&quot;StartingUnit\&quot;: \&quot;151\&quot;,     \&quot;EndingUnit\&quot;: \&quot;300\&quot;,     \&quot;Currency\&quot;: \&quot;USD\&quot;,     \&quot;Price\&quot;: 1.45,     \&quot;PriceFormat\&quot;: \&quot;Per Unit\&quot;   },   {     \&quot;StartingUnit\&quot;: \&quot;1\&quot;,     \&quot;EndingUnit\&quot;: \&quot;150\&quot;,     \&quot;Currency\&quot;: \&quot;EUR\&quot;,     \&quot;Price\&quot;: 1.75,     \&quot;PriceFormat\&quot;: \&quot;Per Unit\&quot;   },   {     \&quot;StartingUnit\&quot;: \&quot;151\&quot;,     \&quot;EndingUnit\&quot;: \&quot;300\&quot;,     \&quot;Currency\&quot;: \&quot;EUR\&quot;,     \&quot;Price\&quot;: 1.30,     \&quot;PriceFormat\&quot;: \&quot;Per Unit\&quot;   } ] &#x60;&#x60;&#x60;  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

