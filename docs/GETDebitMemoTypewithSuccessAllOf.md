# ZuoraClient.Model.GETDebitMemoTypewithSuccessAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account associated with the debit memo.  | [optional] 
**Amount** | **double** | The total amount of the debit memo.  | [optional] 
**AutoPay** | **bool** | Whether debit memos are automatically picked up for processing in the corresponding payment run.   By default, debit memos are automatically picked up for processing in the corresponding payment run.        | [optional] 
**Balance** | **double** | The balance of the debit memo.  | [optional] 
**BeAppliedAmount** | **double** | The applied amount of the debit memo.  | [optional] 
**BillToContactId** | **string** | The ID of the bill-to contact associated with the debit memo.  The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled.  | [optional] 
**CancelledById** | **string** | The ID of the Zuora user who cancelled the debit memo.  | [optional] 
**CancelledOn** | **DateTime** | The date and time when the debit memo was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Comment** | **string** | Comments about the debit memo.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the debit memo.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the debit memo was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10.  | [optional] 
**DebitMemoDate** | **DateTime** | The date when the debit memo takes effect, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-05-20.  | [optional] 
**DueDate** | **DateTime** | The date by which the payment for the debit memo is due, in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**Id** | **string** | The unique ID of the debit memo.  | [optional] 
**LatestPDFFileId** | **string** | The ID of the latest PDF file generated for the debit memo.  | [optional] 
**Number** | **string** | The unique identification number of the debit memo.  | [optional] 
**PaymentTerm** | **string** | The name of the payment term assoicated with the debit memo.  The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled.  | [optional] 
**PostedById** | **string** | The ID of the Zuora user who posted the debit memo.  | [optional] 
**PostedOn** | **DateTime** | The date and time when the debit memo was posted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty.  | [optional] 
**ReferredCreditMemoId** | **string** | The ID of the credit memo from which the debit memo was created.  | [optional] 
**ReferredInvoiceId** | **string** | The ID of a referred invoice.  | [optional] 
**SourceType** | **string** | The type of the debit memo source.  | [optional] 
**Status** | **string** | The status of the debit memo.   | [optional] 
**TargetDate** | **DateTime** | The target date for the debit memo, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-07-20.  | [optional] 
**TaxAmount** | **double** | The amount of taxation.  | [optional] 
**TaxMessage** | **string** | The message about the status of tax calculation related to the debit memo. If tax calculation fails in one debit memo, this field displays the reason for the failure.  | [optional] 
**TaxStatus** | **string** | The status of tax calculation related to the debit memo.  **Note**: This field is only applicable to tax calculation by third-party tax engines.  | [optional] 
**TotalTaxExemptAmount** | **double** | The calculated tax amount excluded due to the exemption.  | [optional] 
**TransferredToAccounting** | **string** | Whether the debit memo was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite.   | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the debit memo.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the debit memo was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-02 15:31:10.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

