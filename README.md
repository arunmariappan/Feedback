# Feedback

## Technologies Used:-
- Front End
  - [ASP.NET MVC](https://dotnet.microsoft.com/en-us/apps/aspnet)
  - [Bootstrap v5](https://getbootstrap.com/)
  - [jQuery v3](https://jquery.com/)
  - [jQuery Validation](https://jqueryvalidation.org/)
  - [toastr v2](https://github.com/CodeSeven/toastr)
  - [jquery.mask v1.14.16](https://igorescobar.github.io/jQuery-Mask-Plugin/)
- Server Side
  - [.NET 8](https://dotnet.microsoft.com/en-us/download)
  - ASP.NET MVC Core
  - Entity Framework
  - [Serilog](https://serilog.net/)
- Data Source
  - SQL Server
- IDE
  - [Visual Studio 2022 Community Edition](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)
- Third-Party
  - [Jira - Bug tracking](https://www.atlassian.com/software/jira)
 
## Design Pattern
Unit of Work in Repository Pattern

## Validation
- Front-End form required field validation
- Model validation in Server side

## Security Implementation
- SQL Injection
- XSS (Cross-Site Scripting)
- Anti-Forgery Tokens
- Content Security Policy (CSP)

## Application Setup
1. Execute the **SQL Script\SQL_Script.sql** from the code repo, which will create **CustomerFeedback** database and **Feedbacks** table
2. Open the application **appsettings.json** file and change the ConnectionStrings:DefaultConnection according to you SQL Server details and login details

## Bug Tracking
For Bug tracking we are using Jira 30 days trial account(Personal account arunjai@gmail.com)

### Jira Setup and REST API
- To setup the Jira Issue tracking, sign-up and enable the 30 days trails. Once you completed the setup we will have our own domain for project issue tracking. Like https://arunjai.atlassian.net
- Generate the API token from https://id.atlassian.com/manage-profile/security/api-tokens
- In the application appsettings.json change the below keys
  - **"JiraBaseURL"**: "https://arunjai.atlassian.net" - Jira base url after enabling the 30 days trial
  - **"BasicAuthenticationUsername"**: "arunjai@gmail.com" - username used to signup the Jira account
  - **"BasicAuthenticationPassword"**: "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" - copy paste the API key gerated from https://id.atlassian.com/manage-profile/security/api-tokens
 
### Issue tracking in Jira
Once the user submitted the feedback, the data is saved in the Feedback table then we send the same feedback information to JIRA Rest API

Below we have the screenshot of my Jira Issue dashboard
![image](https://github.com/user-attachments/assets/cbafe46b-a809-48dc-90ae-11159cfe7ebe)


