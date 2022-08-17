# ZuoraClient.Model.CreatePaymentMethodBankTransfer

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**IBAN** | **string** | The International Bank Account Number. This field is required if the &#x60;type&#x60; field is set to &#x60;SEPA&#x60;.  | [optional] 
**AccountHolderInfo** | [**CreatePaymentMethodBankTransferAccountHolderInfo**](CreatePaymentMethodBankTransferAccountHolderInfo.md) |  | [optional] 
**AccountNumber** | **string** | The number of the customer&#39;s bank account. This field is required for the following bank transfer payment methods:   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;)  | [optional] 
**BankCode** | **string** | The sort code or number that identifies the bank. This is also known as the sort code. This field is required for the following bank transfer payment methods:   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;)  | [optional] 
**BranchCode** | **string** | The branch code of the bank used for direct debit. This field is required for the following bank transfer payment methods:   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;)  | [optional] 
**BusinessIdentificationCode** | **string** | The BIC code used for SEPA.  | [optional] 
**CurrencyCode** | **string** | The currency used for payment method authorization.  If this field is not specified, &#x60;currency&#x60; specified for the account is used for payment method authorization. If no currency is specified for the account, the default currency of the account is then used.  | [optional] 
**IdentityNumber** | **string** | The identity number used for Bank Transfer. This field is required for the following bank transfer payment methods:   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;)  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

