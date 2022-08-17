# ZuoraClient.Model.UpdateCustomObjectCusotmField
A reference to a field.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Definition** | [**CustomObjectCustomFieldDefinitionUpdate**](CustomObjectCustomFieldDefinitionUpdate.md) |  | [optional] 
**Filterable** | **bool** | Indicates whether the field is filterable or not. Applicable to &#x60;addField&#x60; and &#x60;updateField&#x60; actions.  You can change a filterable field to non-filterable and vice versa. You can also add a filterable field. One custom object can have a maximum of 10 filterable fields.  Note that changing filterable fields triggers reindexing. It will take 12-24 hours before all your data are reindexed and available to query.  | [optional] 
**Name** | **string** | The name of the custom field to be updated | [optional] 
**Required** | **bool** | Indicates whether the field is required or optional.  You can update a required field to optional. On the other hand, you can only update an optional field to required on the custom object with no records.  You can only add a required field to the custom object with no records.  | [optional] 
**TargetName** | **string** | Required if the &#x60;type&#x60; of the action is &#x60;renameField&#x60; | [optional] 
**Unique** | **bool** | Indicates whether to specify a unique constraint to the field. You can remove the unique constraint on the field. However, you can only add a unique constraint to a filterable field if the custom object contains no record. One custom object can have a maximum of 5 fields with unique constraints.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

