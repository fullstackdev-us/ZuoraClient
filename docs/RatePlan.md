# ZuoraClient.Model.RatePlan

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AmendmentId** | **string** |  The ID of the amendment associated with the rate plan. This field only applies to amendment rate plans.   **Character limit**: 32  **Values**: a valid amendment ID  | [optional] 
**AmendmentSubscriptionRatePlanId** | **string** | The ID of the subscription rate plan modified by the amendment. This field only applies to amendment rate plans. The ID can be the latest version or any history version of ID.  **Character limit**: 32  **Values**: a valid rate plan ID  | [optional] 
**AmendmentType** | **string** | The type of amendment associated with the rate plan. This field only applies to amendment rate plans.  **Character limit**: 20  **Values**: inherited from &#x60;Amendment.Type&#x60;  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the RatePlan object.  **Character limit**: 32  **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** | The date when the &#x60;RatePlan&#x60; object was last updated.  **Character limit**: 29  **Values**: automatically generated  | [optional] 
**ExternallyManagedPlanId** | **string** | The unique identifier for the rate plan purchased on a third-party store. This field is used to represent a subscription rate plan created through third-party stores.  | [optional] 
**Name** | **string** | The name of the rate plan. Leave this null in a subscribe call to inherited the &#x60;ProductRatePlan.Name&#x60; field value.  **Character limit**: 100  **Values**: a string of 100 characters or fewer or inherited from ProductRatePlan.Name  | [optional] 
**ProductRatePlanId** | **string** | The ID of the associated product rate plan.  **Character limit**: 32  **Values**: a valid product rate plan ID  | 
**SubscriptionId** | **string** | The ID of the subscription that the rate plan belongs to.  **Character limit**: 32  **Values**: a valid subscription ID  | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the rate plan.   **Character limit**: 32  **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the rate plan was last updated.   **Character limit**: 29  **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

