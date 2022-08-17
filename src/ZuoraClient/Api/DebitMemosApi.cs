/*
 * API Reference: Billing
 *
 *   # Introduction  Welcome to the reference for the Zuora Billing REST API!  To learn about the common use cases of Zuora Billing REST APIs, check out the [API Guides](https://www.zuora.com/developer/api-guides/).  In addition to Zuora API Reference; Billing, we also provide API references for other Zuora products:    * [API Reference: Collections](https://www.zuora.com/developer/collect-api/)   * [API Reference: Revenue](https://www.zuora.com/developer/revpro-api/)      The Zuora REST API provides a broad set of operations and resources that:    * Enable Web Storefront integration from your website.   * Support self-service subscriber sign-ups and account management.   * Process revenue schedules through custom revenue rule models.   * Enable manipulation of most objects in the Zuora Billing Object Model.  Want to share your opinion on how our API works for you? <a href=\"https://community.zuora.com/t5/Developers/API-Feedback-Form/gpm-p/21399\" target=\"_blank\">Tell us how you feel </a>about using our API and what we can do to make it better.  ## Access to the API  If you have a Zuora tenant, you can access the Zuora REST API via one of the following endpoints:  | Tenant              | Base URL for REST Endpoints | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- --| |US Cloud 1 Production | https://rest.na.zuora.com  | |US Cloud 1 API Sandbox |  https://rest.sandbox.na.zuora.com | |US Cloud 2 Production | https://rest.zuora.com | |US Cloud 2 API Sandbox | https://rest.apisandbox.zuora.com| |US Central Sandbox | https://rest.test.zuora.com |   |US Performance Test | https://rest.pt1.zuora.com | |US Production Copy | Submit a request at <a href=\"http://support.zuora.com/\" target=\"_blank\">Zuora Global Support</a> to enable the Zuora REST API in your tenant and obtain the base URL for REST endpoints. See [REST endpoint base URL of Production Copy (Service) Environment for existing and new customers](https://community.zuora.com/t5/API/REST-endpoint-base-URL-of-Production-Copy-Service-Environment/td-p/29611) for more information. | |EU Production | https://rest.eu.zuora.com | |EU API Sandbox | https://rest.sandbox.eu.zuora.com | |EU Central Sandbox | https://rest.test.eu.zuora.com |  The Production endpoint provides access to your live user data. Sandbox tenants are a good place to test code without affecting real-world data. If you would like Zuora to provision a Sandbox tenant for you, contact your Zuora representative for assistance.   If you do not have a Zuora tenant, go to <a href=\"https://www.zuora.com/resource/zuora-test-drive\" target=\"_blank\">https://www.zuora.com/resource/zuora-test-drive</a> and sign up for a Production Test Drive tenant. The tenant comes with seed data, including a sample product catalog.  # API Changelog You can find the <a href=\"https://bit.ly/3JGqyR3\" target=\"_blank\">Changelog</a> of the API Reference: Billing in the Zuora Community.  # Authentication  ## OAuth v2.0  Zuora recommends that you use OAuth v2.0 to authenticate to the Zuora REST API. Currently, OAuth is not available in every environment. See [Zuora Testing Environments](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Zuora_Environments) for more information.  Zuora recommends you to create a dedicated API user with API write access on a tenant when authenticating via OAuth, and then create an OAuth client for this user. See <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">Create an API User</a> for how to do this. By creating a dedicated API user, you can control permissions of the API user without affecting other non-API users.  If a user is deactivated, all of the user's OAuth clients will be automatically deactivated.  Authenticating via OAuth requires the following steps: 1. Create a Client 2. Generate a Token 3. Make Authenticated Requests  ### Create a Client  You must first [create an OAuth client](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users#Create_an_OAuth_Client_for_a_User) in the Zuora UI. To do this, you must be an administrator of your Zuora tenant. This is a one-time operation. You will be provided with a Client ID and a Client Secret. Please note this information down, as it will be required for the next step.  **Note:** The OAuth client will be owned by a Zuora user account. If you want to perform PUT, POST, or DELETE operations using the OAuth client, the owner of the OAuth client must have a Platform role that includes the \"API Write Access\" permission.  ### Generate a Token  After creating a client, you must make a call to obtain a bearer token using the [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) operation. This operation requires the following parameters: - `client_id` - the Client ID displayed when you created the OAuth client in the previous step - `client_secret` - the Client Secret displayed when you created the OAuth client in the previous step - `grant_type` - must be set to `client_credentials`  **Note**: The Client ID and Client Secret mentioned above were displayed when you created the OAuth Client in the prior step. The [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) response specifies how long the bearer token is valid for. You should reuse the bearer token until it is expired. When the token is expired, call [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) again to generate a new one.  ### Make Authenticated Requests  To authenticate subsequent API requests, you must provide a valid bearer token in an HTTP header:  `Authorization: Bearer {bearer_token}`  If you have [Zuora Multi-entity](https://www.zuora.com/developer/api-reference/#tag/Entities) enabled, you need to set an additional header to specify the ID of the entity that you want to access. You can use the `scope` field in the [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) response to determine whether you need to specify an entity ID.  If the `scope` field contains more than one entity ID, you must specify the ID of the entity that you want to access. For example, if the `scope` field contains `entity.1a2b7a37-3e7d-4cb3-b0e2-883de9e766cc` and `entity.c92ed977-510c-4c48-9b51-8d5e848671e9`, specify one of the following headers: - `Zuora-Entity-Ids: 1a2b7a37-3e7d-4cb3-b0e2-883de9e766cc` - `Zuora-Entity-Ids: c92ed977-510c-4c48-9b51-8d5e848671e9`  **Note**: For a limited period of time, Zuora will accept the `entityId` header as an alternative to the `Zuora-Entity-Ids` header. If you choose to set the `entityId` header, you must remove all \"-\" characters from the entity ID in the `scope` field.  If the `scope` field contains a single entity ID, you do not need to specify an entity ID.  ## Other Supported Authentication Schemes  Zuora continues to support the following additional legacy means of authentication:    * Use username and password. Include authentication with each request in the header:         * `apiAccessKeyId`      * `apiSecretAccessKey`          Zuora recommends that you create an API user specifically for making API calls. See <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">Create an API User</a> for more information.      * Use an authorization cookie. The cookie authorizes the user to make calls to the REST API for the duration specified in  **Administration > Security Policies > Session timeout**. The cookie expiration time is reset with this duration after every call to the REST API. To obtain a cookie, call the [Connections](https://www.zuora.com/developer/api-reference/#tag/Connections) resource with the following API user information:         *   ID         *   Password        * For CORS-enabled APIs only: Include a 'single-use' token in the request header, which re-authenticates the user with each request. See below for more details.  ### Entity Id and Entity Name  The `entityId` and `entityName` parameters are only used for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Zuora Multi-entity\"). These are the legacy parameters that Zuora will only continue to support for a period of time. Zuora recommends you to use the `Zuora-Entity-Ids` parameter instead.   The  `entityId` and `entityName` parameters specify the Id and the [name of the entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/B_Introduction_to_Entity_and_Entity_Hierarchy#Name_and_Display_Name \"Introduction to Entity and Entity Hierarchy\") that you want to access, respectively. Note that you must have permission to access the entity.   You can specify either the `entityId` or `entityName` parameter in the authentication to access and view an entity.    * If both `entityId` and `entityName` are specified in the authentication, an error occurs.    * If neither `entityId` nor `entityName` is specified in the authentication, you will log in to the entity in which your user account is created.      To get the entity Id and entity name, you can use the GET Entities REST call. For more information, see [API User Authentication](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/A_Overview_of_Multi-entity#API_User_Authentication \"API User Authentication\").      ### Token Authentication for CORS-Enabled APIs      The CORS mechanism enables REST API calls to Zuora to be made directly from your customer's browser, with all credit card and security information transmitted directly to Zuora. This minimizes your PCI compliance burden, allows you to implement advanced validation on your payment forms, and  makes your payment forms look just like any other part of your website.    For security reasons, instead of using cookies, an API request via CORS uses **tokens** for authentication.  The token method of authentication is only designed for use with requests that must originate from your customer's browser; **it should  not be considered a replacement to the existing cookie authentication** mechanism.  See [Zuora CORS REST](https://knowledgecenter.zuora.com/DC_Developers/C_REST_API/Zuora_CORS_REST \"Zuora CORS REST\") for details on how CORS works and how you can begin to implement customer calls to the Zuora REST APIs. See  [HMAC Signatures](https://www.zuora.com/developer/api-reference/#operation/POSTHMACSignature \"HMAC Signatures\") for details on the HMAC method that returns the authentication token.  # Requests and Responses  ## Request IDs  As a general rule, when asked to supply a \"key\" for an account or subscription (accountKey, account-key, subscriptionKey, subscription-key), you can provide either the actual ID or  the number of the entity.  ## HTTP Request Body  Most of the parameters and data accompanying your requests will be contained in the body of the HTTP request.   The Zuora REST API accepts JSON in the HTTP request body. No other data format (e.g., XML) is supported.  ### Data Type  ([Actions](https://www.zuora.com/developer/api-reference/#tag/Actions) and CRUD operations only) We recommend that you do not specify the decimal values with quotation marks, commas, and spaces. Use characters of `+-0-9.eE`, for example, `5`, `1.9`, `-8.469`, and `7.7e2`. Also, Zuora does not convert currencies for decimal values.   ## Making asynchronous requests  Most Zuora REST API endpoints documented in this API Reference process requests synchronously. In high-throughput scenarios, your requests to these endpoints are usually rate limited.   One strategy for avoiding rate limits is to make asynchronous requests, and Zuora provides this option to you.  Making asynchronous requests allows you to scale your applications more efficiently by leveraging Zuora's infrastructure to enqueue and execute requests for you without blocking. These requests also use built-in retry semantics, which makes them much less likely to fail for non-deterministic reasons, even in extreme high-throughput scenarios.  Meanwhile, when you send a request to one of these endpoints, you can receive a response in less than 150 milliseconds and these calls are unlikely to trigger rate limit errors.   You can make asynchronous requests to the POST, PUT, or DELETE operations, except [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions), for all resources documented in this API Reference.  Take the following steps to take advantage of the asynchronous API:    1. Set up callout notification   2. Make asynchronous requests  The following sections describes the high-level steps for you to get the most of the asynchronous API. For detailed instructions, see [Make asynchronous requests](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Make_asynchronous_requests) in the Knowledge Center.   ### Set up notifications  You can create callout notification definitions based on the following custom events through the Zuora UI or the [Create a notification definition](https://www.zuora.com/developer/api-reference/#operation/POST_Create_Notification_Definition) API operation:   * Async Request Succeeded   * Async Request Failed  This step ensures that your system receives a callout when an asynchronous request succeeds or fails.   ### Make asynchronous requests  By design, asynchronous requests differ from their synchronous counterparts in endpoints, and the HTTP status response code and response body they return. ​​The header parameters and request body schema for asynchronous operations are the same as their synchronous counterparts.   * The endpoints for asynchronous API operations contain `/async` in the path after `/v1`. See the following table for examples:  | Operation               | Synchronous endpoint  | Asynchronous endpoint      | |:- -- -- -- - |:- -- -- -- - |:- -- -- -- - | | Create an account       | `/v1/accounts`        | `/v1/async/accounts`       | | CRUD: Create an account | `/v1/object/account`  | `/v1/async/object/account` |  * Unlike the 200 OK response for synchronous requests, Zuora returns a 202 Accepted response for all asynchronous requests, and the response body contains only a request ID.   **Note**: These asynchronous API endpoints are in addition to the previously introduced endpoints that support asynchronous processing. You should continue to use them:   * [Perform a mass action](https://www.zuora.com/developer/api-reference/#operation/POST_MassUpdater)   * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously)   * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)   * [Create a job to hard delete billing document files](https://www.zuora.com/developer/api-reference/#operation/POST_BillingDocumentFilesDeletionJob)   * [CRUD: Post or cancel a bill run](https://www.zuora.com/developer/api-reference/#operation/Object_PUTBillRun)   * [Cancel a journal run](https://www.zuora.com/developer/api-reference/#operation/PUT_JournalRun)   * [Run trial balance](https://www.zuora.com/developer/api-reference/#operation/PUT_RunTrialBalance)  For more information, see [Make asynchronous requests](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Make_asynchronous_requests).  ## Testing a Request  Use a third party client, such as [curl](https://curl.haxx.se \"curl\"), [Postman](https://www.getpostman.com \"Postman\"), or [Advanced REST Client](https://advancedrestclient.com \"Advanced REST Client\"), to test the Zuora REST API.  You can test the Zuora REST API from the Zuora API Sandbox or Production tenants. If connecting to Production, bear in mind that you are working with your live production data, not sample data or test data.  ## Testing with Credit Cards  Sooner or later it will probably be necessary to test some transactions that involve credit cards. For suggestions on how to handle this, see [Going Live With Your Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards \"C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards\" ).  ## Concurrent Request Limits  Zuora enforces tenant-level concurrent request limits. See <a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits\" target=\"_blank\">Concurrent Request Limits</a> for more information.  ## Timeout Limit  If a request does not complete within 120 seconds, the request times out and Zuora returns a Gateway Timeout error.   # Error Handling  If a request to Zuora Billing REST API with an endpoint starting with `/v1` (except [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions) and CRUD operations) fails, the response will contain an eight-digit error code with a corresponding error message to indicate the details of the error.  The following code snippet is a sample error response that contains an error code and message pair:  ```  {    \"success\": false,    \"processId\": \"CBCFED6580B4E076\",    \"reasons\":  [      {       \"code\": 53100320,       \"message\": \"'termType' value should be one of: TERMED, EVERGREEN\"      }     ]  } ``` The `success` field indicates whether the API request has succeeded. The `processId` field is a Zuora internal ID that you can provide to Zuora Global Support for troubleshooting purposes.  The `reasons` field contains the actual error code and message pair. The error code begins with `5` or `6` means that you encountered a certain issue that is specific to a REST API resource in Zuora Billing. For example, `53100320` indicates that an invalid value is specified for the `termType` field of the `subscription` object.  The error code beginning with `9` usually indicates that an authentication-related issue occurred, and it can also indicate other unexpected errors depending on different cases. For example, `90000011` indicates that an invalid credential is provided in the request header.   When troubleshooting the error, you can divide the error code into two components: REST API resource code and error category code. See the following Zuora error code sample:  <a href=\"https://assets.zuora.com/zuora-documentation/ZuoraErrorCode.jpeg\" target=\"_blank\"><img src=\"https://assets.zuora.com/zuora-documentation/ZuoraErrorCode.jpeg\" alt=\"Zuora Error Code Sample\"></a>   **Note:** Zuora determines resource codes based on the request payload. Therefore, if GET and DELETE requests that do not contain payloads fail, you will get `500000` as the resource code, which indicates an unknown object and an unknown field.  The error category code of these requests is valid and follows the rules described in the [Error Category Code](https://www.zuora.com/developer/api-reference/#section/Error-Handling/Error-Category-Code) section.  In such case, you can refer to the returned error message to troubleshoot.   ## REST API Resource Codes  The 6-digit resource code indicates the REST API resource, typically a field of a Zuora object, on which the issue occurs. In the preceding example, `531003` refers to the `termType` field of the `subscription` object.   The value range for all REST API resource codes is from `500000` to `679999`. See [Resource Codes](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Resource_Codes) in the Knowledge Center for a full list of resource codes.  ## Error Category Codes  The 2-digit error category code identifies the type of error, for example, resource not found or missing required field.   The following table describes all error categories and the corresponding resolution:  | Code    | Error category              | Description    | Resolution    | |:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -| | 10      | Permission or access denied | The request cannot be processed because a certain tenant or user permission is missing. | Check the missing tenant or user permission in the response message and contact [Zuora Global Support](https://support.zuora.com) for enablement. | | 11      | Authentication failed       | Authentication fails due to invalid API authentication credentials. | Ensure that a valid API credential is specified. | | 20      | Invalid format or value     | The request cannot be processed due to an invalid field format or value. | Check the invalid field in the error message, and ensure that the format and value of all fields you passed in are valid. | | 21      | Unknown field in request    | The request cannot be processed because an unknown field exists in the request body. | Check the unknown field name in the response message, and ensure that you do not include any unknown field in the request body. | | 22      | Missing required field      | The request cannot be processed because a required field in the request body is missing. | Check the missing field name in the response message, and ensure that you include all required fields in the request body. | | 23      | Missing required parameter  | The request cannot be processed because a required query parameter is missing. | Check the missing parameter name in the response message, and ensure that you include the parameter in the query. | | 30      | Rule restriction            | The request cannot be processed due to the violation of a Zuora business rule. | Check the response message and ensure that the API request meets the specified business rules. | | 40      | Not found                   | The specified resource cannot be found. | Check the response message and ensure that the specified resource exists in your Zuora tenant. | | 45      | Unsupported request         | The requested endpoint does not support the specified HTTP method. | Check your request and ensure that the endpoint and method matches. | | 50      | Locking contention          | This request cannot be processed because the objects this request is trying to modify are being modified by another API request, UI operation, or batch job process. | <p>Resubmit the request first to have another try.</p> <p>If this error still occurs, contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance.</p> | | 60      | Internal error              | The server encounters an internal error. | Contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance. | | 61      | Temporary error             | A temporary error occurs during request processing, for example, a database communication error. | <p>Resubmit the request first to have another try.</p> <p>If this error still occurs, contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance. </p>| | 70      | Request exceeded limit      | The total number of concurrent requests exceeds the limit allowed by the system. | <p>Resubmit the request after the number of seconds specified by the `Retry-After` value in the response header.</p> <p>Check [Concurrent request limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits) for details about Zuora’s concurrent request limit policy.</p> | | 90      | Malformed request           | The request cannot be processed due to JSON syntax errors. | Check the syntax error in the JSON request body and ensure that the request is in the correct JSON format. | | 99      | Integration error           | The server encounters an error when communicating with an external system, for example, payment gateway, tax engine provider. | Check the response message and take action accordingly. |   # Pagination  When retrieving information (using GET methods), the optional `pageSize` query parameter sets the maximum number of rows to return in a response. The maximum is `40`; larger values are treated as `40`. If this value is empty or invalid, `pageSize` typically defaults to `10`.  The default value for the maximum number of rows retrieved can be overridden at the method level.  If more rows are available, the response will include a `nextPage` element, which contains a URL for requesting the next page.  If this value is not provided, no more rows are available. No \"previous page\" element is explicitly provided; to support backward paging, use the previous call.  ## Array Size  For data items that are not paginated, the REST API supports arrays of up to 300 rows.  Thus, for instance, repeated pagination can retrieve thousands of customer accounts, but within any account an array of no more than 300 rate plans is returned.  # API Versions  The Zuora REST API are version controlled. Versioning ensures that Zuora REST API changes are backward compatible. Zuora uses a major and minor version nomenclature to manage changes. By specifying a version in a REST request, you can get expected responses regardless of future changes to the API.  ## Major Version  The major version number of the REST API appears in the REST URL. Currently, Zuora only supports the **v1** major version. For example, `POST https://rest.zuora.com/v1/subscriptions`.  ## Minor Version  Zuora uses minor versions for the REST API to control small changes. For example, a field in a REST method is deprecated and a new field is used to replace it.   Some fields in the REST methods are supported as of minor versions. If a field is not noted with a minor version, this field is available for all minor versions. If a field is noted with a minor version, this field is in version control. You must specify the supported minor version in the request header to process without an error.   If a field is in version control, it is either with a minimum minor version or a maximum minor version, or both of them. You can only use this field with the minor version between the minimum and the maximum minor versions. For example, the `invoiceCollect` field in the POST Subscription method is in version control and its maximum minor version is 189.0. You can only use this field with the minor version 189.0 or earlier.  If you specify a version number in the request header that is not supported, Zuora will use the minimum minor version of the REST API. In our REST API documentation, if a field or feature requires a minor version number, we note that in the field description.  You only need to specify the version number when you use the fields require a minor version. To specify the minor version, set the `zuora-version` parameter to the minor version number in the request header for the request call. For example, the `collect` field is in 196.0 minor version. If you want to use this field for the POST Subscription method, set the  `zuora-version` parameter to `196.0` in the request header. The `zuora-version` parameter is case sensitive.  For all the REST API fields, by default, if the minor version is not specified in the request header, Zuora will use the minimum minor version of the REST API to avoid breaking your integration.   ### Minor Version History  The supported minor versions are not serial. This section documents the changes made to each Zuora REST API minor version.  The following table lists the supported versions and the fields that have a Zuora REST API minor version.  | Fields         | Minor Version      | REST Methods    | Description | |:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -| | invoiceCollect | 189.0 and earlier  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice and collects a payment for a subscription. | | collect        | 196.0 and later    | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Collects an automatic payment for a subscription. | | invoice | 196.0 and 207.0| [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice for a subscription. | | invoiceTargetDate | 196.0 and earlier  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") |Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | invoiceTargetDate | 207.0 and earlier  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | targetDate | 207.0 and later | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") |Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | targetDate | 211.0 and later | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | includeExisting DraftInvoiceItems | 196.0 and earlier| [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | Specifies whether to include draft invoice items in subscription previews. Specify it to be `true` (default) to include draft invoice items in the preview result. Specify it to be `false` to excludes draft invoice items in the preview result. | | includeExisting DraftDocItems | 207.0 and later  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | Specifies whether to include draft invoice items in subscription previews. Specify it to be `true` (default) to include draft invoice items in the preview result. Specify it to be `false` to excludes draft invoice items in the preview result. | | previewType | 196.0 and earlier| [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | The type of preview you will receive. The possible values are `InvoiceItem`(default), `ChargeMetrics`, and `InvoiceItemChargeMetrics`. | | previewType | 207.0 and later  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | The type of preview you will receive. The possible values are `LegalDoc`(default), `ChargeMetrics`, and `LegalDocChargeMetrics`. | | runBilling  | 211.0 and later  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice or credit memo for a subscription. **Note:** Credit memos are only available if you have the Invoice Settlement feature enabled. | | invoiceDate | 214.0 and earlier  | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date that should appear on the invoice being generated, as `yyyy-mm-dd`. | | invoiceTargetDate | 214.0 and earlier  | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date through which to calculate charges on this account if an invoice is generated, as `yyyy-mm-dd`. | | documentDate | 215.0 and later | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date that should appear on the invoice and credit memo being generated, as `yyyy-mm-dd`. | | targetDate | 215.0 and later | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date through which to calculate charges on this account if an invoice or a credit memo is generated, as `yyyy-mm-dd`. | | memoItemAmount | 223.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | Amount of the memo item. | | amount | 224.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | Amount of the memo item. | | subscriptionNumbers | 222.4 and earlier | [Create order](https://www.zuora.com/developer/api-reference/#operation/POST_Order \"Create order\") | Container for the subscription numbers of the subscriptions in an order. | | subscriptions | 223.0 and later | [Create order](https://www.zuora.com/developer/api-reference/#operation/POST_Order \"Create order\") | Container for the subscription numbers and statuses in an order. | | creditTaxItems | 238.0 and earlier | [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\") | Container for the taxation items of the credit memo item. | | taxItems | 238.0 and earlier | [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Container for the taxation items of the debit memo item. | | taxationItems | 239.0 and later | [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Container for the taxation items of the memo item. | | chargeId | 256.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | ID of the product rate plan charge that the memo is created from. | | productRatePlanChargeId | 257.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | ID of the product rate plan charge that the memo is created from. | | comment | 256.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\"); [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice \"Create credit memo from invoice\"); [Create debit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromInvoice \"Create debit memo from invoice\"); [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Comments about the product rate plan charge, invoice item, or memo item. | | description | 257.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\"); [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice \"Create credit memo from invoice\"); [Create debit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromInvoice \"Create debit memo from invoice\"); [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Description of the the product rate plan charge, invoice item, or memo item. | | taxationItems | 309.0 and later | [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder \"Preview an order\") | List of taxation items for an invoice item or a credit memo item. | | batch | 309.0 and earlier | [Create a billing preview run](https://www.zuora.com/developer/api-reference/#operation/POST_BillingPreviewRun \"Create a billing preview run\") | The customer batches to include in the billing preview run. |       | batches | 314.0 and later | [Create a billing preview run](https://www.zuora.com/developer/api-reference/#operation/POST_BillingPreviewRun \"Create a billing preview run\") | The customer batches to include in the billing preview run. | | taxationItems | 315.0 and later | [Preview a subscription](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewSubscription \"Preview a subscription\"); [Update a subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update a subscription\")| List of taxation items for an invoice item or a credit memo item. |    #### Version 207.0 and Later  The response structure of the [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") and [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") methods are changed. The following invoice related response fields are moved to the invoice container:    * amount   * amountWithoutTax   * taxAmount   * invoiceItems   * targetDate   * chargeMetrics  # Zuora Billing Object Model  The following diagram is a high-level view of how key business objects are related to one another within Zuora Billing.  Click the diagram to open it in a new tab and zoom in. For more information about the different sections of the diagram, see <a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/A_Zuora_Billing_business_object_model\" target=\"_blank\">Zuora Billing business object model</a>.  <a href=\"https://assets.zuora.com/zuora-documentation/Zuora_Billing_object_model_Sep2020.png\" target=\"_blank\"><img src=\"https://assets.zuora.com/zuora-documentation/Zuora_Billing_object_model_Sep2020.png\" alt=\"Zuora Billing object model diagram\"></a>  This diagram is intended to provide a conceptual understanding; it does not illustrate a specific way to integrate with Zuora.  The diagram includes the Orders feature and the Invoice Settlement feature. If your organization does not use either of these features, see <a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/B_Zuora_Billing_business_object_model_prior_to_Orders_and_Invoice_Settlement\" target=\"_blank\">Zuora Billing business object model prior to Orders and Invoice Settlement</a> for an alternative diagram.  ## API Names  You can use the [Describe object](https://www.zuora.com/developer/api-reference/#operation/GET_Describe) operation to list the fields of each Zuora object that is available in your tenant. When you call the operation, you must specify the API name of the Zuora object.  The following table provides the API name of each Zuora object:  | Object                                        | API Name                                   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | Account                                       | `Account`                                  | | Accounting Code                               | `AccountingCode`                           | | Accounting Period                             | `AccountingPeriod`                         | | Amendment                                     | `Amendment`                                | | Application Group                             | `ApplicationGroup`                         | | Billing Run                                   | <p>`BillingRun` - API name used  in the [Describe object](https://www.zuora.com/developer/api-reference/#operation/GET_Describe) operation, Export ZOQL queries, and Data Query.</p> <p>`BillRun` - API name used in the [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions). See the CRUD oprations of [Bill Run](https://www.zuora.com/developer/api-reference/#tag/Bill-Run) for more information about the `BillRun` object. `BillingRun` and `BillRun` have different fields. |                      | Contact                                       | `Contact`                                  | | Contact Snapshot                              | `ContactSnapshot`                          | | Credit Balance Adjustment                     | `CreditBalanceAdjustment`                  | | Credit Memo                                   | `CreditMemo`                               | | Credit Memo Application                       | `CreditMemoApplication`                    | | Credit Memo Application Item                  | `CreditMemoApplicationItem`                | | Credit Memo Item                              | `CreditMemoItem`                           | | Credit Memo Part                              | `CreditMemoPart`                           | | Credit Memo Part Item                         | `CreditMemoPartItem`                       | | Credit Taxation Item                          | `CreditTaxationItem`                       | | Custom Exchange Rate                          | `FXCustomRate`                             | | Debit Memo                                    | `DebitMemo`                                | | Debit Memo Item                               | `DebitMemoItem`                            | | Debit Taxation Item                           | `DebitTaxationItem`                        | | Discount Applied Metrics                      | `DiscountAppliedMetrics`                   | | Entity                                        | `Tenant`                                   | | Feature                                       | `Feature`                                  | | Gateway Reconciliation Event                  | `PaymentGatewayReconciliationEventLog`     | | Gateway Reconciliation Job                    | `PaymentReconciliationJob`                 | | Gateway Reconciliation Log                    | `PaymentReconciliationLog`                 | | Invoice                                       | `Invoice`                                  | | Invoice Adjustment                            | `InvoiceAdjustment`                        | | Invoice Item                                  | `InvoiceItem`                              | | Invoice Item Adjustment                       | `InvoiceItemAdjustment`                    | | Invoice Payment                               | `InvoicePayment`                           | | Journal Entry                                 | `JournalEntry`                             | | Journal Entry Item                            | `JournalEntryItem`                         | | Journal Run                                   | `JournalRun`                               | | Notification History - Callout                | `CalloutHistory`                           | | Notification History - Email                  | `EmailHistory`                             | | Order                                         | `Order`                                    | | Order Action                                  | `OrderAction`                              | | Order ELP                                     | `OrderElp`                                 | | Order Line Items                              | `OrderLineItems`                           |     | Order Item                                    | `OrderItem`                                | | Order MRR                                     | `OrderMrr`                                 | | Order Quantity                                | `OrderQuantity`                            | | Order TCB                                     | `OrderTcb`                                 | | Order TCV                                     | `OrderTcv`                                 | | Payment                                       | `Payment`                                  | | Payment Application                           | `PaymentApplication`                       | | Payment Application Item                      | `PaymentApplicationItem`                   | | Payment Method                                | `PaymentMethod`                            | | Payment Method Snapshot                       | `PaymentMethodSnapshot`                    | | Payment Method Transaction Log                | `PaymentMethodTransactionLog`              | | Payment Method Update                         | `UpdaterDetail`                            | | Payment Part                                  | `PaymentPart`                              | | Payment Part Item                             | `PaymentPartItem`                          | | Payment Run                                   | `PaymentRun`                               | | Payment Transaction Log                       | `PaymentTransactionLog`                    | | Processed Usage                               | `ProcessedUsage`                           | | Product                                       | `Product`                                  | | Product Feature                               | `ProductFeature`                           | | Product Rate Plan                             | `ProductRatePlan`                          | | Product Rate Plan Charge                      | `ProductRatePlanCharge`                    | | Product Rate Plan Charge Tier                 | `ProductRatePlanChargeTier`                | | Rate Plan                                     | `RatePlan`                                 | | Rate Plan Charge                              | `RatePlanCharge`                           | | Rate Plan Charge Tier                         | `RatePlanChargeTier`                       | | Refund                                        | `Refund`                                   | | Refund Application                            | `RefundApplication`                        | | Refund Application Item                       | `RefundApplicationItem`                    | | Refund Invoice Payment                        | `RefundInvoicePayment`                     | | Refund Part                                   | `RefundPart`                               | | Refund Part Item                              | `RefundPartItem`                           | | Refund Transaction Log                        | `RefundTransactionLog`                     | | Revenue Charge Summary                        | `RevenueChargeSummary`                     | | Revenue Charge Summary Item                   | `RevenueChargeSummaryItem`                 | | Revenue Event                                 | `RevenueEvent`                             | | Revenue Event Credit Memo Item                | `RevenueEventCreditMemoItem`               | | Revenue Event Debit Memo Item                 | `RevenueEventDebitMemoItem`                | | Revenue Event Invoice Item                    | `RevenueEventInvoiceItem`                  | | Revenue Event Invoice Item Adjustment         | `RevenueEventInvoiceItemAdjustment`        | | Revenue Event Item                            | `RevenueEventItem`                         | | Revenue Event Item Credit Memo Item           | `RevenueEventItemCreditMemoItem`           | | Revenue Event Item Debit Memo Item            | `RevenueEventItemDebitMemoItem`            | | Revenue Event Item Invoice Item               | `RevenueEventItemInvoiceItem`              | | Revenue Event Item Invoice Item Adjustment    | `RevenueEventItemInvoiceItemAdjustment`    | | Revenue Event Type                            | `RevenueEventType`                         | | Revenue Schedule                              | `RevenueSchedule`                          | | Revenue Schedule Credit Memo Item             | `RevenueScheduleCreditMemoItem`            | | Revenue Schedule Debit Memo Item              | `RevenueScheduleDebitMemoItem`             | | Revenue Schedule Invoice Item                 | `RevenueScheduleInvoiceItem`               | | Revenue Schedule Invoice Item Adjustment      | `RevenueScheduleInvoiceItemAdjustment`     | | Revenue Schedule Item                         | `RevenueScheduleItem`                      | | Revenue Schedule Item Credit Memo Item        | `RevenueScheduleItemCreditMemoItem`        | | Revenue Schedule Item Debit Memo Item         | `RevenueScheduleItemDebitMemoItem`         | | Revenue Schedule Item Invoice Item            | `RevenueScheduleItemInvoiceItem`           | | Revenue Schedule Item Invoice Item Adjustment | `RevenueScheduleItemInvoiceItemAdjustment` | | Subscription                                  | `Subscription`                             | | Subscription Product Feature                  | `SubscriptionProductFeature`               | | Taxable Item Snapshot                         | `TaxableItemSnapshot`                      | | Taxation Item                                 | `TaxationItem`                             | | Updater Batch                                 | `UpdaterBatch`                             | | Usage                                         | `Usage`                                    | 
 *
 * The version of the OpenAPI document: 2022-08-12
 * Contact: docs@zuora.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using ZuoraClient.Client;
using ZuoraClient.Model;

namespace ZuoraClient.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDebitMemosApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType DELETEDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Delete a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> DELETEDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Retrieve a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        GETDebitMemoType GETDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Retrieve a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        ApiResponse<GETDebitMemoType> GETDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// List all application parts of a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetDebitMemoApplicationPartCollectionType</returns>
        GetDebitMemoApplicationPartCollectionType GETDebitMemoApplicationParts(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// List all application parts of a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetDebitMemoApplicationPartCollectionType</returns>
        ApiResponse<GetDebitMemoApplicationPartCollectionType> GETDebitMemoApplicationPartsWithHttpInfo(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Retrieve a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoItemType</returns>
        GETDebitMemoItemType GETDebitMemoItem(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);

        /// <summary>
        /// Retrieve a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoItemType</returns>
        ApiResponse<GETDebitMemoItemType> GETDebitMemoItemWithHttpInfo(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);
        /// <summary>
        /// List debit memo items
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoItemCollectionType</returns>
        GETDebitMemoItemCollectionType GETDebitMemoItems(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0);

        /// <summary>
        /// List debit memo items
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoItemCollectionType</returns>
        ApiResponse<GETDebitMemoItemCollectionType> GETDebitMemoItemsWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0);
        /// <summary>
        /// List debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoCollectionType</returns>
        GETDebitMemoCollectionType GETDebitMemos(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0);

        /// <summary>
        /// List debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoCollectionType</returns>
        ApiResponse<GETDebitMemoCollectionType> GETDebitMemosWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0);
        /// <summary>
        /// List all taxation items of a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETTaxationItemsOfDebitMemoItemType</returns>
        GETTaxationItemsOfDebitMemoItemType GETTaxationItemsOfDebitMemoItem(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0);

        /// <summary>
        /// List all taxation items of a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETTaxationItemsOfDebitMemoItemType</returns>
        ApiResponse<GETTaxationItemsOfDebitMemoItemType> GETTaxationItemsOfDebitMemoItemWithHttpInfo(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0);
        /// <summary>
        /// Create debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>BulkDebitMemosResponseType</returns>
        BulkDebitMemosResponseType POSTCreateDebitMemos(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);

        /// <summary>
        /// Create debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of BulkDebitMemosResponseType</returns>
        ApiResponse<BulkDebitMemosResponseType> POSTCreateDebitMemosWithHttpInfo(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);
        /// <summary>
        /// Create taxation items for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETTaxationItemListType</returns>
        GETTaxationItemListType POSTDMTaxationItems(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Create taxation items for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETTaxationItemListType</returns>
        ApiResponse<GETTaxationItemListType> POSTDMTaxationItemsWithHttpInfo(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Collect a posted debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DebitMemoCollectResponse</returns>
        DebitMemoCollectResponse POSTDebitMemoCollect(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Collect a posted debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DebitMemoCollectResponse</returns>
        ApiResponse<DebitMemoCollectResponse> POSTDebitMemoCollectWithHttpInfo(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Create a debit memo from an invoice
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        GETDebitMemoType POSTDebitMemoFromInvoice(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);

        /// <summary>
        /// Create a debit memo from an invoice
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        ApiResponse<GETDebitMemoType> POSTDebitMemoFromInvoiceWithHttpInfo(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);
        /// <summary>
        /// Create a debit memo from a charge
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        GETDebitMemoType POSTDebitMemoFromPrpc(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);

        /// <summary>
        /// Create a debit memo from a charge
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        ApiResponse<GETDebitMemoType> POSTDebitMemoFromPrpcWithHttpInfo(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);
        /// <summary>
        /// Generate a debit memo PDF file
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTMemoPdfResponse</returns>
        POSTMemoPdfResponse POSTDebitMemoPDF(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Generate a debit memo PDF file
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTMemoPdfResponse</returns>
        ApiResponse<POSTMemoPdfResponse> POSTDebitMemoPDFWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Email a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType POSTEmailDebitMemo(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Email a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> POSTEmailDebitMemoWithHttpInfo(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Upload a file for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTUploadFileResponse</returns>
        POSTUploadFileResponse POSTUploadFileForDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0);

        /// <summary>
        /// Upload a file for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTUploadFileResponse</returns>
        ApiResponse<POSTUploadFileResponse> POSTUploadFileForDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0);
        /// <summary>
        /// Cancel a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        GETDebitMemoType PUTCancelDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Cancel a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        ApiResponse<GETDebitMemoType> PUTCancelDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Update a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        GETDebitMemoType PUTDebitMemo(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Update a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        ApiResponse<GETDebitMemoType> PUTDebitMemoWithHttpInfo(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Post a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        GETDebitMemoType PUTPostDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Post a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        ApiResponse<GETDebitMemoType> PUTPostDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Unpost a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        GETDebitMemoType PUTUnpostDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Unpost a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        ApiResponse<GETDebitMemoType> PUTUnpostDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Update debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>BulkDebitMemosResponseType</returns>
        BulkDebitMemosResponseType PUTUpdateDebitMemos(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);

        /// <summary>
        /// Update debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of BulkDebitMemosResponseType</returns>
        ApiResponse<BulkDebitMemosResponseType> PUTUpdateDebitMemosWithHttpInfo(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0);
        /// <summary>
        /// Update due dates for debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTUpdateDebitMemosDueDates(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Update due dates for debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTUpdateDebitMemosDueDatesWithHttpInfo(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDebitMemosApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> DELETEDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETEDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        System.Threading.Tasks.Task<GETDebitMemoType> GETDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoType>> GETDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all application parts of a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetDebitMemoApplicationPartCollectionType</returns>
        System.Threading.Tasks.Task<GetDebitMemoApplicationPartCollectionType> GETDebitMemoApplicationPartsAsync(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List all application parts of a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetDebitMemoApplicationPartCollectionType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetDebitMemoApplicationPartCollectionType>> GETDebitMemoApplicationPartsWithHttpInfoAsync(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoItemType</returns>
        System.Threading.Tasks.Task<GETDebitMemoItemType> GETDebitMemoItemAsync(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoItemType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoItemType>> GETDebitMemoItemWithHttpInfoAsync(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List debit memo items
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoItemCollectionType</returns>
        System.Threading.Tasks.Task<GETDebitMemoItemCollectionType> GETDebitMemoItemsAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List debit memo items
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoItemCollectionType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoItemCollectionType>> GETDebitMemoItemsWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoCollectionType</returns>
        System.Threading.Tasks.Task<GETDebitMemoCollectionType> GETDebitMemosAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoCollectionType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoCollectionType>> GETDebitMemosWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List all taxation items of a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETTaxationItemsOfDebitMemoItemType</returns>
        System.Threading.Tasks.Task<GETTaxationItemsOfDebitMemoItemType> GETTaxationItemsOfDebitMemoItemAsync(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List all taxation items of a debit memo item
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETTaxationItemsOfDebitMemoItemType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETTaxationItemsOfDebitMemoItemType>> GETTaxationItemsOfDebitMemoItemWithHttpInfoAsync(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BulkDebitMemosResponseType</returns>
        System.Threading.Tasks.Task<BulkDebitMemosResponseType> POSTCreateDebitMemosAsync(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BulkDebitMemosResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<BulkDebitMemosResponseType>> POSTCreateDebitMemosWithHttpInfoAsync(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create taxation items for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETTaxationItemListType</returns>
        System.Threading.Tasks.Task<GETTaxationItemListType> POSTDMTaxationItemsAsync(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create taxation items for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETTaxationItemListType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETTaxationItemListType>> POSTDMTaxationItemsWithHttpInfoAsync(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Collect a posted debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DebitMemoCollectResponse</returns>
        System.Threading.Tasks.Task<DebitMemoCollectResponse> POSTDebitMemoCollectAsync(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Collect a posted debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DebitMemoCollectResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DebitMemoCollectResponse>> POSTDebitMemoCollectWithHttpInfoAsync(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a debit memo from an invoice
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        System.Threading.Tasks.Task<GETDebitMemoType> POSTDebitMemoFromInvoiceAsync(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a debit memo from an invoice
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoType>> POSTDebitMemoFromInvoiceWithHttpInfoAsync(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a debit memo from a charge
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        System.Threading.Tasks.Task<GETDebitMemoType> POSTDebitMemoFromPrpcAsync(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a debit memo from a charge
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoType>> POSTDebitMemoFromPrpcWithHttpInfoAsync(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Generate a debit memo PDF file
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTMemoPdfResponse</returns>
        System.Threading.Tasks.Task<POSTMemoPdfResponse> POSTDebitMemoPDFAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Generate a debit memo PDF file
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTMemoPdfResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTMemoPdfResponse>> POSTDebitMemoPDFWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Email a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> POSTEmailDebitMemoAsync(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Email a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> POSTEmailDebitMemoWithHttpInfoAsync(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Upload a file for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTUploadFileResponse</returns>
        System.Threading.Tasks.Task<POSTUploadFileResponse> POSTUploadFileForDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Upload a file for a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTUploadFileResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTUploadFileResponse>> POSTUploadFileForDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Cancel a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        System.Threading.Tasks.Task<GETDebitMemoType> PUTCancelDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Cancel a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoType>> PUTCancelDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        System.Threading.Tasks.Task<GETDebitMemoType> PUTDebitMemoAsync(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoType>> PUTDebitMemoWithHttpInfoAsync(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Post a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        System.Threading.Tasks.Task<GETDebitMemoType> PUTPostDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Post a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoType>> PUTPostDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Unpost a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        System.Threading.Tasks.Task<GETDebitMemoType> PUTUnpostDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Unpost a debit memo
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETDebitMemoType>> PUTUnpostDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BulkDebitMemosResponseType</returns>
        System.Threading.Tasks.Task<BulkDebitMemosResponseType> PUTUpdateDebitMemosAsync(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BulkDebitMemosResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<BulkDebitMemosResponseType>> PUTUpdateDebitMemosWithHttpInfoAsync(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update due dates for debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTUpdateDebitMemosDueDatesAsync(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update due dates for debit memos
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTUpdateDebitMemosDueDatesWithHttpInfoAsync(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDebitMemosApi : IDebitMemosApiSync, IDebitMemosApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DebitMemosApi : IDebitMemosApi
    {
        private ZuoraClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebitMemosApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DebitMemosApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebitMemosApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DebitMemosApi(string basePath)
        {
            this.Configuration = ZuoraClient.Client.Configuration.MergeConfigurations(
                ZuoraClient.Client.GlobalConfiguration.Instance,
                new ZuoraClient.Client.Configuration { BasePath = basePath }
            );
            this.Client = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = ZuoraClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebitMemosApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DebitMemosApi(ZuoraClient.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = ZuoraClient.Client.Configuration.MergeConfigurations(
                ZuoraClient.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ZuoraClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebitMemosApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public DebitMemosApi(ZuoraClient.Client.ISynchronousClient client, ZuoraClient.Client.IAsynchronousClient asyncClient, ZuoraClient.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = ZuoraClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public ZuoraClient.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public ZuoraClient.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public ZuoraClient.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ZuoraClient.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Delete a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType DELETEDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = DELETEDebitMemoWithHttpInfo(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ZuoraClient.Client.ApiResponse<CommonResponseType> DELETEDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->DELETEDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.DELETEDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Delete<CommonResponseType>("/v1/debitmemos/{debitMemoKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> DELETEDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = await DELETEDebitMemoWithHttpInfoAsync(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Deletes a debit memo. Only debit memos with the Cancelled status can be deleted.   You can delete a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<CommonResponseType>> DELETEDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->DELETEDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.DELETEDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<CommonResponseType>("/v1/debitmemos/{debitMemoKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        public GETDebitMemoType GETDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = GETDebitMemoWithHttpInfo(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoType> GETDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->GETDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoType> GETDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = await GETDebitMemoWithHttpInfoAsync(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about a specific debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoType>> GETDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->GETDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all application parts of a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetDebitMemoApplicationPartCollectionType</returns>
        public GetDebitMemoApplicationPartCollectionType GETDebitMemoApplicationParts(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetDebitMemoApplicationPartCollectionType> localVarResponse = GETDebitMemoApplicationPartsWithHttpInfo(debitMemoId, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List all application parts of a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetDebitMemoApplicationPartCollectionType</returns>
        public ZuoraClient.Client.ApiResponse<GetDebitMemoApplicationPartCollectionType> GETDebitMemoApplicationPartsWithHttpInfo(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoId' is set
            if (debitMemoId == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoId' when calling DebitMemosApi->GETDebitMemoApplicationParts");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoId", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoId)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemoApplicationParts";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetDebitMemoApplicationPartCollectionType>("/v1/debitmemos/{debitMemoId}/application-parts", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemoApplicationParts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all application parts of a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetDebitMemoApplicationPartCollectionType</returns>
        public async System.Threading.Tasks.Task<GetDebitMemoApplicationPartCollectionType> GETDebitMemoApplicationPartsAsync(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetDebitMemoApplicationPartCollectionType> localVarResponse = await GETDebitMemoApplicationPartsWithHttpInfoAsync(debitMemoId, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List all application parts of a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves information about the payments or credit memos that are applied to a specified debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetDebitMemoApplicationPartCollectionType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetDebitMemoApplicationPartCollectionType>> GETDebitMemoApplicationPartsWithHttpInfoAsync(string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoId' is set
            if (debitMemoId == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoId' when calling DebitMemosApi->GETDebitMemoApplicationParts");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoId", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoId)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemoApplicationParts";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetDebitMemoApplicationPartCollectionType>("/v1/debitmemos/{debitMemoId}/application-parts", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemoApplicationParts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoItemType</returns>
        public GETDebitMemoItemType GETDebitMemoItem(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoItemType> localVarResponse = GETDebitMemoItemWithHttpInfo(dmitemid, debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoItemType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoItemType> GETDebitMemoItemWithHttpInfo(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'dmitemid' is set
            if (dmitemid == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'dmitemid' when calling DebitMemosApi->GETDebitMemoItem");
            }

            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->GETDebitMemoItem");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("dmitemid", ZuoraClient.Client.ClientUtils.ParameterToString(dmitemid)); // path parameter
            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemoItem";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETDebitMemoItemType>("/v1/debitmemos/{debitMemoKey}/items/{dmitemid}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemoItem", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoItemType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoItemType> GETDebitMemoItemAsync(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoItemType> localVarResponse = await GETDebitMemoItemWithHttpInfoAsync(dmitemid, debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about a specific item of a debit memo. A debit memo item is a single line item in a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;taxItems&#x60; * &#x60;taxationItems&#x60; * &#x60;comment&#x60; * &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoItemType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoItemType>> GETDebitMemoItemWithHttpInfoAsync(string dmitemid, string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'dmitemid' is set
            if (dmitemid == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'dmitemid' when calling DebitMemosApi->GETDebitMemoItem");
            }

            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->GETDebitMemoItem");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("dmitemid", ZuoraClient.Client.ClientUtils.ParameterToString(dmitemid)); // path parameter
            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemoItem";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETDebitMemoItemType>("/v1/debitmemos/{debitMemoKey}/items/{dmitemid}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemoItem", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List debit memo items **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoItemCollectionType</returns>
        public GETDebitMemoItemCollectionType GETDebitMemoItems(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoItemCollectionType> localVarResponse = GETDebitMemoItemsWithHttpInfo(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, zuoraVersion, amount, beAppliedAmount, createdById, createdDate, id, serviceEndDate, serviceStartDate, sku, skuName, sourceItemId, subscriptionId, updatedById, updatedDate, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List debit memo items **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoItemCollectionType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoItemCollectionType> GETDebitMemoItemsWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->GETDebitMemoItems");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (amount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "amount", amount));
            }
            if (beAppliedAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "beAppliedAmount", beAppliedAmount));
            }
            if (createdById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdById", createdById));
            }
            if (createdDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdDate", createdDate));
            }
            if (id != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "id", id));
            }
            if (serviceEndDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "serviceEndDate", serviceEndDate));
            }
            if (serviceStartDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "serviceStartDate", serviceStartDate));
            }
            if (sku != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sku", sku));
            }
            if (skuName != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "skuName", skuName));
            }
            if (sourceItemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sourceItemId", sourceItemId));
            }
            if (subscriptionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "subscriptionId", subscriptionId));
            }
            if (updatedById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedById", updatedById));
            }
            if (updatedDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedDate", updatedDate));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemoItems";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETDebitMemoItemCollectionType>("/v1/debitmemos/{debitMemoKey}/items", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemoItems", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List debit memo items **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoItemCollectionType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoItemCollectionType> GETDebitMemoItemsAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoItemCollectionType> localVarResponse = await GETDebitMemoItemsWithHttpInfoAsync(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, zuoraVersion, amount, beAppliedAmount, createdById, createdDate, id, serviceEndDate, serviceStartDate, sku, skuName, sourceItemId, subscriptionId, updatedById, updatedDate, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List debit memo items **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Retrieves the information about all items of a debit memo. A debit memo item is a single line item in a debit memo.   ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following response fields: * &#x60;items&#x60; &gt; &#x60;taxItems&#x60; * &#x60;items&#x60; &gt; &#x60;taxationItems&#x60; * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="id">This parameter filters the response based on the &#x60;id&#x60; field.  (optional)</param>
        /// <param name="serviceEndDate">This parameter filters the response based on the &#x60;serviceEndDate&#x60; field.  (optional)</param>
        /// <param name="serviceStartDate">This parameter filters the response based on the &#x60;serviceStartDate&#x60; field.  (optional)</param>
        /// <param name="sku">This parameter filters the response based on the &#x60;sku&#x60; field.  (optional)</param>
        /// <param name="skuName">This parameter filters the response based on the &#x60;skuName&#x60; field.  (optional)</param>
        /// <param name="sourceItemId">This parameter filters the response based on the &#x60;sourceItemId&#x60; field.  (optional)</param>
        /// <param name="subscriptionId">This parameter filters the response based on the &#x60;subscriptionId&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by updated date.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - id   - amount   - beAppliedAmount   - sku   - skuName   - serviceStartDate   - serviceEndDate   - sourceItemId   - createdDate   - createdById   - updatedDate   - updatedById   - subscriptionId    Examples:  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?sort&#x3D;createdDate  - /v1/debitmemos/402890245c7ca371015c7cb40b28001f/items?amount&#x3D;100&amp;sort&#x3D;createdDate  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoItemCollectionType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoItemCollectionType>> GETDebitMemoItemsWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string zuoraVersion = default(string), double? amount = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string id = default(string), DateTime? serviceEndDate = default(DateTime?), DateTime? serviceStartDate = default(DateTime?), string sku = default(string), string skuName = default(string), string sourceItemId = default(string), string subscriptionId = default(string), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->GETDebitMemoItems");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (amount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "amount", amount));
            }
            if (beAppliedAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "beAppliedAmount", beAppliedAmount));
            }
            if (createdById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdById", createdById));
            }
            if (createdDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdDate", createdDate));
            }
            if (id != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "id", id));
            }
            if (serviceEndDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "serviceEndDate", serviceEndDate));
            }
            if (serviceStartDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "serviceStartDate", serviceStartDate));
            }
            if (sku != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sku", sku));
            }
            if (skuName != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "skuName", skuName));
            }
            if (sourceItemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sourceItemId", sourceItemId));
            }
            if (subscriptionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "subscriptionId", subscriptionId));
            }
            if (updatedById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedById", updatedById));
            }
            if (updatedDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedDate", updatedDate));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemoItems";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETDebitMemoItemCollectionType>("/v1/debitmemos/{debitMemoKey}/items", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemoItems", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoCollectionType</returns>
        public GETDebitMemoCollectionType GETDebitMemos(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoCollectionType> localVarResponse = GETDebitMemosWithHttpInfo(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, accountId, amount, balance, beAppliedAmount, createdById, createdDate, currency, debitMemoDate, dueDate, number, referredInvoiceId, status, targetDate, taxAmount, totalTaxExemptAmount, updatedById, updatedDate, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoCollectionType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoCollectionType> GETDebitMemosWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (amount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "amount", amount));
            }
            if (balance != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "balance", balance));
            }
            if (beAppliedAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "beAppliedAmount", beAppliedAmount));
            }
            if (createdById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdById", createdById));
            }
            if (createdDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdDate", createdDate));
            }
            if (currency != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "currency", currency));
            }
            if (debitMemoDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "debitMemoDate", debitMemoDate));
            }
            if (dueDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dueDate", dueDate));
            }
            if (number != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "number", number));
            }
            if (referredInvoiceId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "referredInvoiceId", referredInvoiceId));
            }
            if (status != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "status", status));
            }
            if (targetDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "targetDate", targetDate));
            }
            if (taxAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "taxAmount", taxAmount));
            }
            if (totalTaxExemptAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "totalTaxExemptAmount", totalTaxExemptAmount));
            }
            if (updatedById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedById", updatedById));
            }
            if (updatedDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedDate", updatedDate));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETDebitMemoCollectionType>("/v1/debitmemos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoCollectionType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoCollectionType> GETDebitMemosAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoCollectionType> localVarResponse = await GETDebitMemosWithHttpInfoAsync(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, accountId, amount, balance, beAppliedAmount, createdById, createdDate, currency, debitMemoDate, dueDate, number, referredInvoiceId, status, targetDate, taxAmount, totalTaxExemptAmount, updatedById, updatedDate, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves the information about all debit memos associated with all customer accounts.  ### Filtering  You can use query parameters to restrict the data returned in the response. Each query parameter corresponds to one field in the response body.  If the value of a filterable field is string, you can set the corresponding query parameter to &#x60;null&#x60; when filtering. Then, you can get the response data with this field value being &#x60;null&#x60;.   Examples:  - /v1/debitmemos?status&#x3D;Posted  - /v1/debitmemos?referredInvoiceId&#x3D;null&amp;status&#x3D;Draft  - /v1/debitmemos?status&#x3D;Posted&amp;type&#x3D;External&amp;sort&#x3D;+number 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">This parameter filters the response based on the &#x60;accountId&#x60; field.  (optional)</param>
        /// <param name="amount">This parameter filters the response based on the &#x60;amount&#x60; field.  (optional)</param>
        /// <param name="balance">This parameter filters the response based on the &#x60;balance&#x60; field.  (optional)</param>
        /// <param name="beAppliedAmount">This parameter filters the response based on the &#x60;beAppliedAmount&#x60; field.  (optional)</param>
        /// <param name="createdById">This parameter filters the response based on the &#x60;createdById&#x60; field.  (optional)</param>
        /// <param name="createdDate">This parameter filters the response based on the &#x60;createdDate&#x60; field.  (optional)</param>
        /// <param name="currency">This parameter filters the response based on the &#x60;currency&#x60; field.  (optional)</param>
        /// <param name="debitMemoDate">This parameter filters the response based on the &#x60;debitMemoDate&#x60; field.  (optional)</param>
        /// <param name="dueDate">This parameter filters the response based on the &#x60;dueDate&#x60; field.  (optional)</param>
        /// <param name="number">This parameter filters the response based on the &#x60;number&#x60; field.  (optional)</param>
        /// <param name="referredInvoiceId">This parameter filters the response based on the &#x60;referredInvoiceId&#x60; field.  (optional)</param>
        /// <param name="status">This parameter filters the response based on the &#x60;status&#x60; field.  (optional)</param>
        /// <param name="targetDate">This parameter filters the response based on the &#x60;targetDate&#x60; field.  (optional)</param>
        /// <param name="taxAmount">This parameter filters the response based on the &#x60;taxAmount&#x60; field.  (optional)</param>
        /// <param name="totalTaxExemptAmount">This parameter filters the response based on the &#x60;totalTaxExemptAmount&#x60; field.  (optional)</param>
        /// <param name="updatedById">This parameter filters the response based on the &#x60;updatedById&#x60; field.  (optional)</param>
        /// <param name="updatedDate">This parameter filters the response based on the &#x60;updatedDate&#x60; field.  (optional)</param>
        /// <param name="sort">This parameter restricts the order of the data returned in the response. You can use this parameter to supply a dimension you want to sort on.  A sortable field uses the following form:   *operator* *field_name*  You can use at most two sortable fields in one URL path. Use a comma to separate sortable fields. For example:  *operator* *field_name*, *operator* *field_name*    *operator* is used to mark the order of sequencing. The operator is optional. If you only specify the sortable field without any operator, the response data is sorted in descending order by this field.    - The &#x60;-&#x60; operator indicates an ascending order.   - The &#x60;+&#x60; operator indicates a descending order.  By default, the response data is displayed in descending order by debit memo number.  *field_name* indicates the name of a sortable field. The supported sortable fields of this operation are as below:    - number   - accountId   - debitMemoDate   - targetDate   - dueDate   - amount   - taxAmount   - totalTaxExemptAmount   - balance   - beAppliedAmount   - referredInvoiceId   - createdDate   - createdById   - updatedDate   - updatedById    Examples:  - /v1/debitmemos?sort&#x3D;+number  - /v1/debitmemos?status&#x3D;Processed&amp;sort&#x3D;-number,+amount  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoCollectionType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoCollectionType>> GETDebitMemosWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), double? amount = default(double?), double? balance = default(double?), double? beAppliedAmount = default(double?), string createdById = default(string), DateTime? createdDate = default(DateTime?), string currency = default(string), DateTime? debitMemoDate = default(DateTime?), DateTime? dueDate = default(DateTime?), string number = default(string), string referredInvoiceId = default(string), string status = default(string), DateTime? targetDate = default(DateTime?), double? taxAmount = default(double?), double? totalTaxExemptAmount = default(double?), string updatedById = default(string), DateTime? updatedDate = default(DateTime?), string sort = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (amount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "amount", amount));
            }
            if (balance != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "balance", balance));
            }
            if (beAppliedAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "beAppliedAmount", beAppliedAmount));
            }
            if (createdById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdById", createdById));
            }
            if (createdDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "createdDate", createdDate));
            }
            if (currency != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "currency", currency));
            }
            if (debitMemoDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "debitMemoDate", debitMemoDate));
            }
            if (dueDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dueDate", dueDate));
            }
            if (number != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "number", number));
            }
            if (referredInvoiceId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "referredInvoiceId", referredInvoiceId));
            }
            if (status != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "status", status));
            }
            if (targetDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "targetDate", targetDate));
            }
            if (taxAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "taxAmount", taxAmount));
            }
            if (totalTaxExemptAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "totalTaxExemptAmount", totalTaxExemptAmount));
            }
            if (updatedById != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedById", updatedById));
            }
            if (updatedDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "updatedDate", updatedDate));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETDebitMemos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETDebitMemoCollectionType>("/v1/debitmemos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETDebitMemos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all taxation items of a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETTaxationItemsOfDebitMemoItemType</returns>
        public GETTaxationItemsOfDebitMemoItemType GETTaxationItemsOfDebitMemoItem(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETTaxationItemsOfDebitMemoItemType> localVarResponse = GETTaxationItemsOfDebitMemoItemWithHttpInfo(dmitemid, debitMemoId, authorization, zuoraTrackId, zuoraEntityIds, pageSize, page);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List all taxation items of a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETTaxationItemsOfDebitMemoItemType</returns>
        public ZuoraClient.Client.ApiResponse<GETTaxationItemsOfDebitMemoItemType> GETTaxationItemsOfDebitMemoItemWithHttpInfo(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'dmitemid' is set
            if (dmitemid == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'dmitemid' when calling DebitMemosApi->GETTaxationItemsOfDebitMemoItem");
            }

            // verify the required parameter 'debitMemoId' is set
            if (debitMemoId == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoId' when calling DebitMemosApi->GETTaxationItemsOfDebitMemoItem");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("dmitemid", ZuoraClient.Client.ClientUtils.ParameterToString(dmitemid)); // path parameter
            localVarRequestOptions.PathParameters.Add("debitMemoId", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoId)); // path parameter
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETTaxationItemsOfDebitMemoItem";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETTaxationItemsOfDebitMemoItemType>("/v1/debitmemos/{debitMemoId}/items/{dmitemid}/taxation-items", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETTaxationItemsOfDebitMemoItem", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List all taxation items of a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETTaxationItemsOfDebitMemoItemType</returns>
        public async System.Threading.Tasks.Task<GETTaxationItemsOfDebitMemoItemType> GETTaxationItemsOfDebitMemoItemAsync(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETTaxationItemsOfDebitMemoItemType> localVarResponse = await GETTaxationItemsOfDebitMemoItemWithHttpInfoAsync(dmitemid, debitMemoId, authorization, zuoraTrackId, zuoraEntityIds, pageSize, page, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List all taxation items of a debit memo item **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Retrieves information about the taxation items of a specific debit memo item. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dmitemid">The unique ID of a debit memo item. You can get the debit memo item ID from the response of [List debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems). </param>
        /// <param name="debitMemoId">The unique ID of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETTaxationItemsOfDebitMemoItemType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETTaxationItemsOfDebitMemoItemType>> GETTaxationItemsOfDebitMemoItemWithHttpInfoAsync(string dmitemid, string debitMemoId, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? pageSize = default(int?), int? page = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'dmitemid' is set
            if (dmitemid == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'dmitemid' when calling DebitMemosApi->GETTaxationItemsOfDebitMemoItem");
            }

            // verify the required parameter 'debitMemoId' is set
            if (debitMemoId == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoId' when calling DebitMemosApi->GETTaxationItemsOfDebitMemoItem");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("dmitemid", ZuoraClient.Client.ClientUtils.ParameterToString(dmitemid)); // path parameter
            localVarRequestOptions.PathParameters.Add("debitMemoId", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoId)); // path parameter
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.GETTaxationItemsOfDebitMemoItem";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETTaxationItemsOfDebitMemoItemType>("/v1/debitmemos/{debitMemoId}/items/{dmitemid}/taxation-items", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETTaxationItemsOfDebitMemoItem", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>BulkDebitMemosResponseType</returns>
        public BulkDebitMemosResponseType POSTCreateDebitMemos(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType> localVarResponse = POSTCreateDebitMemosWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of BulkDebitMemosResponseType</returns>
        public ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType> POSTCreateDebitMemosWithHttpInfo(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTCreateDebitMemos");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTCreateDebitMemos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<BulkDebitMemosResponseType>("/v1/debitmemos/bulk", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateDebitMemos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BulkDebitMemosResponseType</returns>
        public async System.Threading.Tasks.Task<BulkDebitMemosResponseType> POSTCreateDebitMemosAsync(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType> localVarResponse = await POSTCreateDebitMemosWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates multiple debit memos from invoices or product rate plan charges. You can create a maximum of 50 debit memos in one single request.   - If you set the &#x60;sourceType&#x60; request field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - If you set the &#x60;sourceType&#x60; request field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The debit memos that are created are each in separate database transactions. If the creation of one debit memo fails, other debit memos can still be created successfully.  You can create  debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BulkDebitMemosResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType>> POSTCreateDebitMemosWithHttpInfoAsync(POSTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTCreateDebitMemos");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTCreateDebitMemos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<BulkDebitMemosResponseType>("/v1/debitmemos/bulk", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateDebitMemos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create taxation items for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETTaxationItemListType</returns>
        public GETTaxationItemListType POSTDMTaxationItems(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETTaxationItemListType> localVarResponse = POSTDMTaxationItemsWithHttpInfo(debitMemoKey, body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create taxation items for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETTaxationItemListType</returns>
        public ZuoraClient.Client.ApiResponse<GETTaxationItemListType> POSTDMTaxationItemsWithHttpInfo(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTDMTaxationItems");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDMTaxationItems");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDMTaxationItems";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GETTaxationItemListType>("/v1/debitmemos/{debitMemoKey}/taxationitems", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDMTaxationItems", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create taxation items for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETTaxationItemListType</returns>
        public async System.Threading.Tasks.Task<GETTaxationItemListType> POSTDMTaxationItemsAsync(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETTaxationItemListType> localVarResponse = await POSTDMTaxationItemsWithHttpInfoAsync(debitMemoKey, body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create taxation items for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates taxation items for a debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETTaxationItemListType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETTaxationItemListType>> POSTDMTaxationItemsWithHttpInfoAsync(string debitMemoKey, POSTTaxationItemListForDMType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTDMTaxationItems");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDMTaxationItems");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDMTaxationItems";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<GETTaxationItemListType>("/v1/debitmemos/{debitMemoKey}/taxationitems", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDMTaxationItems", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Collect a posted debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DebitMemoCollectResponse</returns>
        public DebitMemoCollectResponse POSTDebitMemoCollect(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<DebitMemoCollectResponse> localVarResponse = POSTDebitMemoCollectWithHttpInfo(debitMemoKey, body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Collect a posted debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DebitMemoCollectResponse</returns>
        public ZuoraClient.Client.ApiResponse<DebitMemoCollectResponse> POSTDebitMemoCollectWithHttpInfo(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTDebitMemoCollect");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDebitMemoCollect");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoCollect";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<DebitMemoCollectResponse>("/v1/debitmemos/{debitMemoKey}/collect", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoCollect", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Collect a posted debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DebitMemoCollectResponse</returns>
        public async System.Threading.Tasks.Task<DebitMemoCollectResponse> POSTDebitMemoCollectAsync(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<DebitMemoCollectResponse> localVarResponse = await POSTDebitMemoCollectWithHttpInfoAsync(debitMemoKey, body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Collect a posted debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  This API operation provides an easy way to let the client-side to collect an existing posted debit memo. It supports the following steps:   1. Apply unapplied credit memos to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied credit memos.   2. Apply unapplied payments to the posted debit memo by Oldest-First-Largest-First rule if there are more than one unapplied payments.   3. Process payment to the posted debit memo if there is an open-balance on it.  **Reistrictions**  Since this API will do lots of works, and some of them are resource consuming, we need to resitrict the usage of this API by the following conditions:   1. If the target debit memo gets more than 10 debit memo items, the request will be rejected.   2. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 credit memos will be used to apply to the debit memo, the request will be rejected.   3. If &#x60;CreditMemo&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 100 credit memo items will be used to apply to the debit memo, the request will be rejected.   4. If &#x60;UnappliedPayment&#x60; is specified in &#x60;applicationOrder&#x60;, when there are more than 25 payments will be used to apply to the debit memo, the request will be rejected. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DebitMemoCollectResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<DebitMemoCollectResponse>> POSTDebitMemoCollectWithHttpInfoAsync(string debitMemoKey, DebitMemoCollectRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTDebitMemoCollect");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDebitMemoCollect");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoCollect";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<DebitMemoCollectResponse>("/v1/debitmemos/{debitMemoKey}/collect", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoCollect", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a debit memo from an invoice **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        public GETDebitMemoType POSTDebitMemoFromInvoice(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = POSTDebitMemoFromInvoiceWithHttpInfo(invoiceKey, body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a debit memo from an invoice **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoType> POSTDebitMemoFromInvoiceWithHttpInfo(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'invoiceKey' is set
            if (invoiceKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'invoiceKey' when calling DebitMemosApi->POSTDebitMemoFromInvoice");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDebitMemoFromInvoice");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("invoiceKey", ZuoraClient.Client.ClientUtils.ParameterToString(invoiceKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoFromInvoice";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GETDebitMemoType>("/v1/invoices/{invoiceKey}/debitmemos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoFromInvoice", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a debit memo from an invoice **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoType> POSTDebitMemoFromInvoiceAsync(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = await POSTDebitMemoFromInvoiceWithHttpInfoAsync(invoiceKey, body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a debit memo from an invoice **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from an invoice.  You can create a debit memo from an invoice only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceKey">The ID or number of an invoice that you want to create a debit memo from. For example, 2c93808457d787030157e030d10f3f64 or INV00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;items&#x60; &gt; &#x60;comment&#x60; * &#x60;items&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoType>> POSTDebitMemoFromInvoiceWithHttpInfoAsync(string invoiceKey, DebitMemoFromInvoiceType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'invoiceKey' is set
            if (invoiceKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'invoiceKey' when calling DebitMemosApi->POSTDebitMemoFromInvoice");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDebitMemoFromInvoice");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("invoiceKey", ZuoraClient.Client.ClientUtils.ParameterToString(invoiceKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoFromInvoice";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<GETDebitMemoType>("/v1/invoices/{invoiceKey}/debitmemos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoFromInvoice", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a debit memo from a charge **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        public GETDebitMemoType POSTDebitMemoFromPrpc(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = POSTDebitMemoFromPrpcWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a debit memo from a charge **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoType> POSTDebitMemoFromPrpcWithHttpInfo(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDebitMemoFromPrpc");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoFromPrpc";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GETDebitMemoType>("/v1/debitmemos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoFromPrpc", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a debit memo from a charge **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoType> POSTDebitMemoFromPrpcAsync(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = await POSTDebitMemoFromPrpcWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a debit memo from a charge **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Creates an ad-hoc debit memo from a product rate plan charge. Zuora supports the creation of debit memos from any type of product rate plan charge. The charges can also have any amount and any charge model, except for discout charge models.  When debit memos are created from product rate plan charges, the specified amount with decimal places is now validated based on the decimal places supported by each currency.  You can create a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;charges&#x60; &gt; &#x60;amount&#x60; * &#x60;charges&#x60; &gt; &#x60;memoItemAmount&#x60; * &#x60;charges&#x60; &gt; &#x60;chargeId&#x60; * &#x60;charges&#x60; &gt; &#x60;productRatePlanChargeId&#x60;        * &#x60;charges&#x60; &gt; &#x60;comment&#x60; * &#x60;charges&#x60; &gt; &#x60;description&#x60;  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoType>> POSTDebitMemoFromPrpcWithHttpInfoAsync(DebitMemoFromChargeType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->POSTDebitMemoFromPrpc");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoFromPrpc";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<GETDebitMemoType>("/v1/debitmemos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoFromPrpc", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Generate a debit memo PDF file **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTMemoPdfResponse</returns>
        public POSTMemoPdfResponse POSTDebitMemoPDF(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<POSTMemoPdfResponse> localVarResponse = POSTDebitMemoPDFWithHttpInfo(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Generate a debit memo PDF file **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTMemoPdfResponse</returns>
        public ZuoraClient.Client.ApiResponse<POSTMemoPdfResponse> POSTDebitMemoPDFWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTDebitMemoPDF");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoPDF";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<POSTMemoPdfResponse>("/v1/debitmemos/{debitMemoKey}/pdfs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoPDF", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Generate a debit memo PDF file **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTMemoPdfResponse</returns>
        public async System.Threading.Tasks.Task<POSTMemoPdfResponse> POSTDebitMemoPDFAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<POSTMemoPdfResponse> localVarResponse = await POSTDebitMemoPDFWithHttpInfoAsync(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Generate a debit memo PDF file **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Creates a PDF file for a specified debit memo. To access the generated PDF file, you can download it by clicking **View PDF** on the detailed debit memo page through the Zuora UI.  This REST API operation can be used only if you have the billing document file generation feature and the Billing user permission \&quot;Regenerate PDF\&quot; enabled. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of the debit memo that you want to create a PDF file for. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTMemoPdfResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<POSTMemoPdfResponse>> POSTDebitMemoPDFWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTDebitMemoPDF");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.POSTDebitMemoPDF";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<POSTMemoPdfResponse>("/v1/debitmemos/{debitMemoKey}/pdfs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTDebitMemoPDF", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Email a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType POSTEmailDebitMemo(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = POSTEmailDebitMemoWithHttpInfo(debitMemoKey, request, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Email a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ZuoraClient.Client.ApiResponse<CommonResponseType> POSTEmailDebitMemoWithHttpInfo(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTEmailDebitMemo");
            }

            // verify the required parameter 'request' is set
            if (request == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'request' when calling DebitMemosApi->POSTEmailDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = request;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTEmailDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<CommonResponseType>("/v1/debitmemos/{debitMemoKey}/emails", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTEmailDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Email a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> POSTEmailDebitMemoAsync(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = await POSTEmailDebitMemoWithHttpInfoAsync(debitMemoKey, request, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Email a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Sends a posted debit memo to the specified email addresses manually.    ## Notes   - You must activate the **Email Debit Memo | Manually email Debit Memo** notification before emailing debit memos. To include the debit memo PDF in the email, select the **Include Debit Memo PDF** check box in the **Edit notification** dialog from the Zuora UI. See [Create and Edit Notifications](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/C_Create_Notifications#section_2) for more information.     - Zuora sends the email messages based on the email template you set. You can set the email template to use in the **Delivery Options** panel of the **Edit notification** dialog from the Zuora UI. By default, the **Manual Email for Debit Memo Default Template** template is used. See [Create and Edit Email Templates](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Notifications/Create_Email_Templates) for more information.     - The debit memos are sent only to the work email addresses or personal email addresses of the Bill To contact if the following conditions are all met:      * The &#x60;useEmailTemplateSetting&#x60; field is set to &#x60;false&#x60;.     * The email addresses are not specified in the &#x60;emailAddresses&#x60; field. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of a posted debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="request"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<CommonResponseType>> POSTEmailDebitMemoWithHttpInfoAsync(string debitMemoKey, PostDebitMemoEmailType request, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTEmailDebitMemo");
            }

            // verify the required parameter 'request' is set
            if (request == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'request' when calling DebitMemosApi->POSTEmailDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = request;

            localVarRequestOptions.Operation = "DebitMemosApi.POSTEmailDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<CommonResponseType>("/v1/debitmemos/{debitMemoKey}/emails", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTEmailDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Upload a file for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTUploadFileResponse</returns>
        public POSTUploadFileResponse POSTUploadFileForDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<POSTUploadFileResponse> localVarResponse = POSTUploadFileForDebitMemoWithHttpInfo(debitMemoKey, authorization, zuoraEntityIds, zuoraTrackId, file);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Upload a file for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTUploadFileResponse</returns>
        public ZuoraClient.Client.ApiResponse<POSTUploadFileResponse> POSTUploadFileForDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTUploadFileForDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "multipart/form-data"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (file != null)
            {
                localVarRequestOptions.FileParameters.Add("file", file);
            }

            localVarRequestOptions.Operation = "DebitMemosApi.POSTUploadFileForDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<POSTUploadFileResponse>("/v1/debitmemos/{debitMemoKey}/files", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTUploadFileForDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Upload a file for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTUploadFileResponse</returns>
        public async System.Threading.Tasks.Task<POSTUploadFileResponse> POSTUploadFileForDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<POSTUploadFileResponse> localVarResponse = await POSTUploadFileForDebitMemoWithHttpInfoAsync(debitMemoKey, authorization, zuoraEntityIds, zuoraTrackId, file, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Upload a file for a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Uploads an externally generated PDF file for a debit memo that is in Draft or Posted status.  To use this operation, you must enable the Modify Debit Memo permission. See [Billing Permissions](https://knowledgecenter.zuora.com/Billing/Tenant_Management/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information.  This operation has the following restrictions: - Only the PDF file format is supported. - The maximum size of the PDF file to upload is 4 MB. - A maximum of 50 PDF files can be uploaded for one debit memo. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The ID or number of the debit memo that you want to upload a PDF file for. For example, 402890555a87d7f5015a8919e4fe002e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="file">The PDF file to upload for the debit memo.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTUploadFileResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<POSTUploadFileResponse>> POSTUploadFileForDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraEntityIds = default(string), string zuoraTrackId = default(string), System.IO.Stream file = default(System.IO.Stream), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->POSTUploadFileForDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "multipart/form-data"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (file != null)
            {
                localVarRequestOptions.FileParameters.Add("file", file);
            }

            localVarRequestOptions.Operation = "DebitMemosApi.POSTUploadFileForDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<POSTUploadFileResponse>("/v1/debitmemos/{debitMemoKey}/files", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTUploadFileForDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        public GETDebitMemoType PUTCancelDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = PUTCancelDebitMemoWithHttpInfo(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Cancel a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoType> PUTCancelDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTCancelDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.PUTCancelDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}/cancel", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTCancelDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoType> PUTCancelDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = await PUTCancelDebitMemoWithHttpInfoAsync(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Cancel a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Cancels a debit memo. Only debit memos with the Draft status can be cancelled.   You can cancel a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000003. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoType>> PUTCancelDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTCancelDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.PUTCancelDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}/cancel", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTCancelDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        public GETDebitMemoType PUTDebitMemo(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = PUTDebitMemoWithHttpInfo(debitMemoKey, body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoType> PUTDebitMemoWithHttpInfo(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTDebitMemo");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->PUTDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.PUTDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoType> PUTDebitMemoAsync(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = await PUTDebitMemoWithHttpInfoAsync(debitMemoKey, body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Updates the basic and finance information about a debit memo. Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.   If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update a debit memo only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoType>> PUTDebitMemoWithHttpInfoAsync(string debitMemoKey, PUTDebitMemoType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTDebitMemo");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->PUTDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.PUTDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Post a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        public GETDebitMemoType PUTPostDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = PUTPostDebitMemoWithHttpInfo(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Post a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoType> PUTPostDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTPostDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.PUTPostDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}/post", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTPostDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Post a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoType> PUTPostDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = await PUTPostDebitMemoWithHttpInfoAsync(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Post a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Posts a debit memo to activate it. You can post debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoType>> PUTPostDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTPostDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.PUTPostDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}/post", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTPostDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Unpost a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETDebitMemoType</returns>
        public GETDebitMemoType PUTUnpostDebitMemo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = PUTUnpostDebitMemoWithHttpInfo(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Unpost a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETDebitMemoType</returns>
        public ZuoraClient.Client.ApiResponse<GETDebitMemoType> PUTUnpostDebitMemoWithHttpInfo(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTUnpostDebitMemo");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.PUTUnpostDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}/unpost", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUnpostDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Unpost a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETDebitMemoType</returns>
        public async System.Threading.Tasks.Task<GETDebitMemoType> PUTUnpostDebitMemoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETDebitMemoType> localVarResponse = await PUTUnpostDebitMemoWithHttpInfoAsync(debitMemoKey, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Unpost a debit memo **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   Unposts a debit memo that is in Posted status. If any credit memo or payment has been applied to a debit memo, you are not allowed to unpost the debit memo. After a debit memo is unposted, its status becomes Draft.  You can unpost debit memos only if you have the [Billing permissions](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles#Billing_Permissions). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="debitMemoKey">The unique ID or number of a debit memo. For example, 8a8082e65b27f6c3015ba419f3c2644e or DM00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETDebitMemoType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETDebitMemoType>> PUTUnpostDebitMemoWithHttpInfoAsync(string debitMemoKey, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'debitMemoKey' is set
            if (debitMemoKey == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'debitMemoKey' when calling DebitMemosApi->PUTUnpostDebitMemo");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("debitMemoKey", ZuoraClient.Client.ClientUtils.ParameterToString(debitMemoKey)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "DebitMemosApi.PUTUnpostDebitMemo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<GETDebitMemoType>("/v1/debitmemos/{debitMemoKey}/unpost", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUnpostDebitMemo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>BulkDebitMemosResponseType</returns>
        public BulkDebitMemosResponseType PUTUpdateDebitMemos(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType> localVarResponse = PUTUpdateDebitMemosWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of BulkDebitMemosResponseType</returns>
        public ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType> PUTUpdateDebitMemosWithHttpInfo(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->PUTUpdateDebitMemos");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.PUTUpdateDebitMemos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<BulkDebitMemosResponseType>("/v1/debitmemos/bulk", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateDebitMemos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BulkDebitMemosResponseType</returns>
        public async System.Threading.Tasks.Task<BulkDebitMemosResponseType> PUTUpdateDebitMemosAsync(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType> localVarResponse = await PUTUpdateDebitMemosWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the basic and finance information about multiple debit memos.  You can update a maximum of 50 credit memos in one single request.    The credit memos that are updated are each in separate database transactions. If the update of one debit memo fails, other debit memos can still be updated successfully.  Currently, Zuora supports updating tax-exclusive memo items, but does not support updating tax-inclusive memo items.  If the amount of a memo item is updated, the tax will be recalculated in the following conditions:   - The memo is created from a product rate plan charge and you use Avalara to calculate the tax.   - The memo is created from an invoice and you use Avalara or Zuora Tax to calculate the tax.  You can update debit memos only if you have the user permission. See [Billing Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) for more information. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BulkDebitMemosResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<BulkDebitMemosResponseType>> PUTUpdateDebitMemosWithHttpInfoAsync(PUTBulkDebitMemosRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->PUTUpdateDebitMemos");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            if (zuoraVersion != null)
            {
                localVarRequestOptions.HeaderParameters.Add("zuora-version", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraVersion)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.PUTUpdateDebitMemos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<BulkDebitMemosResponseType>("/v1/debitmemos/bulk", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateDebitMemos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update due dates for debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTUpdateDebitMemosDueDates(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = PUTUpdateDebitMemosDueDatesWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update due dates for debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ZuoraClient.Client.ApiResponse<CommonResponseType> PUTUpdateDebitMemosDueDatesWithHttpInfo(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->PUTUpdateDebitMemosDueDates");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.PUTUpdateDebitMemosDueDates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<CommonResponseType>("/v1/debitmemos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateDebitMemosDueDates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update due dates for debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTUpdateDebitMemosDueDatesAsync(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = await PUTUpdateDebitMemosDueDatesWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update due dates for debit memos **Note:** This operation is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  Updates the due date for multiple debit memos in one single request.   This API operation will be deprecated. You can use the [Update debit memos](https://www.zuora.com/developer/api-reference/#operation/PUT_BulkUpdateDebitMemos) instead, which provides more flexible functionality. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<CommonResponseType>> PUTUpdateDebitMemosDueDatesWithHttpInfoAsync(PUTBatchDebitMemosRequest body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling DebitMemosApi->PUTUpdateDebitMemosDueDates");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "DebitMemosApi.PUTUpdateDebitMemosDueDates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<CommonResponseType>("/v1/debitmemos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateDebitMemosDueDates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
