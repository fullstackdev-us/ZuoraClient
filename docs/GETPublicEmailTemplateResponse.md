# ZuoraClient.Model.GETPublicEmailTemplateResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the email template. | [optional] 
**BccEmailAddress** | **string** | Email BCC address. | [optional] 
**CcEmailAddress** | **string** | Email CC address. | [optional] 
**CcEmailType** | **string** | Email cc type. | [optional] [default to CcEmailTypeEnum.SpecificEmails]
**CreatedBy** | **Guid** | The ID of the user who created the email template. | [optional] 
**CreatedOn** | **DateTime** | The time when the email template was created. Specified in the UTC timezone in the ISO860 format (YYYY-MM-DDThh:mm:ss.sTZD). E.g. 1997-07-16T19:20:30.45+00:00 | [optional] 
**Description** | **string** | The description of the email template. | [optional] 
**EmailBody** | **string** | The email body. You can add merge fields in the email object using angle brackets.  User can also embed html tags if &#x60;isHtml&#x60; is &#x60;true&#x60;. | [optional] 
**EmailSubject** | **string** | The email subject. You can add merge fields in the email subject using angle brackets. | [optional] 
**EncodingType** | **string** | The endcode type of the email body. | [optional] 
**EventCategory** | **decimal** | The event category code for a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all event category codes. | [optional] 
**EventTypeName** | **string** | The name of the custom event or custom scheduled event. | [optional] 
**EventTypeNamespace** | **string** | The namespace of the &#x60;eventTypeName&#x60; field for custom events and custom scheduled events.   | [optional] 
**FromEmailAddress** | **string** | If formEmailType is SpecificEmail, this field is required. | [optional] 
**FromEmailType** | **string** | The from email type. | [optional] 
**FromName** | **string** | The name of email sender. | [optional] 
**Id** | **Guid** | The email template ID. | [optional] 
**IsHtml** | **bool** | Indicates whether the style of email body is HTML. | [optional] 
**Name** | **string** | The name of the email template. | [optional] 
**ReplyToEmailAddress** | **string** | If replyToEmailType is SpecificEmail, this field is required | [optional] 
**ReplyToEmailType** | **string** | The reply email type. | [optional] 
**ToEmailAddress** | **string** | If &#x60;toEmailType&#x60; is &#x60;SpecificEmail&#x60;, this field is required. | [optional] 
**ToEmailType** | **string** | Email receive type. | [optional] 
**UpdatedBy** | **Guid** | The ID of the user who updated the email template. | [optional] 
**UpdatedOn** | **DateTime** | The time when the email template was updated. Specified in the UTC timezone in the ISO860 format (YYYY-MM-DDThh:mm:ss.sTZD). E.g. 1997-07-16T19:20:30.45+00:00 | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

