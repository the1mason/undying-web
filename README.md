# UndyingWorld Web Services

## Requirements

Minecraft server with following plugins installed:
- AuthMe [5.6.0]
- GamePoints [1.3.1]
- LuckPerms [5.4.41]
- AdvancedBan [2.3.0]
- Rcon access to the server

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

Yaml example:

```yaml
  JWT:
    Key: "817WPyDF3t8VhJzbn58puu8tOSurDIul3Ei8YF3g0e1YyCs7E0bZ4BHLQh93JvzkhFPdCa2IgtypQnVd0CtfH1lZOWq4MiqervMN"
    Issuer: "https://superserver.org"
    Audience: "superserver.org"
    ValidateIssuer: true
    ValidateAudience: true
    ValidateLifetime: true
    ValidateIssuerSigningKey: true
  ConnectionStrings: 
    MySQL: "server=db.example.com;database=minecraft;uid=username;pwd=secret420!"
    Rcon: "mc.example.com:25575:superSecret1337!"
```