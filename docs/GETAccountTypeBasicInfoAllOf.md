# ZuoraClient.Model.GETAccountTypeBasicInfoAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountNumber** | **string** | Account number.  | [optional] 
**Batch** | **string** | The alias name given to a batch. A string of 50 characters or less.  | [optional] 
**CommunicationProfileId** | **string** | ID of a communication profile.  | [optional] 
**CreditMemoTemplateId** | **string** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  The unique ID of the credit memo template, configured in **Billing Settings** &gt; **Manage Billing Document Configuration** through the Zuora UI. For example, 2c92c08a6246fdf101626b1b3fe0144b.  | [optional] 
**CrmId** | **string** | CRM account ID for the account, up to 100 characters.  | [optional] 
**DebitMemoTemplateId** | **string** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  The unique ID of the debit memo template, configured in **Billing Settings** &gt; **Manage Billing Document Configuration** through the Zuora UI. For example, 2c92c08d62470a8501626b19d24f19e2.  | [optional] 
**Id** | **string** | Account ID.  | [optional] 
**InvoiceTemplateId** | **string** | Invoice template ID, configured in Billing Settings in the Zuora UI.  | [optional] 
**Name** | **string** | Account name.  | [optional] 
**Notes** | **string** | Notes associated with the account, up to 65,535 characters.  | [optional] 
**ParentId** | **string** | Identifier of the parent customer account for this Account object. The length is 32 characters. Use this field if you have customer hierarchy enabled. | [optional] 
**SalesRep** | **string** | The name of the sales representative associated with this account, if applicable. Maximum of 50 characters. | [optional] 
**SequenceSetId** | **string** | The ID of the billing document sequence set that is assigned to the customer account.   | [optional] 
**Status** | **string** | Account status; possible values are: &#x60;Active&#x60;, &#x60;Draft&#x60;, &#x60;Canceled&#x60;.  | [optional] 
**Tags** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

