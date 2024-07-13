# Module 5 Self-check Questions

**What is the difference between authentication and authorization?**
Authentication is the process of verifying the identity of a user, device, or system. It often involves validating credentials like username and password. On the other hand, authorization is the process of granting the authenticated entity certain permissions within the system, i.e., what an authenticated user can do within the system.

**What authorization approaches can you list? What is role-based access control?**
There are several authorization approaches including:
1. Role-Based Access Control (RBAC)
2. Discretionary Access Control (DAC)
3. Mandatory Access Control (MAC)
4. Attribute-Based Access Control (ABAC)

Role-Based Access Control (RBAC) is a strategy where permissions are associated with roles, and users are assigned to these roles. Thus, obtaining the role’s permissions.

**What exactly is Identity Management (Identity and Access Management)?**
Identity Management, also known as Identity and Access Management (IAM), is a framework of policies and technologies that ensure the right individuals in an enterprise have access to the technology resources. IAM technology can be used to initiate, capture, record, and manage user identities and their related access permissions.

**What authentication/authorization protocols do you know? What is the difference between OAuth & OpenID?**
The widely used authentication/authorization protocols are LDAP, RADIUS, Kerberos, SAML, OAuth, and OpenID Connect. OAuth is a protocol that allows an application to authenticate against a server as a user, but with the user’s approval, whereas OpenID Connect is a protocol that allows a client to verify the identity of the user based on the authentication performed by an authorization server.

**What is Authentication/Authorization Token? What is JWT token? What other approaches except authentication/authorization, can we use with a security token?**
Authentication/Authorization tokens are a tool that can be used to authenticate a user, a machine, or a software. JSON Web Tokens (JWTs) are used to send information that can be verified and trusted with a digital signature. Aside from authentication and authorization, security tokens in JWT format can be used for information exchange due to the ability to carry JSON-based data.

**What is Single Sign-On (SSO)? Name the steps to implement SSO. What are the benefits of SSO?**
Single Sign-On (SSO) is an authentication service that permits a user to use one set of login credentials to access multiple applications. Steps to implement it may involve: set up Identity Provider, configure Service Provider, validate set up, and User Access. SSO benefits include better password management, improved user experience and productivity, and enhanced security and compliance.

**What is the difference between Two-Factor Authentication and Multi-Factor Authentication?**
Two-Factor Authentication (2FA) is a subset of Multi-Factor Authentication (MFA). While 2FA relies on two types of info for user identity confirmation (e.g., password and OTP), MFA can use two or more methods of authentication from independent categories of credentials.

**Which of the OAuth flows can be used for user (customer) and which for client (server) authentication?**
OAuth 2.0 provides several different "flows" suitable for different types of clients and scenarios - Authorization Code Flow (best for server-side apps), Implicit Flow (best for lightweight, browser-based apps), and Client Credentials Flow (best for server-to-server scenarios). PKCE (Proof Key for Code Exchange) is also utilized for mobile and desktop applications.