# ZuoraClient.Model.OrderLineItemCommonPostOrder

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UOM** | **string** | Specifies the units to measure usage.  | [optional] 
**AccountingCode** | **string** | The accounting code for the Order Line Item.  | [optional] 
**AdjustmentLiabilityAccountingCode** | **string** | The accounting code on the Order Line Item object for customers using [Zuora Billing - Revenue Integration](https://knowledgecenter.zuora.com/Zuora_Revenue/Zuora_Billing_-_Revenue_Integration).  | [optional] 
**AdjustmentRevenueAccountingCode** | **string** | The accounting code on the Order Line Item object for customers using [Zuora Billing - Revenue Integration](https://knowledgecenter.zuora.com/Zuora_Revenue/Zuora_Billing_-_Revenue_Integration).  | [optional] 
**AmountPerUnit** | **decimal** | The actual charged amount per unit for the Order Line Item.  If you set the &#x60;inlineDiscountType&#x60;, &#x60;inlineDiscountPerUnit&#x60;, and &#x60;listPricePerUnit&#x60; fields, the system will automatically generate the &#x60;amountPerUnit&#x60; field. You shall not set the &#x60;amountPerUnit&#x60; field by yourself.  | [optional] 
**BillTargetDate** | **DateTime** | The target date for the Order Line Item to be picked up by bill run for billing.  | [optional] 
**ContractAssetAccountingCode** | **string** | The accounting code on the Order Line Item object for customers using [Zuora Billing - Revenue Integration](https://knowledgecenter.zuora.com/Zuora_Revenue/Zuora_Billing_-_Revenue_Integration).  | [optional] 
**ContractLiabilityAccountingCode** | **string** | The accounting code on the Order Line Item object for customers using [Zuora Billing - Revenue Integration](https://knowledgecenter.zuora.com/Zuora_Revenue/Zuora_Billing_-_Revenue_Integration).  | [optional] 
**ContractRecognizedRevenueAccountingCode** | **string** | The accounting code on the Order Line Item object for customers using [Zuora Billing - Revenue Integration](https://knowledgecenter.zuora.com/Zuora_Revenue/Zuora_Billing_-_Revenue_Integration).  | [optional] 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Order Line Item object.  | [optional] 
**DeferredRevenueAccountingCode** | **string** | The deferred revenue accounting code for the Order Line Item.  | [optional] 
**Description** | **string** | The description of the Order Line Item.  | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude Order Line Item related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] [default to false]
**ExcludeItemBookingFromRevenueAccounting** | **bool** | The flag to exclude Order Line Item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.   | [optional] [default to false]
**InlineDiscountPerUnit** | **decimal** | Use this field in accordance with the &#x60;inlineDiscountType&#x60; field, in the following manner: * If the &#x60;inlineDiscountType&#x60; field is set as &#x60;Percentage&#x60;, this field specifies the discount percentage for each unit of the order line item. For exmaple, if you specify &#x60;5&#x60; in this field, the discount percentage is 5%. * If the &#x60;inlineDiscountType&#x60; field is set as &#x60;FixedAmount&#x60;, this field specifies the discount amount on each unit of the order line item. For exmaple, if you specify &#x60;10&#x60; in this field, the discount amount on each unit of the order line item is 10.  Once you set the &#x60;inlineDiscountType&#x60;, &#x60;inlineDiscountPerUnit&#x60;, and &#x60;listPricePerUnit&#x60; fields, the system will automatically generate the &#x60;amountPerUnit&#x60; field. You shall not set the &#x60;amountPerUnit&#x60; field by yourself.  | [optional] 
**InlineDiscountType** | **string** | Use this field to specify the inline discount type, which can be &#x60;Percentage&#x60;, &#x60;FixedAmount&#x60;, or &#x60;None&#x60;. The default value is &#x60;Percentage&#x60;.  Use this field together with the &#x60;inlineDiscountPerUnit&#x60; field to specify inline discounts for order line items. The inline discount is applied to the list price of an order line item.   Once you set the &#x60;inlineDiscountType&#x60;, &#x60;inlineDiscountPerUnit&#x60;, and &#x60;listPricePerUnit&#x60; fields, the system will automatically generate the &#x60;amountPerUnit&#x60; field. You shall not set the &#x60;amountPerUnit&#x60; field by yourself.  | [optional] 
**ItemName** | **string** | The name of the Order Line Item.  | [optional] 
**ItemNumber** | **string** | The number of the Order Line Item. Use this field to specify a custom item number for your Order Line Item. If you are to use this field,  you must set all the item numbers in an order when there are several order line items in the order.  | [optional] 
**ItemState** | **string** | The state of an Order Line Item. If you want to generate invoice for order line items, you must set this field to &#x60;SentToBilling&#x60;. For invoice preview, you do not need to set this field.  See [Order Line Item states, Order states, and state transitions](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AB_Order_Line_Item_States_and_Order_States) for more information.  | [optional] 
**ItemType** | **string** | The type of the Order Line Item.   | [optional] 
**ListPricePerUnit** | **decimal** | The list price per unit for the Order Line Item.  | [optional] 
**ProductCode** | **string** | The product code for the Order Line Item.  | [optional] 
**ProductRatePlanChargeId** | **DateTime** | Id of a Product Rate Plan Charge. Only one-time charges are supported.  | [optional] 
**PurchaseOrderNumber** | **string** | Used by customers to specify the Purchase Order Number provided by the buyer.  | [optional] 
**Quantity** | **decimal** | The quantity of units, such as the number of authors in a hosted wiki service.  | [optional] 
**RecognizedRevenueAccountingCode** | **string** | The recognized revenue accounting code for the Order Line Item.  | [optional] 
**RelatedSubscriptionNumber** | **string** | Use this field to relate an order line item to a subscription when you create the order line item.  * To relate an order line item to a new subscription which is yet to create in the same \&quot;Create an order\&quot; call, use this field in combination with the &#x60;subscriptions&#x60; &gt; &#x60;subscriptionNumber&#x60; field in the \&quot;Create an order\&quot; operation. Specify this field to the same value as that of the &#x60;subscriptions&#x60; &gt; &#x60;subscriptionNumber&#x60; field when you make the \&quot;Create an order\&quot; call. * To relate an order line item to an existing subscription, specify this field to the subscription number of the existing subscription.  | [optional] 
**RevenueRecognitionRule** | **string** | The Revenue Recognition rule for the Order Line Item.  | [optional] 
**SoldTo** | **string** | The ID of a contact that belongs to the billing account of the order line item. Use this field to assign an existing account as the sold-to contact of an order line item.  | [optional] 
**TaxCode** | **string** | The tax code for the Order Line Item.  | [optional] 
**TaxMode** | **string** | The tax mode for the Order Line Item.  | [optional] 
**TransactionEndDate** | **DateTime** | The date a transaction is completed. The default value of this field is the transaction start date. Also, the value of this field should always equal or be later than the value of the &#x60;transactionStartDate&#x60; field.  | [optional] 
**TransactionStartDate** | **DateTime** | The date a transaction starts. The default value of this field is the order date.  | [optional] 
**UnbilledReceivablesAccountingCode** | **string** | The accounting code on the Order Line Item object for customers using [Zuora Billing - Revenue Integration](https://knowledgecenter.zuora.com/Zuora_Revenue/Zuora_Billing_-_Revenue_Integration).  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

