# ZuoraClient.Model.GETRSDetailType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | An account ID.  | [optional] 
**Amount** | **decimal** | The revenue schedule amount, which is the sum of all revenue items. This field cannot be null and must be formatted based on the currency, such as &#x60;JPY 30&#x60; or &#x60;USD 30.15&#x60;. Test out the currency to ensure you are using the proper formatting otherwise, the response will fail and this error message is returned: &#x60;Allocation amount with wrong decimal places.&#x60;  | [optional] 
**CreatedOn** | **DateTime** | The date and time when the record was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**Currency** | **string** | The type of currency used.  | [optional] 
**LinkedTransactionId** | **string** | The linked transaction ID for billing transactions. This field is used for all rules except for the custom unlimited or manual recognition rule models. If using the custom unlimited rule model, then the field value must be null. If the field is not null, then the referenceId field must be null.  | [optional] 
**LinkedTransactionNumber** | **string** | The number for the linked invoice item or invoice item adjustment transaction. This field is used for all rules except for the custom unlimited or manual recognition rule models. If using the custom unlimited or manual recognition rule models, then the field value is null.  | [optional] 
**LinkedTransactionType** | **string** | The type of linked transaction for billing transactions, which can be invoice item or invoice item adjustment. This field is used for all rules except for the custom unlimited or manual recognition rule models.  | [optional] 
**Notes** | **string** | Additional information about this record.  | [optional] 
**Number** | **string** | Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;.  | [optional] 
**RecognitionRuleName** | **string** | The name of the recognition rule.  | [optional] 
**RecognizedRevenue** | **decimal** | The revenue that was distributed in a closed accounting period.  | [optional] 
**ReferenceId** | **string** | Reference ID is used only in the custom unlimited rule to create a revenue schedule. In this scenario, the revenue schedule is not linked to an invoice item or invoice item adjustment.  | [optional] 
**RevenueItems** | [**List&lt;GETRsRevenueItemType&gt;**](GETRsRevenueItemType.md) | Revenue items are listed in ascending order by the accounting period start date.  | [optional] 
**RevenueScheduleDate** | **DateTime** | The effective date of the revenue schedule. For example, the revenue schedule date for bookings-based revenue recognition is typically set to the order date or contract date.  The date cannot be in a closed accounting period. The date must be in &#x60;yyyy-mm-dd&#x60; format.  | [optional] 
**SubscriptionChargeId** | **string** | The original subscription charge ID.  | [optional] 
**SubscriptionId** | **string** | The original subscription ID.  | [optional] 
**Success** | **bool** | Returns &#x60;true&#x60; if the request was processed successfully.  | [optional] 
**UndistributedUnrecognizedRevenue** | **decimal** | Revenue in the open-ended accounting period.  | [optional] 
**UnrecognizedRevenue** | **decimal** | Revenue distributed in all open accounting periods, which includes the open-ended accounting period.  | [optional] 
**UpdatedOn** | **DateTime** | The date and time when the revenue automation start date was set, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; formst.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

