# ZuoraClient.Model.PostEventTriggerRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the event trigger. | 
**BaseObject** | **string** | The base object that the trigger rule is defined upon. Should be specified in the pattern: ^[A-Z][\\\\w\\\\-]*$ | 
**Condition** | **string** | The JEXL expression to be evaluated against object changes. See above for more information and an example. | 
**Description** | **string** | The description of the event trigger. | [optional] 
**EventType** | [**EventType**](EventType.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

