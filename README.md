# VemProFut
This is a modular monolith experimentation. 

This project intends to use some concepts of _Feature Driven Development_, _Domain Driven Design_ and _Clean Architecture_.

## Api
It uses the minimal api approach in the "Endpoints" folder. It is grouped by feature.

## Domain
The heart of the software, mixing FDD and DDD. We still use some packages here - Such as Mediatr and Identity - because i am not a purist and i see it as a core part of the project.
Yes - we could abstract it away in a Shared Kernel, but in the end we would depend upon the said Kernel and i dont feel like the project need such abstraction right now.

## Infra
Concerns of implementation which i delegated away from the domain, such as DbContext, Token implementation and so on.

<hr />

# Docker and Dockercompose
To change docker ports on the container level, please edit the _launchSettings.json_ at the Docker node:
```
"Docker": {
  ... omitted ...
  "useSSL": true,
  "sslPort": 7111  // this is the port for running the docker container by itself
  ... omitted ...
}
```

If you want to change ports with docker compose, you need to edit the _docker-compose.override.yml_:
```
version: '3.4'

services:
  vemprofut.api:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081  // https container port in docker compose
    ... omitted ...
    ports:
      - "8080"
      - "7111:8081"  // setting up custom 7111 port to bind with https port of the container
```
