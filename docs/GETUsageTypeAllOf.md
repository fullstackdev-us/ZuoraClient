# ZuoraClient.Model.GETUsageTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | Customer account ID.  | [optional] 
**AccountName** | **string** | Customer account name.  | [optional] 
**AccountNumber** | **string** | Customer account number.  | [optional] 
**ChargeNumber** | **string** | Number of the rate-plan charge that pays for this usage.  | [optional] 
**Id** | **string** | Unique ID for the usage item.  | [optional] 
**Quantity** | **decimal** | Number of units used.  | [optional] 
**SourceName** | **string** | Source of the usage data. Possible values are: &#x60;Import&#x60;, &#x60;API&#x60;.  | [optional] 
**StartDateTime** | **DateTime** | Start date of the time period in which usage is tracked. Zuora uses this field value to determine the usage date.  | [optional] 
**Status** | **string** | Possible values are: &#x60;Importing&#x60;, &#x60;Pending&#x60;, &#x60;Processed&#x60;.  | [optional] 
**SubmissionDateTime** | **DateTime** | Date when usage was submitted.  | [optional] 
**SubscriptionNumber** | **string** | Number of the subscription covering this usage.  | [optional] 
**UniqueKey** | **string** | a customer-defined specific identifier of a usage record.  **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled. See [Upload usage record with unique key](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Prepaid_balance_transactions#Upload_usage_record_with_unique_key) for more information.  | [optional] 
**UnitOfMeasure** | **string** | Unit used to measure consumption.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

