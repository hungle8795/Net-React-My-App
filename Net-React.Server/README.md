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