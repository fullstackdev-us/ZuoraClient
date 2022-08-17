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
    public interface IOrdersApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType DELETEOrder(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Delete an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> DELETEOrderWithHttpInfo(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// List orders
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAllOrdersResponseType</returns>
        GetAllOrdersResponseType GETAllOrders(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);

        /// <summary>
        /// List orders
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAllOrdersResponseType</returns>
        ApiResponse<GetAllOrdersResponseType> GETAllOrdersWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);
        /// <summary>
        /// Retrieve the status and response of a job
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETJobStatusAndResponse200Response</returns>
        GETJobStatusAndResponse200Response GETJobStatusAndResponse(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0);

        /// <summary>
        /// Retrieve the status and response of a job
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETJobStatusAndResponse200Response</returns>
        ApiResponse<GETJobStatusAndResponse200Response> GETJobStatusAndResponseWithHttpInfo(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0);
        /// <summary>
        /// Retrieve an order
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrderResponse</returns>
        GetOrderResponse GETOrder(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Retrieve an order
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrderResponse</returns>
        ApiResponse<GetOrderResponse> GETOrderWithHttpInfo(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// List order metrics for an evergreen subscription
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrderResponseForEvergreen</returns>
        GetOrderResponseForEvergreen GETOrderMetricsforEvergreenSubscription(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// List order metrics for an evergreen subscription
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrderResponseForEvergreen</returns>
        ApiResponse<GetOrderResponseForEvergreen> GETOrderMetricsforEvergreenSubscriptionWithHttpInfo(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// List orders of an invoice owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrdersResponse</returns>
        GetOrdersResponse GETOrdersByInvoiceOwner(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);

        /// <summary>
        /// List orders of an invoice owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrdersResponse</returns>
        ApiResponse<GetOrdersResponse> GETOrdersByInvoiceOwnerWithHttpInfo(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);
        /// <summary>
        /// List orders by subscription number
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrdersResponse</returns>
        GetOrdersResponse GETOrdersBySubscriptionNumber(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);

        /// <summary>
        /// List orders by subscription number
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrdersResponse</returns>
        ApiResponse<GetOrdersResponse> GETOrdersBySubscriptionNumberWithHttpInfo(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);
        /// <summary>
        /// List orders of a subscription owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrdersResponse</returns>
        GetOrdersResponse GETOrdersBySubscriptionOwner(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);

        /// <summary>
        /// List orders of a subscription owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrdersResponse</returns>
        ApiResponse<GetOrdersResponse> GETOrdersBySubscriptionOwnerWithHttpInfo(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0);
        /// <summary>
        /// List subscription terms
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetSubscriptionTermInfoResponseType</returns>
        GetSubscriptionTermInfoResponseType GETSubscriptionTermInfo(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0);

        /// <summary>
        /// List subscription terms
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetSubscriptionTermInfoResponseType</returns>
        ApiResponse<GetSubscriptionTermInfoResponseType> GETSubscriptionTermInfoWithHttpInfo(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0);
        /// <summary>
        /// Create an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTCreateOrderAsynchronously202Response</returns>
        POSTCreateOrderAsynchronously202Response POSTCreateOrderAsynchronously(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0);

        /// <summary>
        /// Create an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTCreateOrderAsynchronously202Response</returns>
        ApiResponse<POSTCreateOrderAsynchronously202Response> POSTCreateOrderAsynchronouslyWithHttpInfo(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0);
        /// <summary>
        /// Create an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PostOrderResponseType</returns>
        PostOrderResponseType POSTOrder(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0);

        /// <summary>
        /// Create an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PostOrderResponseType</returns>
        ApiResponse<PostOrderResponseType> POSTOrderWithHttpInfo(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0);
        /// <summary>
        /// Preview an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PostOrderPreviewResponseType</returns>
        PostOrderPreviewResponseType POSTPreviewOrder(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Preview an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PostOrderPreviewResponseType</returns>
        ApiResponse<PostOrderPreviewResponseType> POSTPreviewOrderWithHttpInfo(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Preview an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTPreviewOrderAsynchronously202Response</returns>
        POSTPreviewOrderAsynchronously202Response POSTPreviewOrderAsynchronously(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Preview an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTPreviewOrderAsynchronously202Response</returns>
        ApiResponse<POSTPreviewOrderAsynchronously202Response> POSTPreviewOrderAsynchronouslyWithHttpInfo(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Update order action trigger dates
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PUTOrderTriggerDatesResponseType</returns>
        PUTOrderTriggerDatesResponseType PUTOrderTriggerDates(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Update order action trigger dates
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PUTOrderTriggerDatesResponseType</returns>
        ApiResponse<PUTOrderTriggerDatesResponseType> PUTOrderTriggerDatesWithHttpInfo(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Update order custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTUpdateOrderCustomFields(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Update order custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTUpdateOrderCustomFieldsWithHttpInfo(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Update subscription custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTUpdateSubscriptionCustomFields(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Update subscription custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTUpdateSubscriptionCustomFieldsWithHttpInfo(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOrdersApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> DELETEOrderAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETEOrderWithHttpInfoAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List orders
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAllOrdersResponseType</returns>
        System.Threading.Tasks.Task<GetAllOrdersResponseType> GETAllOrdersAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List orders
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAllOrdersResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetAllOrdersResponseType>> GETAllOrdersWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve the status and response of a job
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETJobStatusAndResponse200Response</returns>
        System.Threading.Tasks.Task<GETJobStatusAndResponse200Response> GETJobStatusAndResponseAsync(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve the status and response of a job
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETJobStatusAndResponse200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETJobStatusAndResponse200Response>> GETJobStatusAndResponseWithHttpInfoAsync(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve an order
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrderResponse</returns>
        System.Threading.Tasks.Task<GetOrderResponse> GETOrderAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve an order
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrderResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrderResponse>> GETOrderWithHttpInfoAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List order metrics for an evergreen subscription
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrderResponseForEvergreen</returns>
        System.Threading.Tasks.Task<GetOrderResponseForEvergreen> GETOrderMetricsforEvergreenSubscriptionAsync(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List order metrics for an evergreen subscription
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrderResponseForEvergreen)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrderResponseForEvergreen>> GETOrderMetricsforEvergreenSubscriptionWithHttpInfoAsync(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List orders of an invoice owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrdersResponse</returns>
        System.Threading.Tasks.Task<GetOrdersResponse> GETOrdersByInvoiceOwnerAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List orders of an invoice owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrdersResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrdersResponse>> GETOrdersByInvoiceOwnerWithHttpInfoAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List orders by subscription number
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrdersResponse</returns>
        System.Threading.Tasks.Task<GetOrdersResponse> GETOrdersBySubscriptionNumberAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List orders by subscription number
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrdersResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrdersResponse>> GETOrdersBySubscriptionNumberWithHttpInfoAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List orders of a subscription owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrdersResponse</returns>
        System.Threading.Tasks.Task<GetOrdersResponse> GETOrdersBySubscriptionOwnerAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List orders of a subscription owner
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrdersResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrdersResponse>> GETOrdersBySubscriptionOwnerWithHttpInfoAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List subscription terms
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetSubscriptionTermInfoResponseType</returns>
        System.Threading.Tasks.Task<GetSubscriptionTermInfoResponseType> GETSubscriptionTermInfoAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List subscription terms
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetSubscriptionTermInfoResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetSubscriptionTermInfoResponseType>> GETSubscriptionTermInfoWithHttpInfoAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTCreateOrderAsynchronously202Response</returns>
        System.Threading.Tasks.Task<POSTCreateOrderAsynchronously202Response> POSTCreateOrderAsynchronouslyAsync(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTCreateOrderAsynchronously202Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTCreateOrderAsynchronously202Response>> POSTCreateOrderAsynchronouslyWithHttpInfoAsync(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PostOrderResponseType</returns>
        System.Threading.Tasks.Task<PostOrderResponseType> POSTOrderAsync(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PostOrderResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PostOrderResponseType>> POSTOrderWithHttpInfoAsync(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Preview an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PostOrderPreviewResponseType</returns>
        System.Threading.Tasks.Task<PostOrderPreviewResponseType> POSTPreviewOrderAsync(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Preview an order
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PostOrderPreviewResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PostOrderPreviewResponseType>> POSTPreviewOrderWithHttpInfoAsync(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Preview an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTPreviewOrderAsynchronously202Response</returns>
        System.Threading.Tasks.Task<POSTPreviewOrderAsynchronously202Response> POSTPreviewOrderAsynchronouslyAsync(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Preview an order asynchronously
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTPreviewOrderAsynchronously202Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTPreviewOrderAsynchronously202Response>> POSTPreviewOrderAsynchronouslyWithHttpInfoAsync(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update order action trigger dates
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PUTOrderTriggerDatesResponseType</returns>
        System.Threading.Tasks.Task<PUTOrderTriggerDatesResponseType> PUTOrderTriggerDatesAsync(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update order action trigger dates
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PUTOrderTriggerDatesResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTOrderTriggerDatesResponseType>> PUTOrderTriggerDatesWithHttpInfoAsync(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update order custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTUpdateOrderCustomFieldsAsync(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update order custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTUpdateOrderCustomFieldsWithHttpInfoAsync(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update subscription custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTUpdateSubscriptionCustomFieldsAsync(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update subscription custom fields
        /// </summary>
        /// <remarks>
        /// **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTUpdateSubscriptionCustomFieldsWithHttpInfoAsync(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOrdersApi : IOrdersApiSync, IOrdersApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class OrdersApi : IOrdersApi
    {
        private ZuoraClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OrdersApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OrdersApi(string basePath)
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
        /// Initializes a new instance of the <see cref="OrdersApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public OrdersApi(ZuoraClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="OrdersApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public OrdersApi(ZuoraClient.Client.ISynchronousClient client, ZuoraClient.Client.IAsynchronousClient asyncClient, ZuoraClient.Client.IReadableConfiguration configuration)
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
        /// Delete an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType DELETEOrder(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = DELETEOrderWithHttpInfo(orderNumber, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ZuoraClient.Client.ApiResponse<CommonResponseType> DELETEOrderWithHttpInfo(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->DELETEOrder");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.DELETEOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Delete<CommonResponseType>("/v1/orders/{orderNumber}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> DELETEOrderAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = await DELETEOrderWithHttpInfoAsync(orderNumber, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Deletes a specified order.   * All the subscriptions changed by this order are deleted. After the deletion, the subscriptions are rolled back to the previous version.   * All the order line items created in this order are deleted.  You are not allowed to delete an order if the charges that are affected by this order are invoiced. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The number of the order to be deleted.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<CommonResponseType>> DELETEOrderWithHttpInfoAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->DELETEOrder");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.DELETEOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<CommonResponseType>("/v1/orders/{orderNumber}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAllOrdersResponseType</returns>
        public GetAllOrdersResponseType GETAllOrders(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetAllOrdersResponseType> localVarResponse = GETAllOrdersWithHttpInfo(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAllOrdersResponseType</returns>
        public ZuoraClient.Client.ApiResponse<GetAllOrdersResponseType> GETAllOrdersWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
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
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETAllOrders";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetAllOrdersResponseType>("/v1/orders", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETAllOrders", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAllOrdersResponseType</returns>
        public async System.Threading.Tasks.Task<GetAllOrdersResponseType> GETAllOrdersAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetAllOrdersResponseType> localVarResponse = await GETAllOrdersWithHttpInfoAsync(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves information about all orders in your tenant. By default, it returns the first page of the orders.  
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contains orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAllOrdersResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetAllOrdersResponseType>> GETAllOrdersWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETAllOrders";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetAllOrdersResponseType>("/v1/orders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETAllOrders", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the status and response of a job **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETJobStatusAndResponse200Response</returns>
        public GETJobStatusAndResponse200Response GETJobStatusAndResponse(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETJobStatusAndResponse200Response> localVarResponse = GETJobStatusAndResponseWithHttpInfo(jobId, authorization, zuoraTrackId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the status and response of a job **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETJobStatusAndResponse200Response</returns>
        public ZuoraClient.Client.ApiResponse<GETJobStatusAndResponse200Response> GETJobStatusAndResponseWithHttpInfo(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobId", ZuoraClient.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }

            localVarRequestOptions.Operation = "OrdersApi.GETJobStatusAndResponse";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETJobStatusAndResponse200Response>("/v1/async-jobs/{jobId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETJobStatusAndResponse", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the status and response of a job **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETJobStatusAndResponse200Response</returns>
        public async System.Threading.Tasks.Task<GETJobStatusAndResponse200Response> GETJobStatusAndResponseAsync(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETJobStatusAndResponse200Response> localVarResponse = await GETJobStatusAndResponseWithHttpInfoAsync(jobId, authorization, zuoraTrackId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the status and response of a job **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Get the status and response of an asynchronous job. Currently, an asynchronous job created by \&quot;Create an order asynchronously\&quot; or \&quot;Preview an order asynchronously\&quot; is supported. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">UUID of the asynchronous job created by an asynchronous API operation.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETJobStatusAndResponse200Response)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETJobStatusAndResponse200Response>> GETJobStatusAndResponseWithHttpInfoAsync(Guid jobId, string authorization = default(string), string zuoraTrackId = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobId", ZuoraClient.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }

            localVarRequestOptions.Operation = "OrdersApi.GETJobStatusAndResponse";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETJobStatusAndResponse200Response>("/v1/async-jobs/{jobId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETJobStatusAndResponse", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve an order **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrderResponse</returns>
        public GetOrderResponse GETOrder(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetOrderResponse> localVarResponse = GETOrderWithHttpInfo(orderNumber, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve an order **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrderResponse</returns>
        public ZuoraClient.Client.ApiResponse<GetOrderResponse> GETOrderWithHttpInfo(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->GETOrder");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetOrderResponse>("/v1/orders/{orderNumber}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve an order **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrderResponse</returns>
        public async System.Threading.Tasks.Task<GetOrderResponse> GETOrderAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetOrderResponse> localVarResponse = await GETOrderWithHttpInfoAsync(orderNumber, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve an order **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         Retrieves the detailed information about a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number to be retrieved.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrderResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetOrderResponse>> GETOrderWithHttpInfoAsync(string orderNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->GETOrder");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetOrderResponse>("/v1/orders/{orderNumber}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List order metrics for an evergreen subscription **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrderResponseForEvergreen</returns>
        public GetOrderResponseForEvergreen GETOrderMetricsforEvergreenSubscription(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetOrderResponseForEvergreen> localVarResponse = GETOrderMetricsforEvergreenSubscriptionWithHttpInfo(orderNumber, subscriptionNumber, startDate, endDate, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List order metrics for an evergreen subscription **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrderResponseForEvergreen</returns>
        public ZuoraClient.Client.ApiResponse<GetOrderResponseForEvergreen> GETOrderMetricsforEvergreenSubscriptionWithHttpInfo(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->GETOrderMetricsforEvergreenSubscription");
            }

            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->GETOrderMetricsforEvergreenSubscription");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
            localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrderMetricsforEvergreenSubscription";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetOrderResponseForEvergreen>("/v1/orders/{orderNumber}/evergreenMetrics/{subscriptionNumber}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrderMetricsforEvergreenSubscription", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List order metrics for an evergreen subscription **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrderResponseForEvergreen</returns>
        public async System.Threading.Tasks.Task<GetOrderResponseForEvergreen> GETOrderMetricsforEvergreenSubscriptionAsync(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetOrderResponseForEvergreen> localVarResponse = await GETOrderMetricsforEvergreenSubscriptionWithHttpInfoAsync(orderNumber, subscriptionNumber, startDate, endDate, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List order metrics for an evergreen subscription **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** As of Zuora Billing Release 306, Zuora has upgraded the methodologies for calculating metrics in [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders). The new methodologies are reflected in the following Order Delta Metrics objects.  * [Order Delta Mrr](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Mrr) * [Order Delta Tcv](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcv) * [Order Delta Tcb](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/Order_Delta_Tcb)  It is recommended that all customers use the new [Order Delta Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Delta_Metrics/AA_Overview_of_Order_Delta_Metrics). If you are an existing [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders) customer and want to migrate to Order Delta Metrics, submit a request at [Zuora Global Support](https://support.zuora.com/).  Whereas new customers, and existing customers not currently on [Order Metrics](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders/Key_Metrics_for_Orders), will no longer have access to Order Metrics, existing customers currently using Order Metrics will continue to be supported.  **Note:** As of Zuora Billing Release 306, any new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) or [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization) will no longer get this operation.   Retrieves the metrics of an evergreen subscription in a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number. </param>
        /// <param name="subscriptionNumber">The subscription number you want to get the metrics for. </param>
        /// <param name="startDate">The start date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="endDate">The end date of the date range for which you want to get the metrics. The date must be in yyyy-mm-dd format. For example, 2017-12-03. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrderResponseForEvergreen)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetOrderResponseForEvergreen>> GETOrderMetricsforEvergreenSubscriptionWithHttpInfoAsync(string orderNumber, string subscriptionNumber, DateTime startDate, DateTime endDate, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->GETOrderMetricsforEvergreenSubscription");
            }

            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->GETOrderMetricsforEvergreenSubscription");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
            localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrderMetricsforEvergreenSubscription";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetOrderResponseForEvergreen>("/v1/orders/{orderNumber}/evergreenMetrics/{subscriptionNumber}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrderMetricsforEvergreenSubscription", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders of an invoice owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrdersResponse</returns>
        public GetOrdersResponse GETOrdersByInvoiceOwner(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetOrdersResponse> localVarResponse = GETOrdersByInvoiceOwnerWithHttpInfo(accountNumber, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders of an invoice owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrdersResponse</returns>
        public ZuoraClient.Client.ApiResponse<GetOrdersResponse> GETOrdersByInvoiceOwnerWithHttpInfo(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
        {
            // verify the required parameter 'accountNumber' is set
            if (accountNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'accountNumber' when calling OrdersApi->GETOrdersByInvoiceOwner");
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

            localVarRequestOptions.PathParameters.Add("accountNumber", ZuoraClient.Client.ClientUtils.ParameterToString(accountNumber)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrdersByInvoiceOwner";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetOrdersResponse>("/v1/orders/invoiceOwner/{accountNumber}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrdersByInvoiceOwner", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders of an invoice owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrdersResponse</returns>
        public async System.Threading.Tasks.Task<GetOrdersResponse> GETOrdersByInvoiceOwnerAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetOrdersResponse> localVarResponse = await GETOrdersByInvoiceOwnerWithHttpInfoAsync(accountNumber, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders of an invoice owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified invoice owner. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The invoice owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be orderDate or updatedDate. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of dateFilterOption later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of dateFilterOption earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrdersResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetOrdersResponse>> GETOrdersByInvoiceOwnerWithHttpInfoAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'accountNumber' is set
            if (accountNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'accountNumber' when calling OrdersApi->GETOrdersByInvoiceOwner");
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

            localVarRequestOptions.PathParameters.Add("accountNumber", ZuoraClient.Client.ClientUtils.ParameterToString(accountNumber)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrdersByInvoiceOwner";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetOrdersResponse>("/v1/orders/invoiceOwner/{accountNumber}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrdersByInvoiceOwner", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders by subscription number **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrdersResponse</returns>
        public GetOrdersResponse GETOrdersBySubscriptionNumber(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetOrdersResponse> localVarResponse = GETOrdersBySubscriptionNumberWithHttpInfo(subscriptionNumber, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders by subscription number **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrdersResponse</returns>
        public ZuoraClient.Client.ApiResponse<GetOrdersResponse> GETOrdersBySubscriptionNumberWithHttpInfo(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
        {
            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->GETOrdersBySubscriptionNumber");
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

            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrdersBySubscriptionNumber";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetOrdersResponse>("/v1/orders/subscription/{subscriptionNumber}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrdersBySubscriptionNumber", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders by subscription number **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrdersResponse</returns>
        public async System.Threading.Tasks.Task<GetOrdersResponse> GETOrdersBySubscriptionNumberAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetOrdersResponse> localVarResponse = await GETOrdersBySubscriptionNumberWithHttpInfoAsync(subscriptionNumber, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders by subscription number **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.   Retrieves the detailed information about all orders except for the pending orders for a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrdersResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetOrdersResponse>> GETOrdersBySubscriptionNumberWithHttpInfoAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->GETOrdersBySubscriptionNumber");
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

            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrdersBySubscriptionNumber";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetOrdersResponse>("/v1/orders/subscription/{subscriptionNumber}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrdersBySubscriptionNumber", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders of a subscription owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOrdersResponse</returns>
        public GetOrdersResponse GETOrdersBySubscriptionOwner(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetOrdersResponse> localVarResponse = GETOrdersBySubscriptionOwnerWithHttpInfo(accountNumber, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders of a subscription owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOrdersResponse</returns>
        public ZuoraClient.Client.ApiResponse<GetOrdersResponse> GETOrdersBySubscriptionOwnerWithHttpInfo(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0)
        {
            // verify the required parameter 'accountNumber' is set
            if (accountNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'accountNumber' when calling OrdersApi->GETOrdersBySubscriptionOwner");
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

            localVarRequestOptions.PathParameters.Add("accountNumber", ZuoraClient.Client.ClientUtils.ParameterToString(accountNumber)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrdersBySubscriptionOwner";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetOrdersResponse>("/v1/orders/subscriptionOwner/{accountNumber}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrdersBySubscriptionOwner", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List orders of a subscription owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOrdersResponse</returns>
        public async System.Threading.Tasks.Task<GetOrdersResponse> GETOrdersBySubscriptionOwnerAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetOrdersResponse> localVarResponse = await GETOrdersBySubscriptionOwnerWithHttpInfoAsync(accountNumber, authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, dateFilterOption, startDate, endDate, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List orders of a subscription owner **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          Retrieves the detailed information about all orders for a specified subscription owner. Any orders containing the changes on the subscriptions owned by this account are returned. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountNumber">The subscription owner account number.</param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="dateFilterOption">The date type to filter on. This field value can be &#39;orderDate&#39; or &#39;updatedDate&#39;. Default is orderDate.  (optional)</param>
        /// <param name="startDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; later than or equal to this date.  (optional)</param>
        /// <param name="endDate">The result will only contain the orders with the date of &#39;dateFilterOption&#39; earlier than or equal to this date.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOrdersResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetOrdersResponse>> GETOrdersBySubscriptionOwnerWithHttpInfoAsync(string accountNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string dateFilterOption = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'accountNumber' is set
            if (accountNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'accountNumber' when calling OrdersApi->GETOrdersBySubscriptionOwner");
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

            localVarRequestOptions.PathParameters.Add("accountNumber", ZuoraClient.Client.ClientUtils.ParameterToString(accountNumber)); // path parameter
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (dateFilterOption != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "dateFilterOption", dateFilterOption));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
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

            localVarRequestOptions.Operation = "OrdersApi.GETOrdersBySubscriptionOwner";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetOrdersResponse>("/v1/orders/subscriptionOwner/{accountNumber}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETOrdersBySubscriptionOwner", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List subscription terms **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetSubscriptionTermInfoResponseType</returns>
        public GetSubscriptionTermInfoResponseType GETSubscriptionTermInfo(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GetSubscriptionTermInfoResponseType> localVarResponse = GETSubscriptionTermInfoWithHttpInfo(subscriptionNumber, authorization, zuoraTrackId, zuoraEntityIds, version, page, pageSize);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List subscription terms **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetSubscriptionTermInfoResponseType</returns>
        public ZuoraClient.Client.ApiResponse<GetSubscriptionTermInfoResponseType> GETSubscriptionTermInfoWithHttpInfo(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->GETSubscriptionTermInfo");
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

            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
            if (version != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "version", version));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
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

            localVarRequestOptions.Operation = "OrdersApi.GETSubscriptionTermInfo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetSubscriptionTermInfoResponseType>("/v1/orders/term/{subscriptionNumber}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETSubscriptionTermInfo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List subscription terms **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetSubscriptionTermInfoResponseType</returns>
        public async System.Threading.Tasks.Task<GetSubscriptionTermInfoResponseType> GETSubscriptionTermInfoAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GetSubscriptionTermInfoResponseType> localVarResponse = await GETSubscriptionTermInfoWithHttpInfoAsync(subscriptionNumber, authorization, zuoraTrackId, zuoraEntityIds, version, page, pageSize, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List subscription terms **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  Retrieves the terms of the specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The number of the subscription to retrieve terms for. For example, A-S00000001. </param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="version">The version of the subscription to retrieve terms for. If you do not specify this parameter, Zuora returns the terms for the latest version of the subscription.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetSubscriptionTermInfoResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GetSubscriptionTermInfoResponseType>> GETSubscriptionTermInfoWithHttpInfoAsync(string subscriptionNumber, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? version = default(int?), int? page = default(int?), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->GETSubscriptionTermInfo");
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

            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
            if (version != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "version", version));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
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

            localVarRequestOptions.Operation = "OrdersApi.GETSubscriptionTermInfo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetSubscriptionTermInfoResponseType>("/v1/orders/term/{subscriptionNumber}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETSubscriptionTermInfo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTCreateOrderAsynchronously202Response</returns>
        public POSTCreateOrderAsynchronously202Response POSTCreateOrderAsynchronously(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<POSTCreateOrderAsynchronously202Response> localVarResponse = POSTCreateOrderAsynchronouslyWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds, returnIds, zuoraVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTCreateOrderAsynchronously202Response</returns>
        public ZuoraClient.Client.ApiResponse<POSTCreateOrderAsynchronously202Response> POSTCreateOrderAsynchronouslyWithHttpInfo(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTCreateOrderAsynchronously");
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

            if (returnIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "returnIds", returnIds));
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

            localVarRequestOptions.Operation = "OrdersApi.POSTCreateOrderAsynchronously";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<POSTCreateOrderAsynchronously202Response>("/v1/async/orders", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateOrderAsynchronously", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTCreateOrderAsynchronously202Response</returns>
        public async System.Threading.Tasks.Task<POSTCreateOrderAsynchronously202Response> POSTCreateOrderAsynchronouslyAsync(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<POSTCreateOrderAsynchronously202Response> localVarResponse = await POSTCreateOrderAsynchronouslyWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, returnIds, zuoraVersion, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        In the case where a normal \&quot;Create an order\&quot; operation call will time out, use this operation instead to create an order asynchronously. A job will be creating the order in the back end; the job ID will be returned for tracking the job status and result.   The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs for the [Get job status and response](https://www.zuora.com/developer/api-reference/#operation/GET_JobStatusAndResponse) operation. If you set this query parameter to &#x60;true&#x60;, the corresponding IDs, which are associated with the numbers returned in this operation, can be returned in the \&quot;Get job status and response\&quot; response body.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you want to use the following fields: * subscriptions * subscriptionNumbers * subscriptionIds (when the &#x60;returnId&#x60; query parameter is set to &#x60;true&#x60;)  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTCreateOrderAsynchronously202Response)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<POSTCreateOrderAsynchronously202Response>> POSTCreateOrderAsynchronouslyWithHttpInfoAsync(POSTOrderAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTCreateOrderAsynchronously");
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

            if (returnIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "returnIds", returnIds));
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

            localVarRequestOptions.Operation = "OrdersApi.POSTCreateOrderAsynchronously";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<POSTCreateOrderAsynchronously202Response>("/v1/async/orders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateOrderAsynchronously", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PostOrderResponseType</returns>
        public PostOrderResponseType POSTOrder(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<PostOrderResponseType> localVarResponse = POSTOrderWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds, returnIds, zuoraVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PostOrderResponseType</returns>
        public ZuoraClient.Client.ApiResponse<PostOrderResponseType> POSTOrderWithHttpInfo(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTOrder");
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

            if (returnIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "returnIds", returnIds));
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

            localVarRequestOptions.Operation = "OrdersApi.POSTOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<PostOrderResponseType>("/v1/orders", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PostOrderResponseType</returns>
        public async System.Threading.Tasks.Task<PostOrderResponseType> POSTOrderAsync(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<PostOrderResponseType> localVarResponse = await POSTOrderWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, returnIds, zuoraVersion, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.         You can use this operation to create subscriptions and make changes to subscriptions by creating orders. You can also use this operation to create order line items by creating orders. The following tutorials demonstrate how to use this operation:   * [Create a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Create_a_Subscription)  * [Add a Product to a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/A_Add_a_Product_to_a_Subscription)  * [Create a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/B_Create_a_Ramp_Deal)  * [Add a Product Mid-Interval Update on a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/E_Update_a_Product_in_a_Ramp_Deal)  * [Add a Product in a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/C_Add_a_Product_in_a_Ramp_Deal)  * [Change the Terms and Conditions of a Ramp Deal](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Ramps_and_Ramp_Metrics/D_Change_the_Terms_and_Conditions_of_a_Ramp_Deal_and_Update_the_Ramp)  * [Change the Owner of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Owner_of_a_Subscription)  * [Change the Terms and Conditions of a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Change_the_Terms_and_Conditions_of_a_Subscription)  * [Renew a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription)  * [Renew a Subscription and Upgrade a Product](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Renew_a_Subscription_and_Upgrade_a_Product)  * [Replace a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Replace_a_Product_in_a_Subscription)  * [Update a Product in a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/C_Update_a_Product_in_a_Subscription)  * [Cancel a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Cancel_a_Subscription)  * [Remove a Product from a Subscription](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AC_Orders_Tutorials/D_Remove_a_Product_from_a_Subscription)  * [Create an order line item](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item)  * [Create an order line item with a new subscription](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/Create_an_order_line_item_with_a_new_subscription)  You can also see the [API Guides](https://www.zuora.com/developer/api-guides/) for more use cases of the \&quot;Create an order\&quot; operation.  Creating a draft order is currently not supported. See [Known Limitations in Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/C_Known_Limitations_in_Orders) for additional limitations.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com).          **Note:** When you are to suspend a subcription (via the &#x60;suspend&#x60; order action), if in the same \&quot;Create an order\&quot; call you are to perform other subsequent order actions on the supscription to suspend, you must first resume the subscription (via a &#x60;resume&#x60; order action).   **Note:** When using this operation to create an account, create a subscription, run billing, and collect payment in a single call, if any error occurs during the call, such as a payment processing failure and a tax engine failure, then all the other steps will be rolled back. This means that the invoice will not be generated, the subscription will not be created, and the account will not be created. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="returnIds">Specify whether to return IDs associated with the numbers returned in the \&quot;Create an order\&quot; operation.  (optional, default to false)</param>
        /// <param name="zuoraVersion"> The minor version of the Zuora REST API.   You need to set this parameter if you use the following fields: * subscriptions * subscriptionNumbers  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PostOrderResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<PostOrderResponseType>> POSTOrderWithHttpInfoAsync(POSTOrderRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), bool? returnIds = default(bool?), string zuoraVersion = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTOrder");
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

            if (returnIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "returnIds", returnIds));
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

            localVarRequestOptions.Operation = "OrdersApi.POSTOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<PostOrderResponseType>("/v1/orders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Preview an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PostOrderPreviewResponseType</returns>
        public PostOrderPreviewResponseType POSTPreviewOrder(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<PostOrderPreviewResponseType> localVarResponse = POSTPreviewOrderWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Preview an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PostOrderPreviewResponseType</returns>
        public ZuoraClient.Client.ApiResponse<PostOrderPreviewResponseType> POSTPreviewOrderWithHttpInfo(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTPreviewOrder");
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

            localVarRequestOptions.Operation = "OrdersApi.POSTPreviewOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<PostOrderPreviewResponseType>("/v1/orders/preview", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTPreviewOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Preview an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PostOrderPreviewResponseType</returns>
        public async System.Threading.Tasks.Task<PostOrderPreviewResponseType> POSTPreviewOrderAsync(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<PostOrderPreviewResponseType> localVarResponse = await POSTPreviewOrderWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Preview an order **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.        Retrieves the preview of the charge metrics and invoice items of a specified order. Preview for subscriptions and order line items are both supported. This operation is only an order preview and no order is created.    See [Preview a Subscription Creation Order](https://www.zuora.com/developer/api-guides/#Create-a-subscription-for-a-new-customer) for a use case of the \&quot;Preview an order\&quot; operation.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PostOrderPreviewResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<PostOrderPreviewResponseType>> POSTPreviewOrderWithHttpInfoAsync(POSTOrderPreviewRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTPreviewOrder");
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

            localVarRequestOptions.Operation = "OrdersApi.POSTPreviewOrder";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<PostOrderPreviewResponseType>("/v1/orders/preview", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTPreviewOrder", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Preview an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>POSTPreviewOrderAsynchronously202Response</returns>
        public POSTPreviewOrderAsynchronously202Response POSTPreviewOrderAsynchronously(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<POSTPreviewOrderAsynchronously202Response> localVarResponse = POSTPreviewOrderAsynchronouslyWithHttpInfo(body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Preview an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of POSTPreviewOrderAsynchronously202Response</returns>
        public ZuoraClient.Client.ApiResponse<POSTPreviewOrderAsynchronously202Response> POSTPreviewOrderAsynchronouslyWithHttpInfo(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTPreviewOrderAsynchronously");
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

            localVarRequestOptions.Operation = "OrdersApi.POSTPreviewOrderAsynchronously";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<POSTPreviewOrderAsynchronously202Response>("/v1/async/orders/preview", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTPreviewOrderAsynchronously", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Preview an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of POSTPreviewOrderAsynchronously202Response</returns>
        public async System.Threading.Tasks.Task<POSTPreviewOrderAsynchronously202Response> POSTPreviewOrderAsynchronouslyAsync(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<POSTPreviewOrderAsynchronously202Response> localVarResponse = await POSTPreviewOrderAsynchronouslyWithHttpInfoAsync(body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Preview an order asynchronously **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  **Note:** The [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature is now generally available to all Zuora customers. You need to enable the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature to access the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items/AA_Overview_of_Order_Line_Items) feature. As of Zuora Billing Release 313 (November 2021), new customers who onboard on [Orders](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/AA_Overview_of_Orders) will have the [Order Line Items](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Order_Line_Items) feature enabled by default.          In the case where a normal \&quot;Preview an order\&quot; operation call will time out, use this operation instead to preview an order asynchronously. A job will be previewing the order in the back end; the job ID will be returned for tracking the job status and result.  The limit of orders allowed on a subscription is 1000.  The limit of order line items allowed in an order is 100.  Zuora has the following limits on the Orders synchronous API to prevent performance degradation:  * Up to 50 subscriptions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed in a single [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call. * Up to 50 order actions are allowed on a single subscription in a [Create an order](https://www.zuora.com/developer/api-reference/#operation/POST_Order) or [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder) operation call.  If you have an Order that exceeds any limits of the above, Zuora recommends you use the following asynchronous API operations: * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)  Zuora has the following limits on the Orders asynchronous API operations to prevent performance degradation: * Up to 300 subscriptions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed in a single [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call. * Up to 300 order actions are allowed on a single subscription in a [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously) or [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously) operation call.  If you have a need for a large order that exceeds any limits of the above, you can request a limit increase for the Orders asynchronous API by submitting a request at [Zuora Global Support](https://support.zuora.com). 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (POSTPreviewOrderAsynchronously202Response)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<POSTPreviewOrderAsynchronously202Response>> POSTPreviewOrderAsynchronouslyWithHttpInfoAsync(POSTOrderPreviewAsyncRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->POSTPreviewOrderAsynchronously");
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

            localVarRequestOptions.Operation = "OrdersApi.POSTPreviewOrderAsynchronously";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<POSTPreviewOrderAsynchronously202Response>("/v1/async/orders/preview", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTPreviewOrderAsynchronously", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update order action trigger dates **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PUTOrderTriggerDatesResponseType</returns>
        public PUTOrderTriggerDatesResponseType PUTOrderTriggerDates(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<PUTOrderTriggerDatesResponseType> localVarResponse = PUTOrderTriggerDatesWithHttpInfo(orderNumber, body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update order action trigger dates **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PUTOrderTriggerDatesResponseType</returns>
        public ZuoraClient.Client.ApiResponse<PUTOrderTriggerDatesResponseType> PUTOrderTriggerDatesWithHttpInfo(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->PUTOrderTriggerDates");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->PUTOrderTriggerDates");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.PUTOrderTriggerDates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<PUTOrderTriggerDatesResponseType>("/v1/orders/{orderNumber}/triggerDates", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTOrderTriggerDates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update order action trigger dates **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PUTOrderTriggerDatesResponseType</returns>
        public async System.Threading.Tasks.Task<PUTOrderTriggerDatesResponseType> PUTOrderTriggerDatesAsync(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<PUTOrderTriggerDatesResponseType> localVarResponse = await PUTOrderTriggerDatesWithHttpInfoAsync(orderNumber, body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update order action trigger dates **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the triggering dates for either of the following order actions:  * CreateSubscription  * AddProduct  * UpdateProduct  * RemoveProduct  * RenewSubscription  * TermsAndConditions 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">Order number of a pending order in which you are to update an order action&#39;s triggering dates.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PUTOrderTriggerDatesResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<PUTOrderTriggerDatesResponseType>> PUTOrderTriggerDatesWithHttpInfoAsync(string orderNumber, PUTOrderActionTriggerDatesRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->PUTOrderTriggerDates");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->PUTOrderTriggerDates");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.PUTOrderTriggerDates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<PUTOrderTriggerDatesResponseType>("/v1/orders/{orderNumber}/triggerDates", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTOrderTriggerDates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update order custom fields **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTUpdateOrderCustomFields(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = PUTUpdateOrderCustomFieldsWithHttpInfo(orderNumber, body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update order custom fields **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ZuoraClient.Client.ApiResponse<CommonResponseType> PUTUpdateOrderCustomFieldsWithHttpInfo(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->PUTUpdateOrderCustomFields");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->PUTUpdateOrderCustomFields");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.PUTUpdateOrderCustomFields";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<CommonResponseType>("/v1/orders/{orderNumber}/customFields", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateOrderCustomFields", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update order custom fields **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTUpdateOrderCustomFieldsAsync(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = await PUTUpdateOrderCustomFieldsWithHttpInfoAsync(orderNumber, body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update order custom fields **Note:** This feature is only available if you have the [Order Metrics](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Order_Metrics) feature enabled. As of Zuora Billing Release 284, Orders is generally available and the Order Metrics feature is no longer available as a standalone feature. If you are an existing Subscribe and Amend customer and want Order Metrics only, you must turn on [Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization). You can still keep the existing Subscribe and Amend API integrations to create and manage subscriptions.  **Note:** To update the custom fields of an order line item, you must use the \&quot;Update an order line item\&quot; or \&quot;Update order line items\&quot; operation.  Updates the custom fields of a specified order. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<CommonResponseType>> PUTUpdateOrderCustomFieldsWithHttpInfoAsync(string orderNumber, PUTOrderPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'orderNumber' is set
            if (orderNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'orderNumber' when calling OrdersApi->PUTUpdateOrderCustomFields");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->PUTUpdateOrderCustomFields");
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

            localVarRequestOptions.PathParameters.Add("orderNumber", ZuoraClient.Client.ClientUtils.ParameterToString(orderNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.PUTUpdateOrderCustomFields";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<CommonResponseType>("/v1/orders/{orderNumber}/customFields", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateOrderCustomFields", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update subscription custom fields **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTUpdateSubscriptionCustomFields(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = PUTUpdateSubscriptionCustomFieldsWithHttpInfo(subscriptionNumber, body, authorization, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update subscription custom fields **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ZuoraClient.Client.ApiResponse<CommonResponseType> PUTUpdateSubscriptionCustomFieldsWithHttpInfo(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->PUTUpdateSubscriptionCustomFields");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->PUTUpdateSubscriptionCustomFields");
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

            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.PUTUpdateSubscriptionCustomFields";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<CommonResponseType>("/v1/subscriptions/{subscriptionNumber}/customFields", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateSubscriptionCustomFields", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update subscription custom fields **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTUpdateSubscriptionCustomFieldsAsync(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<CommonResponseType> localVarResponse = await PUTUpdateSubscriptionCustomFieldsWithHttpInfoAsync(subscriptionNumber, body, authorization, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update subscription custom fields **Note:** This operation is only available if you have the [Orders](https://knowledgecenter.zuora.com/BC_Subscription_Management/Orders/AA_Overview_of_Orders#Orders) feature enabled. Orders is now generally available as of Zuora Billing Release 284 (August 2020). If you are an existing Zuora Subscribe and Amend customer and want to adopt Orders, see [What is Orders Harmonization](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Harmonization#What_is_Orders_Harmonization.3F) and join the [Orders Harmonization community group](https://community.zuora.com/t5/Orders-Harmonization/gp-p/Orders-Harmonization) for more information. If you want to enable Orders, submit a request at [Zuora Global Support](https://support.zuora.com/).  Updates the custom fields of a specified subscription. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionNumber">The subscription number to be updated.</param>
        /// <param name="body"></param>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<CommonResponseType>> PUTUpdateSubscriptionCustomFieldsWithHttpInfoAsync(string subscriptionNumber, PUTSubscriptionPatchRequestType body, string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'subscriptionNumber' is set
            if (subscriptionNumber == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'subscriptionNumber' when calling OrdersApi->PUTUpdateSubscriptionCustomFields");
            }

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'body' when calling OrdersApi->PUTUpdateSubscriptionCustomFields");
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

            localVarRequestOptions.PathParameters.Add("subscriptionNumber", ZuoraClient.Client.ClientUtils.ParameterToString(subscriptionNumber)); // path parameter
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

            localVarRequestOptions.Operation = "OrdersApi.PUTUpdateSubscriptionCustomFields";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<CommonResponseType>("/v1/subscriptions/{subscriptionNumber}/customFields", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateSubscriptionCustomFields", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
