# RabbitMQIntegration

Install Rabbitmq docker file using the following command (Note- docker desktop is in running mode):

docker pull rabbitmq:3-management

Next, create a container and start using the Rabbitmq Dockerfile that we downloaded:

docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management
