# ZuoraClient.Model.POSTBillingPreviewInvoiceItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AppliedToItemId** | **string** | The unique ID of the invoice item that the discount charge is applied to.  | [optional] 
**ChargeAmount** | **decimal** | The amount of the charge. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive.  | [optional] 
**ChargeDate** | **DateTime** | The date when the invoice item was created.  | [optional] 
**ChargeDescription** | **string** | Description of the charge.  | [optional] 
**ChargeId** | **string** | Id of the charge.  | [optional] 
**ChargeName** | **string** | Name of the charge.  | [optional] 
**ChargeNumber** | **string** | Number of the charge.  | [optional] 
**ChargeType** | **string** | The type of charge.   Possible values are &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, and &#x60;Usage&#x60;.  | [optional] 
**Id** | **string** | Invoice item ID.  | [optional] 
**ProcessingType** | **string** | Identifies the kind of charge.   Possible values: * charge * discount * prepayment * tax | [optional] 
**ProductName** | **string** | Name of the product associated with this item.  | [optional] 
**Quantity** | **decimal** | Quantity of this item, in the configured unit of measure for the charge.  | [optional] 
**ServiceEndDate** | **DateTime** | End date of the service period for this item, i.e., the last day of the service period, in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**ServiceStartDate** | **DateTime** | Start date of the service period for this item, in &#x60;yyyy-mm-dd&#x60; format. If the charge is a one-time fee, this is the date of that charge.  | [optional] 
**SubscriptionId** | **string** | ID of the subscription associated with this item.  | [optional] 
**SubscriptionName** | **string** | Name of the subscription associated with this item.  | [optional] 
**SubscriptionNumber** | **string** | Number of the subscription associated with this item.  | [optional] 
**TaxAmount** | **decimal** | If you use [Zuora Tax](https://knowledgecenter.zuora.com/Billing/Taxes/A_Zuora_Tax) and the product rate plan charge associated with the invoice item is of [tax inclusive mode](https://knowledgecenter.zuora.com/Billing/Taxes/A_Zuora_Tax/D_Associate_tax_codes_with_product_charges_and_set_the_tax_mode), the value of this field is the amount of tax applied to the charge. Otherwise, the value of this field is &#x60;0&#x60;.   | [optional] 
**UnitOfMeasure** | **string** | Unit used to measure consumption.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

