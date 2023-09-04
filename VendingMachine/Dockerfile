FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VendingMachine/VendingMachine.csproj", "VendingMachine/"]
RUN dotnet restore "VendingMachine/VendingMachine.csproj"
COPY . .
WORKDIR "/src/VendingMachine"
RUN dotnet build "VendingMachine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VendingMachine.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VendingMachine.dll"]
