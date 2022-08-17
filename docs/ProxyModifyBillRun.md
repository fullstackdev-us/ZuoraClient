# ZuoraClient.Model.ProxyModifyBillRun

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceDate** | **DateTime** | The new invoice date of all invoices invloved in the bill run, or the new memo date of all credit memos invloved in the bill run. The date cannot fall in a closed accounting period.  This field takes effect only when &#x60;Status&#x60; is set to &#x60;Posted&#x60;.  **Note**: The Credit and Debit Memos feature is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   | [optional] 
**Status** | **string** | The status for this bill run. See [Status Types](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/G_Bill_Runs#Status_Types) for more information.  To cancel a bill run, specify &#x60;Canceled&#x60;. To post a bill run, specify &#x60;Posted&#x60;.  **Character limit:** 20  **Values:**     * &#x60;Pending&#x60;   * &#x60;Processing&#x60;   * &#x60;Completed&#x60;   * &#x60;Error&#x60;   * &#x60;Canceled&#x60;   * &#x60;Posted&#x60;  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

