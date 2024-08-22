## GUIDLINE
### Install the JwtBearer NuGet Package
PM> Install-Package Microsoft.AspNetCore.Authentication.JwtBearer

## Specify a Secret Key in the appsettings.json file
Add the following information in the appettings.json file.
appsettings.json
 "JwtSettings": {
    "SigningKey": "YouSecreteKeyforAuthenticationtovalidateApplication",
    "Issuer": "AuthBasicAPI",
    "Audiences": [ "Swagger-Client" ]
  },

## Dependencies <a name="backend-dependencies"></a> 
- AutoMapper version 12.0.1
- AutoMapper.Extensions.Microsoft.DependencyInjection version 12.0.1
- BCrypt.Net-Next version 4.0.3
- Microsoft.AspNetCore.Authentication.JwtBearer version 7.0.8