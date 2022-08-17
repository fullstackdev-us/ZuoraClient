# ZuoraClient.Model.OpenPaymentMethodTypeResponseFields

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Checksum** | **bool** | The checksum value of a payment method is used to identify if this payment method is the same as another one, or if this payment method is altered to another new payment method.  For example, if you select the credit card number and expiration date as the checksum fields for the CreditCard payment method type, when you modified the expiration date, Zuora considers this payment method as a different payment method compared to the original one.  | [optional] 
**DefaultValue** | **string** | The default value of the field.  | [optional] 
**Description** | **string** | An explanation of this field.  | [optional] 
**Editable** | **bool** | Specify &#x60;true&#x60; if this field can be updated through PUT API or UI.  Note: If &#x60;editable&#x60; is set to &#x60;false&#x60;, you can specify the value of this field in the UI and POST API when creating a payment method. However, after you created the payment method, you cannot edit this field through PUT API or UI.  | [optional] 
**Index** | **int** | The order of the field in this type, starting from 1.  | [optional] 
**Label** | **string** | The label that is used to refer to this field in the Zuora UI.  | [optional] 
**MaxLength** | **int** | A maximum length limitation of the field value.  | [optional] 
**MinLength** | **int** | A minimal length limitation of the field value.  | [optional] 
**Name** | **string** | The API name of this field. It must be uinique.  | [optional] 
**Representer** | **bool** | This flag determines whether this field will be used for identifying this payment method in the Zuora UI. The field will be shown in the Payment Method field in the UI.  | [optional] 
**Required** | **bool** | Specify whether this field is required.  | [optional] 
**Type** | **string** | The type of this field.  | [optional] 
**Visible** | **bool** | Specify &#x60;true&#x60; if this field can be retrieved through GET API or UI for displaying payment method details.  Notes:    - If &#x60;visible&#x60; is set to &#x60;false&#x60;, you can still specify the value of this field in the UI and POST API when creating the payment method.   - If &#x60;visible&#x60; is set to &#x60;false&#x60; and &#x60;editable&#x60; is set to &#x60;true&#x60;, this field is not accessible through GET API or UI for displaying details, but you can still see it and edit the value in the UI and PUT API when updating this payment method.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

