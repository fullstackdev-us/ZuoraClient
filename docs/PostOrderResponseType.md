# ZuoraClient.Model.PostOrderResponseType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ProcessId** | **string** | The Id of the process that handle the operation.  | [optional] 
**Reasons** | [**List&lt;CommonResponseTypeReasonsInner&gt;**](CommonResponseTypeReasonsInner.md) |  | [optional] 
**Success** | **bool** | Indicates whether the call succeeded.  | [optional] 
**AccountId** | **string** | The account ID for the order. This field is returned instead of the &#x60;accountNumber&#x60; field if the &#x60;returnIds&#x60; query parameter is set to &#x60;true&#x60;. | [optional] 
**AccountNumber** | **string** | The account number for the order. | [optional] 
**CreditMemoIds** | **List&lt;string&gt;** | An array of the credit memo IDs generated in this order request. The credit memo is only available if you have the Invoice Settlement feature enabled. This field is returned instead of the &#x60;creditMemoNumbers&#x60; field if the &#x60;returnIds&#x60; query parameter is set to &#x60;true&#x60;. | [optional] 
**CreditMemoNumbers** | **List&lt;string&gt;** | An array of the credit memo numbers generated in this order request. The credit memo is only available if you have the Invoice Settlement feature enabled. | [optional] 
**InvoiceIds** | **List&lt;string&gt;** | An array of the invoice IDs generated in this order request. Normally it includes one invoice ID only, but can include multiple items when a subscription was tagged as invoice separately. This field is returned instead of the &#x60;invoiceNumbers&#x60; field if the &#x60;returnIds&#x60; query parameter is set to &#x60;true&#x60;. | [optional] 
**InvoiceNumbers** | **List&lt;string&gt;** | An array of the invoice numbers generated in this order request. Normally it includes one invoice number only, but can include multiple items when a subscription was tagged as invoice separately. | [optional] 
**OrderId** | **string** | The ID of the order created. This field is returned instead of the &#x60;orderNumber&#x60; field if the &#x60;returnIds&#x60; query parameter is set to &#x60;true&#x60;. | [optional] 
**OrderLineItems** | [**List&lt;JobResultAllOfOrderLineItems&gt;**](JobResultAllOfOrderLineItems.md) |  | [optional] 
**OrderNumber** | **string** | The order number of the order created. | [optional] 
**PaidAmount** | **string** | The total amount collected in this order request. | [optional] 
**PaymentId** | **string** | The payment Id that is collected in this order request. This field is returned instead of the &#x60;paymentNumber&#x60; field if the &#x60;returnIds&#x60; query parameter is set to &#x60;true&#x60;. | [optional] 
**PaymentNumber** | **string** | The payment number that is collected in this order request. | [optional] 
**Ramps** | [**List&lt;JobResultAllOfRamps&gt;**](JobResultAllOfRamps.md) | **Note**: This field is only available if you have the Ramps feature enabled. The [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) feature must be enabled before you can access the [Ramps](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/A_Overview_of_Ramps_and_Ramp_Metrics) feature. The Ramps feature is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information coming October 2020.  The ramp definitions created by this order request.  | [optional] 
**Status** | **string** | Status of the order. &#x60;Pending&#x60; is only applicable for an order that contains a &#x60;CreateSubscription&#x60; order action. | [optional] 
**SubscriptionIds** | **List&lt;string&gt;** | Container for the subscription IDs of the subscriptions in an order. This field is returned if the &#x60;returnIds&#x60; query parameter is set to &#x60;true&#x60;. | [optional] 
**SubscriptionNumbers** | **List&lt;string&gt;** | Container for the subscription numbers of the subscriptions in an order. | [optional] 
**Subscriptions** | [**List&lt;PostOrderResponseTypeAllOfSubscriptions&gt;**](PostOrderResponseTypeAllOfSubscriptions.md) | **Note:** This field is in Zuora REST API version control. Supported minor versions are 223.0 or later. To use this field in the method, you must set the &#x60;zuora-version&#x60; parameter to the minor version number in the request header.  Container for the subscription numbers and statuses in an order.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

