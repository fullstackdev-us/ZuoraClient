# ZuoraClient.Model.QuoteObjectFields
The fields populated for a quote when a quote is sent to Zuora Billing from Zuora Quote. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**OpportunityCloseDateQT** | **string** | The closing date of the Opportunity.  This field is used in Zuora Reporting Data Sources to report on Subscription metrics.  If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes.  | [optional] 
**OpportunityNameQT** | **string** | The unique identifier of the Opportunity.   This field is used in the Zuora Reporting Data Sources to report on Subscription metrics.  If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes.  **Character limit**: 100  | [optional] 
**QuoteBusinessTypeQT** | **string** | The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal or Churn.  This field is used in the Zuora Reporting Data Sources to report on Subscription metrics.  If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes.  **Character limit**: 32  | [optional] 
**QuoteNumberQT** | **string** | The unique identifier of the Quote.  This field is used in the Zuora Reporting Data Sources to report on Subscription metrics.  If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes.  **Character limit**: 32  | [optional] 
**QuoteTypeQT** | **string** | The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel.  This field is used in the Zuora Reporting Data Sources to report on Subscription metrics.  If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes.  **Character limit**: 32  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

