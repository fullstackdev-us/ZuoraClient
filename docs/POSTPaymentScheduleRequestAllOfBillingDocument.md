# ZuoraClient.Model.POSTPaymentScheduleRequestAllOfBillingDocument
Object of the billing document with which the payment schedule is associated.  **Note:** - This field is optional. If you have the Standalone Payment feature enabled, you can escape this field and set `standalone` to `true` to create standalone payments. You can also choose to create unapplied payments by escaping this object and setting `standalone` to `false`. - If Standalone Payment is not enabled, leaving this object unspecified will create unapplied payments. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | ID of the billing document.  **Note:**  If a billing document is specified, either &#x60;id&#x60; or &#x60;number&#x60; of the billing document must be specified. You cannot specify both of them or skip both.  | [optional] 
**Number** | **string** | ID of the billing document.  **Note:**  If a billing document is specified, either &#x60;id&#x60; or &#x60;number&#x60; of the billing document must be specified. You cannot specify both of them or skip both.  | [optional] 
**Type** | **string** | The type of the billing document. The default value is &#x60;Invoice&#x60;.  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

