# ZuoraClient.Model.PreviewAccountInfo
Information about the account that will own the order. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BillCycleDay** | **int** | Day of the month that the account prefers billing periods to begin on. If set to 0, the bill cycle day will be set as \&quot;AutoSet\&quot;. | 
**Currency** | **string** | ISO 3-letter currency code (uppercase). For example, USD.  | 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Account object.  | [optional] 
**SoldToContact** | [**PreviewContactInfo**](PreviewContactInfo.md) |  | [optional] 
**TaxInfo** | [**TaxInfo**](TaxInfo.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

