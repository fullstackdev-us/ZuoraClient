# ZuoraClient.Model.OwnerTransfer
Information about an order action of type `OwnerTransfer`.  **Note:** The Owner Transfer feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BillToContactId** | **string** | The contact id of the bill to contact that the subscription is being transferred to.  | [optional] 
**ClearingExistingBillToContact** | **bool** | Whether to clear the existing bill-to contact ID at the subscription level. This field is mutually exclusive with the &#x60;paymentTerm&#x60; field.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] [default to false]
**ClearingExistingPaymentTerm** | **bool** | Whether to clear the existing payment term at the subscription level. This field is mutually exclusive with the &#x60;billToContactId&#x60; field.  **Note**: If you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled, this field is unavailable in the request body and the value of this field is &#x60;null&#x60; in the response body.  | [optional] [default to false]
**DestinationAccountNumber** | **string** | The account number of the account that the subscription is being transferred to.  | [optional] 
**DestinationInvoiceAccountNumber** | **string** | The account number of the invoice owner account that the subscription is being transferred to.  | [optional] 
**PaymentTerm** | **string** | Name of the payment term associated with the account. For example, \&quot;Net 30\&quot;. The payment term determines the due dates of invoices.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

