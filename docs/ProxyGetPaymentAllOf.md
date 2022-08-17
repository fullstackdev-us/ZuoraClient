# ZuoraClient.Model.ProxyGetPaymentAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The unique account ID for the customer that the payment is for.  | [optional] 
**AccountingCode** | **string** | The accounting code for the payment. Accounting codes group transactions that contain similar accounting attributes.  | [optional] 
**Amount** | **double** | The amount of the payment.  | [optional] 
**AppliedAmount** | **double** | The applied amount of the payment.  **Note**: This field is only available if you have the Invoice Settlement feature enabled.  | [optional] 
**AppliedCreditBalanceAmount** | **double** | If you have the Invoice Settlement feature disabled, the value of this field is the amount of the payment to apply to a credit balance.  If you have the Invoice Settlement feature enabled, the value of this field returned in the response is &#x60;0&#x60; for the payments that are created after the enablement.  | [optional] 
**AuthTransactionId** | **string** | The authorization transaction ID from the payment gateway.   | [optional] 
**BankIdentificationNumber** | **string** | The first six or eight digits of the credit card or debit card used for the payment, when applicable.   | [optional] 
**CancelledOn** | **DateTime** | The date and time when the payment was canceled.  | [optional] 
**Comment** | **string** | Additional information related to the payment.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the payment.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the payment was created.  | [optional] 
**EffectiveDate** | **DateTime** | The date when the payment takes effect.  | [optional] 
**Gateway** | **string** | The name of the gateway instance that processes the payment.   | [optional] 
**GatewayOrderId** | **string** | A merchant-specified natural key value that can be passed to the electronic payment gateway when a payment is created. If not specified, the payment number will be passed in instead.  | [optional] 
**GatewayResponse** | **string** | The message returned from the payment gateway for the payment. This message is gateway-dependent.  | [optional] 
**GatewayResponseCode** | **string** | The code returned from the payment gateway for the payment. This code is gateway-dependent.  | [optional] 
**GatewayState** | **string** | The status of the payment in the gateway; use for reconciliation.  | [optional] 
**Id** | **string** | The unique ID of a payment. For example, 2c92c095592623ea01596621ada84352.  | [optional] 
**MarkedForSubmissionOn** | **DateTime** | The date and time when a payment was marked and waiting for batch submission to the payment process.   | [optional] 
**PaymentMethodId** | **string** | The ID of the payment method used for the payment.   | [optional] 
**PaymentMethodSnapshotId** | **string** | The unique ID of the payment method snapshot which is a copy of the particular payment method used in a transaction.  | [optional] 
**PaymentNumber** | **string** | The unique identification number of the payment. For example, P-00000028.  | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Zuora Payments.  | [optional] 
**RefundAmount** | **double** | The amount of the payment that is refunded. The value of this field is &#x60;0&#x60; if no refund is made against the payment.  | [optional] 
**SecondPaymentReferenceId** | **string** | The transaction ID returned by the payment gateway if there is an additional transaction for the payment. Use this field to reconcile payments between your gateway and Zuora Payments.  | [optional] 
**SettledOn** | **DateTime** | The date and time when the payment was settled in the payment processor. This field is used by the Spectrum gateway only and not applicable to other gateways.  | [optional] 
**SoftDescriptor** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.   | [optional] 
**SoftDescriptorPhone** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.  | [optional] 
**Source** | **string** | How the payment was created, whether through the API, manually, import, or payment run.  | [optional] 
**SourceName** | **string** | The name of the source. The value is a Payment Run number or a file name.  | [optional] 
**Status** | **string** | The status of the payment in Zuora. The value depends on the type of payments.  - If you have the Invoice Settlement feature disabled, for electronic payments, the status can be &#x60;Processed&#x60;, &#x60;Processing&#x60;, &#x60;Error&#x60;, or &#x60;Voided&#x60;. For external payments, the status can be &#x60;Processed&#x60; or &#x60;Canceled&#x60;. - If you have the Invoice Settlement feature enabled, for electronic payments, the status can be &#x60;Processed&#x60;, &#x60;Processing&#x60;, &#x60;Error&#x60;, or &#x60;Canceled&#x60;. For external payments, the status can be &#x60;Processed&#x60; or &#x60;Canceled&#x60;.  | [optional] 
**SubmittedOn** | **DateTime** | The date and time when the payment was submitted.  | [optional] 
**TransferredToAccounting** | **string** | Indicates if the payment was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite.  | [optional] 
**Type** | **string** | The type of the payment, whether the payment is external or electronic.  | [optional] 
**UnappliedAmount** | **double** | The unapplied amount of the payment.  **Note**: This field is only available if you have the Invoice Settlement feature enabled.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the payment.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the payment was last updated.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

