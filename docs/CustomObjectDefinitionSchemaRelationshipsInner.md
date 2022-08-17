# ZuoraClient.Model.CustomObjectDefinitionSchemaRelationshipsInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Cardinality** | **string** | The cardinality of the relationship from this object to another object.  A &#x60;manyToOne&#x60; relationship means this object is the child object (the \&quot;many\&quot; side), and the referenced object (the \&quot;one\&quot; side) is the parent.  A &#x60;oneToMany&#x60; relationship means this object is the parent object (the \&quot;one\&quot; side), and the referenced object (the \&quot;many\&quot; side) is the child.  | [optional] [default to CardinalityEnum.ManyToOne]
**Fields** | **Dictionary&lt;string, string&gt;** | Field mappings in the form of &#x60;&lt;this-object-field-name&gt;&#x60;: &#x60;&lt;other-object-field-name&gt;&#x60;.  | [optional] 
**Namespace** | **string** | The namespace where the related object is located | [optional] 
**Object** | **string** | The API name of the related object | [optional] 
**RecordConstraints** | [**CustomObjectDefinitionSchemaRelationshipsInnerRecordConstraints**](CustomObjectDefinitionSchemaRelationshipsInnerRecordConstraints.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

