# StorePay-Api-Compra-Aplicativos

API DE COMPRA DE APLICATIVOS
Desafio - Nivel 1

Requisitos de negócio
A API disponibiliza uma lista de aplicativos.
O cliente pode escolher comprar um aplicativo.
O cliente pode se cadastrar ou fazer login (se já tiver cadastro).
Os parâmetros de cadastro são: nome, cpf, data de nascimento, sexo, endereço completo.
O pagamento do aplicativo deve ser feito somente com cartão de crédito.
Cartão de crédito pode (opcional) ficar guardado para uso futuro.
O sistema só salva cartões que são válidos
Não precisa desenvolver a administração dos aplicativos.

Requisitos técnicos
As compras/transações devem ser processadas de modo assincrono, colocadas num serviço de fila.
Implementação de cache pra listagem dos aplicativos. (opcional).
Deve existir um serviço que busca as transações de cartão de crédito para processar da fila (sugiro utilizar o padrão Observer)
Tecnologias.
http://asp.net/web-api (em REST)
BD: SQL Server ou MongoDb
Fila: RabbitMQ ou Kafka
Serviço de consumer: Pode ser algo simples, como um console aplication em C# que lerá da fila e armazenará no banco de dados. (O pagamento pode ser aprovado de forma mockada)

O que esperamos ver do seu código?
Orientação a objeto, design pattern, princípios SOLID e visão arquitetural.
O código deve ser organizado, claro, intuitivo, fácil de ler e entender, seguindo convenções Microsoft.
Código deve ser versionado com git e hospedado no github.
Bons tratamentos de exceção, sendo que todas devem ser logadas.
