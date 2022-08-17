# ZuoraClient.Model.ProxyCreateCreditBalanceAdjustmentAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingCode** | **string** | An active accounting code in your Zuora [Chart of Accounts](https://knowledgecenter.zuora.com/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts).  The [accounting code](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/A_Product_Catalog_Concepts/Accounting_Codes) for the credit balance adjustment. Typically, an accounting code for a credit balance adjustment maps to a bank account in your accounting system.  | [optional] 
**AdjustmentDate** | **DateTime** | The date when the credit balance adjustment is applied.  With the Future Dated Credit Balance Adjustment feature enabled, you can use this field to specify when the credit balance adjustment is applied. If not specified, the value defaults to the latter date of the date when the API operation is called and the invoice date.  With the Future Dated Credit Balance Adjustment feature disabled, if no value is specified for this field, the value defaults to the date when the API operation is called. If you specify a value for this field, the value must be the date when the API operation is called.  | [optional] 
**Amount** | **double** | The amount of the adjustment.  | 
**Comment** | **string** | Your comments about the credit balance adjustment.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. Must be an existing [reason code](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/Reason_Codes_for_Payment_Operations) or empty. If you do not specify a value, Zuora uses the default reason code.  | [optional] 
**ReferenceId** | **string** | The ID of the payment that the credit balance adjustment is for.  | [optional] 
**SourceTransactionId** | **string** | The ID of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field.  The value of this field must be an invoice ID.  | [optional] 
**SourceTransactionNumber** | **string** | The number of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field.  The value of this field must be an invoice number.  | [optional] 
**Type** | **string** | Whether the credit balance adjustment increases or decrease the amount of the credit balance.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

