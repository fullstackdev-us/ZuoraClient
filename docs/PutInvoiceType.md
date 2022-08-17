# ZuoraClient.Model.PutInvoiceType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoPay** | **bool** | Whether invoices are automatically picked up for processing in the corresponding payment run. By default, invoices are automatically picked up for processing in the corresponding payment run.  | [optional] 
**Comments** | **string** | Additional information related to the invoice that a Zuora user added to the invoice.  | [optional] 
**DueDate** | **DateTime** | The date by which the payment for this invoice is due.  | [optional] 
**InvoiceDate** | **DateTime** | The new invoice date of the invoice. The new invoice date cannot fall in a closed accounting period. You can only specify &#x60;invoiceDate&#x60; or &#x60;dueDate&#x60; in one request. Otherwise, an error occurs.  | [optional] 
**InvoiceItems** | [**List&lt;PutInvoiceItemType&gt;**](PutInvoiceItemType.md) | Container for invoice items, The maximum number of items is 1,000.  | [optional] 
**TransferredToAccounting** | **string** | Whether the invoice was transferred to an external accounting system.  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the invoice&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the invoice was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

