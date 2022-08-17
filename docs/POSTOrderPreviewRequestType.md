# ZuoraClient.Model.POSTOrderPreviewRequestType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Order object.  | [optional] 
**Description** | **string** | A description of the order. | [optional] 
**ExistingAccountNumber** | **string** | The account number that this order will be created under. It can be either the accountNumber or the account info. It will return an error if both are specified. Note that invoice owner account of the subscriptions included in this order should be the same with the account of the order.  | [optional] 
**OrderDate** | **DateTime** | The date when the order is signed. All of the order actions under this order will use this order date as the contract effective date. | 
**OrderLineItems** | [**List&lt;CreateOrderOrderLineItem&gt;**](CreateOrderOrderLineItem.md) | [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) are non subscription based items created by an Order, representing transactional charges such as one-time fees, physical goods, or professional service charges that are not sold as subscription services.   With the Order Line Items feature enabled, you can now launch non-subscription and unified monetization business models in Zuora, in addition to subscription business models.   **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          | [optional] 
**OrderNumber** | **string** | The order number of this order. | [optional] 
**PreviewAccountInfo** | [**PreviewAccountInfo**](PreviewAccountInfo.md) |  | [optional] 
**PreviewOptions** | [**PreviewOptions**](PreviewOptions.md) |  | 
**Subscriptions** | [**List&lt;POSTOrderPreviewAsyncRequestTypeSubscriptionsInner&gt;**](POSTOrderPreviewAsyncRequestTypeSubscriptionsInner.md) | Each item includes a set of order actions, which will be applied to the same base subscription. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

