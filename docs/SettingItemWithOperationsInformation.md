# ZuoraClient.Model.SettingItemWithOperationsInformation

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Context** | **string** | The context where this setting item is effective. | [optional] 
**Description** | **string** | The description of the setting item as you see from Zuora UI. | [optional] 
**HttpOperations** | [**List&lt;SettingItemHttpOperation&gt;**](SettingItemHttpOperation.md) | An array of HTTP operation methods that are supported on this setting endpoint. | [optional] 
**Key** | **string** | The unique key to distinguish the setting item. | [optional] 
**PathPattern** | **string** | The path pattern of the setting endpoint, relative to &#x60;/settings&#x60;. For example, &#x60;/billing-rules&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

