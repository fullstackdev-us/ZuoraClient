# ZuoraClient.Model.PUTRefundTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Comment** | **string** | Comments about the refund.  | [optional] 
**FinanceInformation** | [**PUTRefundTypeAllOfFinanceInformation**](PUTRefundTypeAllOfFinanceInformation.md) |  | [optional] 
**ReasonCode** | **string** | A code identifying the reason for the transaction. The value must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code.  | [optional] 
**ReferenceId** | **string** | The transaction ID returned by the payment gateway. Use this field to reconcile refunds between your gateway and Zuora Payments.  You can only update the reference ID for external refunds.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

