# ZuoraClient.Model.GETOpenPaymentMethodTypeRevisionResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EntityId** | **string** | If an entity UUID is provided, this custom payment method type is specific to this entity only. If no entity UUID is provided, the custom payment method type is available to the global entity and all the sub entities in the tenant.  | [optional] 
**Fields** | [**List&lt;OpenPaymentMethodTypeResponseFields&gt;**](OpenPaymentMethodTypeResponseFields.md) | An array containing field metadata of the custom payment method type.  | [optional] 
**InternalName** | **string** | A string to identify the custom payment method type in the API name of the payment method type.  This field is used along with the &#x60;tenantId&#x60; field by the system to construct and generate the API name of the custom payment method type in the following way:  &#x60;&lt;internalName&gt;__c_&lt;tenantId&gt;&#x60;  For example, if &#x60;internalName&#x60; is &#x60;AmazonPay&#x60;, and &#x60;tenantId&#x60; is &#x60;12368&#x60;, the API name of the custom payment method type will be &#x60;AmazonPay__c_12368&#x60;.  | [optional] 
**Label** | **string** | The label that is used to refer to this type in the Zuora UI.  | [optional] 
**MethodReferenceIdField** | **string** | The identification reference of the custom payment method.  This field should be mapped to a field name defined in the &#x60;fields&#x60; array for the purpose of being used as a filter in reporting tools such as Data Source Exports and Data Query.  | [optional] 
**Revision** | **int** | The revision number of the custom payment method type, which starts from 1 and increases by 1 when you update a published revision for the first time.  | [optional] 
**Status** | **string** | The status of the custom payment method type.  | [optional] 
**SubTypeField** | **string** | The identification reference indicating the subtype of the custom payment method.  This field should be mapped to a field name defined in the &#x60;fields&#x60; array for the purpose of being used as a filter in reporting tools such as Data Source Exports and Data Query.  | [optional] 
**TenantId** | **string** | Zuora tenant ID. If multi-entity is enabled in your tenant, this is the ID of the parent tenant of all the sub entities.  | [optional] 
**UserReferenceIdField** | **string** | The identification reference of the user or customer account.  This field should be mapped to a field name defined in the &#x60;fields&#x60; array for the purpose of being used as a filter in reporting tools such as Data Source Exports and Data Query.  | [optional] 
**_Version** | **string** | The time when the custom payment method type was first published.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

