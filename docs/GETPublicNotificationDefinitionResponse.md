# ZuoraClient.Model.GETPublicNotificationDefinitionResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the notification definition. The default value is &#x60;true&#x60;. | [optional] 
**AssociatedAccount** | **string** | Indicates with which type of account this notification is associated.  | [optional] 
**Callout** | [**GETPublicNotificationDefinitionResponseCallout**](GETPublicNotificationDefinitionResponseCallout.md) |  | [optional] 
**CalloutActive** | **bool** | The status of the callout action. The default value is &#x60;false&#x60;. | [optional] 
**CommunicationProfileId** | **Guid** | The profile that the notification definition belongs to. | [optional] 
**CreatedBy** | **Guid** | The ID of the user who created the notification definition. | [optional] 
**CreatedOn** | **DateTime** | The time when the notification definition was created. Specified in the UTC timezone in the ISO860 format (YYYY-MM-DDThh:mm:ss.sTZD). E.g. 1997-07-16T19:20:30.45+00:00 | [optional] 
**Description** | **string** | Description of the notification definition | [optional] 
**EmailActive** | **bool** | The status of the email action. The default value is &#x60;false&#x60;. | [optional] 
**EmailTemplateId** | **Guid** | The ID of the email template. In the request, there should be at least one email template or callout. | [optional] 
**EventTypeName** | **string** | The name of the event type. | [optional] 
**EventTypeNamespace** | **string** | The namespace of the &#x60;eventTypeName&#x60; field.   | [optional] 
**FilterRule** | [**GETPublicNotificationDefinitionResponseFilterRule**](GETPublicNotificationDefinitionResponseFilterRule.md) |  | [optional] 
**FilterRuleParams** | **Dictionary&lt;string, string&gt;** | The parameter values used to configure the filter rule.  | [optional] 
**Id** | **Guid** | The ID associated with this notification definition. | [optional] 
**Name** | **string** | The name of the notification definition. | [optional] 
**UpdatedBy** | **Guid** | The ID of the user who updated the notification definition. | [optional] 
**UpdatedOn** | **DateTime** | The time when the notification was updated. Specified in the UTC timezone in the ISO860 format (YYYY-MM-DDThh:mm:ss.sTZD). E.g. 1997-07-16T19:20:30.45+00:00 | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

