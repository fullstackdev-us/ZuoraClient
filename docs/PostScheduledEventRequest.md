# ZuoraClient.Model.PostScheduledEventRequest
namespace.name pair should be unique universally

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ApiField** | **string** | The base field of the base object in the &#x60;apiObject&#x60; field, should be in date or timestamp format. The scheduled event notifications are triggered based on this date and the event parameters (before or after a specified number of days) from notification definitions. Should be specified in the pattern: ^[A-Z][\\\\w\\\\-]*$   See [Custom Scheduled Events](https://knowledgecenter.zuora.com/Central_Platform/Events_and_Notifications/A_Z_Custom_Scheduled_Events) for all available base fields.  | 
**ApiObject** | **string** | The base object that the scheduled event is defined upon. The base object should contain a date or timestamp format field. Should be specified in the pattern: ^[A-Z][\\\\w\\\\-]*$             See [Custom Scheduled Events](https://knowledgecenter.zuora.com/Central_Platform/Events_and_Notifications/A_Z_Custom_Scheduled_Events) for all available base objects.  | 
**Condition** | **string** | The filter rule conditions, written in [JEXL](http://commons.apache.org/proper/commons-jexl/). The scheduled event is triggered only if the condition is evaluated as true. The rule might contain event context merge fields and data source merge fields. Data source merge fields must be from [the base object of the event or from the joined objects of the base object](https://knowledgecenter.zuora.com/DC_Developers/M_Export_ZOQL#Data_Sources_and_Objects). Scheduled events with invalid merge fields will fail to evaluate, thus will not be triggered. For example, to trigger an invoice due date scheduled event to only invoices with an amount over 1000, you would define the following condition:  &#x60;&#x60;&#x60;Invoice.Amount &gt; 1000&#x60;&#x60;&#x60;  &#x60;Invoice.Amount&#x60; refers to the &#x60;Amount&#x60; field of the Zuora object &#x60;Invoice&#x60;.  | [optional] 
**Description** | **string** | The description of the scheduled event. | [optional] 
**DisplayName** | **string** | The display name of the scheduled event. | 
**Hours** | **int** | The scheduled time (hour) that the scheduled event notifications are sent. This time is based on the localized timezone of your tenant. | 
**Minutes** | **int** | The scheduled time (minute) that the scheduled event notifications are sent. This time is based on the localized timezone of your tenant. | 
**Name** | **string** | The name of the scheduled event. Should be unique, contain no space, and be in the pattern: ^[A-Za-z]{1,}[\\\\w\\\\-]*$ | 
**Parameters** | [**Dictionary&lt;string, PostScheduledEventRequestParametersValue&gt;**](PostScheduledEventRequestParametersValue.md) | The parameter definitions of the filter rule. The names of the parameters must match with the filter rule and can&#39;t be duplicated. You should specify all the parameters when creating scheduled event notifications. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

