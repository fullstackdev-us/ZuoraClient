# ZuoraClient.Model.ProxyModifyInvoice

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RegenerateInvoicePDF** | **bool** | Whether to regenerate a PDF file for an invoice that already has PDF files generated.   This field is valid only if you enable the billing document file generation feature. To enable this feature, you have to select the **Enable the billing document generation** check box after navigating to **Billing** &gt; **Manage Billing Document Configuration** through the Zuora UI. Otherwise, the request is rejected.   For one specific invoice, you can use this field to regenerate PDF files for a maximum of 100 times.  **Note**: If you set this field to &#x60;true&#x60;, you cannot update any other fields in the same update request. Otherwise, you will receive the following INVALID_VALUE error:  \&quot;When field RegenerateInvoicePDF is set to true to regenerate the invoice PDF file, changes on other fields of the invoice are not allowed.\&quot;  | [optional] 
**Status** | **string** | The status of the invoice in the system. This status is not the status of the payment of the invoice, just the status of the invoice itself.  With the [Cancel Posted Billing Documents](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions) billing permission, you can directly update the status of an invoice from Posted to Draft.   **Character limit**: 8  **Values**: one of the following:    -  Draft (default, automatically set upon invoice creation)    -  Posted    -  Canceled  | [optional] 
**TransferredToAccounting** | **string** |  Specifies whether or not the invoice was transferred to an external accounting system, such as NetSuite. **Character limit**: 10 **Values**: Processing, Yes, Error, Ignore  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the invoice&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the invoice was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

