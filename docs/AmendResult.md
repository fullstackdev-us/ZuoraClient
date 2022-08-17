# ZuoraClient.Model.AmendResult

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AmendmentIds** | **List&lt;string&gt;** | A list of the IDs of the associated amendments. There can be as many as three amendment IDs. Use a comma to separate each amendment ID.  | [optional] 
**ChargeMetricsData** | [**ChargeMetricsData**](ChargeMetricsData.md) |  | [optional] 
**CreditMemoDatas** | [**List&lt;ActionAmendCreditMemoData&gt;**](ActionAmendCreditMemoData.md) |  | [optional] 
**CreditMemoId** | **string** |  | [optional] 
**Errors** | [**List&lt;ActionsErrorResponse&gt;**](ActionsErrorResponse.md) |  | [optional] 
**GatewayResponse** | **string** |  | [optional] 
**GatewayResponseCode** | **string** |  | [optional] 
**InvoiceDatas** | [**List&lt;ActionAmendInvoiceData&gt;**](ActionAmendInvoiceData.md) | This array of invoices contains one invoice only as one invoice is generated for one subscription.  | [optional] 
**InvoiceId** | **string** |  | [optional] 
**PaymentId** | **string** |  | [optional] 
**PaymentTransactionNumber** | **string** |  | [optional] 
**SubscriptionId** | **string** |  | [optional] 
**Success** | **bool** |  | [optional] 
**TotalDeltaMrr** | **double** | &#x60;TotalDeltaMrr&#x60; is calculated by the following formula:   TotalDeltaMrr &#x3D; newSubscription.CMRR - originalSubscription.CMRR   See [here](https://knowledgecenter.zuora.com/Billing/Subscriptions/Customer_Accounts/A_How_to_Manage_Customer_Accounts/E_Key_Metrics/B_Monthly_Recurring_Revenue#Contracted_MRR) for the definition of CMRR. The new subscriptin represents the later version of an subscription after an amendment. The original subscription represents the original version of the subscription before the amendment.   | [optional] 
**TotalDeltaTcv** | **double** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

