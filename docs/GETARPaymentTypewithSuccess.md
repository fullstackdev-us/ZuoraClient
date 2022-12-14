# ZuoraClient.Model.GETARPaymentTypewithSuccess

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account that the payment is for.  | [optional] 
**AccountNumber** | **string** | The number of the customer account that the payment is for.  | [optional] 
**Amount** | **double** | The total amount of the payment.  | [optional] 
**AppliedAmount** | **double** | The applied amount of the payment.  | [optional] 
**AuthTransactionId** | **string** | The authorization transaction ID from the payment gateway.  | [optional] 
**BankIdentificationNumber** | **string** | The first six or eight digits of the credit card or debit card used for the payment, when applicable.  | [optional] 
**CancelledOn** | **DateTime** | The date and time when the payment was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Comment** | **string** | Comments about the payment.  | [optional] 
**CreatedById** | **string** | The ID of the Zuora user who created the payment part.  | [optional] 
**CreatedDate** | **DateTime** | The date and time when the payment was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10.  | [optional] 
**CreditBalanceAmount** | **double** | The amount that the payment transfers to the credit balance. The value is not &#x60;0&#x60; only for those payments that come from legacy payment operations performed without the Invoice Settlement feature.  | [optional] 
**Currency** | **string** | When Standalone Payment is not enabled, the &#x60;currency&#x60; of the payment must be the same as the payment currency defined in the customer account settings through Zuora UI.  When Standalone Payment is enabled and &#x60;standalone&#x60; is &#x60;true&#x60;, the &#x60;currency&#x60; of the standalone payment can be different from the payment currency defined in the customer account settings. The amount will not be summed up to the account balance or key metrics regardless of currency.  | [optional] 
**EffectiveDate** | **DateTime** | The date and time when the payment takes effect, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**FinanceInformation** | [**GETARPaymentTypeAllOfFinanceInformation**](GETARPaymentTypeAllOfFinanceInformation.md) |  | [optional] 
**GatewayId** | **string** | The ID of the gateway instance that processes the payment.  | [optional] 
**GatewayOrderId** | **string** | A merchant-specified natural key value that can be passed to the electronic payment gateway when a payment is created.  | [optional] 
**GatewayReconciliationReason** | **string** | The reason of gateway reconciliation.  | [optional] 
**GatewayReconciliationStatus** | **string** | The status of gateway reconciliation.  | [optional] 
**GatewayResponse** | **string** | The message returned from the payment gateway for the payment. This message is gateway-dependent.  | [optional] 
**GatewayResponseCode** | **string** | The code returned from the payment gateway for the payment. This code is gateway-dependent.  | [optional] 
**GatewayState** | **string** | The status of the payment in the gateway; use for reconciliation.   | [optional] 
**Id** | **string** | The unique ID of the payment. For example, 4028905f5a87c0ff015a87eb6b75007f.  | [optional] 
**MarkedForSubmissionOn** | **DateTime** | The date and time when a payment was marked and waiting for batch submission to the payment process, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Number** | **string** | The unique identification number of the payment. For example, P-00000001.  | [optional] 
**PaymentMethodId** | **string** | The unique ID of the payment method that the customer used to make the payment.  | [optional] 
**PaymentMethodSnapshotId** | **string** | The unique ID of the payment method snapshot which is a copy of the particular Payment Method used in a transaction.  | [optional] 
**PaymentScheduleNumber** | **string** | The number of the payment schedule that is linked to the payment. See [Link payments to payment schedules](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Payment_Schedules/Link_payments_with_payment_schedules) for more information. | [optional] 
**PayoutId** | **string** | The payout ID of the payment from the gateway side.  | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Zuora Payments.  | [optional] 
**RefundAmount** | **double** | The amount of the payment that is refunded.  | [optional] 
**SecondPaymentReferenceId** | **string** | The transaction ID returned by the payment gateway if there is an additional transaction for the payment. Use this field to reconcile payments between your gateway and Zuora Payments.  | [optional] 
**SettledOn** | **DateTime** | The date and time when the payment was settled in the payment processor, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. This field is used by the Spectrum gateway only and not applicable to other gateways.  | [optional] 
**SoftDescriptor** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.  | [optional] 
**SoftDescriptorPhone** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.  | [optional] 
**Standalone** | **bool** | This field is only available if the support for standalone payment is enabled.  The value &#x60;true&#x60; indicates this is a standalone payment that is created and processed in Zuora through Zuora gateway integration but will be settled outside of Zuora. No settlement data will be created. The standalone payment cannot be applied, unapplied, or transferred.  The value &#x60;false&#x60; indicates this is an ordinary payment that is created, processed, and settled in Zuora.  | [optional] [default to false]
**Status** | **string** | The status of the payment.  | [optional] 
**SubmittedOn** | **DateTime** | The date and time when the payment was submitted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Type** | **string** | The type of the payment.  | [optional] 
**UnappliedAmount** | **double** | The unapplied amount of the payment.  | [optional] 
**UpdatedById** | **string** | The ID of the Zuora user who last updated the payment.  | [optional] 
**UpdatedDate** | **DateTime** | The date and time when the payment was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-02 15:36:10.  | [optional] 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the payment&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**OriginNS** | **string** | Origin of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the payment was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**TransactionNS** | **string** | Related transaction in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

