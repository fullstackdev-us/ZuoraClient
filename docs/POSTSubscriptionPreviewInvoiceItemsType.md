# ZuoraClient.Model.POSTSubscriptionPreviewInvoiceItemsType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ChargeAmount** | **decimal** | The amount of the charge. This amount doesn&#39;t include taxes unless the charge&#39;s tax mode is inclusive.  | [optional] 
**ChargeDescription** | **string** | Description of the charge.  | [optional] 
**ChargeName** | **string** | Name of the charge.  | [optional] 
**ProductName** | **string** | Name of the product associated with this item.  | [optional] 
**ProductRatePlanChargeId** | **string** | ID of the product rate plan charge.  | [optional] 
**Quantity** | **decimal** | Quantity of this item.  | [optional] 
**ServiceEndDate** | **DateTime** | End date of the service period for this item, i.e., the last day of the period, as yyyy-mm-dd.  | [optional] 
**ServiceStartDate** | **DateTime** | Service start date as yyyy-mm-dd. If the charge is a one-time fee, this is the date of that charge.  | [optional] 
**TaxAmount** | **double** | The tax amount of the invoice item.  | [optional] 
**TaxationItems** | [**List&lt;POSTSubscriptionPreviewTaxationItemsType&gt;**](POSTSubscriptionPreviewTaxationItemsType.md) | List of taxation items. **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;315.0&#x60; or later.  | [optional] 
**UnitOfMeasure** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

