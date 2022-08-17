# ZuoraClient.Model.CreateSubscription
Information about an order action of type `CreateSubscription`. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BillToContactId** | **string** | The ID of the bill-to contact associated with the subscription.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] 
**InvoiceSeparately** | **bool** | Specifies whether the subscription appears on a separate invoice when Zuora generates invoices.  | [optional] 
**NewSubscriptionOwnerAccount** | [**CreateSubscriptionNewSubscriptionOwnerAccount**](CreateSubscriptionNewSubscriptionOwnerAccount.md) |  | [optional] 
**Notes** | **string** | Notes about the subscription. These notes are only visible to Zuora users.  | [optional] 
**PaymentTerm** | **string** | The name of the payment term associated with the subscription. For example, &#x60;Net 30&#x60;. The payment term determines the due dates of invoices.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] 
**SubscribeToRatePlans** | [**List&lt;RatePlanOverride&gt;**](RatePlanOverride.md) | List of rate plans associated with the subscription.  | [optional] 
**SubscriptionNumber** | **string** | Subscription number of the subscription. For example, A-S00000001.  If you do not set this field, Zuora will generate the subscription number.  | [optional] 
**SubscriptionOwnerAccountNumber** | **string** | Account number of an existing account that will own the subscription. For example, A00000001.  If you do not set this field or the &#x60;newSubscriptionOwnerAccount&#x60; field, the account that owns the order will also own the subscription. Zuora will return an error if you set this field and the &#x60;newSubscriptionOwnerAccount&#x60; field.  | [optional] 
**Terms** | [**CreateSubscriptionTerms**](CreateSubscriptionTerms.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

