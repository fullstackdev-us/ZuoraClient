# ZuoraClient.Model.CreateEntityType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DisplayName** | **string** | The display name of the entity that is shown in the Zuora UI and APIs  **Note:** If you do not specify the display name in the request, the entity name is used as the display name. | [optional] 
**Locale** | **string** | The locale that is used in this entity. | 
**Name** | **string** | The name of the entity that is the entity identifier and is unique across all entities in a multi-entity hierarchy.  **Note:** Only alphanumeric characters (letters A–Z and a–z, and digits 0–9), space, period, and hyphen are allowed to be used in entity names.  | 
**ParentId** | **string** | The Id of the entity under which you want to create an entity. You can get the parent entity Id by using the GET Entities call.  | 
**Timezone** | **string** | The time zone that is used in this entity. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

