# ZuoraClient.Model.CreateOrderChangePlanRatePlanOverride
Information about the new product rate plan to add.  

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ChargeOverrides** | [**List&lt;CreateOrderChargeOverride&gt;**](CreateOrderChargeOverride.md) | List of charges associated with the rate plan.  | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of a Rate Plan object.  | [optional] 
**ExternalCatalogPlanId** | **string** | An external ID of the product rate plan to be added. You can use this field to specify a product rate plan that is imported from an external system. The value of the &#x60;externalCatalogPlanId&#x60; field must match one of the values that are predefined in the &#x60;externallyManagedPlanIds&#x60; field on a product rate plan.  **Note:** If both &#x60;externalCatalogPlanId&#x60; and &#x60;productRatePlanId&#x60; are provided. They must point to the same product rate plan. Otherwise, the request would fail.  | [optional] 
**ExternallyManagedPlanId** | **string** | Indicates the unique identifier for the rate plan purchased on a third-party store. This field is used to represent a subscription rate plan created through third-party stores.  | [optional] 
**ProductRatePlanId** | **string** | Internal identifier of the product rate plan that the rate plan is based on.  | [optional] 
**UniqueToken** | **string** | Unique identifier for the rate plan. This identifier enables you to refer to the rate plan before the rate plan has an internal identifier in Zuora.  For instance, suppose that you want to use a single order to add a product to a subscription and later update the same product. When you add the product, you can set a unique identifier for the rate plan. Then when you update the product, you can use the same unique identifier to specify which rate plan to modify.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

