# ZuoraClient.Model.PutInvoiceResponseType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account associated with the invoice.  | [optional] 
**Amount** | **decimal** | The total amount of the invoice.  | [optional] 
**AutoPay** | **bool** | Whether invoices are automatically picked up for processing in the corresponding payment run.   | [optional] 
**Balance** | **decimal** | The balance of the invoice.  | [optional] 
**CancelledById** | **string** | The ID of the Zuora user who cancelled the invoice.  | [optional] 
**CancelledOn** | **DateTime** | The date and time when the invoice was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Comment** | **string** | Comments about the invoice.   | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the invoice.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the invoice was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10.  | [optional] 
**CreditBalanceAdjustmentAmount** | **decimal** | **Note:** This filed is only available if you have the Credit Balance feature enabled and the Invoice Settlement feature disabled. The currency amount of the adjustment applied to the customer&#39;s credit balance.  | [optional] 
**Currency** | **string** | A currency defined in the web-based UI administrative settings.  | [optional] 
**Discount** | **decimal** | The discount of the invoice.  | [optional] 
**DueDate** | **DateTime** | The date by which the payment for this invoice is due.   | [optional] 
**Id** | **string** | The unique ID of the invoice.  | [optional] 
**InvoiceDate** | **DateTime** | The date on which to generate the invoice.  | [optional] 
**Number** | **string** | The unique identification number of the invoice.  | [optional] 
**PostedById** | **string** | The ID of the Zuora user who posted the invoice.  | [optional] 
**PostedOn** | **DateTime** | The date and time when the invoice was posted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.   | [optional] 
**Status** | **string** | The status of the invoice.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**TargetDate** | **DateTime** | The target date for the invoice, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-07-20.   | [optional] 
**TaxAmount** | **decimal** | The amount of taxation.  | [optional] 
**TotalTaxExemptAmount** | **decimal** | The calculated tax amount excluded due to the exemption.  | [optional] 
**TransferredToAccounting** | **string** | Whether the invoice was transferred to an external accounting system.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the invoice.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the invoice was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-02 15:36:10.  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the invoice&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the invoice was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

