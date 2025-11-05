# Design vs. Architecture

Design foca nas decisões de baixo nível que estruturam classes, interfaces e interações dentro de um módulo. Arquitetura, por sua vez, trata do arranjo de alto nível entre componentes, serviços e limites do sistema. Nesta coleção de exemplos a ênfase está no **design**: exploramos padrões que resolvem problemas recorrentes no código e demonstram como pequenas escolhas de modelagem impactam a flexibilidade e a manutenção sem necessariamente redesenhar toda a arquitetura.

## Estrutura de Pastas
| Pasta | Tipo | Descrição |
| --- | --- | --- |
| `Decorator/` | .NET Console | Exemplo do padrão Decorator envolvendo composição de responsabilidades em runtime. |
| `FactoryAndAbstractFactory/` | .NET Console | Demonstra criação de objetos com Factory Method e Abstract Factory. |
| `Observer/` | .NET Console | Implementação do padrão Observer com sujeitos e observadores separados. |
| `Strategy/` | .NET Console | Estratégias intercambiáveis para cálculo de impostos e planos. |
| `dependency-injection-console/` | .NET Console | Uso de Injeção de Dependência com `IServiceCollection`. |
| `DependecyInjectionTS/` | Node + TypeScript | Equivalente em TypeScript demonstrando DI orientada a contratos. |
| `DesignPatterns.sln` | Solution | Solução .NET que agrega os projetos C#. |

## Padrões Demonstrados
- **Decorator** (`Decorator/`): adiciona responsabilidades dinamicamente sem alterar classes existentes.
- **Factory Method & Abstract Factory** (`FactoryAndAbstractFactory/`): centraliza a criação de famílias de produtos relacionados.
- **Observer** (`Observer/`): propaga eventos do sujeito para diversos observadores acoplados de forma frouxa.
- **Strategy** (`Strategy/`): troca algoritmos em tempo de execução através de abstrações.
- **Dependency Injection** (`dependency-injection-console/` e `DependecyInjectionTS/`): enfatiza inversão de controle e construção flexível de dependências.

## Como Compilar e Executar os Exemplos
Todos os exemplos .NET são projetos de console individuais. Execute-os a partir da raiz do repositório:

```bash
# Compilar toda a solução (opcional)
dotnet build DesignPatterns.sln

# Executar cada exemplo individualmente
dotnet run --project Decorator/Decorator.csproj
dotnet run --project FactoryAndAbstractFactory/FactoryAndAbstractFactory.csproj
dotnet run --project Observer/Observer.csproj
dotnet run --project Strategy/Strategy.csproj
dotnet run --project dependency-injection-console/dependency-injection-console.csproj
```

Para o exemplo em TypeScript:

```bash
cd DependecyInjectionTS
npm install
npm run build
npm start
```

Cada comando `dotnet run` abre uma demonstração em console destacando o padrão correspondente e referenciando os diretórios descritos acima. O projeto TypeScript compila o código (`npm run build`) para `app.js` e executa a variação de injeção de dependência com `npm start`.

## SOLID Principles (Design Level)
- **Single Responsibility Principle**: reforçado ao separar estratégias, observadores e serviços em arquivos distintos.
- **Open/Closed Principle**: novas variações são adicionadas por extensão (novas classes decorator, estratégias etc.).
- **Liskov Substitution Principle**: interfaces compartilhadas garantem que substituições preservem contratos.
- **Interface Segregation Principle (ISP)**: cada exemplo prioriza interfaces específicas (por exemplo, `Observer/Interface` e `Strategy/BLL`), evitando clientes forçados a depender de membros que não utilizam. Este destaque é fundamental para manter componentes pequenos e coesos.
- **Dependency Inversion Principle**: implementado por construtores que recebem abstrações e pelo contêiner de DI.
