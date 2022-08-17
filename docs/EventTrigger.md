# ZuoraClient.Model.EventTrigger

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Active** | **bool** | The status of the trigger. | [optional] 
**BaseObject** | **string** | The base object that the trigger rule is defined upon. Should be specified in the pattern: ^[A-Z][\\\\w\\\\-]*$ | [optional] 
**Condition** | **string** | The JEXL expression to be evaluated against object changes. See above for more information and an example. | [optional] 
**Description** | **string** | The description of the trigger. | [optional] 
**EventType** | [**EventType**](EventType.md) |  | [optional] 
**Id** | **Guid** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

