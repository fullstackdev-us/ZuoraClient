# ZuoraClient.Model.POSTPublicEmailTemplateRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the email template. The default value is &#x60;true&#x60;. | [optional] [default to true]
**BccEmailAddress** | **string** | The email bcc address. | [optional] 
**CcEmailAddress** | **string** | The email CC address. | [optional] 
**CcEmailType** | **string** | Email CC type. * When the base object for the event is associated with &#x60;Account&#x60;, &#x60;ccEmailType&#x60; can be any values in the enum list.  * When the base object for the event is not associated with &#x60;Account&#x60;, &#x60;ccEmailType&#x60; must be &#x60;TenantAdmin&#x60;, &#x60;RunOwner&#x60;, or &#x60;SpecificEmail&#x60;.  | [optional] [default to CcEmailTypeEnum.SpecificEmails]
**Description** | **string** | The description of the email template. | [optional] 
**EmailBody** | **string** | The email body. You can add merge fields in the email object using angle brackets.  You can also embed HTML tags if &#x60;isHtml&#x60; is &#x60;true&#x60;. | 
**EmailSubject** | **string** | The email subject. Users can add merge fields in the email subject using angle brackets. | 
**EncodingType** | **string** | The endcode type of the email body. | [optional] [default to EncodingTypeEnum.UTF8]
**EventCategory** | **decimal** | If you specify this field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes.   | [optional] 
**EventTypeName** | **string** | The name of the custom event or custom scheduled event. If you specify this field, the email template is created based on the corresponding custom event or custom scheduled event.  | [optional] 
**EventTypeNamespace** | **string** | The namespace of the &#x60;eventTypeName&#x60; field. The &#x60;eventTypeName&#x60; has the &#x60;user.notification&#x60; namespace by default.   Note that if the &#x60;eventTypeName&#x60; is a standard event type, you must specify the &#x60;com.zuora.notification&#x60; namespace; otherwise, you will get an error.  For example, if you want to create an email template on the &#x60;OrderActionProcessed&#x60; event, you must specify &#x60;com.zuora.notification&#x60; for this field.           | [optional] 
**FromEmailAddress** | **string** | If fromEmailType is SpecificEmail, this field is required. | [optional] 
**FromEmailType** | **string** | The type of the email. | 
**FromName** | **string** | The name of the email sender. | [optional] 
**IsHtml** | **bool** | Indicates whether the style of email body is HTML. The default value is &#x60;false&#x60;. | [optional] [default to false]
**Name** | **string** | The name of the email template, a unique name in a tenant. | 
**ReplyToEmailAddress** | **string** | If replyToEmailType is SpecificEmail, this field is required. | [optional] 
**ReplyToEmailType** | **string** | Type of the replyTo email. | [optional] 
**ToEmailAddress** | **string** | If toEmailType is SpecificEmail, this field is required. | [optional] 
**ToEmailType** | **string** | Email receive type. * When the base object for the event is associated with &#x60;Account&#x60;, &#x60;toEmailType&#x60; can be any values in the enum list.  * When the base object for the event is not associated with &#x60;Account&#x60;, &#x60;toEmailType&#x60; must be &#x60;TenantAdmin&#x60;, &#x60;RunOwner&#x60;, or &#x60;SpecificEmail&#x60;.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

