# ZuoraClient.Model.GETPublicNotificationDefinitionResponseCallout

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the callout. The default value is &#x60;true&#x60;. | [optional] [default to true]
**CalloutAuth** | [**CalloutAuth**](CalloutAuth.md) |  | [optional] 
**CalloutBaseurl** | **string** | The callout URL. It must start with &#39;https://&#39; | [optional] 
**CalloutParams** | **Dictionary&lt;string, string&gt;** | A key-value map of merge fields of this callout.  | [optional] 
**CalloutRetry** | **bool** | Specified whether to retry the callout when the callout fails. The default value is &#x60;true&#x60;. | [optional] [default to true]
**Description** | **string** | Description for the callout. | [optional] 
**EventTypeName** | **string** | The name of the custom event type. | [optional] 
**HttpMethod** | **string** | The HTTP method of the callout. | [optional] 
**Id** | **Guid** | The ID of the callout. If &#x60;calloutActive&#x60; is &#x60;true&#x60;, a callout is required. The eventTypeName of the callout MUST be the same as the eventTypeName. | [optional] 
**Name** | **string** | The name of the created callout. | [optional] 
**RequiredAuth** | **bool** | Specifies whether the callout requires auth. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

