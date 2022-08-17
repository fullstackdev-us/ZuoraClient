# ZuoraClient.Model.POSTRevenueScheduleByTransactionTypeRevenueEvent
Represents a change to a revenue schedule, such as posting an invoice or distributing revenue.  You must specify the `eventType` or the `eventTypeSystemID`, or both. If you have configured more than one revenue event type with the same label, you must specify the `eventTypeSystemId`. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EventType** | **string** | Label of the revenue event type. Revenue event type labels can be duplicated. You can configure your revenue event type labels by navigating to **Settings &gt; Finance &gt; Configure Revenue Event Types** in the Zuora UI.  Note that &#x60;Credit Memo Posted&#x60; and &#x60;Debit Memo Posted&#x60; are only available if you enable the Invoice Settlement feature.  | [optional] 
**EventTypeSystemId** | **string** | System ID of the revenue event type. Each eventType has a unique system ID. You can configure your revenue event type system IDs by navigating to **Settings &gt; Finance &gt; Configure Revenue Event Types** in the Zuora UI.  Required only if there is more than one revenue event type with the same label.  | [optional] 
**Notes** | **string** | Additional information about this record.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

