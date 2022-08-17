# ZuoraClient - the C# library for the API Reference: Billing



# Introduction

Welcome to the reference for the Zuora Billing REST API!

To learn about the common use cases of Zuora Billing REST APIs, check out the [API Guides](https://www.zuora.com/developer/api-guides/).

In addition to Zuora API Reference; Billing, we also provide API references for other Zuora products:

  * [API Reference: Collections](https://www.zuora.com/developer/collect-api/)
  * [API Reference: Revenue](https://www.zuora.com/developer/revpro-api/)
    
The Zuora REST API provides a broad set of operations and resources that:

  * Enable Web Storefront integration from your website.
  * Support self-service subscriber sign-ups and account management.
  * Process revenue schedules through custom revenue rule models.
  * Enable manipulation of most objects in the Zuora Billing Object Model.

Want to share your opinion on how our API works for you? <a href=\"https://community.zuora.com/t5/Developers/API-Feedback-Form/gpm-p/21399\" target=\"_blank\">Tell us how you feel </a>about using our API and what we can do to make it better.

## Access to the API

If you have a Zuora tenant, you can access the Zuora REST API via one of the following endpoints:

| Tenant              | Base URL for REST Endpoints |
|- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- --|
|US Cloud 1 Production | https://rest.na.zuora.com  |
|US Cloud 1 API Sandbox |  https://rest.sandbox.na.zuora.com |
|US Cloud 2 Production | https://rest.zuora.com |
|US Cloud 2 API Sandbox | https://rest.apisandbox.zuora.com|
|US Central Sandbox | https://rest.test.zuora.com |  
|US Performance Test | https://rest.pt1.zuora.com |
|US Production Copy | Submit a request at <a href=\"http://support.zuora.com/\" target=\"_blank\">Zuora Global Support</a> to enable the Zuora REST API in your tenant and obtain the base URL for REST endpoints. See [REST endpoint base URL of Production Copy (Service) Environment for existing and new customers](https://community.zuora.com/t5/API/REST-endpoint-base-URL-of-Production-Copy-Service-Environment/td-p/29611) for more information. |
|EU Production | https://rest.eu.zuora.com |
|EU API Sandbox | https://rest.sandbox.eu.zuora.com |
|EU Central Sandbox | https://rest.test.eu.zuora.com |

The Production endpoint provides access to your live user data. Sandbox tenants are a good place to test code without affecting real-world data. If you would like Zuora to provision a Sandbox tenant for you, contact your Zuora representative for assistance.


If you do not have a Zuora tenant, go to <a href=\"https://www.zuora.com/resource/zuora-test-drive\" target=\"_blank\">https://www.zuora.com/resource/zuora-test-drive</a> and sign up for a Production Test Drive tenant. The tenant comes with seed data, including a sample product catalog.

# API Changelog
You can find the <a href=\"https://bit.ly/3JGqyR3\" target=\"_blank\">Changelog</a> of the API Reference: Billing in the Zuora Community.

# Authentication

## OAuth v2.0

Zuora recommends that you use OAuth v2.0 to authenticate to the Zuora REST API. Currently, OAuth is not available in every environment. See [Zuora Testing Environments](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Zuora_Environments) for more information.

Zuora recommends you to create a dedicated API user with API write access on a tenant when authenticating via OAuth, and then create an OAuth client for this user. See <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">Create an API User</a> for how to do this. By creating a dedicated API user, you can control permissions of the API user without affecting other non-API users.

If a user is deactivated, all of the user's OAuth clients will be automatically deactivated.

Authenticating via OAuth requires the following steps:
1. Create a Client
2. Generate a Token
3. Make Authenticated Requests

### Create a Client

You must first [create an OAuth client](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users#Create_an_OAuth_Client_for_a_User) in the Zuora UI. To do this, you must be an administrator of your Zuora tenant. This is a one-time operation. You will be provided with a Client ID and a Client Secret. Please note this information down, as it will be required for the next step.

**Note:** The OAuth client will be owned by a Zuora user account. If you want to perform PUT, POST, or DELETE operations using the OAuth client, the owner of the OAuth client must have a Platform role that includes the \"API Write Access\" permission.

### Generate a Token

After creating a client, you must make a call to obtain a bearer token using the [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) operation. This operation requires the following parameters:
- `client_id` - the Client ID displayed when you created the OAuth client in the previous step
- `client_secret` - the Client Secret displayed when you created the OAuth client in the previous step
- `grant_type` - must be set to `client_credentials`

**Note**: The Client ID and Client Secret mentioned above were displayed when you created the OAuth Client in the prior step. The [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) response specifies how long the bearer token is valid for. You should reuse the bearer token until it is expired. When the token is expired, call [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) again to generate a new one.

### Make Authenticated Requests

To authenticate subsequent API requests, you must provide a valid bearer token in an HTTP header:

`Authorization: Bearer {bearer_token}`

If you have [Zuora Multi-entity](https://www.zuora.com/developer/api-reference/#tag/Entities) enabled, you need to set an additional header to specify the ID of the entity that you want to access. You can use the `scope` field in the [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) response to determine whether you need to specify an entity ID.

If the `scope` field contains more than one entity ID, you must specify the ID of the entity that you want to access. For example, if the `scope` field contains `entity.1a2b7a37-3e7d-4cb3-b0e2-883de9e766cc` and `entity.c92ed977-510c-4c48-9b51-8d5e848671e9`, specify one of the following headers:
- `Zuora-Entity-Ids: 1a2b7a37-3e7d-4cb3-b0e2-883de9e766cc`
- `Zuora-Entity-Ids: c92ed977-510c-4c48-9b51-8d5e848671e9`

**Note**: For a limited period of time, Zuora will accept the `entityId` header as an alternative to the `Zuora-Entity-Ids` header. If you choose to set the `entityId` header, you must remove all \"-\" characters from the entity ID in the `scope` field.

If the `scope` field contains a single entity ID, you do not need to specify an entity ID.

## Other Supported Authentication Schemes

Zuora continues to support the following additional legacy means of authentication:

  * Use username and password. Include authentication with each request in the header: 
  
    * `apiAccessKeyId` 
    * `apiSecretAccessKey`
    
    Zuora recommends that you create an API user specifically for making API calls. See <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">Create an API User</a> for more information.
  
  * Use an authorization cookie. The cookie authorizes the user to make calls to the REST API for the duration specified in  **Administration > Security Policies > Session timeout**. The cookie expiration time is reset with this duration after every call to the REST API. To obtain a cookie, call the [Connections](https://www.zuora.com/developer/api-reference/#tag/Connections) resource with the following API user information: 
  
    *   ID    
    *   Password
    
  * For CORS-enabled APIs only: Include a 'single-use' token in the request header, which re-authenticates the user with each request. See below for more details.

### Entity Id and Entity Name

The `entityId` and `entityName` parameters are only used for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Zuora Multi-entity\"). These are the legacy parameters that Zuora will only continue to support for a period of time. Zuora recommends you to use the `Zuora-Entity-Ids` parameter instead.


The  `entityId` and `entityName` parameters specify the Id and the [name of the entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/B_Introduction_to_Entity_and_Entity_Hierarchy#Name_and_Display_Name \"Introduction to Entity and Entity Hierarchy\") that you want to access, respectively. Note that you must have permission to access the entity. 

You can specify either the `entityId` or `entityName` parameter in the authentication to access and view an entity.

  * If both `entityId` and `entityName` are specified in the authentication, an error occurs. 
  * If neither `entityId` nor `entityName` is specified in the authentication, you will log in to the entity in which your user account is created. 
  

To get the entity Id and entity name, you can use the GET Entities REST call. For more information, see [API User Authentication](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/A_Overview_of_Multi-entity#API_User_Authentication \"API User Authentication\").
  
  ### Token Authentication for CORS-Enabled APIs
  
  The CORS mechanism enables REST API calls to Zuora to be made directly from your customer's browser, with all credit card and security information transmitted directly to Zuora. This minimizes your PCI compliance burden, allows you to implement advanced validation on your payment forms, and  makes your payment forms look just like any other part of your website.
  
For security reasons, instead of using cookies, an API request via CORS uses **tokens** for authentication.

The token method of authentication is only designed for use with requests that must originate from your customer's browser; **it should  not be considered a replacement to the existing cookie authentication** mechanism.

See [Zuora CORS REST](https://knowledgecenter.zuora.com/DC_Developers/C_REST_API/Zuora_CORS_REST \"Zuora CORS REST\") for details on how CORS works and how you can begin to implement customer calls to the Zuora REST APIs. See  [HMAC Signatures](https://www.zuora.com/developer/api-reference/#operation/POSTHMACSignature \"HMAC Signatures\") for details on the HMAC method that returns the authentication token.

# Requests and Responses

## Request IDs 
As a general rule, when asked to supply a \"key\" for an account or subscription (accountKey, account-key, subscriptionKey, subscription-key), you can provide either the actual ID or  the number of the entity.

## HTTP Request Body

Most of the parameters and data accompanying your requests will be contained in the body of the HTTP request. 

The Zuora REST API accepts JSON in the HTTP request body. No other data format (e.g., XML) is supported.

### Data Type

([Actions](https://www.zuora.com/developer/api-reference/#tag/Actions) and CRUD operations only) We recommend that you do not specify the decimal values with quotation marks, commas, and spaces. Use characters of `+-0-9.eE`, for example, `5`, `1.9`, `-8.469`, and `7.7e2`. Also, Zuora does not convert currencies for decimal values.


## Making asynchronous requests

Most Zuora REST API endpoints documented in this API Reference process requests synchronously. In high-throughput scenarios, your requests to these endpoints are usually rate limited. 

One strategy for avoiding rate limits is to make asynchronous requests, and Zuora provides this option to you.

Making asynchronous requests allows you to scale your applications more efficiently by leveraging Zuora's infrastructure to enqueue and execute requests for you without blocking. These requests also use built-in retry semantics, which makes them much less likely to fail for non-deterministic reasons, even in extreme high-throughput scenarios. 
Meanwhile, when you send a request to one of these endpoints, you can receive a response in less than 150 milliseconds and these calls are unlikely to trigger rate limit errors. 

You can make asynchronous requests to the POST, PUT, or DELETE operations, except [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions), for all resources documented in this API Reference.

Take the following steps to take advantage of the asynchronous API:

  1. Set up callout notification
  2. Make asynchronous requests

The following sections describes the high-level steps for you to get the most of the asynchronous API. For detailed instructions, see [Make asynchronous requests](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Make_asynchronous_requests) in the Knowledge Center. 

### Set up notifications

You can create callout notification definitions based on the following custom events through the Zuora UI or the [Create a notification definition](https://www.zuora.com/developer/api-reference/#operation/POST_Create_Notification_Definition) API operation:
  * Async Request Succeeded
  * Async Request Failed

This step ensures that your system receives a callout when an asynchronous request succeeds or fails.


### Make asynchronous requests

By design, asynchronous requests differ from their synchronous counterparts in endpoints, and the HTTP status response code and response body they return. ​​The header parameters and request body schema for asynchronous operations are the same as their synchronous counterparts. 

* The endpoints for asynchronous API operations contain `/async` in the path after `/v1`. See the following table for examples:

| Operation               | Synchronous endpoint  | Asynchronous endpoint      |
|:- -- -- -- - |:- -- -- -- - |:- -- -- -- - |
| Create an account       | `/v1/accounts`        | `/v1/async/accounts`       |
| CRUD: Create an account | `/v1/object/account`  | `/v1/async/object/account` |

* Unlike the 200 OK response for synchronous requests, Zuora returns a 202 Accepted response for all asynchronous requests, and the response body contains only a request ID. 

**Note**: These asynchronous API endpoints are in addition to the previously introduced endpoints that support asynchronous processing. You should continue to use them:
  * [Perform a mass action](https://www.zuora.com/developer/api-reference/#operation/POST_MassUpdater)
  * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously)
  * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)
  * [Create a job to hard delete billing document files](https://www.zuora.com/developer/api-reference/#operation/POST_BillingDocumentFilesDeletionJob)
  * [CRUD: Post or cancel a bill run](https://www.zuora.com/developer/api-reference/#operation/Object_PUTBillRun)
  * [Cancel a journal run](https://www.zuora.com/developer/api-reference/#operation/PUT_JournalRun)
  * [Run trial balance](https://www.zuora.com/developer/api-reference/#operation/PUT_RunTrialBalance)

For more information, see [Make asynchronous requests](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Make_asynchronous_requests).

## Testing a Request

Use a third party client, such as [curl](https://curl.haxx.se \"curl\"), [Postman](https://www.getpostman.com \"Postman\"), or [Advanced REST Client](https://advancedrestclient.com \"Advanced REST Client\"), to test the Zuora REST API.

You can test the Zuora REST API from the Zuora API Sandbox or Production tenants. If connecting to Production, bear in mind that you are working with your live production data, not sample data or test data.

## Testing with Credit Cards

Sooner or later it will probably be necessary to test some transactions that involve credit cards. For suggestions on how to handle this, see [Going Live With Your Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards \"C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards\"
).

## Concurrent Request Limits

Zuora enforces tenant-level concurrent request limits. See <a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits\" target=\"_blank\">Concurrent Request Limits</a> for more information.

## Timeout Limit

If a request does not complete within 120 seconds, the request times out and Zuora returns a Gateway Timeout error.


# Error Handling

If a request to Zuora Billing REST API with an endpoint starting with `/v1` (except [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions) and CRUD operations) fails, the response will contain an eight-digit error code with a corresponding error message to indicate the details of the error.

The following code snippet is a sample error response that contains an error code and message pair:

```
 {
   \"success\": false,
   \"processId\": \"CBCFED6580B4E076\",
   \"reasons\":  [
     {
      \"code\": 53100320,
      \"message\": \"'termType' value should be one of: TERMED, EVERGREEN\"
     }
    ]
 }
```
The `success` field indicates whether the API request has succeeded. The `processId` field is a Zuora internal ID that you can provide to Zuora Global Support for troubleshooting purposes.

The `reasons` field contains the actual error code and message pair. The error code begins with `5` or `6` means that you encountered a certain issue that is specific to a REST API resource in Zuora Billing. For example, `53100320` indicates that an invalid value is specified for the `termType` field of the `subscription` object.

The error code beginning with `9` usually indicates that an authentication-related issue occurred, and it can also indicate other unexpected errors depending on different cases. For example, `90000011` indicates that an invalid credential is provided in the request header. 

When troubleshooting the error, you can divide the error code into two components: REST API resource code and error category code. See the following Zuora error code sample:

<a href=\"https://assets.zuora.com/zuora-documentation/ZuoraErrorCode.jpeg\" target=\"_blank\"><img src=\"https://assets.zuora.com/zuora-documentation/ZuoraErrorCode.jpeg\" alt=\"Zuora Error Code Sample\"></a>


**Note:** Zuora determines resource codes based on the request payload. Therefore, if GET and DELETE requests that do not contain payloads fail, you will get `500000` as the resource code, which indicates an unknown object and an unknown field. 
The error category code of these requests is valid and follows the rules described in the [Error Category Code](https://www.zuora.com/developer/api-reference/#section/Error-Handling/Error-Category-Code) section. 
In such case, you can refer to the returned error message to troubleshoot.


## REST API Resource Codes

The 6-digit resource code indicates the REST API resource, typically a field of a Zuora object, on which the issue occurs. In the preceding example, `531003` refers to the `termType` field of the `subscription` object. 

The value range for all REST API resource codes is from `500000` to `679999`. See [Resource Codes](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Resource_Codes) in the Knowledge Center for a full list of resource codes.

## Error Category Codes

The 2-digit error category code identifies the type of error, for example, resource not found or missing required field. 

The following table describes all error categories and the corresponding resolution:

| Code    | Error category              | Description    | Resolution    |
|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|
| 10      | Permission or access denied | The request cannot be processed because a certain tenant or user permission is missing. | Check the missing tenant or user permission in the response message and contact [Zuora Global Support](https://support.zuora.com) for enablement. |
| 11      | Authentication failed       | Authentication fails due to invalid API authentication credentials. | Ensure that a valid API credential is specified. |
| 20      | Invalid format or value     | The request cannot be processed due to an invalid field format or value. | Check the invalid field in the error message, and ensure that the format and value of all fields you passed in are valid. |
| 21      | Unknown field in request    | The request cannot be processed because an unknown field exists in the request body. | Check the unknown field name in the response message, and ensure that you do not include any unknown field in the request body. |
| 22      | Missing required field      | The request cannot be processed because a required field in the request body is missing. | Check the missing field name in the response message, and ensure that you include all required fields in the request body. |
| 23      | Missing required parameter  | The request cannot be processed because a required query parameter is missing. | Check the missing parameter name in the response message, and ensure that you include the parameter in the query. |
| 30      | Rule restriction            | The request cannot be processed due to the violation of a Zuora business rule. | Check the response message and ensure that the API request meets the specified business rules. |
| 40      | Not found                   | The specified resource cannot be found. | Check the response message and ensure that the specified resource exists in your Zuora tenant. |
| 45      | Unsupported request         | The requested endpoint does not support the specified HTTP method. | Check your request and ensure that the endpoint and method matches. |
| 50      | Locking contention          | This request cannot be processed because the objects this request is trying to modify are being modified by another API request, UI operation, or batch job process. | <p>Resubmit the request first to have another try.</p> <p>If this error still occurs, contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance.</p> |
| 60      | Internal error              | The server encounters an internal error. | Contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance. |
| 61      | Temporary error             | A temporary error occurs during request processing, for example, a database communication error. | <p>Resubmit the request first to have another try.</p> <p>If this error still occurs, contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance. </p>|
| 70      | Request exceeded limit      | The total number of concurrent requests exceeds the limit allowed by the system. | <p>Resubmit the request after the number of seconds specified by the `Retry-After` value in the response header.</p> <p>Check [Concurrent request limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits) for details about Zuora’s concurrent request limit policy.</p> |
| 90      | Malformed request           | The request cannot be processed due to JSON syntax errors. | Check the syntax error in the JSON request body and ensure that the request is in the correct JSON format. |
| 99      | Integration error           | The server encounters an error when communicating with an external system, for example, payment gateway, tax engine provider. | Check the response message and take action accordingly. |


# Pagination

When retrieving information (using GET methods), the optional `pageSize` query parameter sets the maximum number of rows to return in a response. The maximum is `40`; larger values are treated as `40`. If this value is empty or invalid, `pageSize` typically defaults to `10`.

The default value for the maximum number of rows retrieved can be overridden at the method level.

If more rows are available, the response will include a `nextPage` element, which contains a URL for requesting the next page.  If this value is not provided, no more rows are available. No \"previous page\" element is explicitly provided; to support backward paging, use the previous call.

## Array Size

For data items that are not paginated, the REST API supports arrays of up to 300 rows.  Thus, for instance, repeated pagination can retrieve thousands of customer accounts, but within any account an array of no more than 300 rate plans is returned.

# API Versions

The Zuora REST API are version controlled. Versioning ensures that Zuora REST API changes are backward compatible. Zuora uses a major and minor version nomenclature to manage changes. By specifying a version in a REST request, you can get expected responses regardless of future changes to the API.

## Major Version

The major version number of the REST API appears in the REST URL. Currently, Zuora only supports the **v1** major version. For example, `POST https://rest.zuora.com/v1/subscriptions`.

## Minor Version

Zuora uses minor versions for the REST API to control small changes. For example, a field in a REST method is deprecated and a new field is used to replace it. 

Some fields in the REST methods are supported as of minor versions. If a field is not noted with a minor version, this field is available for all minor versions. If a field is noted with a minor version, this field is in version control. You must specify the supported minor version in the request header to process without an error. 

If a field is in version control, it is either with a minimum minor version or a maximum minor version, or both of them. You can only use this field with the minor version between the minimum and the maximum minor versions. For example, the `invoiceCollect` field in the POST Subscription method is in version control and its maximum minor version is 189.0. You can only use this field with the minor version 189.0 or earlier.

If you specify a version number in the request header that is not supported, Zuora will use the minimum minor version of the REST API. In our REST API documentation, if a field or feature requires a minor version number, we note that in the field description.

You only need to specify the version number when you use the fields require a minor version. To specify the minor version, set the `zuora-version` parameter to the minor version number in the request header for the request call. For example, the `collect` field is in 196.0 minor version. If you want to use this field for the POST Subscription method, set the  `zuora-version` parameter to `196.0` in the request header. The `zuora-version` parameter is case sensitive.

For all the REST API fields, by default, if the minor version is not specified in the request header, Zuora will use the minimum minor version of the REST API to avoid breaking your integration. 

### Minor Version History

The supported minor versions are not serial. This section documents the changes made to each Zuora REST API minor version.

The following table lists the supported versions and the fields that have a Zuora REST API minor version.

| Fields         | Minor Version      | REST Methods    | Description |
|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|
| invoiceCollect | 189.0 and earlier  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice and collects a payment for a subscription. |
| collect        | 196.0 and later    | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Collects an automatic payment for a subscription. |
| invoice | 196.0 and 207.0| [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice for a subscription. |
| invoiceTargetDate | 196.0 and earlier  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") |Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. |
| invoiceTargetDate | 207.0 and earlier  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. |
| targetDate | 207.0 and later | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") |Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. |
| targetDate | 211.0 and later | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. |
| includeExisting DraftInvoiceItems | 196.0 and earlier| [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | Specifies whether to include draft invoice items in subscription previews. Specify it to be `true` (default) to include draft invoice items in the preview result. Specify it to be `false` to excludes draft invoice items in the preview result. |
| includeExisting DraftDocItems | 207.0 and later  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | Specifies whether to include draft invoice items in subscription previews. Specify it to be `true` (default) to include draft invoice items in the preview result. Specify it to be `false` to excludes draft invoice items in the preview result. |
| previewType | 196.0 and earlier| [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | The type of preview you will receive. The possible values are `InvoiceItem`(default), `ChargeMetrics`, and `InvoiceItemChargeMetrics`. |
| previewType | 207.0 and later  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | The type of preview you will receive. The possible values are `LegalDoc`(default), `ChargeMetrics`, and `LegalDocChargeMetrics`. |
| runBilling  | 211.0 and later  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice or credit memo for a subscription. **Note:** Credit memos are only available if you have the Invoice Settlement feature enabled. |
| invoiceDate | 214.0 and earlier  | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date that should appear on the invoice being generated, as `yyyy-mm-dd`. |
| invoiceTargetDate | 214.0 and earlier  | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date through which to calculate charges on this account if an invoice is generated, as `yyyy-mm-dd`. |
| documentDate | 215.0 and later | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date that should appear on the invoice and credit memo being generated, as `yyyy-mm-dd`. |
| targetDate | 215.0 and later | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date through which to calculate charges on this account if an invoice or a credit memo is generated, as `yyyy-mm-dd`. |
| memoItemAmount | 223.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | Amount of the memo item. |
| amount | 224.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | Amount of the memo item. |
| subscriptionNumbers | 222.4 and earlier | [Create order](https://www.zuora.com/developer/api-reference/#operation/POST_Order \"Create order\") | Container for the subscription numbers of the subscriptions in an order. |
| subscriptions | 223.0 and later | [Create order](https://www.zuora.com/developer/api-reference/#operation/POST_Order \"Create order\") | Container for the subscription numbers and statuses in an order. |
| creditTaxItems | 238.0 and earlier | [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\") | Container for the taxation items of the credit memo item. |
| taxItems | 238.0 and earlier | [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Container for the taxation items of the debit memo item. |
| taxationItems | 239.0 and later | [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Container for the taxation items of the memo item. |
| chargeId | 256.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | ID of the product rate plan charge that the memo is created from. |
| productRatePlanChargeId | 257.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | ID of the product rate plan charge that the memo is created from. |
| comment | 256.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\"); [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice \"Create credit memo from invoice\"); [Create debit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromInvoice \"Create debit memo from invoice\"); [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Comments about the product rate plan charge, invoice item, or memo item. |
| description | 257.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\"); [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice \"Create credit memo from invoice\"); [Create debit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromInvoice \"Create debit memo from invoice\"); [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Description of the the product rate plan charge, invoice item, or memo item. |
| taxationItems | 309.0 and later | [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder \"Preview an order\") | List of taxation items for an invoice item or a credit memo item. |
| batch | 309.0 and earlier | [Create a billing preview run](https://www.zuora.com/developer/api-reference/#operation/POST_BillingPreviewRun \"Create a billing preview run\") | The customer batches to include in the billing preview run. |      
| batches | 314.0 and later | [Create a billing preview run](https://www.zuora.com/developer/api-reference/#operation/POST_BillingPreviewRun \"Create a billing preview run\") | The customer batches to include in the billing preview run. |
| taxationItems | 315.0 and later | [Preview a subscription](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewSubscription \"Preview a subscription\"); [Update a subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update a subscription\")| List of taxation items for an invoice item or a credit memo item. |



#### Version 207.0 and Later

The response structure of the [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") and [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") methods are changed. The following invoice related response fields are moved to the invoice container:

  * amount
  * amountWithoutTax
  * taxAmount
  * invoiceItems
  * targetDate
  * chargeMetrics

# Zuora Billing Object Model

The following diagram is a high-level view of how key business objects are related to one another within Zuora Billing.

Click the diagram to open it in a new tab and zoom in.
For more information about the different sections of the diagram, see
<a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/A_Zuora_Billing_business_object_model\" target=\"_blank\">Zuora Billing business object model</a>.

<a href=\"https://assets.zuora.com/zuora-documentation/Zuora_Billing_object_model_Sep2020.png\" target=\"_blank\"><img src=\"https://assets.zuora.com/zuora-documentation/Zuora_Billing_object_model_Sep2020.png\" alt=\"Zuora Billing object model diagram\"></a>

This diagram is intended to provide a conceptual understanding; it does not illustrate a specific way to integrate with Zuora.

The diagram includes the Orders feature and the Invoice Settlement feature.
If your organization does not use either of these features, see
<a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/B_Zuora_Billing_business_object_model_prior_to_Orders_and_Invoice_Settlement\" target=\"_blank\">Zuora Billing business object model prior to Orders and Invoice Settlement</a>
for an alternative diagram.

## API Names

You can use the [Describe object](https://www.zuora.com/developer/api-reference/#operation/GET_Describe) operation to list the fields of each Zuora object that is available in your tenant. When you call the operation, you must specify the API name of the Zuora object.

The following table provides the API name of each Zuora object:

| Object                                        | API Name                                   |
|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|
| Account                                       | `Account`                                  |
| Accounting Code                               | `AccountingCode`                           |
| Accounting Period                             | `AccountingPeriod`                         |
| Amendment                                     | `Amendment`                                |
| Application Group                             | `ApplicationGroup`                         |
| Billing Run                                   | <p>`BillingRun` - API name used  in the [Describe object](https://www.zuora.com/developer/api-reference/#operation/GET_Describe) operation, Export ZOQL queries, and Data Query.</p> <p>`BillRun` - API name used in the [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions). See the CRUD oprations of [Bill Run](https://www.zuora.com/developer/api-reference/#tag/Bill-Run) for more information about the `BillRun` object. `BillingRun` and `BillRun` have different fields. |                     
| Contact                                       | `Contact`                                  |
| Contact Snapshot                              | `ContactSnapshot`                          |
| Credit Balance Adjustment                     | `CreditBalanceAdjustment`                  |
| Credit Memo                                   | `CreditMemo`                               |
| Credit Memo Application                       | `CreditMemoApplication`                    |
| Credit Memo Application Item                  | `CreditMemoApplicationItem`                |
| Credit Memo Item                              | `CreditMemoItem`                           |
| Credit Memo Part                              | `CreditMemoPart`                           |
| Credit Memo Part Item                         | `CreditMemoPartItem`                       |
| Credit Taxation Item                          | `CreditTaxationItem`                       |
| Custom Exchange Rate                          | `FXCustomRate`                             |
| Debit Memo                                    | `DebitMemo`                                |
| Debit Memo Item                               | `DebitMemoItem`                            |
| Debit Taxation Item                           | `DebitTaxationItem`                        |
| Discount Applied Metrics                      | `DiscountAppliedMetrics`                   |
| Entity                                        | `Tenant`                                   |
| Feature                                       | `Feature`                                  |
| Gateway Reconciliation Event                  | `PaymentGatewayReconciliationEventLog`     |
| Gateway Reconciliation Job                    | `PaymentReconciliationJob`                 |
| Gateway Reconciliation Log                    | `PaymentReconciliationLog`                 |
| Invoice                                       | `Invoice`                                  |
| Invoice Adjustment                            | `InvoiceAdjustment`                        |
| Invoice Item                                  | `InvoiceItem`                              |
| Invoice Item Adjustment                       | `InvoiceItemAdjustment`                    |
| Invoice Payment                               | `InvoicePayment`                           |
| Journal Entry                                 | `JournalEntry`                             |
| Journal Entry Item                            | `JournalEntryItem`                         |
| Journal Run                                   | `JournalRun`                               |
| Notification History - Callout                | `CalloutHistory`                           |
| Notification History - Email                  | `EmailHistory`                             |
| Order                                         | `Order`                                    |
| Order Action                                  | `OrderAction`                              |
| Order ELP                                     | `OrderElp`                                 |
| Order Line Items                              | `OrderLineItems`                           |    
| Order Item                                    | `OrderItem`                                |
| Order MRR                                     | `OrderMrr`                                 |
| Order Quantity                                | `OrderQuantity`                            |
| Order TCB                                     | `OrderTcb`                                 |
| Order TCV                                     | `OrderTcv`                                 |
| Payment                                       | `Payment`                                  |
| Payment Application                           | `PaymentApplication`                       |
| Payment Application Item                      | `PaymentApplicationItem`                   |
| Payment Method                                | `PaymentMethod`                            |
| Payment Method Snapshot                       | `PaymentMethodSnapshot`                    |
| Payment Method Transaction Log                | `PaymentMethodTransactionLog`              |
| Payment Method Update                         | `UpdaterDetail`                            |
| Payment Part                                  | `PaymentPart`                              |
| Payment Part Item                             | `PaymentPartItem`                          |
| Payment Run                                   | `PaymentRun`                               |
| Payment Transaction Log                       | `PaymentTransactionLog`                    |
| Processed Usage                               | `ProcessedUsage`                           |
| Product                                       | `Product`                                  |
| Product Feature                               | `ProductFeature`                           |
| Product Rate Plan                             | `ProductRatePlan`                          |
| Product Rate Plan Charge                      | `ProductRatePlanCharge`                    |
| Product Rate Plan Charge Tier                 | `ProductRatePlanChargeTier`                |
| Rate Plan                                     | `RatePlan`                                 |
| Rate Plan Charge                              | `RatePlanCharge`                           |
| Rate Plan Charge Tier                         | `RatePlanChargeTier`                       |
| Refund                                        | `Refund`                                   |
| Refund Application                            | `RefundApplication`                        |
| Refund Application Item                       | `RefundApplicationItem`                    |
| Refund Invoice Payment                        | `RefundInvoicePayment`                     |
| Refund Part                                   | `RefundPart`                               |
| Refund Part Item                              | `RefundPartItem`                           |
| Refund Transaction Log                        | `RefundTransactionLog`                     |
| Revenue Charge Summary                        | `RevenueChargeSummary`                     |
| Revenue Charge Summary Item                   | `RevenueChargeSummaryItem`                 |
| Revenue Event                                 | `RevenueEvent`                             |
| Revenue Event Credit Memo Item                | `RevenueEventCreditMemoItem`               |
| Revenue Event Debit Memo Item                 | `RevenueEventDebitMemoItem`                |
| Revenue Event Invoice Item                    | `RevenueEventInvoiceItem`                  |
| Revenue Event Invoice Item Adjustment         | `RevenueEventInvoiceItemAdjustment`        |
| Revenue Event Item                            | `RevenueEventItem`                         |
| Revenue Event Item Credit Memo Item           | `RevenueEventItemCreditMemoItem`           |
| Revenue Event Item Debit Memo Item            | `RevenueEventItemDebitMemoItem`            |
| Revenue Event Item Invoice Item               | `RevenueEventItemInvoiceItem`              |
| Revenue Event Item Invoice Item Adjustment    | `RevenueEventItemInvoiceItemAdjustment`    |
| Revenue Event Type                            | `RevenueEventType`                         |
| Revenue Schedule                              | `RevenueSchedule`                          |
| Revenue Schedule Credit Memo Item             | `RevenueScheduleCreditMemoItem`            |
| Revenue Schedule Debit Memo Item              | `RevenueScheduleDebitMemoItem`             |
| Revenue Schedule Invoice Item                 | `RevenueScheduleInvoiceItem`               |
| Revenue Schedule Invoice Item Adjustment      | `RevenueScheduleInvoiceItemAdjustment`     |
| Revenue Schedule Item                         | `RevenueScheduleItem`                      |
| Revenue Schedule Item Credit Memo Item        | `RevenueScheduleItemCreditMemoItem`        |
| Revenue Schedule Item Debit Memo Item         | `RevenueScheduleItemDebitMemoItem`         |
| Revenue Schedule Item Invoice Item            | `RevenueScheduleItemInvoiceItem`           |
| Revenue Schedule Item Invoice Item Adjustment | `RevenueScheduleItemInvoiceItemAdjustment` |
| Subscription                                  | `Subscription`                             |
| Subscription Product Feature                  | `SubscriptionProductFeature`               |
| Taxable Item Snapshot                         | `TaxableItemSnapshot`                      |
| Taxation Item                                 | `TaxationItem`                             |
| Updater Batch                                 | `UpdaterBatch`                             |
| Usage                                         | `Usage`                                    |


This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 2022-08-12
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.1 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using ZuoraClient.Api;
using ZuoraClient.Client;
using ZuoraClient.Model;
```
<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ZuoraClient.Api;
using ZuoraClient.Client;
using ZuoraClient.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://rest.zuora.com";
            var apiInstance = new AccountingCodesApi(config);
            var acId = "acId_example";  // string | ID of the accounting code you want to delete.
            var authorization = "authorization_example";  // string | The value is in the `Bearer {token}` format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional) 
            var zuoraTrackId = "zuoraTrackId_example";  // string | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (`:`), semicolon (`;`), double quote (`\"`), and quote (`'`).  (optional) 
            var zuoraEntityIds = "zuoraEntityIds_example";  // string | An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional) 

            try
            {
                // Delete an accounting code
                CommonResponseType result = apiInstance.DELETEAccountingCode(acId, authorization, zuoraTrackId, zuoraEntityIds);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AccountingCodesApi.DELETEAccountingCode: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://rest.zuora.com*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AccountingCodesApi* | [**DELETEAccountingCode**](docs/AccountingCodesApi.md#deleteaccountingcode) | **DELETE** /v1/accounting-codes/{ac-id} | Delete an accounting code
*AccountingCodesApi* | [**GETAccountingCode**](docs/AccountingCodesApi.md#getaccountingcode) | **GET** /v1/accounting-codes/{ac-id} | Retrieve an accounting code
*AccountingCodesApi* | [**GETAllAccountingCodes**](docs/AccountingCodesApi.md#getallaccountingcodes) | **GET** /v1/accounting-codes | List all accounting codes
*AccountingCodesApi* | [**POSTAccountingCode**](docs/AccountingCodesApi.md#postaccountingcode) | **POST** /v1/accounting-codes | Create an accounting code
*AccountingCodesApi* | [**PUTAccountingCode**](docs/AccountingCodesApi.md#putaccountingcode) | **PUT** /v1/accounting-codes/{ac-id} | Update an accounting code
*AccountingCodesApi* | [**PUTActivateAccountingCode**](docs/AccountingCodesApi.md#putactivateaccountingcode) | **PUT** /v1/accounting-codes/{ac-id}/activate | Activate an accounting code
*AccountingCodesApi* | [**PUTDeactivateAccountingCode**](docs/AccountingCodesApi.md#putdeactivateaccountingcode) | **PUT** /v1/accounting-codes/{ac-id}/deactivate | Deactivate an accounting code
*AccountingPeriodsApi* | [**DELETEAccountingPeriod**](docs/AccountingPeriodsApi.md#deleteaccountingperiod) | **DELETE** /v1/accounting-periods/{ap-id} | Delete an accounting period
*AccountingPeriodsApi* | [**GETAccountingPeriod**](docs/AccountingPeriodsApi.md#getaccountingperiod) | **GET** /v1/accounting-periods/{ap-id} | Retrieve an accounting period
*AccountingPeriodsApi* | [**GETAllAccountingPeriods**](docs/AccountingPeriodsApi.md#getallaccountingperiods) | **GET** /v1/accounting-periods | List all accounting periods
*AccountingPeriodsApi* | [**POSTAccountingPeriod**](docs/AccountingPeriodsApi.md#postaccountingperiod) | **POST** /v1/accounting-periods | Create an accounting period
*AccountingPeriodsApi* | [**PUTCloseAccountingPeriod**](docs/AccountingPeriodsApi.md#putcloseaccountingperiod) | **PUT** /v1/accounting-periods/{ap-id}/close | Close an accounting period
*AccountingPeriodsApi* | [**PUTPendingCloseAccountingPeriod**](docs/AccountingPeriodsApi.md#putpendingcloseaccountingperiod) | **PUT** /v1/accounting-periods/{ap-id}/pending-close | Set an accounting period to pending close
*AccountingPeriodsApi* | [**PUTReopenAccountingPeriod**](docs/AccountingPeriodsApi.md#putreopenaccountingperiod) | **PUT** /v1/accounting-periods/{ap-id}/reopen | Reopen an accounting period
*AccountingPeriodsApi* | [**PUTRunTrialBalance**](docs/AccountingPeriodsApi.md#putruntrialbalance) | **PUT** /v1/accounting-periods/{ap-id}/run-trial-balance | Run trial balance
*AccountingPeriodsApi* | [**PUTUpdateAccountingPeriod**](docs/AccountingPeriodsApi.md#putupdateaccountingperiod) | **PUT** /v1/accounting-periods/{ap-id} | Update an accounting period
*AccountsApi* | [**GETAccount**](docs/AccountsApi.md#getaccount) | **GET** /v1/accounts/{account-key} | Retrieve an account
*AccountsApi* | [**GETAccountSummary**](docs/AccountsApi.md#getaccountsummary) | **GET** /v1/accounts/{account-key}/summary | Retrieve an account summary
*AccountsApi* | [**GETAcountDefaultPaymentMethod**](docs/AccountsApi.md#getacountdefaultpaymentmethod) | **GET** /v1/accounts/{account-key}/payment-methods/default | Retrieve the default payment method of an account
*AccountsApi* | [**GETAcountPaymentMethods**](docs/AccountsApi.md#getacountpaymentmethods) | **GET** /v1/accounts/{account-key}/payment-methods | List payment methods of an account
*AccountsApi* | [**ObjectDELETEAccount**](docs/AccountsApi.md#objectdeleteaccount) | **DELETE** /v1/object/account/{id} | CRUD: Delete an account
*AccountsApi* | [**ObjectGETAccount**](docs/AccountsApi.md#objectgetaccount) | **GET** /v1/object/account/{id} | CRUD: Retrieve an account
*AccountsApi* | [**ObjectPOSTAccount**](docs/AccountsApi.md#objectpostaccount) | **POST** /v1/object/account | CRUD: Create an account
*AccountsApi* | [**ObjectPUTAccount**](docs/AccountsApi.md#objectputaccount) | **PUT** /v1/object/account/{id} | CRUD: Update an account
*AccountsApi* | [**POSTAccount**](docs/AccountsApi.md#postaccount) | **POST** /v1/accounts | Create an account
*AccountsApi* | [**PUTAccount**](docs/AccountsApi.md#putaccount) | **PUT** /v1/accounts/{account-key} | Update an account
*ActionsApi* | [**ActionPOSTamend**](docs/ActionsApi.md#actionpostamend) | **POST** /v1/action/amend | Amend
*ActionsApi* | [**ActionPOSTcreate**](docs/ActionsApi.md#actionpostcreate) | **POST** /v1/action/create | Create
*ActionsApi* | [**ActionPOSTdelete**](docs/ActionsApi.md#actionpostdelete) | **POST** /v1/action/delete | Delete
*ActionsApi* | [**ActionPOSTexecute**](docs/ActionsApi.md#actionpostexecute) | **POST** /v1/action/execute | Execute
*ActionsApi* | [**ActionPOSTgenerate**](docs/ActionsApi.md#actionpostgenerate) | **POST** /v1/action/generate | Generate
*ActionsApi* | [**ActionPOSTquery**](docs/ActionsApi.md#actionpostquery) | **POST** /v1/action/query | Query
*ActionsApi* | [**ActionPOSTqueryMore**](docs/ActionsApi.md#actionpostquerymore) | **POST** /v1/action/queryMore | QueryMore
*ActionsApi* | [**ActionPOSTsubscribe**](docs/ActionsApi.md#actionpostsubscribe) | **POST** /v1/action/subscribe | Subscribe
*ActionsApi* | [**ActionPOSTupdate**](docs/ActionsApi.md#actionpostupdate) | **POST** /v1/action/update | Update
*AmendmentsApi* | [**GETAmendmentsByKey**](docs/AmendmentsApi.md#getamendmentsbykey) | **GET** /v1/amendments/{amendment-key} | Retrieve an amendment
*AmendmentsApi* | [**GETAmendmentsBySubscriptionID**](docs/AmendmentsApi.md#getamendmentsbysubscriptionid) | **GET** /v1/amendments/subscriptions/{subscription-id} | Retrieve the last amendment of a subscription
*AmendmentsApi* | [**ObjectDELETEAmendment**](docs/AmendmentsApi.md#objectdeleteamendment) | **DELETE** /v1/object/amendment/{id} | CRUD: Delete an amendment
*AmendmentsApi* | [**ObjectGETAmendment**](docs/AmendmentsApi.md#objectgetamendment) | **GET** /v1/object/amendment/{id} | CRUD: Retrieve an amendment
*AmendmentsApi* | [**ObjectPUTAmendment**](docs/AmendmentsApi.md#objectputamendment) | **PUT** /v1/object/amendment/{id} | CRUD: Update an amendment
*AttachmentsApi* | [**DELETEAttachments**](docs/AttachmentsApi.md#deleteattachments) | **DELETE** /v1/attachments/{attachment-id} | Delete an attachment
*AttachmentsApi* | [**GETAttachments**](docs/AttachmentsApi.md#getattachments) | **GET** /v1/attachments/{attachment-id} | Retrieve an attachment
*AttachmentsApi* | [**GETAttachmentsList**](docs/AttachmentsApi.md#getattachmentslist) | **GET** /v1/attachments/{object-type}/{object-key} | List attachments by object type and key
*AttachmentsApi* | [**POSTAttachments**](docs/AttachmentsApi.md#postattachments) | **POST** /v1/attachments | Create an attachment
*AttachmentsApi* | [**PUTAttachments**](docs/AttachmentsApi.md#putattachments) | **PUT** /v1/attachments/{attachment-id} | Update an attachment
*BillRunApi* | [**ObjectDELETEBillRun**](docs/BillRunApi.md#objectdeletebillrun) | **DELETE** /v1/object/bill-run/{id} | CRUD: Delete a bill run
*BillRunApi* | [**ObjectGETBillRun**](docs/BillRunApi.md#objectgetbillrun) | **GET** /v1/object/bill-run/{id} | CRUD: Retrieve a bill run
*BillRunApi* | [**ObjectPOSTBillRun**](docs/BillRunApi.md#objectpostbillrun) | **POST** /v1/object/bill-run | CRUD: Create a bill run
*BillRunApi* | [**ObjectPUTBillRun**](docs/BillRunApi.md#objectputbillrun) | **PUT** /v1/object/bill-run/{id} | CRUD: Post or cancel a bill run
*BillRunApi* | [**POSTEmailBillingDocumentsfromBillRun**](docs/BillRunApi.md#postemailbillingdocumentsfrombillrun) | **POST** /v1/bill-runs/{billRunKey}/emails | Email billing documents generated from a bill run
*BillingDocumentsApi* | [**GETBillingDocumentFilesDeletionJob**](docs/BillingDocumentsApi.md#getbillingdocumentfilesdeletionjob) | **GET** /v1/accounts/billing-documents/files/deletion-jobs/{jobId} | Retrieve a job of hard deleting billing document files
*BillingDocumentsApi* | [**GETBillingDocuments**](docs/BillingDocumentsApi.md#getbillingdocuments) | **GET** /v1/billing-documents | List billing documents for an account
*BillingDocumentsApi* | [**POSTBillingDocumentFilesDeletionJob**](docs/BillingDocumentsApi.md#postbillingdocumentfilesdeletionjob) | **POST** /v1/accounts/billing-documents/files/deletion-jobs | Create a job to hard delete billing document files
*BillingDocumentsApi* | [**POSTGenerateBillingDocuments**](docs/BillingDocumentsApi.md#postgeneratebillingdocuments) | **POST** /v1/accounts/{key}/billing-documents/generate | Generate billing documents by account ID
*BillingPreviewRunApi* | [**GETBillingPreviewRun**](docs/BillingPreviewRunApi.md#getbillingpreviewrun) | **GET** /v1/billing-preview-runs/{billingPreviewRunId} | Retrieve a billing preview run
*BillingPreviewRunApi* | [**POSTBillingPreviewRun**](docs/BillingPreviewRunApi.md#postbillingpreviewrun) | **POST** /v1/billing-preview-runs | Create a billing preview run
*CatalogApi* | [**GETCatalog**](docs/CatalogApi.md#getcatalog) | **GET** /v1/catalog/products | List all products
*CatalogApi* | [**GETProduct**](docs/CatalogApi.md#getproduct) | **GET** /v1/catalog/product/{product-key} | Retrieve a product
*CatalogApi* | [**POSTCatalog**](docs/CatalogApi.md#postcatalog) | **POST** /v1/catalog/products/{product-id}/share | Multi-entity: Share a product with an entity
*CatalogGroupsApi* | [**DELETECatalogGroup**](docs/CatalogGroupsApi.md#deletecataloggroup) | **DELETE** /v1/catalog-groups/{catalog-group-key} | Delete a catalog group
*CatalogGroupsApi* | [**GETListAllCatalogGroups**](docs/CatalogGroupsApi.md#getlistallcataloggroups) | **GET** /v1/catalog-groups | List all catalog groups
*CatalogGroupsApi* | [**GETRetrieveCatalogGroup**](docs/CatalogGroupsApi.md#getretrievecataloggroup) | **GET** /v1/catalog-groups/{catalog-group-key} | Retrieve a catalog group
*CatalogGroupsApi* | [**POSTCreateCatalogGroup**](docs/CatalogGroupsApi.md#postcreatecataloggroup) | **POST** /v1/catalog-groups | Create a catalog group
*CatalogGroupsApi* | [**PUTUpdateCatalogGroup**](docs/CatalogGroupsApi.md#putupdatecataloggroup) | **PUT** /v1/catalog-groups/{catalog-group-key} | Update a catalog group
*ChargeMetricsApi* | [**GETChargeMetrics**](docs/ChargeMetricsApi.md#getchargemetrics) | **GET** /charge-metrics/data/charge-metrics | List charge metrics by time range
*ChargeMetricsApi* | [**GETChargeMetricsDiscountAllocationDetails**](docs/ChargeMetricsApi.md#getchargemetricsdiscountallocationdetails) | **GET** /charge-metrics/data/charge-metrics-discount-allocation-detail | List discount allocation details by time range
*ChargeRevenueSummariesApi* | [**GETCRSByCRSNumber**](docs/ChargeRevenueSummariesApi.md#getcrsbycrsnumber) | **GET** /v1/charge-revenue-summaries/{crs-number} | List all details of a charge revenue summary
*ChargeRevenueSummariesApi* | [**GETCRSByChargeID**](docs/ChargeRevenueSummariesApi.md#getcrsbychargeid) | **GET** /v1/charge-revenue-summaries/subscription-charges/{charge-key} | Retrieve a charge revenue summary by charge ID
*CommunicationProfilesApi* | [**ObjectGETCommunicationProfile**](docs/CommunicationProfilesApi.md#objectgetcommunicationprofile) | **GET** /v1/object/communication-profile/{id} | CRUD: Retrieve a communication profile
*ConnectionsApi* | [**POSTConnections**](docs/ConnectionsApi.md#postconnections) | **POST** /v1/connections | Establish a connection to Zuora REST API
*ContactsApi* | [**ObjectDELETEContact**](docs/ContactsApi.md#objectdeletecontact) | **DELETE** /v1/object/contact/{id} | CRUD: Delete a contact
*ContactsApi* | [**ObjectGETContact**](docs/ContactsApi.md#objectgetcontact) | **GET** /v1/object/contact/{id} | CRUD: Retrieve a contact
*ContactsApi* | [**ObjectPOSTContact**](docs/ContactsApi.md#objectpostcontact) | **POST** /v1/object/contact | CRUD: Create a contact
*ContactsApi* | [**ObjectPUTContact**](docs/ContactsApi.md#objectputcontact) | **PUT** /v1/object/contact/{id} | CRUD: Update a contact
*ContactsApi* | [**PUTScrubContact**](docs/ContactsApi.md#putscrubcontact) | **PUT** /v1/contacts/{contactId}/scrub | Scrub a contact
*CreditBalanceAdjustmentsApi* | [**ObjectGETCreditBalanceAdjustment**](docs/CreditBalanceAdjustmentsApi.md#objectgetcreditbalanceadjustment) | **GET** /v1/object/credit-balance-adjustment/{id} | CRUD: Retrieve a credit balance adjustment
*CreditBalanceAdjustmentsApi* | [**ObjectPOSTCreditBalanceAdjustment**](docs/CreditBalanceAdjustmentsApi.md#objectpostcreditbalanceadjustment) | **POST** /v1/object/credit-balance-adjustment | CRUD: Create a credit balance adjustment
*CreditBalanceAdjustmentsApi* | [**ObjectPUTCreditBalanceAdjustment**](docs/CreditBalanceAdjustmentsApi.md#objectputcreditbalanceadjustment) | **PUT** /v1/object/credit-balance-adjustment/{id} | CRUD: Update a credit balance adjustment
*CreditMemosApi* | [**DELETECreditMemo**](docs/CreditMemosApi.md#deletecreditmemo) | **DELETE** /v1/creditmemos/{creditMemoKey} | Delete a credit memo
*CreditMemosApi* | [**GETCreditMemo**](docs/CreditMemosApi.md#getcreditmemo) | **GET** /v1/creditmemos/{creditMemoKey} | Retrieve a credit memo
*CreditMemosApi* | [**GETCreditMemoItem**](docs/CreditMemosApi.md#getcreditmemoitem) | **GET** /v1/creditmemos/{creditMemoKey}/items/{cmitemid} | Retrieve a credit memo item
*CreditMemosApi* | [**GETCreditMemoItemPart**](docs/CreditMemosApi.md#getcreditmemoitempart) | **GET** /v1/creditmemos/{creditMemoKey}/parts/{partid}/itemparts/{itempartid} | Retrieve a credit memo part item
*CreditMemosApi* | [**GETCreditMemoItemParts**](docs/CreditMemosApi.md#getcreditmemoitemparts) | **GET** /v1/creditmemos/{creditMemoKey}/parts/{partid}/itemparts | List all credit memo part items
*CreditMemosApi* | [**GETCreditMemoItems**](docs/CreditMemosApi.md#getcreditmemoitems) | **GET** /v1/creditmemos/{creditMemoKey}/items | List credit memo items
*CreditMemosApi* | [**GETCreditMemoPart**](docs/CreditMemosApi.md#getcreditmemopart) | **GET** /v1/creditmemos/{creditMemoKey}/parts/{partid} | Retrieve a credit memo part
*CreditMemosApi* | [**GETCreditMemoParts**](docs/CreditMemosApi.md#getcreditmemoparts) | **GET** /v1/creditmemos/{creditMemoKey}/parts | List all parts of a credit memo
*CreditMemosApi* | [**GETCreditMemos**](docs/CreditMemosApi.md#getcreditmemos) | **GET** /v1/creditmemos | List credit memos
*CreditMemosApi* | [**GETTaxationItemsOfCreditMemoItem**](docs/CreditMemosApi.md#gettaxationitemsofcreditmemoitem) | **GET** /v1/creditmemos/{creditMemoId}/items/{cmitemid}/taxation-items | List all taxation items of a credit memo item
*CreditMemosApi* | [**POSTCMTaxationItems**](docs/CreditMemosApi.md#postcmtaxationitems) | **POST** /v1/creditmemos/{creditMemoKey}/taxationitems | Create taxation items for a credit memo
*CreditMemosApi* | [**POSTCreateCreditMemos**](docs/CreditMemosApi.md#postcreatecreditmemos) | **POST** /v1/creditmemos/bulk | Create credit memos
*CreditMemosApi* | [**POSTCreditMemoFromInvoice**](docs/CreditMemosApi.md#postcreditmemofrominvoice) | **POST** /v1/invoices/{invoiceKey}/creditmemos | Create a credit memo from an invoice
*CreditMemosApi* | [**POSTCreditMemoFromPrpc**](docs/CreditMemosApi.md#postcreditmemofromprpc) | **POST** /v1/creditmemos | Create a credit memo from a charge
*CreditMemosApi* | [**POSTCreditMemoPDF**](docs/CreditMemosApi.md#postcreditmemopdf) | **POST** /v1/creditmemos/{creditMemoKey}/pdfs | Generate a credit memo PDF file
*CreditMemosApi* | [**POSTEmailCreditMemo**](docs/CreditMemosApi.md#postemailcreditmemo) | **POST** /v1/creditmemos/{creditMemoKey}/emails | Email a credit memo
*CreditMemosApi* | [**POSTRefundCreditMemo**](docs/CreditMemosApi.md#postrefundcreditmemo) | **POST** /v1/creditmemos/{creditmemoId}/refunds | Refund a credit memo
*CreditMemosApi* | [**POSTUploadFileForCreditMemo**](docs/CreditMemosApi.md#postuploadfileforcreditmemo) | **POST** /v1/creditmemos/{creditMemoKey}/files | Upload a file for a credit memo
*CreditMemosApi* | [**PUTApplyCreditMemo**](docs/CreditMemosApi.md#putapplycreditmemo) | **PUT** /v1/creditmemos/{creditMemoKey}/apply | Apply a credit memo
*CreditMemosApi* | [**PUTCancelCreditMemo**](docs/CreditMemosApi.md#putcancelcreditmemo) | **PUT** /v1/creditmemos/{creditMemoKey}/cancel | Cancel a credit memo
*CreditMemosApi* | [**PUTPostCreditMemo**](docs/CreditMemosApi.md#putpostcreditmemo) | **PUT** /v1/creditmemos/{creditMemoKey}/post | Post a credit memo
*CreditMemosApi* | [**PUTReverseCreditMemo**](docs/CreditMemosApi.md#putreversecreditmemo) | **PUT** /v1/creditmemos/{creditMemoKey}/reverse | Reverse a credit memo
*CreditMemosApi* | [**PUTUnapplyCreditMemo**](docs/CreditMemosApi.md#putunapplycreditmemo) | **PUT** /v1/creditmemos/{creditMemoKey}/unapply | Unapply a credit memo
*CreditMemosApi* | [**PUTUnpostCreditMemo**](docs/CreditMemosApi.md#putunpostcreditmemo) | **PUT** /v1/creditmemos/{creditMemoKey}/unpost | Unpost a credit memo
*CreditMemosApi* | [**PUTUpdateCreditMemo**](docs/CreditMemosApi.md#putupdatecreditmemo) | **PUT** /v1/creditmemos/{creditMemoKey} | Update a credit memo
*CreditMemosApi* | [**PUTUpdateCreditMemos**](docs/CreditMemosApi.md#putupdatecreditmemos) | **PUT** /v1/creditmemos/bulk | Update credit memos
*CreditMemosApi* | [**PUTWriteOffCreditMemo**](docs/CreditMemosApi.md#putwriteoffcreditmemo) | **PUT** /v1/creditmemos/{creditMemoId}/write-off | Write off a credit memo
*CustomEventTriggersApi* | [**DELETEEventTrigger**](docs/CustomEventTriggersApi.md#deleteeventtrigger) | **DELETE** /events/event-triggers/{id} | Delete an event trigger
*CustomEventTriggersApi* | [**GETEventTrigger**](docs/CustomEventTriggersApi.md#geteventtrigger) | **GET** /events/event-triggers/{id} | Retrieve an event trigger
*CustomEventTriggersApi* | [**GETEventTriggers**](docs/CustomEventTriggersApi.md#geteventtriggers) | **GET** /events/event-triggers | List event triggers
*CustomEventTriggersApi* | [**POSTEventTrigger**](docs/CustomEventTriggersApi.md#posteventtrigger) | **POST** /events/event-triggers | Create an event trigger
*CustomEventTriggersApi* | [**PUTEventTrigger**](docs/CustomEventTriggersApi.md#puteventtrigger) | **PUT** /events/event-triggers/{id} | Update an event trigger
*CustomExchangeRatesApi* | [**GETCustomExchangeRates**](docs/CustomExchangeRatesApi.md#getcustomexchangerates) | **GET** /v1/custom-exchange-rates/{currency} | List custom exchange rates by currency
*CustomObjectDefinitionsApi* | [**DeleteCustomObjectDefinitionByType**](docs/CustomObjectDefinitionsApi.md#deletecustomobjectdefinitionbytype) | **DELETE** /objects/definitions/default/{object} | Delete a custom object definition
*CustomObjectDefinitionsApi* | [**GETAllCustomObjectDefinitionsInNamespace**](docs/CustomObjectDefinitionsApi.md#getallcustomobjectdefinitionsinnamespace) | **GET** /objects/definitions/default | List custom object definitions
*CustomObjectDefinitionsApi* | [**GETCustomObjectDefinitionByType**](docs/CustomObjectDefinitionsApi.md#getcustomobjectdefinitionbytype) | **GET** /objects/definitions/default/{object} | Retrieve a custom object definition
*CustomObjectDefinitionsApi* | [**POSTCustomObjectDefinitions**](docs/CustomObjectDefinitionsApi.md#postcustomobjectdefinitions) | **POST** /objects/definitions/default | Create custom object definitions
*CustomObjectDefinitionsApi* | [**POSTUpdateCustomObjectDefinition**](docs/CustomObjectDefinitionsApi.md#postupdatecustomobjectdefinition) | **POST** /objects/migrations | Update a custom object definition
*CustomObjectJobsApi* | [**GETAllCustomObjectBulkJobs**](docs/CustomObjectJobsApi.md#getallcustomobjectbulkjobs) | **GET** /objects/jobs | List all custom object bulk jobs
*CustomObjectJobsApi* | [**GETCustomObjectBulkJob**](docs/CustomObjectJobsApi.md#getcustomobjectbulkjob) | **GET** /objects/jobs/{id} | Retrieve a custom object bulk job
*CustomObjectJobsApi* | [**GETCustomObjectBulkJobErrors**](docs/CustomObjectJobsApi.md#getcustomobjectbulkjoberrors) | **GET** /objects/jobs/{id}/errors | List all errors for a custom object bulk job
*CustomObjectJobsApi* | [**POSTCustomObjectBulkJob**](docs/CustomObjectJobsApi.md#postcustomobjectbulkjob) | **POST** /objects/jobs | Submit a custom object bulk job
*CustomObjectJobsApi* | [**POSTUploadFileForCustomObjectBulkJob**](docs/CustomObjectJobsApi.md#postuploadfileforcustomobjectbulkjob) | **POST** /objects/jobs/{id}/files | Upload a file for a custom object bulk job
*CustomObjectRecordsApi* | [**DeleteCustomObjectRecordByID**](docs/CustomObjectRecordsApi.md#deletecustomobjectrecordbyid) | **DELETE** /objects/records/default/{object}/{id} | Delete a custom object record
*CustomObjectRecordsApi* | [**GETAllRecordsForCustomObjectType**](docs/CustomObjectRecordsApi.md#getallrecordsforcustomobjecttype) | **GET** /objects/records/default/{object} | List records for a custom object
*CustomObjectRecordsApi* | [**GETCustomObjectRecordByID**](docs/CustomObjectRecordsApi.md#getcustomobjectrecordbyid) | **GET** /objects/records/default/{object}/{id} | Retrieve a custom object record
*CustomObjectRecordsApi* | [**POSTCustomObjectRecords**](docs/CustomObjectRecordsApi.md#postcustomobjectrecords) | **POST** /objects/records/default/{object} | Create custom object records
*CustomObjectRecordsApi* | [**POSTCustomObjectRecordsBatchUpdateOrDelete**](docs/CustomObjectRecordsApi.md#postcustomobjectrecordsbatchupdateordelete) | **POST** /objects/batch/default/{object} | Update or delete custom object records
*CustomObjectRecordsApi* | [**PUTCustomObjectRecord**](docs/CustomObjectRecordsApi.md#putcustomobjectrecord) | **PUT** /objects/records/default/{object}/{id} | Update a custom object record
*CustomObjectRecordsApi* | [**PatchPartialUpdateCustomObjectRecord**](docs/CustomObjectRecordsApi.md#patchpartialupdatecustomobjectrecord) | **PATCH** /objects/records/default/{object}/{id} | Partially update a custom object record
*CustomPaymentMethodTypesApi* | [**GETOpenPaymentMethodTypePublish**](docs/CustomPaymentMethodTypesApi.md#getopenpaymentmethodtypepublish) | **GET** /open-payment-method-types/{paymentMethodTypeName}/published | Retrieve a published custom payment method type
*CustomPaymentMethodTypesApi* | [**GETOpenPaymentMethodTypeRevision**](docs/CustomPaymentMethodTypesApi.md#getopenpaymentmethodtyperevision) | **GET** /open-payment-method-types/{paymentMethodTypeName}/draft/{revisionNumber} | Retrieve a specific draft revision of a custom payment method type
*CustomPaymentMethodTypesApi* | [**POSTCreateDraftOpenPaymentMethodType**](docs/CustomPaymentMethodTypesApi.md#postcreatedraftopenpaymentmethodtype) | **POST** /open-payment-method-types | Create a draft custom payment method type
*CustomPaymentMethodTypesApi* | [**PUTPublishOpenPaymentMethodType**](docs/CustomPaymentMethodTypesApi.md#putpublishopenpaymentmethodtype) | **PUT** /open-payment-method-types/publish/{paymentMethodTypeName} | Publish a custom payment method type
*CustomPaymentMethodTypesApi* | [**PUTUpdateOpenPaymentMethodType**](docs/CustomPaymentMethodTypesApi.md#putupdateopenpaymentmethodtype) | **PUT** /open-payment-method-types/{paymentMethodTypeName} | Update a custom payment method type
*CustomScheduledEventsApi* | [**DELETEScheduledEventByID**](docs/CustomScheduledEventsApi.md#deletescheduledeventbyid) | **DELETE** /events/scheduled-events/{id} | Delete a scheduled event by ID
*CustomScheduledEventsApi* | [**GETScheduledEventByID**](docs/CustomScheduledEventsApi.md#getscheduledeventbyid) | **GET** /events/scheduled-events/{id} | Retrieve a scheduled event by ID
*CustomScheduledEventsApi* | [**GETScheduledEvents**](docs/CustomScheduledEventsApi.md#getscheduledevents) | **GET** /events/scheduled-events | List all scheduled events
*CustomScheduledEventsApi* | [**POSTScheduledEvent**](docs/CustomScheduledEventsApi.md#postscheduledevent) | **POST** /events/scheduled-events | Create a scheduled event
*DataQueriesApi* | [**DELETEDataQueryJob**](docs/DataQueriesApi.md#deletedataqueryjob) | **DELETE** /query/jobs/{job-id} | Cancel a data query job
*DataQueriesApi* | [**GETDataQueryJob**](docs/DataQueriesApi.md#getdataqueryjob) | **GET** /query/jobs/{job-id} | Retrieve a data query job
*DataQueriesApi* | [**GETDataQueryJobs**](docs/DataQueriesApi.md#getdataqueryjobs) | **GET** /query/jobs | List data query jobs
*DataQueriesApi* | [**POSTDataQueryJob**](docs/DataQueriesApi.md#postdataqueryjob) | **POST** /query/jobs | Submit a data query
*DebitMemosApi* | [**DELETEDebitMemo**](docs/DebitMemosApi.md#deletedebitmemo) | **DELETE** /v1/debitmemos/{debitMemoKey} | Delete a debit memo
*DebitMemosApi* | [**GETDebitMemo**](docs/DebitMemosApi.md#getdebitmemo) | **GET** /v1/debitmemos/{debitMemoKey} | Retrieve a debit memo
*DebitMemosApi* | [**GETDebitMemoApplicationParts**](docs/DebitMemosApi.md#getdebitmemoapplicationparts) | **GET** /v1/debitmemos/{debitMemoId}/application-parts | List all application parts of a debit memo
*DebitMemosApi* | [**GETDebitMemoItem**](docs/DebitMemosApi.md#getdebitmemoitem) | **GET** /v1/debitmemos/{debitMemoKey}/items/{dmitemid} | Retrieve a debit memo item
*DebitMemosApi* | [**GETDebitMemoItems**](docs/DebitMemosApi.md#getdebitmemoitems) | **GET** /v1/debitmemos/{debitMemoKey}/items | List debit memo items
*DebitMemosApi* | [**GETDebitMemos**](docs/DebitMemosApi.md#getdebitmemos) | **GET** /v1/debitmemos | List debit memos
*DebitMemosApi* | [**GETTaxationItemsOfDebitMemoItem**](docs/DebitMemosApi.md#gettaxationitemsofdebitmemoitem) | **GET** /v1/debitmemos/{debitMemoId}/items/{dmitemid}/taxation-items | List all taxation items of a debit memo item
*DebitMemosApi* | [**POSTCreateDebitMemos**](docs/DebitMemosApi.md#postcreatedebitmemos) | **POST** /v1/debitmemos/bulk | Create debit memos
*DebitMemosApi* | [**POSTDMTaxationItems**](docs/DebitMemosApi.md#postdmtaxationitems) | **POST** /v1/debitmemos/{debitMemoKey}/taxationitems | Create taxation items for a debit memo
*DebitMemosApi* | [**POSTDebitMemoCollect**](docs/DebitMemosApi.md#postdebitmemocollect) | **POST** /v1/debitmemos/{debitMemoKey}/collect | Collect a posted debit memo
*DebitMemosApi* | [**POSTDebitMemoFromInvoice**](docs/DebitMemosApi.md#postdebitmemofrominvoice) | **POST** /v1/invoices/{invoiceKey}/debitmemos | Create a debit memo from an invoice
*DebitMemosApi* | [**POSTDebitMemoFromPrpc**](docs/DebitMemosApi.md#postdebitmemofromprpc) | **POST** /v1/debitmemos | Create a debit memo from a charge
*DebitMemosApi* | [**POSTDebitMemoPDF**](docs/DebitMemosApi.md#postdebitmemopdf) | **POST** /v1/debitmemos/{debitMemoKey}/pdfs | Generate a debit memo PDF file
*DebitMemosApi* | [**POSTEmailDebitMemo**](docs/DebitMemosApi.md#postemaildebitmemo) | **POST** /v1/debitmemos/{debitMemoKey}/emails | Email a debit memo
*DebitMemosApi* | [**POSTUploadFileForDebitMemo**](docs/DebitMemosApi.md#postuploadfilefordebitmemo) | **POST** /v1/debitmemos/{debitMemoKey}/files | Upload a file for a debit memo
*DebitMemosApi* | [**PUTCancelDebitMemo**](docs/DebitMemosApi.md#putcanceldebitmemo) | **PUT** /v1/debitmemos/{debitMemoKey}/cancel | Cancel a debit memo
*DebitMemosApi* | [**PUTDebitMemo**](docs/DebitMemosApi.md#putdebitmemo) | **PUT** /v1/debitmemos/{debitMemoKey} | Update a debit memo
*DebitMemosApi* | [**PUTPostDebitMemo**](docs/DebitMemosApi.md#putpostdebitmemo) | **PUT** /v1/debitmemos/{debitMemoKey}/post | Post a debit memo
*DebitMemosApi* | [**PUTUnpostDebitMemo**](docs/DebitMemosApi.md#putunpostdebitmemo) | **PUT** /v1/debitmemos/{debitMemoKey}/unpost | Unpost a debit memo
*DebitMemosApi* | [**PUTUpdateDebitMemos**](docs/DebitMemosApi.md#putupdatedebitmemos) | **PUT** /v1/debitmemos/bulk | Update debit memos
*DebitMemosApi* | [**PUTUpdateDebitMemosDueDates**](docs/DebitMemosApi.md#putupdatedebitmemosduedates) | **PUT** /v1/debitmemos | Update due dates for debit memos
*DescribeApi* | [**GETDescribe**](docs/DescribeApi.md#getdescribe) | **GET** /v1/describe/{object} | Describe an object
*DocumentPropertiesApi* | [**DELETEDocumentProperties**](docs/DocumentPropertiesApi.md#deletedocumentproperties) | **DELETE** /v1/document-properties/{documentPropertiesId} | Delete document properties
*DocumentPropertiesApi* | [**GETDocumentProperies**](docs/DocumentPropertiesApi.md#getdocumentproperies) | **GET** /v1/document-properties/{documentType}/{documentId} | List all properties of a billing document
*DocumentPropertiesApi* | [**POSTDocumentProperties**](docs/DocumentPropertiesApi.md#postdocumentproperties) | **POST** /v1/document-properties | Create document properties
*DocumentPropertiesApi* | [**PUTDocumentProperties**](docs/DocumentPropertiesApi.md#putdocumentproperties) | **PUT** /v1/document-properties/{documentPropertiesId} | Update document properties
*EntitiesApi* | [**DELETEEntities**](docs/EntitiesApi.md#deleteentities) | **DELETE** /v1/entities/{id} | Multi-entity: Delete an entity
*EntitiesApi* | [**GETEntities**](docs/EntitiesApi.md#getentities) | **GET** /v1/entities | Multi-entity: List entities
*EntitiesApi* | [**GETEntityById**](docs/EntitiesApi.md#getentitybyid) | **GET** /v1/entities/{id} | Multi-entity: Retrieve an entity
*EntitiesApi* | [**POSTEntities**](docs/EntitiesApi.md#postentities) | **POST** /v1/entities | Multi-entity: Create an entity
*EntitiesApi* | [**PUTEntities**](docs/EntitiesApi.md#putentities) | **PUT** /v1/entities/{id} | Multi-entity: Update an entity
*EntitiesApi* | [**PUTProvisionEntity**](docs/EntitiesApi.md#putprovisionentity) | **PUT** /v1/entities/{id}/provision | Multi-entity: Provision an entity
*EntityConnectionsApi* | [**GETEntityConnections**](docs/EntityConnectionsApi.md#getentityconnections) | **GET** /v1/entity-connections | Multi-entity: List connections
*EntityConnectionsApi* | [**POSTEntityConnections**](docs/EntityConnectionsApi.md#postentityconnections) | **POST** /v1/entity-connections | Multi-entity: Initiate a connection request
*EntityConnectionsApi* | [**PUTEntityConnectionsAccept**](docs/EntityConnectionsApi.md#putentityconnectionsaccept) | **PUT** /v1/entity-connections/{connection-id}/accept | Multi-entity: Accept a connection request
*EntityConnectionsApi* | [**PUTEntityConnectionsDeny**](docs/EntityConnectionsApi.md#putentityconnectionsdeny) | **PUT** /v1/entity-connections/{connection-id}/deny | Multi-entity: Deny a connection request
*EntityConnectionsApi* | [**PUTEntityConnectionsDisconnect**](docs/EntityConnectionsApi.md#putentityconnectionsdisconnect) | **PUT** /v1/entity-connections/{connection-id}/disconnect | Multi-entity: Disconnect a connection
*ExportsApi* | [**ObjectGETExport**](docs/ExportsApi.md#objectgetexport) | **GET** /v1/object/export/{id} | CRUD: Retrieve an export
*ExportsApi* | [**ObjectPOSTExport**](docs/ExportsApi.md#objectpostexport) | **POST** /v1/object/export | CRUD: Create an export
*FeaturesApi* | [**ObjectDELETEFeature**](docs/FeaturesApi.md#objectdeletefeature) | **DELETE** /v1/object/feature/{id} | CRUD: Delete a feature
*FeaturesApi* | [**ObjectGETFeature**](docs/FeaturesApi.md#objectgetfeature) | **GET** /v1/object/feature/{id} | CRUD: Retrieve a feature
*FeaturesApi* | [**ObjectPOSTFeature**](docs/FeaturesApi.md#objectpostfeature) | **POST** /v1/object/feature | CRUD: Create a feature
*FeaturesApi* | [**ObjectPUTFeature**](docs/FeaturesApi.md#objectputfeature) | **PUT** /v1/object/feature/{id} | CRUD: Update a feature
*FilesApi* | [**GETFiles**](docs/FilesApi.md#getfiles) | **GET** /v1/files/{file-id} | Retrieve a file
*HMACSignaturesApi* | [**POSTHMACSignatures**](docs/HMACSignaturesApi.md#posthmacsignatures) | **POST** /v1/hmac-signatures | Generate an HMAC signature
*HostedPagesApi* | [**GetHostedPages**](docs/HostedPagesApi.md#gethostedpages) | **GET** /v1/hostedpages | List hosted pages
*ImportsApi* | [**ObjectGETImport**](docs/ImportsApi.md#objectgetimport) | **GET** /v1/object/import/{id} | CRUD: Retrieve an import
*ImportsApi* | [**ObjectPOSTImport**](docs/ImportsApi.md#objectpostimport) | **POST** /v1/object/import | CRUD: Create an import
*InvoiceAdjustmentsApi* | [**ObjectDELETEInvoiceAdjustment**](docs/InvoiceAdjustmentsApi.md#objectdeleteinvoiceadjustment) | **DELETE** /v1/object/invoice-adjustment/{id} | CRUD: Delete an invoice adjustment
*InvoiceAdjustmentsApi* | [**ObjectGETInvoiceAdjustment**](docs/InvoiceAdjustmentsApi.md#objectgetinvoiceadjustment) | **GET** /v1/object/invoice-adjustment/{id} | CRUD: Retrieve an invoice adjustment
*InvoiceAdjustmentsApi* | [**ObjectPOSTInvoiceAdjustment**](docs/InvoiceAdjustmentsApi.md#objectpostinvoiceadjustment) | **POST** /v1/object/invoice-adjustment | CRUD: Create an invoice adjustment
*InvoiceAdjustmentsApi* | [**ObjectPUTInvoiceAdjustment**](docs/InvoiceAdjustmentsApi.md#objectputinvoiceadjustment) | **PUT** /v1/object/invoice-adjustment/{id} | CRUD: Update an invoice adjustment
*InvoiceItemAdjustmentsApi* | [**ObjectDELETEInvoiceItemAdjustment**](docs/InvoiceItemAdjustmentsApi.md#objectdeleteinvoiceitemadjustment) | **DELETE** /v1/object/invoice-item-adjustment/{id} | CRUD: Delete an invoice item adjustment
*InvoiceItemAdjustmentsApi* | [**ObjectGETInvoiceItemAdjustment**](docs/InvoiceItemAdjustmentsApi.md#objectgetinvoiceitemadjustment) | **GET** /v1/object/invoice-item-adjustment/{id} | CRUD: Retrieve an invoice item adjustment
*InvoiceItemAdjustmentsApi* | [**ObjectPOSTInvoiceItemAdjustment**](docs/InvoiceItemAdjustmentsApi.md#objectpostinvoiceitemadjustment) | **POST** /v1/object/invoice-item-adjustment | CRUD: Create an invoice item adjustment
*InvoiceItemAdjustmentsApi* | [**ObjectPUTInvoiceItemAdjustment**](docs/InvoiceItemAdjustmentsApi.md#objectputinvoiceitemadjustment) | **PUT** /v1/object/invoice-item-adjustment/{id} | CRUD: Update an invoice item adjustment
*InvoiceItemsApi* | [**ObjectGETInvoiceItem**](docs/InvoiceItemsApi.md#objectgetinvoiceitem) | **GET** /v1/object/invoice-item/{id} | CRUD: Retrieve an invoice item
*InvoicePaymentsApi* | [**ObjectGETInvoicePayment**](docs/InvoicePaymentsApi.md#objectgetinvoicepayment) | **GET** /v1/object/invoice-payment/{id} | CRUD: Retrieve an invoice payment
*InvoicePaymentsApi* | [**ObjectPOSTInvoicePayment**](docs/InvoicePaymentsApi.md#objectpostinvoicepayment) | **POST** /v1/object/invoice-payment | CRUD: Create an invoice payment
*InvoicePaymentsApi* | [**ObjectPUTInvoicePayment**](docs/InvoicePaymentsApi.md#objectputinvoicepayment) | **PUT** /v1/object/invoice-payment/{id} | CRUD: Update an invoice payment
*InvoiceSplitItemsApi* | [**ObjectGETInvoiceSplitItem**](docs/InvoiceSplitItemsApi.md#objectgetinvoicesplititem) | **GET** /v1/object/invoice-split-item/{id} | CRUD: Retrieve an invoice split item
*InvoiceSplitsApi* | [**ObjectGETInvoiceSplit**](docs/InvoiceSplitsApi.md#objectgetinvoicesplit) | **GET** /v1/object/invoice-split/{id} | CRUD: Retrieve an invoice split
*InvoicesApi* | [**GETInvoiceApplicationParts**](docs/InvoicesApi.md#getinvoiceapplicationparts) | **GET** /v1/invoices/{invoiceId}/application-parts | List all application parts of an invoice
*InvoicesApi* | [**GETInvoiceFiles**](docs/InvoicesApi.md#getinvoicefiles) | **GET** /v1/invoices/{invoiceKey}/files | List all files of an invoice
*InvoicesApi* | [**GETInvoiceItems**](docs/InvoicesApi.md#getinvoiceitems) | **GET** /v1/invoices/{invoiceKey}/items | List all items of an invoice
*InvoicesApi* | [**GETTaxationItemsOfInvoiceItem**](docs/InvoicesApi.md#gettaxationitemsofinvoiceitem) | **GET** /v1/invoices/{invoiceKey}/items/{itemId}/taxation-items | List all taxation items of an invoice item
*InvoicesApi* | [**ObjectDELETEInvoice**](docs/InvoicesApi.md#objectdeleteinvoice) | **DELETE** /v1/object/invoice/{id} | CRUD: Delete an invoice
*InvoicesApi* | [**ObjectGETInvoice**](docs/InvoicesApi.md#objectgetinvoice) | **GET** /v1/object/invoice/{id} | CRUD: Retrieve an invoice
*InvoicesApi* | [**ObjectPUTInvoice**](docs/InvoicesApi.md#objectputinvoice) | **PUT** /v1/object/invoice/{id} | CRUD: Update an invoice
*InvoicesApi* | [**POSTEmailInvoice**](docs/InvoicesApi.md#postemailinvoice) | **POST** /v1/invoices/{invoiceKey}/emails | Email an invoice
*InvoicesApi* | [**POSTPostInvoices**](docs/InvoicesApi.md#postpostinvoices) | **POST** /v1/invoices/bulk-post | Post invoices
*InvoicesApi* | [**POSTStandaloneInvoice**](docs/InvoicesApi.md#poststandaloneinvoice) | **POST** /v1/invoices | Create a standalone invoice
*InvoicesApi* | [**POSTStandaloneInvoices**](docs/InvoicesApi.md#poststandaloneinvoices) | **POST** /v1/invoices/batch | Create standalone invoices
*InvoicesApi* | [**POSTUploadFileForInvoice**](docs/InvoicesApi.md#postuploadfileforinvoice) | **POST** /v1/invoices/{invoiceKey}/files | Upload a file for an invoice
*InvoicesApi* | [**PUTBatchUpdateInvoices**](docs/InvoicesApi.md#putbatchupdateinvoices) | **PUT** /v1/invoices | Update invoices
*InvoicesApi* | [**PUTReverseInvoice**](docs/InvoicesApi.md#putreverseinvoice) | **PUT** /v1/invoices/{invoiceKey}/reverse | Reverse an invoice
*InvoicesApi* | [**PUTUpdateInvoice**](docs/InvoicesApi.md#putupdateinvoice) | **PUT** /v1/invoices/{invoiceKey} | Update an invoice
*InvoicesApi* | [**PUTWriteOffInvoice**](docs/InvoicesApi.md#putwriteoffinvoice) | **PUT** /v1/invoices/{invoiceId}/write-off | Write off an invoice
*JournalRunsApi* | [**DELETEJournalRun**](docs/JournalRunsApi.md#deletejournalrun) | **DELETE** /v1/journal-runs/{jr-number} | Delete a journal run
*JournalRunsApi* | [**GETJournalRun**](docs/JournalRunsApi.md#getjournalrun) | **GET** /v1/journal-runs/{jr-number} | Retrieve a journal run
*JournalRunsApi* | [**POSTJournalRun**](docs/JournalRunsApi.md#postjournalrun) | **POST** /v1/journal-runs | Create a journal run
*JournalRunsApi* | [**PUTJournalRun**](docs/JournalRunsApi.md#putjournalrun) | **PUT** /v1/journal-runs/{jr-number}/cancel | Cancel a journal run
*MassUpdaterApi* | [**GETMassUpdater**](docs/MassUpdaterApi.md#getmassupdater) | **GET** /v1/bulk/{bulk-key} | List all results of a mass action
*MassUpdaterApi* | [**POSTMassUpdater**](docs/MassUpdaterApi.md#postmassupdater) | **POST** /v1/bulk | Perform a mass action
*MassUpdaterApi* | [**PUTMassUpdater**](docs/MassUpdaterApi.md#putmassupdater) | **PUT** /v1/bulk/{bulk-key}/stop | Stop a mass action
*NotificationsApi* | [**DELETEDeleteEmailTemplate**](docs/NotificationsApi.md#deletedeleteemailtemplate) | **DELETE** /notifications/email-templates/{id} | Delete an email template
*NotificationsApi* | [**DELETEDeleteNotificationDefinition**](docs/NotificationsApi.md#deletedeletenotificationdefinition) | **DELETE** /notifications/notification-definitions/{id} | Delete a notification definition
*NotificationsApi* | [**DELETEDeleteNotificationHistoryForAccount**](docs/NotificationsApi.md#deletedeletenotificationhistoryforaccount) | **DELETE** /notifications/history | Delete notification histories for an account
*NotificationsApi* | [**GETCalloutHistory**](docs/NotificationsApi.md#getcallouthistory) | **GET** /v1/notification-history/callout | List callout notification histories
*NotificationsApi* | [**GETEmailHistory**](docs/NotificationsApi.md#getemailhistory) | **GET** /v1/notification-history/email | List email notification histories
*NotificationsApi* | [**GETGetEmailTemplate**](docs/NotificationsApi.md#getgetemailtemplate) | **GET** /notifications/email-templates/{id} | Retrieve an email template
*NotificationsApi* | [**GETGetNotificationDefinition**](docs/NotificationsApi.md#getgetnotificationdefinition) | **GET** /notifications/notification-definitions/{id} | Retrieve a notification definition
*NotificationsApi* | [**GETGetNotificationHistoryDeletionTask**](docs/NotificationsApi.md#getgetnotificationhistorydeletiontask) | **GET** /notifications/history/tasks/{id} | Retrieve a notification history deletion task
*NotificationsApi* | [**GETQueryEmailTemplates**](docs/NotificationsApi.md#getqueryemailtemplates) | **GET** /notifications/email-templates | List email templates
*NotificationsApi* | [**GETQueryNotificationDefinitions**](docs/NotificationsApi.md#getquerynotificationdefinitions) | **GET** /notifications/notification-definitions | List notification definitions
*NotificationsApi* | [**POSTCreateEmailTemplate**](docs/NotificationsApi.md#postcreateemailtemplate) | **POST** /notifications/email-templates | Create an email template
*NotificationsApi* | [**POSTCreateNotificationDefinition**](docs/NotificationsApi.md#postcreatenotificationdefinition) | **POST** /notifications/notification-definitions | Create a notification definition
*NotificationsApi* | [**POSTCreateOrUpdateEmailTemplates**](docs/NotificationsApi.md#postcreateorupdateemailtemplates) | **POST** /notifications/email-templates/import | Create or update email templates
*NotificationsApi* | [**POSTResendCalloutNotifications**](docs/NotificationsApi.md#postresendcalloutnotifications) | **POST** /notifications/callout-histories/resend | Resend callout notifications
*NotificationsApi* | [**POSTResendEmailNotifications**](docs/NotificationsApi.md#postresendemailnotifications) | **POST** /notifications/email-histories/resend | Resend email notifications
*NotificationsApi* | [**PUTUpdateEmailTemplate**](docs/NotificationsApi.md#putupdateemailtemplate) | **PUT** /notifications/email-templates/{id} | Update an email template
*NotificationsApi* | [**PUTUpdateNotificationDefinition**](docs/NotificationsApi.md#putupdatenotificationdefinition) | **PUT** /notifications/notification-definitions/{id} | Update a notification definition
*OAuthApi* | [**CreateToken**](docs/OAuthApi.md#createtoken) | **POST** /oauth/token | Create an OAuth token
*OperationsApi* | [**POSTBillingPreview**](docs/OperationsApi.md#postbillingpreview) | **POST** /v1/operations/billing-preview | Generate a billing preview
*OperationsApi* | [**POSTTransactionInvoicePayment**](docs/OperationsApi.md#posttransactioninvoicepayment) | **POST** /v1/operations/invoice-collect | Invoice and collect
*OrderLineItemsApi* | [**GETOrderLineItem**](docs/OrderLineItemsApi.md#getorderlineitem) | **GET** /v1/order-line-items/{itemId} | Retrieve an order line item
*OrderLineItemsApi* | [**PUTOrderLineItem**](docs/OrderLineItemsApi.md#putorderlineitem) | **PUT** /v1/order-line-items/{itemId} | Update an order line item
*OrderLineItemsApi* | [**PostOrderLineItems**](docs/OrderLineItemsApi.md#postorderlineitems) | **POST** /v1/order-line-items/bulk | Update order line items
*OrdersApi* | [**DELETEOrder**](docs/OrdersApi.md#deleteorder) | **DELETE** /v1/orders/{orderNumber} | Delete an order
*OrdersApi* | [**GETAllOrders**](docs/OrdersApi.md#getallorders) | **GET** /v1/orders | List orders
*OrdersApi* | [**GETJobStatusAndResponse**](docs/OrdersApi.md#getjobstatusandresponse) | **GET** /v1/async-jobs/{jobId} | Retrieve the status and response of a job
*OrdersApi* | [**GETOrder**](docs/OrdersApi.md#getorder) | **GET** /v1/orders/{orderNumber} | Retrieve an order
*OrdersApi* | [**GETOrderMetricsforEvergreenSubscription**](docs/OrdersApi.md#getordermetricsforevergreensubscription) | **GET** /v1/orders/{orderNumber}/evergreenMetrics/{subscriptionNumber} | List order metrics for an evergreen subscription
*OrdersApi* | [**GETOrdersByInvoiceOwner**](docs/OrdersApi.md#getordersbyinvoiceowner) | **GET** /v1/orders/invoiceOwner/{accountNumber} | List orders of an invoice owner
*OrdersApi* | [**GETOrdersBySubscriptionNumber**](docs/OrdersApi.md#getordersbysubscriptionnumber) | **GET** /v1/orders/subscription/{subscriptionNumber} | List orders by subscription number
*OrdersApi* | [**GETOrdersBySubscriptionOwner**](docs/OrdersApi.md#getordersbysubscriptionowner) | **GET** /v1/orders/subscriptionOwner/{accountNumber} | List orders of a subscription owner
*OrdersApi* | [**GETSubscriptionTermInfo**](docs/OrdersApi.md#getsubscriptionterminfo) | **GET** /v1/orders/term/{subscriptionNumber} | List subscription terms
*OrdersApi* | [**POSTCreateOrderAsynchronously**](docs/OrdersApi.md#postcreateorderasynchronously) | **POST** /v1/async/orders | Create an order asynchronously
*OrdersApi* | [**POSTOrder**](docs/OrdersApi.md#postorder) | **POST** /v1/orders | Create an order
*OrdersApi* | [**POSTPreviewOrder**](docs/OrdersApi.md#postprevieworder) | **POST** /v1/orders/preview | Preview an order
*OrdersApi* | [**POSTPreviewOrderAsynchronously**](docs/OrdersApi.md#postprevieworderasynchronously) | **POST** /v1/async/orders/preview | Preview an order asynchronously
*OrdersApi* | [**PUTOrderTriggerDates**](docs/OrdersApi.md#putordertriggerdates) | **PUT** /v1/orders/{orderNumber}/triggerDates | Update order action trigger dates
*OrdersApi* | [**PUTUpdateOrderCustomFields**](docs/OrdersApi.md#putupdateordercustomfields) | **PUT** /v1/orders/{orderNumber}/customFields | Update order custom fields
*OrdersApi* | [**PUTUpdateSubscriptionCustomFields**](docs/OrdersApi.md#putupdatesubscriptioncustomfields) | **PUT** /v1/subscriptions/{subscriptionNumber}/customFields | Update subscription custom fields
*PaymentGatewayReconciliationApi* | [**POSTReconcileRefund**](docs/PaymentGatewayReconciliationApi.md#postreconcilerefund) | **POST** /v1/refunds/{refund-key}/reconcile | Reconcile a refund
*PaymentGatewayReconciliationApi* | [**POSTRejectPayment**](docs/PaymentGatewayReconciliationApi.md#postrejectpayment) | **POST** /v1/gateway-settlement/payments/{payment-key}/reject | Reject a payment
*PaymentGatewayReconciliationApi* | [**POSTReversePayment**](docs/PaymentGatewayReconciliationApi.md#postreversepayment) | **POST** /v1/gateway-settlement/payments/{payment-key}/chargeback | Reverse a payment
*PaymentGatewayReconciliationApi* | [**POSTSettlePayment**](docs/PaymentGatewayReconciliationApi.md#postsettlepayment) | **POST** /v1/gateway-settlement/payments/{payment-key}/settle | Settle a payment
*PaymentGatewayTransactionLogsApi* | [**GETPaymentGatewayTransactionLog**](docs/PaymentGatewayTransactionLogsApi.md#getpaymentgatewaytransactionlog) | **GET** /v1/payment-gateway-transaction-log/{paymentOrRefundOrPaymentMethod-id} | Retrieve a payment gateway transaction log
*PaymentGatewaysApi* | [**GETPaymentgateways**](docs/PaymentGatewaysApi.md#getpaymentgateways) | **GET** /v1/paymentgateways | List all payment gateways
*PaymentMethodSnapshotsApi* | [**ObjectGETPaymentMethodSnapshot**](docs/PaymentMethodSnapshotsApi.md#objectgetpaymentmethodsnapshot) | **GET** /v1/object/payment-method-snapshot/{id} | CRUD: Retrieve a payment method snapshot
*PaymentMethodTransactionLogsApi* | [**ObjectGETPaymentMethodTransactionLog**](docs/PaymentMethodTransactionLogsApi.md#objectgetpaymentmethodtransactionlog) | **GET** /v1/object/payment-method-transaction-log/{id} | CRUD: Retrieve a payment method transaction log
*PaymentMethodsApi* | [**DELETEPaymentMethods**](docs/PaymentMethodsApi.md#deletepaymentmethods) | **DELETE** /v1/payment-methods/{payment-method-id} | Delete a payment method
*PaymentMethodsApi* | [**GETPaymentMethod**](docs/PaymentMethodsApi.md#getpaymentmethod) | **GET** /v1/payment-methods/{payment-method-id} | Retrieve a payment method
*PaymentMethodsApi* | [**GETPaymentMethodsCreditCard**](docs/PaymentMethodsApi.md#getpaymentmethodscreditcard) | **GET** /v1/payment-methods/credit-cards/accounts/{account-key} | List all credit card payment methods of an account
*PaymentMethodsApi* | [**GETStoredCredentialProfiles**](docs/PaymentMethodsApi.md#getstoredcredentialprofiles) | **GET** /v1/payment-methods/{payment-method-id}/profiles | List stored credential profiles of a payment method
*PaymentMethodsApi* | [**ObjectDELETEPaymentMethod**](docs/PaymentMethodsApi.md#objectdeletepaymentmethod) | **DELETE** /v1/object/payment-method/{id} | CRUD: Delete a payment method
*PaymentMethodsApi* | [**ObjectGETPaymentMethod**](docs/PaymentMethodsApi.md#objectgetpaymentmethod) | **GET** /v1/object/payment-method/{id} | CRUD: Retrieve a payment method
*PaymentMethodsApi* | [**ObjectPOSTPaymentMethod**](docs/PaymentMethodsApi.md#objectpostpaymentmethod) | **POST** /v1/object/payment-method | CRUD: Create a payment method
*PaymentMethodsApi* | [**ObjectPUTPaymentMethod**](docs/PaymentMethodsApi.md#objectputpaymentmethod) | **PUT** /v1/object/payment-method/{id} | CRUD: Update a payment method
*PaymentMethodsApi* | [**POSTCancelAuthorization**](docs/PaymentMethodsApi.md#postcancelauthorization) | **POST** /v1/payment-methods/{payment-method-id}/voidAuthorize | Cancel authorization
*PaymentMethodsApi* | [**POSTCancelStoredCredentialProfile**](docs/PaymentMethodsApi.md#postcancelstoredcredentialprofile) | **POST** /v1/payment-methods/{payment-method-id}/profiles/{profile-number}/cancel | Cancel a stored credential profile
*PaymentMethodsApi* | [**POSTCreateAuthorization**](docs/PaymentMethodsApi.md#postcreateauthorization) | **POST** /v1/payment-methods/{payment-method-id}/authorize | Create authorization
*PaymentMethodsApi* | [**POSTCreateStoredCredentialProfile**](docs/PaymentMethodsApi.md#postcreatestoredcredentialprofile) | **POST** /v1/payment-methods/{payment-method-id}/profiles | Create a stored credential profile
*PaymentMethodsApi* | [**POSTExpireStoredCredentialProfile**](docs/PaymentMethodsApi.md#postexpirestoredcredentialprofile) | **POST** /v1/payment-methods/{payment-method-id}/profiles/{profile-number}/expire | Expire a stored credential profile
*PaymentMethodsApi* | [**POSTPaymentMethods**](docs/PaymentMethodsApi.md#postpaymentmethods) | **POST** /v1/payment-methods | Create a payment method
*PaymentMethodsApi* | [**POSTPaymentMethodsCreditCard**](docs/PaymentMethodsApi.md#postpaymentmethodscreditcard) | **POST** /v1/payment-methods/credit-cards | Create a credit card payment method
*PaymentMethodsApi* | [**POSTPaymentMethodsDecryption**](docs/PaymentMethodsApi.md#postpaymentmethodsdecryption) | **POST** /v1/payment-methods/decryption | Create an Apple Pay payment method
*PaymentMethodsApi* | [**PUTPaymentMethod**](docs/PaymentMethodsApi.md#putpaymentmethod) | **PUT** /v1/payment-methods/{payment-method-id} | Update a payment method
*PaymentMethodsApi* | [**PUTPaymentMethodsCreditCard**](docs/PaymentMethodsApi.md#putpaymentmethodscreditcard) | **PUT** /v1/payment-methods/credit-cards/{payment-method-id} | Update a credit card payment method
*PaymentMethodsApi* | [**PUTScrubPaymentMethods**](docs/PaymentMethodsApi.md#putscrubpaymentmethods) | **PUT** /v1/payment-methods/{payment-method-id}/scrub | Scrub a payment method
*PaymentMethodsApi* | [**PUTVerifyPaymentMethods**](docs/PaymentMethodsApi.md#putverifypaymentmethods) | **PUT** /v1/payment-methods/{payment-method-id}/verify | Verify a payment method
*PaymentRunsApi* | [**DELETEPaymentRun**](docs/PaymentRunsApi.md#deletepaymentrun) | **DELETE** /v1/payment-runs/{paymentRunKey} | Delete a payment run
*PaymentRunsApi* | [**GETPaymentRun**](docs/PaymentRunsApi.md#getpaymentrun) | **GET** /v1/payment-runs/{paymentRunKey} | Retrieve a payment run
*PaymentRunsApi* | [**GETPaymentRunData**](docs/PaymentRunsApi.md#getpaymentrundata) | **GET** /v1/payment-runs/{paymentRunKey}/data | Retrieve payment run data
*PaymentRunsApi* | [**GETPaymentRunSummary**](docs/PaymentRunsApi.md#getpaymentrunsummary) | **GET** /v1/payment-runs/{paymentRunKey}/summary | Retrieve a payment run summary
*PaymentRunsApi* | [**GETPaymentRuns**](docs/PaymentRunsApi.md#getpaymentruns) | **GET** /v1/payment-runs | List payment runs
*PaymentRunsApi* | [**POSTPaymentRun**](docs/PaymentRunsApi.md#postpaymentrun) | **POST** /v1/payment-runs | Create a payment run
*PaymentRunsApi* | [**PUTPaymentRun**](docs/PaymentRunsApi.md#putpaymentrun) | **PUT** /v1/payment-runs/{paymentRunKey} | Update a payment run
*PaymentSchedulesApi* | [**GETPaymentSchedule**](docs/PaymentSchedulesApi.md#getpaymentschedule) | **GET** /v1/payment-schedules/{paymentScheduleKey} | Retrieve a payment schedule
*PaymentSchedulesApi* | [**GETPaymentScheduleItem**](docs/PaymentSchedulesApi.md#getpaymentscheduleitem) | **GET** /v1/payment-schedule-items/{item-id} | Retrieve a payment schedule item
*PaymentSchedulesApi* | [**GETPaymentScheduleStatistic**](docs/PaymentSchedulesApi.md#getpaymentschedulestatistic) | **GET** /v1/payment-schedules/statistics/{yyyy-mm-dd} | Retrieve payment schedule statistic of a date
*PaymentSchedulesApi* | [**GETPaymentSchedules**](docs/PaymentSchedulesApi.md#getpaymentschedules) | **GET** /v1/payment-schedules | List payment schedules by customer account
*PaymentSchedulesApi* | [**POSTAddItemsToCustomPaymentSchedule**](docs/PaymentSchedulesApi.md#postadditemstocustompaymentschedule) | **POST** /v1/payment-schedules/{paymentScheduleKey}/items | Add payment schedule items to a custom payment schedule
*PaymentSchedulesApi* | [**POSTPaymentSchedule**](docs/PaymentSchedulesApi.md#postpaymentschedule) | **POST** /v1/payment-schedules | Create a payment schedule
*PaymentSchedulesApi* | [**POSTPaymentSchedules**](docs/PaymentSchedulesApi.md#postpaymentschedules) | **POST** /v1/payment-schedules/batch | Create multiple payment schedules at once
*PaymentSchedulesApi* | [**POSTRetryPaymentScheduleItem**](docs/PaymentSchedulesApi.md#postretrypaymentscheduleitem) | **POST** /v1/payment-schedule-items/retry-payment | Retry failed payment schedule items
*PaymentSchedulesApi* | [**PUTCancelPaymentSchedule**](docs/PaymentSchedulesApi.md#putcancelpaymentschedule) | **PUT** /v1/payment-schedules/{paymentScheduleKey}/cancel | Cancel a payment schedule
*PaymentSchedulesApi* | [**PUTCancelPaymentScheduleItem**](docs/PaymentSchedulesApi.md#putcancelpaymentscheduleitem) | **PUT** /v1/payment-schedule-items/{item-id}/cancel | Cancel a payment schedule item
*PaymentSchedulesApi* | [**PUTPaymentSchedule**](docs/PaymentSchedulesApi.md#putpaymentschedule) | **PUT** /v1/payment-schedules/{paymentScheduleKey} | Update a payment schedule
*PaymentSchedulesApi* | [**PUTPaymentScheduleItem**](docs/PaymentSchedulesApi.md#putpaymentscheduleitem) | **PUT** /v1/payment-schedule-items/{item-id} | Update a payment schedule item
*PaymentSchedulesApi* | [**PUTPaymentScheduleUpdatePreview**](docs/PaymentSchedulesApi.md#putpaymentscheduleupdatepreview) | **PUT** /v1/payment-schedules/{paymentScheduleKey}/preview | Preview the result of payment schedule updates
*PaymentTransactionLogsApi* | [**ObjectGETPaymentTransactionLog**](docs/PaymentTransactionLogsApi.md#objectgetpaymenttransactionlog) | **GET** /v1/object/payment-transaction-log/{id} | CRUD: Retrieve a payment transaction log
*PaymentsApi* | [**DELETEPayment**](docs/PaymentsApi.md#deletepayment) | **DELETE** /v1/payments/{paymentKey} | Delete a payment
*PaymentsApi* | [**GETPayment**](docs/PaymentsApi.md#getpayment) | **GET** /v1/payments/{paymentKey} | Retrieve a payment
*PaymentsApi* | [**GETPaymentItemPart**](docs/PaymentsApi.md#getpaymentitempart) | **GET** /v1/payments/{paymentKey}/parts/{partid}/itemparts/{itempartid} | Retrieve a payment part item
*PaymentsApi* | [**GETPaymentItemParts**](docs/PaymentsApi.md#getpaymentitemparts) | **GET** /v1/payments/{paymentKey}/parts/{partid}/itemparts | List all payment part items
*PaymentsApi* | [**GETPaymentPart**](docs/PaymentsApi.md#getpaymentpart) | **GET** /v1/payments/{paymentKey}/parts/{partid} | Retrieve a payment part
*PaymentsApi* | [**GETPaymentParts**](docs/PaymentsApi.md#getpaymentparts) | **GET** /v1/payments/{paymentKey}/parts | List all parts of a payment
*PaymentsApi* | [**GETRetrieveAllPayments**](docs/PaymentsApi.md#getretrieveallpayments) | **GET** /v1/payments | List payments
*PaymentsApi* | [**ObjectDELETEPayment**](docs/PaymentsApi.md#objectdeletepayment) | **DELETE** /v1/object/payment/{id} | CRUD: Delete a payment
*PaymentsApi* | [**ObjectGETPayment**](docs/PaymentsApi.md#objectgetpayment) | **GET** /v1/object/payment/{id} | CRUD: Retrieve a payment
*PaymentsApi* | [**ObjectPOSTPayment**](docs/PaymentsApi.md#objectpostpayment) | **POST** /v1/object/payment | CRUD: Create a payment
*PaymentsApi* | [**ObjectPUTPayment**](docs/PaymentsApi.md#objectputpayment) | **PUT** /v1/object/payment/{id} | CRUD: Update a payment
*PaymentsApi* | [**POSTCreatePayment**](docs/PaymentsApi.md#postcreatepayment) | **POST** /v1/payments | Create a payment
*PaymentsApi* | [**POSTRefundPayment**](docs/PaymentsApi.md#postrefundpayment) | **POST** /v1/payments/{paymentKey}/refunds | Refund a payment
*PaymentsApi* | [**PUTApplyPayment**](docs/PaymentsApi.md#putapplypayment) | **PUT** /v1/payments/{paymentKey}/apply | Apply a payment
*PaymentsApi* | [**PUTCancelPayment**](docs/PaymentsApi.md#putcancelpayment) | **PUT** /v1/payments/{paymentKey}/cancel | Cancel a payment
*PaymentsApi* | [**PUTTransferPayment**](docs/PaymentsApi.md#puttransferpayment) | **PUT** /v1/payments/{paymentId}/transfer | Transfer a payment
*PaymentsApi* | [**PUTUnapplyPayment**](docs/PaymentsApi.md#putunapplypayment) | **PUT** /v1/payments/{paymentKey}/unapply | Unapply a payment
*PaymentsApi* | [**PUTUpdatePayment**](docs/PaymentsApi.md#putupdatepayment) | **PUT** /v1/payments/{paymentKey} | Update a payment
*ProductFeaturesApi* | [**ObjectDELETEProductFeature**](docs/ProductFeaturesApi.md#objectdeleteproductfeature) | **DELETE** /v1/object/product-feature/{id} | CRUD: Delete a product feature
*ProductFeaturesApi* | [**ObjectGETProductFeature**](docs/ProductFeaturesApi.md#objectgetproductfeature) | **GET** /v1/object/product-feature/{id} | CRUD: Retrieve a product feature
*ProductRatePlanChargeTiersApi* | [**ObjectGETProductRatePlanChargeTier**](docs/ProductRatePlanChargeTiersApi.md#objectgetproductrateplanchargetier) | **GET** /v1/object/product-rate-plan-charge-tier/{id} | CRUD: Retrieve a product rate plan charge tier
*ProductRatePlanChargeTiersApi* | [**ObjectPUTProductRatePlanChargeTier**](docs/ProductRatePlanChargeTiersApi.md#objectputproductrateplanchargetier) | **PUT** /v1/object/product-rate-plan-charge-tier/{id} | CRUD: Update a product rate plan charge tier
*ProductRatePlanChargesApi* | [**ObjectDELETEProductRatePlanCharge**](docs/ProductRatePlanChargesApi.md#objectdeleteproductrateplancharge) | **DELETE** /v1/object/product-rate-plan-charge/{id} | CRUD: Delete a product rate plan charge
*ProductRatePlanChargesApi* | [**ObjectGETProductRatePlanCharge**](docs/ProductRatePlanChargesApi.md#objectgetproductrateplancharge) | **GET** /v1/object/product-rate-plan-charge/{id} | CRUD: Retrieve a product rate plan charge
*ProductRatePlanChargesApi* | [**ObjectPOSTProductRatePlanCharge**](docs/ProductRatePlanChargesApi.md#objectpostproductrateplancharge) | **POST** /v1/object/product-rate-plan-charge | CRUD: Create a product rate plan charge
*ProductRatePlanChargesApi* | [**ObjectPUTProductRatePlanCharge**](docs/ProductRatePlanChargesApi.md#objectputproductrateplancharge) | **PUT** /v1/object/product-rate-plan-charge/{id} | CRUD: Update a product rate plan charge
*ProductRatePlansApi* | [**GETProductRatePlan**](docs/ProductRatePlansApi.md#getproductrateplan) | **GET** /v1/product-rate-plans/{id} | Retrieve a product rate plan by ID
*ProductRatePlansApi* | [**GETProductRatePlans**](docs/ProductRatePlansApi.md#getproductrateplans) | **GET** /v1/rateplan/{product-key}/productRatePlan | List all product rate plans of a product
*ProductRatePlansApi* | [**GETProductRatePlansByExternalID**](docs/ProductRatePlansApi.md#getproductrateplansbyexternalid) | **GET** /v1/product-rate-plans/external-id/{id} | List product rate plans by external ID
*ProductRatePlansApi* | [**ObjectDELETEProductRatePlan**](docs/ProductRatePlansApi.md#objectdeleteproductrateplan) | **DELETE** /v1/object/product-rate-plan/{id} | CRUD: Delete a product rate plan
*ProductRatePlansApi* | [**ObjectGETProductRatePlan**](docs/ProductRatePlansApi.md#objectgetproductrateplan) | **GET** /v1/object/product-rate-plan/{id} | CRUD: Retrieve a product rate plan
*ProductRatePlansApi* | [**ObjectPOSTProductRatePlan**](docs/ProductRatePlansApi.md#objectpostproductrateplan) | **POST** /v1/object/product-rate-plan | CRUD: Create a product rate plan
*ProductRatePlansApi* | [**ObjectPUTProductRatePlan**](docs/ProductRatePlansApi.md#objectputproductrateplan) | **PUT** /v1/object/product-rate-plan/{id} | CRUD: Update a product rate plan
*ProductsApi* | [**ObjectDELETEProduct**](docs/ProductsApi.md#objectdeleteproduct) | **DELETE** /v1/object/product/{id} | CRUD: Delete a product
*ProductsApi* | [**ObjectGETProduct**](docs/ProductsApi.md#objectgetproduct) | **GET** /v1/object/product/{id} | CRUD: Retrieve a product
*ProductsApi* | [**ObjectPOSTProduct**](docs/ProductsApi.md#objectpostproduct) | **POST** /v1/object/product | CRUD: Create a product
*ProductsApi* | [**ObjectPUTProduct**](docs/ProductsApi.md#objectputproduct) | **PUT** /v1/object/product/{id} | CRUD: Update a product
*QuotesDocumentApi* | [**POSTQuotesDocument**](docs/QuotesDocumentApi.md#postquotesdocument) | **POST** /v1/quotes/document | Generate a quote document
*RSASignaturesApi* | [**POSTDecryptRSASignatures**](docs/RSASignaturesApi.md#postdecryptrsasignatures) | **POST** /v1/rsa-signatures/decrypt | Decrypt an RSA signature
*RSASignaturesApi* | [**POSTRSASignatures**](docs/RSASignaturesApi.md#postrsasignatures) | **POST** /v1/rsa-signatures | Generate an RSA signature
*RampsApi* | [**GETRampByRampNumber**](docs/RampsApi.md#getrampbyrampnumber) | **GET** /v1/ramps/{rampNumber} | Retrieve a ramp
*RampsApi* | [**GETRampMetricsByOrderNumber**](docs/RampsApi.md#getrampmetricsbyordernumber) | **GET** /v1/orders/{orderNumber}/ramp-metrics | List ramp metrics by order number
*RampsApi* | [**GETRampMetricsByRampNumber**](docs/RampsApi.md#getrampmetricsbyrampnumber) | **GET** /v1/ramps/{rampNumber}/ramp-metrics | List all ramp metrics of a ramp
*RampsApi* | [**GETRampMetricsBySubscriptionKey**](docs/RampsApi.md#getrampmetricsbysubscriptionkey) | **GET** /v1/subscriptions/{subscriptionKey}/ramp-metrics | List ramp metrics by subscription key
*RampsApi* | [**GETRampsBySubscriptionKey**](docs/RampsApi.md#getrampsbysubscriptionkey) | **GET** /v1/subscriptions/{subscriptionKey}/ramps | Retrieve a ramp by subscription key
*RatePlanChargeTiersApi* | [**ObjectGETRatePlanChargeTier**](docs/RatePlanChargeTiersApi.md#objectgetrateplanchargetier) | **GET** /v1/object/rate-plan-charge-tier/{id} | CRUD: Retrieve a rate plan charge tier
*RatePlanChargesApi* | [**ObjectGETRatePlanCharge**](docs/RatePlanChargesApi.md#objectgetrateplancharge) | **GET** /v1/object/rate-plan-charge/{id} | CRUD: Retrieve a rate plan charge
*RatePlanChargesApi* | [**ObjectPUTRatePlanCharge**](docs/RatePlanChargesApi.md#objectputrateplancharge) | **PUT** /v1/object/rate-plan-charge/{id} | CRUD: Update a rate plan charge
*RatePlansApi* | [**GETRatePlan**](docs/RatePlansApi.md#getrateplan) | **GET** /v1/rateplans/{ratePlanId} | Retrieve a rate plan
*RatePlansApi* | [**ObjectGETRatePlan**](docs/RatePlansApi.md#objectgetrateplan) | **GET** /v1/object/rate-plan/{id} | CRUD: Retrieve a rate plan
*RefundInvoicePaymentsApi* | [**ObjectGETRefundInvoicePayment**](docs/RefundInvoicePaymentsApi.md#objectgetrefundinvoicepayment) | **GET** /v1/object/refund-invoice-payment/{id} | CRUD: Retrieve a refund invoice payment
*RefundTransactionLogsApi* | [**ObjectGETRefundTransactionLog**](docs/RefundTransactionLogsApi.md#objectgetrefundtransactionlog) | **GET** /v1/object/refund-transaction-log/{id} | CRUD: Retrieve a refund transaction log
*RefundsApi* | [**DELETERefund**](docs/RefundsApi.md#deleterefund) | **DELETE** /v1/refunds/{refundKey} | Delete a refund
*RefundsApi* | [**GETRefund**](docs/RefundsApi.md#getrefund) | **GET** /v1/refunds/{refundKey} | Retrieve a refund
*RefundsApi* | [**GETRefundItemPart**](docs/RefundsApi.md#getrefunditempart) | **GET** /v1/refunds/{refundKey}/parts/{refundpartid}/itemparts/{itempartid} | Retrieve a refund part item
*RefundsApi* | [**GETRefundItemParts**](docs/RefundsApi.md#getrefunditemparts) | **GET** /v1/refunds/{refundKey}/parts/{refundpartid}/itemparts | List all refund part items
*RefundsApi* | [**GETRefundPart**](docs/RefundsApi.md#getrefundpart) | **GET** /v1/refunds/{refundKey}/parts/{refundpartid} | Retrieve a refund part
*RefundsApi* | [**GETRefundParts**](docs/RefundsApi.md#getrefundparts) | **GET** /v1/refunds/{refundKey}/parts | List all parts of a refund
*RefundsApi* | [**GETRefunds**](docs/RefundsApi.md#getrefunds) | **GET** /v1/refunds | List refunds
*RefundsApi* | [**ObjectDELETERefund**](docs/RefundsApi.md#objectdeleterefund) | **DELETE** /v1/object/refund/{id} | CRUD: Delete a refund
*RefundsApi* | [**ObjectGETRefund**](docs/RefundsApi.md#objectgetrefund) | **GET** /v1/object/refund/{id} | CRUD: Retrieve a refund
*RefundsApi* | [**ObjectPOSTRefund**](docs/RefundsApi.md#objectpostrefund) | **POST** /v1/object/refund | CRUD: Create a refund
*RefundsApi* | [**ObjectPUTRefund**](docs/RefundsApi.md#objectputrefund) | **PUT** /v1/object/refund/{id} | CRUD: Update a refund
*RefundsApi* | [**PUTCancelRefund**](docs/RefundsApi.md#putcancelrefund) | **PUT** /v1/refunds/{refundKey}/cancel | Cancel a refund
*RefundsApi* | [**PUTUpdateRefund**](docs/RefundsApi.md#putupdaterefund) | **PUT** /v1/refunds/{refundKey} | Update a refund
*RevenueEventsApi* | [**GETRevenueEventDetails**](docs/RevenueEventsApi.md#getrevenueeventdetails) | **GET** /v1/revenue-events/{event-number} | Retrieve a revenue event
*RevenueEventsApi* | [**GETRevenueEventForRevenueSchedule**](docs/RevenueEventsApi.md#getrevenueeventforrevenueschedule) | **GET** /v1/revenue-events/revenue-schedules/{rs-number} | List all revenue events of a revenue schedule
*RevenueItemsApi* | [**GETRevenueItemsByChargeRevenueEventNumber**](docs/RevenueItemsApi.md#getrevenueitemsbychargerevenueeventnumber) | **GET** /v1/revenue-items/revenue-events/{event-number} | List revenue items by revenue event number
*RevenueItemsApi* | [**GETRevenueItemsByChargeRevenueSummaryNumber**](docs/RevenueItemsApi.md#getrevenueitemsbychargerevenuesummarynumber) | **GET** /v1/revenue-items/charge-revenue-summaries/{crs-number} | List revenue items by charge revenue summary number
*RevenueItemsApi* | [**GETRevenueItemsByRevenueSchedule**](docs/RevenueItemsApi.md#getrevenueitemsbyrevenueschedule) | **GET** /v1/revenue-items/revenue-schedules/{rs-number} | List all revenue items of a revenue schedule
*RevenueItemsApi* | [**PUTCustomFieldsonRevenueItemsByRevenueEvent**](docs/RevenueItemsApi.md#putcustomfieldsonrevenueitemsbyrevenueevent) | **PUT** /v1/revenue-items/revenue-events/{event-number} | Update custom fields on revenue items by revenue event number
*RevenueItemsApi* | [**PUTCustomFieldsonRevenueItemsByRevenueSchedule**](docs/RevenueItemsApi.md#putcustomfieldsonrevenueitemsbyrevenueschedule) | **PUT** /v1/revenue-items/revenue-schedules/{rs-number} | Update custom fields on revenue items by revenue schedule number
*RevenueRulesApi* | [**GETRevenueAutomationStartDate**](docs/RevenueRulesApi.md#getrevenueautomationstartdate) | **GET** /v1/settings/finance/revenue-automation-start-date | Retrieve a revenue automation start date
*RevenueRulesApi* | [**GETRevenueRecRulebyProductRatePlanCharge**](docs/RevenueRulesApi.md#getrevenuerecrulebyproductrateplancharge) | **GET** /v1/revenue-recognition-rules/product-charges/{charge-key} | Retrieve a revenue recognition rule by product rate plan charge ID
*RevenueRulesApi* | [**GETRevenueRecRules**](docs/RevenueRulesApi.md#getrevenuerecrules) | **GET** /v1/revenue-recognition-rules/subscription-charges/{charge-key} | Retrieve a revenue recognition rule by subscription charge ID
*RevenueSchedulesApi* | [**DELETERS**](docs/RevenueSchedulesApi.md#deleters) | **DELETE** /v1/revenue-schedules/{rs-number} | Delete a revenue schedule
*RevenueSchedulesApi* | [**GETRS**](docs/RevenueSchedulesApi.md#getrs) | **GET** /v1/revenue-schedules/{rs-number} | List all details of a revenue schedule
*RevenueSchedulesApi* | [**GETRSbyCreditMemoItem**](docs/RevenueSchedulesApi.md#getrsbycreditmemoitem) | **GET** /v1/revenue-schedules/credit-memo-items/{cmi-id} | Retrieve a revenue schedule by credit memo item ID 
*RevenueSchedulesApi* | [**GETRSbyDebitMemoItem**](docs/RevenueSchedulesApi.md#getrsbydebitmemoitem) | **GET** /v1/revenue-schedules/debit-memo-items/{dmi-id} | Retrieve a revenue schedule by debit memo item ID 
*RevenueSchedulesApi* | [**GETRSbyInvoiceItem**](docs/RevenueSchedulesApi.md#getrsbyinvoiceitem) | **GET** /v1/revenue-schedules/invoice-items/{invoice-item-id} | Retrieve a revenue schedule by invoice item ID
*RevenueSchedulesApi* | [**GETRSbyInvoiceItemAdjustment**](docs/RevenueSchedulesApi.md#getrsbyinvoiceitemadjustment) | **GET** /v1/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-key} | Retrieve a revenue schedule by invoice item adjustment key
*RevenueSchedulesApi* | [**GETRSbyProductChargeAndBillingAccount**](docs/RevenueSchedulesApi.md#getrsbyproductchargeandbillingaccount) | **GET** /v1/revenue-schedules/product-charges/{charge-key}/{account-key} | List revenue schedules of a product charge by charge ID and account key 
*RevenueSchedulesApi* | [**GETRSforSubscCharge**](docs/RevenueSchedulesApi.md#getrsforsubsccharge) | **GET** /v1/revenue-schedules/subscription-charges/{charge-key} | List revenue schedules by subscription charge key
*RevenueSchedulesApi* | [**POSTRSforCreditMemoItemDistributeByDateRange**](docs/RevenueSchedulesApi.md#postrsforcreditmemoitemdistributebydaterange) | **POST** /v1/revenue-schedules/credit-memo-items/{cmi-id}/distribute-revenue-with-date-range | Create a revenue schedule for a credit memo item (distribute by date range) 
*RevenueSchedulesApi* | [**POSTRSforCreditMemoItemManualDistribution**](docs/RevenueSchedulesApi.md#postrsforcreditmemoitemmanualdistribution) | **POST** /v1/revenue-schedules/credit-memo-items/{cmi-id} | Create a revenue schedule for a credit memo item (manual distribution) 
*RevenueSchedulesApi* | [**POSTRSforDebitMemoItemDistributeByDateRange**](docs/RevenueSchedulesApi.md#postrsfordebitmemoitemdistributebydaterange) | **POST** /v1/revenue-schedules/debit-memo-items/{dmi-id}/distribute-revenue-with-date-range | Create a revenue schedule for a debit memo item (distribute by date range) 
*RevenueSchedulesApi* | [**POSTRSforDebitMemoItemManualDistribution**](docs/RevenueSchedulesApi.md#postrsfordebitmemoitemmanualdistribution) | **POST** /v1/revenue-schedules/debit-memo-items/{dmi-id} | Create a revenue schedule for a debit memo item (manual distribution) 
*RevenueSchedulesApi* | [**POSTRSforInvoiceItemAdjustmentDistributeByDateRange**](docs/RevenueSchedulesApi.md#postrsforinvoiceitemadjustmentdistributebydaterange) | **POST** /v1/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-key}/distribute-revenue-with-date-range | Create a revenue schedule for an invoice item adjustment (distribute by date range)
*RevenueSchedulesApi* | [**POSTRSforInvoiceItemAdjustmentManualDistribution**](docs/RevenueSchedulesApi.md#postrsforinvoiceitemadjustmentmanualdistribution) | **POST** /v1/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-key} | Create a revenue schedule for an invoice item adjustment (manual distribution)
*RevenueSchedulesApi* | [**POSTRSforInvoiceItemDistributeByDateRange**](docs/RevenueSchedulesApi.md#postrsforinvoiceitemdistributebydaterange) | **POST** /v1/revenue-schedules/invoice-items/{invoice-item-id}/distribute-revenue-with-date-range | Create a revenue schedule for an invoice item (distribute by date range)
*RevenueSchedulesApi* | [**POSTRSforInvoiceItemManualDistribution**](docs/RevenueSchedulesApi.md#postrsforinvoiceitemmanualdistribution) | **POST** /v1/revenue-schedules/invoice-items/{invoice-item-id} | Create a revenue schedule for an invoice item (manual distribution)
*RevenueSchedulesApi* | [**POSTRSforSubscCharge**](docs/RevenueSchedulesApi.md#postrsforsubsccharge) | **POST** /v1/revenue-schedules/subscription-charges/{charge-key} | Create a revenue schedule by subscription charge key
*RevenueSchedulesApi* | [**PUTRSBasicInfo**](docs/RevenueSchedulesApi.md#putrsbasicinfo) | **PUT** /v1/revenue-schedules/{rs-number}/basic-information | Update a revenue schedule
*RevenueSchedulesApi* | [**PUTRevenueAcrossAP**](docs/RevenueSchedulesApi.md#putrevenueacrossap) | **PUT** /v1/revenue-schedules/{rs-number}/distribute-revenue-across-accounting-periods | Distribute revenue across accounting periods
*RevenueSchedulesApi* | [**PUTRevenueByRecognitionStartandEndDates**](docs/RevenueSchedulesApi.md#putrevenuebyrecognitionstartandenddates) | **PUT** /v1/revenue-schedules/{rs-number}/distribute-revenue-with-date-range | Distribute revenue in a recognition period
*RevenueSchedulesApi* | [**PUTRevenueSpecificDate**](docs/RevenueSchedulesApi.md#putrevenuespecificdate) | **PUT** /v1/revenue-schedules/{rs-number}/distribute-revenue-on-specific-date | Distribute revenue on a specific date
*SequenceSetsApi* | [**DELETESequenceSet**](docs/SequenceSetsApi.md#deletesequenceset) | **DELETE** /v1/sequence-sets/{id} | Delete a sequence set
*SequenceSetsApi* | [**GETSequenceSet**](docs/SequenceSetsApi.md#getsequenceset) | **GET** /v1/sequence-sets/{id} | Retrieve a sequence set
*SequenceSetsApi* | [**GETSequenceSets**](docs/SequenceSetsApi.md#getsequencesets) | **GET** /v1/sequence-sets | List sequence sets
*SequenceSetsApi* | [**POSTSequenceSets**](docs/SequenceSetsApi.md#postsequencesets) | **POST** /v1/sequence-sets | Create sequence sets
*SequenceSetsApi* | [**PUTSequenceSet**](docs/SequenceSetsApi.md#putsequenceset) | **PUT** /v1/sequence-sets/{id} | Update a sequence set
*SettingsApi* | [**GETListAllSettings**](docs/SettingsApi.md#getlistallsettings) | **GET** /settings/listing | List all settings
*SettingsApi* | [**POSTProcessSettingsBatchRequest**](docs/SettingsApi.md#postprocesssettingsbatchrequest) | **POST** /settings/batch-requests | Submit settings requests
*SubscriptionProductFeaturesApi* | [**ObjectGETSubscriptionProductFeature**](docs/SubscriptionProductFeaturesApi.md#objectgetsubscriptionproductfeature) | **GET** /v1/object/subscription-product-feature/{id} | CRUD: Retrieve a subscription product feature
*SubscriptionsApi* | [**GETSubscriptionsByAccount**](docs/SubscriptionsApi.md#getsubscriptionsbyaccount) | **GET** /v1/subscriptions/accounts/{account-key} | List subscriptions by account key
*SubscriptionsApi* | [**GETSubscriptionsByKey**](docs/SubscriptionsApi.md#getsubscriptionsbykey) | **GET** /v1/subscriptions/{subscription-key} | Retrieve a subscription by key
*SubscriptionsApi* | [**GETSubscriptionsByKeyAndVersion**](docs/SubscriptionsApi.md#getsubscriptionsbykeyandversion) | **GET** /v1/subscriptions/{subscription-key}/versions/{version} | Retrieve a subscription by key and version
*SubscriptionsApi* | [**ObjectDELETESubscription**](docs/SubscriptionsApi.md#objectdeletesubscription) | **DELETE** /v1/object/subscription/{id} | CRUD: Delete a subscription
*SubscriptionsApi* | [**ObjectGETSubscription**](docs/SubscriptionsApi.md#objectgetsubscription) | **GET** /v1/object/subscription/{id} | CRUD: Retrieve a subscription
*SubscriptionsApi* | [**ObjectPUTSubscription**](docs/SubscriptionsApi.md#objectputsubscription) | **PUT** /v1/object/subscription/{id} | CRUD: Update a subscription
*SubscriptionsApi* | [**POSTPreviewSubscription**](docs/SubscriptionsApi.md#postpreviewsubscription) | **POST** /v1/subscriptions/preview | Preview a subscription
*SubscriptionsApi* | [**POSTSubscription**](docs/SubscriptionsApi.md#postsubscription) | **POST** /v1/subscriptions | Create a subscription
*SubscriptionsApi* | [**PUTCancelSubscription**](docs/SubscriptionsApi.md#putcancelsubscription) | **PUT** /v1/subscriptions/{subscription-key}/cancel | Cancel a subscription
*SubscriptionsApi* | [**PUTDeleteSubscription**](docs/SubscriptionsApi.md#putdeletesubscription) | **PUT** /v1/subscriptions/{subscription-key}/delete | Delete a subscription by number
*SubscriptionsApi* | [**PUTRenewSubscription**](docs/SubscriptionsApi.md#putrenewsubscription) | **PUT** /v1/subscriptions/{subscription-key}/renew | Renew a subscription
*SubscriptionsApi* | [**PUTResumeSubscription**](docs/SubscriptionsApi.md#putresumesubscription) | **PUT** /v1/subscriptions/{subscription-key}/resume | Resume a subscription
*SubscriptionsApi* | [**PUTSubscription**](docs/SubscriptionsApi.md#putsubscription) | **PUT** /v1/subscriptions/{subscription-key} | Update a subscription
*SubscriptionsApi* | [**PUTSuspendSubscription**](docs/SubscriptionsApi.md#putsuspendsubscription) | **PUT** /v1/subscriptions/{subscription-key}/suspend | Suspend a subscription
*SubscriptionsApi* | [**PUTUpdateSubscriptionCustomFieldsOfASpecifiedVersion**](docs/SubscriptionsApi.md#putupdatesubscriptioncustomfieldsofaspecifiedversion) | **PUT** /v1/subscriptions/{subscriptionNumber}/versions/{version}/customFields | Update subscription custom fields of a subscription version
*SummaryJournalEntriesApi* | [**DELETESummaryJournalEntry**](docs/SummaryJournalEntriesApi.md#deletesummaryjournalentry) | **DELETE** /v1/journal-entries/{je-number} | Delete a summary journal entry
*SummaryJournalEntriesApi* | [**GETAllSummaryJournalEntries**](docs/SummaryJournalEntriesApi.md#getallsummaryjournalentries) | **GET** /v1/journal-entries/journal-runs/{jr-number} | List all summary journal entries in a journal run
*SummaryJournalEntriesApi* | [**GETSummaryJournalEntry**](docs/SummaryJournalEntriesApi.md#getsummaryjournalentry) | **GET** /v1/journal-entries/{je-number} | Retrieve a summary journal entry
*SummaryJournalEntriesApi* | [**POSTSummaryJournalEntry**](docs/SummaryJournalEntriesApi.md#postsummaryjournalentry) | **POST** /v1/journal-entries | Create a summary journal entry
*SummaryJournalEntriesApi* | [**PUTBasicSummaryJournalEntry**](docs/SummaryJournalEntriesApi.md#putbasicsummaryjournalentry) | **PUT** /v1/journal-entries/{je-number}/basic-information | Update a summary journal entry
*SummaryJournalEntriesApi* | [**PUTSummaryJournalEntry**](docs/SummaryJournalEntriesApi.md#putsummaryjournalentry) | **PUT** /v1/journal-entries/{je-number}/cancel | Cancel a summary journal entry
*TaxationItemsApi* | [**DELETETaxationItem**](docs/TaxationItemsApi.md#deletetaxationitem) | **DELETE** /v1/taxationitems/{id} | Delete a taxation item
*TaxationItemsApi* | [**GETTaxationItem**](docs/TaxationItemsApi.md#gettaxationitem) | **GET** /v1/taxationitems/{id} | Retrieve a taxation item 
*TaxationItemsApi* | [**ObjectDELETETaxationItem**](docs/TaxationItemsApi.md#objectdeletetaxationitem) | **DELETE** /v1/object/taxation-item/{id} | CRUD: Delete a taxation item
*TaxationItemsApi* | [**ObjectGETTaxationItem**](docs/TaxationItemsApi.md#objectgettaxationitem) | **GET** /v1/object/taxation-item/{id} | CRUD: Retrieve a taxation item
*TaxationItemsApi* | [**ObjectPOSTTaxationItem**](docs/TaxationItemsApi.md#objectposttaxationitem) | **POST** /v1/object/taxation-item | CRUD: Create a taxation item
*TaxationItemsApi* | [**ObjectPUTTaxationItem**](docs/TaxationItemsApi.md#objectputtaxationitem) | **PUT** /v1/object/taxation-item/{id} | CRUD: Update a taxation item
*TaxationItemsApi* | [**PUTTaxationItem**](docs/TaxationItemsApi.md#puttaxationitem) | **PUT** /v1/taxationitems/{id} | Update a taxation item
*TransactionsApi* | [**GETTransactionInvoice**](docs/TransactionsApi.md#gettransactioninvoice) | **GET** /v1/transactions/invoices/accounts/{account-key} | List all invoices for an account
*TransactionsApi* | [**GETTransactionPayment**](docs/TransactionsApi.md#gettransactionpayment) | **GET** /v1/transactions/payments/accounts/{account-key} | List all payments for an account
*UnitOfMeasureApi* | [**ObjectDELETEUnitOfMeasure**](docs/UnitOfMeasureApi.md#objectdeleteunitofmeasure) | **DELETE** /v1/object/unit-of-measure/{id} | CRUD: Delete a unit of measure
*UnitOfMeasureApi* | [**ObjectGETUnitOfMeasure**](docs/UnitOfMeasureApi.md#objectgetunitofmeasure) | **GET** /v1/object/unit-of-measure/{id} | CRUD: Retrieve a unit of measure
*UnitOfMeasureApi* | [**ObjectPOSTUnitOfMeasure**](docs/UnitOfMeasureApi.md#objectpostunitofmeasure) | **POST** /v1/object/unit-of-measure | CRUD: Create a unit of measure
*UnitOfMeasureApi* | [**ObjectPUTUnitOfMeasure**](docs/UnitOfMeasureApi.md#objectputunitofmeasure) | **PUT** /v1/object/unit-of-measure/{id} | CRUD: Update a unit of measure
*UsageApi* | [**GETUsage**](docs/UsageApi.md#getusage) | **GET** /v1/usage/accounts/{account-key} | Retrieve a usage record
*UsageApi* | [**GETUsageRateDetailByInvoiceItem**](docs/UsageApi.md#getusageratedetailbyinvoiceitem) | **GET** /v1/invoices/invoice-item/{invoice-item-id}/usage-rate-detail | Retrieve usage rate detail for an invoice item
*UsageApi* | [**ObjectDELETEUsage**](docs/UsageApi.md#objectdeleteusage) | **DELETE** /v1/object/usage/{id} | CRUD: Delete a usage record
*UsageApi* | [**ObjectGETUsage**](docs/UsageApi.md#objectgetusage) | **GET** /v1/object/usage/{id} | CRUD: Retrieve a usage record
*UsageApi* | [**ObjectPOSTUsage**](docs/UsageApi.md#objectpostusage) | **POST** /v1/object/usage | CRUD: Create a usage record
*UsageApi* | [**ObjectPUTUsage**](docs/UsageApi.md#objectputusage) | **PUT** /v1/object/usage/{id} | CRUD: Update a usage record
*UsageApi* | [**POSTUsage**](docs/UsageApi.md#postusage) | **POST** /v1/usage | Upload a usage file
*UsersApi* | [**GETEntitiesUserAccessible**](docs/UsersApi.md#getentitiesuseraccessible) | **GET** /v1/users/{username}/accessible-entities | Multi-entity: List all entities that a user can access
*UsersApi* | [**PUTAcceptUserAccess**](docs/UsersApi.md#putacceptuseraccess) | **PUT** /v1/users/{username}/accept-access | Multi-entity: Accept user access
*UsersApi* | [**PUTDenyUserAccess**](docs/UsersApi.md#putdenyuseraccess) | **PUT** /v1/users/{username}/deny-access | Multi-entity: Deny user access
*UsersApi* | [**PUTSendUserAccessRequests**](docs/UsersApi.md#putsenduseraccessrequests) | **PUT** /v1/users/{username}/request-access | Multi-entity: Send user access requests
*WorkflowsApi* | [**DELETEWorkflow**](docs/WorkflowsApi.md#deleteworkflow) | **DELETE** /workflows/{workflow_id} | Delete a workflow
*WorkflowsApi* | [**DELETEWorkflowVersion**](docs/WorkflowsApi.md#deleteworkflowversion) | **DELETE** /versions/{version_id} | Delete a workflow version
*WorkflowsApi* | [**GETWorkflow**](docs/WorkflowsApi.md#getworkflow) | **GET** /workflows/{workflow_id} | Retrieve a workflow
*WorkflowsApi* | [**GETWorkflowExport**](docs/WorkflowsApi.md#getworkflowexport) | **GET** /workflows/{workflow_id}/export | Export a workflow version
*WorkflowsApi* | [**GETWorkflowRun**](docs/WorkflowsApi.md#getworkflowrun) | **GET** /workflows/workflow_runs/{workflow_run_id} | Retrieve a workflow run
*WorkflowsApi* | [**GETWorkflowVersions**](docs/WorkflowsApi.md#getworkflowversions) | **GET** /workflows/{workflow_id}/versions | List all versions of a workflow definition
*WorkflowsApi* | [**GETWorkflows**](docs/WorkflowsApi.md#getworkflows) | **GET** /workflows | List workflows
*WorkflowsApi* | [**GETWorkflowsTask**](docs/WorkflowsApi.md#getworkflowstask) | **GET** /workflows/tasks/{task_id} | Retrieve a workflow task
*WorkflowsApi* | [**GETWorkflowsTasks**](docs/WorkflowsApi.md#getworkflowstasks) | **GET** /workflows/tasks | List workflow tasks
*WorkflowsApi* | [**GETWorkflowsUsages**](docs/WorkflowsApi.md#getworkflowsusages) | **GET** /workflows/metrics.json | Retrieve workflow task usage
*WorkflowsApi* | [**PATCHUpdateWorkflow**](docs/WorkflowsApi.md#patchupdateworkflow) | **PATCH** /workflows/{workflow_id} | Update a workflow
*WorkflowsApi* | [**POSTRunWorkflow**](docs/WorkflowsApi.md#postrunworkflow) | **POST** /workflows/{workflow_id}/run | Run a workflow
*WorkflowsApi* | [**POSTWorkflowImport**](docs/WorkflowsApi.md#postworkflowimport) | **POST** /workflows/import | Import a workflow
*WorkflowsApi* | [**POSTWorkflowVersionsImport**](docs/WorkflowsApi.md#postworkflowversionsimport) | **POST** /workflows/{workflow_id}/versions/import | Import a workflow version
*WorkflowsApi* | [**POSTWorkflowsTaskRerun**](docs/WorkflowsApi.md#postworkflowstaskrerun) | **POST** /workflows/tasks/{task_id}/rerun | Rerun a workflow task
*WorkflowsApi* | [**PUTWorkflowsTasksUpdate**](docs/WorkflowsApi.md#putworkflowstasksupdate) | **PUT** /workflows/tasks/batch_update | Update workflow tasks
*ZuoraRevenueIntegrationApi* | [**PUTRevProAccountingCodes**](docs/ZuoraRevenueIntegrationApi.md#putrevproaccountingcodes) | **PUT** /v1/revpro-accounting-codes | Update a Zuora Revenue accounting code


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Account](docs/Account.md)
 - [Model.AccountAllOf](docs/AccountAllOf.md)
 - [Model.AccountCreditCardHolder](docs/AccountCreditCardHolder.md)
 - [Model.AccountObjectNSFields](docs/AccountObjectNSFields.md)
 - [Model.ActionAmendCreditMemo](docs/ActionAmendCreditMemo.md)
 - [Model.ActionAmendCreditMemoData](docs/ActionAmendCreditMemoData.md)
 - [Model.ActionAmendCreditMemoDataTaxationItemDataInner](docs/ActionAmendCreditMemoDataTaxationItemDataInner.md)
 - [Model.ActionAmendCreditMemoItem](docs/ActionAmendCreditMemoItem.md)
 - [Model.ActionAmendInvoiceData](docs/ActionAmendInvoiceData.md)
 - [Model.ActionAmendInvoiceDataTaxationItemDataInner](docs/ActionAmendInvoiceDataTaxationItemDataInner.md)
 - [Model.ActionAmendInvoiceItem](docs/ActionAmendInvoiceItem.md)
 - [Model.ActionAmendSubscriptionProductFeature](docs/ActionAmendSubscriptionProductFeature.md)
 - [Model.ActionAmendSubscriptionProductFeatureAllOf](docs/ActionAmendSubscriptionProductFeatureAllOf.md)
 - [Model.ActionSubscribeCreditMemo](docs/ActionSubscribeCreditMemo.md)
 - [Model.ActionSubscribeCreditMemoData](docs/ActionSubscribeCreditMemoData.md)
 - [Model.ActionSubscribeCreditMemoItem](docs/ActionSubscribeCreditMemoItem.md)
 - [Model.ActionSubscribeInvoiceData](docs/ActionSubscribeInvoiceData.md)
 - [Model.ActionSubscribeInvoiceItem](docs/ActionSubscribeInvoiceItem.md)
 - [Model.ActionSubscribeInvoiceItemAllOf](docs/ActionSubscribeInvoiceItemAllOf.md)
 - [Model.ActionsErrorResponse](docs/ActionsErrorResponse.md)
 - [Model.AmendRequest](docs/AmendRequest.md)
 - [Model.AmendRequestAmendOptions](docs/AmendRequestAmendOptions.md)
 - [Model.AmendRequestPreviewOptions](docs/AmendRequestPreviewOptions.md)
 - [Model.AmendResult](docs/AmendResult.md)
 - [Model.Amendment](docs/Amendment.md)
 - [Model.AmendmentRatePlanChargeData](docs/AmendmentRatePlanChargeData.md)
 - [Model.AmendmentRatePlanChargeDataRatePlanCharge](docs/AmendmentRatePlanChargeDataRatePlanCharge.md)
 - [Model.AmendmentRatePlanChargeDataRatePlanChargeAllOf](docs/AmendmentRatePlanChargeDataRatePlanChargeAllOf.md)
 - [Model.AmendmentRatePlanChargeTier](docs/AmendmentRatePlanChargeTier.md)
 - [Model.AmendmentRatePlanData](docs/AmendmentRatePlanData.md)
 - [Model.ApplyCreditMemoType](docs/ApplyCreditMemoType.md)
 - [Model.ApplyPaymentType](docs/ApplyPaymentType.md)
 - [Model.BadRequestResponse](docs/BadRequestResponse.md)
 - [Model.BadRequestResponseErrorsInner](docs/BadRequestResponseErrorsInner.md)
 - [Model.BatchDebitMemoType](docs/BatchDebitMemoType.md)
 - [Model.BatchInvoiceType](docs/BatchInvoiceType.md)
 - [Model.BatchInvoiceTypeAllOf](docs/BatchInvoiceTypeAllOf.md)
 - [Model.BillToContact](docs/BillToContact.md)
 - [Model.BillToContactAllOf](docs/BillToContactAllOf.md)
 - [Model.BillToContactPostOrder](docs/BillToContactPostOrder.md)
 - [Model.BillToContactPostOrderAllOf](docs/BillToContactPostOrderAllOf.md)
 - [Model.BillingDocumentQueryResponseElementType](docs/BillingDocumentQueryResponseElementType.md)
 - [Model.BillingOptions](docs/BillingOptions.md)
 - [Model.BillingPreviewResult](docs/BillingPreviewResult.md)
 - [Model.BillingUpdate](docs/BillingUpdate.md)
 - [Model.BulkCreditMemosResponseType](docs/BulkCreditMemosResponseType.md)
 - [Model.BulkCreditMemosResponseTypeAllOf](docs/BulkCreditMemosResponseTypeAllOf.md)
 - [Model.BulkDebitMemosResponseType](docs/BulkDebitMemosResponseType.md)
 - [Model.BulkDebitMemosResponseTypeAllOf](docs/BulkDebitMemosResponseTypeAllOf.md)
 - [Model.CalloutAuth](docs/CalloutAuth.md)
 - [Model.CancelSubscription](docs/CancelSubscription.md)
 - [Model.CatalogGroupResponse](docs/CatalogGroupResponse.md)
 - [Model.ChangePlan](docs/ChangePlan.md)
 - [Model.ChangePlanRatePlanOverride](docs/ChangePlanRatePlanOverride.md)
 - [Model.ChargeMetricsData](docs/ChargeMetricsData.md)
 - [Model.ChargeMetricsDiscountAllocationDetailResponse](docs/ChargeMetricsDiscountAllocationDetailResponse.md)
 - [Model.ChargeMetricsResponse](docs/ChargeMetricsResponse.md)
 - [Model.ChargeModelConfigurationType](docs/ChargeModelConfigurationType.md)
 - [Model.ChargeModelDataOverride](docs/ChargeModelDataOverride.md)
 - [Model.ChargeModelDataOverrideChargeModelConfiguration](docs/ChargeModelDataOverrideChargeModelConfiguration.md)
 - [Model.ChargeOverride](docs/ChargeOverride.md)
 - [Model.ChargeOverrideBilling](docs/ChargeOverrideBilling.md)
 - [Model.ChargeOverrideForEvergreen](docs/ChargeOverrideForEvergreen.md)
 - [Model.ChargeOverridePricing](docs/ChargeOverridePricing.md)
 - [Model.ChargePreviewMetrics](docs/ChargePreviewMetrics.md)
 - [Model.ChargePreviewMetricsCmrr](docs/ChargePreviewMetricsCmrr.md)
 - [Model.ChargePreviewMetricsTax](docs/ChargePreviewMetricsTax.md)
 - [Model.ChargePreviewMetricsTcb](docs/ChargePreviewMetricsTcb.md)
 - [Model.ChargePreviewMetricsTcv](docs/ChargePreviewMetricsTcv.md)
 - [Model.ChargeTier](docs/ChargeTier.md)
 - [Model.ChargeUpdate](docs/ChargeUpdate.md)
 - [Model.ChargeUpdateForEvergreen](docs/ChargeUpdateForEvergreen.md)
 - [Model.ChildrenSettingValueRequest](docs/ChildrenSettingValueRequest.md)
 - [Model.CommonErrorResponse](docs/CommonErrorResponse.md)
 - [Model.CommonReasonsErrorResponse](docs/CommonReasonsErrorResponse.md)
 - [Model.CommonReasonsErrorResponseReasonsInner](docs/CommonReasonsErrorResponseReasonsInner.md)
 - [Model.CommonResponseType](docs/CommonResponseType.md)
 - [Model.CommonResponseTypeReasonsInner](docs/CommonResponseTypeReasonsInner.md)
 - [Model.Contact](docs/Contact.md)
 - [Model.CreateChangePlan](docs/CreateChangePlan.md)
 - [Model.CreateEntityResponseType](docs/CreateEntityResponseType.md)
 - [Model.CreateEntityType](docs/CreateEntityType.md)
 - [Model.CreateOrUpdateEmailTemplatesResponse](docs/CreateOrUpdateEmailTemplatesResponse.md)
 - [Model.CreateOrderChangePlanRatePlanOverride](docs/CreateOrderChangePlanRatePlanOverride.md)
 - [Model.CreateOrderChargeOverride](docs/CreateOrderChargeOverride.md)
 - [Model.CreateOrderChargeUpdate](docs/CreateOrderChargeUpdate.md)
 - [Model.CreateOrderCreateSubscription](docs/CreateOrderCreateSubscription.md)
 - [Model.CreateOrderCreateSubscriptionNewSubscriptionOwnerAccount](docs/CreateOrderCreateSubscriptionNewSubscriptionOwnerAccount.md)
 - [Model.CreateOrderCreateSubscriptionNewSubscriptionOwnerAccountAllOf](docs/CreateOrderCreateSubscriptionNewSubscriptionOwnerAccountAllOf.md)
 - [Model.CreateOrderCreateSubscriptionTerms](docs/CreateOrderCreateSubscriptionTerms.md)
 - [Model.CreateOrderCreateSubscriptionTermsInitialTerm](docs/CreateOrderCreateSubscriptionTermsInitialTerm.md)
 - [Model.CreateOrderOrderAction](docs/CreateOrderOrderAction.md)
 - [Model.CreateOrderOrderLineItem](docs/CreateOrderOrderLineItem.md)
 - [Model.CreateOrderPricingUpdate](docs/CreateOrderPricingUpdate.md)
 - [Model.CreateOrderRatePlanOverride](docs/CreateOrderRatePlanOverride.md)
 - [Model.CreateOrderRatePlanUpdate](docs/CreateOrderRatePlanUpdate.md)
 - [Model.CreateOrderResume](docs/CreateOrderResume.md)
 - [Model.CreateOrderSuspend](docs/CreateOrderSuspend.md)
 - [Model.CreateOrderTermsAndConditions](docs/CreateOrderTermsAndConditions.md)
 - [Model.CreateOrderTriggerParams](docs/CreateOrderTriggerParams.md)
 - [Model.CreateOrderUpdateProductTriggerParams](docs/CreateOrderUpdateProductTriggerParams.md)
 - [Model.CreatePMPayPalECPayPalNativeECPayPalCP](docs/CreatePMPayPalECPayPalNativeECPayPalCP.md)
 - [Model.CreatePaymentMethodACH](docs/CreatePaymentMethodACH.md)
 - [Model.CreatePaymentMethodApplePayAdyen](docs/CreatePaymentMethodApplePayAdyen.md)
 - [Model.CreatePaymentMethodBankTransfer](docs/CreatePaymentMethodBankTransfer.md)
 - [Model.CreatePaymentMethodBankTransferAccountHolderInfo](docs/CreatePaymentMethodBankTransferAccountHolderInfo.md)
 - [Model.CreatePaymentMethodCCReferenceTransaction](docs/CreatePaymentMethodCCReferenceTransaction.md)
 - [Model.CreatePaymentMethodCardholderInfo](docs/CreatePaymentMethodCardholderInfo.md)
 - [Model.CreatePaymentMethodCommon](docs/CreatePaymentMethodCommon.md)
 - [Model.CreatePaymentMethodCommonGatewayOptions](docs/CreatePaymentMethodCommonGatewayOptions.md)
 - [Model.CreatePaymentMethodCommonMandateInfo](docs/CreatePaymentMethodCommonMandateInfo.md)
 - [Model.CreatePaymentMethodCreditCard](docs/CreatePaymentMethodCreditCard.md)
 - [Model.CreatePaymentMethodGooglePayAdyenChase](docs/CreatePaymentMethodGooglePayAdyenChase.md)
 - [Model.CreatePaymentMethodPayPalAdaptive](docs/CreatePaymentMethodPayPalAdaptive.md)
 - [Model.CreatePaymentType](docs/CreatePaymentType.md)
 - [Model.CreatePaymentTypeAllOf](docs/CreatePaymentTypeAllOf.md)
 - [Model.CreatePaymentTypeAllOfFinanceInformation](docs/CreatePaymentTypeAllOfFinanceInformation.md)
 - [Model.CreatePaymentTypeAllOfGatewayOptions](docs/CreatePaymentTypeAllOfGatewayOptions.md)
 - [Model.CreateStoredCredentialProfileRequest](docs/CreateStoredCredentialProfileRequest.md)
 - [Model.CreateSubscription](docs/CreateSubscription.md)
 - [Model.CreateSubscriptionForEvergreen](docs/CreateSubscriptionForEvergreen.md)
 - [Model.CreateSubscriptionNewSubscriptionOwnerAccount](docs/CreateSubscriptionNewSubscriptionOwnerAccount.md)
 - [Model.CreateSubscriptionTerms](docs/CreateSubscriptionTerms.md)
 - [Model.CreditBalanceAdjustmentObjectNSFields](docs/CreditBalanceAdjustmentObjectNSFields.md)
 - [Model.CreditCard](docs/CreditCard.md)
 - [Model.CreditMemoApplyDebitMemoItemRequestType](docs/CreditMemoApplyDebitMemoItemRequestType.md)
 - [Model.CreditMemoApplyDebitMemoRequestType](docs/CreditMemoApplyDebitMemoRequestType.md)
 - [Model.CreditMemoApplyInvoiceItemRequestType](docs/CreditMemoApplyInvoiceItemRequestType.md)
 - [Model.CreditMemoApplyInvoiceRequestType](docs/CreditMemoApplyInvoiceRequestType.md)
 - [Model.CreditMemoEntityPrefix](docs/CreditMemoEntityPrefix.md)
 - [Model.CreditMemoFromChargeDetailType](docs/CreditMemoFromChargeDetailType.md)
 - [Model.CreditMemoFromChargeDetailTypeAllOf](docs/CreditMemoFromChargeDetailTypeAllOf.md)
 - [Model.CreditMemoFromChargeDetailTypeAllOfFinanceInformation](docs/CreditMemoFromChargeDetailTypeAllOfFinanceInformation.md)
 - [Model.CreditMemoFromChargeType](docs/CreditMemoFromChargeType.md)
 - [Model.CreditMemoFromChargeTypeAllOf](docs/CreditMemoFromChargeTypeAllOf.md)
 - [Model.CreditMemoFromInvoiceType](docs/CreditMemoFromInvoiceType.md)
 - [Model.CreditMemoFromInvoiceTypeAllOf](docs/CreditMemoFromInvoiceTypeAllOf.md)
 - [Model.CreditMemoItemFromInvoiceItemType](docs/CreditMemoItemFromInvoiceItemType.md)
 - [Model.CreditMemoItemFromInvoiceItemTypeAllOf](docs/CreditMemoItemFromInvoiceItemTypeAllOf.md)
 - [Model.CreditMemoItemFromInvoiceItemTypeAllOfFinanceInformation](docs/CreditMemoItemFromInvoiceItemTypeAllOfFinanceInformation.md)
 - [Model.CreditMemoItemFromWriteOffInvoice](docs/CreditMemoItemFromWriteOffInvoice.md)
 - [Model.CreditMemoItemFromWriteOffInvoiceAllOf](docs/CreditMemoItemFromWriteOffInvoiceAllOf.md)
 - [Model.CreditMemoObjectNSFields](docs/CreditMemoObjectNSFields.md)
 - [Model.CreditMemoResponseType](docs/CreditMemoResponseType.md)
 - [Model.CreditMemoResult](docs/CreditMemoResult.md)
 - [Model.CreditMemoResultCreditMemoInner](docs/CreditMemoResultCreditMemoInner.md)
 - [Model.CreditMemoTaxItemFromInvoiceTaxItemType](docs/CreditMemoTaxItemFromInvoiceTaxItemType.md)
 - [Model.CreditMemoTaxItemFromInvoiceTaxItemTypeFinanceInformation](docs/CreditMemoTaxItemFromInvoiceTaxItemTypeFinanceInformation.md)
 - [Model.CreditMemoUnapplyDebitMemoItemRequestType](docs/CreditMemoUnapplyDebitMemoItemRequestType.md)
 - [Model.CreditMemoUnapplyDebitMemoRequestType](docs/CreditMemoUnapplyDebitMemoRequestType.md)
 - [Model.CreditMemoUnapplyInvoiceItemRequestType](docs/CreditMemoUnapplyInvoiceItemRequestType.md)
 - [Model.CreditMemoUnapplyInvoiceRequestType](docs/CreditMemoUnapplyInvoiceRequestType.md)
 - [Model.CreditMemosFromCharges](docs/CreditMemosFromCharges.md)
 - [Model.CreditMemosFromChargesAllOf](docs/CreditMemosFromChargesAllOf.md)
 - [Model.CreditMemosFromInvoices](docs/CreditMemosFromInvoices.md)
 - [Model.CreditMemosFromInvoicesAllOf](docs/CreditMemosFromInvoicesAllOf.md)
 - [Model.CustomObjectAllFieldsDefinition](docs/CustomObjectAllFieldsDefinition.md)
 - [Model.CustomObjectAllFieldsDefinitionAllOf](docs/CustomObjectAllFieldsDefinitionAllOf.md)
 - [Model.CustomObjectAllFieldsDefinitionAllOfCreatedById](docs/CustomObjectAllFieldsDefinitionAllOfCreatedById.md)
 - [Model.CustomObjectAllFieldsDefinitionAllOfCreatedDate](docs/CustomObjectAllFieldsDefinitionAllOfCreatedDate.md)
 - [Model.CustomObjectAllFieldsDefinitionAllOfId](docs/CustomObjectAllFieldsDefinitionAllOfId.md)
 - [Model.CustomObjectAllFieldsDefinitionAllOfUpdatedById](docs/CustomObjectAllFieldsDefinitionAllOfUpdatedById.md)
 - [Model.CustomObjectAllFieldsDefinitionAllOfUpdatedDate](docs/CustomObjectAllFieldsDefinitionAllOfUpdatedDate.md)
 - [Model.CustomObjectBulkDeleteFilter](docs/CustomObjectBulkDeleteFilter.md)
 - [Model.CustomObjectBulkDeleteFilterCondition](docs/CustomObjectBulkDeleteFilterCondition.md)
 - [Model.CustomObjectBulkJobErrorResponse](docs/CustomObjectBulkJobErrorResponse.md)
 - [Model.CustomObjectBulkJobErrorResponseCollection](docs/CustomObjectBulkJobErrorResponseCollection.md)
 - [Model.CustomObjectBulkJobRequest](docs/CustomObjectBulkJobRequest.md)
 - [Model.CustomObjectBulkJobResponse](docs/CustomObjectBulkJobResponse.md)
 - [Model.CustomObjectBulkJobResponseCollection](docs/CustomObjectBulkJobResponseCollection.md)
 - [Model.CustomObjectBulkJobResponseError](docs/CustomObjectBulkJobResponseError.md)
 - [Model.CustomObjectCustomFieldDefinition](docs/CustomObjectCustomFieldDefinition.md)
 - [Model.CustomObjectCustomFieldDefinitionUpdate](docs/CustomObjectCustomFieldDefinitionUpdate.md)
 - [Model.CustomObjectDefinition](docs/CustomObjectDefinition.md)
 - [Model.CustomObjectDefinitionSchema](docs/CustomObjectDefinitionSchema.md)
 - [Model.CustomObjectDefinitionSchemaRelationshipsInner](docs/CustomObjectDefinitionSchemaRelationshipsInner.md)
 - [Model.CustomObjectDefinitionSchemaRelationshipsInnerRecordConstraints](docs/CustomObjectDefinitionSchemaRelationshipsInnerRecordConstraints.md)
 - [Model.CustomObjectDefinitionSchemaRelationshipsInnerRecordConstraintsCreate](docs/CustomObjectDefinitionSchemaRelationshipsInnerRecordConstraintsCreate.md)
 - [Model.CustomObjectDefinitionUpdateActionRequest](docs/CustomObjectDefinitionUpdateActionRequest.md)
 - [Model.CustomObjectDefinitionUpdateActionRequestRelationship](docs/CustomObjectDefinitionUpdateActionRequestRelationship.md)
 - [Model.CustomObjectDefinitionUpdateActionRequestRelationshipRecordConstraints](docs/CustomObjectDefinitionUpdateActionRequestRelationshipRecordConstraints.md)
 - [Model.CustomObjectDefinitionUpdateActionRequestRelationshipRecordConstraintsCreate](docs/CustomObjectDefinitionUpdateActionRequestRelationshipRecordConstraintsCreate.md)
 - [Model.CustomObjectDefinitionUpdateActionResponse](docs/CustomObjectDefinitionUpdateActionResponse.md)
 - [Model.CustomObjectDefinitionUpdateActionResponseRelationship](docs/CustomObjectDefinitionUpdateActionResponseRelationship.md)
 - [Model.CustomObjectDefinitionUpdateActionResponseRelationshipRecordConstraints](docs/CustomObjectDefinitionUpdateActionResponseRelationshipRecordConstraints.md)
 - [Model.CustomObjectDefinitionUpdateActionResponseRelationshipRecordConstraintsCreate](docs/CustomObjectDefinitionUpdateActionResponseRelationshipRecordConstraintsCreate.md)
 - [Model.CustomObjectRecordBatchAction](docs/CustomObjectRecordBatchAction.md)
 - [Model.CustomObjectRecordBatchRequest](docs/CustomObjectRecordBatchRequest.md)
 - [Model.CustomObjectRecordWithAllFields](docs/CustomObjectRecordWithAllFields.md)
 - [Model.CustomObjectRecordWithAllFieldsAllOf](docs/CustomObjectRecordWithAllFieldsAllOf.md)
 - [Model.CustomObjectRecordsBatchUpdatePartialSuccessResponse](docs/CustomObjectRecordsBatchUpdatePartialSuccessResponse.md)
 - [Model.CustomObjectRecordsErrorResponse](docs/CustomObjectRecordsErrorResponse.md)
 - [Model.CustomObjectRecordsThrottledResponse](docs/CustomObjectRecordsThrottledResponse.md)
 - [Model.CustomObjectRecordsWithError](docs/CustomObjectRecordsWithError.md)
 - [Model.CustomObjectsNamespace](docs/CustomObjectsNamespace.md)
 - [Model.DELETEntityResponseType](docs/DELETEntityResponseType.md)
 - [Model.DataQueryErrorResponse](docs/DataQueryErrorResponse.md)
 - [Model.DataQueryJob](docs/DataQueryJob.md)
 - [Model.DataQueryJobAllOf](docs/DataQueryJobAllOf.md)
 - [Model.DataQueryJobCancelled](docs/DataQueryJobCancelled.md)
 - [Model.DataQueryJobCancelledAllOf](docs/DataQueryJobCancelledAllOf.md)
 - [Model.DataQueryJobCommon](docs/DataQueryJobCommon.md)
 - [Model.DebitMemoCollectRequest](docs/DebitMemoCollectRequest.md)
 - [Model.DebitMemoCollectRequestPayment](docs/DebitMemoCollectRequestPayment.md)
 - [Model.DebitMemoCollectResponse](docs/DebitMemoCollectResponse.md)
 - [Model.DebitMemoCollectResponseAllOf](docs/DebitMemoCollectResponseAllOf.md)
 - [Model.DebitMemoCollectResponseAllOfDebitMemo](docs/DebitMemoCollectResponseAllOfDebitMemo.md)
 - [Model.DebitMemoCollectResponseAllOfProcessedPayment](docs/DebitMemoCollectResponseAllOfProcessedPayment.md)
 - [Model.DebitMemoCollectResponseAppliedCreditMemos](docs/DebitMemoCollectResponseAppliedCreditMemos.md)
 - [Model.DebitMemoCollectResponseAppliedCreditMemosAllOf](docs/DebitMemoCollectResponseAppliedCreditMemosAllOf.md)
 - [Model.DebitMemoCollectResponseAppliedPayments](docs/DebitMemoCollectResponseAppliedPayments.md)
 - [Model.DebitMemoCollectResponseAppliedPaymentsAllOf](docs/DebitMemoCollectResponseAppliedPaymentsAllOf.md)
 - [Model.DebitMemoEntityPrefix](docs/DebitMemoEntityPrefix.md)
 - [Model.DebitMemoFromChargeDetailType](docs/DebitMemoFromChargeDetailType.md)
 - [Model.DebitMemoFromChargeDetailTypeAllOf](docs/DebitMemoFromChargeDetailTypeAllOf.md)
 - [Model.DebitMemoFromChargeDetailTypeAllOfFinanceInformation](docs/DebitMemoFromChargeDetailTypeAllOfFinanceInformation.md)
 - [Model.DebitMemoFromChargeType](docs/DebitMemoFromChargeType.md)
 - [Model.DebitMemoFromChargeTypeAllOf](docs/DebitMemoFromChargeTypeAllOf.md)
 - [Model.DebitMemoFromInvoiceType](docs/DebitMemoFromInvoiceType.md)
 - [Model.DebitMemoFromInvoiceTypeAllOf](docs/DebitMemoFromInvoiceTypeAllOf.md)
 - [Model.DebitMemoItemFromInvoiceItemType](docs/DebitMemoItemFromInvoiceItemType.md)
 - [Model.DebitMemoItemFromInvoiceItemTypeAllOf](docs/DebitMemoItemFromInvoiceItemTypeAllOf.md)
 - [Model.DebitMemoItemFromInvoiceItemTypeAllOfFinanceInformation](docs/DebitMemoItemFromInvoiceItemTypeAllOfFinanceInformation.md)
 - [Model.DebitMemoObjectNSFields](docs/DebitMemoObjectNSFields.md)
 - [Model.DebitMemoTaxItemFromInvoiceTaxItemType](docs/DebitMemoTaxItemFromInvoiceTaxItemType.md)
 - [Model.DebitMemoTaxItemFromInvoiceTaxItemTypeFinanceInformation](docs/DebitMemoTaxItemFromInvoiceTaxItemTypeFinanceInformation.md)
 - [Model.DebitMemosFromCharges](docs/DebitMemosFromCharges.md)
 - [Model.DebitMemosFromChargesAllOf](docs/DebitMemosFromChargesAllOf.md)
 - [Model.DebitMemosFromInvoices](docs/DebitMemosFromInvoices.md)
 - [Model.DebitMemosFromInvoicesAllOf](docs/DebitMemosFromInvoicesAllOf.md)
 - [Model.DeleteDataQueryJobResponse](docs/DeleteDataQueryJobResponse.md)
 - [Model.DeleteResult](docs/DeleteResult.md)
 - [Model.DeleteWorkflowError](docs/DeleteWorkflowError.md)
 - [Model.DeleteWorkflowSuccess](docs/DeleteWorkflowSuccess.md)
 - [Model.DetailedWorkflow](docs/DetailedWorkflow.md)
 - [Model.DiscountItemObjectNSFields](docs/DiscountItemObjectNSFields.md)
 - [Model.DiscountPricingOverride](docs/DiscountPricingOverride.md)
 - [Model.DiscountPricingUpdate](docs/DiscountPricingUpdate.md)
 - [Model.ElectronicPaymentOptions](docs/ElectronicPaymentOptions.md)
 - [Model.EndConditions](docs/EndConditions.md)
 - [Model.Error401](docs/Error401.md)
 - [Model.ErrorResponse](docs/ErrorResponse.md)
 - [Model.ErrorResponse401Record](docs/ErrorResponse401Record.md)
 - [Model.ErrorResponseReasonsInner](docs/ErrorResponseReasonsInner.md)
 - [Model.EventRevenueItemType](docs/EventRevenueItemType.md)
 - [Model.EventRevenueItemTypeAllOf](docs/EventRevenueItemTypeAllOf.md)
 - [Model.EventTrigger](docs/EventTrigger.md)
 - [Model.EventType](docs/EventType.md)
 - [Model.ExecuteResult](docs/ExecuteResult.md)
 - [Model.ExportWorkflowVersionResponse](docs/ExportWorkflowVersionResponse.md)
 - [Model.ExternalPaymentOptions](docs/ExternalPaymentOptions.md)
 - [Model.FilterRuleParameterDefinition](docs/FilterRuleParameterDefinition.md)
 - [Model.FinanceInformation](docs/FinanceInformation.md)
 - [Model.GETAPaymentGatwayResponse](docs/GETAPaymentGatwayResponse.md)
 - [Model.GETARPaymentType](docs/GETARPaymentType.md)
 - [Model.GETARPaymentTypeAllOf](docs/GETARPaymentTypeAllOf.md)
 - [Model.GETARPaymentTypeAllOfFinanceInformation](docs/GETARPaymentTypeAllOfFinanceInformation.md)
 - [Model.GETARPaymentTypewithSuccess](docs/GETARPaymentTypewithSuccess.md)
 - [Model.GETARPaymentTypewithSuccessAllOf](docs/GETARPaymentTypewithSuccessAllOf.md)
 - [Model.GETAccountPaymentMethodType](docs/GETAccountPaymentMethodType.md)
 - [Model.GETAccountPaymentMethodTypeAllOf](docs/GETAccountPaymentMethodTypeAllOf.md)
 - [Model.GETAccountSummaryInvoiceType](docs/GETAccountSummaryInvoiceType.md)
 - [Model.GETAccountSummaryPaymentInvoiceType](docs/GETAccountSummaryPaymentInvoiceType.md)
 - [Model.GETAccountSummaryPaymentType](docs/GETAccountSummaryPaymentType.md)
 - [Model.GETAccountSummarySubscriptionRatePlanType](docs/GETAccountSummarySubscriptionRatePlanType.md)
 - [Model.GETAccountSummarySubscriptionType](docs/GETAccountSummarySubscriptionType.md)
 - [Model.GETAccountSummarySubscriptionTypeAllOf](docs/GETAccountSummarySubscriptionTypeAllOf.md)
 - [Model.GETAccountSummaryType](docs/GETAccountSummaryType.md)
 - [Model.GETAccountSummaryTypeBasicInfo](docs/GETAccountSummaryTypeBasicInfo.md)
 - [Model.GETAccountSummaryTypeBasicInfoAllOf](docs/GETAccountSummaryTypeBasicInfoAllOf.md)
 - [Model.GETAccountSummaryTypeBasicInfoAllOfDefaultPaymentMethod](docs/GETAccountSummaryTypeBasicInfoAllOfDefaultPaymentMethod.md)
 - [Model.GETAccountSummaryTypeBillToContact](docs/GETAccountSummaryTypeBillToContact.md)
 - [Model.GETAccountSummaryTypeBillToContactAllOf](docs/GETAccountSummaryTypeBillToContactAllOf.md)
 - [Model.GETAccountSummaryTypeSoldToContact](docs/GETAccountSummaryTypeSoldToContact.md)
 - [Model.GETAccountSummaryTypeTaxInfo](docs/GETAccountSummaryTypeTaxInfo.md)
 - [Model.GETAccountSummaryUsageType](docs/GETAccountSummaryUsageType.md)
 - [Model.GETAccountType](docs/GETAccountType.md)
 - [Model.GETAccountTypeBasicInfo](docs/GETAccountTypeBasicInfo.md)
 - [Model.GETAccountTypeBasicInfoAllOf](docs/GETAccountTypeBasicInfoAllOf.md)
 - [Model.GETAccountTypeBillToContact](docs/GETAccountTypeBillToContact.md)
 - [Model.GETAccountTypeBillToContactAllOf](docs/GETAccountTypeBillToContactAllOf.md)
 - [Model.GETAccountTypeBillingAndPayment](docs/GETAccountTypeBillingAndPayment.md)
 - [Model.GETAccountTypeMetrics](docs/GETAccountTypeMetrics.md)
 - [Model.GETAccountTypeSoldToContact](docs/GETAccountTypeSoldToContact.md)
 - [Model.GETAccountTypeSoldToContactAllOf](docs/GETAccountTypeSoldToContactAllOf.md)
 - [Model.GETAccountingCodeItemType](docs/GETAccountingCodeItemType.md)
 - [Model.GETAccountingCodeItemTypeAllOf](docs/GETAccountingCodeItemTypeAllOf.md)
 - [Model.GETAccountingCodeItemWithoutSuccessType](docs/GETAccountingCodeItemWithoutSuccessType.md)
 - [Model.GETAccountingCodeItemWithoutSuccessTypeAllOf](docs/GETAccountingCodeItemWithoutSuccessTypeAllOf.md)
 - [Model.GETAccountingCodesType](docs/GETAccountingCodesType.md)
 - [Model.GETAccountingPeriodType](docs/GETAccountingPeriodType.md)
 - [Model.GETAccountingPeriodTypeAllOf](docs/GETAccountingPeriodTypeAllOf.md)
 - [Model.GETAccountingPeriodTypeAllOfFileIds](docs/GETAccountingPeriodTypeAllOfFileIds.md)
 - [Model.GETAccountingPeriodWithoutSuccessType](docs/GETAccountingPeriodWithoutSuccessType.md)
 - [Model.GETAccountingPeriodWithoutSuccessTypeAllOf](docs/GETAccountingPeriodWithoutSuccessTypeAllOf.md)
 - [Model.GETAccountingPeriodsType](docs/GETAccountingPeriodsType.md)
 - [Model.GETAllCustomObjectDefinitionsInNamespaceResponse](docs/GETAllCustomObjectDefinitionsInNamespaceResponse.md)
 - [Model.GETAmendmentType](docs/GETAmendmentType.md)
 - [Model.GETAttachmentResponseType](docs/GETAttachmentResponseType.md)
 - [Model.GETAttachmentResponseWithoutSuccessType](docs/GETAttachmentResponseWithoutSuccessType.md)
 - [Model.GETAttachmentsResponseType](docs/GETAttachmentsResponseType.md)
 - [Model.GETBillingDocumentFilesDeletionJobResponse](docs/GETBillingDocumentFilesDeletionJobResponse.md)
 - [Model.GETBillingDocumentsResponseType](docs/GETBillingDocumentsResponseType.md)
 - [Model.GETCMTaxItemType](docs/GETCMTaxItemType.md)
 - [Model.GETCMTaxItemTypeAllOf](docs/GETCMTaxItemTypeAllOf.md)
 - [Model.GETCMTaxItemTypeAllOfFinanceInformation](docs/GETCMTaxItemTypeAllOfFinanceInformation.md)
 - [Model.GETCMTaxItemTypeNew](docs/GETCMTaxItemTypeNew.md)
 - [Model.GETCalloutHistoryVOType](docs/GETCalloutHistoryVOType.md)
 - [Model.GETCalloutHistoryVOsType](docs/GETCalloutHistoryVOsType.md)
 - [Model.GETCatalogGroupProductRatePlanResponse](docs/GETCatalogGroupProductRatePlanResponse.md)
 - [Model.GETCatalogType](docs/GETCatalogType.md)
 - [Model.GETChargeRSDetailType](docs/GETChargeRSDetailType.md)
 - [Model.GETCreditMemoCollectionType](docs/GETCreditMemoCollectionType.md)
 - [Model.GETCreditMemoItemPartType](docs/GETCreditMemoItemPartType.md)
 - [Model.GETCreditMemoItemPartTypewithSuccess](docs/GETCreditMemoItemPartTypewithSuccess.md)
 - [Model.GETCreditMemoItemPartsCollectionType](docs/GETCreditMemoItemPartsCollectionType.md)
 - [Model.GETCreditMemoItemType](docs/GETCreditMemoItemType.md)
 - [Model.GETCreditMemoItemTypeAllOf](docs/GETCreditMemoItemTypeAllOf.md)
 - [Model.GETCreditMemoItemTypeAllOfFinanceInformation](docs/GETCreditMemoItemTypeAllOfFinanceInformation.md)
 - [Model.GETCreditMemoItemTypeAllOfTaxationItems](docs/GETCreditMemoItemTypeAllOfTaxationItems.md)
 - [Model.GETCreditMemoItemTypewithSuccess](docs/GETCreditMemoItemTypewithSuccess.md)
 - [Model.GETCreditMemoItemTypewithSuccessAllOf](docs/GETCreditMemoItemTypewithSuccessAllOf.md)
 - [Model.GETCreditMemoItemTypewithSuccessAllOfFinanceInformation](docs/GETCreditMemoItemTypewithSuccessAllOfFinanceInformation.md)
 - [Model.GETCreditMemoItemsListType](docs/GETCreditMemoItemsListType.md)
 - [Model.GETCreditMemoPartType](docs/GETCreditMemoPartType.md)
 - [Model.GETCreditMemoPartTypewithSuccess](docs/GETCreditMemoPartTypewithSuccess.md)
 - [Model.GETCreditMemoPartsCollectionType](docs/GETCreditMemoPartsCollectionType.md)
 - [Model.GETCreditMemoType](docs/GETCreditMemoType.md)
 - [Model.GETCreditMemoTypeAllOf](docs/GETCreditMemoTypeAllOf.md)
 - [Model.GETCreditMemoTypewithSuccess](docs/GETCreditMemoTypewithSuccess.md)
 - [Model.GETCreditMemoTypewithSuccessAllOf](docs/GETCreditMemoTypewithSuccessAllOf.md)
 - [Model.GETCustomExchangeRatesDataType](docs/GETCustomExchangeRatesDataType.md)
 - [Model.GETCustomExchangeRatesType](docs/GETCustomExchangeRatesType.md)
 - [Model.GETDMTaxItemType](docs/GETDMTaxItemType.md)
 - [Model.GETDMTaxItemTypeAllOf](docs/GETDMTaxItemTypeAllOf.md)
 - [Model.GETDMTaxItemTypeAllOfFinanceInformation](docs/GETDMTaxItemTypeAllOfFinanceInformation.md)
 - [Model.GETDMTaxItemTypeNew](docs/GETDMTaxItemTypeNew.md)
 - [Model.GETDMTaxItemTypeNewAllOf](docs/GETDMTaxItemTypeNewAllOf.md)
 - [Model.GETDebitMemoCollectionType](docs/GETDebitMemoCollectionType.md)
 - [Model.GETDebitMemoItemCollectionType](docs/GETDebitMemoItemCollectionType.md)
 - [Model.GETDebitMemoItemType](docs/GETDebitMemoItemType.md)
 - [Model.GETDebitMemoItemTypeAllOf](docs/GETDebitMemoItemTypeAllOf.md)
 - [Model.GETDebitMemoItemTypeAllOfFinanceInformation](docs/GETDebitMemoItemTypeAllOfFinanceInformation.md)
 - [Model.GETDebitMemoItemTypeAllOfTaxationItems](docs/GETDebitMemoItemTypeAllOfTaxationItems.md)
 - [Model.GETDebitMemoItemTypewithSuccess](docs/GETDebitMemoItemTypewithSuccess.md)
 - [Model.GETDebitMemoItemTypewithSuccessAllOf](docs/GETDebitMemoItemTypewithSuccessAllOf.md)
 - [Model.GETDebitMemoItemTypewithSuccessAllOfTaxationItems](docs/GETDebitMemoItemTypewithSuccessAllOfTaxationItems.md)
 - [Model.GETDebitMemoType](docs/GETDebitMemoType.md)
 - [Model.GETDebitMemoTypeAllOf](docs/GETDebitMemoTypeAllOf.md)
 - [Model.GETDebitMemoTypewithSuccess](docs/GETDebitMemoTypewithSuccess.md)
 - [Model.GETDebitMemoTypewithSuccessAllOf](docs/GETDebitMemoTypewithSuccessAllOf.md)
 - [Model.GETDiscountApplyDetailsType](docs/GETDiscountApplyDetailsType.md)
 - [Model.GETDocumentPropertiesResponseType](docs/GETDocumentPropertiesResponseType.md)
 - [Model.GETEmailHistoryVOType](docs/GETEmailHistoryVOType.md)
 - [Model.GETEmailHistoryVOsType](docs/GETEmailHistoryVOsType.md)
 - [Model.GETEntitiesResponseType](docs/GETEntitiesResponseType.md)
 - [Model.GETEntitiesResponseTypeWithId](docs/GETEntitiesResponseTypeWithId.md)
 - [Model.GETEntitiesType](docs/GETEntitiesType.md)
 - [Model.GETEntitiesUserAccessibleResponseType](docs/GETEntitiesUserAccessibleResponseType.md)
 - [Model.GETEntityConnectionsArrayItemsType](docs/GETEntityConnectionsArrayItemsType.md)
 - [Model.GETEntityConnectionsResponseType](docs/GETEntityConnectionsResponseType.md)
 - [Model.GETEventTriggers200Response](docs/GETEventTriggers200Response.md)
 - [Model.GETInvoiceFileWrapper](docs/GETInvoiceFileWrapper.md)
 - [Model.GETInvoiceFilesResponse](docs/GETInvoiceFilesResponse.md)
 - [Model.GETInvoiceItemsResponse](docs/GETInvoiceItemsResponse.md)
 - [Model.GETInvoiceTaxItemType](docs/GETInvoiceTaxItemType.md)
 - [Model.GETInvoiceTaxationItemsResponse](docs/GETInvoiceTaxationItemsResponse.md)
 - [Model.GETInvoiceType](docs/GETInvoiceType.md)
 - [Model.GETInvoiceTypeAllOf](docs/GETInvoiceTypeAllOf.md)
 - [Model.GETJobStatusAndResponse200Response](docs/GETJobStatusAndResponse200Response.md)
 - [Model.GETJournalEntriesInJournalRunType](docs/GETJournalEntriesInJournalRunType.md)
 - [Model.GETJournalEntryDetailType](docs/GETJournalEntryDetailType.md)
 - [Model.GETJournalEntryDetailTypeAllOf](docs/GETJournalEntryDetailTypeAllOf.md)
 - [Model.GETJournalEntryDetailTypeWithoutSuccess](docs/GETJournalEntryDetailTypeWithoutSuccess.md)
 - [Model.GETJournalEntryDetailTypeWithoutSuccessAllOf](docs/GETJournalEntryDetailTypeWithoutSuccessAllOf.md)
 - [Model.GETJournalEntryItemType](docs/GETJournalEntryItemType.md)
 - [Model.GETJournalEntryItemTypeAllOf](docs/GETJournalEntryItemTypeAllOf.md)
 - [Model.GETJournalEntrySegmentType](docs/GETJournalEntrySegmentType.md)
 - [Model.GETJournalRunTransactionType](docs/GETJournalRunTransactionType.md)
 - [Model.GETJournalRunType](docs/GETJournalRunType.md)
 - [Model.GETMassUpdateType](docs/GETMassUpdateType.md)
 - [Model.GETOpenPaymentMethodTypeRevisionResponse](docs/GETOpenPaymentMethodTypeRevisionResponse.md)
 - [Model.GETPMAccountHolderInfo](docs/GETPMAccountHolderInfo.md)
 - [Model.GETPaidInvoicesType](docs/GETPaidInvoicesType.md)
 - [Model.GETPaymentGatewayTransactionLogElementResponse](docs/GETPaymentGatewayTransactionLogElementResponse.md)
 - [Model.GETPaymentGatewayTransactionLogResponse](docs/GETPaymentGatewayTransactionLogResponse.md)
 - [Model.GETPaymentGatwaysResponse](docs/GETPaymentGatwaysResponse.md)
 - [Model.GETPaymentItemPartCollectionType](docs/GETPaymentItemPartCollectionType.md)
 - [Model.GETPaymentItemPartType](docs/GETPaymentItemPartType.md)
 - [Model.GETPaymentItemPartTypewithSuccess](docs/GETPaymentItemPartTypewithSuccess.md)
 - [Model.GETPaymentMethodResponse](docs/GETPaymentMethodResponse.md)
 - [Model.GETPaymentMethodResponseACH](docs/GETPaymentMethodResponseACH.md)
 - [Model.GETPaymentMethodResponseACHForAccount](docs/GETPaymentMethodResponseACHForAccount.md)
 - [Model.GETPaymentMethodResponseAllOf](docs/GETPaymentMethodResponseAllOf.md)
 - [Model.GETPaymentMethodResponseBankTransfer](docs/GETPaymentMethodResponseBankTransfer.md)
 - [Model.GETPaymentMethodResponseBankTransferForAccount](docs/GETPaymentMethodResponseBankTransferForAccount.md)
 - [Model.GETPaymentMethodResponseCreditCard](docs/GETPaymentMethodResponseCreditCard.md)
 - [Model.GETPaymentMethodResponseCreditCardForAccount](docs/GETPaymentMethodResponseCreditCardForAccount.md)
 - [Model.GETPaymentMethodResponseForAccount](docs/GETPaymentMethodResponseForAccount.md)
 - [Model.GETPaymentMethodResponsePayPal](docs/GETPaymentMethodResponsePayPal.md)
 - [Model.GETPaymentMethodResponsePayPalForAccount](docs/GETPaymentMethodResponsePayPalForAccount.md)
 - [Model.GETPaymentMethodType](docs/GETPaymentMethodType.md)
 - [Model.GETPaymentMethodTypeCardHolderInfo](docs/GETPaymentMethodTypeCardHolderInfo.md)
 - [Model.GETPaymentMethodsType](docs/GETPaymentMethodsType.md)
 - [Model.GETPaymentPartType](docs/GETPaymentPartType.md)
 - [Model.GETPaymentPartTypewithSuccess](docs/GETPaymentPartTypewithSuccess.md)
 - [Model.GETPaymentPartsCollectionType](docs/GETPaymentPartsCollectionType.md)
 - [Model.GETPaymentRunCollectionType](docs/GETPaymentRunCollectionType.md)
 - [Model.GETPaymentRunDataArrayResponse](docs/GETPaymentRunDataArrayResponse.md)
 - [Model.GETPaymentRunDataElementResponse](docs/GETPaymentRunDataElementResponse.md)
 - [Model.GETPaymentRunDataTransactionElementResponse](docs/GETPaymentRunDataTransactionElementResponse.md)
 - [Model.GETPaymentRunSummaryResponse](docs/GETPaymentRunSummaryResponse.md)
 - [Model.GETPaymentRunSummaryTotalValues](docs/GETPaymentRunSummaryTotalValues.md)
 - [Model.GETPaymentRunType](docs/GETPaymentRunType.md)
 - [Model.GETPaymentScheduleItemResponse](docs/GETPaymentScheduleItemResponse.md)
 - [Model.GETPaymentScheduleItemResponseAllOf](docs/GETPaymentScheduleItemResponseAllOf.md)
 - [Model.GETPaymentScheduleItemResponseAllOfBillingDocument](docs/GETPaymentScheduleItemResponseAllOfBillingDocument.md)
 - [Model.GETPaymentScheduleResponse](docs/GETPaymentScheduleResponse.md)
 - [Model.GETPaymentScheduleResponseAllOf](docs/GETPaymentScheduleResponseAllOf.md)
 - [Model.GETPaymentScheduleStatisticResponse](docs/GETPaymentScheduleStatisticResponse.md)
 - [Model.GETPaymentScheduleStatisticResponsePaymentScheduleItems](docs/GETPaymentScheduleStatisticResponsePaymentScheduleItems.md)
 - [Model.GETPaymentType](docs/GETPaymentType.md)
 - [Model.GETPaymentTypeAllOf](docs/GETPaymentTypeAllOf.md)
 - [Model.GETPaymentsType](docs/GETPaymentsType.md)
 - [Model.GETProductDiscountApplyDetailsType](docs/GETProductDiscountApplyDetailsType.md)
 - [Model.GETProductRatePlanChargePricingTierType](docs/GETProductRatePlanChargePricingTierType.md)
 - [Model.GETProductRatePlanChargePricingType](docs/GETProductRatePlanChargePricingType.md)
 - [Model.GETProductRatePlanChargeType](docs/GETProductRatePlanChargeType.md)
 - [Model.GETProductRatePlanChargeTypeAllOf](docs/GETProductRatePlanChargeTypeAllOf.md)
 - [Model.GETProductRatePlanType](docs/GETProductRatePlanType.md)
 - [Model.GETProductRatePlanTypeAllOf](docs/GETProductRatePlanTypeAllOf.md)
 - [Model.GETProductRatePlanWithExternalIdMultiResponseInner](docs/GETProductRatePlanWithExternalIdMultiResponseInner.md)
 - [Model.GETProductRatePlanWithExternalIdResponse](docs/GETProductRatePlanWithExternalIdResponse.md)
 - [Model.GETProductRatePlansResponse](docs/GETProductRatePlansResponse.md)
 - [Model.GETProductType](docs/GETProductType.md)
 - [Model.GETProductTypeAllOf](docs/GETProductTypeAllOf.md)
 - [Model.GETPublicEmailTemplateResponse](docs/GETPublicEmailTemplateResponse.md)
 - [Model.GETPublicNotificationDefinitionResponse](docs/GETPublicNotificationDefinitionResponse.md)
 - [Model.GETPublicNotificationDefinitionResponseCallout](docs/GETPublicNotificationDefinitionResponseCallout.md)
 - [Model.GETPublicNotificationDefinitionResponseFilterRule](docs/GETPublicNotificationDefinitionResponseFilterRule.md)
 - [Model.GETQueryEmailTemplates200Response](docs/GETQueryEmailTemplates200Response.md)
 - [Model.GETQueryNotificationDefinitions200Response](docs/GETQueryNotificationDefinitions200Response.md)
 - [Model.GETRSDetailForProductChargeType](docs/GETRSDetailForProductChargeType.md)
 - [Model.GETRSDetailForProductChargeTypeAllOf](docs/GETRSDetailForProductChargeTypeAllOf.md)
 - [Model.GETRSDetailType](docs/GETRSDetailType.md)
 - [Model.GETRSDetailTypeAllOf](docs/GETRSDetailTypeAllOf.md)
 - [Model.GETRSDetailWithoutSuccessType](docs/GETRSDetailWithoutSuccessType.md)
 - [Model.GETRSDetailWithoutSuccessTypeAllOf](docs/GETRSDetailWithoutSuccessTypeAllOf.md)
 - [Model.GETRSDetailsByChargeType](docs/GETRSDetailsByChargeType.md)
 - [Model.GETRSDetailsByProductChargeType](docs/GETRSDetailsByProductChargeType.md)
 - [Model.GETRampByRampNumberResponseType](docs/GETRampByRampNumberResponseType.md)
 - [Model.GETRampByRampNumberResponseTypeAllOf](docs/GETRampByRampNumberResponseTypeAllOf.md)
 - [Model.GETRampMetricsByOrderNumberResponseType](docs/GETRampMetricsByOrderNumberResponseType.md)
 - [Model.GETRampMetricsByOrderNumberResponseTypeAllOf](docs/GETRampMetricsByOrderNumberResponseTypeAllOf.md)
 - [Model.GETRampMetricsByRampNumberResponseType](docs/GETRampMetricsByRampNumberResponseType.md)
 - [Model.GETRampMetricsByRampNumberResponseTypeAllOf](docs/GETRampMetricsByRampNumberResponseTypeAllOf.md)
 - [Model.GETRampMetricsBySubscriptionKeyResponseType](docs/GETRampMetricsBySubscriptionKeyResponseType.md)
 - [Model.GETRampsBySubscriptionKeyResponseType](docs/GETRampsBySubscriptionKeyResponseType.md)
 - [Model.GETRampsBySubscriptionKeyResponseTypeAllOf](docs/GETRampsBySubscriptionKeyResponseTypeAllOf.md)
 - [Model.GETRefundCollectionType](docs/GETRefundCollectionType.md)
 - [Model.GETRefundCreditMemoType](docs/GETRefundCreditMemoType.md)
 - [Model.GETRefundCreditMemoTypeAllOf](docs/GETRefundCreditMemoTypeAllOf.md)
 - [Model.GETRefundCreditMemoTypeAllOfFinanceInformation](docs/GETRefundCreditMemoTypeAllOfFinanceInformation.md)
 - [Model.GETRefundItemPartCollectionType](docs/GETRefundItemPartCollectionType.md)
 - [Model.GETRefundItemPartType](docs/GETRefundItemPartType.md)
 - [Model.GETRefundItemPartTypewithSuccess](docs/GETRefundItemPartTypewithSuccess.md)
 - [Model.GETRefundPartCollectionType](docs/GETRefundPartCollectionType.md)
 - [Model.GETRefundPaymentType](docs/GETRefundPaymentType.md)
 - [Model.GETRefundPaymentTypeAllOf](docs/GETRefundPaymentTypeAllOf.md)
 - [Model.GETRefundType](docs/GETRefundType.md)
 - [Model.GETRefundTypeAllOf](docs/GETRefundTypeAllOf.md)
 - [Model.GETRefundTypewithSuccess](docs/GETRefundTypewithSuccess.md)
 - [Model.GETRefundTypewithSuccessAllOf](docs/GETRefundTypewithSuccessAllOf.md)
 - [Model.GETRevenueEventDetailType](docs/GETRevenueEventDetailType.md)
 - [Model.GETRevenueEventDetailTypeAllOf](docs/GETRevenueEventDetailTypeAllOf.md)
 - [Model.GETRevenueEventDetailWithoutSuccessType](docs/GETRevenueEventDetailWithoutSuccessType.md)
 - [Model.GETRevenueEventDetailWithoutSuccessTypeAllOf](docs/GETRevenueEventDetailWithoutSuccessTypeAllOf.md)
 - [Model.GETRevenueEventDetailsType](docs/GETRevenueEventDetailsType.md)
 - [Model.GETRevenueItemType](docs/GETRevenueItemType.md)
 - [Model.GETRevenueItemTypeAllOf](docs/GETRevenueItemTypeAllOf.md)
 - [Model.GETRevenueItemTypeResponse](docs/GETRevenueItemTypeResponse.md)
 - [Model.GETRevenueItemsType](docs/GETRevenueItemsType.md)
 - [Model.GETRevenueRecognitionRuleAssociationType](docs/GETRevenueRecognitionRuleAssociationType.md)
 - [Model.GETRevenueStartDateSettingType](docs/GETRevenueStartDateSettingType.md)
 - [Model.GETRsRevenueItemType](docs/GETRsRevenueItemType.md)
 - [Model.GETRsRevenueItemTypeAllOf](docs/GETRsRevenueItemTypeAllOf.md)
 - [Model.GETRsRevenueItemsType](docs/GETRsRevenueItemsType.md)
 - [Model.GETScheduledEvents200Response](docs/GETScheduledEvents200Response.md)
 - [Model.GETSequenceSetResponse](docs/GETSequenceSetResponse.md)
 - [Model.GETSequenceSetsResponse](docs/GETSequenceSetsResponse.md)
 - [Model.GETSubscriptionProductFeatureType](docs/GETSubscriptionProductFeatureType.md)
 - [Model.GETSubscriptionRatePlanChargesType](docs/GETSubscriptionRatePlanChargesType.md)
 - [Model.GETSubscriptionRatePlanChargesTypeAllOf](docs/GETSubscriptionRatePlanChargesTypeAllOf.md)
 - [Model.GETSubscriptionRatePlanType](docs/GETSubscriptionRatePlanType.md)
 - [Model.GETSubscriptionRatePlanTypeAllOf](docs/GETSubscriptionRatePlanTypeAllOf.md)
 - [Model.GETSubscriptionType](docs/GETSubscriptionType.md)
 - [Model.GETSubscriptionTypeAllOf](docs/GETSubscriptionTypeAllOf.md)
 - [Model.GETSubscriptionTypeWithSuccess](docs/GETSubscriptionTypeWithSuccess.md)
 - [Model.GETSubscriptionTypeWithSuccessAllOf](docs/GETSubscriptionTypeWithSuccessAllOf.md)
 - [Model.GETSubscriptionWrapper](docs/GETSubscriptionWrapper.md)
 - [Model.GETTaxationItemListType](docs/GETTaxationItemListType.md)
 - [Model.GETTaxationItemType](docs/GETTaxationItemType.md)
 - [Model.GETTaxationItemTypeAllOf](docs/GETTaxationItemTypeAllOf.md)
 - [Model.GETTaxationItemTypewithSuccess](docs/GETTaxationItemTypewithSuccess.md)
 - [Model.GETTaxationItemTypewithSuccessAllOf](docs/GETTaxationItemTypewithSuccessAllOf.md)
 - [Model.GETTaxationItemsOfCreditMemoItemType](docs/GETTaxationItemsOfCreditMemoItemType.md)
 - [Model.GETTaxationItemsOfCreditMemoItemTypeAllOf](docs/GETTaxationItemsOfCreditMemoItemTypeAllOf.md)
 - [Model.GETTaxationItemsOfDebitMemoItemType](docs/GETTaxationItemsOfDebitMemoItemType.md)
 - [Model.GETTaxationItemsOfDebitMemoItemTypeAllOf](docs/GETTaxationItemsOfDebitMemoItemTypeAllOf.md)
 - [Model.GETTierType](docs/GETTierType.md)
 - [Model.GETUsageRateDetailWrapper](docs/GETUsageRateDetailWrapper.md)
 - [Model.GETUsageRateDetailWrapperData](docs/GETUsageRateDetailWrapperData.md)
 - [Model.GETUsageType](docs/GETUsageType.md)
 - [Model.GETUsageTypeAllOf](docs/GETUsageTypeAllOf.md)
 - [Model.GETUsageWrapper](docs/GETUsageWrapper.md)
 - [Model.GatewayOption](docs/GatewayOption.md)
 - [Model.GenerateBillingDocumentResponseType](docs/GenerateBillingDocumentResponseType.md)
 - [Model.GetAllOrdersResponseType](docs/GetAllOrdersResponseType.md)
 - [Model.GetBillingPreviewRunResponse](docs/GetBillingPreviewRunResponse.md)
 - [Model.GetCustomObjectsAllNamespacesResponse](docs/GetCustomObjectsAllNamespacesResponse.md)
 - [Model.GetDataQueryJobResponse](docs/GetDataQueryJobResponse.md)
 - [Model.GetDataQueryJobsResponse](docs/GetDataQueryJobsResponse.md)
 - [Model.GetDebitMemoApplicationPartCollectionType](docs/GetDebitMemoApplicationPartCollectionType.md)
 - [Model.GetDebitMemoApplicationPartType](docs/GetDebitMemoApplicationPartType.md)
 - [Model.GetHostedPageType](docs/GetHostedPageType.md)
 - [Model.GetHostedPagesType](docs/GetHostedPagesType.md)
 - [Model.GetInvoiceApplicationPartCollectionType](docs/GetInvoiceApplicationPartCollectionType.md)
 - [Model.GetInvoiceApplicationPartType](docs/GetInvoiceApplicationPartType.md)
 - [Model.GetOrderActionRatePlanResponse](docs/GetOrderActionRatePlanResponse.md)
 - [Model.GetOrderActionRatePlanResponseAllOf](docs/GetOrderActionRatePlanResponseAllOf.md)
 - [Model.GetOrderLineItemResponseType](docs/GetOrderLineItemResponseType.md)
 - [Model.GetOrderLineItemResponseTypeAllOf](docs/GetOrderLineItemResponseTypeAllOf.md)
 - [Model.GetOrderResponse](docs/GetOrderResponse.md)
 - [Model.GetOrderResponseAllOf](docs/GetOrderResponseAllOf.md)
 - [Model.GetOrderResponseForEvergreen](docs/GetOrderResponseForEvergreen.md)
 - [Model.GetOrderResponseForEvergreenAllOf](docs/GetOrderResponseForEvergreenAllOf.md)
 - [Model.GetOrderResume](docs/GetOrderResume.md)
 - [Model.GetOrderSuspend](docs/GetOrderSuspend.md)
 - [Model.GetOrdersResponse](docs/GetOrdersResponse.md)
 - [Model.GetOrdersResponseAllOf](docs/GetOrdersResponseAllOf.md)
 - [Model.GetProductFeatureType](docs/GetProductFeatureType.md)
 - [Model.GetProductFeatureTypeAllOf](docs/GetProductFeatureTypeAllOf.md)
 - [Model.GetScheduledEventResponse](docs/GetScheduledEventResponse.md)
 - [Model.GetScheduledEventResponseParametersValue](docs/GetScheduledEventResponseParametersValue.md)
 - [Model.GetStoredCredentialProfilesResponse](docs/GetStoredCredentialProfilesResponse.md)
 - [Model.GetStoredCredentialProfilesResponseProfiles](docs/GetStoredCredentialProfilesResponseProfiles.md)
 - [Model.GetSubscriptionTermInfoResponseType](docs/GetSubscriptionTermInfoResponseType.md)
 - [Model.GetSubscriptionTermInfoResponseTypeAllOf](docs/GetSubscriptionTermInfoResponseTypeAllOf.md)
 - [Model.GetVersionsResponse](docs/GetVersionsResponse.md)
 - [Model.GetWorkflowResponse](docs/GetWorkflowResponse.md)
 - [Model.GetWorkflowResponseTasks](docs/GetWorkflowResponseTasks.md)
 - [Model.GetWorkflowSetupResponse](docs/GetWorkflowSetupResponse.md)
 - [Model.GetWorkflowsResponse](docs/GetWorkflowsResponse.md)
 - [Model.GetWorkflowsResponsePagination](docs/GetWorkflowsResponsePagination.md)
 - [Model.InitialTerm](docs/InitialTerm.md)
 - [Model.Invoice](docs/Invoice.md)
 - [Model.InvoiceDataInvoice](docs/InvoiceDataInvoice.md)
 - [Model.InvoiceDataInvoiceAllOf](docs/InvoiceDataInvoiceAllOf.md)
 - [Model.InvoiceEntityPrefix](docs/InvoiceEntityPrefix.md)
 - [Model.InvoiceFile](docs/InvoiceFile.md)
 - [Model.InvoiceItem](docs/InvoiceItem.md)
 - [Model.InvoiceItemAdjustmentObjectNSFields](docs/InvoiceItemAdjustmentObjectNSFields.md)
 - [Model.InvoiceItemAllOf](docs/InvoiceItemAllOf.md)
 - [Model.InvoiceItemAllOfTaxationItems](docs/InvoiceItemAllOfTaxationItems.md)
 - [Model.InvoiceItemObjectNSFields](docs/InvoiceItemObjectNSFields.md)
 - [Model.InvoiceItemPreviewResult](docs/InvoiceItemPreviewResult.md)
 - [Model.InvoiceItemPreviewResultAdditionalInfo](docs/InvoiceItemPreviewResultAdditionalInfo.md)
 - [Model.InvoiceItemPreviewResultTaxationItemsInner](docs/InvoiceItemPreviewResultTaxationItemsInner.md)
 - [Model.InvoiceItems](docs/InvoiceItems.md)
 - [Model.InvoiceItems1](docs/InvoiceItems1.md)
 - [Model.InvoiceItems2](docs/InvoiceItems2.md)
 - [Model.InvoiceObjectNSFields](docs/InvoiceObjectNSFields.md)
 - [Model.InvoicePayment](docs/InvoicePayment.md)
 - [Model.InvoicePaymentData](docs/InvoicePaymentData.md)
 - [Model.InvoicePostResponseType](docs/InvoicePostResponseType.md)
 - [Model.InvoicePostResponseTypeAllOf](docs/InvoicePostResponseTypeAllOf.md)
 - [Model.InvoicePostType](docs/InvoicePostType.md)
 - [Model.InvoicePostTypeAllOf](docs/InvoicePostTypeAllOf.md)
 - [Model.InvoiceProcessingOptions](docs/InvoiceProcessingOptions.md)
 - [Model.InvoiceResponseType](docs/InvoiceResponseType.md)
 - [Model.Invoices](docs/Invoices.md)
 - [Model.InvoicesBatchPostResponseType](docs/InvoicesBatchPostResponseType.md)
 - [Model.InvoicesBatchPostResponseTypeAllOf](docs/InvoicesBatchPostResponseTypeAllOf.md)
 - [Model.JobResult](docs/JobResult.md)
 - [Model.JobResultAllOf](docs/JobResultAllOf.md)
 - [Model.JobResultAllOfOrderLineItems](docs/JobResultAllOfOrderLineItems.md)
 - [Model.JobResultAllOfRamps](docs/JobResultAllOfRamps.md)
 - [Model.JobResultAllOfSubscriptions](docs/JobResultAllOfSubscriptions.md)
 - [Model.LastTerm](docs/LastTerm.md)
 - [Model.Linkage](docs/Linkage.md)
 - [Model.ListAllCatalogGroupsResponse](docs/ListAllCatalogGroupsResponse.md)
 - [Model.ListAllSettingsResponse](docs/ListAllSettingsResponse.md)
 - [Model.ListOfExchangeRates](docs/ListOfExchangeRates.md)
 - [Model.MigrationUpdateCustomObjectDefinitionsRequest](docs/MigrationUpdateCustomObjectDefinitionsRequest.md)
 - [Model.MigrationUpdateCustomObjectDefinitionsResponse](docs/MigrationUpdateCustomObjectDefinitionsResponse.md)
 - [Model.ModifiedStoredCredentialProfileResponse](docs/ModifiedStoredCredentialProfileResponse.md)
 - [Model.NewChargeMetrics](docs/NewChargeMetrics.md)
 - [Model.NotificationsHistoryDeletionTaskResponse](docs/NotificationsHistoryDeletionTaskResponse.md)
 - [Model.OneTimeFlatFeePricingOverride](docs/OneTimeFlatFeePricingOverride.md)
 - [Model.OneTimePerUnitPricingOverride](docs/OneTimePerUnitPricingOverride.md)
 - [Model.OneTimeTieredPricingOverride](docs/OneTimeTieredPricingOverride.md)
 - [Model.OneTimeVolumePricingOverride](docs/OneTimeVolumePricingOverride.md)
 - [Model.OpenPaymentMethodTypeRequestFields](docs/OpenPaymentMethodTypeRequestFields.md)
 - [Model.OpenPaymentMethodTypeResponseFields](docs/OpenPaymentMethodTypeResponseFields.md)
 - [Model.Order](docs/Order.md)
 - [Model.OrderAction](docs/OrderAction.md)
 - [Model.OrderActionForEvergreen](docs/OrderActionForEvergreen.md)
 - [Model.OrderActionRatePlanAmendment](docs/OrderActionRatePlanAmendment.md)
 - [Model.OrderActionRatePlanBillingUpdate](docs/OrderActionRatePlanBillingUpdate.md)
 - [Model.OrderActionRatePlanChargeModelDataOverride](docs/OrderActionRatePlanChargeModelDataOverride.md)
 - [Model.OrderActionRatePlanChargeModelDataOverrideChargeModelConfiguration](docs/OrderActionRatePlanChargeModelDataOverrideChargeModelConfiguration.md)
 - [Model.OrderActionRatePlanChargeOverride](docs/OrderActionRatePlanChargeOverride.md)
 - [Model.OrderActionRatePlanChargeOverridePricing](docs/OrderActionRatePlanChargeOverridePricing.md)
 - [Model.OrderActionRatePlanChargeTier](docs/OrderActionRatePlanChargeTier.md)
 - [Model.OrderActionRatePlanChargeUpdate](docs/OrderActionRatePlanChargeUpdate.md)
 - [Model.OrderActionRatePlanDiscountPricingOverride](docs/OrderActionRatePlanDiscountPricingOverride.md)
 - [Model.OrderActionRatePlanDiscountPricingUpdate](docs/OrderActionRatePlanDiscountPricingUpdate.md)
 - [Model.OrderActionRatePlanEndConditions](docs/OrderActionRatePlanEndConditions.md)
 - [Model.OrderActionRatePlanOneTimeFlatFeePricingOverride](docs/OrderActionRatePlanOneTimeFlatFeePricingOverride.md)
 - [Model.OrderActionRatePlanOneTimePerUnitPricingOverride](docs/OrderActionRatePlanOneTimePerUnitPricingOverride.md)
 - [Model.OrderActionRatePlanOneTimeTieredPricingOverride](docs/OrderActionRatePlanOneTimeTieredPricingOverride.md)
 - [Model.OrderActionRatePlanOneTimeVolumePricingOverride](docs/OrderActionRatePlanOneTimeVolumePricingOverride.md)
 - [Model.OrderActionRatePlanOrder](docs/OrderActionRatePlanOrder.md)
 - [Model.OrderActionRatePlanOrderAction](docs/OrderActionRatePlanOrderAction.md)
 - [Model.OrderActionRatePlanPriceChangeParams](docs/OrderActionRatePlanPriceChangeParams.md)
 - [Model.OrderActionRatePlanPricingUpdate](docs/OrderActionRatePlanPricingUpdate.md)
 - [Model.OrderActionRatePlanRatePlanOverride](docs/OrderActionRatePlanRatePlanOverride.md)
 - [Model.OrderActionRatePlanRatePlanUpdate](docs/OrderActionRatePlanRatePlanUpdate.md)
 - [Model.OrderActionRatePlanRecurringFlatFeePricingOverride](docs/OrderActionRatePlanRecurringFlatFeePricingOverride.md)
 - [Model.OrderActionRatePlanRecurringFlatFeePricingOverrideAllOf](docs/OrderActionRatePlanRecurringFlatFeePricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanRecurringFlatFeePricingUpdate](docs/OrderActionRatePlanRecurringFlatFeePricingUpdate.md)
 - [Model.OrderActionRatePlanRecurringFlatFeePricingUpdateAllOf](docs/OrderActionRatePlanRecurringFlatFeePricingUpdateAllOf.md)
 - [Model.OrderActionRatePlanRecurringPerUnitPricingOverride](docs/OrderActionRatePlanRecurringPerUnitPricingOverride.md)
 - [Model.OrderActionRatePlanRecurringPerUnitPricingOverrideAllOf](docs/OrderActionRatePlanRecurringPerUnitPricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanRecurringPerUnitPricingUpdate](docs/OrderActionRatePlanRecurringPerUnitPricingUpdate.md)
 - [Model.OrderActionRatePlanRecurringPerUnitPricingUpdateAllOf](docs/OrderActionRatePlanRecurringPerUnitPricingUpdateAllOf.md)
 - [Model.OrderActionRatePlanRecurringTieredPricingOverride](docs/OrderActionRatePlanRecurringTieredPricingOverride.md)
 - [Model.OrderActionRatePlanRecurringTieredPricingOverrideAllOf](docs/OrderActionRatePlanRecurringTieredPricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanRecurringTieredPricingUpdate](docs/OrderActionRatePlanRecurringTieredPricingUpdate.md)
 - [Model.OrderActionRatePlanRecurringTieredPricingUpdateAllOf](docs/OrderActionRatePlanRecurringTieredPricingUpdateAllOf.md)
 - [Model.OrderActionRatePlanRecurringVolumePricingOverride](docs/OrderActionRatePlanRecurringVolumePricingOverride.md)
 - [Model.OrderActionRatePlanRecurringVolumePricingOverrideAllOf](docs/OrderActionRatePlanRecurringVolumePricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanRecurringVolumePricingUpdate](docs/OrderActionRatePlanRecurringVolumePricingUpdate.md)
 - [Model.OrderActionRatePlanRemoveProduct](docs/OrderActionRatePlanRemoveProduct.md)
 - [Model.OrderActionRatePlanTriggerParams](docs/OrderActionRatePlanTriggerParams.md)
 - [Model.OrderActionRatePlanUsageFlatFeePricingOverride](docs/OrderActionRatePlanUsageFlatFeePricingOverride.md)
 - [Model.OrderActionRatePlanUsageFlatFeePricingOverrideAllOf](docs/OrderActionRatePlanUsageFlatFeePricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanUsageFlatFeePricingUpdate](docs/OrderActionRatePlanUsageFlatFeePricingUpdate.md)
 - [Model.OrderActionRatePlanUsageOveragePricingOverride](docs/OrderActionRatePlanUsageOveragePricingOverride.md)
 - [Model.OrderActionRatePlanUsageOveragePricingOverrideAllOf](docs/OrderActionRatePlanUsageOveragePricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanUsageOveragePricingUpdate](docs/OrderActionRatePlanUsageOveragePricingUpdate.md)
 - [Model.OrderActionRatePlanUsageOveragePricingUpdateAllOf](docs/OrderActionRatePlanUsageOveragePricingUpdateAllOf.md)
 - [Model.OrderActionRatePlanUsagePerUnitPricingOverride](docs/OrderActionRatePlanUsagePerUnitPricingOverride.md)
 - [Model.OrderActionRatePlanUsagePerUnitPricingOverrideAllOf](docs/OrderActionRatePlanUsagePerUnitPricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanUsagePerUnitPricingUpdate](docs/OrderActionRatePlanUsagePerUnitPricingUpdate.md)
 - [Model.OrderActionRatePlanUsageTieredPricingOverride](docs/OrderActionRatePlanUsageTieredPricingOverride.md)
 - [Model.OrderActionRatePlanUsageTieredPricingOverrideAllOf](docs/OrderActionRatePlanUsageTieredPricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanUsageTieredPricingUpdate](docs/OrderActionRatePlanUsageTieredPricingUpdate.md)
 - [Model.OrderActionRatePlanUsageTieredPricingUpdateAllOf](docs/OrderActionRatePlanUsageTieredPricingUpdateAllOf.md)
 - [Model.OrderActionRatePlanUsageTieredWithOveragePricingOverride](docs/OrderActionRatePlanUsageTieredWithOveragePricingOverride.md)
 - [Model.OrderActionRatePlanUsageTieredWithOveragePricingOverrideAllOf](docs/OrderActionRatePlanUsageTieredWithOveragePricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanUsageTieredWithOveragePricingUpdate](docs/OrderActionRatePlanUsageTieredWithOveragePricingUpdate.md)
 - [Model.OrderActionRatePlanUsageTieredWithOveragePricingUpdateAllOf](docs/OrderActionRatePlanUsageTieredWithOveragePricingUpdateAllOf.md)
 - [Model.OrderActionRatePlanUsageVolumePricingOverride](docs/OrderActionRatePlanUsageVolumePricingOverride.md)
 - [Model.OrderActionRatePlanUsageVolumePricingOverrideAllOf](docs/OrderActionRatePlanUsageVolumePricingOverrideAllOf.md)
 - [Model.OrderActionRatePlanUsageVolumePricingUpdate](docs/OrderActionRatePlanUsageVolumePricingUpdate.md)
 - [Model.OrderDeltaMetric](docs/OrderDeltaMetric.md)
 - [Model.OrderDeltaMrr](docs/OrderDeltaMrr.md)
 - [Model.OrderDeltaTcb](docs/OrderDeltaTcb.md)
 - [Model.OrderDeltaTcbAllOf](docs/OrderDeltaTcbAllOf.md)
 - [Model.OrderDeltaTcv](docs/OrderDeltaTcv.md)
 - [Model.OrderDeltaTcvAllOf](docs/OrderDeltaTcvAllOf.md)
 - [Model.OrderForEvergreen](docs/OrderForEvergreen.md)
 - [Model.OrderForEvergreenSubscriptionsInner](docs/OrderForEvergreenSubscriptionsInner.md)
 - [Model.OrderItem](docs/OrderItem.md)
 - [Model.OrderLineItem](docs/OrderLineItem.md)
 - [Model.OrderLineItemAllOf](docs/OrderLineItemAllOf.md)
 - [Model.OrderLineItemCommon](docs/OrderLineItemCommon.md)
 - [Model.OrderLineItemCommonPostOrder](docs/OrderLineItemCommonPostOrder.md)
 - [Model.OrderLineItemCommonRetrieveOrder](docs/OrderLineItemCommonRetrieveOrder.md)
 - [Model.OrderLineItemCommonRetrieveOrderLineItem](docs/OrderLineItemCommonRetrieveOrderLineItem.md)
 - [Model.OrderLineItemRetrieveOrder](docs/OrderLineItemRetrieveOrder.md)
 - [Model.OrderLineItemRetrieveOrderAllOf](docs/OrderLineItemRetrieveOrderAllOf.md)
 - [Model.OrderMetric](docs/OrderMetric.md)
 - [Model.OrderMetricsForEvergreen](docs/OrderMetricsForEvergreen.md)
 - [Model.OrderRampIntervalMetrics](docs/OrderRampIntervalMetrics.md)
 - [Model.OrderRampMetrics](docs/OrderRampMetrics.md)
 - [Model.OrderSubscriptionsInner](docs/OrderSubscriptionsInner.md)
 - [Model.OwnerTransfer](docs/OwnerTransfer.md)
 - [Model.PATCHUpdateWorkflowRequest](docs/PATCHUpdateWorkflowRequest.md)
 - [Model.POSTAccountResponseType](docs/POSTAccountResponseType.md)
 - [Model.POSTAccountType](docs/POSTAccountType.md)
 - [Model.POSTAccountTypeAllOf](docs/POSTAccountTypeAllOf.md)
 - [Model.POSTAccountTypeAllOfTaxInfo](docs/POSTAccountTypeAllOfTaxInfo.md)
 - [Model.POSTAccountTypeBillToContact](docs/POSTAccountTypeBillToContact.md)
 - [Model.POSTAccountTypeBillToContactAllOf](docs/POSTAccountTypeBillToContactAllOf.md)
 - [Model.POSTAccountTypeCreditCard](docs/POSTAccountTypeCreditCard.md)
 - [Model.POSTAccountTypeCreditCardAllOf](docs/POSTAccountTypeCreditCardAllOf.md)
 - [Model.POSTAccountTypeCreditCardAllOfCardHolderInfo](docs/POSTAccountTypeCreditCardAllOfCardHolderInfo.md)
 - [Model.POSTAccountTypePaymentMethod](docs/POSTAccountTypePaymentMethod.md)
 - [Model.POSTAccountTypePaymentMethodAllOf](docs/POSTAccountTypePaymentMethodAllOf.md)
 - [Model.POSTAccountTypeSoldToContact](docs/POSTAccountTypeSoldToContact.md)
 - [Model.POSTAccountTypeSoldToContactAllOf](docs/POSTAccountTypeSoldToContactAllOf.md)
 - [Model.POSTAccountTypeSubscription](docs/POSTAccountTypeSubscription.md)
 - [Model.POSTAccountTypeSubscriptionAllOf](docs/POSTAccountTypeSubscriptionAllOf.md)
 - [Model.POSTAccountingCodeResponseType](docs/POSTAccountingCodeResponseType.md)
 - [Model.POSTAccountingCodeType](docs/POSTAccountingCodeType.md)
 - [Model.POSTAccountingCodeTypeAllOf](docs/POSTAccountingCodeTypeAllOf.md)
 - [Model.POSTAccountingPeriodResponseType](docs/POSTAccountingPeriodResponseType.md)
 - [Model.POSTAccountingPeriodType](docs/POSTAccountingPeriodType.md)
 - [Model.POSTAccountingPeriodTypeAllOf](docs/POSTAccountingPeriodTypeAllOf.md)
 - [Model.POSTAddItemsToPaymentScheduleRequest](docs/POSTAddItemsToPaymentScheduleRequest.md)
 - [Model.POSTAttachmentResponseType](docs/POSTAttachmentResponseType.md)
 - [Model.POSTAuthorizeResponse](docs/POSTAuthorizeResponse.md)
 - [Model.POSTBillingDocumentFilesDeletionJobRequest](docs/POSTBillingDocumentFilesDeletionJobRequest.md)
 - [Model.POSTBillingDocumentFilesDeletionJobResponse](docs/POSTBillingDocumentFilesDeletionJobResponse.md)
 - [Model.POSTBillingPreviewCreditMemoItem](docs/POSTBillingPreviewCreditMemoItem.md)
 - [Model.POSTBillingPreviewInvoiceItem](docs/POSTBillingPreviewInvoiceItem.md)
 - [Model.POSTBillingPreviewRun200Response](docs/POSTBillingPreviewRun200Response.md)
 - [Model.POSTBulkCreditMemoFromInvoiceType](docs/POSTBulkCreditMemoFromInvoiceType.md)
 - [Model.POSTBulkCreditMemoFromInvoiceTypeAllOf](docs/POSTBulkCreditMemoFromInvoiceTypeAllOf.md)
 - [Model.POSTBulkCreditMemosRequestType](docs/POSTBulkCreditMemosRequestType.md)
 - [Model.POSTBulkDebitMemoFromInvoiceType](docs/POSTBulkDebitMemoFromInvoiceType.md)
 - [Model.POSTBulkDebitMemoFromInvoiceTypeAllOf](docs/POSTBulkDebitMemoFromInvoiceTypeAllOf.md)
 - [Model.POSTBulkDebitMemosRequestType](docs/POSTBulkDebitMemosRequestType.md)
 - [Model.POSTCatalogGroupRequest](docs/POSTCatalogGroupRequest.md)
 - [Model.POSTCatalogGroupRequestAllOf](docs/POSTCatalogGroupRequestAllOf.md)
 - [Model.POSTCatalogType](docs/POSTCatalogType.md)
 - [Model.POSTCmiRevenueScheduleByTransactionType](docs/POSTCmiRevenueScheduleByTransactionType.md)
 - [Model.POSTCmiRevenueScheduleByTransactionTypeAllOf](docs/POSTCmiRevenueScheduleByTransactionTypeAllOf.md)
 - [Model.POSTCreateOpenPaymentMethodTypeRequest](docs/POSTCreateOpenPaymentMethodTypeRequest.md)
 - [Model.POSTCreateOpenPaymentMethodTypeResponse](docs/POSTCreateOpenPaymentMethodTypeResponse.md)
 - [Model.POSTCreateOrUpdateEmailTemplateRequest](docs/POSTCreateOrUpdateEmailTemplateRequest.md)
 - [Model.POSTCreateOrUpdateEmailTemplateRequestFormat](docs/POSTCreateOrUpdateEmailTemplateRequestFormat.md)
 - [Model.POSTCreateOrderAsynchronously202Response](docs/POSTCreateOrderAsynchronously202Response.md)
 - [Model.POSTDecryptResponseType](docs/POSTDecryptResponseType.md)
 - [Model.POSTDecryptionType](docs/POSTDecryptionType.md)
 - [Model.POSTDelayAuthorizeCapture](docs/POSTDelayAuthorizeCapture.md)
 - [Model.POSTDistributionItemType](docs/POSTDistributionItemType.md)
 - [Model.POSTDmiRevenueScheduleByTransactionType](docs/POSTDmiRevenueScheduleByTransactionType.md)
 - [Model.POSTDocumentPropertiesType](docs/POSTDocumentPropertiesType.md)
 - [Model.POSTEmailBillingDocfromBillRunType](docs/POSTEmailBillingDocfromBillRunType.md)
 - [Model.POSTEntityConnectionsResponseType](docs/POSTEntityConnectionsResponseType.md)
 - [Model.POSTEntityConnectionsType](docs/POSTEntityConnectionsType.md)
 - [Model.POSTHMACSignatureResponseType](docs/POSTHMACSignatureResponseType.md)
 - [Model.POSTHMACSignatureType](docs/POSTHMACSignatureType.md)
 - [Model.POSTIiaRevenueScheduleByDateRangeType](docs/POSTIiaRevenueScheduleByDateRangeType.md)
 - [Model.POSTIiaRevenueScheduleByDateRangeTypeAllOf](docs/POSTIiaRevenueScheduleByDateRangeTypeAllOf.md)
 - [Model.POSTIiaRevenueScheduleByTransactionType](docs/POSTIiaRevenueScheduleByTransactionType.md)
 - [Model.POSTInvoiceCollectCreditMemosType](docs/POSTInvoiceCollectCreditMemosType.md)
 - [Model.POSTInvoiceCollectInvoicesType](docs/POSTInvoiceCollectInvoicesType.md)
 - [Model.POSTInvoiceCollectResponseType](docs/POSTInvoiceCollectResponseType.md)
 - [Model.POSTInvoiceCollectType](docs/POSTInvoiceCollectType.md)
 - [Model.POSTInvoicesBatchPostType](docs/POSTInvoicesBatchPostType.md)
 - [Model.POSTInvoicesBatchPostTypeAllOf](docs/POSTInvoicesBatchPostTypeAllOf.md)
 - [Model.POSTJournalEntryItemType](docs/POSTJournalEntryItemType.md)
 - [Model.POSTJournalEntryItemTypeAllOf](docs/POSTJournalEntryItemTypeAllOf.md)
 - [Model.POSTJournalEntryResponseType](docs/POSTJournalEntryResponseType.md)
 - [Model.POSTJournalEntrySegmentType](docs/POSTJournalEntrySegmentType.md)
 - [Model.POSTJournalEntryType](docs/POSTJournalEntryType.md)
 - [Model.POSTJournalEntryTypeAllOf](docs/POSTJournalEntryTypeAllOf.md)
 - [Model.POSTJournalRunResponseType](docs/POSTJournalRunResponseType.md)
 - [Model.POSTJournalRunTransactionType](docs/POSTJournalRunTransactionType.md)
 - [Model.POSTJournalRunType](docs/POSTJournalRunType.md)
 - [Model.POSTMassUpdateResponseType](docs/POSTMassUpdateResponseType.md)
 - [Model.POSTMemoPdfResponse](docs/POSTMemoPdfResponse.md)
 - [Model.POSTOrderAsyncRequestType](docs/POSTOrderAsyncRequestType.md)
 - [Model.POSTOrderAsyncRequestTypeSubscriptionsInner](docs/POSTOrderAsyncRequestTypeSubscriptionsInner.md)
 - [Model.POSTOrderPreviewAsyncRequestType](docs/POSTOrderPreviewAsyncRequestType.md)
 - [Model.POSTOrderPreviewAsyncRequestTypeSubscriptionsInner](docs/POSTOrderPreviewAsyncRequestTypeSubscriptionsInner.md)
 - [Model.POSTOrderPreviewRequestType](docs/POSTOrderPreviewRequestType.md)
 - [Model.POSTOrderRequestType](docs/POSTOrderRequestType.md)
 - [Model.POSTPMMandateInfo](docs/POSTPMMandateInfo.md)
 - [Model.POSTPaymentMethodDecryption](docs/POSTPaymentMethodDecryption.md)
 - [Model.POSTPaymentMethodRequest](docs/POSTPaymentMethodRequest.md)
 - [Model.POSTPaymentMethodRequestAllOf](docs/POSTPaymentMethodRequestAllOf.md)
 - [Model.POSTPaymentMethodResponse](docs/POSTPaymentMethodResponse.md)
 - [Model.POSTPaymentMethodResponseAllOf](docs/POSTPaymentMethodResponseAllOf.md)
 - [Model.POSTPaymentMethodResponseAllOfReasons](docs/POSTPaymentMethodResponseAllOfReasons.md)
 - [Model.POSTPaymentMethodResponseDecryption](docs/POSTPaymentMethodResponseDecryption.md)
 - [Model.POSTPaymentMethodResponseType](docs/POSTPaymentMethodResponseType.md)
 - [Model.POSTPaymentMethodType](docs/POSTPaymentMethodType.md)
 - [Model.POSTPaymentMethodTypeAllOf](docs/POSTPaymentMethodTypeAllOf.md)
 - [Model.POSTPaymentRunDataElementRequest](docs/POSTPaymentRunDataElementRequest.md)
 - [Model.POSTPaymentRunDataElementRequestAllOf](docs/POSTPaymentRunDataElementRequestAllOf.md)
 - [Model.POSTPaymentRunRequest](docs/POSTPaymentRunRequest.md)
 - [Model.POSTPaymentScheduleRequest](docs/POSTPaymentScheduleRequest.md)
 - [Model.POSTPaymentScheduleRequestAllOf](docs/POSTPaymentScheduleRequestAllOf.md)
 - [Model.POSTPaymentScheduleRequestAllOfBillingDocument](docs/POSTPaymentScheduleRequestAllOfBillingDocument.md)
 - [Model.POSTPaymentScheduleResponse](docs/POSTPaymentScheduleResponse.md)
 - [Model.POSTPaymentScheduleResponseAllOf](docs/POSTPaymentScheduleResponseAllOf.md)
 - [Model.POSTPaymentScheduleResponseAllOfBillingDocument](docs/POSTPaymentScheduleResponseAllOfBillingDocument.md)
 - [Model.POSTPaymentSchedulesEach](docs/POSTPaymentSchedulesEach.md)
 - [Model.POSTPaymentSchedulesRequest](docs/POSTPaymentSchedulesRequest.md)
 - [Model.POSTPaymentSchedulesResponse](docs/POSTPaymentSchedulesResponse.md)
 - [Model.POSTPreviewOrderAsynchronously202Response](docs/POSTPreviewOrderAsynchronously202Response.md)
 - [Model.POSTPublicEmailTemplateRequest](docs/POSTPublicEmailTemplateRequest.md)
 - [Model.POSTPublicNotificationDefinitionRequest](docs/POSTPublicNotificationDefinitionRequest.md)
 - [Model.POSTPublicNotificationDefinitionRequestCallout](docs/POSTPublicNotificationDefinitionRequestCallout.md)
 - [Model.POSTPublicNotificationDefinitionRequestFilterRule](docs/POSTPublicNotificationDefinitionRequestFilterRule.md)
 - [Model.POSTQuoteDocResponseType](docs/POSTQuoteDocResponseType.md)
 - [Model.POSTQuoteDocType](docs/POSTQuoteDocType.md)
 - [Model.POSTRSASignatureResponseType](docs/POSTRSASignatureResponseType.md)
 - [Model.POSTRSASignatureType](docs/POSTRSASignatureType.md)
 - [Model.POSTReconcileRefundRequest](docs/POSTReconcileRefundRequest.md)
 - [Model.POSTReconcileRefundResponse](docs/POSTReconcileRefundResponse.md)
 - [Model.POSTReconcileRefundResponseFinanceInformation](docs/POSTReconcileRefundResponseFinanceInformation.md)
 - [Model.POSTRejectPaymentRequest](docs/POSTRejectPaymentRequest.md)
 - [Model.POSTRejectPaymentResponse](docs/POSTRejectPaymentResponse.md)
 - [Model.POSTRetryPaymentScheduleItemInfo](docs/POSTRetryPaymentScheduleItemInfo.md)
 - [Model.POSTRetryPaymentScheduleItemRequest](docs/POSTRetryPaymentScheduleItemRequest.md)
 - [Model.POSTRetryPaymentScheduleItemResponse](docs/POSTRetryPaymentScheduleItemResponse.md)
 - [Model.POSTRevenueScheduleByChargeResponseType](docs/POSTRevenueScheduleByChargeResponseType.md)
 - [Model.POSTRevenueScheduleByChargeType](docs/POSTRevenueScheduleByChargeType.md)
 - [Model.POSTRevenueScheduleByChargeTypeAllOf](docs/POSTRevenueScheduleByChargeTypeAllOf.md)
 - [Model.POSTRevenueScheduleByChargeTypeRevenueEvent](docs/POSTRevenueScheduleByChargeTypeRevenueEvent.md)
 - [Model.POSTRevenueScheduleByChargeTypeRevenueEventAllOf](docs/POSTRevenueScheduleByChargeTypeRevenueEventAllOf.md)
 - [Model.POSTRevenueScheduleByDateRangeType](docs/POSTRevenueScheduleByDateRangeType.md)
 - [Model.POSTRevenueScheduleByDateRangeTypeRevenueEvent](docs/POSTRevenueScheduleByDateRangeTypeRevenueEvent.md)
 - [Model.POSTRevenueScheduleByDateRangeTypeRevenueEventAllOf](docs/POSTRevenueScheduleByDateRangeTypeRevenueEventAllOf.md)
 - [Model.POSTRevenueScheduleByTransactionRatablyCMType](docs/POSTRevenueScheduleByTransactionRatablyCMType.md)
 - [Model.POSTRevenueScheduleByTransactionRatablyCMTypeAllOf](docs/POSTRevenueScheduleByTransactionRatablyCMTypeAllOf.md)
 - [Model.POSTRevenueScheduleByTransactionRatablyDMType](docs/POSTRevenueScheduleByTransactionRatablyDMType.md)
 - [Model.POSTRevenueScheduleByTransactionRatablyTypeRevenueEvent](docs/POSTRevenueScheduleByTransactionRatablyTypeRevenueEvent.md)
 - [Model.POSTRevenueScheduleByTransactionRatablyTypeRevenueEventAllOf](docs/POSTRevenueScheduleByTransactionRatablyTypeRevenueEventAllOf.md)
 - [Model.POSTRevenueScheduleByTransactionResponseType](docs/POSTRevenueScheduleByTransactionResponseType.md)
 - [Model.POSTRevenueScheduleByTransactionType](docs/POSTRevenueScheduleByTransactionType.md)
 - [Model.POSTRevenueScheduleByTransactionTypeRevenueEvent](docs/POSTRevenueScheduleByTransactionTypeRevenueEvent.md)
 - [Model.POSTRevenueScheduleByTransactionTypeRevenueEventAllOf](docs/POSTRevenueScheduleByTransactionTypeRevenueEventAllOf.md)
 - [Model.POSTReversePaymentRequest](docs/POSTReversePaymentRequest.md)
 - [Model.POSTReversePaymentResponse](docs/POSTReversePaymentResponse.md)
 - [Model.POSTRunWorkflow400Response](docs/POSTRunWorkflow400Response.md)
 - [Model.POSTRunWorkflow406Response](docs/POSTRunWorkflow406Response.md)
 - [Model.POSTScCreateType](docs/POSTScCreateType.md)
 - [Model.POSTScCreateTypeAllOf](docs/POSTScCreateTypeAllOf.md)
 - [Model.POSTSequenceSetRequest](docs/POSTSequenceSetRequest.md)
 - [Model.POSTSequenceSetsRequest](docs/POSTSequenceSetsRequest.md)
 - [Model.POSTSequenceSetsResponse](docs/POSTSequenceSetsResponse.md)
 - [Model.POSTSettlePaymentRequest](docs/POSTSettlePaymentRequest.md)
 - [Model.POSTSettlePaymentResponse](docs/POSTSettlePaymentResponse.md)
 - [Model.POSTSrpCreateType](docs/POSTSrpCreateType.md)
 - [Model.POSTSrpCreateTypeAllOf](docs/POSTSrpCreateTypeAllOf.md)
 - [Model.POSTSubscriptionCancellationResponseType](docs/POSTSubscriptionCancellationResponseType.md)
 - [Model.POSTSubscriptionCancellationType](docs/POSTSubscriptionCancellationType.md)
 - [Model.POSTSubscriptionPreviewCreditMemoItemsType](docs/POSTSubscriptionPreviewCreditMemoItemsType.md)
 - [Model.POSTSubscriptionPreviewInvoiceItemsType](docs/POSTSubscriptionPreviewInvoiceItemsType.md)
 - [Model.POSTSubscriptionPreviewResponseType](docs/POSTSubscriptionPreviewResponseType.md)
 - [Model.POSTSubscriptionPreviewResponseTypeChargeMetrics](docs/POSTSubscriptionPreviewResponseTypeChargeMetrics.md)
 - [Model.POSTSubscriptionPreviewResponseTypeCreditMemo](docs/POSTSubscriptionPreviewResponseTypeCreditMemo.md)
 - [Model.POSTSubscriptionPreviewResponseTypeInvoice](docs/POSTSubscriptionPreviewResponseTypeInvoice.md)
 - [Model.POSTSubscriptionPreviewTaxationItemsType](docs/POSTSubscriptionPreviewTaxationItemsType.md)
 - [Model.POSTSubscriptionPreviewType](docs/POSTSubscriptionPreviewType.md)
 - [Model.POSTSubscriptionPreviewTypeAllOf](docs/POSTSubscriptionPreviewTypeAllOf.md)
 - [Model.POSTSubscriptionPreviewTypePreviewAccountInfo](docs/POSTSubscriptionPreviewTypePreviewAccountInfo.md)
 - [Model.POSTSubscriptionPreviewTypePreviewAccountInfoAllOf](docs/POSTSubscriptionPreviewTypePreviewAccountInfoAllOf.md)
 - [Model.POSTSubscriptionPreviewTypePreviewAccountInfoAllOfBillToContact](docs/POSTSubscriptionPreviewTypePreviewAccountInfoAllOfBillToContact.md)
 - [Model.POSTSubscriptionResponseType](docs/POSTSubscriptionResponseType.md)
 - [Model.POSTSubscriptionType](docs/POSTSubscriptionType.md)
 - [Model.POSTSubscriptionTypeAllOf](docs/POSTSubscriptionTypeAllOf.md)
 - [Model.POSTTaxationItemForCMType](docs/POSTTaxationItemForCMType.md)
 - [Model.POSTTaxationItemForCMTypeAllOf](docs/POSTTaxationItemForCMTypeAllOf.md)
 - [Model.POSTTaxationItemForCMTypeAllOfFinanceInformation](docs/POSTTaxationItemForCMTypeAllOfFinanceInformation.md)
 - [Model.POSTTaxationItemForDMType](docs/POSTTaxationItemForDMType.md)
 - [Model.POSTTaxationItemForDMTypeAllOf](docs/POSTTaxationItemForDMTypeAllOf.md)
 - [Model.POSTTaxationItemForDMTypeAllOfFinanceInformation](docs/POSTTaxationItemForDMTypeAllOfFinanceInformation.md)
 - [Model.POSTTaxationItemListForCMType](docs/POSTTaxationItemListForCMType.md)
 - [Model.POSTTaxationItemListForDMType](docs/POSTTaxationItemListForDMType.md)
 - [Model.POSTTierType](docs/POSTTierType.md)
 - [Model.POSTUploadFileResponse](docs/POSTUploadFileResponse.md)
 - [Model.POSTUsageResponseType](docs/POSTUsageResponseType.md)
 - [Model.POSTVoidAuthorize](docs/POSTVoidAuthorize.md)
 - [Model.POSTVoidAuthorizeResponse](docs/POSTVoidAuthorizeResponse.md)
 - [Model.POSTWorkflowDefinitionImportRequest](docs/POSTWorkflowDefinitionImportRequest.md)
 - [Model.POSTWorkflowVersionsImportRequest](docs/POSTWorkflowVersionsImportRequest.md)
 - [Model.POSTorPUTCatalogGroupAddProductRatePlan](docs/POSTorPUTCatalogGroupAddProductRatePlan.md)
 - [Model.POSTorPUTCatalogGroupAddProductRatePlanAllOf](docs/POSTorPUTCatalogGroupAddProductRatePlanAllOf.md)
 - [Model.PUTAcceptUserAccessResponseType](docs/PUTAcceptUserAccessResponseType.md)
 - [Model.PUTAccountType](docs/PUTAccountType.md)
 - [Model.PUTAccountTypeAllOf](docs/PUTAccountTypeAllOf.md)
 - [Model.PUTAccountTypeBillToContact](docs/PUTAccountTypeBillToContact.md)
 - [Model.PUTAccountTypeSoldToContact](docs/PUTAccountTypeSoldToContact.md)
 - [Model.PUTAccountTypeSoldToContactAllOf](docs/PUTAccountTypeSoldToContactAllOf.md)
 - [Model.PUTAccountingCodeType](docs/PUTAccountingCodeType.md)
 - [Model.PUTAccountingCodeTypeAllOf](docs/PUTAccountingCodeTypeAllOf.md)
 - [Model.PUTAccountingPeriodType](docs/PUTAccountingPeriodType.md)
 - [Model.PUTAccountingPeriodTypeAllOf](docs/PUTAccountingPeriodTypeAllOf.md)
 - [Model.PUTAllocateManuallyType](docs/PUTAllocateManuallyType.md)
 - [Model.PUTAllocateManuallyTypeAllOf](docs/PUTAllocateManuallyTypeAllOf.md)
 - [Model.PUTAttachmentType](docs/PUTAttachmentType.md)
 - [Model.PUTBasicSummaryJournalEntryType](docs/PUTBasicSummaryJournalEntryType.md)
 - [Model.PUTBasicSummaryJournalEntryTypeAllOf](docs/PUTBasicSummaryJournalEntryTypeAllOf.md)
 - [Model.PUTBatchDebitMemosRequest](docs/PUTBatchDebitMemosRequest.md)
 - [Model.PUTBulkCreditMemosRequestType](docs/PUTBulkCreditMemosRequestType.md)
 - [Model.PUTBulkCreditMemosRequestTypeAllOf](docs/PUTBulkCreditMemosRequestTypeAllOf.md)
 - [Model.PUTBulkDebitMemosRequestType](docs/PUTBulkDebitMemosRequestType.md)
 - [Model.PUTBulkDebitMemosRequestTypeAllOf](docs/PUTBulkDebitMemosRequestTypeAllOf.md)
 - [Model.PUTCancelPaymentScheduleRequest](docs/PUTCancelPaymentScheduleRequest.md)
 - [Model.PUTCatalogGroup](docs/PUTCatalogGroup.md)
 - [Model.PUTCatalogGroupAllOf](docs/PUTCatalogGroupAllOf.md)
 - [Model.PUTCatalogGroupRemoveProductRatePlan](docs/PUTCatalogGroupRemoveProductRatePlan.md)
 - [Model.PUTCatalogGroupRemoveProductRatePlanAllOf](docs/PUTCatalogGroupRemoveProductRatePlanAllOf.md)
 - [Model.PUTCreditMemoItemType](docs/PUTCreditMemoItemType.md)
 - [Model.PUTCreditMemoItemTypeAllOf](docs/PUTCreditMemoItemTypeAllOf.md)
 - [Model.PUTCreditMemoType](docs/PUTCreditMemoType.md)
 - [Model.PUTCreditMemoTypeAllOf](docs/PUTCreditMemoTypeAllOf.md)
 - [Model.PUTCreditMemoWriteOff](docs/PUTCreditMemoWriteOff.md)
 - [Model.PUTCreditMemoWriteOffAllOf](docs/PUTCreditMemoWriteOffAllOf.md)
 - [Model.PUTCreditMemoWriteOffResponseType](docs/PUTCreditMemoWriteOffResponseType.md)
 - [Model.PUTCreditMemoWriteOffResponseTypeDebitMemo](docs/PUTCreditMemoWriteOffResponseTypeDebitMemo.md)
 - [Model.PUTCreditMemosWithIdType](docs/PUTCreditMemosWithIdType.md)
 - [Model.PUTCreditMemosWithIdTypeAllOf](docs/PUTCreditMemosWithIdTypeAllOf.md)
 - [Model.PUTDebitMemoItemType](docs/PUTDebitMemoItemType.md)
 - [Model.PUTDebitMemoItemTypeAllOf](docs/PUTDebitMemoItemTypeAllOf.md)
 - [Model.PUTDebitMemoType](docs/PUTDebitMemoType.md)
 - [Model.PUTDebitMemoTypeAllOf](docs/PUTDebitMemoTypeAllOf.md)
 - [Model.PUTDebitMemoWithIdType](docs/PUTDebitMemoWithIdType.md)
 - [Model.PUTDebitMemoWithIdTypeAllOf](docs/PUTDebitMemoWithIdTypeAllOf.md)
 - [Model.PUTDeleteSubscriptionResponseType](docs/PUTDeleteSubscriptionResponseType.md)
 - [Model.PUTDenyUserAccessResponseType](docs/PUTDenyUserAccessResponseType.md)
 - [Model.PUTDocumentPropertiesType](docs/PUTDocumentPropertiesType.md)
 - [Model.PUTEntityConnectionsAcceptResponseType](docs/PUTEntityConnectionsAcceptResponseType.md)
 - [Model.PUTEntityConnectionsDenyResponseType](docs/PUTEntityConnectionsDenyResponseType.md)
 - [Model.PUTEntityConnectionsDisconnectResponseType](docs/PUTEntityConnectionsDisconnectResponseType.md)
 - [Model.PUTEventRIDetailType](docs/PUTEventRIDetailType.md)
 - [Model.PUTJournalEntryItemType](docs/PUTJournalEntryItemType.md)
 - [Model.PUTJournalEntryItemTypeAllOf](docs/PUTJournalEntryItemTypeAllOf.md)
 - [Model.PUTOrderActionTriggerDatesRequestType](docs/PUTOrderActionTriggerDatesRequestType.md)
 - [Model.PUTOrderActionTriggerDatesRequestTypeSubscriptionsInner](docs/PUTOrderActionTriggerDatesRequestTypeSubscriptionsInner.md)
 - [Model.PUTOrderActionTriggerDatesRequestTypeSubscriptionsInnerOrderActionsInner](docs/PUTOrderActionTriggerDatesRequestTypeSubscriptionsInnerOrderActionsInner.md)
 - [Model.PUTOrderActionTriggerDatesRequestTypeSubscriptionsInnerOrderActionsInnerChargesInner](docs/PUTOrderActionTriggerDatesRequestTypeSubscriptionsInnerOrderActionsInnerChargesInner.md)
 - [Model.PUTOrderActionTriggerDatesRequestTypeSubscriptionsInnerOrderActionsInnerTriggerDatesInner](docs/PUTOrderActionTriggerDatesRequestTypeSubscriptionsInnerOrderActionsInnerTriggerDatesInner.md)
 - [Model.PUTOrderLineItemRequestType](docs/PUTOrderLineItemRequestType.md)
 - [Model.PUTOrderPatchRequestType](docs/PUTOrderPatchRequestType.md)
 - [Model.PUTOrderPatchRequestTypeSubscriptionsInner](docs/PUTOrderPatchRequestTypeSubscriptionsInner.md)
 - [Model.PUTOrderPatchRequestTypeSubscriptionsInnerOrderActionsInner](docs/PUTOrderPatchRequestTypeSubscriptionsInnerOrderActionsInner.md)
 - [Model.PUTOrderTriggerDatesResponseType](docs/PUTOrderTriggerDatesResponseType.md)
 - [Model.PUTOrderTriggerDatesResponseTypeAllOf](docs/PUTOrderTriggerDatesResponseTypeAllOf.md)
 - [Model.PUTOrderTriggerDatesResponseTypeAllOfSubscriptions](docs/PUTOrderTriggerDatesResponseTypeAllOfSubscriptions.md)
 - [Model.PUTPMAccountHolderInfo](docs/PUTPMAccountHolderInfo.md)
 - [Model.PUTPMCreditCardInfo](docs/PUTPMCreditCardInfo.md)
 - [Model.PUTPaymentMethodRequest](docs/PUTPaymentMethodRequest.md)
 - [Model.PUTPaymentMethodRequestAllOf](docs/PUTPaymentMethodRequestAllOf.md)
 - [Model.PUTPaymentMethodRequestAllOfMandateInfo](docs/PUTPaymentMethodRequestAllOfMandateInfo.md)
 - [Model.PUTPaymentMethodResponse](docs/PUTPaymentMethodResponse.md)
 - [Model.PUTPaymentMethodResponseType](docs/PUTPaymentMethodResponseType.md)
 - [Model.PUTPaymentMethodType](docs/PUTPaymentMethodType.md)
 - [Model.PUTPaymentMethodTypeAllOf](docs/PUTPaymentMethodTypeAllOf.md)
 - [Model.PUTPaymentRunRequest](docs/PUTPaymentRunRequest.md)
 - [Model.PUTPaymentScheduleItemRequest](docs/PUTPaymentScheduleItemRequest.md)
 - [Model.PUTPaymentScheduleItemResponse](docs/PUTPaymentScheduleItemResponse.md)
 - [Model.PUTPaymentScheduleRequest](docs/PUTPaymentScheduleRequest.md)
 - [Model.PUTPaymentScheduleRequestAllOf](docs/PUTPaymentScheduleRequestAllOf.md)
 - [Model.PUTPreviewPaymentScheduleRequest](docs/PUTPreviewPaymentScheduleRequest.md)
 - [Model.PUTPublicCalloutOptionsRequest](docs/PUTPublicCalloutOptionsRequest.md)
 - [Model.PUTPublicEmailTemplateRequest](docs/PUTPublicEmailTemplateRequest.md)
 - [Model.PUTPublicNotificationDefinitionRequest](docs/PUTPublicNotificationDefinitionRequest.md)
 - [Model.PUTPublicNotificationDefinitionRequestCallout](docs/PUTPublicNotificationDefinitionRequestCallout.md)
 - [Model.PUTPublicNotificationDefinitionRequestFilterRule](docs/PUTPublicNotificationDefinitionRequestFilterRule.md)
 - [Model.PUTPublishOpenPaymentMethodTypeResponse](docs/PUTPublishOpenPaymentMethodTypeResponse.md)
 - [Model.PUTRSBasicInfoType](docs/PUTRSBasicInfoType.md)
 - [Model.PUTRSBasicInfoTypeAllOf](docs/PUTRSBasicInfoTypeAllOf.md)
 - [Model.PUTRSTermType](docs/PUTRSTermType.md)
 - [Model.PUTRSTermTypeAllOf](docs/PUTRSTermTypeAllOf.md)
 - [Model.PUTRefundType](docs/PUTRefundType.md)
 - [Model.PUTRefundTypeAllOf](docs/PUTRefundTypeAllOf.md)
 - [Model.PUTRefundTypeAllOfFinanceInformation](docs/PUTRefundTypeAllOfFinanceInformation.md)
 - [Model.PUTRenewSubscriptionResponseType](docs/PUTRenewSubscriptionResponseType.md)
 - [Model.PUTRenewSubscriptionType](docs/PUTRenewSubscriptionType.md)
 - [Model.PUTRevenueScheduleResponseType](docs/PUTRevenueScheduleResponseType.md)
 - [Model.PUTRevproAccCodeResponse](docs/PUTRevproAccCodeResponse.md)
 - [Model.PUTScAddType](docs/PUTScAddType.md)
 - [Model.PUTScAddTypeAllOf](docs/PUTScAddTypeAllOf.md)
 - [Model.PUTScUpdateType](docs/PUTScUpdateType.md)
 - [Model.PUTScUpdateTypeAllOf](docs/PUTScUpdateTypeAllOf.md)
 - [Model.PUTScheduleRIDetailType](docs/PUTScheduleRIDetailType.md)
 - [Model.PUTSendUserAccessRequestResponseType](docs/PUTSendUserAccessRequestResponseType.md)
 - [Model.PUTSendUserAccessRequestType](docs/PUTSendUserAccessRequestType.md)
 - [Model.PUTSequenceSetRequest](docs/PUTSequenceSetRequest.md)
 - [Model.PUTSequenceSetResponse](docs/PUTSequenceSetResponse.md)
 - [Model.PUTSpecificDateAllocationType](docs/PUTSpecificDateAllocationType.md)
 - [Model.PUTSpecificDateAllocationTypeAllOf](docs/PUTSpecificDateAllocationTypeAllOf.md)
 - [Model.PUTSrpAddType](docs/PUTSrpAddType.md)
 - [Model.PUTSrpAddTypeAllOf](docs/PUTSrpAddTypeAllOf.md)
 - [Model.PUTSrpChangeType](docs/PUTSrpChangeType.md)
 - [Model.PUTSrpChangeTypeAllOf](docs/PUTSrpChangeTypeAllOf.md)
 - [Model.PUTSrpRemoveType](docs/PUTSrpRemoveType.md)
 - [Model.PUTSrpUpdateType](docs/PUTSrpUpdateType.md)
 - [Model.PUTSrpUpdateTypeAllOf](docs/PUTSrpUpdateTypeAllOf.md)
 - [Model.PUTSubscriptionPatchRequestType](docs/PUTSubscriptionPatchRequestType.md)
 - [Model.PUTSubscriptionPatchRequestTypeRatePlansInner](docs/PUTSubscriptionPatchRequestTypeRatePlansInner.md)
 - [Model.PUTSubscriptionPatchRequestTypeRatePlansInnerChargesInner](docs/PUTSubscriptionPatchRequestTypeRatePlansInnerChargesInner.md)
 - [Model.PUTSubscriptionPatchSpecificVersionRequestType](docs/PUTSubscriptionPatchSpecificVersionRequestType.md)
 - [Model.PUTSubscriptionPatchSpecificVersionRequestTypeRatePlansInner](docs/PUTSubscriptionPatchSpecificVersionRequestTypeRatePlansInner.md)
 - [Model.PUTSubscriptionPatchSpecificVersionRequestTypeRatePlansInnerChargesInner](docs/PUTSubscriptionPatchSpecificVersionRequestTypeRatePlansInnerChargesInner.md)
 - [Model.PUTSubscriptionPreviewInvoiceItemsType](docs/PUTSubscriptionPreviewInvoiceItemsType.md)
 - [Model.PUTSubscriptionResponseType](docs/PUTSubscriptionResponseType.md)
 - [Model.PUTSubscriptionResponseTypeChargeMetrics](docs/PUTSubscriptionResponseTypeChargeMetrics.md)
 - [Model.PUTSubscriptionResponseTypeCreditMemo](docs/PUTSubscriptionResponseTypeCreditMemo.md)
 - [Model.PUTSubscriptionResponseTypeInvoice](docs/PUTSubscriptionResponseTypeInvoice.md)
 - [Model.PUTSubscriptionResumeResponseType](docs/PUTSubscriptionResumeResponseType.md)
 - [Model.PUTSubscriptionResumeType](docs/PUTSubscriptionResumeType.md)
 - [Model.PUTSubscriptionSuspendResponseType](docs/PUTSubscriptionSuspendResponseType.md)
 - [Model.PUTSubscriptionSuspendType](docs/PUTSubscriptionSuspendType.md)
 - [Model.PUTSubscriptionType](docs/PUTSubscriptionType.md)
 - [Model.PUTSubscriptionTypeAllOf](docs/PUTSubscriptionTypeAllOf.md)
 - [Model.PUTTaxationItemType](docs/PUTTaxationItemType.md)
 - [Model.PUTTaxationItemTypeAllOf](docs/PUTTaxationItemTypeAllOf.md)
 - [Model.PUTUpdateOpenPaymentMethodTypeRequest](docs/PUTUpdateOpenPaymentMethodTypeRequest.md)
 - [Model.PUTUpdateOpenPaymentMethodTypeResponse](docs/PUTUpdateOpenPaymentMethodTypeResponse.md)
 - [Model.PUTVerifyPaymentMethodResponseType](docs/PUTVerifyPaymentMethodResponseType.md)
 - [Model.PUTVerifyPaymentMethodType](docs/PUTVerifyPaymentMethodType.md)
 - [Model.PUTWriteOffInvoiceRequest](docs/PUTWriteOffInvoiceRequest.md)
 - [Model.PUTWriteOffInvoiceRequestAllOf](docs/PUTWriteOffInvoiceRequestAllOf.md)
 - [Model.PUTWriteOffInvoiceResponse](docs/PUTWriteOffInvoiceResponse.md)
 - [Model.PUTWriteOffInvoiceResponseCreditMemo](docs/PUTWriteOffInvoiceResponseCreditMemo.md)
 - [Model.PaymentCollectionResponseType](docs/PaymentCollectionResponseType.md)
 - [Model.PaymentDebitMemoApplicationApplyRequestType](docs/PaymentDebitMemoApplicationApplyRequestType.md)
 - [Model.PaymentDebitMemoApplicationCreateRequestType](docs/PaymentDebitMemoApplicationCreateRequestType.md)
 - [Model.PaymentDebitMemoApplicationItemApplyRequestType](docs/PaymentDebitMemoApplicationItemApplyRequestType.md)
 - [Model.PaymentDebitMemoApplicationItemCreateRequestType](docs/PaymentDebitMemoApplicationItemCreateRequestType.md)
 - [Model.PaymentDebitMemoApplicationItemUnapplyRequestType](docs/PaymentDebitMemoApplicationItemUnapplyRequestType.md)
 - [Model.PaymentDebitMemoApplicationUnapplyRequestType](docs/PaymentDebitMemoApplicationUnapplyRequestType.md)
 - [Model.PaymentEntityPrefix](docs/PaymentEntityPrefix.md)
 - [Model.PaymentInvoiceApplicationApplyRequestType](docs/PaymentInvoiceApplicationApplyRequestType.md)
 - [Model.PaymentInvoiceApplicationCreateRequestType](docs/PaymentInvoiceApplicationCreateRequestType.md)
 - [Model.PaymentInvoiceApplicationItemApplyRequestType](docs/PaymentInvoiceApplicationItemApplyRequestType.md)
 - [Model.PaymentInvoiceApplicationItemCreateRequestType](docs/PaymentInvoiceApplicationItemCreateRequestType.md)
 - [Model.PaymentInvoiceApplicationItemUnapplyRequestType](docs/PaymentInvoiceApplicationItemUnapplyRequestType.md)
 - [Model.PaymentInvoiceApplicationUnapplyRequestType](docs/PaymentInvoiceApplicationUnapplyRequestType.md)
 - [Model.PaymentMethod](docs/PaymentMethod.md)
 - [Model.PaymentMethodAllOf](docs/PaymentMethodAllOf.md)
 - [Model.PaymentObjectNSFields](docs/PaymentObjectNSFields.md)
 - [Model.PaymentRunData](docs/PaymentRunData.md)
 - [Model.PaymentRunStatistic](docs/PaymentRunStatistic.md)
 - [Model.PaymentScheduleCommonResponse](docs/PaymentScheduleCommonResponse.md)
 - [Model.PaymentScheduleCommonResponseAllOf](docs/PaymentScheduleCommonResponseAllOf.md)
 - [Model.PaymentScheduleItemCommon](docs/PaymentScheduleItemCommon.md)
 - [Model.PaymentScheduleItemCommonAllOf](docs/PaymentScheduleItemCommonAllOf.md)
 - [Model.PaymentScheduleItemCommonResponse](docs/PaymentScheduleItemCommonResponse.md)
 - [Model.PaymentScheduleItemCommonResponseAllOf](docs/PaymentScheduleItemCommonResponseAllOf.md)
 - [Model.PostBatchInvoiceResponse](docs/PostBatchInvoiceResponse.md)
 - [Model.PostBatchInvoicesType](docs/PostBatchInvoicesType.md)
 - [Model.PostBillingPreviewParam](docs/PostBillingPreviewParam.md)
 - [Model.PostBillingPreviewRunParam](docs/PostBillingPreviewRunParam.md)
 - [Model.PostCreditMemoEmailRequestType](docs/PostCreditMemoEmailRequestType.md)
 - [Model.PostCustomObjectDefinitionFieldDefinitionRequest](docs/PostCustomObjectDefinitionFieldDefinitionRequest.md)
 - [Model.PostCustomObjectDefinitionsRequest](docs/PostCustomObjectDefinitionsRequest.md)
 - [Model.PostCustomObjectDefinitionsRequestDefinition](docs/PostCustomObjectDefinitionsRequestDefinition.md)
 - [Model.PostCustomObjectDefinitionsRequestDefinitionRelationshipsInner](docs/PostCustomObjectDefinitionsRequestDefinitionRelationshipsInner.md)
 - [Model.PostCustomObjectRecordsRequest](docs/PostCustomObjectRecordsRequest.md)
 - [Model.PostCustomObjectRecordsResponse](docs/PostCustomObjectRecordsResponse.md)
 - [Model.PostDebitMemoEmailType](docs/PostDebitMemoEmailType.md)
 - [Model.PostDiscountItemType](docs/PostDiscountItemType.md)
 - [Model.PostEventTriggerRequest](docs/PostEventTriggerRequest.md)
 - [Model.PostGenerateBillingDocumentType](docs/PostGenerateBillingDocumentType.md)
 - [Model.PostInvoiceEmailRequestType](docs/PostInvoiceEmailRequestType.md)
 - [Model.PostInvoiceItemType](docs/PostInvoiceItemType.md)
 - [Model.PostInvoiceResponse](docs/PostInvoiceResponse.md)
 - [Model.PostInvoiceResponseAllOf](docs/PostInvoiceResponseAllOf.md)
 - [Model.PostInvoiceType](docs/PostInvoiceType.md)
 - [Model.PostNonRefRefundType](docs/PostNonRefRefundType.md)
 - [Model.PostNonRefRefundTypeAllOf](docs/PostNonRefRefundTypeAllOf.md)
 - [Model.PostNonRefRefundTypeAllOfFinanceInformation](docs/PostNonRefRefundTypeAllOfFinanceInformation.md)
 - [Model.PostNonRefRefundTypeAllOfGatewayOptions](docs/PostNonRefRefundTypeAllOfGatewayOptions.md)
 - [Model.PostOrderLineItemUpdateType](docs/PostOrderLineItemUpdateType.md)
 - [Model.PostOrderLineItemUpdateTypeAllOf](docs/PostOrderLineItemUpdateTypeAllOf.md)
 - [Model.PostOrderLineItemsRequestType](docs/PostOrderLineItemsRequestType.md)
 - [Model.PostOrderPreviewResponseType](docs/PostOrderPreviewResponseType.md)
 - [Model.PostOrderPreviewResponseTypeAllOf](docs/PostOrderPreviewResponseTypeAllOf.md)
 - [Model.PostOrderResponseType](docs/PostOrderResponseType.md)
 - [Model.PostOrderResponseTypeAllOf](docs/PostOrderResponseTypeAllOf.md)
 - [Model.PostOrderResponseTypeAllOfSubscriptions](docs/PostOrderResponseTypeAllOfSubscriptions.md)
 - [Model.PostRefundType](docs/PostRefundType.md)
 - [Model.PostRefundTypeAllOf](docs/PostRefundTypeAllOf.md)
 - [Model.PostRefundTypeAllOfFinanceInformation](docs/PostRefundTypeAllOfFinanceInformation.md)
 - [Model.PostScheduledEventRequest](docs/PostScheduledEventRequest.md)
 - [Model.PostScheduledEventRequestParametersValue](docs/PostScheduledEventRequestParametersValue.md)
 - [Model.PostTaxationItemType](docs/PostTaxationItemType.md)
 - [Model.PreviewAccountInfo](docs/PreviewAccountInfo.md)
 - [Model.PreviewContactInfo](docs/PreviewContactInfo.md)
 - [Model.PreviewOptions](docs/PreviewOptions.md)
 - [Model.PreviewOrderChargeOverride](docs/PreviewOrderChargeOverride.md)
 - [Model.PreviewOrderChargeUpdate](docs/PreviewOrderChargeUpdate.md)
 - [Model.PreviewOrderCreateChangePlan](docs/PreviewOrderCreateChangePlan.md)
 - [Model.PreviewOrderCreateSubscription](docs/PreviewOrderCreateSubscription.md)
 - [Model.PreviewOrderCreateSubscriptionNewSubscriptionOwnerAccount](docs/PreviewOrderCreateSubscriptionNewSubscriptionOwnerAccount.md)
 - [Model.PreviewOrderOrderAction](docs/PreviewOrderOrderAction.md)
 - [Model.PreviewOrderPricingUpdate](docs/PreviewOrderPricingUpdate.md)
 - [Model.PreviewOrderRatePlanOverride](docs/PreviewOrderRatePlanOverride.md)
 - [Model.PreviewOrderRatePlanUpdate](docs/PreviewOrderRatePlanUpdate.md)
 - [Model.PreviewOrderTriggerParams](docs/PreviewOrderTriggerParams.md)
 - [Model.PreviewResult](docs/PreviewResult.md)
 - [Model.PreviewResultChargeMetricsInner](docs/PreviewResultChargeMetricsInner.md)
 - [Model.PreviewResultCreditMemosInner](docs/PreviewResultCreditMemosInner.md)
 - [Model.PreviewResultInvoicesInner](docs/PreviewResultInvoicesInner.md)
 - [Model.PreviewResultOrderDeltaMetrics](docs/PreviewResultOrderDeltaMetrics.md)
 - [Model.PreviewResultOrderMetricsInner](docs/PreviewResultOrderMetricsInner.md)
 - [Model.PreviewResultOrderMetricsInnerOrderActionsInner](docs/PreviewResultOrderMetricsInnerOrderActionsInner.md)
 - [Model.PriceChangeParams](docs/PriceChangeParams.md)
 - [Model.PricingUpdate](docs/PricingUpdate.md)
 - [Model.PricingUpdateForEvergreen](docs/PricingUpdateForEvergreen.md)
 - [Model.ProcessingOptions](docs/ProcessingOptions.md)
 - [Model.ProcessingOptionsOrders](docs/ProcessingOptionsOrders.md)
 - [Model.ProcessingOptionsOrdersBillingOptions](docs/ProcessingOptionsOrdersBillingOptions.md)
 - [Model.ProcessingOptionsOrdersElectronicPaymentOptions](docs/ProcessingOptionsOrdersElectronicPaymentOptions.md)
 - [Model.ProductObjectNSFields](docs/ProductObjectNSFields.md)
 - [Model.ProductRatePlanChargeObjectNSFields](docs/ProductRatePlanChargeObjectNSFields.md)
 - [Model.ProductRatePlanObjectNSFields](docs/ProductRatePlanObjectNSFields.md)
 - [Model.ProvisionEntityResponseType](docs/ProvisionEntityResponseType.md)
 - [Model.ProxyActionamendRequest](docs/ProxyActionamendRequest.md)
 - [Model.ProxyActionamendResponse](docs/ProxyActionamendResponse.md)
 - [Model.ProxyActioncreateRequest](docs/ProxyActioncreateRequest.md)
 - [Model.ProxyActiondeleteRequest](docs/ProxyActiondeleteRequest.md)
 - [Model.ProxyActionexecuteRequest](docs/ProxyActionexecuteRequest.md)
 - [Model.ProxyActiongenerateRequest](docs/ProxyActiongenerateRequest.md)
 - [Model.ProxyActionqueryMoreRequest](docs/ProxyActionqueryMoreRequest.md)
 - [Model.ProxyActionqueryMoreResponse](docs/ProxyActionqueryMoreResponse.md)
 - [Model.ProxyActionqueryRequest](docs/ProxyActionqueryRequest.md)
 - [Model.ProxyActionqueryRequestConf](docs/ProxyActionqueryRequestConf.md)
 - [Model.ProxyActionqueryResponse](docs/ProxyActionqueryResponse.md)
 - [Model.ProxyActionsubscribeRequest](docs/ProxyActionsubscribeRequest.md)
 - [Model.ProxyActionupdateRequest](docs/ProxyActionupdateRequest.md)
 - [Model.ProxyBadRequestResponse](docs/ProxyBadRequestResponse.md)
 - [Model.ProxyBadRequestResponseErrorsInner](docs/ProxyBadRequestResponseErrorsInner.md)
 - [Model.ProxyCreateAccount](docs/ProxyCreateAccount.md)
 - [Model.ProxyCreateAccountAllOf](docs/ProxyCreateAccountAllOf.md)
 - [Model.ProxyCreateBillRun](docs/ProxyCreateBillRun.md)
 - [Model.ProxyCreateContact](docs/ProxyCreateContact.md)
 - [Model.ProxyCreateContactAllOf](docs/ProxyCreateContactAllOf.md)
 - [Model.ProxyCreateCreditBalanceAdjustment](docs/ProxyCreateCreditBalanceAdjustment.md)
 - [Model.ProxyCreateCreditBalanceAdjustmentAllOf](docs/ProxyCreateCreditBalanceAdjustmentAllOf.md)
 - [Model.ProxyCreateExport](docs/ProxyCreateExport.md)
 - [Model.ProxyCreateFeature](docs/ProxyCreateFeature.md)
 - [Model.ProxyCreateFeatureAllOf](docs/ProxyCreateFeatureAllOf.md)
 - [Model.ProxyCreateInvoiceAdjustment](docs/ProxyCreateInvoiceAdjustment.md)
 - [Model.ProxyCreateInvoiceAdjustmentAllOf](docs/ProxyCreateInvoiceAdjustmentAllOf.md)
 - [Model.ProxyCreateInvoiceItemAdjustment](docs/ProxyCreateInvoiceItemAdjustment.md)
 - [Model.ProxyCreateInvoiceItemAdjustmentAllOf](docs/ProxyCreateInvoiceItemAdjustmentAllOf.md)
 - [Model.ProxyCreateInvoicePayment](docs/ProxyCreateInvoicePayment.md)
 - [Model.ProxyCreateOrModifyProductRatePlanChargeChargeModelConfiguration](docs/ProxyCreateOrModifyProductRatePlanChargeChargeModelConfiguration.md)
 - [Model.ProxyCreateOrModifyProductRatePlanChargeChargeModelConfigurationItem](docs/ProxyCreateOrModifyProductRatePlanChargeChargeModelConfigurationItem.md)
 - [Model.ProxyCreateOrModifyProductRatePlanChargeTierData](docs/ProxyCreateOrModifyProductRatePlanChargeTierData.md)
 - [Model.ProxyCreateOrModifyProductRatePlanChargeTierDataProductRatePlanChargeTierInner](docs/ProxyCreateOrModifyProductRatePlanChargeTierDataProductRatePlanChargeTierInner.md)
 - [Model.ProxyCreateOrModifyResponse](docs/ProxyCreateOrModifyResponse.md)
 - [Model.ProxyCreatePayment](docs/ProxyCreatePayment.md)
 - [Model.ProxyCreatePaymentAllOf](docs/ProxyCreatePaymentAllOf.md)
 - [Model.ProxyCreatePaymentAllOfGatewayOptionData](docs/ProxyCreatePaymentAllOfGatewayOptionData.md)
 - [Model.ProxyCreatePaymentMethod](docs/ProxyCreatePaymentMethod.md)
 - [Model.ProxyCreatePaymentMethodAllOf](docs/ProxyCreatePaymentMethodAllOf.md)
 - [Model.ProxyCreateProduct](docs/ProxyCreateProduct.md)
 - [Model.ProxyCreateProductAllOf](docs/ProxyCreateProductAllOf.md)
 - [Model.ProxyCreateProductRatePlan](docs/ProxyCreateProductRatePlan.md)
 - [Model.ProxyCreateProductRatePlanAllOf](docs/ProxyCreateProductRatePlanAllOf.md)
 - [Model.ProxyCreateProductRatePlanCharge](docs/ProxyCreateProductRatePlanCharge.md)
 - [Model.ProxyCreateProductRatePlanChargeAllOf](docs/ProxyCreateProductRatePlanChargeAllOf.md)
 - [Model.ProxyCreateRefund](docs/ProxyCreateRefund.md)
 - [Model.ProxyCreateRefundAllOf](docs/ProxyCreateRefundAllOf.md)
 - [Model.ProxyCreateRefundAllOfRefundInvoicePaymentData](docs/ProxyCreateRefundAllOfRefundInvoicePaymentData.md)
 - [Model.ProxyCreateTaxationItem](docs/ProxyCreateTaxationItem.md)
 - [Model.ProxyCreateTaxationItemAllOf](docs/ProxyCreateTaxationItemAllOf.md)
 - [Model.ProxyCreateUnitOfMeasure](docs/ProxyCreateUnitOfMeasure.md)
 - [Model.ProxyCreateUsage](docs/ProxyCreateUsage.md)
 - [Model.ProxyCreateUsageAllOf](docs/ProxyCreateUsageAllOf.md)
 - [Model.ProxyDeleteResponse](docs/ProxyDeleteResponse.md)
 - [Model.ProxyGetAccount](docs/ProxyGetAccount.md)
 - [Model.ProxyGetAccountAllOf](docs/ProxyGetAccountAllOf.md)
 - [Model.ProxyGetAmendment](docs/ProxyGetAmendment.md)
 - [Model.ProxyGetAmendmentAllOf](docs/ProxyGetAmendmentAllOf.md)
 - [Model.ProxyGetBillRun](docs/ProxyGetBillRun.md)
 - [Model.ProxyGetCommunicationProfile](docs/ProxyGetCommunicationProfile.md)
 - [Model.ProxyGetContact](docs/ProxyGetContact.md)
 - [Model.ProxyGetContactAllOf](docs/ProxyGetContactAllOf.md)
 - [Model.ProxyGetCreditBalanceAdjustment](docs/ProxyGetCreditBalanceAdjustment.md)
 - [Model.ProxyGetCreditBalanceAdjustmentAllOf](docs/ProxyGetCreditBalanceAdjustmentAllOf.md)
 - [Model.ProxyGetExport](docs/ProxyGetExport.md)
 - [Model.ProxyGetFeature](docs/ProxyGetFeature.md)
 - [Model.ProxyGetFeatureAllOf](docs/ProxyGetFeatureAllOf.md)
 - [Model.ProxyGetImport](docs/ProxyGetImport.md)
 - [Model.ProxyGetInvoice](docs/ProxyGetInvoice.md)
 - [Model.ProxyGetInvoiceAdjustment](docs/ProxyGetInvoiceAdjustment.md)
 - [Model.ProxyGetInvoiceAdjustmentAllOf](docs/ProxyGetInvoiceAdjustmentAllOf.md)
 - [Model.ProxyGetInvoiceAllOf](docs/ProxyGetInvoiceAllOf.md)
 - [Model.ProxyGetInvoiceItem](docs/ProxyGetInvoiceItem.md)
 - [Model.ProxyGetInvoiceItemAdjustment](docs/ProxyGetInvoiceItemAdjustment.md)
 - [Model.ProxyGetInvoiceItemAdjustmentAllOf](docs/ProxyGetInvoiceItemAdjustmentAllOf.md)
 - [Model.ProxyGetInvoiceItemAllOf](docs/ProxyGetInvoiceItemAllOf.md)
 - [Model.ProxyGetInvoicePayment](docs/ProxyGetInvoicePayment.md)
 - [Model.ProxyGetInvoiceSplit](docs/ProxyGetInvoiceSplit.md)
 - [Model.ProxyGetInvoiceSplitItem](docs/ProxyGetInvoiceSplitItem.md)
 - [Model.ProxyGetPayment](docs/ProxyGetPayment.md)
 - [Model.ProxyGetPaymentAllOf](docs/ProxyGetPaymentAllOf.md)
 - [Model.ProxyGetPaymentMethod](docs/ProxyGetPaymentMethod.md)
 - [Model.ProxyGetPaymentMethodSnapshot](docs/ProxyGetPaymentMethodSnapshot.md)
 - [Model.ProxyGetPaymentMethodTransactionLog](docs/ProxyGetPaymentMethodTransactionLog.md)
 - [Model.ProxyGetPaymentTransactionLog](docs/ProxyGetPaymentTransactionLog.md)
 - [Model.ProxyGetProduct](docs/ProxyGetProduct.md)
 - [Model.ProxyGetProductAllOf](docs/ProxyGetProductAllOf.md)
 - [Model.ProxyGetProductFeature](docs/ProxyGetProductFeature.md)
 - [Model.ProxyGetProductFeatureAllOf](docs/ProxyGetProductFeatureAllOf.md)
 - [Model.ProxyGetProductRatePlan](docs/ProxyGetProductRatePlan.md)
 - [Model.ProxyGetProductRatePlanAllOf](docs/ProxyGetProductRatePlanAllOf.md)
 - [Model.ProxyGetProductRatePlanCharge](docs/ProxyGetProductRatePlanCharge.md)
 - [Model.ProxyGetProductRatePlanChargeAllOf](docs/ProxyGetProductRatePlanChargeAllOf.md)
 - [Model.ProxyGetProductRatePlanChargeTier](docs/ProxyGetProductRatePlanChargeTier.md)
 - [Model.ProxyGetRatePlan](docs/ProxyGetRatePlan.md)
 - [Model.ProxyGetRatePlanAllOf](docs/ProxyGetRatePlanAllOf.md)
 - [Model.ProxyGetRatePlanCharge](docs/ProxyGetRatePlanCharge.md)
 - [Model.ProxyGetRatePlanChargeAllOf](docs/ProxyGetRatePlanChargeAllOf.md)
 - [Model.ProxyGetRatePlanChargeTier](docs/ProxyGetRatePlanChargeTier.md)
 - [Model.ProxyGetRefund](docs/ProxyGetRefund.md)
 - [Model.ProxyGetRefundAllOf](docs/ProxyGetRefundAllOf.md)
 - [Model.ProxyGetRefundInvoicePayment](docs/ProxyGetRefundInvoicePayment.md)
 - [Model.ProxyGetRefundTransactionLog](docs/ProxyGetRefundTransactionLog.md)
 - [Model.ProxyGetSubscription](docs/ProxyGetSubscription.md)
 - [Model.ProxyGetSubscriptionAllOf](docs/ProxyGetSubscriptionAllOf.md)
 - [Model.ProxyGetSubscriptionProductFeature](docs/ProxyGetSubscriptionProductFeature.md)
 - [Model.ProxyGetSubscriptionProductFeatureAllOf](docs/ProxyGetSubscriptionProductFeatureAllOf.md)
 - [Model.ProxyGetTaxationItem](docs/ProxyGetTaxationItem.md)
 - [Model.ProxyGetTaxationItemAllOf](docs/ProxyGetTaxationItemAllOf.md)
 - [Model.ProxyGetUnitOfMeasure](docs/ProxyGetUnitOfMeasure.md)
 - [Model.ProxyGetUsage](docs/ProxyGetUsage.md)
 - [Model.ProxyGetUsageAllOf](docs/ProxyGetUsageAllOf.md)
 - [Model.ProxyModifyAccount](docs/ProxyModifyAccount.md)
 - [Model.ProxyModifyAccountAllOf](docs/ProxyModifyAccountAllOf.md)
 - [Model.ProxyModifyAmendment](docs/ProxyModifyAmendment.md)
 - [Model.ProxyModifyAmendmentAllOf](docs/ProxyModifyAmendmentAllOf.md)
 - [Model.ProxyModifyBillRun](docs/ProxyModifyBillRun.md)
 - [Model.ProxyModifyContact](docs/ProxyModifyContact.md)
 - [Model.ProxyModifyContactAllOf](docs/ProxyModifyContactAllOf.md)
 - [Model.ProxyModifyCreditBalanceAdjustment](docs/ProxyModifyCreditBalanceAdjustment.md)
 - [Model.ProxyModifyCreditBalanceAdjustmentAllOf](docs/ProxyModifyCreditBalanceAdjustmentAllOf.md)
 - [Model.ProxyModifyFeature](docs/ProxyModifyFeature.md)
 - [Model.ProxyModifyFeatureAllOf](docs/ProxyModifyFeatureAllOf.md)
 - [Model.ProxyModifyInvoice](docs/ProxyModifyInvoice.md)
 - [Model.ProxyModifyInvoiceAdjustment](docs/ProxyModifyInvoiceAdjustment.md)
 - [Model.ProxyModifyInvoiceAdjustmentAllOf](docs/ProxyModifyInvoiceAdjustmentAllOf.md)
 - [Model.ProxyModifyInvoiceAllOf](docs/ProxyModifyInvoiceAllOf.md)
 - [Model.ProxyModifyInvoiceItemAdjustment](docs/ProxyModifyInvoiceItemAdjustment.md)
 - [Model.ProxyModifyInvoiceItemAdjustmentAllOf](docs/ProxyModifyInvoiceItemAdjustmentAllOf.md)
 - [Model.ProxyModifyInvoicePayment](docs/ProxyModifyInvoicePayment.md)
 - [Model.ProxyModifyPayment](docs/ProxyModifyPayment.md)
 - [Model.ProxyModifyPaymentAllOf](docs/ProxyModifyPaymentAllOf.md)
 - [Model.ProxyModifyPaymentMethod](docs/ProxyModifyPaymentMethod.md)
 - [Model.ProxyModifyPaymentMethodAllOf](docs/ProxyModifyPaymentMethodAllOf.md)
 - [Model.ProxyModifyProduct](docs/ProxyModifyProduct.md)
 - [Model.ProxyModifyProductAllOf](docs/ProxyModifyProductAllOf.md)
 - [Model.ProxyModifyProductRatePlan](docs/ProxyModifyProductRatePlan.md)
 - [Model.ProxyModifyProductRatePlanAllOf](docs/ProxyModifyProductRatePlanAllOf.md)
 - [Model.ProxyModifyProductRatePlanCharge](docs/ProxyModifyProductRatePlanCharge.md)
 - [Model.ProxyModifyProductRatePlanChargeAllOf](docs/ProxyModifyProductRatePlanChargeAllOf.md)
 - [Model.ProxyModifyProductRatePlanChargeTier](docs/ProxyModifyProductRatePlanChargeTier.md)
 - [Model.ProxyModifyRatePlanCharge](docs/ProxyModifyRatePlanCharge.md)
 - [Model.ProxyModifyRatePlanChargeAllOf](docs/ProxyModifyRatePlanChargeAllOf.md)
 - [Model.ProxyModifyRefund](docs/ProxyModifyRefund.md)
 - [Model.ProxyModifyRefundAllOf](docs/ProxyModifyRefundAllOf.md)
 - [Model.ProxyModifySubscription](docs/ProxyModifySubscription.md)
 - [Model.ProxyModifySubscriptionAllOf](docs/ProxyModifySubscriptionAllOf.md)
 - [Model.ProxyModifyTaxationItem](docs/ProxyModifyTaxationItem.md)
 - [Model.ProxyModifyTaxationItemAllOf](docs/ProxyModifyTaxationItemAllOf.md)
 - [Model.ProxyModifyUnitOfMeasure](docs/ProxyModifyUnitOfMeasure.md)
 - [Model.ProxyModifyUsage](docs/ProxyModifyUsage.md)
 - [Model.ProxyModifyUsageAllOf](docs/ProxyModifyUsageAllOf.md)
 - [Model.ProxyNoDataResponse](docs/ProxyNoDataResponse.md)
 - [Model.ProxyPostImport](docs/ProxyPostImport.md)
 - [Model.ProxyUnauthorizedResponse](docs/ProxyUnauthorizedResponse.md)
 - [Model.PutBatchInvoiceType](docs/PutBatchInvoiceType.md)
 - [Model.PutCreditMemoTaxItemType](docs/PutCreditMemoTaxItemType.md)
 - [Model.PutCreditMemoTaxItemTypeAllOf](docs/PutCreditMemoTaxItemTypeAllOf.md)
 - [Model.PutCreditMemoTaxItemTypeAllOfFinanceInformation](docs/PutCreditMemoTaxItemTypeAllOfFinanceInformation.md)
 - [Model.PutDebitMemoTaxItemType](docs/PutDebitMemoTaxItemType.md)
 - [Model.PutDebitMemoTaxItemTypeAllOf](docs/PutDebitMemoTaxItemTypeAllOf.md)
 - [Model.PutDebitMemoTaxItemTypeAllOfFinanceInformation](docs/PutDebitMemoTaxItemTypeAllOfFinanceInformation.md)
 - [Model.PutDiscountItemType](docs/PutDiscountItemType.md)
 - [Model.PutEventTriggerRequest](docs/PutEventTriggerRequest.md)
 - [Model.PutEventTriggerRequestEventType](docs/PutEventTriggerRequestEventType.md)
 - [Model.PutInvoiceItemType](docs/PutInvoiceItemType.md)
 - [Model.PutInvoiceItemTypeAllOf](docs/PutInvoiceItemTypeAllOf.md)
 - [Model.PutInvoiceResponseType](docs/PutInvoiceResponseType.md)
 - [Model.PutInvoiceResponseTypeAllOf](docs/PutInvoiceResponseTypeAllOf.md)
 - [Model.PutInvoiceType](docs/PutInvoiceType.md)
 - [Model.PutInvoiceTypeAllOf](docs/PutInvoiceTypeAllOf.md)
 - [Model.PutOrderLineItemResponseType](docs/PutOrderLineItemResponseType.md)
 - [Model.PutOrderLineItemUpdateType](docs/PutOrderLineItemUpdateType.md)
 - [Model.PutReverseCreditMemoResponseType](docs/PutReverseCreditMemoResponseType.md)
 - [Model.PutReverseCreditMemoResponseTypeCreditMemo](docs/PutReverseCreditMemoResponseTypeCreditMemo.md)
 - [Model.PutReverseCreditMemoResponseTypeDebitMemo](docs/PutReverseCreditMemoResponseTypeDebitMemo.md)
 - [Model.PutReverseCreditMemoType](docs/PutReverseCreditMemoType.md)
 - [Model.PutReverseInvoiceResponseType](docs/PutReverseInvoiceResponseType.md)
 - [Model.PutReverseInvoiceResponseTypeCreditMemo](docs/PutReverseInvoiceResponseTypeCreditMemo.md)
 - [Model.PutReverseInvoiceResponseTypeDebitMemo](docs/PutReverseInvoiceResponseTypeDebitMemo.md)
 - [Model.PutReverseInvoiceType](docs/PutReverseInvoiceType.md)
 - [Model.PutTasksRequest](docs/PutTasksRequest.md)
 - [Model.QueryCustomObjectRecordsResponse](docs/QueryCustomObjectRecordsResponse.md)
 - [Model.QuoteObjectFields](docs/QuoteObjectFields.md)
 - [Model.RampChargeRequest](docs/RampChargeRequest.md)
 - [Model.RampChargeResponse](docs/RampChargeResponse.md)
 - [Model.RampIntervalChargeDeltaMetrics](docs/RampIntervalChargeDeltaMetrics.md)
 - [Model.RampIntervalChargeDeltaMetricsDeltaMrrInner](docs/RampIntervalChargeDeltaMetricsDeltaMrrInner.md)
 - [Model.RampIntervalChargeDeltaMetricsDeltaQuantityInner](docs/RampIntervalChargeDeltaMetricsDeltaQuantityInner.md)
 - [Model.RampIntervalChargeMetrics](docs/RampIntervalChargeMetrics.md)
 - [Model.RampIntervalChargeMetricsMrrInner](docs/RampIntervalChargeMetricsMrrInner.md)
 - [Model.RampIntervalMetrics](docs/RampIntervalMetrics.md)
 - [Model.RampIntervalRequest](docs/RampIntervalRequest.md)
 - [Model.RampIntervalResponse](docs/RampIntervalResponse.md)
 - [Model.RampMetrics](docs/RampMetrics.md)
 - [Model.RampRequest](docs/RampRequest.md)
 - [Model.RampResponse](docs/RampResponse.md)
 - [Model.RatePlan](docs/RatePlan.md)
 - [Model.RatePlanAllOf](docs/RatePlanAllOf.md)
 - [Model.RatePlanChargeData](docs/RatePlanChargeData.md)
 - [Model.RatePlanChargeDataInRatePlanData](docs/RatePlanChargeDataInRatePlanData.md)
 - [Model.RatePlanChargeDataInRatePlanDataRatePlanCharge](docs/RatePlanChargeDataInRatePlanDataRatePlanCharge.md)
 - [Model.RatePlanChargeDataInRatePlanDataRatePlanChargeAllOf](docs/RatePlanChargeDataInRatePlanDataRatePlanChargeAllOf.md)
 - [Model.RatePlanChargeDataRatePlanCharge](docs/RatePlanChargeDataRatePlanCharge.md)
 - [Model.RatePlanChargeDataRatePlanChargeAllOf](docs/RatePlanChargeDataRatePlanChargeAllOf.md)
 - [Model.RatePlanChargeTier](docs/RatePlanChargeTier.md)
 - [Model.RatePlanData](docs/RatePlanData.md)
 - [Model.RatePlanDataRatePlan](docs/RatePlanDataRatePlan.md)
 - [Model.RatePlanDataRatePlanAllOf](docs/RatePlanDataRatePlanAllOf.md)
 - [Model.RatePlanDataSubscriptionProductFeatureList](docs/RatePlanDataSubscriptionProductFeatureList.md)
 - [Model.RatePlanOverride](docs/RatePlanOverride.md)
 - [Model.RatePlanOverrideForEvergreen](docs/RatePlanOverrideForEvergreen.md)
 - [Model.RatePlanUpdate](docs/RatePlanUpdate.md)
 - [Model.RatePlanUpdateForEvergreen](docs/RatePlanUpdateForEvergreen.md)
 - [Model.RecurringFlatFeePricingOverride](docs/RecurringFlatFeePricingOverride.md)
 - [Model.RecurringFlatFeePricingUpdate](docs/RecurringFlatFeePricingUpdate.md)
 - [Model.RecurringPerUnitPricingOverride](docs/RecurringPerUnitPricingOverride.md)
 - [Model.RecurringPerUnitPricingUpdate](docs/RecurringPerUnitPricingUpdate.md)
 - [Model.RecurringTieredPricingOverride](docs/RecurringTieredPricingOverride.md)
 - [Model.RecurringTieredPricingOverrideAllOf](docs/RecurringTieredPricingOverrideAllOf.md)
 - [Model.RecurringTieredPricingUpdate](docs/RecurringTieredPricingUpdate.md)
 - [Model.RecurringTieredPricingUpdateAllOf](docs/RecurringTieredPricingUpdateAllOf.md)
 - [Model.RecurringVolumePricingOverride](docs/RecurringVolumePricingOverride.md)
 - [Model.RecurringVolumePricingOverrideAllOf](docs/RecurringVolumePricingOverrideAllOf.md)
 - [Model.RecurringVolumePricingUpdate](docs/RecurringVolumePricingUpdate.md)
 - [Model.RefundCreditMemoItemType](docs/RefundCreditMemoItemType.md)
 - [Model.RefundEntityPrefix](docs/RefundEntityPrefix.md)
 - [Model.RefundInvoicePayment](docs/RefundInvoicePayment.md)
 - [Model.RefundObjectNSFields](docs/RefundObjectNSFields.md)
 - [Model.RefundPartResponseType](docs/RefundPartResponseType.md)
 - [Model.RefundPartResponseTypewithSuccess](docs/RefundPartResponseTypewithSuccess.md)
 - [Model.RemoveProduct](docs/RemoveProduct.md)
 - [Model.RenewSubscription](docs/RenewSubscription.md)
 - [Model.RenewalTerm](docs/RenewalTerm.md)
 - [Model.ResendCalloutNotificationsFailedResponseValue](docs/ResendCalloutNotificationsFailedResponseValue.md)
 - [Model.ResendEmailNotificationsFailedResponseValue](docs/ResendEmailNotificationsFailedResponseValue.md)
 - [Model.RevenueScheduleItemType](docs/RevenueScheduleItemType.md)
 - [Model.RevproAccountingCodes](docs/RevproAccountingCodes.md)
 - [Model.SaveResult](docs/SaveResult.md)
 - [Model.SettingItemHttpOperation](docs/SettingItemHttpOperation.md)
 - [Model.SettingItemHttpRequestParameter](docs/SettingItemHttpRequestParameter.md)
 - [Model.SettingItemWithOperationsInformation](docs/SettingItemWithOperationsInformation.md)
 - [Model.SettingValueRequest](docs/SettingValueRequest.md)
 - [Model.SettingValueResponse](docs/SettingValueResponse.md)
 - [Model.SettingValueResponseWrapper](docs/SettingValueResponseWrapper.md)
 - [Model.SettingsBatchRequest](docs/SettingsBatchRequest.md)
 - [Model.SettingsBatchResponse](docs/SettingsBatchResponse.md)
 - [Model.SoldToContact](docs/SoldToContact.md)
 - [Model.SoldToContactAllOf](docs/SoldToContactAllOf.md)
 - [Model.SoldToContactPostOrder](docs/SoldToContactPostOrder.md)
 - [Model.SoldToContactPostOrderAllOf](docs/SoldToContactPostOrderAllOf.md)
 - [Model.SubmitDataQueryRequest](docs/SubmitDataQueryRequest.md)
 - [Model.SubmitDataQueryRequestOutput](docs/SubmitDataQueryRequestOutput.md)
 - [Model.SubmitDataQueryResponse](docs/SubmitDataQueryResponse.md)
 - [Model.SubscribeRequest](docs/SubscribeRequest.md)
 - [Model.SubscribeRequestAccount](docs/SubscribeRequestAccount.md)
 - [Model.SubscribeRequestAccountAllOf](docs/SubscribeRequestAccountAllOf.md)
 - [Model.SubscribeRequestBillToContact](docs/SubscribeRequestBillToContact.md)
 - [Model.SubscribeRequestBillToContactAllOf](docs/SubscribeRequestBillToContactAllOf.md)
 - [Model.SubscribeRequestPaymentMethod](docs/SubscribeRequestPaymentMethod.md)
 - [Model.SubscribeRequestPaymentMethodGatewayOptionData](docs/SubscribeRequestPaymentMethodGatewayOptionData.md)
 - [Model.SubscribeRequestPreviewOptions](docs/SubscribeRequestPreviewOptions.md)
 - [Model.SubscribeRequestSoldToContact](docs/SubscribeRequestSoldToContact.md)
 - [Model.SubscribeRequestSoldToContactAllOf](docs/SubscribeRequestSoldToContactAllOf.md)
 - [Model.SubscribeRequestSubscribeOptions](docs/SubscribeRequestSubscribeOptions.md)
 - [Model.SubscribeRequestSubscribeOptionsElectronicPaymentOptions](docs/SubscribeRequestSubscribeOptionsElectronicPaymentOptions.md)
 - [Model.SubscribeRequestSubscribeOptionsExternalPaymentOptions](docs/SubscribeRequestSubscribeOptionsExternalPaymentOptions.md)
 - [Model.SubscribeRequestSubscribeOptionsSubscribeInvoiceProcessingOptions](docs/SubscribeRequestSubscribeOptionsSubscribeInvoiceProcessingOptions.md)
 - [Model.SubscribeRequestSubscriptionData](docs/SubscribeRequestSubscriptionData.md)
 - [Model.SubscribeRequestSubscriptionDataSubscription](docs/SubscribeRequestSubscriptionDataSubscription.md)
 - [Model.SubscribeRequestSubscriptionDataSubscriptionAllOf](docs/SubscribeRequestSubscriptionDataSubscriptionAllOf.md)
 - [Model.SubscribeResult](docs/SubscribeResult.md)
 - [Model.SubscribeResultChargeMetricsData](docs/SubscribeResultChargeMetricsData.md)
 - [Model.SubscribeResultInvoiceResult](docs/SubscribeResultInvoiceResult.md)
 - [Model.SubscribeResultInvoiceResultInvoiceInner](docs/SubscribeResultInvoiceResultInvoiceInner.md)
 - [Model.SubscriptionObjectNSFields](docs/SubscriptionObjectNSFields.md)
 - [Model.SubscriptionObjectQTFields](docs/SubscriptionObjectQTFields.md)
 - [Model.SubscriptionProductFeature](docs/SubscriptionProductFeature.md)
 - [Model.SubscriptionProductFeatureAllOf](docs/SubscriptionProductFeatureAllOf.md)
 - [Model.SubscriptionProductFeatureList](docs/SubscriptionProductFeatureList.md)
 - [Model.Task](docs/Task.md)
 - [Model.TasksResponse](docs/TasksResponse.md)
 - [Model.TasksResponsePagination](docs/TasksResponsePagination.md)
 - [Model.TaxInfo](docs/TaxInfo.md)
 - [Model.TaxItems](docs/TaxItems.md)
 - [Model.Term](docs/Term.md)
 - [Model.TermsAndConditions](docs/TermsAndConditions.md)
 - [Model.TimeSlicedElpNetMetrics](docs/TimeSlicedElpNetMetrics.md)
 - [Model.TimeSlicedMetrics](docs/TimeSlicedMetrics.md)
 - [Model.TimeSlicedMetricsForEvergreen](docs/TimeSlicedMetricsForEvergreen.md)
 - [Model.TimeSlicedNetMetrics](docs/TimeSlicedNetMetrics.md)
 - [Model.TimeSlicedNetMetricsForEvergreen](docs/TimeSlicedNetMetricsForEvergreen.md)
 - [Model.TimeSlicedTcbNetMetrics](docs/TimeSlicedTcbNetMetrics.md)
 - [Model.TimeSlicedTcbNetMetricsForEvergreen](docs/TimeSlicedTcbNetMetricsForEvergreen.md)
 - [Model.TokenResponse](docs/TokenResponse.md)
 - [Model.TransferPaymentType](docs/TransferPaymentType.md)
 - [Model.TriggerDate](docs/TriggerDate.md)
 - [Model.TriggerParams](docs/TriggerParams.md)
 - [Model.UnapplyCreditMemoType](docs/UnapplyCreditMemoType.md)
 - [Model.UnapplyPaymentType](docs/UnapplyPaymentType.md)
 - [Model.UpdateCustomObjectCusotmField](docs/UpdateCustomObjectCusotmField.md)
 - [Model.UpdateEntityResponseType](docs/UpdateEntityResponseType.md)
 - [Model.UpdateEntityType](docs/UpdateEntityType.md)
 - [Model.UpdatePaymentType](docs/UpdatePaymentType.md)
 - [Model.UpdatePaymentTypeAllOf](docs/UpdatePaymentTypeAllOf.md)
 - [Model.UpdatePaymentTypeAllOfFinanceInformation](docs/UpdatePaymentTypeAllOfFinanceInformation.md)
 - [Model.UpdateTask](docs/UpdateTask.md)
 - [Model.Usage](docs/Usage.md)
 - [Model.UsageFlatFeePricingOverride](docs/UsageFlatFeePricingOverride.md)
 - [Model.UsageFlatFeePricingUpdate](docs/UsageFlatFeePricingUpdate.md)
 - [Model.UsageOveragePricingOverride](docs/UsageOveragePricingOverride.md)
 - [Model.UsageOveragePricingUpdate](docs/UsageOveragePricingUpdate.md)
 - [Model.UsagePerUnitPricingOverride](docs/UsagePerUnitPricingOverride.md)
 - [Model.UsagePerUnitPricingOverrideAllOf](docs/UsagePerUnitPricingOverrideAllOf.md)
 - [Model.UsagePerUnitPricingUpdate](docs/UsagePerUnitPricingUpdate.md)
 - [Model.UsageTieredPricingOverride](docs/UsageTieredPricingOverride.md)
 - [Model.UsageTieredPricingOverrideAllOf](docs/UsageTieredPricingOverrideAllOf.md)
 - [Model.UsageTieredPricingUpdate](docs/UsageTieredPricingUpdate.md)
 - [Model.UsageTieredPricingUpdateAllOf](docs/UsageTieredPricingUpdateAllOf.md)
 - [Model.UsageTieredWithOveragePricingOverride](docs/UsageTieredWithOveragePricingOverride.md)
 - [Model.UsageTieredWithOveragePricingOverrideAllOf](docs/UsageTieredWithOveragePricingOverrideAllOf.md)
 - [Model.UsageTieredWithOveragePricingUpdate](docs/UsageTieredWithOveragePricingUpdate.md)
 - [Model.UsageTieredWithOveragePricingUpdateAllOf](docs/UsageTieredWithOveragePricingUpdateAllOf.md)
 - [Model.UsageValues](docs/UsageValues.md)
 - [Model.UsageVolumePricingOverride](docs/UsageVolumePricingOverride.md)
 - [Model.UsageVolumePricingOverrideAllOf](docs/UsageVolumePricingOverrideAllOf.md)
 - [Model.UsageVolumePricingUpdate](docs/UsageVolumePricingUpdate.md)
 - [Model.UsagesResponse](docs/UsagesResponse.md)
 - [Model.ValidationErrors](docs/ValidationErrors.md)
 - [Model.ValidationReasons](docs/ValidationReasons.md)
 - [Model.Workflow](docs/Workflow.md)
 - [Model.WorkflowDefinition](docs/WorkflowDefinition.md)
 - [Model.WorkflowDefinitionActiveVersion](docs/WorkflowDefinitionActiveVersion.md)
 - [Model.WorkflowDefinitionAndVersions](docs/WorkflowDefinitionAndVersions.md)
 - [Model.WorkflowError](docs/WorkflowError.md)
 - [Model.WorkflowInstance](docs/WorkflowInstance.md)
 - [Model.ZObjectUpdate](docs/ZObjectUpdate.md)
 - [Model.ZObjectUpdateAllOf](docs/ZObjectUpdateAllOf.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

All endpoints do not require authorization.
