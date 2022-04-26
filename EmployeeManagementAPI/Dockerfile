FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY EmployeeManagementAPI.csproj .
RUN dotnet restore "EmployeeManagementAPI.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "EmployeeManagementAPI.csproj" -c Release -o /publish

# Build runtime image
FROM base AS final
WORKDIR /app

COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EmployeeManagementAPI.dll"]