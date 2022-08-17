# ZuoraClient.Model.RenewSubscription
Information about an order action of type `RenewSubscription`. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BillToContactId** | **string** | The ID of the bill-to contact associated with the subscription.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] 
**ClearingExistingBillToContact** | **bool** | Whether to clear the existing bill-to contact ID at the subscription level. This field is mutually exclusive with the &#x60;paymentTerm&#x60; field.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] [default to false]
**ClearingExistingPaymentTerm** | **bool** | Whether to clear the existing payment term at the subscription level. This field is mutually exclusive with the &#x60;billToContactId&#x60; field.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] [default to false]
**PaymentTerm** | **string** | The name of the payment term associated with the subscription. For example, &#x60;Net 30&#x60;. The payment term determines the due dates of invoices.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

