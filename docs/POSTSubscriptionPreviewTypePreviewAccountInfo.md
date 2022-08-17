# ZuoraClient.Model.POSTSubscriptionPreviewTypePreviewAccountInfo
A container for providing a customer account information if you do not have an existing customer account. This customer account information is only used for subscription preview.  You must specify the account information either in this field or in the `accountKey` field with the following conditions:  * If you already have a customer account, specify the account number or ID in the accountKey field. * If you do not have a customer account, provide account information in this field. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BillCycleDay** | **long** | The account&#39;s bill cycle day (BCD), when bill runs generate invoices for the account. Specify any day of the month (&#x60;1&#x60;-&#x60;31&#x60;, where &#x60;31&#x60; &#x3D; end-of-month), or &#x60;0&#x60; for auto-set.  | 
**BillToContact** | [**POSTSubscriptionPreviewTypePreviewAccountInfoAllOfBillToContact**](POSTSubscriptionPreviewTypePreviewAccountInfoAllOfBillToContact.md) |  | 
**Currency** | **string** | A currency as defined in Billing Settings.  | 
**ClassNS** | **string** | Value of the Class field for the corresponding customer account in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**CustomerTypeNS** | **string** | Value of the Customer Type field for the corresponding customer account in NetSuite. The Customer Type field is used when the customer account is created in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**DepartmentNS** | **string** | Value of the Department field for the corresponding customer account in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the account&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**LocationNS** | **string** | Value of the Location field for the corresponding customer account in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SubsidiaryNS** | **string** | Value of the Subsidiary field for the corresponding customer account in NetSuite. The Subsidiary field is required if you use NetSuite OneWorld. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the account was sychronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SynctoNetSuiteNS** | **string** | Specifies whether the account should be synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

