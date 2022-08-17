# ZuoraClient.Model.ProxyGetCreditBalanceAdjustment

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** |  The account ID of the credit balance&#39;s account. Zuora generates this value from the source transaction. **Character limit**: 32 **Values**: automatically generated from:  - CreditBalanceAdjustment.SourceTransactionId or - CreditBalanceAdjustment.SourceTransactionNumber  | [optional] 
**AccountingCode** | **string** |  The Chart of Accounts  | [optional] 
**AdjustmentDate** | **DateTime** |  The date when the credit balance adjustment is applied. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**Amount** | **double** |  The amount of the adjustment. **Character limit**: 16 **Values**: a valid currency amount  | [optional] 
**CancelledOn** | **DateTime** |  The date when the credit balance adjustment was canceled. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**Comment** | **string** |  Use this field to record comments about the credit balance adjustment. **Character limit**: 255 **Values**: a string of 255 characters or fewer  | [optional] 
**CreatedById** | **string** |  The user ID of the person who created the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date when the credit balance adjustmentwas generated. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**Number** | **string** |  A unique identifier for the credit balance adjustment. Zuora generates this number in the format, &lt;em&gt;CBA-xxxxxxxx&lt;/em&gt;, such as CBA-00375919. **Character limit**: 255 **Values**: automatically generated  | [optional] 
**ReasonCode** | **string** |  A code identifying the reason for the transaction. Must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code. **Character limit**: 32 **Values**: a valid reason code  | [optional] 
**ReferenceId** | **string** |  The ID of the payment that the credit balance adjustment is for. **Character limit**: 100 **Values**: a string of 100 characters or fewer  | [optional] 
**SourceTransactionId** | **string** |  The ID of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 32 **Values**: one of the following:  - InvoiceId - PaymentId - RefundId  | [optional] 
**SourceTransactionNumber** | **string** |  The number of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 50 **Values**: one of the following:  - InvoiceNumber - PaymentNumber - RefundNumber  | [optional] 
**SourceTransactionType** | **string** |  The source of the credit balance adjustment. **Character limit**: **Values**: automatically generated; one of the following:  - Invoice - Payment - Refund  | [optional] 
**Status** | **string** |  The status of the credit balance adjustment. **Character limit**: 9 **Values**: automatically generated; one of the following:  - Processed - Canceled  | [optional] 
**TransferredToAccounting** | **string** | Status of the credit balance adjustment&#39;s transfer to an external accounting system, such as NetSuite.  | [optional] 
**Type** | **string** | Create Query Filter | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the credit balance adjustment was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the credit balance adjustment&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the credit balance adjustment was sychronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

