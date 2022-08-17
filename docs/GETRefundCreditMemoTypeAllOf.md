# ZuoraClient.Model.GETRefundCreditMemoTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the account associated with this refund. Zuora associates the refund automatically with the account from the associated payment.  | [optional] 
**Amount** | **double** | The total amount of the refund.  | [optional] 
**CancelledOn** | **DateTime** | The date and time when the refund was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Comment** | **string** | Comments about the refund.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the refund.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the refund was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-06 15:31:10.  | [optional] 
**CreditMemoId** | **string** | The ID of the credit memo that is refunded.  | [optional] 
**FinanceInformation** | [**GETRefundCreditMemoTypeAllOfFinanceInformation**](GETRefundCreditMemoTypeAllOfFinanceInformation.md) |  | [optional] 
**GatewayId** | **string** | The ID of the gateway instance that processes the refund.  | [optional] 
**GatewayResponse** | **string** | The message returned from the payment gateway for the refund. This message is gateway-dependent.  | [optional] 
**GatewayResponseCode** | **string** | The response code returned from the payment gateway for the refund. This code is gateway-dependent.  | [optional] 
**GatewayState** | **string** | The status of the refund in the gateway.  | [optional] 
**Id** | **string** | The ID of the created refund.  | [optional] 
**MarkedForSubmissionOn** | **DateTime** | The date and time when a refund was marked and waiting for batch submission to the payment process, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**MethodType** | **string** | How an external refund was issued to a customer.  | [optional] 
**Number** | **string** | The unique identification number of the refund.  | [optional] 
**PaymentId** | **string** | The ID of the payment associated with the refund.  | [optional] 
**PaymentMethodId** | **string** | The unique ID of the payment method that the customer used to make the refund.  | [optional] 
**PaymentMethodSnapshotId** | **string** | The unique ID of the payment method snapshot, which is a copy of the particular payment method used in a transaction.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction.  | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway for an electronic refund. Use this field to reconcile refunds between your gateway and Zuora Payments.  | [optional] 
**RefundDate** | **DateTime** | The date when the refund takes effect, in yyyy-mm-dd format.  | [optional] 
**RefundTransactionTime** | **DateTime** | The date and time when the refund was issued, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**SecondRefundReferenceId** | **string** | The transaction ID returned by the payment gateway if there is an additional transaction for the refund. Use this field to reconcile payments between your gateway and Zuora Payments.  | [optional] 
**SettledOn** | **DateTime** | The date and time when the refund was settled in the payment processor, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. This field is used by the Spectrum gateway only and not applicable to other gateways.  | [optional] 
**SoftDescriptor** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.  | [optional] 
**SoftDescriptorPhone** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.  | [optional] 
**Status** | **string** | The status of the refund.  | [optional] 
**SubmittedOn** | **DateTime** | The date and time when the refund was submitted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully. | [optional] 
**Type** | **string** | The type of the refund.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the refund.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the refund was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-07 15:36:10.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

