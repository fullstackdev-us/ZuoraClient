# ZuoraClient.Model.POSTReversePaymentResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account that the payment is for.  | [optional] 
**Amount** | **double** | The total amount of the payment.  | [optional] 
**CancelledOn** | **DateTime** | The date and time when the payment was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Comment** | **string** | Comments about the payment.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the refund.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the chargeback is created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2019-03-01 15:31:10.  | [optional] 
**CreditMemoId** | **string** | The ID of the credit memo that is refunded.  | [optional] 
**FinanceInformation** | [**POSTReconcileRefundResponseFinanceInformation**](POSTReconcileRefundResponseFinanceInformation.md) |  | [optional] 
**GatewayId** | **string** | The ID of the gateway instance that processes the payment.  | [optional] 
**GatewayResponse** | **string** | The message returned from the payment gateway for the payment. This message is gateway-dependent.  | [optional] 
**GatewayResponseCode** | **string** | The code returned from the payment gateway for the payment. This code is gateway-dependent.  | [optional] 
**GatewayState** | **string** | The status of the payment in the gateway; specifically used for reconciliation.  | [optional] 
**Id** | **string** | The ID of the payment chargeback.  | [optional] 
**MarkedForSubmissionOn** | **DateTime** | The date and time when a charge was marked and waiting for batch submission to the payment process, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**MethodType** | **string** | How an external refund was issued to a customer.   | [optional] 
**Number** | **string** | The unique identification number of the payment. For example, P-00000001.  | [optional] 
**PaymentId** | **string** | The ID of the payment that is refunded.  | [optional] 
**PaymentMethodId** | **string** | The unique ID of the payment method that the customer used to make the payment.  | [optional] 
**PaymentMethodSnapshotId** | **string** | The unique ID of the payment method snapshot which is a copy of the particular Payment Method used in a transaction.  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction.     | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway for an electronic refund. Use this field to reconcile refunds between your gateway and Zuora Payments.  | [optional] 
**RefundDate** | **DateTime** | The date when the refund takes effect, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-03-01.  | [optional] 
**RefundTransactionTime** | **DateTime** | The date and time when the refund was issued, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**SecondRefundReferenceId** | **string** | The transaction ID returned by the payment gateway if there is an additional refund.   | [optional] 
**SettledOn** | **DateTime** | The date and time when the transaction is settled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**SoftDescriptor** | **string** | A payment gateway-specific field that maps Zuora to other gateways.  | [optional] 
**SoftDescriptorPhone** | **string** | A payment gateway-specific field that maps Zuora to other gateways.            | [optional] 
**Status** | **string** | The status of the payment.  | [optional] 
**SubmittedOn** | **DateTime** | The date and time when the payment was submitted, in yyyy-mm-dd hh:mm:ss format.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**Type** | **string** | The type of the payment.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the payment.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the payment was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2019-03-02 15:36:10.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

