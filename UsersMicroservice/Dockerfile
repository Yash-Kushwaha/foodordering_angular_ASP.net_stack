FROM mcr.microsoft.com/dotnet/sdk:3.1 as buildStage
WORKDIR /app
COPY *.csproj ./
ENV APIGATEWAY "../API gateway"
COPY *.csproj ${APIGATEWAY}
ENV ORDER "../OrderFood web API"
COPY *.csproj ${ORDER}
COPY *.csproj ../PromotionCode
COPY *.csproj ../RestaurantAPI
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /deploy
COPY --from=buildStage /app/out .
ENTRYPOINT ["dotnet", "UsersMicroservice.dll"]