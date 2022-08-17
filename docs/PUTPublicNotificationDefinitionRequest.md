# ZuoraClient.Model.PUTPublicNotificationDefinitionRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the notification definition. The default value is &#x60;true&#x60;. | [optional] [default to true]
**AssociatedAccount** | **string** | Indicates with which type of account this notification is associated. Depending on your environment, you can use one of the following values: * &#x60;Account.Id&#x60;: ID of the primary customer account related to the notification. It is also the default value. * &#x60;ParentAccount.Id&#x60;: this option is available only if you have [Customer Hierarchy](https://knowledgecenter.zuora.com/Billing/Subscriptions/Customer_Accounts/A_Customer_Account_Introduction#Customer_Hierarchy) enabled for your tenant. * &#x60;SubscriptionOwnerAccount.Id&#x60;: this option is available if the base object of the notification is Order Action.  **Note:** before specifying this field, we recommend that you use [Data Source](https://knowledgecenter.zuora.com/Billing/Reporting/D_Data_Sources_and_Exports/C_Data_Source_Reference) to check the available types of accounts for the current notification.    | [optional] 
**Callout** | [**PUTPublicNotificationDefinitionRequestCallout**](PUTPublicNotificationDefinitionRequestCallout.md) |  | [optional] 
**CalloutActive** | **bool** | The status of the callout action. The default value is &#x60;false&#x60;. | [optional] [default to false]
**CommunicationProfileId** | **Guid** | The profile that notification definition belongs to. If you want to update the notification to a system notification, you should pass &#39;SystemNotification&#39;. &#39;  | [optional] 
**Description** | **string** | The description of the notification definition. | [optional] 
**EmailActive** | **bool** | The status of the email action. The default value is &#x60;false&#x60;. | [optional] [default to false]
**EmailTemplateId** | **Guid** | The ID of the email template. If emailActive is updated from false to true, an email template is required, and the EventType of the email template MUST be the same as the EventType of the notification definition.  | [optional] 
**FilterRule** | [**PUTPublicNotificationDefinitionRequestFilterRule**](PUTPublicNotificationDefinitionRequestFilterRule.md) |  | [optional] 
**FilterRuleParams** | **Dictionary&lt;string, string&gt;** | The parameter values used to configure the filter rule.  | [optional] 
**Name** | **string** | The name of the notification definition, which is unique in the profile. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

