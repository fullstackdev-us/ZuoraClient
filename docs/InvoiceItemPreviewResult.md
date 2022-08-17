# ZuoraClient.Model.InvoiceItemPreviewResult

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AdditionalInfo** | [**InvoiceItemPreviewResultAdditionalInfo**](InvoiceItemPreviewResultAdditionalInfo.md) |  | [optional] 
**AmountWithoutTax** | **decimal** |  | [optional] 
**AppliedToChargeNumber** | **string** | Available when the chargeNumber of the charge that discount applies to was specified in the request or when the order is amending an existing subscription. | [optional] 
**ChargeDescription** | **string** |  | [optional] 
**ChargeName** | **string** |  | [optional] 
**ChargeNumber** | **string** | Available when the chargeNumber was specified in the request or when the order is amending an existing subscription. | [optional] 
**OrderLineItemNumber** | **string** | A sequential number auto-assigned for each of order line items in a order, used as an index, for example, \&quot;1\&quot;. | [optional] 
**ProcessingType** | **string** |  | [optional] 
**ProductName** | **string** |  | [optional] 
**ProductRatePlanChargeId** | **string** |  | [optional] 
**ServiceEndDate** | **DateTime** |  | [optional] 
**ServiceStartDate** | **DateTime** |  | [optional] 
**SubscriptionNumber** | **string** |  | [optional] 
**TaxAmount** | **decimal** |  | [optional] 
**TaxationItems** | [**List&lt;InvoiceItemPreviewResultTaxationItemsInner&gt;**](InvoiceItemPreviewResultTaxationItemsInner.md) | List of taxation items.  **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;309.0&#x60; or later.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

