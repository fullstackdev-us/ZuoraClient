# ZuoraClient.Model.GETRevenueItemType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountingPeriodEndDate** | **DateTime** | The accounting period end date. The accounting period end date of the open-ended accounting period is null.   | [optional] 
**AccountingPeriodName** | **string** | Name of the accounting period. The open-ended accounting period is named &#x60;Open-Ended&#x60;.   | [optional] 
**AccountingPeriodStartDate** | **DateTime** | The accounting period start date.  | [optional] 
**Amount** | **decimal** | The revenue schedule amount, which is the sum of all revenue items. This field cannot be null and must be formatted based on the currency, such as *JPY 30* or *USD 30.15*. Test out the currency to ensure you are using the proper formatting otherwise, the response will fail and this error message is returned:  &#x60;Allocation amount with wrong decimal places.&#x60;  | [optional] 
**Currency** | **string** | The type of currency used.   | [optional] 
**IsAccountingPeriodClosed** | **bool** | Indicates if the accounting period is closed or open.   | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

