# ZuoraClient.Model.ProxyCreatePayment

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The unique account ID for the customer that the payment is for.  | 
**AccountingCode** | **string** | The accounting code for the payment. Accounting codes group transactions that contain similar accounting attributes.  | [optional] 
**Amount** | **double** | The amount of the payment.  If Invoice Settlement is enabled, this field is required.  | [optional] 
**AppliedCreditBalanceAmount** | **double** | If you have the Invoice Settlement feature disabled, the value of this field is the amount of the payment to apply to a credit balance. This field is only required if the &#x60;AppliedInvoiceAmount&#x60; field value is null.  If you have the Invoice Settlement feature enabled, the value of this field is created as the unapplied amount.  | [optional] 
**AppliedInvoiceAmount** | **decimal** | The amount of the payment to apply to an invoice. This field is only required if either the &#x60;InvoiceId&#x60; or &#x60;InvoiceNumber&#x60; field is not null.  | [optional] 
**AuthTransactionId** | **string** | The authorization transaction ID from the payment gateway. Use this field for electronic payments, such as credit cards.  The following payment gateways support this field:   - Adyen Integration v2.0   - CyberSource 1.28   - CyberSource 1.97   - CyberSource 2.0   - Chase Paymentech Orbital   - Ingenico ePayments   - SlimPay   - Verifi Global Payment Gateway   - WePay Payment Gateway Integration  | [optional] 
**Comment** | **string** | Additional information related to the payment.  | [optional] 
**EffectiveDate** | **DateTime** | The date when the payment takes effect.  **Note:** This is an optional field that only applies to electronic payments. When specified, it must be set to the date of today.  | 
**Gateway** | **string** | The name of the gateway instance that processes the payment. When creating a payment, the value of this field must be a valid gateway instance name, and this gateway must support the specific payment method. If no value is specified, the default gateway on the Account will be used.  | [optional] 
**GatewayOptionData** | [**ProxyCreatePaymentAllOfGatewayOptionData**](ProxyCreatePaymentAllOfGatewayOptionData.md) |  | [optional] 
**GatewayOrderId** | **string** | A merchant-specified natural key value that can be passed to the electronic payment gateway when a payment is created. If not specified, the payment number will be passed in instead.  Gateways check duplicates on the gateway order ID to ensure that the merchant do not accidentally enter the same transaction twice. This ID can also be used to do reconciliation and tie the payment to a natural key in external systems. The source of this ID varies by merchant. Some merchants use their shopping cart order IDs, and others use something different. Merchants use this ID to track transactions in their eCommerce systems.  | [optional] 
**GatewayResponse** | **string** | The message returned from the payment gateway for the payment. This message is gateway-dependent.  | [optional] 
**GatewayResponseCode** | **string** | The code returned from the payment gateway for the payment. This code is gateway-dependent.  | [optional] 
**GatewayState** | **string** | The status of the payment in the gateway; use for reconciliation.  | [optional] 
**InvoiceId** | **string** | The ID of the invoice that the payment is applied to. When applying a payment to a single invoice, this field is only required if the &#x60;InvoiceNumber&#x60; field is null.  | [optional] 
**InvoiceNumber** | **string** | The unique identification number for the invoice that the payment is applied to. When applying a payment to a single invoice, this field is only required if the &#x60;InvoiceId&#x60; field is null.  | [optional] 
**InvoicePaymentData** | [**InvoicePaymentData**](InvoicePaymentData.md) |  | [optional] 
**PaymentMethodId** | **string** | The ID of the payment method used for the payment.   For a specified credit card payment method, it is recommended that [the support for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions) for this payment method is already enabled.  | 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Zuora Payments.  | [optional] 
**SoftDescriptor** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.   Zuora passes this field to Verifi directly without verification. In general, this field will be defaulted by the gateway. For Orbital, this field contains two fields separated by an asterisk, &#x60;SDMerchantName&#x60; and &#x60;SDProductionInfo&#x60;. For more information, contact your payment gateway.  | [optional] 
**SoftDescriptorPhone** | **string** | A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi.  Verifi and Orbital determine how to format this string. For more information, contact your payment gateway.  | [optional] 
**Status** | **string** | The status of the payment in Zuora. The only available value is &#x60;Processed&#x60;.  | 
**Type** | **string** | The type of the payment, whether the payment is external or electronic.  | 
**IntegrationIdNS** | **string** | ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**IntegrationStatusNS** | **string** | Status of the payment&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**OriginNS** | **string** | Origin of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**SyncDateNS** | **string** | Date when the payment was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 
**TransactionNS** | **string** | Related transaction in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

