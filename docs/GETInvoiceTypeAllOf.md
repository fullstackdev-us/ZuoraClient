# ZuoraClient.Model.GETInvoiceTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | Customer account ID.  | [optional] 
**AccountName** | **string** | Customer account name.  | [optional] 
**AccountNumber** | **string** | Customer account number.  | [optional] 
**Amount** | **decimal** | Amount of the invoice before adjustments, discounts, and similar items.  | [optional] 
**Balance** | **decimal** | Balance remaining due on the invoice (after adjustments, discounts, etc.)  | [optional] 
**Body** | **string** | The REST URL of the invoice PDF file.  | [optional] 
**CreatedBy** | **string** | User ID of the person who created the invoice. If a bill run generated the invoice, then this is the user ID of person who created the bill run.  | [optional] 
**CreditBalanceAdjustmentAmount** | **decimal** |  | [optional] 
**DueDate** | **DateTime** | Payment due date as _yyyy-mm-dd_.  | [optional] 
**Id** | **string** | Invoice ID.  | [optional] 
**InvoiceDate** | **DateTime** | Invoice date as _yyyy-mm-dd_  | [optional] 
**InvoiceFiles** | **string** | URL to retrieve information about all files of a specific invoice if any file exists; otherwise absent. For example, &#x60;https://rest.zuora.com/v1/invoices/2c92c095511f5b4401512682dcfd7987/files&#x60;. If you want to view the invoice file details, call [Get invoice files](https://www.zuora.com/developer/api-reference/#operation/GET_InvoiceFiles) with the returned URL.  If your tenant was created before Zuora Release 228 (R228), July 2018, the value of this field is an array of invoice file details. For more information about the array, see the response body of [Get invoice files](https://www.zuora.com/developer/api-reference/#operation/GET_InvoiceFiles).   Zuora recommends that you use the latest behavior to retrieve invoice information. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/) asking for invoice item and file references to be enabled in the REST API.  | [optional] 
**InvoiceItems** | **string** | URL to retrieve information about all items of a specific invoice. For example, &#x60;https://rest.zuora.com/v1/invoices/2c92c095511f5b4401512682dcfd7987/items&#x60;. If you want to view the invoice item details, call [Get invoice items](https://www.zuora.com/developer/api-reference/#operation/GET_InvoiceItems) with the returned URL.  If your tenant was created before Zuora Release 228 (R228), July 2018, the value of this field is an array of invoice item details. For more information about the array, see the response body of [Get invoice items](https://www.zuora.com/developer/api-reference/#operation/GET_InvoiceItems).   Zuora recommends that you use the latest behavior to retrieve invoice information. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/) asking for invoice item and file references to be enabled in the REST API.   | [optional] 
**InvoiceNumber** | **string** | Unique invoice ID, returned as a string.  | [optional] 
**InvoiceTargetDate** | **DateTime** | Date through which charges on this invoice are calculated, as _yyyy-mm-dd_.  | [optional] 
**Reversed** | **bool** | Whether the invoice is reversed.  | [optional] 
**Status** | **string** | Status of the invoice in the system - not the payment status, but the status of the invoice itself. Possible values are: &#x60;Posted&#x60;, &#x60;Draft&#x60;, &#x60;Canceled&#x60;, &#x60;Error&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

