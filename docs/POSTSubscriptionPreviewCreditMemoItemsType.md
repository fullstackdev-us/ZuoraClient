# ZuoraClient.Model.POSTSubscriptionPreviewCreditMemoItemsType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AmountWithoutTax** | **double** | The credit memo item amount excluding tax.  | [optional] 
**ChargeAmount** | **double** | The amount of the credit memo item. For tax-inclusive credit memo items, the amount indicates the credit memo item amount including tax. For tax-exclusive credit memo items, the amount indicates the credit memo item amount excluding tax  | [optional] 
**ChargeDescription** | **string** | Description of this credit memo item.  | [optional] 
**ChargeName** | **string** | Name of this credit memo item.  | [optional] 
**ProductName** | **string** | Name of the product associated with this credit memo item.  | [optional] 
**ProductRatePlanChargeId** | **string** | ID of the product rate plan charge associated with this credit memo item.  | [optional] 
**Quantity** | **int** | Quantity of the charge associated with this credit memo item.  | [optional] 
**ServiceEndDate** | **DateTime** | End date of the service period for this credit memo item, as yyyy-mm-dd.  | [optional] 
**ServiceStartDate** | **DateTime** | Service start date of this credit memo item, as yyyy-mm-dd.  | [optional] 
**TaxAmount** | **double** | The tax amount of the credit memo item.  | [optional] 
**TaxationItems** | [**List&lt;POSTSubscriptionPreviewTaxationItemsType&gt;**](POSTSubscriptionPreviewTaxationItemsType.md) | List of taxation items. **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;315.0&#x60; or later.  | [optional] 
**UnitOfMeasure** | **string** | Unit used to measure consumption. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

