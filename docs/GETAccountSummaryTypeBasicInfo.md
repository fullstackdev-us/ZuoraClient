# ZuoraClient.Model.GETAccountSummaryTypeBasicInfo
Container for basic information about the account. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountNumber** | **string** | Account number.  | [optional] 
**AdditionalEmailAddresses** | **List&lt;string&gt;** | A list of additional email addresses to receive email notifications.  | [optional] 
**Balance** | **decimal** | Current outstanding balance.  | [optional] 
**Batch** | **string** | The alias name given to a batch. A string of 50 characters or less.  | [optional] 
**BillCycleDay** | **string** | Billing cycle day (BCD), the day of the month when a bill run generates invoices for the account.  | [optional] 
**Currency** | **string** | A currency as defined in Billing Settings in the Zuora UI.  | [optional] 
**DefaultPaymentMethod** | [**GETAccountSummaryTypeBasicInfoAllOfDefaultPaymentMethod**](GETAccountSummaryTypeBasicInfoAllOfDefaultPaymentMethod.md) |  | [optional] 
**Id** | **string** | Account ID.  | [optional] 
**InvoiceDeliveryPrefsEmail** | **bool** | Whether the customer wants to receive invoices through email.   | [optional] 
**InvoiceDeliveryPrefsPrint** | **bool** | Whether the customer wants to receive printed invoices, such as through postal mail.  | [optional] 
**LastInvoiceDate** | **DateTime** | Date of the most recent invoice for the account; null if no invoice has ever been generated.  | [optional] 
**LastPaymentAmount** | **decimal** | Amount of the most recent payment collected for the account; null if no payment has ever been collected.  | [optional] 
**LastPaymentDate** | **DateTime** | Date of the most recent payment collected for the account. Null if no payment has ever been collected.  | [optional] 
**Name** | **string** | Account name.  | [optional] 
**Status** | **string** | Account status; possible values are: &#x60;Active&#x60;, &#x60;Draft&#x60;, &#x60;Canceled&#x60;.  | [optional] 
**Tags** | **string** |  | [optional] 
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

