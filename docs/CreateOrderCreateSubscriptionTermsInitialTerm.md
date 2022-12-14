# ZuoraClient.Model.CreateOrderCreateSubscriptionTermsInitialTerm
Information about the first term of the subscription. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Period** | **int** | Duration of the first term in months, years, days, or weeks, depending on the value of the &#x60;periodType&#x60; field. Only applicable if the value of the &#x60;termType&#x60; field is &#x60;TERMED&#x60;.  | [optional] 
**PeriodType** | **string** | Unit of time that the first term is measured in. Only applicable if the value of the &#x60;termType&#x60; field is &#x60;TERMED&#x60;.  | [optional] 
**StartDate** | **DateTime** | Start date of the first term, in YYYY-MM-DD format.  | [optional] 
**TermType** | **string** | Type of the first term. If the value of this field is &#x60;TERMED&#x60;, the first term has a predefined duration based on the value of the &#x60;period&#x60; field. If the value of this field is &#x60;EVERGREEN&#x60;, the first term does not have a predefined duration.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

