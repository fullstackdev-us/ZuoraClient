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
    /// POSTPaymentMethodRequest
    /// </summary>
    [DataContract(Name = "POSTPaymentMethodRequest")]
    public partial class POSTPaymentMethodRequest : IEquatable<POSTPaymentMethodRequest>, IValidatableObject
    {
        /// <summary>
        /// Required if you set the &#x60;mitProfileAction&#x60; field. 
        /// </summary>
        /// <value>Required if you set the &#x60;mitProfileAction&#x60; field. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MitConsentAgreementSrcEnum
        {
            /// <summary>
            /// Enum External for value: External
            /// </summary>
            [EnumMember(Value = "External")]
            External = 1

        }


        /// <summary>
        /// Required if you set the &#x60;mitProfileAction&#x60; field. 
        /// </summary>
        /// <value>Required if you set the &#x60;mitProfileAction&#x60; field. </value>
        [DataMember(Name = "mitConsentAgreementSrc", EmitDefaultValue = false)]
        public MitConsentAgreementSrcEnum? MitConsentAgreementSrc { get; set; }
        /// <summary>
        /// If you set this field, Zuora creates a stored credential profile within the payment method.  * &#x60;Activate&#x60; - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;. 
        /// </summary>
        /// <value>If you set this field, Zuora creates a stored credential profile within the payment method.  * &#x60;Activate&#x60; - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MitProfileActionEnum
        {
            /// <summary>
            /// Enum Activate for value: Activate
            /// </summary>
            [EnumMember(Value = "Activate")]
            Activate = 1,

            /// <summary>
            /// Enum Persist for value: Persist
            /// </summary>
            [EnumMember(Value = "Persist")]
            Persist = 2

        }


        /// <summary>
        /// If you set this field, Zuora creates a stored credential profile within the payment method.  * &#x60;Activate&#x60; - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;. 
        /// </summary>
        /// <value>If you set this field, Zuora creates a stored credential profile within the payment method.  * &#x60;Activate&#x60; - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;. </value>
        [DataMember(Name = "mitProfileAction", EmitDefaultValue = false)]
        public MitProfileActionEnum? MitProfileAction { get; set; }
        /// <summary>
        /// Required if you set the &#x60;mitProfileAction&#x60; field. Indicates the type of the stored credential profile to process recurring or unsecheduled transactions. 
        /// </summary>
        /// <value>Required if you set the &#x60;mitProfileAction&#x60; field. Indicates the type of the stored credential profile to process recurring or unsecheduled transactions. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MitProfileTypeEnum
        {
            /// <summary>
            /// Enum Recurring for value: Recurring
            /// </summary>
            [EnumMember(Value = "Recurring")]
            Recurring = 1,

            /// <summary>
            /// Enum Unscheduled for value: Unscheduled
            /// </summary>
            [EnumMember(Value = "Unscheduled")]
            Unscheduled = 2

        }


        /// <summary>
        /// Required if you set the &#x60;mitProfileAction&#x60; field. Indicates the type of the stored credential profile to process recurring or unsecheduled transactions. 
        /// </summary>
        /// <value>Required if you set the &#x60;mitProfileAction&#x60; field. Indicates the type of the stored credential profile to process recurring or unsecheduled transactions. </value>
        [DataMember(Name = "mitProfileType", EmitDefaultValue = false)]
        public MitProfileTypeEnum? MitProfileType { get; set; }
        /// <summary>
        /// The type of bank account associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably. 
        /// </summary>
        /// <value>The type of bank account associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum BankAccountTypeEnum
        {
            /// <summary>
            /// Enum BusinessChecking for value: BusinessChecking
            /// </summary>
            [EnumMember(Value = "BusinessChecking")]
            BusinessChecking = 1,

            /// <summary>
            /// Enum BusinessSaving for value: BusinessSaving
            /// </summary>
            [EnumMember(Value = "BusinessSaving")]
            BusinessSaving = 2,

            /// <summary>
            /// Enum Checking for value: Checking
            /// </summary>
            [EnumMember(Value = "Checking")]
            Checking = 3,

            /// <summary>
            /// Enum Saving for value: Saving
            /// </summary>
            [EnumMember(Value = "Saving")]
            Saving = 4

        }


        /// <summary>
        /// The type of bank account associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably. 
        /// </summary>
        /// <value>The type of bank account associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably. </value>
        [DataMember(Name = "bankAccountType", EmitDefaultValue = false)]
        public BankAccountTypeEnum? BankAccountType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSTPaymentMethodRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected POSTPaymentMethodRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSTPaymentMethodRequest" /> class.
        /// </summary>
        /// <param name="type">Type of the payment method. Possible values include:  * &#x60;CreditCard&#x60; - Credit card payment method. * &#x60;CreditCardReferenceTransaction&#x60; - Credit Card Reference Transaction. See [Supported payment methods](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Supported_Payment_Methods) for payment gateways that support this type of payment method. * &#x60;ACH&#x60; - ACH payment method. * &#x60;SEPA&#x60; - Single Euro Payments Area. * &#x60;Betalingsservice&#x60; - Direct Debit DK. * &#x60;Autogiro&#x60; - Direct Debit SE. * &#x60;Bacs&#x60; - Direct Debit UK. * &#x60;Becs&#x60; - Direct Entry AU. * &#x60;Becsnz&#x60; - Direct Debit NZ. * &#x60;PAD&#x60; - Pre-Authorized Debit. * &#x60;PayPalCP&#x60; - PayPal Commerce Platform payment method. Use this type if you are using a [PayPal Commerce Platform Gateway](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Commerce_Platform_Gateway) instance. * &#x60;PayPalEC&#x60; - PayPal Express Checkout payment method. Use this type if you are using a [PayPal Payflow Pro Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Payflow_Pro%2C_Website_Payments_Payflow_Edition%2C_Website_Pro_Payment_Gateway) instance. * &#x60;PayPalNativeEC&#x60; - PayPal Native Express Checkout payment method. Use this type if you are using a [PayPal Express Checkout Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Express_Checkout_Gateway) instance. * &#x60;PayPalAdaptive&#x60; - PayPal Adaptive payment method. Use this type if you are using a [PayPal Adaptive Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Adaptive_Payments_Gateway) instance. * &#x60;AdyenApplePay&#x60; - Apple Pay on Adyen Integration v2.0. See [Set up Adyen Apple Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Apple_Pay_on_Web/Set_up_Adyen_Apple_Pay) for details. * &#x60;AdyenGooglePay&#x60; - Google Pay on Adyen Integration v2.0. See [Set up Adyen Google Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Adyen_Google_Pay) for details. * &#x60;GooglePay&#x60; - Google Pay on Chase Paymentech Orbital gateway integration. See [Set up Google Pay on Chase](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Google_Pay_on_Chase) for details. * You can also specify a custom payment method type. See [Set up custom payment gateways and payment methods](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/MB_Set_up_custom_payment_gateways_and_payment_methods) for details.  Note that Zuora is continuously adding new payment method types.  (required).</param>
        /// <param name="bAID">ID of a PayPal billing agreement. For example, I-1TJ3GAGG82Y9. .</param>
        /// <param name="email">Email address associated with the payment method. This field is required if you want to create any of the following PayPal payment methods:   - PayPal Express Checkout payment method    - PayPal Adaptive payment method   - PayPal Commerce Platform payment method .</param>
        /// <param name="preapprovalKey">The PayPal preapproval key. .</param>
        /// <param name="cardHolderInfo">cardHolderInfo.</param>
        /// <param name="cardNumber">Credit card number. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. .</param>
        /// <param name="cardType">The type of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;.  Possible values include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways). .</param>
        /// <param name="checkDuplicated">Indicates whether the duplication check is performed when you create a new credit card payment method. The default value is &#x60;false&#x60;.  With this field set to &#x60;true&#x60;, Zuora will check all active payment methods associated with the same billing account to ensure that no duplicate credit card payment methods are created. An error is returned if a duplicate payment method is found.          The following fields are used for the duplication check:   * &#x60;cardHolderName&#x60;   * &#x60;expirationMonth&#x60;   * &#x60;expirationYear&#x60;   * &#x60;creditCardMaskNumber&#x60;. It is the masked credit card number generated by Zuora. For example:     &#x60;&#x60;&#x60;     ************1234     &#x60;&#x60;&#x60; .</param>
        /// <param name="expirationMonth">One or two digit expiration month (1-12) of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. .</param>
        /// <param name="expirationYear">Four-digit expiration year of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. .</param>
        /// <param name="mitConsentAgreementRef">Specifies your reference for the stored credential consent agreement that you have established with the customer. Only applicable if you set the &#x60;mitProfileAction&#x60; field. .</param>
        /// <param name="mitConsentAgreementSrc">Required if you set the &#x60;mitProfileAction&#x60; field. .</param>
        /// <param name="mitNetworkTransactionId">Specifies the ID of a network transaction. Only applicable if you set the &#x60;mitProfileAction&#x60; field to &#x60;Persist&#x60;. .</param>
        /// <param name="mitProfileAction">If you set this field, Zuora creates a stored credential profile within the payment method.  * &#x60;Activate&#x60; - Use this value if you are creating the stored credential profile after receiving the customer&#39;s consent.    Zuora will create the stored credential profile then send a cardholder-initiated transaction (CIT) to the payment gateway to validate the stored credential profile. If the CIT succeeds, the status of the stored credential profile will be &#x60;Active&#x60;. If the CIT does not succeed, Zuora will not create a stored credential profile.      If the payment gateway does not support the stored credential transaction framework, the status of the stored credential profile will be &#x60;Agreed&#x60;.   * &#x60;Persist&#x60; - Use this value if the stored credential profile represents a stored credential profile in an external system. The status of the payment method&#39;s stored credential profile will be &#x60;Active&#x60;. .</param>
        /// <param name="mitProfileAgreedOn">The date on which the profile is agreed. The date format is &#x60;yyyy-mm-dd&#x60;. .</param>
        /// <param name="mitProfileType">Required if you set the &#x60;mitProfileAction&#x60; field. Indicates the type of the stored credential profile to process recurring or unsecheduled transactions. .</param>
        /// <param name="securityCode">CVV or CVV2 security code of the credit card.  To ensure PCI compliance, this value is not stored and cannot be queried. .</param>
        /// <param name="addressLine1">First address line, 255 characters or less. .</param>
        /// <param name="addressLine2">Second address line, 255 characters or less. .</param>
        /// <param name="bankABACode">The nine-digit routing number or ABA number used by banks. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. .</param>
        /// <param name="bankAccountName">The name of the account holder, which can be either a person or a company. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. .</param>
        /// <param name="bankAccountNumber">The bank account number associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. .</param>
        /// <param name="bankAccountType">The type of bank account associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably. .</param>
        /// <param name="bankName">The name of the bank where the ACH payment account is held. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify a dummy value. .</param>
        /// <param name="city">City, 40 characters or less.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.      .</param>
        /// <param name="country">Country, must be a valid country name or abbreviation.  See [Country Names and Their ISO Standard 2- and 3-Digit Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) for the list of supported country names and abbreviations.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing. .</param>
        /// <param name="phone">Phone number, 40 characters or less. .</param>
        /// <param name="state">State, must be a valid state name or 2-character abbreviation.  See [United States Standard State Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) and [Canadian Standard Province Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/C_Canadian_Province_Names_and_2-Digit_Codes) for the list of supported names and abbreviations. .</param>
        /// <param name="zipCode">Zip code, 20 characters or less. .</param>
        /// <param name="accountKey">Internal ID of the customer account that will own the payment method.   To create an orphan payment method that is not associated with any customer account, you do not need to specify this field during creation. However, you must associate the orphan payment method with a customer account within 10 days. Otherwise, this orphan payment method will be deleted. .</param>
        /// <param name="authGateway">Internal ID of the payment gateway that Zuora will use to authorize the payments that are made with the payment method.  If you do not set this field, Zuora will use one of the following payment gateways instead:  * The default payment gateway of the customer account that owns the payment method, if the &#x60;accountKey&#x60; field is set. * The default payment gateway of your Zuora tenant, if the &#x60;accountKey&#x60; field is not set. .</param>
        /// <param name="gatewayOptions">gatewayOptions.</param>
        /// <param name="makeDefault">Specifies whether the payment method will be the default payment method of the customer account that owns the payment method. Only applicable if the &#x60;accountKey&#x60; field is set.  When you set this field to &#x60;true&#x60;, make sure the payment method is supported by the default payment gateway.  (default to false).</param>
        /// <param name="mandateInfo">mandateInfo.</param>
        /// <param name="skipValidation">Specify whether to skip the validation of the information through the payment gateway. For example, when migrating your payment methods, you can set this field to &#x60;true&#x60; to skip the validation.   (default to false).</param>
        /// <param name="iBAN">The International Bank Account Number. This field is required if the &#x60;type&#x60; field is set to &#x60;SEPA&#x60;. .</param>
        /// <param name="accountHolderInfo">accountHolderInfo.</param>
        /// <param name="accountNumber">The number of the customer&#39;s bank account. This field is required for the following bank transfer payment methods:   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) .</param>
        /// <param name="bankCode">The sort code or number that identifies the bank. This is also known as the sort code. This field is required for the following bank transfer payment methods:   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) .</param>
        /// <param name="branchCode">The branch code of the bank used for direct debit. This field is required for the following bank transfer payment methods:   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) .</param>
        /// <param name="businessIdentificationCode">The BIC code used for SEPA. .</param>
        /// <param name="currencyCode">The currency used for payment method authorization.  If this field is not specified, &#x60;currency&#x60; specified for the account is used for payment method authorization. If no currency is specified for the account, the default currency of the account is then used. .</param>
        /// <param name="identityNumber">The identity number used for Bank Transfer. This field is required for the following bank transfer payment methods:   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;) .</param>
        /// <param name="creditCardMaskNumber">The masked credit card number, such as: &#x60;&#x60;&#x60; *********1112 &#x60;&#x60;&#x60;  This field is specific for the CC Reference Transaction payment method. It is an optional field that you can use to distinguish different CC Reference Transaction payment methods.  Though there are no special restrictions on the input string, it is highly recommended to specify a card number that is masked. .</param>
        /// <param name="secondTokenId">A gateway unique identifier that replaces sensitive payment method data.   &#x60;secondTokenId&#x60; is conditionally required only when &#x60;tokenId&#x60; is being used to represent a gateway customer profile. &#x60;secondTokenId&#x60; is used in the CC Reference Transaction payment method. .</param>
        /// <param name="tokenId">A gateway unique identifier that replaces sensitive payment method data or represents a gateway&#39;s unique customer profile. &#x60;tokenId&#x60; is required for the CC Reference Transaction payment method.  When &#x60;tokenId&#x60; is used to represent a customer profile, &#x60;secondTokenId&#x60; is conditionally required for representing the underlying tokenized payment method.  When creating an ACH payment method, if you need to pass in tokenized information, use the &#x60;mandateId&#x60; instead of &#x60;tokenId&#x60; field. .</param>
        /// <param name="applePaymentData">This field is specific for setting up Apple Pay for Adyen to include payload with Apple Pay token or Apple payment data. This information should be stringified. For more information, see [Set up Adyen Apple Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Apple_Pay_on_Web/Set_up_Adyen_Apple_Pay). .</param>
        /// <param name="googlePaymentToken">This field is specific for setting up Google Pay for Adyen and Chase gateway integrations to specify the stringified Google Pay token. For more information, see [Set up Adyen Google Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Adyen_Google_Pay) and [Set up Google Pay on Chase](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Google_Pay_on_Chase). .</param>
        public POSTPaymentMethodRequest(string type = default(string), string bAID = default(string), string email = default(string), string preapprovalKey = default(string), CreatePaymentMethodCardholderInfo cardHolderInfo = default(CreatePaymentMethodCardholderInfo), string cardNumber = default(string), string cardType = default(string), bool checkDuplicated = default(bool), int expirationMonth = default(int), int expirationYear = default(int), string mitConsentAgreementRef = default(string), MitConsentAgreementSrcEnum? mitConsentAgreementSrc = default(MitConsentAgreementSrcEnum?), string mitNetworkTransactionId = default(string), MitProfileActionEnum? mitProfileAction = default(MitProfileActionEnum?), DateTime mitProfileAgreedOn = default(DateTime), MitProfileTypeEnum? mitProfileType = default(MitProfileTypeEnum?), string securityCode = default(string), string addressLine1 = default(string), string addressLine2 = default(string), string bankABACode = default(string), string bankAccountName = default(string), string bankAccountNumber = default(string), BankAccountTypeEnum? bankAccountType = default(BankAccountTypeEnum?), string bankName = default(string), string city = default(string), string country = default(string), string phone = default(string), string state = default(string), string zipCode = default(string), string accountKey = default(string), string authGateway = default(string), CreatePaymentMethodCommonGatewayOptions gatewayOptions = default(CreatePaymentMethodCommonGatewayOptions), bool makeDefault = false, CreatePaymentMethodCommonMandateInfo mandateInfo = default(CreatePaymentMethodCommonMandateInfo), bool skipValidation = false, string iBAN = default(string), CreatePaymentMethodBankTransferAccountHolderInfo accountHolderInfo = default(CreatePaymentMethodBankTransferAccountHolderInfo), string accountNumber = default(string), string bankCode = default(string), string branchCode = default(string), string businessIdentificationCode = default(string), string currencyCode = default(string), string identityNumber = default(string), string creditCardMaskNumber = default(string), string secondTokenId = default(string), string tokenId = default(string), string applePaymentData = default(string), string googlePaymentToken = default(string))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for POSTPaymentMethodRequest and cannot be null");
            }
            this.Type = type;
            this.BAID = bAID;
            this.Email = email;
            this.PreapprovalKey = preapprovalKey;
            this.CardHolderInfo = cardHolderInfo;
            this.CardNumber = cardNumber;
            this.CardType = cardType;
            this.CheckDuplicated = checkDuplicated;
            this.ExpirationMonth = expirationMonth;
            this.ExpirationYear = expirationYear;
            this.MitConsentAgreementRef = mitConsentAgreementRef;
            this.MitConsentAgreementSrc = mitConsentAgreementSrc;
            this.MitNetworkTransactionId = mitNetworkTransactionId;
            this.MitProfileAction = mitProfileAction;
            this.MitProfileAgreedOn = mitProfileAgreedOn;
            this.MitProfileType = mitProfileType;
            this.SecurityCode = securityCode;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.BankABACode = bankABACode;
            this.BankAccountName = bankAccountName;
            this.BankAccountNumber = bankAccountNumber;
            this.BankAccountType = bankAccountType;
            this.BankName = bankName;
            this.City = city;
            this.Country = country;
            this.Phone = phone;
            this.State = state;
            this.ZipCode = zipCode;
            this.AccountKey = accountKey;
            this.AuthGateway = authGateway;
            this.GatewayOptions = gatewayOptions;
            this.MakeDefault = makeDefault;
            this.MandateInfo = mandateInfo;
            this.SkipValidation = skipValidation;
            this.IBAN = iBAN;
            this.AccountHolderInfo = accountHolderInfo;
            this.AccountNumber = accountNumber;
            this.BankCode = bankCode;
            this.BranchCode = branchCode;
            this.BusinessIdentificationCode = businessIdentificationCode;
            this.CurrencyCode = currencyCode;
            this.IdentityNumber = identityNumber;
            this.CreditCardMaskNumber = creditCardMaskNumber;
            this.SecondTokenId = secondTokenId;
            this.TokenId = tokenId;
            this.ApplePaymentData = applePaymentData;
            this.GooglePaymentToken = googlePaymentToken;
        }

        /// <summary>
        /// Type of the payment method. Possible values include:  * &#x60;CreditCard&#x60; - Credit card payment method. * &#x60;CreditCardReferenceTransaction&#x60; - Credit Card Reference Transaction. See [Supported payment methods](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Supported_Payment_Methods) for payment gateways that support this type of payment method. * &#x60;ACH&#x60; - ACH payment method. * &#x60;SEPA&#x60; - Single Euro Payments Area. * &#x60;Betalingsservice&#x60; - Direct Debit DK. * &#x60;Autogiro&#x60; - Direct Debit SE. * &#x60;Bacs&#x60; - Direct Debit UK. * &#x60;Becs&#x60; - Direct Entry AU. * &#x60;Becsnz&#x60; - Direct Debit NZ. * &#x60;PAD&#x60; - Pre-Authorized Debit. * &#x60;PayPalCP&#x60; - PayPal Commerce Platform payment method. Use this type if you are using a [PayPal Commerce Platform Gateway](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Commerce_Platform_Gateway) instance. * &#x60;PayPalEC&#x60; - PayPal Express Checkout payment method. Use this type if you are using a [PayPal Payflow Pro Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Payflow_Pro%2C_Website_Payments_Payflow_Edition%2C_Website_Pro_Payment_Gateway) instance. * &#x60;PayPalNativeEC&#x60; - PayPal Native Express Checkout payment method. Use this type if you are using a [PayPal Express Checkout Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Express_Checkout_Gateway) instance. * &#x60;PayPalAdaptive&#x60; - PayPal Adaptive payment method. Use this type if you are using a [PayPal Adaptive Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Adaptive_Payments_Gateway) instance. * &#x60;AdyenApplePay&#x60; - Apple Pay on Adyen Integration v2.0. See [Set up Adyen Apple Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Apple_Pay_on_Web/Set_up_Adyen_Apple_Pay) for details. * &#x60;AdyenGooglePay&#x60; - Google Pay on Adyen Integration v2.0. See [Set up Adyen Google Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Adyen_Google_Pay) for details. * &#x60;GooglePay&#x60; - Google Pay on Chase Paymentech Orbital gateway integration. See [Set up Google Pay on Chase](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Google_Pay_on_Chase) for details. * You can also specify a custom payment method type. See [Set up custom payment gateways and payment methods](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/MB_Set_up_custom_payment_gateways_and_payment_methods) for details.  Note that Zuora is continuously adding new payment method types. 
        /// </summary>
        /// <value>Type of the payment method. Possible values include:  * &#x60;CreditCard&#x60; - Credit card payment method. * &#x60;CreditCardReferenceTransaction&#x60; - Credit Card Reference Transaction. See [Supported payment methods](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Supported_Payment_Methods) for payment gateways that support this type of payment method. * &#x60;ACH&#x60; - ACH payment method. * &#x60;SEPA&#x60; - Single Euro Payments Area. * &#x60;Betalingsservice&#x60; - Direct Debit DK. * &#x60;Autogiro&#x60; - Direct Debit SE. * &#x60;Bacs&#x60; - Direct Debit UK. * &#x60;Becs&#x60; - Direct Entry AU. * &#x60;Becsnz&#x60; - Direct Debit NZ. * &#x60;PAD&#x60; - Pre-Authorized Debit. * &#x60;PayPalCP&#x60; - PayPal Commerce Platform payment method. Use this type if you are using a [PayPal Commerce Platform Gateway](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Commerce_Platform_Gateway) instance. * &#x60;PayPalEC&#x60; - PayPal Express Checkout payment method. Use this type if you are using a [PayPal Payflow Pro Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Payflow_Pro%2C_Website_Payments_Payflow_Edition%2C_Website_Pro_Payment_Gateway) instance. * &#x60;PayPalNativeEC&#x60; - PayPal Native Express Checkout payment method. Use this type if you are using a [PayPal Express Checkout Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Express_Checkout_Gateway) instance. * &#x60;PayPalAdaptive&#x60; - PayPal Adaptive payment method. Use this type if you are using a [PayPal Adaptive Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/PayPal_Adaptive_Payments_Gateway) instance. * &#x60;AdyenApplePay&#x60; - Apple Pay on Adyen Integration v2.0. See [Set up Adyen Apple Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Apple_Pay_on_Web/Set_up_Adyen_Apple_Pay) for details. * &#x60;AdyenGooglePay&#x60; - Google Pay on Adyen Integration v2.0. See [Set up Adyen Google Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Adyen_Google_Pay) for details. * &#x60;GooglePay&#x60; - Google Pay on Chase Paymentech Orbital gateway integration. See [Set up Google Pay on Chase](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Google_Pay_on_Chase) for details. * You can also specify a custom payment method type. See [Set up custom payment gateways and payment methods](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/MB_Set_up_custom_payment_gateways_and_payment_methods) for details.  Note that Zuora is continuously adding new payment method types. </value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// ID of a PayPal billing agreement. For example, I-1TJ3GAGG82Y9. 
        /// </summary>
        /// <value>ID of a PayPal billing agreement. For example, I-1TJ3GAGG82Y9. </value>
        [DataMember(Name = "BAID", EmitDefaultValue = false)]
        public string BAID { get; set; }

        /// <summary>
        /// Email address associated with the payment method. This field is required if you want to create any of the following PayPal payment methods:   - PayPal Express Checkout payment method    - PayPal Adaptive payment method   - PayPal Commerce Platform payment method 
        /// </summary>
        /// <value>Email address associated with the payment method. This field is required if you want to create any of the following PayPal payment methods:   - PayPal Express Checkout payment method    - PayPal Adaptive payment method   - PayPal Commerce Platform payment method </value>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// The PayPal preapproval key. 
        /// </summary>
        /// <value>The PayPal preapproval key. </value>
        [DataMember(Name = "preapprovalKey", EmitDefaultValue = false)]
        public string PreapprovalKey { get; set; }

        /// <summary>
        /// Gets or Sets CardHolderInfo
        /// </summary>
        [DataMember(Name = "cardHolderInfo", EmitDefaultValue = false)]
        public CreatePaymentMethodCardholderInfo CardHolderInfo { get; set; }

        /// <summary>
        /// Credit card number. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. 
        /// </summary>
        /// <value>Credit card number. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. </value>
        [DataMember(Name = "cardNumber", EmitDefaultValue = false)]
        public string CardNumber { get; set; }

        /// <summary>
        /// The type of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;.  Possible values include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways). 
        /// </summary>
        /// <value>The type of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;.  Possible values include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways). </value>
        [DataMember(Name = "cardType", EmitDefaultValue = false)]
        public string CardType { get; set; }

        /// <summary>
        /// Indicates whether the duplication check is performed when you create a new credit card payment method. The default value is &#x60;false&#x60;.  With this field set to &#x60;true&#x60;, Zuora will check all active payment methods associated with the same billing account to ensure that no duplicate credit card payment methods are created. An error is returned if a duplicate payment method is found.          The following fields are used for the duplication check:   * &#x60;cardHolderName&#x60;   * &#x60;expirationMonth&#x60;   * &#x60;expirationYear&#x60;   * &#x60;creditCardMaskNumber&#x60;. It is the masked credit card number generated by Zuora. For example:     &#x60;&#x60;&#x60;     ************1234     &#x60;&#x60;&#x60; 
        /// </summary>
        /// <value>Indicates whether the duplication check is performed when you create a new credit card payment method. The default value is &#x60;false&#x60;.  With this field set to &#x60;true&#x60;, Zuora will check all active payment methods associated with the same billing account to ensure that no duplicate credit card payment methods are created. An error is returned if a duplicate payment method is found.          The following fields are used for the duplication check:   * &#x60;cardHolderName&#x60;   * &#x60;expirationMonth&#x60;   * &#x60;expirationYear&#x60;   * &#x60;creditCardMaskNumber&#x60;. It is the masked credit card number generated by Zuora. For example:     &#x60;&#x60;&#x60;     ************1234     &#x60;&#x60;&#x60; </value>
        [DataMember(Name = "checkDuplicated", EmitDefaultValue = true)]
        public bool CheckDuplicated { get; set; }

        /// <summary>
        /// One or two digit expiration month (1-12) of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. 
        /// </summary>
        /// <value>One or two digit expiration month (1-12) of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. </value>
        [DataMember(Name = "expirationMonth", EmitDefaultValue = false)]
        public int ExpirationMonth { get; set; }

        /// <summary>
        /// Four-digit expiration year of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. 
        /// </summary>
        /// <value>Four-digit expiration year of the credit card. This field is required if &#x60;type&#x60; is set to &#x60;CreditCard&#x60;. </value>
        [DataMember(Name = "expirationYear", EmitDefaultValue = false)]
        public int ExpirationYear { get; set; }

        /// <summary>
        /// Specifies your reference for the stored credential consent agreement that you have established with the customer. Only applicable if you set the &#x60;mitProfileAction&#x60; field. 
        /// </summary>
        /// <value>Specifies your reference for the stored credential consent agreement that you have established with the customer. Only applicable if you set the &#x60;mitProfileAction&#x60; field. </value>
        [DataMember(Name = "mitConsentAgreementRef", EmitDefaultValue = false)]
        public string MitConsentAgreementRef { get; set; }

        /// <summary>
        /// Specifies the ID of a network transaction. Only applicable if you set the &#x60;mitProfileAction&#x60; field to &#x60;Persist&#x60;. 
        /// </summary>
        /// <value>Specifies the ID of a network transaction. Only applicable if you set the &#x60;mitProfileAction&#x60; field to &#x60;Persist&#x60;. </value>
        [DataMember(Name = "mitNetworkTransactionId", EmitDefaultValue = false)]
        public string MitNetworkTransactionId { get; set; }

        /// <summary>
        /// The date on which the profile is agreed. The date format is &#x60;yyyy-mm-dd&#x60;. 
        /// </summary>
        /// <value>The date on which the profile is agreed. The date format is &#x60;yyyy-mm-dd&#x60;. </value>
        [DataMember(Name = "mitProfileAgreedOn", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime MitProfileAgreedOn { get; set; }

        /// <summary>
        /// CVV or CVV2 security code of the credit card.  To ensure PCI compliance, this value is not stored and cannot be queried. 
        /// </summary>
        /// <value>CVV or CVV2 security code of the credit card.  To ensure PCI compliance, this value is not stored and cannot be queried. </value>
        [DataMember(Name = "securityCode", EmitDefaultValue = false)]
        public string SecurityCode { get; set; }

        /// <summary>
        /// First address line, 255 characters or less. 
        /// </summary>
        /// <value>First address line, 255 characters or less. </value>
        [DataMember(Name = "addressLine1", EmitDefaultValue = false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Second address line, 255 characters or less. 
        /// </summary>
        /// <value>Second address line, 255 characters or less. </value>
        [DataMember(Name = "addressLine2", EmitDefaultValue = false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The nine-digit routing number or ABA number used by banks. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. 
        /// </summary>
        /// <value>The nine-digit routing number or ABA number used by banks. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. </value>
        [DataMember(Name = "bankABACode", EmitDefaultValue = false)]
        public string BankABACode { get; set; }

        /// <summary>
        /// The name of the account holder, which can be either a person or a company. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. 
        /// </summary>
        /// <value>The name of the account holder, which can be either a person or a company. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. </value>
        [DataMember(Name = "bankAccountName", EmitDefaultValue = false)]
        public string BankAccountName { get; set; }

        /// <summary>
        /// The bank account number associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. 
        /// </summary>
        /// <value>The bank account number associated with the ACH payment. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;. </value>
        [DataMember(Name = "bankAccountNumber", EmitDefaultValue = false)]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The name of the bank where the ACH payment account is held. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify a dummy value. 
        /// </summary>
        /// <value>The name of the bank where the ACH payment account is held. This field is only required if the &#x60;type&#x60; field is set to &#x60;ACH&#x60;.  When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify a dummy value. </value>
        [DataMember(Name = "bankName", EmitDefaultValue = false)]
        public string BankName { get; set; }

        /// <summary>
        /// City, 40 characters or less.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.      
        /// </summary>
        /// <value>City, 40 characters or less.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing.      </value>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// Country, must be a valid country name or abbreviation.  See [Country Names and Their ISO Standard 2- and 3-Digit Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) for the list of supported country names and abbreviations.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing. 
        /// </summary>
        /// <value>Country, must be a valid country name or abbreviation.  See [Country Names and Their ISO Standard 2- and 3-Digit Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) for the list of supported country names and abbreviations.  It is recommended to provide the city and country information when creating a payment method. The information will be used to process payments. If the information is not provided during payment method creation, the city and country data will be missing during payment processing. </value>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        /// Phone number, 40 characters or less. 
        /// </summary>
        /// <value>Phone number, 40 characters or less. </value>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string Phone { get; set; }

        /// <summary>
        /// State, must be a valid state name or 2-character abbreviation.  See [United States Standard State Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) and [Canadian Standard Province Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/C_Canadian_Province_Names_and_2-Digit_Codes) for the list of supported names and abbreviations. 
        /// </summary>
        /// <value>State, must be a valid state name or 2-character abbreviation.  See [United States Standard State Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) and [Canadian Standard Province Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/C_Canadian_Province_Names_and_2-Digit_Codes) for the list of supported names and abbreviations. </value>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// Zip code, 20 characters or less. 
        /// </summary>
        /// <value>Zip code, 20 characters or less. </value>
        [DataMember(Name = "zipCode", EmitDefaultValue = false)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Internal ID of the customer account that will own the payment method.   To create an orphan payment method that is not associated with any customer account, you do not need to specify this field during creation. However, you must associate the orphan payment method with a customer account within 10 days. Otherwise, this orphan payment method will be deleted. 
        /// </summary>
        /// <value>Internal ID of the customer account that will own the payment method.   To create an orphan payment method that is not associated with any customer account, you do not need to specify this field during creation. However, you must associate the orphan payment method with a customer account within 10 days. Otherwise, this orphan payment method will be deleted. </value>
        [DataMember(Name = "accountKey", EmitDefaultValue = false)]
        public string AccountKey { get; set; }

        /// <summary>
        /// Internal ID of the payment gateway that Zuora will use to authorize the payments that are made with the payment method.  If you do not set this field, Zuora will use one of the following payment gateways instead:  * The default payment gateway of the customer account that owns the payment method, if the &#x60;accountKey&#x60; field is set. * The default payment gateway of your Zuora tenant, if the &#x60;accountKey&#x60; field is not set. 
        /// </summary>
        /// <value>Internal ID of the payment gateway that Zuora will use to authorize the payments that are made with the payment method.  If you do not set this field, Zuora will use one of the following payment gateways instead:  * The default payment gateway of the customer account that owns the payment method, if the &#x60;accountKey&#x60; field is set. * The default payment gateway of your Zuora tenant, if the &#x60;accountKey&#x60; field is not set. </value>
        [DataMember(Name = "authGateway", EmitDefaultValue = false)]
        public string AuthGateway { get; set; }

        /// <summary>
        /// Gets or Sets GatewayOptions
        /// </summary>
        [DataMember(Name = "gatewayOptions", EmitDefaultValue = false)]
        public CreatePaymentMethodCommonGatewayOptions GatewayOptions { get; set; }

        /// <summary>
        /// Specifies whether the payment method will be the default payment method of the customer account that owns the payment method. Only applicable if the &#x60;accountKey&#x60; field is set.  When you set this field to &#x60;true&#x60;, make sure the payment method is supported by the default payment gateway. 
        /// </summary>
        /// <value>Specifies whether the payment method will be the default payment method of the customer account that owns the payment method. Only applicable if the &#x60;accountKey&#x60; field is set.  When you set this field to &#x60;true&#x60;, make sure the payment method is supported by the default payment gateway. </value>
        [DataMember(Name = "makeDefault", EmitDefaultValue = true)]
        public bool MakeDefault { get; set; }

        /// <summary>
        /// Gets or Sets MandateInfo
        /// </summary>
        [DataMember(Name = "mandateInfo", EmitDefaultValue = false)]
        public CreatePaymentMethodCommonMandateInfo MandateInfo { get; set; }

        /// <summary>
        /// Specify whether to skip the validation of the information through the payment gateway. For example, when migrating your payment methods, you can set this field to &#x60;true&#x60; to skip the validation.  
        /// </summary>
        /// <value>Specify whether to skip the validation of the information through the payment gateway. For example, when migrating your payment methods, you can set this field to &#x60;true&#x60; to skip the validation.  </value>
        [DataMember(Name = "skipValidation", EmitDefaultValue = true)]
        public bool SkipValidation { get; set; }

        /// <summary>
        /// The International Bank Account Number. This field is required if the &#x60;type&#x60; field is set to &#x60;SEPA&#x60;. 
        /// </summary>
        /// <value>The International Bank Account Number. This field is required if the &#x60;type&#x60; field is set to &#x60;SEPA&#x60;. </value>
        [DataMember(Name = "IBAN", EmitDefaultValue = false)]
        public string IBAN { get; set; }

        /// <summary>
        /// Gets or Sets AccountHolderInfo
        /// </summary>
        [DataMember(Name = "accountHolderInfo", EmitDefaultValue = false)]
        public CreatePaymentMethodBankTransferAccountHolderInfo AccountHolderInfo { get; set; }

        /// <summary>
        /// The number of the customer&#39;s bank account. This field is required for the following bank transfer payment methods:   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) 
        /// </summary>
        /// <value>The number of the customer&#39;s bank account. This field is required for the following bank transfer payment methods:   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) </value>
        [DataMember(Name = "accountNumber", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// The sort code or number that identifies the bank. This is also known as the sort code. This field is required for the following bank transfer payment methods:   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) 
        /// </summary>
        /// <value>The sort code or number that identifies the bank. This is also known as the sort code. This field is required for the following bank transfer payment methods:   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) </value>
        [DataMember(Name = "bankCode", EmitDefaultValue = false)]
        public string BankCode { get; set; }

        /// <summary>
        /// The branch code of the bank used for direct debit. This field is required for the following bank transfer payment methods:   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) 
        /// </summary>
        /// <value>The branch code of the bank used for direct debit. This field is required for the following bank transfer payment methods:   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Direct Entry AU (&#x60;Becs&#x60;)   - Direct Debit NZ (&#x60;Becsnz&#x60;)   - Canadian Pre-Authorized Debit (&#x60;PAD&#x60;) </value>
        [DataMember(Name = "branchCode", EmitDefaultValue = false)]
        public string BranchCode { get; set; }

        /// <summary>
        /// The BIC code used for SEPA. 
        /// </summary>
        /// <value>The BIC code used for SEPA. </value>
        [DataMember(Name = "businessIdentificationCode", EmitDefaultValue = false)]
        public string BusinessIdentificationCode { get; set; }

        /// <summary>
        /// The currency used for payment method authorization.  If this field is not specified, &#x60;currency&#x60; specified for the account is used for payment method authorization. If no currency is specified for the account, the default currency of the account is then used. 
        /// </summary>
        /// <value>The currency used for payment method authorization.  If this field is not specified, &#x60;currency&#x60; specified for the account is used for payment method authorization. If no currency is specified for the account, the default currency of the account is then used. </value>
        [DataMember(Name = "currencyCode", EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The identity number used for Bank Transfer. This field is required for the following bank transfer payment methods:   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;) 
        /// </summary>
        /// <value>The identity number used for Bank Transfer. This field is required for the following bank transfer payment methods:   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Sweden Direct Debit (&#x60;Autogiro&#x60;) </value>
        [DataMember(Name = "identityNumber", EmitDefaultValue = false)]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// The masked credit card number, such as: &#x60;&#x60;&#x60; *********1112 &#x60;&#x60;&#x60;  This field is specific for the CC Reference Transaction payment method. It is an optional field that you can use to distinguish different CC Reference Transaction payment methods.  Though there are no special restrictions on the input string, it is highly recommended to specify a card number that is masked. 
        /// </summary>
        /// <value>The masked credit card number, such as: &#x60;&#x60;&#x60; *********1112 &#x60;&#x60;&#x60;  This field is specific for the CC Reference Transaction payment method. It is an optional field that you can use to distinguish different CC Reference Transaction payment methods.  Though there are no special restrictions on the input string, it is highly recommended to specify a card number that is masked. </value>
        [DataMember(Name = "creditCardMaskNumber", EmitDefaultValue = false)]
        public string CreditCardMaskNumber { get; set; }

        /// <summary>
        /// A gateway unique identifier that replaces sensitive payment method data.   &#x60;secondTokenId&#x60; is conditionally required only when &#x60;tokenId&#x60; is being used to represent a gateway customer profile. &#x60;secondTokenId&#x60; is used in the CC Reference Transaction payment method. 
        /// </summary>
        /// <value>A gateway unique identifier that replaces sensitive payment method data.   &#x60;secondTokenId&#x60; is conditionally required only when &#x60;tokenId&#x60; is being used to represent a gateway customer profile. &#x60;secondTokenId&#x60; is used in the CC Reference Transaction payment method. </value>
        [DataMember(Name = "secondTokenId", EmitDefaultValue = false)]
        public string SecondTokenId { get; set; }

        /// <summary>
        /// A gateway unique identifier that replaces sensitive payment method data or represents a gateway&#39;s unique customer profile. &#x60;tokenId&#x60; is required for the CC Reference Transaction payment method.  When &#x60;tokenId&#x60; is used to represent a customer profile, &#x60;secondTokenId&#x60; is conditionally required for representing the underlying tokenized payment method.  When creating an ACH payment method, if you need to pass in tokenized information, use the &#x60;mandateId&#x60; instead of &#x60;tokenId&#x60; field. 
        /// </summary>
        /// <value>A gateway unique identifier that replaces sensitive payment method data or represents a gateway&#39;s unique customer profile. &#x60;tokenId&#x60; is required for the CC Reference Transaction payment method.  When &#x60;tokenId&#x60; is used to represent a customer profile, &#x60;secondTokenId&#x60; is conditionally required for representing the underlying tokenized payment method.  When creating an ACH payment method, if you need to pass in tokenized information, use the &#x60;mandateId&#x60; instead of &#x60;tokenId&#x60; field. </value>
        [DataMember(Name = "tokenId", EmitDefaultValue = false)]
        public string TokenId { get; set; }

        /// <summary>
        /// This field is specific for setting up Apple Pay for Adyen to include payload with Apple Pay token or Apple payment data. This information should be stringified. For more information, see [Set up Adyen Apple Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Apple_Pay_on_Web/Set_up_Adyen_Apple_Pay). 
        /// </summary>
        /// <value>This field is specific for setting up Apple Pay for Adyen to include payload with Apple Pay token or Apple payment data. This information should be stringified. For more information, see [Set up Adyen Apple Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Apple_Pay_on_Web/Set_up_Adyen_Apple_Pay). </value>
        [DataMember(Name = "applePaymentData", EmitDefaultValue = false)]
        public string ApplePaymentData { get; set; }

        /// <summary>
        /// This field is specific for setting up Google Pay for Adyen and Chase gateway integrations to specify the stringified Google Pay token. For more information, see [Set up Adyen Google Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Adyen_Google_Pay) and [Set up Google Pay on Chase](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Google_Pay_on_Chase). 
        /// </summary>
        /// <value>This field is specific for setting up Google Pay for Adyen and Chase gateway integrations to specify the stringified Google Pay token. For more information, see [Set up Adyen Google Pay](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Adyen_Google_Pay) and [Set up Google Pay on Chase](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Payment_Method_Types/Set_up_Google_Pay_on_Chase). </value>
        [DataMember(Name = "googlePaymentToken", EmitDefaultValue = false)]
        public string GooglePaymentToken { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class POSTPaymentMethodRequest {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  BAID: ").Append(BAID).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  PreapprovalKey: ").Append(PreapprovalKey).Append("\n");
            sb.Append("  CardHolderInfo: ").Append(CardHolderInfo).Append("\n");
            sb.Append("  CardNumber: ").Append(CardNumber).Append("\n");
            sb.Append("  CardType: ").Append(CardType).Append("\n");
            sb.Append("  CheckDuplicated: ").Append(CheckDuplicated).Append("\n");
            sb.Append("  ExpirationMonth: ").Append(ExpirationMonth).Append("\n");
            sb.Append("  ExpirationYear: ").Append(ExpirationYear).Append("\n");
            sb.Append("  MitConsentAgreementRef: ").Append(MitConsentAgreementRef).Append("\n");
            sb.Append("  MitConsentAgreementSrc: ").Append(MitConsentAgreementSrc).Append("\n");
            sb.Append("  MitNetworkTransactionId: ").Append(MitNetworkTransactionId).Append("\n");
            sb.Append("  MitProfileAction: ").Append(MitProfileAction).Append("\n");
            sb.Append("  MitProfileAgreedOn: ").Append(MitProfileAgreedOn).Append("\n");
            sb.Append("  MitProfileType: ").Append(MitProfileType).Append("\n");
            sb.Append("  SecurityCode: ").Append(SecurityCode).Append("\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  BankABACode: ").Append(BankABACode).Append("\n");
            sb.Append("  BankAccountName: ").Append(BankAccountName).Append("\n");
            sb.Append("  BankAccountNumber: ").Append(BankAccountNumber).Append("\n");
            sb.Append("  BankAccountType: ").Append(BankAccountType).Append("\n");
            sb.Append("  BankName: ").Append(BankName).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  ZipCode: ").Append(ZipCode).Append("\n");
            sb.Append("  AccountKey: ").Append(AccountKey).Append("\n");
            sb.Append("  AuthGateway: ").Append(AuthGateway).Append("\n");
            sb.Append("  GatewayOptions: ").Append(GatewayOptions).Append("\n");
            sb.Append("  MakeDefault: ").Append(MakeDefault).Append("\n");
            sb.Append("  MandateInfo: ").Append(MandateInfo).Append("\n");
            sb.Append("  SkipValidation: ").Append(SkipValidation).Append("\n");
            sb.Append("  IBAN: ").Append(IBAN).Append("\n");
            sb.Append("  AccountHolderInfo: ").Append(AccountHolderInfo).Append("\n");
            sb.Append("  AccountNumber: ").Append(AccountNumber).Append("\n");
            sb.Append("  BankCode: ").Append(BankCode).Append("\n");
            sb.Append("  BranchCode: ").Append(BranchCode).Append("\n");
            sb.Append("  BusinessIdentificationCode: ").Append(BusinessIdentificationCode).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  IdentityNumber: ").Append(IdentityNumber).Append("\n");
            sb.Append("  CreditCardMaskNumber: ").Append(CreditCardMaskNumber).Append("\n");
            sb.Append("  SecondTokenId: ").Append(SecondTokenId).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  ApplePaymentData: ").Append(ApplePaymentData).Append("\n");
            sb.Append("  GooglePaymentToken: ").Append(GooglePaymentToken).Append("\n");
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
            return this.Equals(input as POSTPaymentMethodRequest);
        }

        /// <summary>
        /// Returns true if POSTPaymentMethodRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of POSTPaymentMethodRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(POSTPaymentMethodRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.BAID == input.BAID ||
                    (this.BAID != null &&
                    this.BAID.Equals(input.BAID))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.PreapprovalKey == input.PreapprovalKey ||
                    (this.PreapprovalKey != null &&
                    this.PreapprovalKey.Equals(input.PreapprovalKey))
                ) && 
                (
                    this.CardHolderInfo == input.CardHolderInfo ||
                    (this.CardHolderInfo != null &&
                    this.CardHolderInfo.Equals(input.CardHolderInfo))
                ) && 
                (
                    this.CardNumber == input.CardNumber ||
                    (this.CardNumber != null &&
                    this.CardNumber.Equals(input.CardNumber))
                ) && 
                (
                    this.CardType == input.CardType ||
                    (this.CardType != null &&
                    this.CardType.Equals(input.CardType))
                ) && 
                (
                    this.CheckDuplicated == input.CheckDuplicated ||
                    this.CheckDuplicated.Equals(input.CheckDuplicated)
                ) && 
                (
                    this.ExpirationMonth == input.ExpirationMonth ||
                    this.ExpirationMonth.Equals(input.ExpirationMonth)
                ) && 
                (
                    this.ExpirationYear == input.ExpirationYear ||
                    this.ExpirationYear.Equals(input.ExpirationYear)
                ) && 
                (
                    this.MitConsentAgreementRef == input.MitConsentAgreementRef ||
                    (this.MitConsentAgreementRef != null &&
                    this.MitConsentAgreementRef.Equals(input.MitConsentAgreementRef))
                ) && 
                (
                    this.MitConsentAgreementSrc == input.MitConsentAgreementSrc ||
                    this.MitConsentAgreementSrc.Equals(input.MitConsentAgreementSrc)
                ) && 
                (
                    this.MitNetworkTransactionId == input.MitNetworkTransactionId ||
                    (this.MitNetworkTransactionId != null &&
                    this.MitNetworkTransactionId.Equals(input.MitNetworkTransactionId))
                ) && 
                (
                    this.MitProfileAction == input.MitProfileAction ||
                    this.MitProfileAction.Equals(input.MitProfileAction)
                ) && 
                (
                    this.MitProfileAgreedOn == input.MitProfileAgreedOn ||
                    (this.MitProfileAgreedOn != null &&
                    this.MitProfileAgreedOn.Equals(input.MitProfileAgreedOn))
                ) && 
                (
                    this.MitProfileType == input.MitProfileType ||
                    this.MitProfileType.Equals(input.MitProfileType)
                ) && 
                (
                    this.SecurityCode == input.SecurityCode ||
                    (this.SecurityCode != null &&
                    this.SecurityCode.Equals(input.SecurityCode))
                ) && 
                (
                    this.AddressLine1 == input.AddressLine1 ||
                    (this.AddressLine1 != null &&
                    this.AddressLine1.Equals(input.AddressLine1))
                ) && 
                (
                    this.AddressLine2 == input.AddressLine2 ||
                    (this.AddressLine2 != null &&
                    this.AddressLine2.Equals(input.AddressLine2))
                ) && 
                (
                    this.BankABACode == input.BankABACode ||
                    (this.BankABACode != null &&
                    this.BankABACode.Equals(input.BankABACode))
                ) && 
                (
                    this.BankAccountName == input.BankAccountName ||
                    (this.BankAccountName != null &&
                    this.BankAccountName.Equals(input.BankAccountName))
                ) && 
                (
                    this.BankAccountNumber == input.BankAccountNumber ||
                    (this.BankAccountNumber != null &&
                    this.BankAccountNumber.Equals(input.BankAccountNumber))
                ) && 
                (
                    this.BankAccountType == input.BankAccountType ||
                    this.BankAccountType.Equals(input.BankAccountType)
                ) && 
                (
                    this.BankName == input.BankName ||
                    (this.BankName != null &&
                    this.BankName.Equals(input.BankName))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.ZipCode == input.ZipCode ||
                    (this.ZipCode != null &&
                    this.ZipCode.Equals(input.ZipCode))
                ) && 
                (
                    this.AccountKey == input.AccountKey ||
                    (this.AccountKey != null &&
                    this.AccountKey.Equals(input.AccountKey))
                ) && 
                (
                    this.AuthGateway == input.AuthGateway ||
                    (this.AuthGateway != null &&
                    this.AuthGateway.Equals(input.AuthGateway))
                ) && 
                (
                    this.GatewayOptions == input.GatewayOptions ||
                    (this.GatewayOptions != null &&
                    this.GatewayOptions.Equals(input.GatewayOptions))
                ) && 
                (
                    this.MakeDefault == input.MakeDefault ||
                    this.MakeDefault.Equals(input.MakeDefault)
                ) && 
                (
                    this.MandateInfo == input.MandateInfo ||
                    (this.MandateInfo != null &&
                    this.MandateInfo.Equals(input.MandateInfo))
                ) && 
                (
                    this.SkipValidation == input.SkipValidation ||
                    this.SkipValidation.Equals(input.SkipValidation)
                ) && 
                (
                    this.IBAN == input.IBAN ||
                    (this.IBAN != null &&
                    this.IBAN.Equals(input.IBAN))
                ) && 
                (
                    this.AccountHolderInfo == input.AccountHolderInfo ||
                    (this.AccountHolderInfo != null &&
                    this.AccountHolderInfo.Equals(input.AccountHolderInfo))
                ) && 
                (
                    this.AccountNumber == input.AccountNumber ||
                    (this.AccountNumber != null &&
                    this.AccountNumber.Equals(input.AccountNumber))
                ) && 
                (
                    this.BankCode == input.BankCode ||
                    (this.BankCode != null &&
                    this.BankCode.Equals(input.BankCode))
                ) && 
                (
                    this.BranchCode == input.BranchCode ||
                    (this.BranchCode != null &&
                    this.BranchCode.Equals(input.BranchCode))
                ) && 
                (
                    this.BusinessIdentificationCode == input.BusinessIdentificationCode ||
                    (this.BusinessIdentificationCode != null &&
                    this.BusinessIdentificationCode.Equals(input.BusinessIdentificationCode))
                ) && 
                (
                    this.CurrencyCode == input.CurrencyCode ||
                    (this.CurrencyCode != null &&
                    this.CurrencyCode.Equals(input.CurrencyCode))
                ) && 
                (
                    this.IdentityNumber == input.IdentityNumber ||
                    (this.IdentityNumber != null &&
                    this.IdentityNumber.Equals(input.IdentityNumber))
                ) && 
                (
                    this.CreditCardMaskNumber == input.CreditCardMaskNumber ||
                    (this.CreditCardMaskNumber != null &&
                    this.CreditCardMaskNumber.Equals(input.CreditCardMaskNumber))
                ) && 
                (
                    this.SecondTokenId == input.SecondTokenId ||
                    (this.SecondTokenId != null &&
                    this.SecondTokenId.Equals(input.SecondTokenId))
                ) && 
                (
                    this.TokenId == input.TokenId ||
                    (this.TokenId != null &&
                    this.TokenId.Equals(input.TokenId))
                ) && 
                (
                    this.ApplePaymentData == input.ApplePaymentData ||
                    (this.ApplePaymentData != null &&
                    this.ApplePaymentData.Equals(input.ApplePaymentData))
                ) && 
                (
                    this.GooglePaymentToken == input.GooglePaymentToken ||
                    (this.GooglePaymentToken != null &&
                    this.GooglePaymentToken.Equals(input.GooglePaymentToken))
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
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.BAID != null)
                {
                    hashCode = (hashCode * 59) + this.BAID.GetHashCode();
                }
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.PreapprovalKey != null)
                {
                    hashCode = (hashCode * 59) + this.PreapprovalKey.GetHashCode();
                }
                if (this.CardHolderInfo != null)
                {
                    hashCode = (hashCode * 59) + this.CardHolderInfo.GetHashCode();
                }
                if (this.CardNumber != null)
                {
                    hashCode = (hashCode * 59) + this.CardNumber.GetHashCode();
                }
                if (this.CardType != null)
                {
                    hashCode = (hashCode * 59) + this.CardType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CheckDuplicated.GetHashCode();
                hashCode = (hashCode * 59) + this.ExpirationMonth.GetHashCode();
                hashCode = (hashCode * 59) + this.ExpirationYear.GetHashCode();
                if (this.MitConsentAgreementRef != null)
                {
                    hashCode = (hashCode * 59) + this.MitConsentAgreementRef.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MitConsentAgreementSrc.GetHashCode();
                if (this.MitNetworkTransactionId != null)
                {
                    hashCode = (hashCode * 59) + this.MitNetworkTransactionId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MitProfileAction.GetHashCode();
                if (this.MitProfileAgreedOn != null)
                {
                    hashCode = (hashCode * 59) + this.MitProfileAgreedOn.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MitProfileType.GetHashCode();
                if (this.SecurityCode != null)
                {
                    hashCode = (hashCode * 59) + this.SecurityCode.GetHashCode();
                }
                if (this.AddressLine1 != null)
                {
                    hashCode = (hashCode * 59) + this.AddressLine1.GetHashCode();
                }
                if (this.AddressLine2 != null)
                {
                    hashCode = (hashCode * 59) + this.AddressLine2.GetHashCode();
                }
                if (this.BankABACode != null)
                {
                    hashCode = (hashCode * 59) + this.BankABACode.GetHashCode();
                }
                if (this.BankAccountName != null)
                {
                    hashCode = (hashCode * 59) + this.BankAccountName.GetHashCode();
                }
                if (this.BankAccountNumber != null)
                {
                    hashCode = (hashCode * 59) + this.BankAccountNumber.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.BankAccountType.GetHashCode();
                if (this.BankName != null)
                {
                    hashCode = (hashCode * 59) + this.BankName.GetHashCode();
                }
                if (this.City != null)
                {
                    hashCode = (hashCode * 59) + this.City.GetHashCode();
                }
                if (this.Country != null)
                {
                    hashCode = (hashCode * 59) + this.Country.GetHashCode();
                }
                if (this.Phone != null)
                {
                    hashCode = (hashCode * 59) + this.Phone.GetHashCode();
                }
                if (this.State != null)
                {
                    hashCode = (hashCode * 59) + this.State.GetHashCode();
                }
                if (this.ZipCode != null)
                {
                    hashCode = (hashCode * 59) + this.ZipCode.GetHashCode();
                }
                if (this.AccountKey != null)
                {
                    hashCode = (hashCode * 59) + this.AccountKey.GetHashCode();
                }
                if (this.AuthGateway != null)
                {
                    hashCode = (hashCode * 59) + this.AuthGateway.GetHashCode();
                }
                if (this.GatewayOptions != null)
                {
                    hashCode = (hashCode * 59) + this.GatewayOptions.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MakeDefault.GetHashCode();
                if (this.MandateInfo != null)
                {
                    hashCode = (hashCode * 59) + this.MandateInfo.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SkipValidation.GetHashCode();
                if (this.IBAN != null)
                {
                    hashCode = (hashCode * 59) + this.IBAN.GetHashCode();
                }
                if (this.AccountHolderInfo != null)
                {
                    hashCode = (hashCode * 59) + this.AccountHolderInfo.GetHashCode();
                }
                if (this.AccountNumber != null)
                {
                    hashCode = (hashCode * 59) + this.AccountNumber.GetHashCode();
                }
                if (this.BankCode != null)
                {
                    hashCode = (hashCode * 59) + this.BankCode.GetHashCode();
                }
                if (this.BranchCode != null)
                {
                    hashCode = (hashCode * 59) + this.BranchCode.GetHashCode();
                }
                if (this.BusinessIdentificationCode != null)
                {
                    hashCode = (hashCode * 59) + this.BusinessIdentificationCode.GetHashCode();
                }
                if (this.CurrencyCode != null)
                {
                    hashCode = (hashCode * 59) + this.CurrencyCode.GetHashCode();
                }
                if (this.IdentityNumber != null)
                {
                    hashCode = (hashCode * 59) + this.IdentityNumber.GetHashCode();
                }
                if (this.CreditCardMaskNumber != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardMaskNumber.GetHashCode();
                }
                if (this.SecondTokenId != null)
                {
                    hashCode = (hashCode * 59) + this.SecondTokenId.GetHashCode();
                }
                if (this.TokenId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                }
                if (this.ApplePaymentData != null)
                {
                    hashCode = (hashCode * 59) + this.ApplePaymentData.GetHashCode();
                }
                if (this.GooglePaymentToken != null)
                {
                    hashCode = (hashCode * 59) + this.GooglePaymentToken.GetHashCode();
                }
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
            // MitConsentAgreementRef (string) maxLength
            if (this.MitConsentAgreementRef != null && this.MitConsentAgreementRef.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MitConsentAgreementRef, length must be less than 128.", new [] { "MitConsentAgreementRef" });
            }

            // MitNetworkTransactionId (string) maxLength
            if (this.MitNetworkTransactionId != null && this.MitNetworkTransactionId.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MitNetworkTransactionId, length must be less than 128.", new [] { "MitNetworkTransactionId" });
            }

            // BankAccountName (string) maxLength
            if (this.BankAccountName != null && this.BankAccountName.Length > 70)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BankAccountName, length must be less than 70.", new [] { "BankAccountName" });
            }

            // BankAccountNumber (string) maxLength
            if (this.BankAccountNumber != null && this.BankAccountNumber.Length > 30)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BankAccountNumber, length must be less than 30.", new [] { "BankAccountNumber" });
            }

            // BankName (string) maxLength
            if (this.BankName != null && this.BankName.Length > 70)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BankName, length must be less than 70.", new [] { "BankName" });
            }

            // CreditCardMaskNumber (string) maxLength
            if (this.CreditCardMaskNumber != null && this.CreditCardMaskNumber.Length > 19)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CreditCardMaskNumber, length must be less than 19.", new [] { "CreditCardMaskNumber" });
            }

            yield break;
        }
    }

}
