# ZuoraClient.Model.CustomObjectDefinitionSchema
The schema of the custom object definition

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EnableRecordMigration** | **bool** | Specifies whether Deployment Manager migrates custom object records when migrating the custom object between tenants.  | [optional] 
**Filterable** | **List&lt;string&gt;** | The set of fields that are allowed to be queried on. Queries on non-filterable fields will be rejected. You can not change a non-filterable field to filterable. | [optional] 
**Label** | **string** | A label for the custom object | [optional] 
**Object** | **string** | The API name of the custom object | [optional] 
**Properties** | [**CustomObjectAllFieldsDefinition**](CustomObjectAllFieldsDefinition.md) |  | [optional] 
**Relationships** | [**List&lt;CustomObjectDefinitionSchemaRelationshipsInner&gt;**](CustomObjectDefinitionSchemaRelationshipsInner.md) | An array of relationships with Zuora objects or other custom objects | [optional] 
**Required** | **List&lt;string&gt;** | The required fields of the custom object definition. You can change required fields to optional. However, you can only change optional fields to required on the custom objects with no records. | [optional] 
**Type** | **string** | The custom object definition type. Can only be &#x60;object&#x60; currently. | [optional] 
**Unique** | **List&lt;string&gt;** | The fields with unique constraints. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

