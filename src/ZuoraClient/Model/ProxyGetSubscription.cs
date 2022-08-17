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
    /// ProxyGetSubscription
    /// </summary>
    [DataContract(Name = "ProxyGetSubscription")]
    public partial class ProxyGetSubscription : IEquatable<ProxyGetSubscription>, IValidatableObject
    {
        /// <summary>
        /// An enum field on the Subscription object to indicate the name of a third-party store. This field is used to represent subscriptions created through third-party stores. 
        /// </summary>
        /// <value>An enum field on the Subscription object to indicate the name of a third-party store. This field is used to represent subscriptions created through third-party stores. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExternallyManagedByEnum
        {
            /// <summary>
            /// Enum Amazon for value: Amazon
            /// </summary>
            [EnumMember(Value = "Amazon")]
            Amazon = 1,

            /// <summary>
            /// Enum Apple for value: Apple
            /// </summary>
            [EnumMember(Value = "Apple")]
            Apple = 2,

            /// <summary>
            /// Enum Google for value: Google
            /// </summary>
            [EnumMember(Value = "Google")]
            Google = 3,

            /// <summary>
            /// Enum Roku for value: Roku
            /// </summary>
            [EnumMember(Value = "Roku")]
            Roku = 4

        }


        /// <summary>
        /// An enum field on the Subscription object to indicate the name of a third-party store. This field is used to represent subscriptions created through third-party stores. 
        /// </summary>
        /// <value>An enum field on the Subscription object to indicate the name of a third-party store. This field is used to represent subscriptions created through third-party stores. </value>
        [DataMember(Name = "ExternallyManagedBy", EmitDefaultValue = false)]
        public ExternallyManagedByEnum? ExternallyManagedBy { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetSubscription" /> class.
        /// </summary>
        /// <param name="accountId"> This field can be updated when **Status** is &#x60;Draft&#x60;. The ID of a valid account ID. .</param>
        /// <param name="autoRenew"> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if the subscription automatically renews at the end of the term. **Values**: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="cancelledDate"> The date on which the subscription was canceled. .</param>
        /// <param name="contractAcceptanceDate"> The date when the customer accepts the contract. This field can be updated when **Status** is &#x60;Draft&#x60;. .</param>
        /// <param name="contractEffectiveDate"> The date when the contract takes effect. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: This field is required in the subscribe call. If you set the value of this field to null and both the ServiceActivationDate and ContractAcceptanceDate fields are not required, the subscribe call still returns success, but the new subscription is in &#x60;DRAFT&#x60; status. To activate the subscription, you must set a valid date to this field. .</param>
        /// <param name="createdById">The user ID of the person who created the subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="createdDate"> The date the subscription was created. This value is the same as the OriginalCreatedDate value until the subscription is amended. **Values**: automatically generated .</param>
        /// <param name="creatorAccountId"> The account ID that created the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="creatorInvoiceOwnerId"> The account ID that owns the invoices associated with the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="currentTerm"> The length of the period for the current subscription term. If TermType is set to &#x60;TERMED&#x60;, this field is required and must be greater than &#x60;0&#x60;. If TermType is set to &#x60;EVERGREEN&#x60;, this value is ignored. Default is &#x60;0&#x60;. **Character limit**: 20 **Values**: automatically generated .</param>
        /// <param name="currentTermPeriodType"> The period type for the current subscription term. This field is used with the CurrentTerm field to specify the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; .</param>
        /// <param name="externallyManagedBy">An enum field on the Subscription object to indicate the name of a third-party store. This field is used to represent subscriptions created through third-party stores. .</param>
        /// <param name="id">Object identifier..</param>
        /// <param name="initialTerm"> The length of the period for the first subscription term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: If TermType is Termed **Character limit**: 20 **Values**: any valid number. The default value is 0. .</param>
        /// <param name="initialTermPeriodType"> The period type for the first subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the InitialTerm field to specify the initial subscription term. .</param>
        /// <param name="invoiceOwnerId"> This field can be updated when **Status** is &#x60;Draft&#x60;. A valid account ID. .</param>
        /// <param name="isInvoiceSeparate"> Determines if the subscription is invoiced separately. If &#x60;TRUE&#x60;, then all charges for this subscription are collected into the subscription&#39;s own invoice. **Values**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) .</param>
        /// <param name="isLatestVersion"> Determines if the subscription is the latest version. If the value of this field is &#x60;TRUE&#x60;, the subscription is the latest version. **Values**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) .</param>
        /// <param name="name"> The unique identifier of the subscription. If you don&#39;t specify a value, then Zuora generates a name automatically. Whether auto-generated or manually specified, the subscription name must be unique. Otherwise an error will occur. **Character limit**: 100 **Values**: one of the following:  - leave null to automatically generate - a string of 100 characters or fewer .</param>
        /// <param name="notes"> Use this field to record comments about the subscription. **Character limit**: 500 **Values**: a string of 500 characters or fewer .</param>
        /// <param name="originalCreatedDate"> The date when the subscription was originally created. This value is the same as the CreatedDate value until the subscription is amended. **Values**: automatically generated .</param>
        /// <param name="originalId"> The original ID of this subscription. **Values**: automatically generated .</param>
        /// <param name="paymentTerm">The name of the payment term associated with the subscription. For example, &#x60;Net 30&#x60;. The payment term determines the due dates of invoices.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;115&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. .</param>
        /// <param name="previousSubscriptionId"> The subscription ID immediately prior to the current subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="renewalSetting"> This field can be updated when **Status** is &#x60;Draft&#x60;. Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: &#x60;RENEW_WITH_SPECIFIC_TERM &#x60;(default), &#x60;RENEW_TO_EVERGREEN&#x60; .</param>
        /// <param name="renewalTerm"> The length of the period for the subscription renewal term. This field can be updated when **Status** is &#x60;Draft&#x60;. **Required**: If TermType is Termed. **Character limit**: 20 **Values**: one of the following:  - leave null to default to &#x60;0&#x60; - any number .</param>
        /// <param name="renewalTermPeriodType"> The period type for the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field is used with the RenewalTerm field to specify the subscription renewal term. - This field can be updated when Status is &#x60;Draft&#x60;. .</param>
        /// <param name="revision">An auto-generated decimal value uniquely tagged with a subscription. The value always contains one decimal place, for example, the revision of a new subscription is 1.0. If a further version of the subscription is created, the Revision value will be increased by 1. Also, the Revision value is always incremental regardless of deletion of subscription versions. **Note:** To get this field, you must set the Zuora WSDL version to 107.0 or over in the &#x60;X-Zuora-WSDL-Version&#x60; header parameter. .</param>
        /// <param name="serviceActivationDate"> The date when the subscription is activated. This field can be updated when **Status** is &#x60;Draft&#x60;. .</param>
        /// <param name="status"> The status of the subscription. **Character limit**: 17 **Values**: automatically generated **Possible values**: one of the following:  - &#x60;Draft&#x60; - &#x60;Pending Activation&#x60; - &#x60;Pending Acceptance&#x60; - &#x60;Active&#x60; - &#x60;Cancelled&#x60; - &#x60;Expired&#x60; - &#x60;Suspended&#x60; (This value is in **Limited Availability**.) .</param>
        /// <param name="subscriptionBillToId">The bill-to contact ID of the subscription.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;121&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. .</param>
        /// <param name="subscriptionBillToSnapshotId">The snapshot ID of the subscription&#39;s bill-to contact. The snapshot ID will not change after the subscription version is created.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;121&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. .</param>
        /// <param name="subscriptionEndDate"> The date when the subscription term ends, where the subscription ends at midnight the day before. For example, if the SubscriptionEndDate is 12/31/2016, the subscriptions ends at midnight (00:00:00 hours) on 12/30/2016. This date is the same as the term end date or the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="subscriptionStartDate"> The date when the subscription term starts. This date is the same as the start date of the original term, which isn&#39;t necessarily the start date of the current or new term. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="termEndDate"> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term ends. If the subscription is evergreen, the TermEndDate value is null or is the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="termStartDate"> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term begins. If this is a renewal subscription, then this date is different from the subscription start date. **Character limit**: 29 **Version notes**: - - .</param>
        /// <param name="termType"> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if a subscription is termed or evergreen. **Character limit**: 9 **Values**: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60; .</param>
        /// <param name="updatedById"> The ID of the user who last updated the subscription. **Character limit:** 32 **Values: **automatically generated .</param>
        /// <param name="updatedDate"> The date when the subscription was last updated. **Character limit:** 29 **Values**: automatically generated .</param>
        /// <param name="version"> The version number of the subscription. **Values**: automatically generated .</param>
        /// <param name="lastBookingDate">The last booking date of the subscription object. This field is writable only when the subscription is newly created as a first version subscription. You can override the date value when creating a subscription through the Subscribe and Amend API or the subscription creation UI (non-Orders). Otherwise, the default value &#x60;today&#x60; is set per the user&#39;s timezone. The value of this field is as follows: * For a new subscription created by the [Subscribe and Amend APIs](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Migration_Guidance#Subscribe_and_Amend_APIs_to_Migrate), this field has the value of the subscription creation date. * For a subscription changed by an amendment, this field has the value of the amendment booking date. * For a subscription created or changed by an order, this field has the value of the order date. .</param>
        /// <param name="cpqBundleJsonIdQT">The Bundle product structures from Zuora Quotes if you utilize Bundling in Salesforce. Do not change the value in this field. .</param>
        /// <param name="opportunityCloseDateQT">The closing date of the Opportunity. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. .</param>
        /// <param name="opportunityNameQT">The unique identifier of the Opportunity. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. .</param>
        /// <param name="quoteBusinessTypeQT">The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal or Churn. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. .</param>
        /// <param name="quoteNumberQT">The unique identifier of the Quote. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. .</param>
        /// <param name="quoteTypeQT">The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. .</param>
        /// <param name="integrationIdNS">ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="integrationStatusNS">Status of the subscription&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="projectNS">The NetSuite project that the subscription was created from. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="salesOrderNS">The NetSuite sales order than the subscription was created from. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="syncDateNS">Date when the subscription was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        public ProxyGetSubscription(string accountId = default(string), bool autoRenew = default(bool), DateTime cancelledDate = default(DateTime), DateTime contractAcceptanceDate = default(DateTime), DateTime contractEffectiveDate = default(DateTime), string createdById = default(string), DateTime createdDate = default(DateTime), string creatorAccountId = default(string), string creatorInvoiceOwnerId = default(string), int currentTerm = default(int), string currentTermPeriodType = default(string), ExternallyManagedByEnum? externallyManagedBy = default(ExternallyManagedByEnum?), string id = default(string), int initialTerm = default(int), string initialTermPeriodType = default(string), string invoiceOwnerId = default(string), bool isInvoiceSeparate = default(bool), bool isLatestVersion = default(bool), string name = default(string), string notes = default(string), DateTime originalCreatedDate = default(DateTime), string originalId = default(string), string paymentTerm = default(string), string previousSubscriptionId = default(string), string renewalSetting = default(string), int renewalTerm = default(int), string renewalTermPeriodType = default(string), string revision = default(string), DateTime serviceActivationDate = default(DateTime), string status = default(string), string subscriptionBillToId = default(string), string subscriptionBillToSnapshotId = default(string), DateTime subscriptionEndDate = default(DateTime), DateTime subscriptionStartDate = default(DateTime), DateTime termEndDate = default(DateTime), DateTime termStartDate = default(DateTime), string termType = default(string), string updatedById = default(string), DateTime updatedDate = default(DateTime), int version = default(int), DateTime lastBookingDate = default(DateTime), string cpqBundleJsonIdQT = default(string), DateTime opportunityCloseDateQT = default(DateTime), string opportunityNameQT = default(string), string quoteBusinessTypeQT = default(string), string quoteNumberQT = default(string), string quoteTypeQT = default(string), string integrationIdNS = default(string), string integrationStatusNS = default(string), string projectNS = default(string), string salesOrderNS = default(string), string syncDateNS = default(string))
        {
            this.AccountId = accountId;
            this.AutoRenew = autoRenew;
            this.CancelledDate = cancelledDate;
            this.ContractAcceptanceDate = contractAcceptanceDate;
            this.ContractEffectiveDate = contractEffectiveDate;
            this.CreatedById = createdById;
            this.CreatedDate = createdDate;
            this.CreatorAccountId = creatorAccountId;
            this.CreatorInvoiceOwnerId = creatorInvoiceOwnerId;
            this.CurrentTerm = currentTerm;
            this.CurrentTermPeriodType = currentTermPeriodType;
            this.ExternallyManagedBy = externallyManagedBy;
            this.Id = id;
            this.InitialTerm = initialTerm;
            this.InitialTermPeriodType = initialTermPeriodType;
            this.InvoiceOwnerId = invoiceOwnerId;
            this.IsInvoiceSeparate = isInvoiceSeparate;
            this.IsLatestVersion = isLatestVersion;
            this.Name = name;
            this.Notes = notes;
            this.OriginalCreatedDate = originalCreatedDate;
            this.OriginalId = originalId;
            this.PaymentTerm = paymentTerm;
            this.PreviousSubscriptionId = previousSubscriptionId;
            this.RenewalSetting = renewalSetting;
            this.RenewalTerm = renewalTerm;
            this.RenewalTermPeriodType = renewalTermPeriodType;
            this.Revision = revision;
            this.ServiceActivationDate = serviceActivationDate;
            this.Status = status;
            this.SubscriptionBillToId = subscriptionBillToId;
            this.SubscriptionBillToSnapshotId = subscriptionBillToSnapshotId;
            this.SubscriptionEndDate = subscriptionEndDate;
            this.SubscriptionStartDate = subscriptionStartDate;
            this.TermEndDate = termEndDate;
            this.TermStartDate = termStartDate;
            this.TermType = termType;
            this.UpdatedById = updatedById;
            this.UpdatedDate = updatedDate;
            this._Version = version;
            this.LastBookingDate = lastBookingDate;
            this.CpqBundleJsonIdQT = cpqBundleJsonIdQT;
            this.OpportunityCloseDateQT = opportunityCloseDateQT;
            this.OpportunityNameQT = opportunityNameQT;
            this.QuoteBusinessTypeQT = quoteBusinessTypeQT;
            this.QuoteNumberQT = quoteNumberQT;
            this.QuoteTypeQT = quoteTypeQT;
            this.IntegrationIdNS = integrationIdNS;
            this.IntegrationStatusNS = integrationStatusNS;
            this.ProjectNS = projectNS;
            this.SalesOrderNS = salesOrderNS;
            this.SyncDateNS = syncDateNS;
        }

        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. The ID of a valid account ID. 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. The ID of a valid account ID. </value>
        [DataMember(Name = "AccountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if the subscription automatically renews at the end of the term. **Values**: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if the subscription automatically renews at the end of the term. **Values**: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name = "AutoRenew", EmitDefaultValue = true)]
        public bool AutoRenew { get; set; }

        /// <summary>
        ///  The date on which the subscription was canceled. 
        /// </summary>
        /// <value> The date on which the subscription was canceled. </value>
        [DataMember(Name = "CancelledDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime CancelledDate { get; set; }

        /// <summary>
        ///  The date when the customer accepts the contract. This field can be updated when **Status** is &#x60;Draft&#x60;. 
        /// </summary>
        /// <value> The date when the customer accepts the contract. This field can be updated when **Status** is &#x60;Draft&#x60;. </value>
        [DataMember(Name = "ContractAcceptanceDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ContractAcceptanceDate { get; set; }

        /// <summary>
        ///  The date when the contract takes effect. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: This field is required in the subscribe call. If you set the value of this field to null and both the ServiceActivationDate and ContractAcceptanceDate fields are not required, the subscribe call still returns success, but the new subscription is in &#x60;DRAFT&#x60; status. To activate the subscription, you must set a valid date to this field. 
        /// </summary>
        /// <value> The date when the contract takes effect. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: This field is required in the subscribe call. If you set the value of this field to null and both the ServiceActivationDate and ContractAcceptanceDate fields are not required, the subscribe call still returns success, but the new subscription is in &#x60;DRAFT&#x60; status. To activate the subscription, you must set a valid date to this field. </value>
        [DataMember(Name = "ContractEffectiveDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ContractEffectiveDate { get; set; }

        /// <summary>
        /// The user ID of the person who created the subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The user ID of the person who created the subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name = "CreatedById", EmitDefaultValue = false)]
        public string CreatedById { get; set; }

        /// <summary>
        ///  The date the subscription was created. This value is the same as the OriginalCreatedDate value until the subscription is amended. **Values**: automatically generated 
        /// </summary>
        /// <value> The date the subscription was created. This value is the same as the OriginalCreatedDate value until the subscription is amended. **Values**: automatically generated </value>
        [DataMember(Name = "CreatedDate", EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///  The account ID that created the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The account ID that created the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name = "CreatorAccountId", EmitDefaultValue = false)]
        public string CreatorAccountId { get; set; }

        /// <summary>
        ///  The account ID that owns the invoices associated with the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The account ID that owns the invoices associated with the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name = "CreatorInvoiceOwnerId", EmitDefaultValue = false)]
        public string CreatorInvoiceOwnerId { get; set; }

        /// <summary>
        ///  The length of the period for the current subscription term. If TermType is set to &#x60;TERMED&#x60;, this field is required and must be greater than &#x60;0&#x60;. If TermType is set to &#x60;EVERGREEN&#x60;, this value is ignored. Default is &#x60;0&#x60;. **Character limit**: 20 **Values**: automatically generated 
        /// </summary>
        /// <value> The length of the period for the current subscription term. If TermType is set to &#x60;TERMED&#x60;, this field is required and must be greater than &#x60;0&#x60;. If TermType is set to &#x60;EVERGREEN&#x60;, this value is ignored. Default is &#x60;0&#x60;. **Character limit**: 20 **Values**: automatically generated </value>
        [DataMember(Name = "CurrentTerm", EmitDefaultValue = false)]
        public int CurrentTerm { get; set; }

        /// <summary>
        ///  The period type for the current subscription term. This field is used with the CurrentTerm field to specify the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; 
        /// </summary>
        /// <value> The period type for the current subscription term. This field is used with the CurrentTerm field to specify the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; </value>
        [DataMember(Name = "CurrentTermPeriodType", EmitDefaultValue = false)]
        public string CurrentTermPeriodType { get; set; }

        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name = "Id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        ///  The length of the period for the first subscription term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: If TermType is Termed **Character limit**: 20 **Values**: any valid number. The default value is 0. 
        /// </summary>
        /// <value> The length of the period for the first subscription term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: If TermType is Termed **Character limit**: 20 **Values**: any valid number. The default value is 0. </value>
        [DataMember(Name = "InitialTerm", EmitDefaultValue = false)]
        public int InitialTerm { get; set; }

        /// <summary>
        ///  The period type for the first subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the InitialTerm field to specify the initial subscription term. 
        /// </summary>
        /// <value> The period type for the first subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the InitialTerm field to specify the initial subscription term. </value>
        [DataMember(Name = "InitialTermPeriodType", EmitDefaultValue = false)]
        public string InitialTermPeriodType { get; set; }

        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. A valid account ID. 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. A valid account ID. </value>
        [DataMember(Name = "InvoiceOwnerId", EmitDefaultValue = false)]
        public string InvoiceOwnerId { get; set; }

        /// <summary>
        ///  Determines if the subscription is invoiced separately. If &#x60;TRUE&#x60;, then all charges for this subscription are collected into the subscription&#39;s own invoice. **Values**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) 
        /// </summary>
        /// <value> Determines if the subscription is invoiced separately. If &#x60;TRUE&#x60;, then all charges for this subscription are collected into the subscription&#39;s own invoice. **Values**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) </value>
        [DataMember(Name = "IsInvoiceSeparate", EmitDefaultValue = true)]
        public bool IsInvoiceSeparate { get; set; }

        /// <summary>
        ///  Determines if the subscription is the latest version. If the value of this field is &#x60;TRUE&#x60;, the subscription is the latest version. **Values**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) 
        /// </summary>
        /// <value> Determines if the subscription is the latest version. If the value of this field is &#x60;TRUE&#x60;, the subscription is the latest version. **Values**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) </value>
        [DataMember(Name = "IsLatestVersion", EmitDefaultValue = true)]
        public bool IsLatestVersion { get; set; }

        /// <summary>
        ///  The unique identifier of the subscription. If you don&#39;t specify a value, then Zuora generates a name automatically. Whether auto-generated or manually specified, the subscription name must be unique. Otherwise an error will occur. **Character limit**: 100 **Values**: one of the following:  - leave null to automatically generate - a string of 100 characters or fewer 
        /// </summary>
        /// <value> The unique identifier of the subscription. If you don&#39;t specify a value, then Zuora generates a name automatically. Whether auto-generated or manually specified, the subscription name must be unique. Otherwise an error will occur. **Character limit**: 100 **Values**: one of the following:  - leave null to automatically generate - a string of 100 characters or fewer </value>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///  Use this field to record comments about the subscription. **Character limit**: 500 **Values**: a string of 500 characters or fewer 
        /// </summary>
        /// <value> Use this field to record comments about the subscription. **Character limit**: 500 **Values**: a string of 500 characters or fewer </value>
        [DataMember(Name = "Notes", EmitDefaultValue = false)]
        public string Notes { get; set; }

        /// <summary>
        ///  The date when the subscription was originally created. This value is the same as the CreatedDate value until the subscription is amended. **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription was originally created. This value is the same as the CreatedDate value until the subscription is amended. **Values**: automatically generated </value>
        [DataMember(Name = "OriginalCreatedDate", EmitDefaultValue = false)]
        public DateTime OriginalCreatedDate { get; set; }

        /// <summary>
        ///  The original ID of this subscription. **Values**: automatically generated 
        /// </summary>
        /// <value> The original ID of this subscription. **Values**: automatically generated </value>
        [DataMember(Name = "OriginalId", EmitDefaultValue = false)]
        public string OriginalId { get; set; }

        /// <summary>
        /// The name of the payment term associated with the subscription. For example, &#x60;Net 30&#x60;. The payment term determines the due dates of invoices.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;115&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. 
        /// </summary>
        /// <value>The name of the payment term associated with the subscription. For example, &#x60;Net 30&#x60;. The payment term determines the due dates of invoices.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;115&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. </value>
        [DataMember(Name = "PaymentTerm", EmitDefaultValue = false)]
        public string PaymentTerm { get; set; }

        /// <summary>
        ///  The subscription ID immediately prior to the current subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The subscription ID immediately prior to the current subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name = "PreviousSubscriptionId", EmitDefaultValue = false)]
        public string PreviousSubscriptionId { get; set; }

        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: &#x60;RENEW_WITH_SPECIFIC_TERM &#x60;(default), &#x60;RENEW_TO_EVERGREEN&#x60; 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: &#x60;RENEW_WITH_SPECIFIC_TERM &#x60;(default), &#x60;RENEW_TO_EVERGREEN&#x60; </value>
        [DataMember(Name = "RenewalSetting", EmitDefaultValue = false)]
        public string RenewalSetting { get; set; }

        /// <summary>
        ///  The length of the period for the subscription renewal term. This field can be updated when **Status** is &#x60;Draft&#x60;. **Required**: If TermType is Termed. **Character limit**: 20 **Values**: one of the following:  - leave null to default to &#x60;0&#x60; - any number 
        /// </summary>
        /// <value> The length of the period for the subscription renewal term. This field can be updated when **Status** is &#x60;Draft&#x60;. **Required**: If TermType is Termed. **Character limit**: 20 **Values**: one of the following:  - leave null to default to &#x60;0&#x60; - any number </value>
        [DataMember(Name = "RenewalTerm", EmitDefaultValue = false)]
        public int RenewalTerm { get; set; }

        /// <summary>
        ///  The period type for the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field is used with the RenewalTerm field to specify the subscription renewal term. - This field can be updated when Status is &#x60;Draft&#x60;. 
        /// </summary>
        /// <value> The period type for the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field is used with the RenewalTerm field to specify the subscription renewal term. - This field can be updated when Status is &#x60;Draft&#x60;. </value>
        [DataMember(Name = "RenewalTermPeriodType", EmitDefaultValue = false)]
        public string RenewalTermPeriodType { get; set; }

        /// <summary>
        /// An auto-generated decimal value uniquely tagged with a subscription. The value always contains one decimal place, for example, the revision of a new subscription is 1.0. If a further version of the subscription is created, the Revision value will be increased by 1. Also, the Revision value is always incremental regardless of deletion of subscription versions. **Note:** To get this field, you must set the Zuora WSDL version to 107.0 or over in the &#x60;X-Zuora-WSDL-Version&#x60; header parameter. 
        /// </summary>
        /// <value>An auto-generated decimal value uniquely tagged with a subscription. The value always contains one decimal place, for example, the revision of a new subscription is 1.0. If a further version of the subscription is created, the Revision value will be increased by 1. Also, the Revision value is always incremental regardless of deletion of subscription versions. **Note:** To get this field, you must set the Zuora WSDL version to 107.0 or over in the &#x60;X-Zuora-WSDL-Version&#x60; header parameter. </value>
        [DataMember(Name = "Revision", EmitDefaultValue = false)]
        public string Revision { get; set; }

        /// <summary>
        ///  The date when the subscription is activated. This field can be updated when **Status** is &#x60;Draft&#x60;. 
        /// </summary>
        /// <value> The date when the subscription is activated. This field can be updated when **Status** is &#x60;Draft&#x60;. </value>
        [DataMember(Name = "ServiceActivationDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ServiceActivationDate { get; set; }

        /// <summary>
        ///  The status of the subscription. **Character limit**: 17 **Values**: automatically generated **Possible values**: one of the following:  - &#x60;Draft&#x60; - &#x60;Pending Activation&#x60; - &#x60;Pending Acceptance&#x60; - &#x60;Active&#x60; - &#x60;Cancelled&#x60; - &#x60;Expired&#x60; - &#x60;Suspended&#x60; (This value is in **Limited Availability**.) 
        /// </summary>
        /// <value> The status of the subscription. **Character limit**: 17 **Values**: automatically generated **Possible values**: one of the following:  - &#x60;Draft&#x60; - &#x60;Pending Activation&#x60; - &#x60;Pending Acceptance&#x60; - &#x60;Active&#x60; - &#x60;Cancelled&#x60; - &#x60;Expired&#x60; - &#x60;Suspended&#x60; (This value is in **Limited Availability**.) </value>
        [DataMember(Name = "Status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// The bill-to contact ID of the subscription.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;121&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. 
        /// </summary>
        /// <value>The bill-to contact ID of the subscription.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;121&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. </value>
        [DataMember(Name = "SubscriptionBillToId", EmitDefaultValue = false)]
        public string SubscriptionBillToId { get; set; }

        /// <summary>
        /// The snapshot ID of the subscription&#39;s bill-to contact. The snapshot ID will not change after the subscription version is created.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;121&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. 
        /// </summary>
        /// <value>The snapshot ID of the subscription&#39;s bill-to contact. The snapshot ID will not change after the subscription version is created.  **Note:** This field is only available if you set the &#x60;X-Zuora-WSDL-Version&#x60; header parameter to &#x60;121&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. </value>
        [DataMember(Name = "SubscriptionBillToSnapshotId", EmitDefaultValue = false)]
        public string SubscriptionBillToSnapshotId { get; set; }

        /// <summary>
        ///  The date when the subscription term ends, where the subscription ends at midnight the day before. For example, if the SubscriptionEndDate is 12/31/2016, the subscriptions ends at midnight (00:00:00 hours) on 12/30/2016. This date is the same as the term end date or the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription term ends, where the subscription ends at midnight the day before. For example, if the SubscriptionEndDate is 12/31/2016, the subscriptions ends at midnight (00:00:00 hours) on 12/30/2016. This date is the same as the term end date or the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name = "SubscriptionEndDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime SubscriptionEndDate { get; set; }

        /// <summary>
        ///  The date when the subscription term starts. This date is the same as the start date of the original term, which isn&#39;t necessarily the start date of the current or new term. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription term starts. This date is the same as the start date of the original term, which isn&#39;t necessarily the start date of the current or new term. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name = "SubscriptionStartDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime SubscriptionStartDate { get; set; }

        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term ends. If the subscription is evergreen, the TermEndDate value is null or is the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term ends. If the subscription is evergreen, the TermEndDate value is null or is the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name = "TermEndDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime TermEndDate { get; set; }

        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term begins. If this is a renewal subscription, then this date is different from the subscription start date. **Character limit**: 29 **Version notes**: - - 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term begins. If this is a renewal subscription, then this date is different from the subscription start date. **Character limit**: 29 **Version notes**: - - </value>
        [DataMember(Name = "TermStartDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime TermStartDate { get; set; }

        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if a subscription is termed or evergreen. **Character limit**: 9 **Values**: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60; 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if a subscription is termed or evergreen. **Character limit**: 9 **Values**: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60; </value>
        [DataMember(Name = "TermType", EmitDefaultValue = false)]
        public string TermType { get; set; }

        /// <summary>
        ///  The ID of the user who last updated the subscription. **Character limit:** 32 **Values: **automatically generated 
        /// </summary>
        /// <value> The ID of the user who last updated the subscription. **Character limit:** 32 **Values: **automatically generated </value>
        [DataMember(Name = "UpdatedById", EmitDefaultValue = false)]
        public string UpdatedById { get; set; }

        /// <summary>
        ///  The date when the subscription was last updated. **Character limit:** 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription was last updated. **Character limit:** 29 **Values**: automatically generated </value>
        [DataMember(Name = "UpdatedDate", EmitDefaultValue = false)]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        ///  The version number of the subscription. **Values**: automatically generated 
        /// </summary>
        /// <value> The version number of the subscription. **Values**: automatically generated </value>
        [DataMember(Name = "Version", EmitDefaultValue = false)]
        public int _Version { get; set; }

        /// <summary>
        /// The last booking date of the subscription object. This field is writable only when the subscription is newly created as a first version subscription. You can override the date value when creating a subscription through the Subscribe and Amend API or the subscription creation UI (non-Orders). Otherwise, the default value &#x60;today&#x60; is set per the user&#39;s timezone. The value of this field is as follows: * For a new subscription created by the [Subscribe and Amend APIs](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Migration_Guidance#Subscribe_and_Amend_APIs_to_Migrate), this field has the value of the subscription creation date. * For a subscription changed by an amendment, this field has the value of the amendment booking date. * For a subscription created or changed by an order, this field has the value of the order date. 
        /// </summary>
        /// <value>The last booking date of the subscription object. This field is writable only when the subscription is newly created as a first version subscription. You can override the date value when creating a subscription through the Subscribe and Amend API or the subscription creation UI (non-Orders). Otherwise, the default value &#x60;today&#x60; is set per the user&#39;s timezone. The value of this field is as follows: * For a new subscription created by the [Subscribe and Amend APIs](https://knowledgecenter.zuora.com/Billing/Subscriptions/Orders/Orders_Harmonization/Orders_Migration_Guidance#Subscribe_and_Amend_APIs_to_Migrate), this field has the value of the subscription creation date. * For a subscription changed by an amendment, this field has the value of the amendment booking date. * For a subscription created or changed by an order, this field has the value of the order date. </value>
        [DataMember(Name = "lastBookingDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime LastBookingDate { get; set; }

        /// <summary>
        /// The Bundle product structures from Zuora Quotes if you utilize Bundling in Salesforce. Do not change the value in this field. 
        /// </summary>
        /// <value>The Bundle product structures from Zuora Quotes if you utilize Bundling in Salesforce. Do not change the value in this field. </value>
        [DataMember(Name = "CpqBundleJsonId__QT", EmitDefaultValue = false)]
        public string CpqBundleJsonIdQT { get; set; }

        /// <summary>
        /// The closing date of the Opportunity. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. 
        /// </summary>
        /// <value>The closing date of the Opportunity. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. </value>
        [DataMember(Name = "OpportunityCloseDate__QT", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime OpportunityCloseDateQT { get; set; }

        /// <summary>
        /// The unique identifier of the Opportunity. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. 
        /// </summary>
        /// <value>The unique identifier of the Opportunity. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. </value>
        [DataMember(Name = "OpportunityName__QT", EmitDefaultValue = false)]
        public string OpportunityNameQT { get; set; }

        /// <summary>
        /// The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal or Churn. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. 
        /// </summary>
        /// <value>The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal or Churn. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. </value>
        [DataMember(Name = "QuoteBusinessType__QT", EmitDefaultValue = false)]
        public string QuoteBusinessTypeQT { get; set; }

        /// <summary>
        /// The unique identifier of the Quote. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. 
        /// </summary>
        /// <value>The unique identifier of the Quote. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. </value>
        [DataMember(Name = "QuoteNumber__QT", EmitDefaultValue = false)]
        public string QuoteNumberQT { get; set; }

        /// <summary>
        /// The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. 
        /// </summary>
        /// <value>The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is used in Zuora data sources to report on Subscription metrics. If the subscription originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. </value>
        [DataMember(Name = "QuoteType__QT", EmitDefaultValue = false)]
        public string QuoteTypeQT { get; set; }

        /// <summary>
        /// ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationId__NS", EmitDefaultValue = false)]
        public string IntegrationIdNS { get; set; }

        /// <summary>
        /// Status of the subscription&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Status of the subscription&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationStatus__NS", EmitDefaultValue = false)]
        public string IntegrationStatusNS { get; set; }

        /// <summary>
        /// The NetSuite project that the subscription was created from. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>The NetSuite project that the subscription was created from. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "Project__NS", EmitDefaultValue = false)]
        public string ProjectNS { get; set; }

        /// <summary>
        /// The NetSuite sales order than the subscription was created from. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>The NetSuite sales order than the subscription was created from. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "SalesOrder__NS", EmitDefaultValue = false)]
        public string SalesOrderNS { get; set; }

        /// <summary>
        /// Date when the subscription was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Date when the subscription was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "SyncDate__NS", EmitDefaultValue = false)]
        public string SyncDateNS { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProxyGetSubscription {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AutoRenew: ").Append(AutoRenew).Append("\n");
            sb.Append("  CancelledDate: ").Append(CancelledDate).Append("\n");
            sb.Append("  ContractAcceptanceDate: ").Append(ContractAcceptanceDate).Append("\n");
            sb.Append("  ContractEffectiveDate: ").Append(ContractEffectiveDate).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CreatorAccountId: ").Append(CreatorAccountId).Append("\n");
            sb.Append("  CreatorInvoiceOwnerId: ").Append(CreatorInvoiceOwnerId).Append("\n");
            sb.Append("  CurrentTerm: ").Append(CurrentTerm).Append("\n");
            sb.Append("  CurrentTermPeriodType: ").Append(CurrentTermPeriodType).Append("\n");
            sb.Append("  ExternallyManagedBy: ").Append(ExternallyManagedBy).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InitialTerm: ").Append(InitialTerm).Append("\n");
            sb.Append("  InitialTermPeriodType: ").Append(InitialTermPeriodType).Append("\n");
            sb.Append("  InvoiceOwnerId: ").Append(InvoiceOwnerId).Append("\n");
            sb.Append("  IsInvoiceSeparate: ").Append(IsInvoiceSeparate).Append("\n");
            sb.Append("  IsLatestVersion: ").Append(IsLatestVersion).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  OriginalCreatedDate: ").Append(OriginalCreatedDate).Append("\n");
            sb.Append("  OriginalId: ").Append(OriginalId).Append("\n");
            sb.Append("  PaymentTerm: ").Append(PaymentTerm).Append("\n");
            sb.Append("  PreviousSubscriptionId: ").Append(PreviousSubscriptionId).Append("\n");
            sb.Append("  RenewalSetting: ").Append(RenewalSetting).Append("\n");
            sb.Append("  RenewalTerm: ").Append(RenewalTerm).Append("\n");
            sb.Append("  RenewalTermPeriodType: ").Append(RenewalTermPeriodType).Append("\n");
            sb.Append("  Revision: ").Append(Revision).Append("\n");
            sb.Append("  ServiceActivationDate: ").Append(ServiceActivationDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubscriptionBillToId: ").Append(SubscriptionBillToId).Append("\n");
            sb.Append("  SubscriptionBillToSnapshotId: ").Append(SubscriptionBillToSnapshotId).Append("\n");
            sb.Append("  SubscriptionEndDate: ").Append(SubscriptionEndDate).Append("\n");
            sb.Append("  SubscriptionStartDate: ").Append(SubscriptionStartDate).Append("\n");
            sb.Append("  TermEndDate: ").Append(TermEndDate).Append("\n");
            sb.Append("  TermStartDate: ").Append(TermStartDate).Append("\n");
            sb.Append("  TermType: ").Append(TermType).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  _Version: ").Append(_Version).Append("\n");
            sb.Append("  LastBookingDate: ").Append(LastBookingDate).Append("\n");
            sb.Append("  CpqBundleJsonIdQT: ").Append(CpqBundleJsonIdQT).Append("\n");
            sb.Append("  OpportunityCloseDateQT: ").Append(OpportunityCloseDateQT).Append("\n");
            sb.Append("  OpportunityNameQT: ").Append(OpportunityNameQT).Append("\n");
            sb.Append("  QuoteBusinessTypeQT: ").Append(QuoteBusinessTypeQT).Append("\n");
            sb.Append("  QuoteNumberQT: ").Append(QuoteNumberQT).Append("\n");
            sb.Append("  QuoteTypeQT: ").Append(QuoteTypeQT).Append("\n");
            sb.Append("  IntegrationIdNS: ").Append(IntegrationIdNS).Append("\n");
            sb.Append("  IntegrationStatusNS: ").Append(IntegrationStatusNS).Append("\n");
            sb.Append("  ProjectNS: ").Append(ProjectNS).Append("\n");
            sb.Append("  SalesOrderNS: ").Append(SalesOrderNS).Append("\n");
            sb.Append("  SyncDateNS: ").Append(SyncDateNS).Append("\n");
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
            return this.Equals(input as ProxyGetSubscription);
        }

        /// <summary>
        /// Returns true if ProxyGetSubscription instances are equal
        /// </summary>
        /// <param name="input">Instance of ProxyGetSubscription to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetSubscription input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
                ) && 
                (
                    this.AutoRenew == input.AutoRenew ||
                    this.AutoRenew.Equals(input.AutoRenew)
                ) && 
                (
                    this.CancelledDate == input.CancelledDate ||
                    (this.CancelledDate != null &&
                    this.CancelledDate.Equals(input.CancelledDate))
                ) && 
                (
                    this.ContractAcceptanceDate == input.ContractAcceptanceDate ||
                    (this.ContractAcceptanceDate != null &&
                    this.ContractAcceptanceDate.Equals(input.ContractAcceptanceDate))
                ) && 
                (
                    this.ContractEffectiveDate == input.ContractEffectiveDate ||
                    (this.ContractEffectiveDate != null &&
                    this.ContractEffectiveDate.Equals(input.ContractEffectiveDate))
                ) && 
                (
                    this.CreatedById == input.CreatedById ||
                    (this.CreatedById != null &&
                    this.CreatedById.Equals(input.CreatedById))
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.CreatorAccountId == input.CreatorAccountId ||
                    (this.CreatorAccountId != null &&
                    this.CreatorAccountId.Equals(input.CreatorAccountId))
                ) && 
                (
                    this.CreatorInvoiceOwnerId == input.CreatorInvoiceOwnerId ||
                    (this.CreatorInvoiceOwnerId != null &&
                    this.CreatorInvoiceOwnerId.Equals(input.CreatorInvoiceOwnerId))
                ) && 
                (
                    this.CurrentTerm == input.CurrentTerm ||
                    this.CurrentTerm.Equals(input.CurrentTerm)
                ) && 
                (
                    this.CurrentTermPeriodType == input.CurrentTermPeriodType ||
                    (this.CurrentTermPeriodType != null &&
                    this.CurrentTermPeriodType.Equals(input.CurrentTermPeriodType))
                ) && 
                (
                    this.ExternallyManagedBy == input.ExternallyManagedBy ||
                    this.ExternallyManagedBy.Equals(input.ExternallyManagedBy)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.InitialTerm == input.InitialTerm ||
                    this.InitialTerm.Equals(input.InitialTerm)
                ) && 
                (
                    this.InitialTermPeriodType == input.InitialTermPeriodType ||
                    (this.InitialTermPeriodType != null &&
                    this.InitialTermPeriodType.Equals(input.InitialTermPeriodType))
                ) && 
                (
                    this.InvoiceOwnerId == input.InvoiceOwnerId ||
                    (this.InvoiceOwnerId != null &&
                    this.InvoiceOwnerId.Equals(input.InvoiceOwnerId))
                ) && 
                (
                    this.IsInvoiceSeparate == input.IsInvoiceSeparate ||
                    this.IsInvoiceSeparate.Equals(input.IsInvoiceSeparate)
                ) && 
                (
                    this.IsLatestVersion == input.IsLatestVersion ||
                    this.IsLatestVersion.Equals(input.IsLatestVersion)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Notes == input.Notes ||
                    (this.Notes != null &&
                    this.Notes.Equals(input.Notes))
                ) && 
                (
                    this.OriginalCreatedDate == input.OriginalCreatedDate ||
                    (this.OriginalCreatedDate != null &&
                    this.OriginalCreatedDate.Equals(input.OriginalCreatedDate))
                ) && 
                (
                    this.OriginalId == input.OriginalId ||
                    (this.OriginalId != null &&
                    this.OriginalId.Equals(input.OriginalId))
                ) && 
                (
                    this.PaymentTerm == input.PaymentTerm ||
                    (this.PaymentTerm != null &&
                    this.PaymentTerm.Equals(input.PaymentTerm))
                ) && 
                (
                    this.PreviousSubscriptionId == input.PreviousSubscriptionId ||
                    (this.PreviousSubscriptionId != null &&
                    this.PreviousSubscriptionId.Equals(input.PreviousSubscriptionId))
                ) && 
                (
                    this.RenewalSetting == input.RenewalSetting ||
                    (this.RenewalSetting != null &&
                    this.RenewalSetting.Equals(input.RenewalSetting))
                ) && 
                (
                    this.RenewalTerm == input.RenewalTerm ||
                    this.RenewalTerm.Equals(input.RenewalTerm)
                ) && 
                (
                    this.RenewalTermPeriodType == input.RenewalTermPeriodType ||
                    (this.RenewalTermPeriodType != null &&
                    this.RenewalTermPeriodType.Equals(input.RenewalTermPeriodType))
                ) && 
                (
                    this.Revision == input.Revision ||
                    (this.Revision != null &&
                    this.Revision.Equals(input.Revision))
                ) && 
                (
                    this.ServiceActivationDate == input.ServiceActivationDate ||
                    (this.ServiceActivationDate != null &&
                    this.ServiceActivationDate.Equals(input.ServiceActivationDate))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.SubscriptionBillToId == input.SubscriptionBillToId ||
                    (this.SubscriptionBillToId != null &&
                    this.SubscriptionBillToId.Equals(input.SubscriptionBillToId))
                ) && 
                (
                    this.SubscriptionBillToSnapshotId == input.SubscriptionBillToSnapshotId ||
                    (this.SubscriptionBillToSnapshotId != null &&
                    this.SubscriptionBillToSnapshotId.Equals(input.SubscriptionBillToSnapshotId))
                ) && 
                (
                    this.SubscriptionEndDate == input.SubscriptionEndDate ||
                    (this.SubscriptionEndDate != null &&
                    this.SubscriptionEndDate.Equals(input.SubscriptionEndDate))
                ) && 
                (
                    this.SubscriptionStartDate == input.SubscriptionStartDate ||
                    (this.SubscriptionStartDate != null &&
                    this.SubscriptionStartDate.Equals(input.SubscriptionStartDate))
                ) && 
                (
                    this.TermEndDate == input.TermEndDate ||
                    (this.TermEndDate != null &&
                    this.TermEndDate.Equals(input.TermEndDate))
                ) && 
                (
                    this.TermStartDate == input.TermStartDate ||
                    (this.TermStartDate != null &&
                    this.TermStartDate.Equals(input.TermStartDate))
                ) && 
                (
                    this.TermType == input.TermType ||
                    (this.TermType != null &&
                    this.TermType.Equals(input.TermType))
                ) && 
                (
                    this.UpdatedById == input.UpdatedById ||
                    (this.UpdatedById != null &&
                    this.UpdatedById.Equals(input.UpdatedById))
                ) && 
                (
                    this.UpdatedDate == input.UpdatedDate ||
                    (this.UpdatedDate != null &&
                    this.UpdatedDate.Equals(input.UpdatedDate))
                ) && 
                (
                    this._Version == input._Version ||
                    this._Version.Equals(input._Version)
                ) && 
                (
                    this.LastBookingDate == input.LastBookingDate ||
                    (this.LastBookingDate != null &&
                    this.LastBookingDate.Equals(input.LastBookingDate))
                ) && 
                (
                    this.CpqBundleJsonIdQT == input.CpqBundleJsonIdQT ||
                    (this.CpqBundleJsonIdQT != null &&
                    this.CpqBundleJsonIdQT.Equals(input.CpqBundleJsonIdQT))
                ) && 
                (
                    this.OpportunityCloseDateQT == input.OpportunityCloseDateQT ||
                    (this.OpportunityCloseDateQT != null &&
                    this.OpportunityCloseDateQT.Equals(input.OpportunityCloseDateQT))
                ) && 
                (
                    this.OpportunityNameQT == input.OpportunityNameQT ||
                    (this.OpportunityNameQT != null &&
                    this.OpportunityNameQT.Equals(input.OpportunityNameQT))
                ) && 
                (
                    this.QuoteBusinessTypeQT == input.QuoteBusinessTypeQT ||
                    (this.QuoteBusinessTypeQT != null &&
                    this.QuoteBusinessTypeQT.Equals(input.QuoteBusinessTypeQT))
                ) && 
                (
                    this.QuoteNumberQT == input.QuoteNumberQT ||
                    (this.QuoteNumberQT != null &&
                    this.QuoteNumberQT.Equals(input.QuoteNumberQT))
                ) && 
                (
                    this.QuoteTypeQT == input.QuoteTypeQT ||
                    (this.QuoteTypeQT != null &&
                    this.QuoteTypeQT.Equals(input.QuoteTypeQT))
                ) && 
                (
                    this.IntegrationIdNS == input.IntegrationIdNS ||
                    (this.IntegrationIdNS != null &&
                    this.IntegrationIdNS.Equals(input.IntegrationIdNS))
                ) && 
                (
                    this.IntegrationStatusNS == input.IntegrationStatusNS ||
                    (this.IntegrationStatusNS != null &&
                    this.IntegrationStatusNS.Equals(input.IntegrationStatusNS))
                ) && 
                (
                    this.ProjectNS == input.ProjectNS ||
                    (this.ProjectNS != null &&
                    this.ProjectNS.Equals(input.ProjectNS))
                ) && 
                (
                    this.SalesOrderNS == input.SalesOrderNS ||
                    (this.SalesOrderNS != null &&
                    this.SalesOrderNS.Equals(input.SalesOrderNS))
                ) && 
                (
                    this.SyncDateNS == input.SyncDateNS ||
                    (this.SyncDateNS != null &&
                    this.SyncDateNS.Equals(input.SyncDateNS))
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
                if (this.AccountId != null)
                {
                    hashCode = (hashCode * 59) + this.AccountId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.AutoRenew.GetHashCode();
                if (this.CancelledDate != null)
                {
                    hashCode = (hashCode * 59) + this.CancelledDate.GetHashCode();
                }
                if (this.ContractAcceptanceDate != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAcceptanceDate.GetHashCode();
                }
                if (this.ContractEffectiveDate != null)
                {
                    hashCode = (hashCode * 59) + this.ContractEffectiveDate.GetHashCode();
                }
                if (this.CreatedById != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedById.GetHashCode();
                }
                if (this.CreatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedDate.GetHashCode();
                }
                if (this.CreatorAccountId != null)
                {
                    hashCode = (hashCode * 59) + this.CreatorAccountId.GetHashCode();
                }
                if (this.CreatorInvoiceOwnerId != null)
                {
                    hashCode = (hashCode * 59) + this.CreatorInvoiceOwnerId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CurrentTerm.GetHashCode();
                if (this.CurrentTermPeriodType != null)
                {
                    hashCode = (hashCode * 59) + this.CurrentTermPeriodType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ExternallyManagedBy.GetHashCode();
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.InitialTerm.GetHashCode();
                if (this.InitialTermPeriodType != null)
                {
                    hashCode = (hashCode * 59) + this.InitialTermPeriodType.GetHashCode();
                }
                if (this.InvoiceOwnerId != null)
                {
                    hashCode = (hashCode * 59) + this.InvoiceOwnerId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsInvoiceSeparate.GetHashCode();
                hashCode = (hashCode * 59) + this.IsLatestVersion.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Notes != null)
                {
                    hashCode = (hashCode * 59) + this.Notes.GetHashCode();
                }
                if (this.OriginalCreatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.OriginalCreatedDate.GetHashCode();
                }
                if (this.OriginalId != null)
                {
                    hashCode = (hashCode * 59) + this.OriginalId.GetHashCode();
                }
                if (this.PaymentTerm != null)
                {
                    hashCode = (hashCode * 59) + this.PaymentTerm.GetHashCode();
                }
                if (this.PreviousSubscriptionId != null)
                {
                    hashCode = (hashCode * 59) + this.PreviousSubscriptionId.GetHashCode();
                }
                if (this.RenewalSetting != null)
                {
                    hashCode = (hashCode * 59) + this.RenewalSetting.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RenewalTerm.GetHashCode();
                if (this.RenewalTermPeriodType != null)
                {
                    hashCode = (hashCode * 59) + this.RenewalTermPeriodType.GetHashCode();
                }
                if (this.Revision != null)
                {
                    hashCode = (hashCode * 59) + this.Revision.GetHashCode();
                }
                if (this.ServiceActivationDate != null)
                {
                    hashCode = (hashCode * 59) + this.ServiceActivationDate.GetHashCode();
                }
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
                if (this.SubscriptionBillToId != null)
                {
                    hashCode = (hashCode * 59) + this.SubscriptionBillToId.GetHashCode();
                }
                if (this.SubscriptionBillToSnapshotId != null)
                {
                    hashCode = (hashCode * 59) + this.SubscriptionBillToSnapshotId.GetHashCode();
                }
                if (this.SubscriptionEndDate != null)
                {
                    hashCode = (hashCode * 59) + this.SubscriptionEndDate.GetHashCode();
                }
                if (this.SubscriptionStartDate != null)
                {
                    hashCode = (hashCode * 59) + this.SubscriptionStartDate.GetHashCode();
                }
                if (this.TermEndDate != null)
                {
                    hashCode = (hashCode * 59) + this.TermEndDate.GetHashCode();
                }
                if (this.TermStartDate != null)
                {
                    hashCode = (hashCode * 59) + this.TermStartDate.GetHashCode();
                }
                if (this.TermType != null)
                {
                    hashCode = (hashCode * 59) + this.TermType.GetHashCode();
                }
                if (this.UpdatedById != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedById.GetHashCode();
                }
                if (this.UpdatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this._Version.GetHashCode();
                if (this.LastBookingDate != null)
                {
                    hashCode = (hashCode * 59) + this.LastBookingDate.GetHashCode();
                }
                if (this.CpqBundleJsonIdQT != null)
                {
                    hashCode = (hashCode * 59) + this.CpqBundleJsonIdQT.GetHashCode();
                }
                if (this.OpportunityCloseDateQT != null)
                {
                    hashCode = (hashCode * 59) + this.OpportunityCloseDateQT.GetHashCode();
                }
                if (this.OpportunityNameQT != null)
                {
                    hashCode = (hashCode * 59) + this.OpportunityNameQT.GetHashCode();
                }
                if (this.QuoteBusinessTypeQT != null)
                {
                    hashCode = (hashCode * 59) + this.QuoteBusinessTypeQT.GetHashCode();
                }
                if (this.QuoteNumberQT != null)
                {
                    hashCode = (hashCode * 59) + this.QuoteNumberQT.GetHashCode();
                }
                if (this.QuoteTypeQT != null)
                {
                    hashCode = (hashCode * 59) + this.QuoteTypeQT.GetHashCode();
                }
                if (this.IntegrationIdNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationIdNS.GetHashCode();
                }
                if (this.IntegrationStatusNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationStatusNS.GetHashCode();
                }
                if (this.ProjectNS != null)
                {
                    hashCode = (hashCode * 59) + this.ProjectNS.GetHashCode();
                }
                if (this.SalesOrderNS != null)
                {
                    hashCode = (hashCode * 59) + this.SalesOrderNS.GetHashCode();
                }
                if (this.SyncDateNS != null)
                {
                    hashCode = (hashCode * 59) + this.SyncDateNS.GetHashCode();
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
            // CpqBundleJsonIdQT (string) maxLength
            if (this.CpqBundleJsonIdQT != null && this.CpqBundleJsonIdQT.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CpqBundleJsonIdQT, length must be less than 32.", new [] { "CpqBundleJsonIdQT" });
            }

            // OpportunityNameQT (string) maxLength
            if (this.OpportunityNameQT != null && this.OpportunityNameQT.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OpportunityNameQT, length must be less than 100.", new [] { "OpportunityNameQT" });
            }

            // QuoteBusinessTypeQT (string) maxLength
            if (this.QuoteBusinessTypeQT != null && this.QuoteBusinessTypeQT.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for QuoteBusinessTypeQT, length must be less than 32.", new [] { "QuoteBusinessTypeQT" });
            }

            // QuoteNumberQT (string) maxLength
            if (this.QuoteNumberQT != null && this.QuoteNumberQT.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for QuoteNumberQT, length must be less than 32.", new [] { "QuoteNumberQT" });
            }

            // QuoteTypeQT (string) maxLength
            if (this.QuoteTypeQT != null && this.QuoteTypeQT.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for QuoteTypeQT, length must be less than 32.", new [] { "QuoteTypeQT" });
            }

            // IntegrationIdNS (string) maxLength
            if (this.IntegrationIdNS != null && this.IntegrationIdNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for IntegrationIdNS, length must be less than 255.", new [] { "IntegrationIdNS" });
            }

            // IntegrationStatusNS (string) maxLength
            if (this.IntegrationStatusNS != null && this.IntegrationStatusNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for IntegrationStatusNS, length must be less than 255.", new [] { "IntegrationStatusNS" });
            }

            // ProjectNS (string) maxLength
            if (this.ProjectNS != null && this.ProjectNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ProjectNS, length must be less than 255.", new [] { "ProjectNS" });
            }

            // SalesOrderNS (string) maxLength
            if (this.SalesOrderNS != null && this.SalesOrderNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SalesOrderNS, length must be less than 255.", new [] { "SalesOrderNS" });
            }

            // SyncDateNS (string) maxLength
            if (this.SyncDateNS != null && this.SyncDateNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SyncDateNS, length must be less than 255.", new [] { "SyncDateNS" });
            }

            yield break;
        }
    }

}
