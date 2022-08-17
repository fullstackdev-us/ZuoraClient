# ZuoraClient.Model.CustomObjectBulkJobResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedById** | **Guid** | The ID of the user who creates the job. | [optional] 
**CreatedDate** | **DateTime** | The time when the bulk job is created. | [optional] 
**Id** | **Guid** | The custom object bulk job ID. | [optional] 
**UpdatedById** | **Guid** | The ID of the user who updates the job. | [optional] 
**UpdatedDate** | **DateTime** | The time when the bulk job is updated. | [optional] 
**Error** | [**CustomObjectBulkJobResponseError**](CustomObjectBulkJobResponseError.md) |  | [optional] 
**Namespace** | **string** | The namespace of the object. Custom objects belong to the &#x60;default&#x60; namespace. Zuora standard objects belong to the &#x60;com_zuora&#x60; namespace. Bulk job operations on the following Zuora standard objects are supported: * SavedQuery  | [optional] 
**Object** | **string** | The object to that the bulk operation performs on. | [optional] 
**Operation** | **string** | The operation that the bulk job performs. Only the users that have the \&quot;Delete Custom Objects\&quot; permission can submit a &#x60;delete&#x60; bulk job request. Only the users that have the \&quot;Edit Custom Objects\&quot; permission can submit a &#x60;create&#x60; or &#x60;update&#x60; bulk job request. See [Platform Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/h_Platform_Roles#Platform_Permissions) for more information.  | [optional] 
**ProcessingTime** | **int** | The amount of time elapsed, in milliseconds, from the submission to the completion of the bulk job. | [optional] 
**RecordsProcessed** | **int** | The number of object records processed by the bulk job. | [optional] 
**Status** | **string** | The status of the bulk job:  - &#x60;accepted&#x60; - The job has been accepted and is ready to process. - &#x60;pending&#x60; - The job is waiting for your input. You can use [Upload a file for a custom object bulk job](https://www.zuora.com/developer/api-reference/#operation/POST_UploadFileForCustomObjectBulkJob) to upload a file so that the job can start creating records. - &#x60;in_progress&#x60; - The job is processing. - &#x60;completed&#x60; - The job has completed. - &#x60;failed&#x60; - The job was unable to complete. You can use [List all errors for a custom object bulk job](https://www.zuora.com/developer/api-reference/#operation/GET_CustomObjectBulkJobErrors) to list the errors. - &#x60;cancelled&#x60; - The job was cancelled by the server.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

