# ZuoraClient.Model.CreateSubscriptionForEvergreen
Information about an order action of type `CreateSubscription`. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceSeparately** | **bool** | Specifies whether the subscription appears on a separate invoice when Zuora generates invoices.  | [optional] 
**NewSubscriptionOwnerAccount** | [**CreateSubscriptionNewSubscriptionOwnerAccount**](CreateSubscriptionNewSubscriptionOwnerAccount.md) |  | [optional] 
**Notes** | **string** | Notes about the subscription. These notes are only visible to Zuora users.  | [optional] 
**SubscribeToRatePlans** | [**List&lt;RatePlanOverrideForEvergreen&gt;**](RatePlanOverrideForEvergreen.md) | List of rate plans associated with the subscription.  | [optional] 
**SubscriptionNumber** | **string** | Subscription number of the subscription. For example, A-S00000001.  If you do not set this field, Zuora will generate the subscription number.  | [optional] 
**SubscriptionOwnerAccountNumber** | **string** | Account number of an existing account that will own the subscription. For example, A00000001.  If you do not set this field or the &#x60;newSubscriptionOwnerAccount&#x60; field, the account that owns the order will also own the subscription. Zuora will return an error if you set this field and the &#x60;newSubscriptionOwnerAccount&#x60; field.  | [optional] 
**Terms** | [**CreateSubscriptionTerms**](CreateSubscriptionTerms.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

