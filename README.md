
# PHARMA EASE - 2024

O PharmaEase Totem é uma solução inovadora que simplifica a experiência de compra de medicamentos em farmácias. Através do uso do CPF do cliente, o totem oferece opções personalizadas com base no histórico de compras, fornece recomendações de medicamentos com base em sintomas e gera uma senha para o recepcionista, permitindo uma integração eficiente com o atendimento presencial.

## Índice

- [Explicação da Arquitetura](#explicação-da-arquitetura)
- [Design Patterns](#design-patterns)
- [Instruções](#instruções)
- [Autores](#autores)

## Explicação da Arquitetura

#### **Porque Microservices?**

Optamos por uma arquitetura de microservices por várias razões que consideramos fundamentais para o projeto. Primeiramente, a escalabilidade é uma grande vantagem, já que cada serviço pode ser escalado de forma independente, enquanto um monolito exigiria escalar o sistema todo, o que seria menos eficiente.

Além disso, a flexibilidade de manutenção e atualizações nos microservices é superior. Cada serviço pode ser atualizado ou corrigido individualmente, sem impactar os demais, garantindo maior agilidade. Essa arquitetura também permite que usemos tecnologias diferentes para cada serviço, escolhendo a melhor solução para cada funcionalidade.

#### **Quais as diferenças?**
_1. Estrutura_
- Monolítica: Todo o código está centralizado em uma única aplicação.
- Microservices: O sistema é dividido em vários serviços menores e independentes.

_2. Resiliência_
- Monolítica: Falhas em uma parte podem comprometer toda a aplicação.
- Microservices: Falhas são isoladas a um serviço, sem afetar o sistema inteiro.

_3. Desempenho_
- Monolítica: Pode ter desempenho limitado devido à interligação dos componentes.
- Microservices: A independência dos serviços permite otimização de recursos.
## Design Patterns

#### **Singleton**
O padrão Singleton garante que uma classe tenha apenas uma única instância em todo o sistema e fornece um ponto de acesso global a essa instância. Optamos por utilizar esse padrão em nosso projeto para situações onde é essencial que exista apenas uma instância de um objeto, como o gerenciamento de conexões de banco de dados ou controle de configurações globais.

A principal vantagem do Singleton é que ele evita a criação de múltiplas instâncias desnecessárias, o que economiza recursos e simplifica o gerenciamento de estados compartilhados entre diferentes partes do sistema.
## Instruções
Para rodar o nosso projeto, basta clonar o repositório, abrir a pasta PharmaEase-NET no Visual Studio e executar o projeto Pharmaease.API. Quando o projeto compilar e carregar, o site da documentação Swagger será aberto, permitindo que você teste nossa API de Clientes e Medicamentos, dois dos elementos mais importantes para o nosso totem.

Disponibilizamos os seguintes arquivos JSON para testar os endpoints. Sinta-se à vontade para modificar qualquer informação nos arquivos JSON, conforme desejar!
JSON exemplo para POST de Clientes:
```json
{
    "id": 1,
    "idCliente": 1,
    "nome": "John Doe",
    "cpf": "123456789",
    "dataCadastro": "2024-09-15T00:00:00Z",
    "dataCancelamento": null
}
```

JSON exemplo para POST de Medicamentos:
```json
{
  "id": 1,
  "idMedicamento": 1,
  "nomeMed": "Paracetamol",
  "codBarra": "7891234567890",
  "dataCadastro": "2024-09-16T21:17:02.527Z",
  "dataCancelamento": null,
  "fabricante": "Farmaceutica XYZ",
  "categoriaMed": "Analgésico",
  "dosagem": "500mg",
  "dataValidade": "2025-09-16T21:17:02.527Z",
  "descricao": "Uso para alívio de dores e febre.",
  "quantidadeUni": "20 comprimidos",
  "dimensaoMed": "5x10 mm"
}
```
## Autores

- [Arthur Mitsuo Yamamoto - RM551283](https://github.com/ArthurMitsuoYamamoto)
- [Daniel dos Santos Araujo Faria - RM99067](https://github.com/DanielAraujoFaria)
- [Enzo Lafer Gallucci - RM551111](https://github.com/EnzoLafer)
- [Francineldo Luan Martins Alvelino - RM99558](https://github.com/FrancineldoLuan)
- [Ramon Cezarino Lopez - RM551279](https://github.com/RamonCezarinoLopez)
