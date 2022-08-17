# ZuoraClient.Model.PostCustomObjectDefinitionsRequestDefinition

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EnableRecordMigration** | **bool** | Specifies whether Deployment Manager migrates custom object records when migrating the custom object between tenants.  | [optional] [default to false]
**Filterable** | **List&lt;string&gt;** | The set of fields that are allowed to be queried on. Queries on non-filterable fields will be rejected. You can not change a non-filterable field to filterable. | [optional] 
**Label** | **string** | A UI label for the custom object | 
**Object** | **string** | The API name of the custom object | 
**Properties** | [**Dictionary&lt;string, PostCustomObjectDefinitionFieldDefinitionRequest&gt;**](PostCustomObjectDefinitionFieldDefinitionRequest.md) |  | [optional] 
**Relationships** | [**List&lt;PostCustomObjectDefinitionsRequestDefinitionRelationshipsInner&gt;**](PostCustomObjectDefinitionsRequestDefinitionRelationshipsInner.md) | An array of relationships with Zuora objects or other custom objects. You can add at most 2 &#x60;manyToOne&#x60; relationships when creating a custom field definition. | [optional] 
**Required** | **List&lt;string&gt;** | The required fields of the custom object. You can change required fields to optional. However, you can only change optional fields to required on the custom objects with no records. | [optional] 
**Unique** | **List&lt;string&gt;** | The fields with unique constraints. You can remove the unique constraint on a field. However, you can only add a unique constraint to a filterable field if the custom object contains no record. One custom object can have a maximum of 5 fields with unique constraints. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

