# ZuoraClient.Model.PostInvoiceType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the account associated with the invoice.   You must specify either &#x60;accountNumber&#x60; or &#x60;accountId&#x60; for a customer account. If both of them are specified, they must refer to the same customer account.  | [optional] 
**AccountNumber** | **string** | The Number of the account associated with the invoice. You must specify either &#x60;accountNumber&#x60; or &#x60;accountId&#x60; for a customer account. If both of them are specified, they must refer to the same customer account.  | [optional] 
**AutoPay** | **bool** | Whether invoices are automatically picked up for processing in the corresponding payment run.  | [optional] [default to false]
**Comments** | **string** | Comments about the invoice.  | [optional] 
**DueDate** | **DateTime** | The date by which the payment for this invoice is due, in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**InvoiceDate** | **DateTime** | The date that appears on the invoice being created, in &#x60;yyyy-mm-dd&#x60; format. The value cannot fall in a closed accounting period.  | 
**InvoiceItems** | [**List&lt;PostInvoiceItemType&gt;**](PostInvoiceItemType.md) | Container for invoice items. The maximum number of invoice items is 1,000.  | [optional] 
**InvoiceNumber** | **string** | A customized invoice number with the following format requirements: - Max length: 16 characters - Acceptable characters: a-z,A-Z,0-9,-,_,  The value must be unique in the system, otherwise it may cause issues with bill runs and subscribe/amend. Check out [things to note and troubleshooting steps](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/IA_Invoices/Unified_Invoicing/Import_external_invoices_as_standalone_invoices?#Customizing_invoice_number).   | [optional] 
**Status** | **string** | The status of invoice. By default, the invoice status is Draft.  When creating an invoice, if you set this field to &#x60;Posted&#x60;, the invoice is created and posted directly.  | [optional] [default to StatusEnum.Draft]
**TransferredToAccounting** | **string** |  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the invoice&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the invoice was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

