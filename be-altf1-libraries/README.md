# be-altf1-libraries
Libraries used by www.alt-f1.be during its software developments

# When to use the librarie?

## Name a directory uniquely based on the identity of the user using Office 365 credentials

URL: 
```
POST https://be-altf1-libraries.azurewebsites.net/api/microsoftgraph
```

INPUT: 
```json
{
"userIdentityName": "identity#belgium@altf1.be",
"userContainer": "identity#belgium@altf1.be"
}
```

OUTPUT: 
```json
{
"id":3,
"userIdentityName":"identity#belgium@altf1.be",
"userContainer":"identity-hsh-belgium-at-altf1-pnt-be"
}
```

# How to test the application

* http://localhost:65108/api/microsoftgraph
* http://localhost:65108/api/microsoftgraph/1
* http://localhost:65108/api/values

# Tools used to build the project 

* https://gitattributes.io (select visualStudio and CSharp)
* https://gitignore.io (select visualStudio and aspNetCore)

# Documentation

 * Create a Web API with ASP.NET Core and Visual Studio for Windows: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
