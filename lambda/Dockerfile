
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim as build
COPY . .
WORKDIR test/lambda.Tests
RUN dotnet test

