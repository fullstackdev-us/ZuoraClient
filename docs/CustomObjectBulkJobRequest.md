# ZuoraClient.Model.CustomObjectBulkJobRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Filter** | [**CustomObjectBulkDeleteFilter**](CustomObjectBulkDeleteFilter.md) |  | [optional] 
**Namespace** | **string** | The namespace of the object. Custom objects belong to the &#x60;default&#x60; namespace. Zuora standard objects belong to the &#x60;com_zuora&#x60; namespace. Bulk job operations on the following Zuora standard objects are supported: * SavedQuery  | 
**Object** | **string** | The object that the bulk operation performs on. | 
**Operation** | **string** | The operation that the bulk job performs. Only the users that have the \&quot;Delete Custom Objects\&quot; permission can submit a &#x60;delete&#x60; bulk job request. Only the users that have the \&quot;Edit Custom Objects\&quot; permission can submit a &#x60;create&#x60; or &#x60;update&#x60; bulk job request. See [Platform Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/h_Platform_Roles#Platform_Permissions) for more information. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

