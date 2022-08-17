# ZuoraClient.Model.PUTPublicNotificationDefinitionRequestCallout

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the callout. The default value is &#x60;true&#x60;. | [optional] [default to true]
**CalloutAuth** | [**CalloutAuth**](CalloutAuth.md) |  | [optional] 
**CalloutBaseurl** | **string** | The callout URL. It must start with &#39;https://&#39; | 
**CalloutParams** | **Dictionary&lt;string, string&gt;** | A key-value map of merge fields of this callout.  | [optional] 
**CalloutRetry** | **bool** | Specified whether to retry the callout when the callout fails. The default value is &#x60;true&#x60;. | [optional] [default to true]
**Description** | **string** | Description for the callout. | [optional] 
**HttpMethod** | **string** | The HTTP method of the callout. | 
**Name** | **string** | The name of the created callout. | 
**RequiredAuth** | **bool** | Specifies whether the callout requires auth. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

