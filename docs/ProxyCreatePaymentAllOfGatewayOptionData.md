# ZuoraClient.Model.ProxyCreatePaymentAllOfGatewayOptionData
A field used to pass gateway options. Zuora allows you to pass in special gateway-specific parameters for payments through the [gateway integrations that support gateway options](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/LA_Hosted_Payment_Pages/B_Payment_Pages_2.0/J_Client_Parameters_for_Payment_Pages_2.0#Gateway_Options).  For each of these special parameters, you supply the name-value pair and Zuora passes it to the gateway. This allows you to add functionality that's supported by a specific gateway but currently not supported by Zuora.  Zuora sends all the information that you specified to the gateway. If you specify any unsupported gateway option parameters, they will be ignored without error prompts. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**GatewayOption** | [**List&lt;GatewayOption&gt;**](GatewayOption.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

