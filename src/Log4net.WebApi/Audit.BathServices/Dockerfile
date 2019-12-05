FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Audit.BathServices/Audit.BathServices.csproj", "Audit.BathServices/"]
RUN dotnet restore "Audit.BathServices/Audit.BathServices.csproj"
COPY . .
WORKDIR "/src/Audit.BathServices"
RUN dotnet build "Audit.BathServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Audit.BathServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Audit.BathServices.dll"]