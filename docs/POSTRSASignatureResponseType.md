# ZuoraClient.Model.POSTRSASignatureResponseType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Key** | **string** | Public key generated for this Payment Page.  | [optional] 
**Signature** | **string** | Digital signature generated for this Payment Page.  If &#x60;signature&#x60; returns &#x60;null&#x60; but &#x60;token&#x60; is successfully returned, please limit the number of the fields in your request to make sure that the maximum length supported by the RSA signature algorithm is not exceeded.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TenantId** | **string** | ID of the Zuora tenant.  | [optional] 
**Token** | **string** | Token generated for this Payment Page.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

