# SalesForceConnector
Portable SalesForce REST .NET library

The aim of this project is to provide a basic .NET solution to make SalesForce REST calls without using third party SDKs. The other objective was to make it perform well and be easy to add to any .NET application.

Although SalesForce provides an SDK to make REST calls, I though it would be interesting to make a native C# REST library. This project contains everything needed to integrate a .NET web application with a SalesForce deployment. 

The solution consists of three individual projects. 

The Common project holds classes representing standard SalesForce objects. Common also holds the serialization methods used to send and retrieve JSON strings.

The SalesForceConnector project contains a wrapper to do HTTP POST, GET, and PATCH calls. This project also has a performance optimization design. It has an interface with two implementations.
The Real implementation makes live calls to SalesForce. The Proxy implementation stores results from previous calls to SalesForce like a caching mechanism.
Together the Real and Proxy implementation switch off to provide fast object returns. 

There is a configuration module. The SalesForceConnector project also has a static configuration class which all of the components call to get the OAuth parameters needed for the REST calls.

Last, is the TestAppplication project. If the configuration class is initialized, this project will display the first 10 Accounts, Contacts, and Users from your SalesForce deployment.

