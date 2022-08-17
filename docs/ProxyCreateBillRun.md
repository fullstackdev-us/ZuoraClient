# ZuoraClient.Model.ProxyCreateBillRun

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | ID of the account used for single account bill run.  This field is only required if you create ad hoc bill run for a single customer account.  **Character limit:** 32  | [optional] 
**AutoEmail** | **bool** | Determines whether to auto send email or not by this bill run once the bill run completes.  **Note:** You must enable the [Support Bill Run Auto-Post Billing](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Billing_Rules) rule to pass this field.  | [optional] [default to false]
**AutoPost** | **bool** | Determines whether to auto post bill run or not once the bill run completes.  **Note:** You must enable the [Support Bill Run Auto-Post Billing](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Billing_Rules) rule to pass this field.  | [optional] [default to false]
**AutoRenewal** | **bool** | Determines whether to auto renew subscription or not by this bill run once the bill run completes.  | [optional] [default to false]
**Batch** | **string** | Batch of accounts for this bill run.   When creating ad hoc bill run for multiple customer accounts, this field is only required if the &#x60;BillCycleDay&#x60;  field is not specified.  **Character limit:** 20  **Values:** AllBatches or Batchn where n is a number between 1 and 50.  | [optional] 
**Batches** | **string** | The specific batches of customer accounts to be included in the bill run.   You cannot set the &#x60;Batches&#x60; field to a value consisting of both &#x60;AllBatches&#x60; and &#x60;Batch&#x60;*n*. Otherwise, the &#x60;INVALID_VALUE&#x60; error occurs. For example, &#x60;AllBatches,Batch3&#x60; is an invalid value for this field. Batch of accounts for this bill run.   **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;102&#x60; or later. Otherwise, an error occurs.  **Character limit:** 20  **Values:** &#x60;AllBatches&#x60;, &#x60;Batch&#x60;*n* or an array of &#x60;Batch&#x60;*n* where *n* is a number between 1 and 50  | [optional] 
**BillCycleDay** | **string** | The day of the bill cycle.  When creating ad hoc bill run for multiple customer accounts, this field is only required if the &#x60;Batch&#x60; field is not specified.  **Character limit:** 32  **Values:** &#x60;AllBillCycleDays&#x60; or 01 - 31.  | [optional] 
**ChargeTypeToExclude** | **string** | Charge type or types to be excluded, separated with comma.  **Possible Values:** &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;, or a combination of these values.   **Character limit:** 50  | [optional] 
**InvoiceDate** | **DateTime** | Invoice date for this bill run.  **Character limit:** 29  | 
**NoEmailForZeroAmountInvoice** | **bool** | Determines whether to suppress email for invoices with zero total or not for this bill run once the bill run completes. (Do not email invoices with 0 Invoice Total).  | [optional] [default to false]
**TargetDate** | **DateTime** | Target date for this bill run. See [Create Bill Run](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/G_Bill_Runs/Creating_Bill_Runs) for more information.  **Character limit:** 29  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

