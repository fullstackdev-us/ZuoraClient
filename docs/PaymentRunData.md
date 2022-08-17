# ZuoraClient.Model.PaymentRunData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The customer account ID specified in the &#x60;data&#x60; field when creating the payment run.  | [optional] 
**AccountNumber** | **string** | The customer account number specified in the &#x60;data&#x60; field when creating the payment run.  | [optional] 
**Amount** | **decimal** | The amount specified in the &#x60;data&#x60; field when creating the payment run. &#x60;null&#x60; is returned if it was not specified.  | [optional] 
**AmountCollected** | **decimal** | The amount that is collected.  | [optional] 
**AmountToCollect** | **decimal** | The amount to be collected.  | [optional] 
**Comment** | **string** | The comment specified in the &#x60;data&#x60; field when creating the payment run. &#x60;null&#x60; is returned if it was not specified.  | [optional] 
**Currency** | **string** | This field is only available if support for standalone payments is enabled.  The currency of the standalone payment. The currency of the standalone payment can be different from the payment currency defined in the customer account settings.  | [optional] 
**DocumentId** | **string** | The billing document ID specified in the &#x60;data&#x60; field when creating the payment run. &#x60;null&#x60; is returned if it was not specified.  | [optional] 
**DocumentNumber** | **string** | The billing document number specified in the &#x60;data&#x60; field when creating the payment run. &#x60;null&#x60; is returned if it was not specified.  | [optional] 
**DocumentType** | **string** | The billing document type specified in the &#x60;data&#x60; field when creating the payment run. &#x60;null&#x60; is returned if it was not specified.  | [optional] 
**ErrorCode** | **string** | The error code of the response.  | [optional] 
**ErrorMessage** | **string** | The detailed information of the error response.  | [optional] 
**PaymentGatewayId** | **string** | The payment gateway ID specified in the &#x60;data&#x60; field when creating the payment run. &#x60;null&#x60; is returned if it was not specified.  | [optional] 
**PaymentMethodId** | **string** | The payment method ID specified in the &#x60;data&#x60; field when creating the payment run. &#x60;null&#x60; is returned if it was not specified.  | [optional] 
**Result** | **string** | Indicates whether the data is processed successfully or not.  | [optional] 
**Standalone** | **bool** | This field is only available if the support for standalone payment is enabled.  The value &#x60;true&#x60; indicates this is a standalone payment that is created and processed in Zuora through Zuora gateway integration but will be settled outside of Zuora. No settlement data will be created. The standalone payment cannot be applied, unapplied, or transferred.  | [optional] 
**Transactions** | [**List&lt;GETPaymentRunDataTransactionElementResponse&gt;**](GETPaymentRunDataTransactionElementResponse.md) | Container for transactions that apply to the current request. Each element contains an array of the settlement/payment applied to the record.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

