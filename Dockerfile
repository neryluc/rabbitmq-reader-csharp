FROM mcr.microsoft.com/dotnet/core/sdk

WORKDIR rabbitmq-reader-loop/

COPY . ./

ENTRYPOINT dotnet run