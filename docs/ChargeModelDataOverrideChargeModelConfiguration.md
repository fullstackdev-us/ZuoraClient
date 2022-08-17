# ZuoraClient.Model.ChargeModelDataOverrideChargeModelConfiguration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CustomFieldPerUnitRate** | **string** | The custom field that carries the per-unit rate for each usage record. For example, &#x60;perUnitAmount__c&#x60;.  This field is only available for the usage-based charges that use the Pre-Rated Per Unit Pricing charge model. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.  | [optional] 
**CustomFieldTotalAmount** | **string** | The custom field that carries the total amount to charge for a usage record. For example, &#x60;totalAmount__c&#x60;.   This field is only available for the usage-based charges that use the Pre-Rated Pricing charge model. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.  | [optional] 
**Formula** | **string** | The pricing formula to calculate actual rating amount.  This field is only available for charges that use the Multi-Attribute Pricing charge model.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

