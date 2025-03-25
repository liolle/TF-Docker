# SDK containing the CLI
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS sdk
# Image optimized to run ASP.NET Core apps 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS aspnet

FROM sdk AS build
ARG INVALIDATE_CACHE
COPY . ./src
RUN dotnet restore src
RUN dotnet publish -c release -o app --no-restore src 

FROM aspnet AS final 
ARG INVALIDATE_CACHE
WORKDIR /app
COPY --from=build ./app .
ENTRYPOINT ["dotnet", "blazor.dll"]
