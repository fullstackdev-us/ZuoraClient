# ZuoraClient.Model.PreviewOrderChargeOverride
Charge associated with a rate plan. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Billing** | [**ChargeOverrideBilling**](ChargeOverrideBilling.md) |  | [optional] 
**ChargeNumber** | **string** | Charge number of the charge. For example, C-00000307.  If you do not set this field, Zuora will generate the charge number.  | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of a Rate Plan Charge object.  | [optional] 
**Description** | **string** | Description of the charge.  | [optional] 
**DrawdownRate** | **decimal** | **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The [conversion rate](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge#UOM_Conversion) between Usage UOM and Drawdown UOM for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). Must be a positive number (&gt;0).  | [optional] 
**EndDate** | [**EndConditions**](EndConditions.md) |  | [optional] 
**PrepaidQuantity** | **decimal** | **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The number of units included in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). Must be a positive number (&gt;0).  | [optional] 
**Pricing** | [**ChargeOverridePricing**](ChargeOverridePricing.md) |  | [optional] 
**ProductRatePlanChargeId** | **string** | Internal identifier of the product rate plan charge that the charge is based on.  | 
**RevRecCode** | **string** | Revenue Recognition Code  | [optional] 
**RevRecTriggerCondition** | **string** | Specifies the revenue recognition trigger condition.    * &#x60;Contract Effective Date&#x60;    * &#x60;Service Activation Date&#x60;   * &#x60;Customer Acceptance Date&#x60;  | [optional] 
**RevenueRecognitionRuleName** | **string** | Specifies the revenue recognition rule.    * &#x60;Recognize upon invoicing&#x60;    * &#x60;Recognize daily over time&#x60;  | [optional] 
**StartDate** | [**PreviewOrderTriggerParams**](PreviewOrderTriggerParams.md) |  | [optional] 
**UniqueToken** | **string** | Unique identifier for the charge. This identifier enables you to refer to the charge before the charge has an internal identifier in Zuora.  For instance, suppose that you want to use a single order to add a product to a subscription and later update the same product. When you add the product, you can set a unique identifier for the charge. Then when you update the product, you can use the same unique identifier to specify which charge to modify.  | [optional] 
**ValidityPeriodType** | **string** | **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge).        | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

