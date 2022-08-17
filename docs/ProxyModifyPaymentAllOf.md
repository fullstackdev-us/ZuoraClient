# ZuoraClient.Model.ProxyModifyPaymentAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The unique account ID for the customer that the payment is for.  | [optional] 
**AccountingCode** | **string** | The accounting code for the payment. Accounting codes group transactions that contain similar accounting attributes.  | [optional] 
**Amount** | **double** | The amount of the payment.  | [optional] 
**EffectiveDate** | **DateTime** | The date when the payment takes effect.  | [optional] 
**PaymentMethodId** | **string** | The ID of the payment method used for the payment.   For a specified credit card payment method, it is recommended that [the support for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions) for this payment method is already enabled.  | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Zuora Payments.  | [optional] 
**Status** | **string** | The updated status of the payment. The value depends on the type of payment.  - For Electronic payment, the available value is &#x60;Voided&#x60;. - For External payment, the available value is &#x60;Canceled&#x60;.  | [optional] 
**TransferredToAccounting** | **string** | Whether the refund was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite.  | [optional] 
**Type** | **string** | The type of the payment, whether the payment is external or electronic.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

