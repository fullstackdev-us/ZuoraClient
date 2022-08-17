# ZuoraClient.Model.PostInvoiceResponseAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account associated with the invoice.  | [optional] 
**Amount** | **decimal** | The total amount of the invoice.  | [optional] 
**AmountWithoutTax** | **decimal** | The invoice amount excluding tax.  | [optional] 
**AutoPay** | **bool** | Whether invoices are automatically picked up for processing in the corresponding payment run.  | [optional] 
**Comments** | **string** | Comments about the invoice.  | [optional] 
**Discount** | **decimal** | the invoice discount amount.  | [optional] 
**DueDate** | **DateTime** | The date by which the payment for this invoice is due.  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude the invoice item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] 
**Id** | **string** | The unique ID of the invoice.  | [optional] 
**InvoiceDate** | **DateTime** | The date that appears on the invoice being created.  | [optional] 
**InvoiceNumber** | **string** | The unique identification number of the invoice.  | [optional] 
**Status** | **string** | The status of the invoice.  | [optional] 
**TaxAmount** | **decimal** | The amount of taxation.  | [optional] 
**TaxExemptAmount** | **decimal** | The calculated tax amount excluded due to the exemption.  | [optional] 
**TransferredToAccounting** | **string** | Whether the invoice was transferred to an external accounting system.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

