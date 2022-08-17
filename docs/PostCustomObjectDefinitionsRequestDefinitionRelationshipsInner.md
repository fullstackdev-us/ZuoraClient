# ZuoraClient.Model.PostCustomObjectDefinitionsRequestDefinitionRelationshipsInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Cardinality** | **string** | The cardinality of the relationship from this object to another object.  Only the &#x60;manyToOne&#x60; cardinality can be used when creating relationships.  A relationship with &#x60;oneToMany&#x60; cardinality is created implicitly when a &#x60;manyToOne&#x60; relationship is created.  A custom object definition can have a maximum of 2 &#x60;manyToOne&#x60; relationships.  | [optional] 
**Fields** | **Dictionary&lt;string, string&gt;** | Field mappings in the form of &#x60;&lt;this-object-field-name&gt;&#x60;: &#x60;&lt;other-object-field-name&gt;&#x60;. Usually the &#x60;&lt;other-object-field-name&gt;&#x60; can only be the &#x60;Id&#x60; field of the related object. Two exceptions are Subscription Name and Rate Plan Charge Number as both of them are unique.  | 
**Namespace** | **string** | The namespace where the related object is located | 
**Object** | **string** | The API name of the related object | 
**RecordConstraints** | [**CustomObjectDefinitionUpdateActionRequestRelationshipRecordConstraints**](CustomObjectDefinitionUpdateActionRequestRelationshipRecordConstraints.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

