# ZuoraClient.Model.PUTPublicEmailTemplateRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the email template. | [optional] 
**BccEmailAddress** | **string** | Email bcc address. | [optional] 
**CcEmailAddress** | **string** | Email cc address. | [optional] 
**CcEmailType** | **string** | Email CC type. * When the base object for the event is associated with &#x60;Account&#x60;, &#x60;ccEmailType&#x60; can be any values in the enum list.  * When the base object for the event is not associated with &#x60;Account&#x60;, &#x60;ccEmailType&#x60; must be &#x60;TenantAdmin&#x60;, &#x60;RunOwner&#x60;, or &#x60;SpecificEmail&#x60;.  | [optional] [default to CcEmailTypeEnum.SpecificEmails]
**Description** | **string** | The description of the email template. | [optional] 
**EmailBody** | **string** | The email body. You can add merge fields in the email object using angle brackets.  User can also embed html tags if &#x60;isHtml&#x60; is &#x60;true&#x60;. | [optional] 
**EmailSubject** | **string** | The email subject. You can add merge fields in the email subject using angle brackets. | [optional] 
**EncodingType** | **string** | The endcode type of the email body. | [optional] 
**FromEmailAddress** | **string** | If fromEmailType is SpecificEmail, this field is required | [optional] 
**FromEmailType** | **string** | The type of fromEmail. | [optional] 
**FromName** | **string** | The name of email sender. | [optional] 
**IsHtml** | **bool** | Indicates whether the style of email body is HTML. | [optional] 
**Name** | **string** | The name of the email template. | [optional] 
**ReplyToEmailAddress** | **string** | If replyToEmailType is SpecificEmail, this field is required. | [optional] 
**ReplyToEmailType** | **string** | The type of the reply email. | [optional] 
**ToEmailAddress** | **string** | If toEmailType is SpecificEmail, this field is required. | [optional] 
**ToEmailType** | **string** | Email receive type. * When the base object for the event is associated with &#x60;Account&#x60;, &#x60;toEmailType&#x60; can be any values in the enum list.  * When the base object for the event is not associated with &#x60;Account&#x60;, &#x60;toEmailType&#x60; must be &#x60;TenantAdmin&#x60;, &#x60;RunOwner&#x60;, or &#x60;SpecificEmail&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

