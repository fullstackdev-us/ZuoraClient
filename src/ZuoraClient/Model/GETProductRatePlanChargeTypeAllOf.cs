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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = ZuoraClient.Client.OpenAPIDateConverter;

namespace ZuoraClient.Model
{
    /// <summary>
    /// GETProductRatePlanChargeTypeAllOf
    /// </summary>
    [DataContract(Name = "GETProductRatePlanChargeType_allOf")]
    public partial class GETProductRatePlanChargeTypeAllOf : IEquatable<GETProductRatePlanChargeTypeAllOf>, IValidatableObject
    {
        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information.  
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information.  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CreditOptionEnum
        {
            /// <summary>
            /// Enum TimeBased for value: TimeBased
            /// </summary>
            [EnumMember(Value = "TimeBased")]
            TimeBased = 1,

            /// <summary>
            /// Enum ConsumptionBased for value: ConsumptionBased
            /// </summary>
            [EnumMember(Value = "ConsumptionBased")]
            ConsumptionBased = 2,

            /// <summary>
            /// Enum FullCreditBack for value: FullCreditBack
            /// </summary>
            [EnumMember(Value = "FullCreditBack")]
            FullCreditBack = 3

        }


        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information.  
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information.  </value>
        [DataMember(Name = "creditOption", EmitDefaultValue = false)]
        public CreditOptionEnum? CreditOption { get; set; }
        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PrepaidOperationTypeEnum
        {
            /// <summary>
            /// Enum Topup for value: topup
            /// </summary>
            [EnumMember(Value = "topup")]
            Topup = 1,

            /// <summary>
            /// Enum Drawdown for value: drawdown
            /// </summary>
            [EnumMember(Value = "drawdown")]
            Drawdown = 2

        }


        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  </value>
        [DataMember(Name = "prepaidOperationType", EmitDefaultValue = false)]
        public PrepaidOperationTypeEnum? PrepaidOperationType { get; set; }
        /// <summary>
        /// Specifies when revenue recognition begins. 
        /// </summary>
        /// <value>Specifies when revenue recognition begins. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RevRecTriggerConditionEnum
        {
            /// <summary>
            /// Enum ContractEffectiveDate for value: ContractEffectiveDate
            /// </summary>
            [EnumMember(Value = "ContractEffectiveDate")]
            ContractEffectiveDate = 1,

            /// <summary>
            /// Enum ServiceActivationDate for value: ServiceActivationDate
            /// </summary>
            [EnumMember(Value = "ServiceActivationDate")]
            ServiceActivationDate = 2,

            /// <summary>
            /// Enum CustomerAcceptanceDate for value: CustomerAcceptanceDate
            /// </summary>
            [EnumMember(Value = "CustomerAcceptanceDate")]
            CustomerAcceptanceDate = 3

        }


        /// <summary>
        /// Specifies when revenue recognition begins. 
        /// </summary>
        /// <value>Specifies when revenue recognition begins. </value>
        [DataMember(Name = "revRecTriggerCondition", EmitDefaultValue = false)]
        public RevRecTriggerConditionEnum? RevRecTriggerCondition { get; set; }
        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ValidityPeriodTypeEnum
        {
            /// <summary>
            /// Enum SUBSCRIPTIONTERM for value: SUBSCRIPTION_TERM
            /// </summary>
            [EnumMember(Value = "SUBSCRIPTION_TERM")]
            SUBSCRIPTIONTERM = 1,

            /// <summary>
            /// Enum ANNUAL for value: ANNUAL
            /// </summary>
            [EnumMember(Value = "ANNUAL")]
            ANNUAL = 2,

            /// <summary>
            /// Enum SEMIANNUAL for value: SEMI_ANNUAL
            /// </summary>
            [EnumMember(Value = "SEMI_ANNUAL")]
            SEMIANNUAL = 3,

            /// <summary>
            /// Enum QUARTER for value: QUARTER
            /// </summary>
            [EnumMember(Value = "QUARTER")]
            QUARTER = 4,

            /// <summary>
            /// Enum MONTH for value: MONTH
            /// </summary>
            [EnumMember(Value = "MONTH")]
            MONTH = 5

        }


        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [DataMember(Name = "validityPeriodType", EmitDefaultValue = false)]
        public ValidityPeriodTypeEnum? ValidityPeriodType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GETProductRatePlanChargeTypeAllOf" /> class.
        /// </summary>
        /// <param name="applyDiscountTo">Specifies where (to what charge type) the discount will be applied. These field values are case-sensitive.  Permissible values: - RECURRING - USAGE - ONETIMERECURRING - ONETIMEUSAGE - RECURRINGUSAGE - ONETIMERECURRINGUSAGE .</param>
        /// <param name="billingDay">The bill cycle day (BCD) for the charge. The BCD determines which day of the month or week the customer is billed. The BCD value in the account can override the BCD in this object. .</param>
        /// <param name="billingPeriod">The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values: - Month - Quarter - Annual - Semi-Annual - Specific Months - Week - Specific_Weeks .</param>
        /// <param name="billingPeriodAlignment">Aligns charges within the same subscription if multiple charges begin on different dates.  Possible values: - AlignToCharge - AlignToSubscriptionStart - AlignToTermStart .</param>
        /// <param name="billingTiming">The billing timing for the charge. You can choose to bill for charges in advance or in arrears.  Values: - In Advance - In Arrears  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  .</param>
        /// <param name="chargeModelConfigurations">This field is for Zuora Internal Use only. See the **pricing** field for the same information as this field..</param>
        /// <param name="creditOption">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information.  .</param>
        /// <param name="defaultQuantity">The default quantity of units.  This field is required if you use a per-unit charge model. .</param>
        /// <param name="description">Usually a brief line item summary of the Rate Plan Charge. .</param>
        /// <param name="discountClass">The class that the discount belongs to. The discount class defines the order in which discount product rate plan charges are applied.  For more information, see [Manage Discount Classes](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models/Manage_Discount_Classes). .</param>
        /// <param name="discountLevel">The level of the discount.   Values: - RatePlan - Subscription - Account .</param>
        /// <param name="drawdownRate">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The [conversion rate](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge#UOM_Conversion) between Usage UOM and Drawdown UOM for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). Must be a positive number (&gt;0). .</param>
        /// <param name="drawdownUom">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). .</param>
        /// <param name="endDateCondition">Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values: - Subscription_End - Fixed_Period .</param>
        /// <param name="excludeItemBillingFromRevenueAccounting">The flag to exclude the related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="excludeItemBookingFromRevenueAccounting">The flag to exclude the related rate plan charges and order line items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="financeInformation">financeInformation.</param>
        /// <param name="formula">The pricing formula to calculate the actual rating amount for each usage record.  This field is only available for the usage-based charges that use the Multi-Attribute Pricing charge model. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information. .</param>
        /// <param name="id">Unique product rate-plan charge ID. .</param>
        /// <param name="includedUnits">Specifies the number of units in the base set of units when the charge model is Overage. .</param>
        /// <param name="isPrepaid">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Indicates whether this charge is a prepayment (topup) charge or a drawdown charge. Values: &#x60;true&#x60; or &#x60;false&#x60;. .</param>
        /// <param name="listPriceBase">The list price base for the product rate plan charge.  Values: - Month - Billing Period - Per_Week .</param>
        /// <param name="maxQuantity">Specifies the maximum number of units for this charge. Use this field and the &#x60;minQuantity&#x60; field to create a range of units allowed in a product rate plan charge. .</param>
        /// <param name="minQuantity">Specifies the minimum number of units for this charge. Use this field and the &#x60;maxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. .</param>
        /// <param name="model">Charge model which determines how charges are calculated. Charge models must be individually activated in Zuora Billing administration.   Possible values are: - &#x60;FlatFee&#x60; - &#x60;PerUnit&#x60; - &#x60;Overage&#x60; - &#x60;Volume&#x60; - &#x60;Tiered&#x60; - &#x60;TieredWithOverage&#x60; - &#x60;DiscountFixedAmount&#x60; - &#x60;DiscountPercentage&#x60; - &#x60;MultiAttributePricing&#x60; (available only if you have the Multi-Attribute Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;PreratedPerUnit&#x60; (available only if you have the Pre-rated Per Unit Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;PreratedPricing&#x60; (available only if you have the Pre-rated Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;HighWatermarkVolumePricing&#x60; (available only if you have the High Water Mark Volume Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;HighWatermarkTieredPricing&#x60; (available only if you have the High Water Mark Tiered Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.)  The value of the &#x60;pricing&#x60; field contains details about these charge models and the value of &#x60;pricingSummary&#x60; field contains their associated pricing summary values. .</param>
        /// <param name="name">Name of the product rate-plan charge. (Not required to be unique.) .</param>
        /// <param name="numberOfPeriods">Value specifies the number of periods used in the smoothing model calculations Used when overage smoothing model is &#x60;RollingWindow&#x60; or &#x60;Rollover&#x60;. .</param>
        /// <param name="overageCalculationOption">Value specifies when to calculate overage charges.  Values: - EndOfSmoothingPeriod - PerBillingPeriod .</param>
        /// <param name="overageUnusedUnitsCreditOption">Determines whether to credit the customer with unused units of usage.  Values: - NoCredit - CreditBySpecificRate .</param>
        /// <param name="prepaidOperationType">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  .</param>
        /// <param name="prepaidQuantity">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The number of units included in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). Must be a positive number (&gt;0). .</param>
        /// <param name="prepaidTotalQuantity">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The total amount of units that end customers can use during a validity period when they subscribe to a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). .</param>
        /// <param name="prepaidUom">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). .</param>
        /// <param name="prepayPeriods">The number of periods to which prepayment is set.   **Note:** This field is only available if you already have the prepayment feature enabled. The prepayment feature is deprecated and available only for backward compatibility. Zuora does not support enabling this feature anymore. .</param>
        /// <param name="priceChangeOption">Applies an automatic price change when a termed subscription is renewed and the following applies:  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: - NoChange (default) - SpecificPercentageValue - UseLatestProductCatalogPricing .</param>
        /// <param name="priceIncreasePercentage">Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the &#x60;PriceChangeOption&#x60; value to &#x60;SpecificPercentageValue&#x60;.  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: a decimal between -100 and 100 .</param>
        /// <param name="pricing">One or more price charge models with attributes that further describe the model.  Some attributes show as null values when not applicable. .</param>
        /// <param name="pricingSummary">A concise description of the charge model and pricing that is suitable to show to your customers. When the rate plan charge model is &#x60;Tiered&#x60; and multi-currency is enabled, this field includes an array of string of each currency, and each string of currency includes tier price description separated by comma.  For the following charge models, the value of this field is an empty string: - Multi-Attribute Pricing - High Water Mark Tiered Pricing - High Water Mark Volume Pricing - Pre-Rated Per Unit Pricing - Pre-Rated Pricing  The charge models are available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information. .</param>
        /// <param name="productDiscountApplyDetails">Container for the application details about a discount product rate plan charge.   Only discount product rate plan charges have values in this field. .</param>
        /// <param name="ratingGroup">Specifies a rating group based on which usage records are rated.  Possible values:  - &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  **Note:**  - The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models.  - The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models.  - The &#x60;ByGroupId&#x60; value is only available if you have the Active Rating feature enabled. - Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. .</param>
        /// <param name="revRecCode">Associates this product rate plan charge with a specific revenue recognition code. The value is a valid revenue recognition code. .</param>
        /// <param name="revRecTriggerCondition">Specifies when revenue recognition begins. .</param>
        /// <param name="revenueRecognitionRuleName">The name of the revenue recognition rule governing the revenue schedule. .</param>
        /// <param name="smoothingModel">Specifies the smoothing model for an overage smoothing charge model or an tiered with overage model, which is an advanced type of a usage model that avoids spikes in usage charges. If a customer&#39;s usage spikes in a single period, then an overage smoothing model eases overage charges by considering usage and multiple periods.  One of the following values shows which smoothing model will be applied to the charge when &#x60;Overage&#x60; or &#x60;Tiered with Overage&#x60; is used:  - &#x60;RollingWindow&#x60; considers a number of periods to smooth usage. The rolling window starts and increments forward based on billing frequency. When allowed usage is met, then period resets and a new window begins. - &#x60;Rollover&#x60; considers a fixed number of periods before calculating usage. The net balance at the end of a period is unused usage, which is carried over to the next period&#39;s balance. .</param>
        /// <param name="specificBillingPeriod">When the billing period is set to &#x60;Specific&#x60; Months then this positive integer reflects the number of months for billing period charges. .</param>
        /// <param name="taxCode">Specifies the tax code for taxation rules; used by Zuora Tax. .</param>
        /// <param name="taxMode">Specifies how to define taxation for the charge; used by Zuora Tax. Possible values are: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60;. .</param>
        /// <param name="taxable">Specifies whether the charge is taxable; used by Zuora Tax. Possible values are:&#x60;true&#x60;, &#x60;false&#x60;. .</param>
        /// <param name="triggerEvent">Specifies when to start billing the customer for the charge.  Values: one of the following: - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription.  - &#x60;SpecificDate&#x60; is the date specified. .</param>
        /// <param name="type">The type of charge. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. .</param>
        /// <param name="uom">Describes the Units of Measure (uom) configured in **Settings &gt; Billing** for the productRatePlanCharges.  Values: &#x60;Each&#x60;, &#x60;License&#x60;, &#x60;Seat&#x60;, or &#x60;null&#x60; .</param>
        /// <param name="upToPeriods">Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. .</param>
        /// <param name="upToPeriodsType">The period type used to define when the charge ends.  Values: - Billing_Periods - Days - Weeks - Months - Years    .</param>
        /// <param name="usageRecordRatingOption">Determines how Zuora processes usage records for per-unit usage charges.  .</param>
        /// <param name="useDiscountSpecificAccountingCode">Determines whether to define a new accounting code for the new discount charge. Values: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="useTenantDefaultForPriceChange">Shows the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Settings &gt; Billing &gt; Define Default Subscription Settings**.  Values: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="validityPeriodType">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). .</param>
        public GETProductRatePlanChargeTypeAllOf(string applyDiscountTo = default(string), string billingDay = default(string), string billingPeriod = default(string), string billingPeriodAlignment = default(string), string billingTiming = default(string), Object chargeModelConfigurations = default(Object), CreditOptionEnum? creditOption = default(CreditOptionEnum?), decimal defaultQuantity = default(decimal), string description = default(string), string discountClass = default(string), string discountLevel = default(string), decimal drawdownRate = default(decimal), string drawdownUom = default(string), string endDateCondition = default(string), bool excludeItemBillingFromRevenueAccounting = default(bool), bool excludeItemBookingFromRevenueAccounting = default(bool), FinanceInformation financeInformation = default(FinanceInformation), string formula = default(string), string id = default(string), decimal includedUnits = default(decimal), bool isPrepaid = default(bool), string listPriceBase = default(string), decimal maxQuantity = default(decimal), decimal minQuantity = default(decimal), string model = default(string), string name = default(string), long numberOfPeriods = default(long), string overageCalculationOption = default(string), string overageUnusedUnitsCreditOption = default(string), PrepaidOperationTypeEnum? prepaidOperationType = default(PrepaidOperationTypeEnum?), decimal prepaidQuantity = default(decimal), decimal prepaidTotalQuantity = default(decimal), string prepaidUom = default(string), long prepayPeriods = default(long), string priceChangeOption = default(string), decimal priceIncreasePercentage = default(decimal), List<GETProductRatePlanChargePricingType> pricing = default(List<GETProductRatePlanChargePricingType>), List<string> pricingSummary = default(List<string>), List<GETProductDiscountApplyDetailsType> productDiscountApplyDetails = default(List<GETProductDiscountApplyDetailsType>), string ratingGroup = default(string), string revRecCode = default(string), RevRecTriggerConditionEnum? revRecTriggerCondition = default(RevRecTriggerConditionEnum?), string revenueRecognitionRuleName = default(string), string smoothingModel = default(string), long specificBillingPeriod = default(long), string taxCode = default(string), string taxMode = default(string), bool taxable = default(bool), string triggerEvent = default(string), string type = default(string), string uom = default(string), long upToPeriods = default(long), string upToPeriodsType = default(string), string usageRecordRatingOption = default(string), bool useDiscountSpecificAccountingCode = default(bool), bool useTenantDefaultForPriceChange = default(bool), ValidityPeriodTypeEnum? validityPeriodType = default(ValidityPeriodTypeEnum?))
        {
            this.ApplyDiscountTo = applyDiscountTo;
            this.BillingDay = billingDay;
            this.BillingPeriod = billingPeriod;
            this.BillingPeriodAlignment = billingPeriodAlignment;
            this.BillingTiming = billingTiming;
            this.ChargeModelConfigurations = chargeModelConfigurations;
            this.CreditOption = creditOption;
            this.DefaultQuantity = defaultQuantity;
            this.Description = description;
            this.DiscountClass = discountClass;
            this.DiscountLevel = discountLevel;
            this.DrawdownRate = drawdownRate;
            this.DrawdownUom = drawdownUom;
            this.EndDateCondition = endDateCondition;
            this.ExcludeItemBillingFromRevenueAccounting = excludeItemBillingFromRevenueAccounting;
            this.ExcludeItemBookingFromRevenueAccounting = excludeItemBookingFromRevenueAccounting;
            this.FinanceInformation = financeInformation;
            this.Formula = formula;
            this.Id = id;
            this.IncludedUnits = includedUnits;
            this.IsPrepaid = isPrepaid;
            this.ListPriceBase = listPriceBase;
            this.MaxQuantity = maxQuantity;
            this.MinQuantity = minQuantity;
            this.Model = model;
            this.Name = name;
            this.NumberOfPeriods = numberOfPeriods;
            this.OverageCalculationOption = overageCalculationOption;
            this.OverageUnusedUnitsCreditOption = overageUnusedUnitsCreditOption;
            this.PrepaidOperationType = prepaidOperationType;
            this.PrepaidQuantity = prepaidQuantity;
            this.PrepaidTotalQuantity = prepaidTotalQuantity;
            this.PrepaidUom = prepaidUom;
            this.PrepayPeriods = prepayPeriods;
            this.PriceChangeOption = priceChangeOption;
            this.PriceIncreasePercentage = priceIncreasePercentage;
            this.Pricing = pricing;
            this.PricingSummary = pricingSummary;
            this.ProductDiscountApplyDetails = productDiscountApplyDetails;
            this.RatingGroup = ratingGroup;
            this.RevRecCode = revRecCode;
            this.RevRecTriggerCondition = revRecTriggerCondition;
            this.RevenueRecognitionRuleName = revenueRecognitionRuleName;
            this.SmoothingModel = smoothingModel;
            this.SpecificBillingPeriod = specificBillingPeriod;
            this.TaxCode = taxCode;
            this.TaxMode = taxMode;
            this.Taxable = taxable;
            this.TriggerEvent = triggerEvent;
            this.Type = type;
            this.Uom = uom;
            this.UpToPeriods = upToPeriods;
            this.UpToPeriodsType = upToPeriodsType;
            this.UsageRecordRatingOption = usageRecordRatingOption;
            this.UseDiscountSpecificAccountingCode = useDiscountSpecificAccountingCode;
            this.UseTenantDefaultForPriceChange = useTenantDefaultForPriceChange;
            this.ValidityPeriodType = validityPeriodType;
        }

        /// <summary>
        /// Specifies where (to what charge type) the discount will be applied. These field values are case-sensitive.  Permissible values: - RECURRING - USAGE - ONETIMERECURRING - ONETIMEUSAGE - RECURRINGUSAGE - ONETIMERECURRINGUSAGE 
        /// </summary>
        /// <value>Specifies where (to what charge type) the discount will be applied. These field values are case-sensitive.  Permissible values: - RECURRING - USAGE - ONETIMERECURRING - ONETIMEUSAGE - RECURRINGUSAGE - ONETIMERECURRINGUSAGE </value>
        [DataMember(Name = "applyDiscountTo", EmitDefaultValue = false)]
        public string ApplyDiscountTo { get; set; }

        /// <summary>
        /// The bill cycle day (BCD) for the charge. The BCD determines which day of the month or week the customer is billed. The BCD value in the account can override the BCD in this object. 
        /// </summary>
        /// <value>The bill cycle day (BCD) for the charge. The BCD determines which day of the month or week the customer is billed. The BCD value in the account can override the BCD in this object. </value>
        [DataMember(Name = "billingDay", EmitDefaultValue = false)]
        public string BillingDay { get; set; }

        /// <summary>
        /// The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values: - Month - Quarter - Annual - Semi-Annual - Specific Months - Week - Specific_Weeks 
        /// </summary>
        /// <value>The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values: - Month - Quarter - Annual - Semi-Annual - Specific Months - Week - Specific_Weeks </value>
        [DataMember(Name = "billingPeriod", EmitDefaultValue = false)]
        public string BillingPeriod { get; set; }

        /// <summary>
        /// Aligns charges within the same subscription if multiple charges begin on different dates.  Possible values: - AlignToCharge - AlignToSubscriptionStart - AlignToTermStart 
        /// </summary>
        /// <value>Aligns charges within the same subscription if multiple charges begin on different dates.  Possible values: - AlignToCharge - AlignToSubscriptionStart - AlignToTermStart </value>
        [DataMember(Name = "billingPeriodAlignment", EmitDefaultValue = false)]
        public string BillingPeriodAlignment { get; set; }

        /// <summary>
        /// The billing timing for the charge. You can choose to bill for charges in advance or in arrears.  Values: - In Advance - In Arrears  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  
        /// </summary>
        /// <value>The billing timing for the charge. You can choose to bill for charges in advance or in arrears.  Values: - In Advance - In Arrears  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  </value>
        [DataMember(Name = "billingTiming", EmitDefaultValue = false)]
        public string BillingTiming { get; set; }

        /// <summary>
        /// This field is for Zuora Internal Use only. See the **pricing** field for the same information as this field.
        /// </summary>
        /// <value>This field is for Zuora Internal Use only. See the **pricing** field for the same information as this field.</value>
        [DataMember(Name = "chargeModelConfigurations", EmitDefaultValue = false)]
        public Object ChargeModelConfigurations { get; set; }

        /// <summary>
        /// The default quantity of units.  This field is required if you use a per-unit charge model. 
        /// </summary>
        /// <value>The default quantity of units.  This field is required if you use a per-unit charge model. </value>
        [DataMember(Name = "defaultQuantity", EmitDefaultValue = false)]
        public decimal DefaultQuantity { get; set; }

        /// <summary>
        /// Usually a brief line item summary of the Rate Plan Charge. 
        /// </summary>
        /// <value>Usually a brief line item summary of the Rate Plan Charge. </value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The class that the discount belongs to. The discount class defines the order in which discount product rate plan charges are applied.  For more information, see [Manage Discount Classes](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models/Manage_Discount_Classes). 
        /// </summary>
        /// <value>The class that the discount belongs to. The discount class defines the order in which discount product rate plan charges are applied.  For more information, see [Manage Discount Classes](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models/Manage_Discount_Classes). </value>
        [DataMember(Name = "discountClass", EmitDefaultValue = false)]
        public string DiscountClass { get; set; }

        /// <summary>
        /// The level of the discount.   Values: - RatePlan - Subscription - Account 
        /// </summary>
        /// <value>The level of the discount.   Values: - RatePlan - Subscription - Account </value>
        [DataMember(Name = "discountLevel", EmitDefaultValue = false)]
        public string DiscountLevel { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The [conversion rate](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge#UOM_Conversion) between Usage UOM and Drawdown UOM for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). Must be a positive number (&gt;0). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The [conversion rate](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge#UOM_Conversion) between Usage UOM and Drawdown UOM for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). Must be a positive number (&gt;0). </value>
        [DataMember(Name = "drawdownRate", EmitDefaultValue = false)]
        public decimal DrawdownRate { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). </value>
        [DataMember(Name = "drawdownUom", EmitDefaultValue = false)]
        public string DrawdownUom { get; set; }

        /// <summary>
        /// Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values: - Subscription_End - Fixed_Period 
        /// </summary>
        /// <value>Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values: - Subscription_End - Fixed_Period </value>
        [DataMember(Name = "endDateCondition", EmitDefaultValue = false)]
        public string EndDateCondition { get; set; }

        /// <summary>
        /// The flag to exclude the related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude the related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "excludeItemBillingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBillingFromRevenueAccounting { get; set; }

        /// <summary>
        /// The flag to exclude the related rate plan charges and order line items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude the related rate plan charges and order line items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "excludeItemBookingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBookingFromRevenueAccounting { get; set; }

        /// <summary>
        /// Gets or Sets FinanceInformation
        /// </summary>
        [DataMember(Name = "financeInformation", EmitDefaultValue = false)]
        public FinanceInformation FinanceInformation { get; set; }

        /// <summary>
        /// The pricing formula to calculate the actual rating amount for each usage record.  This field is only available for the usage-based charges that use the Multi-Attribute Pricing charge model. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information. 
        /// </summary>
        /// <value>The pricing formula to calculate the actual rating amount for each usage record.  This field is only available for the usage-based charges that use the Multi-Attribute Pricing charge model. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information. </value>
        [DataMember(Name = "formula", EmitDefaultValue = false)]
        public string Formula { get; set; }

        /// <summary>
        /// Unique product rate-plan charge ID. 
        /// </summary>
        /// <value>Unique product rate-plan charge ID. </value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Specifies the number of units in the base set of units when the charge model is Overage. 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units when the charge model is Overage. </value>
        [DataMember(Name = "includedUnits", EmitDefaultValue = false)]
        public decimal IncludedUnits { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Indicates whether this charge is a prepayment (topup) charge or a drawdown charge. Values: &#x60;true&#x60; or &#x60;false&#x60;. 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Indicates whether this charge is a prepayment (topup) charge or a drawdown charge. Values: &#x60;true&#x60; or &#x60;false&#x60;. </value>
        [DataMember(Name = "isPrepaid", EmitDefaultValue = true)]
        public bool IsPrepaid { get; set; }

        /// <summary>
        /// The list price base for the product rate plan charge.  Values: - Month - Billing Period - Per_Week 
        /// </summary>
        /// <value>The list price base for the product rate plan charge.  Values: - Month - Billing Period - Per_Week </value>
        [DataMember(Name = "listPriceBase", EmitDefaultValue = false)]
        public string ListPriceBase { get; set; }

        /// <summary>
        /// Specifies the maximum number of units for this charge. Use this field and the &#x60;minQuantity&#x60; field to create a range of units allowed in a product rate plan charge. 
        /// </summary>
        /// <value>Specifies the maximum number of units for this charge. Use this field and the &#x60;minQuantity&#x60; field to create a range of units allowed in a product rate plan charge. </value>
        [DataMember(Name = "maxQuantity", EmitDefaultValue = false)]
        public decimal MaxQuantity { get; set; }

        /// <summary>
        /// Specifies the minimum number of units for this charge. Use this field and the &#x60;maxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. 
        /// </summary>
        /// <value>Specifies the minimum number of units for this charge. Use this field and the &#x60;maxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. </value>
        [DataMember(Name = "minQuantity", EmitDefaultValue = false)]
        public decimal MinQuantity { get; set; }

        /// <summary>
        /// Charge model which determines how charges are calculated. Charge models must be individually activated in Zuora Billing administration.   Possible values are: - &#x60;FlatFee&#x60; - &#x60;PerUnit&#x60; - &#x60;Overage&#x60; - &#x60;Volume&#x60; - &#x60;Tiered&#x60; - &#x60;TieredWithOverage&#x60; - &#x60;DiscountFixedAmount&#x60; - &#x60;DiscountPercentage&#x60; - &#x60;MultiAttributePricing&#x60; (available only if you have the Multi-Attribute Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;PreratedPerUnit&#x60; (available only if you have the Pre-rated Per Unit Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;PreratedPricing&#x60; (available only if you have the Pre-rated Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;HighWatermarkVolumePricing&#x60; (available only if you have the High Water Mark Volume Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;HighWatermarkTieredPricing&#x60; (available only if you have the High Water Mark Tiered Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.)  The value of the &#x60;pricing&#x60; field contains details about these charge models and the value of &#x60;pricingSummary&#x60; field contains their associated pricing summary values. 
        /// </summary>
        /// <value>Charge model which determines how charges are calculated. Charge models must be individually activated in Zuora Billing administration.   Possible values are: - &#x60;FlatFee&#x60; - &#x60;PerUnit&#x60; - &#x60;Overage&#x60; - &#x60;Volume&#x60; - &#x60;Tiered&#x60; - &#x60;TieredWithOverage&#x60; - &#x60;DiscountFixedAmount&#x60; - &#x60;DiscountPercentage&#x60; - &#x60;MultiAttributePricing&#x60; (available only if you have the Multi-Attribute Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;PreratedPerUnit&#x60; (available only if you have the Pre-rated Per Unit Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;PreratedPricing&#x60; (available only if you have the Pre-rated Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;HighWatermarkVolumePricing&#x60; (available only if you have the High Water Mark Volume Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.) - &#x60;HighWatermarkTieredPricing&#x60; (available only if you have the High Water Mark Tiered Pricing charge model enabled. The charge model is available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information.)  The value of the &#x60;pricing&#x60; field contains details about these charge models and the value of &#x60;pricingSummary&#x60; field contains their associated pricing summary values. </value>
        [DataMember(Name = "model", EmitDefaultValue = false)]
        public string Model { get; set; }

        /// <summary>
        /// Name of the product rate-plan charge. (Not required to be unique.) 
        /// </summary>
        /// <value>Name of the product rate-plan charge. (Not required to be unique.) </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Value specifies the number of periods used in the smoothing model calculations Used when overage smoothing model is &#x60;RollingWindow&#x60; or &#x60;Rollover&#x60;. 
        /// </summary>
        /// <value>Value specifies the number of periods used in the smoothing model calculations Used when overage smoothing model is &#x60;RollingWindow&#x60; or &#x60;Rollover&#x60;. </value>
        [DataMember(Name = "numberOfPeriods", EmitDefaultValue = false)]
        public long NumberOfPeriods { get; set; }

        /// <summary>
        /// Value specifies when to calculate overage charges.  Values: - EndOfSmoothingPeriod - PerBillingPeriod 
        /// </summary>
        /// <value>Value specifies when to calculate overage charges.  Values: - EndOfSmoothingPeriod - PerBillingPeriod </value>
        [DataMember(Name = "overageCalculationOption", EmitDefaultValue = false)]
        public string OverageCalculationOption { get; set; }

        /// <summary>
        /// Determines whether to credit the customer with unused units of usage.  Values: - NoCredit - CreditBySpecificRate 
        /// </summary>
        /// <value>Determines whether to credit the customer with unused units of usage.  Values: - NoCredit - CreditBySpecificRate </value>
        [DataMember(Name = "overageUnusedUnitsCreditOption", EmitDefaultValue = false)]
        public string OverageUnusedUnitsCreditOption { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The number of units included in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). Must be a positive number (&gt;0). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The number of units included in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). Must be a positive number (&gt;0). </value>
        [DataMember(Name = "prepaidQuantity", EmitDefaultValue = false)]
        public decimal PrepaidQuantity { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The total amount of units that end customers can use during a validity period when they subscribe to a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The total amount of units that end customers can use during a validity period when they subscribe to a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [DataMember(Name = "prepaidTotalQuantity", EmitDefaultValue = false)]
        public decimal PrepaidTotalQuantity { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [DataMember(Name = "prepaidUom", EmitDefaultValue = false)]
        public string PrepaidUom { get; set; }

        /// <summary>
        /// The number of periods to which prepayment is set.   **Note:** This field is only available if you already have the prepayment feature enabled. The prepayment feature is deprecated and available only for backward compatibility. Zuora does not support enabling this feature anymore. 
        /// </summary>
        /// <value>The number of periods to which prepayment is set.   **Note:** This field is only available if you already have the prepayment feature enabled. The prepayment feature is deprecated and available only for backward compatibility. Zuora does not support enabling this feature anymore. </value>
        [DataMember(Name = "prepayPeriods", EmitDefaultValue = false)]
        public long PrepayPeriods { get; set; }

        /// <summary>
        /// Applies an automatic price change when a termed subscription is renewed and the following applies:  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: - NoChange (default) - SpecificPercentageValue - UseLatestProductCatalogPricing 
        /// </summary>
        /// <value>Applies an automatic price change when a termed subscription is renewed and the following applies:  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: - NoChange (default) - SpecificPercentageValue - UseLatestProductCatalogPricing </value>
        [DataMember(Name = "priceChangeOption", EmitDefaultValue = false)]
        public string PriceChangeOption { get; set; }

        /// <summary>
        /// Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the &#x60;PriceChangeOption&#x60; value to &#x60;SpecificPercentageValue&#x60;.  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: a decimal between -100 and 100 
        /// </summary>
        /// <value>Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the &#x60;PriceChangeOption&#x60; value to &#x60;SpecificPercentageValue&#x60;.  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: a decimal between -100 and 100 </value>
        [DataMember(Name = "priceIncreasePercentage", EmitDefaultValue = false)]
        public decimal PriceIncreasePercentage { get; set; }

        /// <summary>
        /// One or more price charge models with attributes that further describe the model.  Some attributes show as null values when not applicable. 
        /// </summary>
        /// <value>One or more price charge models with attributes that further describe the model.  Some attributes show as null values when not applicable. </value>
        [DataMember(Name = "pricing", EmitDefaultValue = false)]
        public List<GETProductRatePlanChargePricingType> Pricing { get; set; }

        /// <summary>
        /// A concise description of the charge model and pricing that is suitable to show to your customers. When the rate plan charge model is &#x60;Tiered&#x60; and multi-currency is enabled, this field includes an array of string of each currency, and each string of currency includes tier price description separated by comma.  For the following charge models, the value of this field is an empty string: - Multi-Attribute Pricing - High Water Mark Tiered Pricing - High Water Mark Volume Pricing - Pre-Rated Per Unit Pricing - Pre-Rated Pricing  The charge models are available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information. 
        /// </summary>
        /// <value>A concise description of the charge model and pricing that is suitable to show to your customers. When the rate plan charge model is &#x60;Tiered&#x60; and multi-currency is enabled, this field includes an array of string of each currency, and each string of currency includes tier price description separated by comma.  For the following charge models, the value of this field is an empty string: - Multi-Attribute Pricing - High Water Mark Tiered Pricing - High Water Mark Volume Pricing - Pre-Rated Per Unit Pricing - Pre-Rated Pricing  The charge models are available for customers with Enterprise and Nine editions by default. If you are a Growth customer, see [Zuora Editions](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/C_Zuora_Editions) for pricing information. </value>
        [DataMember(Name = "pricingSummary", EmitDefaultValue = false)]
        public List<string> PricingSummary { get; set; }

        /// <summary>
        /// Container for the application details about a discount product rate plan charge.   Only discount product rate plan charges have values in this field. 
        /// </summary>
        /// <value>Container for the application details about a discount product rate plan charge.   Only discount product rate plan charges have values in this field. </value>
        [DataMember(Name = "productDiscountApplyDetails", EmitDefaultValue = false)]
        public List<GETProductDiscountApplyDetailsType> ProductDiscountApplyDetails { get; set; }

        /// <summary>
        /// Specifies a rating group based on which usage records are rated.  Possible values:  - &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  **Note:**  - The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models.  - The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models.  - The &#x60;ByGroupId&#x60; value is only available if you have the Active Rating feature enabled. - Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. 
        /// </summary>
        /// <value>Specifies a rating group based on which usage records are rated.  Possible values:  - &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  **Note:**  - The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models.  - The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models.  - The &#x60;ByGroupId&#x60; value is only available if you have the Active Rating feature enabled. - Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. </value>
        [DataMember(Name = "ratingGroup", EmitDefaultValue = false)]
        public string RatingGroup { get; set; }

        /// <summary>
        /// Associates this product rate plan charge with a specific revenue recognition code. The value is a valid revenue recognition code. 
        /// </summary>
        /// <value>Associates this product rate plan charge with a specific revenue recognition code. The value is a valid revenue recognition code. </value>
        [DataMember(Name = "revRecCode", EmitDefaultValue = false)]
        public string RevRecCode { get; set; }

        /// <summary>
        /// The name of the revenue recognition rule governing the revenue schedule. 
        /// </summary>
        /// <value>The name of the revenue recognition rule governing the revenue schedule. </value>
        [DataMember(Name = "revenueRecognitionRuleName", EmitDefaultValue = false)]
        public string RevenueRecognitionRuleName { get; set; }

        /// <summary>
        /// Specifies the smoothing model for an overage smoothing charge model or an tiered with overage model, which is an advanced type of a usage model that avoids spikes in usage charges. If a customer&#39;s usage spikes in a single period, then an overage smoothing model eases overage charges by considering usage and multiple periods.  One of the following values shows which smoothing model will be applied to the charge when &#x60;Overage&#x60; or &#x60;Tiered with Overage&#x60; is used:  - &#x60;RollingWindow&#x60; considers a number of periods to smooth usage. The rolling window starts and increments forward based on billing frequency. When allowed usage is met, then period resets and a new window begins. - &#x60;Rollover&#x60; considers a fixed number of periods before calculating usage. The net balance at the end of a period is unused usage, which is carried over to the next period&#39;s balance. 
        /// </summary>
        /// <value>Specifies the smoothing model for an overage smoothing charge model or an tiered with overage model, which is an advanced type of a usage model that avoids spikes in usage charges. If a customer&#39;s usage spikes in a single period, then an overage smoothing model eases overage charges by considering usage and multiple periods.  One of the following values shows which smoothing model will be applied to the charge when &#x60;Overage&#x60; or &#x60;Tiered with Overage&#x60; is used:  - &#x60;RollingWindow&#x60; considers a number of periods to smooth usage. The rolling window starts and increments forward based on billing frequency. When allowed usage is met, then period resets and a new window begins. - &#x60;Rollover&#x60; considers a fixed number of periods before calculating usage. The net balance at the end of a period is unused usage, which is carried over to the next period&#39;s balance. </value>
        [DataMember(Name = "smoothingModel", EmitDefaultValue = false)]
        public string SmoothingModel { get; set; }

        /// <summary>
        /// When the billing period is set to &#x60;Specific&#x60; Months then this positive integer reflects the number of months for billing period charges. 
        /// </summary>
        /// <value>When the billing period is set to &#x60;Specific&#x60; Months then this positive integer reflects the number of months for billing period charges. </value>
        [DataMember(Name = "specificBillingPeriod", EmitDefaultValue = false)]
        public long SpecificBillingPeriod { get; set; }

        /// <summary>
        /// Specifies the tax code for taxation rules; used by Zuora Tax. 
        /// </summary>
        /// <value>Specifies the tax code for taxation rules; used by Zuora Tax. </value>
        [DataMember(Name = "taxCode", EmitDefaultValue = false)]
        public string TaxCode { get; set; }

        /// <summary>
        /// Specifies how to define taxation for the charge; used by Zuora Tax. Possible values are: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60;. 
        /// </summary>
        /// <value>Specifies how to define taxation for the charge; used by Zuora Tax. Possible values are: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60;. </value>
        [DataMember(Name = "taxMode", EmitDefaultValue = false)]
        public string TaxMode { get; set; }

        /// <summary>
        /// Specifies whether the charge is taxable; used by Zuora Tax. Possible values are:&#x60;true&#x60;, &#x60;false&#x60;. 
        /// </summary>
        /// <value>Specifies whether the charge is taxable; used by Zuora Tax. Possible values are:&#x60;true&#x60;, &#x60;false&#x60;. </value>
        [DataMember(Name = "taxable", EmitDefaultValue = true)]
        public bool Taxable { get; set; }

        /// <summary>
        /// Specifies when to start billing the customer for the charge.  Values: one of the following: - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription.  - &#x60;SpecificDate&#x60; is the date specified. 
        /// </summary>
        /// <value>Specifies when to start billing the customer for the charge.  Values: one of the following: - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription.  - &#x60;SpecificDate&#x60; is the date specified. </value>
        [DataMember(Name = "triggerEvent", EmitDefaultValue = false)]
        public string TriggerEvent { get; set; }

        /// <summary>
        /// The type of charge. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. 
        /// </summary>
        /// <value>The type of charge. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Describes the Units of Measure (uom) configured in **Settings &gt; Billing** for the productRatePlanCharges.  Values: &#x60;Each&#x60;, &#x60;License&#x60;, &#x60;Seat&#x60;, or &#x60;null&#x60; 
        /// </summary>
        /// <value>Describes the Units of Measure (uom) configured in **Settings &gt; Billing** for the productRatePlanCharges.  Values: &#x60;Each&#x60;, &#x60;License&#x60;, &#x60;Seat&#x60;, or &#x60;null&#x60; </value>
        [DataMember(Name = "uom", EmitDefaultValue = false)]
        public string Uom { get; set; }

        /// <summary>
        /// Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. 
        /// </summary>
        /// <value>Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. </value>
        [DataMember(Name = "upToPeriods", EmitDefaultValue = false)]
        public long UpToPeriods { get; set; }

        /// <summary>
        /// The period type used to define when the charge ends.  Values: - Billing_Periods - Days - Weeks - Months - Years    
        /// </summary>
        /// <value>The period type used to define when the charge ends.  Values: - Billing_Periods - Days - Weeks - Months - Years    </value>
        [DataMember(Name = "upToPeriodsType", EmitDefaultValue = false)]
        public string UpToPeriodsType { get; set; }

        /// <summary>
        /// Determines how Zuora processes usage records for per-unit usage charges.  
        /// </summary>
        /// <value>Determines how Zuora processes usage records for per-unit usage charges.  </value>
        [DataMember(Name = "usageRecordRatingOption", EmitDefaultValue = false)]
        public string UsageRecordRatingOption { get; set; }

        /// <summary>
        /// Determines whether to define a new accounting code for the new discount charge. Values: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value>Determines whether to define a new accounting code for the new discount charge. Values: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name = "useDiscountSpecificAccountingCode", EmitDefaultValue = true)]
        public bool UseDiscountSpecificAccountingCode { get; set; }

        /// <summary>
        /// Shows the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Settings &gt; Billing &gt; Define Default Subscription Settings**.  Values: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value>Shows the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Settings &gt; Billing &gt; Define Default Subscription Settings**.  Values: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name = "useTenantDefaultForPriceChange", EmitDefaultValue = true)]
        public bool UseTenantDefaultForPriceChange { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GETProductRatePlanChargeTypeAllOf {\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillingDay: ").Append(BillingDay).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  ChargeModelConfigurations: ").Append(ChargeModelConfigurations).Append("\n");
            sb.Append("  CreditOption: ").Append(CreditOption).Append("\n");
            sb.Append("  DefaultQuantity: ").Append(DefaultQuantity).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountClass: ").Append(DiscountClass).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  DrawdownRate: ").Append(DrawdownRate).Append("\n");
            sb.Append("  DrawdownUom: ").Append(DrawdownUom).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  ExcludeItemBillingFromRevenueAccounting: ").Append(ExcludeItemBillingFromRevenueAccounting).Append("\n");
            sb.Append("  ExcludeItemBookingFromRevenueAccounting: ").Append(ExcludeItemBookingFromRevenueAccounting).Append("\n");
            sb.Append("  FinanceInformation: ").Append(FinanceInformation).Append("\n");
            sb.Append("  Formula: ").Append(Formula).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  IsPrepaid: ").Append(IsPrepaid).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  MaxQuantity: ").Append(MaxQuantity).Append("\n");
            sb.Append("  MinQuantity: ").Append(MinQuantity).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NumberOfPeriods: ").Append(NumberOfPeriods).Append("\n");
            sb.Append("  OverageCalculationOption: ").Append(OverageCalculationOption).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  PrepaidOperationType: ").Append(PrepaidOperationType).Append("\n");
            sb.Append("  PrepaidQuantity: ").Append(PrepaidQuantity).Append("\n");
            sb.Append("  PrepaidTotalQuantity: ").Append(PrepaidTotalQuantity).Append("\n");
            sb.Append("  PrepaidUom: ").Append(PrepaidUom).Append("\n");
            sb.Append("  PrepayPeriods: ").Append(PrepayPeriods).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  Pricing: ").Append(Pricing).Append("\n");
            sb.Append("  PricingSummary: ").Append(PricingSummary).Append("\n");
            sb.Append("  ProductDiscountApplyDetails: ").Append(ProductDiscountApplyDetails).Append("\n");
            sb.Append("  RatingGroup: ").Append(RatingGroup).Append("\n");
            sb.Append("  RevRecCode: ").Append(RevRecCode).Append("\n");
            sb.Append("  RevRecTriggerCondition: ").Append(RevRecTriggerCondition).Append("\n");
            sb.Append("  RevenueRecognitionRuleName: ").Append(RevenueRecognitionRuleName).Append("\n");
            sb.Append("  SmoothingModel: ").Append(SmoothingModel).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxMode: ").Append(TaxMode).Append("\n");
            sb.Append("  Taxable: ").Append(Taxable).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Uom: ").Append(Uom).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
            sb.Append("  UsageRecordRatingOption: ").Append(UsageRecordRatingOption).Append("\n");
            sb.Append("  UseDiscountSpecificAccountingCode: ").Append(UseDiscountSpecificAccountingCode).Append("\n");
            sb.Append("  UseTenantDefaultForPriceChange: ").Append(UseTenantDefaultForPriceChange).Append("\n");
            sb.Append("  ValidityPeriodType: ").Append(ValidityPeriodType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as GETProductRatePlanChargeTypeAllOf);
        }

        /// <summary>
        /// Returns true if GETProductRatePlanChargeTypeAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of GETProductRatePlanChargeTypeAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETProductRatePlanChargeTypeAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ApplyDiscountTo == input.ApplyDiscountTo ||
                    (this.ApplyDiscountTo != null &&
                    this.ApplyDiscountTo.Equals(input.ApplyDiscountTo))
                ) && 
                (
                    this.BillingDay == input.BillingDay ||
                    (this.BillingDay != null &&
                    this.BillingDay.Equals(input.BillingDay))
                ) && 
                (
                    this.BillingPeriod == input.BillingPeriod ||
                    (this.BillingPeriod != null &&
                    this.BillingPeriod.Equals(input.BillingPeriod))
                ) && 
                (
                    this.BillingPeriodAlignment == input.BillingPeriodAlignment ||
                    (this.BillingPeriodAlignment != null &&
                    this.BillingPeriodAlignment.Equals(input.BillingPeriodAlignment))
                ) && 
                (
                    this.BillingTiming == input.BillingTiming ||
                    (this.BillingTiming != null &&
                    this.BillingTiming.Equals(input.BillingTiming))
                ) && 
                (
                    this.ChargeModelConfigurations == input.ChargeModelConfigurations ||
                    (this.ChargeModelConfigurations != null &&
                    this.ChargeModelConfigurations.Equals(input.ChargeModelConfigurations))
                ) && 
                (
                    this.CreditOption == input.CreditOption ||
                    this.CreditOption.Equals(input.CreditOption)
                ) && 
                (
                    this.DefaultQuantity == input.DefaultQuantity ||
                    this.DefaultQuantity.Equals(input.DefaultQuantity)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DiscountClass == input.DiscountClass ||
                    (this.DiscountClass != null &&
                    this.DiscountClass.Equals(input.DiscountClass))
                ) && 
                (
                    this.DiscountLevel == input.DiscountLevel ||
                    (this.DiscountLevel != null &&
                    this.DiscountLevel.Equals(input.DiscountLevel))
                ) && 
                (
                    this.DrawdownRate == input.DrawdownRate ||
                    this.DrawdownRate.Equals(input.DrawdownRate)
                ) && 
                (
                    this.DrawdownUom == input.DrawdownUom ||
                    (this.DrawdownUom != null &&
                    this.DrawdownUom.Equals(input.DrawdownUom))
                ) && 
                (
                    this.EndDateCondition == input.EndDateCondition ||
                    (this.EndDateCondition != null &&
                    this.EndDateCondition.Equals(input.EndDateCondition))
                ) && 
                (
                    this.ExcludeItemBillingFromRevenueAccounting == input.ExcludeItemBillingFromRevenueAccounting ||
                    this.ExcludeItemBillingFromRevenueAccounting.Equals(input.ExcludeItemBillingFromRevenueAccounting)
                ) && 
                (
                    this.ExcludeItemBookingFromRevenueAccounting == input.ExcludeItemBookingFromRevenueAccounting ||
                    this.ExcludeItemBookingFromRevenueAccounting.Equals(input.ExcludeItemBookingFromRevenueAccounting)
                ) && 
                (
                    this.FinanceInformation == input.FinanceInformation ||
                    (this.FinanceInformation != null &&
                    this.FinanceInformation.Equals(input.FinanceInformation))
                ) && 
                (
                    this.Formula == input.Formula ||
                    (this.Formula != null &&
                    this.Formula.Equals(input.Formula))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.IncludedUnits == input.IncludedUnits ||
                    this.IncludedUnits.Equals(input.IncludedUnits)
                ) && 
                (
                    this.IsPrepaid == input.IsPrepaid ||
                    this.IsPrepaid.Equals(input.IsPrepaid)
                ) && 
                (
                    this.ListPriceBase == input.ListPriceBase ||
                    (this.ListPriceBase != null &&
                    this.ListPriceBase.Equals(input.ListPriceBase))
                ) && 
                (
                    this.MaxQuantity == input.MaxQuantity ||
                    this.MaxQuantity.Equals(input.MaxQuantity)
                ) && 
                (
                    this.MinQuantity == input.MinQuantity ||
                    this.MinQuantity.Equals(input.MinQuantity)
                ) && 
                (
                    this.Model == input.Model ||
                    (this.Model != null &&
                    this.Model.Equals(input.Model))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.NumberOfPeriods == input.NumberOfPeriods ||
                    this.NumberOfPeriods.Equals(input.NumberOfPeriods)
                ) && 
                (
                    this.OverageCalculationOption == input.OverageCalculationOption ||
                    (this.OverageCalculationOption != null &&
                    this.OverageCalculationOption.Equals(input.OverageCalculationOption))
                ) && 
                (
                    this.OverageUnusedUnitsCreditOption == input.OverageUnusedUnitsCreditOption ||
                    (this.OverageUnusedUnitsCreditOption != null &&
                    this.OverageUnusedUnitsCreditOption.Equals(input.OverageUnusedUnitsCreditOption))
                ) && 
                (
                    this.PrepaidOperationType == input.PrepaidOperationType ||
                    this.PrepaidOperationType.Equals(input.PrepaidOperationType)
                ) && 
                (
                    this.PrepaidQuantity == input.PrepaidQuantity ||
                    this.PrepaidQuantity.Equals(input.PrepaidQuantity)
                ) && 
                (
                    this.PrepaidTotalQuantity == input.PrepaidTotalQuantity ||
                    this.PrepaidTotalQuantity.Equals(input.PrepaidTotalQuantity)
                ) && 
                (
                    this.PrepaidUom == input.PrepaidUom ||
                    (this.PrepaidUom != null &&
                    this.PrepaidUom.Equals(input.PrepaidUom))
                ) && 
                (
                    this.PrepayPeriods == input.PrepayPeriods ||
                    this.PrepayPeriods.Equals(input.PrepayPeriods)
                ) && 
                (
                    this.PriceChangeOption == input.PriceChangeOption ||
                    (this.PriceChangeOption != null &&
                    this.PriceChangeOption.Equals(input.PriceChangeOption))
                ) && 
                (
                    this.PriceIncreasePercentage == input.PriceIncreasePercentage ||
                    this.PriceIncreasePercentage.Equals(input.PriceIncreasePercentage)
                ) && 
                (
                    this.Pricing == input.Pricing ||
                    this.Pricing != null &&
                    input.Pricing != null &&
                    this.Pricing.SequenceEqual(input.Pricing)
                ) && 
                (
                    this.PricingSummary == input.PricingSummary ||
                    this.PricingSummary != null &&
                    input.PricingSummary != null &&
                    this.PricingSummary.SequenceEqual(input.PricingSummary)
                ) && 
                (
                    this.ProductDiscountApplyDetails == input.ProductDiscountApplyDetails ||
                    this.ProductDiscountApplyDetails != null &&
                    input.ProductDiscountApplyDetails != null &&
                    this.ProductDiscountApplyDetails.SequenceEqual(input.ProductDiscountApplyDetails)
                ) && 
                (
                    this.RatingGroup == input.RatingGroup ||
                    (this.RatingGroup != null &&
                    this.RatingGroup.Equals(input.RatingGroup))
                ) && 
                (
                    this.RevRecCode == input.RevRecCode ||
                    (this.RevRecCode != null &&
                    this.RevRecCode.Equals(input.RevRecCode))
                ) && 
                (
                    this.RevRecTriggerCondition == input.RevRecTriggerCondition ||
                    this.RevRecTriggerCondition.Equals(input.RevRecTriggerCondition)
                ) && 
                (
                    this.RevenueRecognitionRuleName == input.RevenueRecognitionRuleName ||
                    (this.RevenueRecognitionRuleName != null &&
                    this.RevenueRecognitionRuleName.Equals(input.RevenueRecognitionRuleName))
                ) && 
                (
                    this.SmoothingModel == input.SmoothingModel ||
                    (this.SmoothingModel != null &&
                    this.SmoothingModel.Equals(input.SmoothingModel))
                ) && 
                (
                    this.SpecificBillingPeriod == input.SpecificBillingPeriod ||
                    this.SpecificBillingPeriod.Equals(input.SpecificBillingPeriod)
                ) && 
                (
                    this.TaxCode == input.TaxCode ||
                    (this.TaxCode != null &&
                    this.TaxCode.Equals(input.TaxCode))
                ) && 
                (
                    this.TaxMode == input.TaxMode ||
                    (this.TaxMode != null &&
                    this.TaxMode.Equals(input.TaxMode))
                ) && 
                (
                    this.Taxable == input.Taxable ||
                    this.Taxable.Equals(input.Taxable)
                ) && 
                (
                    this.TriggerEvent == input.TriggerEvent ||
                    (this.TriggerEvent != null &&
                    this.TriggerEvent.Equals(input.TriggerEvent))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Uom == input.Uom ||
                    (this.Uom != null &&
                    this.Uom.Equals(input.Uom))
                ) && 
                (
                    this.UpToPeriods == input.UpToPeriods ||
                    this.UpToPeriods.Equals(input.UpToPeriods)
                ) && 
                (
                    this.UpToPeriodsType == input.UpToPeriodsType ||
                    (this.UpToPeriodsType != null &&
                    this.UpToPeriodsType.Equals(input.UpToPeriodsType))
                ) && 
                (
                    this.UsageRecordRatingOption == input.UsageRecordRatingOption ||
                    (this.UsageRecordRatingOption != null &&
                    this.UsageRecordRatingOption.Equals(input.UsageRecordRatingOption))
                ) && 
                (
                    this.UseDiscountSpecificAccountingCode == input.UseDiscountSpecificAccountingCode ||
                    this.UseDiscountSpecificAccountingCode.Equals(input.UseDiscountSpecificAccountingCode)
                ) && 
                (
                    this.UseTenantDefaultForPriceChange == input.UseTenantDefaultForPriceChange ||
                    this.UseTenantDefaultForPriceChange.Equals(input.UseTenantDefaultForPriceChange)
                ) && 
                (
                    this.ValidityPeriodType == input.ValidityPeriodType ||
                    this.ValidityPeriodType.Equals(input.ValidityPeriodType)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ApplyDiscountTo != null)
                {
                    hashCode = (hashCode * 59) + this.ApplyDiscountTo.GetHashCode();
                }
                if (this.BillingDay != null)
                {
                    hashCode = (hashCode * 59) + this.BillingDay.GetHashCode();
                }
                if (this.BillingPeriod != null)
                {
                    hashCode = (hashCode * 59) + this.BillingPeriod.GetHashCode();
                }
                if (this.BillingPeriodAlignment != null)
                {
                    hashCode = (hashCode * 59) + this.BillingPeriodAlignment.GetHashCode();
                }
                if (this.BillingTiming != null)
                {
                    hashCode = (hashCode * 59) + this.BillingTiming.GetHashCode();
                }
                if (this.ChargeModelConfigurations != null)
                {
                    hashCode = (hashCode * 59) + this.ChargeModelConfigurations.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CreditOption.GetHashCode();
                hashCode = (hashCode * 59) + this.DefaultQuantity.GetHashCode();
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.DiscountClass != null)
                {
                    hashCode = (hashCode * 59) + this.DiscountClass.GetHashCode();
                }
                if (this.DiscountLevel != null)
                {
                    hashCode = (hashCode * 59) + this.DiscountLevel.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.DrawdownRate.GetHashCode();
                if (this.DrawdownUom != null)
                {
                    hashCode = (hashCode * 59) + this.DrawdownUom.GetHashCode();
                }
                if (this.EndDateCondition != null)
                {
                    hashCode = (hashCode * 59) + this.EndDateCondition.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ExcludeItemBillingFromRevenueAccounting.GetHashCode();
                hashCode = (hashCode * 59) + this.ExcludeItemBookingFromRevenueAccounting.GetHashCode();
                if (this.FinanceInformation != null)
                {
                    hashCode = (hashCode * 59) + this.FinanceInformation.GetHashCode();
                }
                if (this.Formula != null)
                {
                    hashCode = (hashCode * 59) + this.Formula.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IncludedUnits.GetHashCode();
                hashCode = (hashCode * 59) + this.IsPrepaid.GetHashCode();
                if (this.ListPriceBase != null)
                {
                    hashCode = (hashCode * 59) + this.ListPriceBase.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MaxQuantity.GetHashCode();
                hashCode = (hashCode * 59) + this.MinQuantity.GetHashCode();
                if (this.Model != null)
                {
                    hashCode = (hashCode * 59) + this.Model.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.NumberOfPeriods.GetHashCode();
                if (this.OverageCalculationOption != null)
                {
                    hashCode = (hashCode * 59) + this.OverageCalculationOption.GetHashCode();
                }
                if (this.OverageUnusedUnitsCreditOption != null)
                {
                    hashCode = (hashCode * 59) + this.OverageUnusedUnitsCreditOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PrepaidOperationType.GetHashCode();
                hashCode = (hashCode * 59) + this.PrepaidQuantity.GetHashCode();
                hashCode = (hashCode * 59) + this.PrepaidTotalQuantity.GetHashCode();
                if (this.PrepaidUom != null)
                {
                    hashCode = (hashCode * 59) + this.PrepaidUom.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PrepayPeriods.GetHashCode();
                if (this.PriceChangeOption != null)
                {
                    hashCode = (hashCode * 59) + this.PriceChangeOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PriceIncreasePercentage.GetHashCode();
                if (this.Pricing != null)
                {
                    hashCode = (hashCode * 59) + this.Pricing.GetHashCode();
                }
                if (this.PricingSummary != null)
                {
                    hashCode = (hashCode * 59) + this.PricingSummary.GetHashCode();
                }
                if (this.ProductDiscountApplyDetails != null)
                {
                    hashCode = (hashCode * 59) + this.ProductDiscountApplyDetails.GetHashCode();
                }
                if (this.RatingGroup != null)
                {
                    hashCode = (hashCode * 59) + this.RatingGroup.GetHashCode();
                }
                if (this.RevRecCode != null)
                {
                    hashCode = (hashCode * 59) + this.RevRecCode.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RevRecTriggerCondition.GetHashCode();
                if (this.RevenueRecognitionRuleName != null)
                {
                    hashCode = (hashCode * 59) + this.RevenueRecognitionRuleName.GetHashCode();
                }
                if (this.SmoothingModel != null)
                {
                    hashCode = (hashCode * 59) + this.SmoothingModel.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SpecificBillingPeriod.GetHashCode();
                if (this.TaxCode != null)
                {
                    hashCode = (hashCode * 59) + this.TaxCode.GetHashCode();
                }
                if (this.TaxMode != null)
                {
                    hashCode = (hashCode * 59) + this.TaxMode.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Taxable.GetHashCode();
                if (this.TriggerEvent != null)
                {
                    hashCode = (hashCode * 59) + this.TriggerEvent.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.Uom != null)
                {
                    hashCode = (hashCode * 59) + this.Uom.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UpToPeriods.GetHashCode();
                if (this.UpToPeriodsType != null)
                {
                    hashCode = (hashCode * 59) + this.UpToPeriodsType.GetHashCode();
                }
                if (this.UsageRecordRatingOption != null)
                {
                    hashCode = (hashCode * 59) + this.UsageRecordRatingOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UseDiscountSpecificAccountingCode.GetHashCode();
                hashCode = (hashCode * 59) + this.UseTenantDefaultForPriceChange.GetHashCode();
                hashCode = (hashCode * 59) + this.ValidityPeriodType.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            // RevRecCode (string) maxLength
            if (this.RevRecCode != null && this.RevRecCode.Length > 70)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RevRecCode, length must be less than 70.", new [] { "RevRecCode" });
            }

            yield break;
        }
    }

}
