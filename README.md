# UndyingWorld Web Services

## Requirements

Minecraft server with following plugins installed:
- AuthMe [5.6.0]
- GamePoints [1.3.1]
- LuckPerms [5.4.41]
- AdvancedBan [2.3.0]

Rcon access to the server

## Configuration

Change the following lines in appsettings.json or create a new appsettings.yml file to overriding it

```json
"JWT": {
    "Key": "jwt-key",
    "Issuer": "jwt-issuer",
    "Audience": "jwt-audience",
    "ValidateIssuer": false,
    "ValidateAudience": false,
    "ValidateLifetime": true,
    "ValidateIssuerSigningKey" : true
  },
  "ConnectionStrings": {
    "MySql": "mysql-connection-string",
    "Rcon": "address:port:password"
  }
```