# ZuoraClient.Model.POSTPMMandateInfo
The mandate information for the Credit Card, Credit Card Reference Transaction, ACH, or Bank Transfer payment method.  The following mandate fields are common to all supported payment methods: * `mandateId` * `mandateReason` * `mandateStatus`  The following mandate fields are specific to the ACH and Bank Transfer payment methods: * `mandateReceivedStatus` * `existingMandateStatus` * `mandateCreationDate` * `mandateUpdateDate`  The following mandate fields are specific to the Credit Card payment method: * `mitTransactionId` * `mitProfileAgreedOn` * `mitConsentAgreementRef` * `mitConsentAgreementSrc` * `mitProfileType` * `mitProfileAction` 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExistingMandateStatus** | **string** | Indicates whether the mandate is an existing mandate.  | [optional] 
**MandateCreationDate** | **DateTime** | The date on which the mandate was created.  | [optional] 
**MandateId** | **string** | The mandate ID.  | [optional] 
**MandateReason** | **string** | The reason of the mandate from the gateway side.  | [optional] 
**MandateReceivedStatus** | **string** | Indicates whether the mandate is received from the gateway  | [optional] 
**MandateStatus** | **string** | The status of the mandate from the gateway side.  | [optional] 
**MandateUpdateDate** | **DateTime** | The date on which the mandate was updated.  | [optional] 
**MitConsentAgreementRef** | **string** | Reference for the consent agreement that you have established with the customer.    | [optional] 
**MitConsentAgreementSrc** | **string** |  | [optional] 
**MitProfileAction** | **string** | Specifies how Zuora activates the stored credential profile. Only applicable if you set the &#x60;status&#x60; field to &#x60;Active&#x60;.  * &#x60;Activate&#x60; (default) - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;.  | [optional] 
**MitProfileAgreedOn** | **DateTime** | The date on which the stored credential profile is agreed. The date format is &#x60;yyyy-mm-dd&#x60;.  | [optional] 
**MitProfileType** | **string** | Indicates the type of the stored credential profile.  | [optional] 
**MitTransactionId** | **string** | Specifies the ID of the transaction. Only applicable if you set the &#x60;mitProfileAction&#x60; field to &#x60;Persist&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

