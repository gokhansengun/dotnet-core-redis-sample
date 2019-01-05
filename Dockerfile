FROM microsoft/dotnet:2.2-sdk AS build-env

MAINTAINER Gokhan Sengun <gokhansengun@gmail.com>

RUN mkdir -p /app

## Copy the csproj files first in order to cache restore
COPY ./dotnet-core-redis.csproj     /app/

WORKDIR /app

RUN dotnet restore

COPY . /app/

RUN dotnet publish -c Release

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime-env

COPY --from=build-env /app/bin/Release/netcoreapp2.2/publish/ /usr/local/bin/

WORKDIR /usr/local/bin

ENTRYPOINT [ "dotnet", "dotnet-core-redis.dll" ]
