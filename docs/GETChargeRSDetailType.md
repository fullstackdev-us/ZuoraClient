# ZuoraClient.Model.GETChargeRSDetailType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | An account ID.  | [optional] 
**Amount** | **decimal** | The revenue schedule amount, which is the sum of all revenue items. This field cannot be null and must be formatted based on the currency, such as *JPY 30* or USD *30.15*. Test out the currency to ensure you are using the proper formatting otherwise, the response will fail and this error message is returned:  *\&quot;Allocation amount with wrong decimal places.\&quot;*  | [optional] 
**Currency** | **string** | The type of currency used.   | [optional] 
**Notes** | **string** | Additional information about this record.  | [optional] 
**Number** | **string** | The charge revenue summary number.  | [optional] 
**RecognitionRuleName** | **string** | The name of the recognition rule.  | [optional] 
**RecognizedRevenue** | **decimal** | The revenue that was distributed in a closed accounting period.  | [optional] 
**RevenueItems** | [**List&lt;GETRevenueItemTypeResponse&gt;**](GETRevenueItemTypeResponse.md) | Revenue items are listed in ascending order by the accounting period start date.  | [optional] 
**SubscriptionChargeId** | **string** | The original subscription charge ID.  | [optional] 
**SubscriptionId** | **string** | The original subscription ID.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**UndistributedUnrecognizedRevenue** | **decimal** | Revenue in the open-ended accounting period.  | [optional] 
**UnrecognizedRevenue** | **decimal** | Revenue distributed in all open accounting periods, which includes the open-ended accounting period.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

