# ZuoraClient.Model.POSTAccountingCodeTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**GlAccountName** | **string** | Name of the account in your general ledger.  Field only available if you have Zuora Finance enabled. Maximum of 255 characters.  | [optional] 
**GlAccountNumber** | **string** | Account number in your general ledger.  Field only available if you have Zuora Finance enabled. Maximum of 255 characters.  | [optional] 
**Name** | **string** | Name of the accounting code.  Accounting code name must be unique. Maximum of 100 characters.  | 
**Notes** | **string** | Maximum of 2,000 characters.  | [optional] 
**Type** | **string** | If you want to create multiple accounting codes of the type &#x60;AccountsReceivable&#x60;, you need to have [Invoice Item Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/C_Invoice_Item_Settlement) enabled and contact [Zuora Global Support](http://support.zuora.com) to access the Multiple AR Accounting Codes feature.   Note that &#x60;On-Account Receivable&#x60; is only available if you enable the Invoice Settlement feature.   | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

