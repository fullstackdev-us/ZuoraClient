# ZuoraClient.Model.CreditCard
Default payment method associated with an account. Only credit card payment methods are supported.  After a credit card payment method is created, it is recommended to enable [the support for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions) for this payment method. See [Migrate an existing payment method for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions/Configuration_procedures/Migrate_an_existing_payment_method) or [Migrate all existing payment methods for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions/Configuration_procedures/Migrate_all_existing_payment_methods_for_stored_credential_transactions) for more information. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CardHolderInfo** | [**AccountCreditCardHolder**](AccountCreditCardHolder.md) |  | [optional] 
**CardNumber** | **string** | Card number. Once set, you cannot update or query the value of this field. The value of this field is only available in masked format. For example, XXXX-XXXX-XXXX-1234 (hyphens must not be used when you set the credit card number).  | [optional] 
**CardType** | **string** | Type of card.  | [optional] 
**ExpirationMonth** | **int** | Expiration date of the card.  | [optional] 
**ExpirationYear** | **int** | Expiration year of the card.  | [optional] 
**SecurityCode** | **string** | CVV or CVV2 security code of the card. To ensure PCI compliance, Zuora does not store the value of this field.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

