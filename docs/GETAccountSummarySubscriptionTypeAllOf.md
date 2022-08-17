# ZuoraClient.Model.GETAccountSummarySubscriptionTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoRenew** | **bool** | If &#x60;true&#x60;, auto-renew is enabled. If &#x60;false&#x60;, auto-renew is disabled.  | [optional] 
**Id** | **string** | Subscription ID.  | [optional] 
**InitialTerm** | **string** | Duration of the initial subscription term in whole months.   | [optional] 
**RatePlans** | [**List&lt;GETAccountSummarySubscriptionRatePlanType&gt;**](GETAccountSummarySubscriptionRatePlanType.md) | Container for rate plans for this subscription.  | [optional] 
**RenewalTerm** | **string** | Duration of the renewal term in whole months.  | [optional] 
**Status** | **string** | Subscription status; possible values are: &#x60;Draft&#x60;, &#x60;PendingActivation&#x60;, &#x60;PendingAcceptance&#x60;, &#x60;Active&#x60;, &#x60;Cancelled&#x60;, &#x60;Expired&#x60;.  | [optional] 
**SubscriptionNumber** | **string** | Subscription Number.  | [optional] 
**SubscriptionStartDate** | **DateTime** | Subscription start date.  | [optional] 
**TermEndDate** | **DateTime** | End date of the subscription term. If the subscription is evergreen, this is either null or equal to the cancellation date, as appropriate.  | [optional] 
**TermStartDate** | **DateTime** | Start date of the subscription term. If this is a renewal subscription, this date is different than the subscription start date.  | [optional] 
**TermType** | **string** | Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

