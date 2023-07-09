FROM mcr.microsoft.com/dotnet/sdk:7.0 as bulid
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:7.0 as final
WORKDIR /app 
COPY --from=bulid /app/out ./
ENTRYPOINT [ "dotnet", "dockerWebApp.dll" ]