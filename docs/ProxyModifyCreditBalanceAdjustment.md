# ZuoraClient.Model.ProxyModifyCreditBalanceAdjustment

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ReasonCode** | **string** | A code identifying the reason for the transaction. Must be an existing [reason code](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/Reason_Codes_for_Payment_Operations) or empty.  | [optional] 
**Status** | **string** | The status of the credit balance adjustment.  | [optional] 
**TransferredToAccounting** | **string** | Status of the credit balance adjustment&#39;s transfer to an external accounting system, such as NetSuite.  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the credit balance adjustment&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the credit balance adjustment was sychronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

