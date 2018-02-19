FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

COPY /src/HttpBin.Server/*.csproj ./
RUN dotnet restore

# copy everything else and build
COPY /src/HttpBin.Server/ ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS "http://*:5000"

LABEL proj="HttpBin.Server"
LABEL workname="aspnetcore-httpbin"

ENTRYPOINT ["dotnet", "HttpBin.Server.dll"]