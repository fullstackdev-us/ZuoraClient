# ZuoraClient.Model.ProxyGetUsageAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** |  The ID of the account associated with the usage data. This field is required if no value is specified for the &#x60;AccountNumber&#x60; field. **Character limit**: 32 **Values**: a valid account ID  | [optional] 
**AccountNumber** | **string** |  The number of the account associated with the usage data. This field is required if no value is specified for the &#x60;AccountId&#x60; field. **Character limit**: 50 **Values**: a valid account number  | [optional] 
**ChargeId** | **string** |  The OrginalId of the rate plan charge related to the usage record, e.g., &#x60;2c9081a03c63c94c013c6873357a0117&#x60; **Character limit**: 32 **Values**: a valid rate plan charge OriginalID  | [optional] 
**CreatedById** | **string** |  The user ID of the person who uploaded the usage records. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date when the usage was generated. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**Description** | **string** | A description of the usage record.  | [optional] 
**EndDateTime** | **DateTime** |  The end date and time of a range of time when usage is tracked. Use this field for reporting; this field doesn&#39;t affect usage calculation. **Character limit**: 29 **Values**: a valid date and time value  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**Quantity** | **double** |  Indicates the number of units used. **Character limit**: 16 **Values**: a valid decimal amount equal to or greater than 0  | [optional] 
**RbeStatus** | **string** |  Indicates if the rating and billing engine (RBE) processed usage data for an invoice. **Character limit**: 9 **Values**: automatically generated to be one of the following values: &#x60;Importing&#x60;, &#x60;Pending&#x60;, &#x60;Processed&#x60;  | [optional] 
**SourceType** | **string** |  Indicates if the usage records were imported from the web-based UI or the API. **Character limit**: 6 **Values**: automatically generated to be one of the following values: &#x60;API&#x60;, &#x60;Import&#x60;  | [optional] 
**StartDateTime** | **DateTime** |  The start date and time of a range of time when usage is tracked. Zuora uses this field value to determine the usage date. Unlike the &#x60;EndDateTime&#x60;, the &#x60;StartDateTime&#x60; field does affect usage calculation. **Character limit**: 29 **Values**: a valid date and time value  | [optional] 
**SubmissionDateTime** | **DateTime** |  The date when usage was submitted. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**SubscriptionId** | **string** |  The original ID of the subscription that contains the fees related to the usage data. **Character limit**: 32 **Values**: a valid subscription ID  | [optional] 
**SubscriptionNumber** | **string** | The unique identifier number of the subscription that contains the fees related to the usage data.  | [optional] 
**UOM** | **string** |  Specifies the units to measure usage. Units of measure are configured in the web-based UI. Your values depend on your configuration in **Billing Settings**. **Character limit**: **Values**: a valid unit of measure  | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the usage upload. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the usage upload was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

