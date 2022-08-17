# ZuoraClient.Model.SubscribeRequestSubscribeOptionsSubscribeInvoiceProcessingOptions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceDate** | **DateTime** |  | [optional] 
**InvoiceProcessingScope** | **string** | A string specifying the scope of the requested invoice. Possible values: * &#x60;Account&#x60; invoice for all subscriptions within the account - the default value. If the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature is enabled, invoices for order line items within the account will also be generated. * &#x60;Subscription&#x60; invoice for only the subscription being created in this call  | [optional] 
**InvoiceTargetDate** | **DateTime** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

