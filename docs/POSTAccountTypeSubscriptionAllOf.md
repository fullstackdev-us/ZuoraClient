# ZuoraClient.Model.POSTAccountTypeSubscriptionAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoRenew** | **bool** | If &#x60;true&#x60;, auto-renew is enabled. Default is &#x60;false&#x60;.  | [optional] 
**ContractEffectiveDate** | **DateTime** | Effective contract date for this subscription, as &#x60;yyyy-mm-dd&#x60;.  | 
**CustomerAcceptanceDate** | **DateTime** | The date on which the services or products within a subscription have been accepted by the customer, as &#x60;yyyy-mm-dd&#x60;.  Default value is dependent on the value of other fields. See Notes section for more details.  | [optional] 
**InitialTerm** | **long** | Duration of the initial subscription term in whole months.  Default is 0.   | [optional] 
**InvoiceOwnerAccountKey** | **string** | Invoice owner account number or ID.  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).   | [optional] 
**InvoiceSeparately** | **bool** | Separates a single subscription from other subscriptions and invoices the charge independently.   If the value is &#x60;true&#x60;, the subscription is billed separately from other subscriptions. If the value is &#x60;false&#x60;, the subscription is included with other subscriptions in the account invoice. The default value is &#x60;false&#x60;.  Prerequisite: The default subscription setting &#x60;Enable Subscriptions to be Invoiced Separately&#x60; must be set to &#x60;Yes&#x60;.  | [optional] 
**Notes** | **string** |  | [optional] 
**RenewalTerm** | **long** | Duration of the renewal term in whole months. Default is 0.  | [optional] 
**ServiceActivationDate** | **DateTime** | The date on which the services or products within a subscription have been activated and access has been provided to the customer, as &#x60;yyyy-mm-dd&#x60;.  Default value is dependent on the value of other fields. See Notes section for more details.  | [optional] 
**SubscribeToRatePlans** | [**List&lt;POSTSrpCreateType&gt;**](POSTSrpCreateType.md) | Container for one or more rate plans for this subscription.  | [optional] 
**SubscriptionNumber** | **string** | Subscription Number. The value can be up to 1000 characters.  If you do not specify a subscription number when creating a subscription for the new account, Zuora will generate a subscription number automatically.  If the account is created successfully, the subscription number is returned in the &#x60;subscriptionNumber&#x60; response field.  | [optional] 
**TermStartDate** | **DateTime** | The date on which the subscription term begins, as &#x60;yyyy-mm-dd&#x60;. If this is a renewal subscription, this date is different from the subscription start date.  | [optional] 
**TermType** | **string** | Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

