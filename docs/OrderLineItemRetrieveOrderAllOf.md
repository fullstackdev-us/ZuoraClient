# ZuoraClient.Model.OrderLineItemRetrieveOrderAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AmendedByOrderOn** | **string** | The date when the rate plan charge is amended through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue.  | [optional] 
**Amount** | **decimal** | The calculated gross amount for the Order Line Item.  | [optional] 
**AmountWithoutTax** | **decimal** | The calculated gross amount for an order line item excluding tax. If the tax mode is tax exclusive, the value of this field equals that of the &#x60;amount&#x60; field.  If the tax mode of an order line item is not set, the system treats it as tax exclusive by default. The value of the &#x60;amountWithoutTax&#x60; field equals that of the &#x60;amount&#x60; field.  If you create an order line item from the product catalog, the tax mode and tax code of the product rate plan charge are used for the order line item by default. You can still overwrite this default set-up by setting the tax mode and tax code of the order line item.  | [optional] 
**Id** | **Guid** | The sytem generated Id for the Order Line Item.  | [optional] 
**ItemNumber** | **string** | The number for the Order Line Item.  | [optional] 
**OriginalOrderDate** | **DateTime** | The date when the rate plan charge is created through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

