# ZuoraClient.Model.GETRevenueEventDetailWithoutSuccessType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | An account ID.  | [optional] 
**CreatedOn** | **DateTime** | The date when the record was created in YYYY-MM-DD HH:MM:SS format.  | [optional] 
**Currency** | **string** | The type of currency used. | [optional] 
**EventType** | **string** | Label of the revenue event type. Revenue event type labels can be duplicated. You can configure your revenue event type labels by navigating to **Settings &gt; Finance &gt; Configure Revenue Event Types** in the Zuora UI.  Note that &#x60;Credit Memo Posted&#x60; and &#x60;Debit Memo Posted&#x60; are only available if you enable the Invoice Settlement feature.  | [optional] 
**Notes** | **string** | Additional information about this record.  | [optional] 
**Number** | **string** | The revenue event number created when a revenue event occurs.  | [optional] 
**RecognitionEnd** | **DateTime** | The end date of a recognition period in YYYY-MM-DD format.   The maximum difference of the recognitionStart and recognitionEnd date fields is equal to 250 multiplied by the length of an accounting period.  | [optional] 
**RecognitionStart** | **DateTime** | The start date of a recognition period in YYYY-MM-DD format.  | [optional] 
**RevenueItems** | [**List&lt;GETRevenueItemType&gt;**](GETRevenueItemType.md) | Revenue items are listed in ascending order by the accounting period start date.  | [optional] 
**SubscriptionChargeId** | **string** | The original subscription charge ID.  | [optional] 
**SubscriptionId** | **string** | The original subscription ID.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

