# ZuoraClient.Model.PostInvoiceEmailRequestType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EmailAddresses** | **string** | The valid email addresses you want to email an invoice to. Use commas to separate email addresses. **Note:** This field is only applicable if you set the &#x60;useEmailTemplateSetting&#x60; field to &#x60;false&#x60;.  | [optional] 
**IncludeAdditionalEmailAddresses** | **bool** | Whether to send an invoice to the additional email addresses of the invoice account.  You can set the additional email addresses in the **Additional Email Addresses** field on the account detail page from the Zuora UI. See [Create a Customer Account](https://knowledgecenter.zuora.com/BC_Subscription_Management/Customer_Accounts/B_Create_a_Customer_Account#section_2) for more information.  | [optional] [default to false]
**UseEmailTemplateSetting** | **bool** | Indicates whether to email an invoice based on the email template setting.  If you set this field to &#x60;true&#x60;, the invoice is sent to the email addresses specified in the **To Email** field of the email template. The email template is the one you set in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. See [Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information about how to edit the **To Email** field in the email template.  | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

