# ZuoraClient.Model.GetStoredCredentialProfilesResponseProfiles
Container for stored credential profiles. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActivatedOn** | **DateTime** | The date when the stored credential profile was activated (if applicable).  | [optional] 
**AgreedOn** | **DateTime** | The date when the stored credential profile was created.  | [optional] 
**Brand** | **string** | The stored credential transaction framework. For example, Visa.  | [optional] 
**CancelledOn** | **DateTime** | The date when the stored credential profile was cancelled (if applicable).  | [optional] 
**ConsentAgreementRef** | **string** | Your reference for the consent agreement that you have established with the customer.  | [optional] 
**ConsentAgreementSrc** | **string** |  | [optional] 
**ExpiredOn** | **DateTime** | The date when the stored credential profile was expired (if applicable).  | [optional] 
**Number** | **int** | The number that identifies the stored credential profile within the payment method.  | [optional] 
**PaymentMethodId** | **string** | ID of the payment method.  | [optional] 
**Status** | **string** | The status of the stored credential profile.  * &#x60;Agreed&#x60; - The stored credential profile has not been validated via an authorization transaction with the payment gateway. * &#x60;Active&#x60; - The stored credential profile has been validated via an authorization transaction with the payment gateway. * &#x60;Cancelled&#x60; - The stored credentials are no longer valid, per a customer request. Zuora cannot use the stored credentials in transactions. * &#x60;Expired&#x60; - The stored credentials are no longer valid, per an expiration policy in the stored credential transaction framework. Zuora cannot use the stored credentials in transactions.  | [optional] 
**Type** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

