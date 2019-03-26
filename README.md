# RabbitMQ Message Reader

[![Build Status](https://dev.azure.com/neryluc/RabbitMQ%20Message%20Reader/_apis/build/status/RabbitMQ%20Message%20Reader-ASP.NET%20Core-CI?branchName=master)](https://dev.azure.com/neryluc/RabbitMQ%20Message%20Reader/_build/results?buildId=10)

A simples RabbitMQ message reader in C#, that runs in a looper.

## Prerequisites

````
docker
````

## Run it

````
docker-compose up 
````

## Try it

1) Open localhost:15672
2) Go to Queues
3) Click on my_queue
4) Expande Publish Message
5) Type anything in the Payload box
6) Hit Publish Message
7) Check your running app in the terminal

## References

- https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
- https://medium.com/@rsdsantos/configurando-appsettings-json-em-aplica%C3%A7%C3%B5es-net-core-2-94eb4e035660
