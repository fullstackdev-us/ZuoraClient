# ZuoraClient.Model.POSTPublicNotificationDefinitionRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the notification definition. The default value is &#x60;true&#x60;. | [optional] [default to true]
**AssociatedAccount** | **string** | Indicates with which type of account this notification is associated. Depending on your environment, you can use one of the following values: * &#x60;Account.Id&#x60;: ID of the primary customer account related to the notification. It is also the default value. * &#x60;ParentAccount.Id&#x60;: this option is available only if you have [Customer Hierarchy](https://knowledgecenter.zuora.com/Billing/Subscriptions/Customer_Accounts/A_Customer_Account_Introduction#Customer_Hierarchy) enabled for your tenant. * &#x60;SubscriptionOwnerAccount.Id&#x60;: this option is available if the base object of the notification is Order Action.  **Note:** before specifying this field, we recommend that you use [Data Source](https://knowledgecenter.zuora.com/Billing/Reporting/D_Data_Sources_and_Exports/C_Data_Source_Reference) to check the available types of accounts for the current notification.    | [optional] 
**Callout** | [**POSTPublicNotificationDefinitionRequestCallout**](POSTPublicNotificationDefinitionRequestCallout.md) |  | [optional] 
**CalloutActive** | **bool** | The status of the callout action. The default value is &#x60;false&#x60;. | [optional] [default to false]
**CommunicationProfileId** | **string** | The profile that notification definition belongs to.   You can use the [Query Action](https://www.zuora.com/developer/api-reference/#operation/Action_POSTquery) to get the communication profile Id. See the following request sample:  &#x60;{     \&quot;queryString\&quot;: \&quot;select Id, ProfileName from CommunicationProfile\&quot;  }&#x60;  If you do not pass the communicationProfileId, notification service will be automatically added to the &#39;Default Profile&#39;.  | [optional] 
**Description** | **string** | The description of the notification definition. | [optional] 
**EmailActive** | **bool** | The status of the email action. The default value is &#x60;false&#x60;. | [optional] [default to false]
**EmailTemplateId** | **Guid** | The ID of the email template. If &#x60;emailActive&#x60; is &#x60;true&#x60;, an email template is required. And EventType of the email template MUST be the same as the eventType. | [optional] 
**EventTypeName** | **string** | The name of the event type.   | 
**EventTypeNamespace** | **string** | The namespace of the &#x60;eventTypeName&#x60; field. The &#x60;eventTypeName&#x60; has the &#x60;user.notification&#x60; namespace by default.             For example, if you want to create a notification definition on the &#x60;OrderActionProcessed&#x60; event, you must specify &#x60;com.zuora.notification&#x60; for this field.  | [optional] 
**FilterRule** | [**POSTPublicNotificationDefinitionRequestFilterRule**](POSTPublicNotificationDefinitionRequestFilterRule.md) |  | [optional] 
**FilterRuleParams** | **Dictionary&lt;string, string&gt;** | The parameter values used to configure the filter rule.  | [optional] 
**Name** | **string** | The name of the notification definition, unique per communication profile. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

