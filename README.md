
# PHARMA EASE - 2024

O PharmaEase Totem é uma solução inovadora que simplifica a experiência de compra de medicamentos em farmácias. Através do uso do CPF do cliente, o totem oferece opções personalizadas com base no histórico de compras, fornece recomendações de medicamentos com base em sintomas e gera uma senha para o recepcionista, permitindo uma integração eficiente com o atendimento presencial.

## Índice

- [Explicação da Arquitetura](#explicação-da-arquitetura)
- [Design Patterns](#design-patterns)
- [Instruções](#instruções)
- [RESTful API: OpenFDA](#)
- [Testes Implementados](#testes-implementados)
- [Clean Code](#clean-code)
- [IA Generativa](#ia-generativa)
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

## OpenFDA

A OpenFDA é uma API do governo dos Estados Unidos que fornece acesso a dados abertos sobre medicamentos, dispositivos médicos e alimentos. Essa API permite que desenvolvedores e pesquisadores acessem informações detalhadas sobre produtos regulamentados pela FDA (Administração de Alimentos e Medicamentos dos EUA), incluindo informações de rotulagem, efeitos colaterais, histórico de aprovações e muito mais.

#### **Traduções**
Como explicamos acima A OpenFDA é uma API do governo dos Estados Unidos então suas respostas naturalmente serão em inglês, 
contudo, abaixo deixamos as traduções dos titulos das respostas json para facilitar o entendimento:

**"brandName"** = Nome da marca

**"purpose"** = Propósito do remédio

**"warnings"** = Avisos e precauções 

**"indications"** = Indicações para uso

**"activeIngredients"** = Ingredientes do remédio

## Testes Implementados

Implementamos testes unitários e de integração para garantir a confiabilidade e a consistência das principais funcionalidades da aplicação. Esses testes cobrem as classes de Clientes, Medicamentos e Recomendações, validando todas as operações CRUD (Create, Read, Update e Delete) em cada uma dessas entidades. Os testes verificam o comportamento correto dos serviços e a comunicação apropriada com os endpoints, ajudando a identificar possíveis problemas e garantindo uma integração eficaz entre os componentes.

#### **Rodando testes**

Para rodar os testes é simples. ao abrir o projeto no Visual Studio basta procurar a opção **"Teste"** e selecionar **"Executar Todos os Testes"** e após alguns segundos de espera será possível ver o resultado no lado direito da janela abaixo da legenda **"Resultados"**

## Clean Code

O projeto segue os princípios de **Clean Code** para garantir que o código seja legível, fácil de manter e intuitivo para outros desenvolvedores. As principais práticas implementadas incluem:

#### **Nomeação Clara**
As variáveis, métodos e classes possuem nomes descritivos e claros, o que facilita  o entendimento do propósito de cada componente sem necessidade de comentários extensos.
  
#### **Princípios SOLID**
Adotamos os princípios de SOLID para aprimorar a arquitetura do projeto e reduzir o acoplamento. Os princípios aplicados incluem:

  - **Single Responsibility Principle (SRP)**: Cada classe ou método possui uma única responsabilidade. Exemplo disso é a classe **MedicamentosService**, responsável exclusivamente por operações de negócios relacionadas a medicamentos.
  - **Open/Closed Principle (OCP)**: A estrutura permite a extensão das funcionalidades sem modificações em código existente, como nas recomendações baseadas em IA, onde novos algoritmos podem ser integrados sem alterar o core do sistema.
  - **Dependency Inversion Principle (DIP)**: Interfaces são utilizadas pra desacoplar dependências e facilitar a criação de testes, como no uso de **IRepository** em vez de implementar a lógica diretamente.

#### **Organização e Estrutura** 

O projeto é dividido em camadas diferentes, sendo elas:
 
- **API** (para a API)
- **Database** (para gerenciamento de dados)
- **ML** (para o machine learning) 
- **Repository** (para o repositório)
- **Services** (lógica de negócios)
- **Test** (para realizar os testes) 

Cada camada possui responsabilidade clara, facilitando a manutenção e testes.

## IA Generativa

Nosso projeto incorpora funcionalidades de IA generativa utilizando ML.NET para criar recomendações personalizadas de medicamentos com base no histórico de compras e sintomas dos clientes. Com um modelo de machine learning treinado para analisar dados de recomendações, o PharmaEase Totem oferece sugestões precisas e úteis para os clientes, aprimorando sua experiência de compra. A IA generativa foi integrada ao sistema de modo a permitir fácil atualização e treinamento do modelo, garantindo que as recomendações se mantenham relevantes e alinhadas com as preferências e necessidades dos clientes.

#### **Estrutura e Funcionamento do Sistema de Recomendação**
A estrutura de recomendação de produtos no projeto foi implementada na classe RecommendationEngine, responsável por treinar, prever e recomendar medicamentos para os clientes. Abaixo, detalhamos cada parte dessa implementação:

- **Coleta e Preparação de Dados**

  A classe **RecommendationEngine** recebe uma lista de recomendações passadas através do método TrainModel. Essas recomendações, representadas pela classe **Recomendacao**, contêm as interações de clientes com medicamentos, incluindo atributos como **IdCliente** e **IdMedicamento**.
  Para o treinamento, essas interações são convertidas em um conjunto de dados de classificações (ProductRating), que o ML.NET utiliza para entender as preferências dos clientes.

- **Pipeline**

  A partir dos dados coletados, um pipeline de treinamento é criado, utilizando Matrix Factorization para mapear as interações entre cliente e medicamento.

- **Predição**
  
  Após o treinamento, o modelo pode prever a afinidade entre um cliente e um medicamento específico usando o método Predict, que retorna uma pontuação (score) indicando o grau de relevância do medicamento para o cliente.

- **Persistência**
  
  Por fim, a classe **RecommendationEngine** permite salvar e carregar o modelo treinado. Isso evita o reprocessamento toda vez que a aplicação é reiniciada.

## Autores

- [Arthur Mitsuo Yamamoto - RM551283](https://github.com/ArthurMitsuoYamamoto)
- [Daniel dos Santos Araujo Faria - RM99067](https://github.com/DanielAraujoFaria)
- [Enzo Lafer Gallucci - RM551111](https://github.com/EnzoLafer)
- [Francineldo Luan Martins Alvelino - RM99558](https://github.com/FrancineldoLuan)
- [Ramon Cezarino Lopez - RM551279](https://github.com/RamonCezarinoLopez)
