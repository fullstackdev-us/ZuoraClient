# ZuoraClient.Model.GETPaymentRunType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account associated with the payment run.  | [optional] 
**ApplyCreditBalance** | **bool** | **Note:** This field is only available if you have the Credit Balance feature enabled and the Invoice Settlement feature disabled.  Whether to apply credit balances in the payment run. This field is only available when you have Invoice Settlement feature disabled.  | [optional] 
**AutoApplyCreditMemo** | **bool** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Whether to automatically apply a posted credit memo to one or more receivables in the payment run.  | [optional] 
**AutoApplyUnappliedPayment** | **bool** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Whether to automatically apply unapplied payments to  one or more receivables in the payment run.  | [optional] 
**Batch** | **string** | The alias name given to a batch.  | [optional] 
**BillCycleDay** | **string** | The billing cycle day (BCD), the day of the month when a bill run generates invoices for the account.   | [optional] 
**BillingRunId** | **Guid** | The ID of the bill run.  | [optional] 
**CollectPayment** | **bool** | Whether to process electronic payments during the execution of payment runs.   | [optional] 
**CompletedOn** | **DateTime** | The date and time when the payment run is completed, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 11:39:58.  | [optional] 
**ConsolidatedPayment** | **bool** | **Note:** The **Process Electronic Payment** permission also needs to be allowed for a Manage Payment Runs role to work. See [Payments Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/e_Payments_Roles) for more information.   Whether to process a single payment for all receivables that are due on an account.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the payment run.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the payment run was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10.  | [optional] 
**Currency** | **string** | A currency defined in the web-based UI administrative settings.  | [optional] 
**ExecutedOn** | **DateTime** | The date and time when the payment run is executed, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 11:30:37.  | [optional] 
**Id** | **string** | The ID of the payment run.  | [optional] 
**Number** | **string** | The identification number of the payment run.  | [optional] 
**PaymentGatewayId** | **Guid** | The ID of the gateway instance that processes the payment.  | [optional] 
**ProcessPaymentWithClosedPM** | **bool** | **Note:** The **Process Electronic Payment** permission also needs to be allowed for a Manage Payment Runs role to work. See [Payments Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/e_Payments_Roles) for more information.   Whether to process payments even if the default payment method is closed.  | [optional] 
**RunDate** | **DateTime** | The date and time when the scheduled payment run is to be executed for collecting payments.  | [optional] 
**Status** | **string** | The status of the created payment run.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TargetDate** | **DateTime** | The target date used to determine which receivables to be collected in the payment run.   | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the payment run.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the payment run was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-02 15:36:10.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

