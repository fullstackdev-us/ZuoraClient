# ZuoraClient.Model.DebitMemoFromChargeDetailType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amount** | **double** | The amount of the debit memo item.  **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;224.0&#x60; or later.  | [optional] 
**ChargeId** | **string** | The ID of the product rate plan charge that the debit memo is created from.  **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | 
**Comment** | **string** | Comments about the product rate plan charge.  **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or before.  | [optional] 
**Description** | **string** | The description of the product rate plan charge.  **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | [optional] 
**FinanceInformation** | [**DebitMemoFromChargeDetailTypeAllOfFinanceInformation**](DebitMemoFromChargeDetailTypeAllOfFinanceInformation.md) |  | [optional] 
**MemoItemAmount** | **double** | The amount of the debit memo item.  **Note**: This field is not available if you set the &#x60;zuora-version&#x60; request header to &#x60;224.0&#x60; or later.  | [optional] 
**ProductRatePlanChargeId** | **string** | The ID of the product rate plan charge that the debit memo is created from.  **Note**: This field is only available if you set the &#x60;zuora-version&#x60; request header to &#x60;257.0&#x60; or later.  | 
**Quantity** | **double** | The number of units for the debit memo item.  | [optional] 
**ServiceEndDate** | **DateTime** | The service end date of the debit memo item. If not specified, the effective end date of the corresponding product rate plan will be used.  | [optional] 
**ServiceStartDate** | **DateTime** | The service start date of the debit memo item. If not specified, the effective start date of the corresponding product rate plan will be used.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

