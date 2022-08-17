# ZuoraClient.Model.ListOfExchangeRates
Container for exchange rate information on a given date. The field name is the date in `yyyy-mm-dd` format, for example, 2016-01-15. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CURRENCY** | **string** | The exchange rate on the **providerExchangeRateDate**. The field name is the ISO currency code of the currency, for example, &#x60;EUR&#x60;.  There may be more than one currency returned for a given **providerExchangeRateDate**. If the rate for a certain currency is not available on the **providerExchangeRateDate**, the currency is not returned in the response.  | [optional] 
**ProviderExchangeRateDate** | **DateTime** | The date of the exchange rate used. The date is in &#x60;yyyy-mm-dd&#x60; format.  Corresponds to the value specified in the Provider Exchange Rate Date column in the Import Foreign Exchange Rates template when you uploaded the rates through the Mass Updater.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

