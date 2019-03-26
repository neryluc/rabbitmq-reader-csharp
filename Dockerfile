FROM mcr.microsoft.com/dotnet/core/sdk

WORKDIR rabbitmq-reader-loop/

COPY . ./

RUN chmod +x ./waitforit.sh

ENTRYPOINT ./waitforit.sh -h ${RabbitMQ__host} -p ${RabbitMQ_port} -t 60 -- dotnet run