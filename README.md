# Running Nodejs Services in ASP.NET Core

### Introduction
ASP.NET Core continues to suprise developers in each release. Adding the ability to run Node Services is a great feature for developer who is already using node javascript. Here are some of the major benifits for having Node services in ASP.NET Core:
- Reuse your favorite node modules or libaries from server-side
- Server-side prerendering can speed up the page load time
- Support Webpack Dev Middleware
- Hot Module Replacement

Here is a real world scenario, if you have some javascript script code that produce HTML using a third party libary/framework, you can invoke nodeServices in ASP.NET Core to get the same output and return it back to the UI.

