# ZuoraClient.Model.POSTSettlePaymentResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account that the payment is for.  | [optional] 
**Amount** | **double** | The total amount of the payment.  | [optional] 
**AppliedAmount** | **double** | The applied amount of the payment.  | [optional] 
**AuthTransactionId** | **string** | The authorization transaction ID from the payment gateway.  | [optional] 
**BankIdentificationNumber** | **string** | The first six or eight digits of the credit card or debit card used for the payment, when applicable.  | [optional] 
**CancelledOn** | **DateTime** | The date and time when the payment was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Comment** | **string** | Comments about the payment.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the refund.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the chargeback is created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2019-03-01 15:31:10.  | [optional] 
**CreditBalanceAmount** | **double** | The amount that the payment transfers to the credit balance. The value is not &#x60;0&#x60; only for those payments that come from legacy payment operations performed without the Invoice Settlement feature.  | [optional] 
**Currency** | **string** | A currency defined in the web-based UI administrative settings.  | [optional] 
**EffectiveDate** | **DateTime** | The date and time when the payment takes effect, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**FinanceInformation** | [**POSTReconcileRefundResponseFinanceInformation**](POSTReconcileRefundResponseFinanceInformation.md) |  | [optional] 
**GatewayId** | **string** | The ID of the gateway instance that processes the payment.  | [optional] 
**GatewayOrderId** | **string** | A merchant-specified natural key value that can be passed to the electronic payment gateway when a payment is created. If not specified, the payment number will be passed in instead.  | [optional] 
**GatewayResponse** | **string** | The message returned from the payment gateway for the payment. This message is gateway-dependent.  | [optional] 
**GatewayResponseCode** | **string** | The code returned from the payment gateway for the payment. This code is gateway-dependent.  | [optional] 
**GatewayState** | **string** | The status of the payment in the gateway; specifically used for reconciliation.  | [optional] 
**Id** | **string** | The ID of the payment chargeback.  | [optional] 
**MarkedForSubmissionOn** | **DateTime** | The date and time when a charge was marked and waiting for batch submission to the payment process, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Number** | **string** | The unique identification number of the payment. For example, P-00000001.  | [optional] 
**PaymentMethodId** | **string** | The unique ID of the payment method that the customer used to make the payment.  | [optional] 
**PaymentMethodSnapshotId** | **string** | The unique ID of the payment method snapshot which is a copy of the particular Payment Method used in a transaction.  | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway for an electronic refund. Use this field to reconcile refunds between your gateway and Zuora Payments.  | [optional] 
**RefundAmount** | **double** | The amount of the payment that is refunded.  | [optional] 
**SecondPaymentReferenceId** | **string** | The transaction ID returned by the payment gateway if there is an additional transaction for the payment.   | [optional] 
**SettledOn** | **DateTime** | The date and time when the transaction is settled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**SoftDescriptor** | **string** | A payment gateway-specific field that maps Zuora to other gateways.  | [optional] 
**SoftDescriptorPhone** | **string** | A payment gateway-specific field that maps Zuora to other gateways.  | [optional] 
**Status** | **string** | The status of the payment.  | [optional] 
**SubmittedOn** | **DateTime** | The date and time when the payment was submitted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Success** | **bool** | Indicates if the request is processed successfully.  | [optional] 
**Type** | **string** | The type of the payment.  | [optional] 
**UnappliedAmount** | **double** | The unapplied amount of the payment.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the payment.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the payment was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2019-03-02 15:36:10.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

