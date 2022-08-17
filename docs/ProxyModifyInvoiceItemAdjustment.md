# ZuoraClient.Model.ProxyModifyInvoiceItemAdjustment

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude Order Line Item related invoice items, invoice item adjustments, credit memo items, and debit memo items that are generate for the rate plan charge from revenue accounting. Set this field to &#x60;true&#x60; to exclude the billing item from the revenue accounting.   **Character limit**: 100     **Version notes**: WSDL 117.0+   **Values**: a boolean value  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  | [optional] [default to false]
**ReasonCode** | **string** |  A code identifying the reason for the transaction. Must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code. **Character limit**: 32 **Values**: a valid reason code  | [optional] 
**Status** | **string** |  The status of the invoice item adjustment. This field is required in the Query call, but is automatically generated in other calls. **Character limit**: 9 **Values**: Canceled, Processed  | [optional] 
**TransferredToAccounting** | **string** | Indicates the status of the adjustment&#39;s transfer to an external accounting system, such as NetSuite.  | [optional] 
**InvoiceItemAdjustmentIntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**InvoiceItemAdjustmentIntegrationStatusNS** | **string** | Status of the invoice item adjustment&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**InvoiceItemAdjustmentSyncDateNS** | **string** | Date when the invoice item adjustment was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

