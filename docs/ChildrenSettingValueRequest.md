# ZuoraClient.Model.ChildrenSettingValueRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Body** | **Object** | Request payload if any | [optional] 
**Id** | **string** | The id of the request. You can set it to any string. It must be unique within the whole batch.  | [optional] 
**Method** | **string** | One of the HTTP methods supported by the setting endpoint, for example, GET,PUT,POST or DELETE.  | [optional] 
**Url** | **string** | The relative URL of the setting. It is the same as in the &#x60;pathPattern&#x60; field in the response body of [Listing all settings](https://www.zuora.com/developer/api-reference/#operation/GET_ListAllSettings). For example, &#x60;/billing-rules&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

