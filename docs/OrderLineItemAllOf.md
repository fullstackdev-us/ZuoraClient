# ZuoraClient.Model.OrderLineItemAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **decimal** | The calculated gross amount for the Order Line Item.  | [optional] 
**AmountWithoutTax** | **decimal** | The calculated gross amount for an order line item excluding tax. If the tax mode is tax exclusive, the value of this field equals that of the &#x60;amount&#x60; field.  If the tax mode of an order line item is not set, the system treats it as tax exclusive by default. The value of the &#x60;amountWithoutTax&#x60; field equals that of the &#x60;amount&#x60; field.  If you create an order line item from the product catalog, the tax mode and tax code of the product rate plan charge are used for the order line item by default. You can still overwrite this default set-up by setting the tax mode and tax code of the order line item.  | [optional] 
**Id** | **Guid** | The sytem generated Id for the Order Line Item.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

