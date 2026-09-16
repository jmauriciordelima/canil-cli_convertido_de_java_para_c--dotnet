# 🐕 Sistema de Gerenciamento de Canil

Sistema desenvolvido em **C# / .NET 8** para gerenciamento de um canil via terminal.
Projeto construído com foco em **Orientação a Objetos** e **arquitetura em camadas**,
aplicando boas práticas de design de software desde a concepção.

> Conversão do projeto original escrito em **Java puro** para **.NET / C#**.

---

## 📋 Funcionalidades

| Opção | Funcionalidade |
|-------|----------------|
| `[1]` | Adicionar cachorro (com validação de entrada) |
| `[2]` | Listar todos os cachorros |
| `[3]` | Buscar cachorro por nome |
| `[4]` | Remover cachorro |
| `[5]` | Registrar aniversário (incrementa idade) |
| `[6]` | Exibir estatísticas do canil |
| `[7]` | Filtrar cachorros por fase da vida |
| `[8]` | Identificar cachorro mais velho e mais novo |
| `[9]` | Salvar dados em arquivo |
| `[0]` | Sair (com opção de salvar) |

---

## 🏗️ Arquitetura

O projeto foi estruturado em camadas com responsabilidades bem definidas:

```
src/
└── ProjetoCanil/
    ├── Modelo/
    │   ├── Animal.cs              # Classe base abstrata
    │   ├── Cachorro.cs            # Entidade de negócio
    │   ├── Gato.cs                # Entidade de negócio
    │   ├── FaseVida.cs            # Enum de classificação etária
    │   ├── Adotavel.cs            # Interface IAdotavel (método default)
    │   └── Vacinavel.cs           # Interface IVacinavel
    │
    ├── Repositorio/
    │   └── CanilRepository.cs     # Persistência e acesso a dados
    │
    ├── Servico/
    │   └── CanilService.cs        # Regras de negócio e estatísticas
    │
    ├── Util/
    │   └── MenuUtil.cs            # Interface e formatação visual
    │
    ├── Testes/
    │   └── PolimorfismoTest.cs    # Demonstração de polimorfismo/interfaces
    │
    └── Program.cs                 # Ponto de entrada e orquestração
```

### Fluxo de comunicação entre camadas:

```
Program (orquestrador)
  ├── MenuUtil        → exibição de menus e mensagens
  ├── CanilRepository → operações CRUD e persistência
  └── CanilService    → estatísticas e regras de negócio
        └── usa CanilRepository internamente
```

---

## 🛠️ Tecnologias e Conceitos Aplicados

**Linguagem:** C# 12 / .NET 8

**Orientação a Objetos:**
- Encapsulamento via properties, campos `private` e métodos de acesso
- Múltiplos construtores com sobrecarga e encadeamento via `: base(...)`
- Membros de instância e métodos auxiliares privados
- Separação de responsabilidades entre classes
- Enum (`FaseVida`) para type safety na classificação etária
- Interfaces (`IAdotavel`, `IVacinavel`) com método default (`ProcessoAdocao`)
- Sobrescrita de `ToString()`, `Equals()` e `GetHashCode()`
- Identidade de objetos baseada em ID único sequencial

**Gerenciamento de ID:**
- ID sequencial gerado e controlado pelo `CanilRepository`
- Persistência do contador entre execuções via leitura do arquivo
- Garantia de unicidade sem reaproveitamento de IDs removidos

**.NET I/O:**
- `StreamWriter` para escrita
- `StreamReader` para leitura
- `using` declarations para liberação automática de recursos

**Coleções:**
- `List<Cachorro>` para armazenamento em memória
- Algoritmos de busca de máximo/mínimo em coleções de objetos
- Filtragem de listas por critério com type safety via Enum

**Tratamento de Erros:**
- `try-catch` com `FormatException` para validação de entrada numérica
- `IOException` para operações de arquivo

---

## ▶️ Como Executar

**Pré-requisitos:** .NET SDK 8.0 ou superior instalado.

```bash
# Clone o repositório
git clone <url-do-repositorio>

# Navegue até o diretório
cd projeto-canil

# Restaure as dependências
dotnet restore

# Compile
dotnet build

# Execute o menu principal
dotnet run --project src/ProjetoCanil

# Execute a demonstração de polimorfismo
dotnet run --project src/ProjetoCanil -- polimorfismo
```

> **Nota:** Na primeira execução, o arquivo `canil.txt` será criado automaticamente
> no diretório de trabalho ao salvar dados. Nas execuções seguintes, os dados são
> carregados automaticamente ao iniciar.

---

## 📊 Exemplo de Uso

```
╔════════════════════════════════╗
║    SISTEMA DE CANIL - MENU     ║
╠════════════════════════════════╣
║ [1] Adicionar Cachorro         ║
║ [2] Listar Todos os Cachorros  ║
...
╚════════════════════════════════╝

→ 6

╔════════════════════════════════╗
║     ESTATÍSTICAS DO CANIL      ║
╚════════════════════════════════╝
TOTAL DE CACHORROS: 3
IDADE MÉDIA: 4.7
MAIS VELHO: MAX (12 ANOS)
MAIS NOVO: BOB (1 ANO)
FILHOTES: 1
ADULTOS: 1
IDOSOS: 1
```

---

## 📁 Formato do Arquivo de Persistência

Os dados são salvos em `canil.txt` com o seguinte formato CSV:

```
1;REX;LABRADOR;3;
2;BOB;POODLE;5;
3;MAX;VIRA-LATA;12;
```

Campos: `id;nome;raca;idade`

> O ID é sequencial e persistido entre execuções. Ao reiniciar o programa,
> o sistema identifica o maior ID existente e continua a sequência a partir dele.

---

## 🎓 Contexto de Desenvolvimento

Este projeto foi originalmente desenvolvido como parte de uma **jornada de aprendizado em Java**
e posteriormente portado para **C# / .NET**, cobrindo os seguintes marcos:

- Fundamentos de programação (loops, condicionais, entrada de dados)
- Coleções e algoritmos de manipulação de listas
- Programação Orientada a Objetos do zero ao avançado
- Enum e type safety
- Interfaces e polimorfismo
- Sobrescrita de `ToString()`, `Equals()` e `GetHashCode()`
- Gerenciamento de identidade de objetos com ID sequencial
- Arquitetura em camadas e separação de responsabilidades
- Persistência de dados com File I/O
- Tratamento de exceções
- Boas práticas: Clean Code, XML Doc, encapsulamento, nomenclatura

O sistema evoluiu incrementalmente ao longo do processo, com cada funcionalidade
sendo implementada, revisada e refatorada — refletindo o ciclo real de desenvolvimento
de software profissional.

---

## 🔄 Notas da Conversão Java → C#

| Java                         | C# / .NET                          |
|------------------------------|------------------------------------|
| Pacote `Bpoo.projeto_canil`  | Namespace `ProjetoCanil.*`         |
| Classe `Main`                | Classe `Program` (método `Main`)   |
| Getters/Setters              | Properties (`get`/`set`)           |
| `Adotavel` / `Vacinavel`     | `IAdotavel` / `IVacinavel`         |
| Enum `FILHOTE`               | Enum `FaseVida.Filhote` (exibido em maiúsculas) |
| `ArrayList<T>`               | `List<T>`                          |
| `FileWriter` / `FileReader`  | `StreamWriter` / `StreamReader`    |
| `NumberFormatException`      | `FormatException`                  |
| `equals()` / `hashCode()`    | `Equals()` / `GetHashCode()`       |
| `toString()`                 | `ToString()`                       |
| Método `default` na interface| Método default de interface (C# 8+)|

A demonstração de polimorfismo, antes um `main` separado (`PolimorfismoTest`),
agora é executada via argumento de linha de comando:

```bash
dotnet run --project src/ProjetoCanil -- polimorfismo
```

---

## 👨‍💻 Autor

José Maurício
Desenvolvedor Java em formação

🔗 [GitHub](https://github.com/jmauriciordelima/jornadaFullStackComJava_e_LevelUp/tree/main/src/Bpoo/projeto_canil)

🔗 [LinkedIn](https://www.linkedin.com/in/jmauriciorlima/)