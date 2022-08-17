# ZuoraClient.Model.ProxyCreateUsage

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** |  The ID of the account associated with the usage data. This field is only required if no value is specified for the &#x60;AccountNumber&#x60; field. **Character limit**: 32 **Values**: a valid account ID.  | [optional] 
**AccountNumber** | **string** |  The number of the account associated with the usage data. This field is only required if no value is specified for the &#x60;AccountId&#x60; field. **Character limit**: 50 **Values**: a valid account number.  | [optional] 
**ChargeId** | **string** |  The OrginalId of the rate plan charge related to the usage record, e.g., &#x60;2c9081a03c63c94c013c6873357a0117&#x60; **Character limit**: 32 **Values**: a valid rate plan charge OriginalID.  | [optional] 
**ChargeNumber** | **string** | A unique number for the rate plan charge related to the usage record. For example, C-00000007.  | [optional] 
**Description** | **string** | A description of the usage record.  | [optional] 
**EndDateTime** | **DateTime** |  The end date and time of a range of time when usage is tracked. Use this field for reporting; this field doesn&#39;t affect usage calculation. **Character limit**: 29 **Values**: a valid date and time value.  | [optional] 
**Quantity** | **double** |  Indicates the number of units used. **Character limit**: 16 **Values**: a valid decimal amount equal to or greater than 0  | 
**StartDateTime** | **DateTime** |  The start date and time of a range of time when usage is tracked. Zuora uses this field value to determine the usage date. Unlike the &#x60;EndDateTime&#x60;, the &#x60;StartDateTime&#x60; field does affect usage calculation. **Character limit**: 29 **Values**: a valid date and time value  | 
**SubmissionDateTime** | **DateTime** |  The date when usage was submitted. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**SubscriptionId** | **string** | The original ID of the subscription that contains the fees related to the usage data.   The ID of a subscription might change when you create amendments to the subscription. It is good practice to use the unique subscription number that you can specify in the &#x60;SubscriptionNumber&#x60; field.  | [optional] 
**SubscriptionNumber** | **string** | The unique identifier number of the subscription that contains the fees related to the usage data.  It is good practice to use this field when creating usage records.  | [optional] 
**UOM** | **string** |  Specifies the units to measure usage. Units of measure are configured in the web-based UI. Your values depend on your configuration in **Billing Settings**. **Character limit**: **Values**: a valid unit of measure  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

