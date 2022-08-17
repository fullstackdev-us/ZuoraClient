# ZuoraClient.Model.CreatePaymentMethodBankTransferAccountHolderInfo
This container field is required for the following bank transfer payment methods. The nested `accountHolderName` field is required.   - Direct Debit NZ (`Becsnz`)   - Single Euro Payments Area (`SEPA`)   - Direct Debit UK (`Bacs`)   - Denmark Direct Debit (`Betalingsservice`)   - Sweden Direct Debit (`Autogiro`)   - Canadian Pre-Authorized Debit (`PAD`) 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountHolderName** | **string** | Required.  The full name of the bank account holder.  | [optional] 
**AddressLine1** | **string** | The first line of the address for the account holder.  This field is required for SEPA Direct Debit payment methods on Stripe v2.  | [optional] 
**AddressLine2** | **string** | The second line of the address for the account holder.   | [optional] 
**City** | **string** | The city where the account holder stays.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.  | [optional] 
**Country** | **string** | The country where the account holder stays.  This field is required for SEPA Direct Debit payment methods on Stripe v2.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.  | [optional] 
**Email** | **string** | The email address of the account holder.  | [optional] 
**FirstName** | **string** | The first name of the account holder.  | [optional] 
**LastName** | **string** | The last name of the account holder.  | [optional] 
**Phone** | **string** | The phone number of the account holder.  | [optional] 
**State** | **string** | The state where the account holder stays.  | [optional] 
**ZipCode** | **string** | The zip code for the address of the account holder.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

