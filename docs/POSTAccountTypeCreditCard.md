# ZuoraClient.Model.POSTAccountTypeCreditCard
**Note:** This field has been deprecated, and is currently available only for backward compatibility. Use the `paymentMethod` field instead to create a payment method associated with this account.  Container for information on a credit card to associate with this account.  If the `autoPay` field is set to `true`, you must provide one of the `paymentMethod`, `creditCard`, or `hpmCreditCardPaymentMethodId` field, but not multiple.  After a credit card payment method is created, it is recommended to enable [the support for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions) for this payment method. See [Migrate an existing payment method for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions/Configuration_procedures/Migrate_an_existing_payment_method) or [Migrate all existing payment methods for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions/Configuration_procedures/Migrate_all_existing_payment_methods_for_stored_credential_transactions) for more information. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CardHolderInfo** | [**POSTAccountTypeCreditCardAllOfCardHolderInfo**](POSTAccountTypeCreditCardAllOfCardHolderInfo.md) |  | 
**CardNumber** | **string** | Card number, up to 16 characters. Once created, this field can&#39;t be updated or queried, and is only available in masked format (e.g., XXXX-XXXX-XXXX-1234).  | 
**CardType** | **string** | The type of the credit card.  Possible values  include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways).  | 
**ExpirationMonth** | **string** | Two-digit expiration month (01-12).  | 
**ExpirationYear** | **string** | Four-digit expiration year.  | 
**SecurityCode** | **string** | The CVV or CVV2 security code of the card. To ensure PCI compliance, this value is not stored and cannot be queried.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

