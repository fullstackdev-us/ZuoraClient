# ZuoraClient.Model.POSTCmiRevenueScheduleByTransactionTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Notes** | **string** | Additional information about this record.  Character Limit: 2,000  | [optional] 
**RevenueDistributions** | [**List&lt;POSTDistributionItemType&gt;**](POSTDistributionItemType.md) | An array of revenue distributions. Represents how you want to distribute revenue for this revenue schedule. You can distribute revenue into a maximum of 250 accounting periods with one revenue schedule.  The sum of new Amounts must equal the the Charge Amount of the specified Invoice Item.  | [optional] 
**RevenueEvent** | [**POSTRevenueScheduleByTransactionTypeRevenueEvent**](POSTRevenueScheduleByTransactionTypeRevenueEvent.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

