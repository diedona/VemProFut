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
