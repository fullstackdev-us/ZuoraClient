# ZuoraClient.Model.POSTOrderRequestType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Order object.  | [optional] 
**Description** | **string** | A description of the order. | [optional] 
**ExistingAccountNumber** | **string** | The account number that this order will be created under. It can be either the accountNumber or the account info provided. It will return an error if both are specified. Note that this actually specifies the invoice owner account of the subscriptions included in this order.  | [optional] 
**ExternallyManagedBy** | **string** | An enum field on the Subscription object to indicate the name of a third-party store. This field is used to represent subscriptions created through third-party stores.  | [optional] 
**NewAccount** | [**Account**](Account.md) |  | [optional] 
**OrderDate** | **DateTime** | The date when the order is signed. All the order actions under this order will use this order date as the contract effective date if the contract effective date field is skipped or its value is left as null. | 
**OrderLineItems** | [**List&lt;CreateOrderOrderLineItem&gt;**](CreateOrderOrderLineItem.md) | [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) are non subscription based items created by an Order, representing transactional charges such as one-time fees, physical goods, or professional service charges that are not sold as subscription services.   With the Order Line Items feature enabled, you can now launch non-subscription and unified monetization business models in Zuora, in addition to subscription business models.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          | [optional] 
**OrderNumber** | **string** | The order number of the new order. If not provided, system will auto-generate a number for this order. | [optional] 
**ProcessingOptions** | [**ProcessingOptionsOrders**](ProcessingOptionsOrders.md) |  | [optional] 
**Subscriptions** | [**List&lt;POSTOrderAsyncRequestTypeSubscriptionsInner&gt;**](POSTOrderAsyncRequestTypeSubscriptionsInner.md) | Each item includes a set of order actions, which will be applied to the same base subscription. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

