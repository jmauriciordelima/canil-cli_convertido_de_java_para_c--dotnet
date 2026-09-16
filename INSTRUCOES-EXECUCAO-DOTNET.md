# Instruções de Execução - Projeto Canil (.NET / C#)

Este pacote contém o **Sistema de Gerenciamento de Canil** convertido de Java para **.NET 8 / C# 12**.

---

## 1. Pré-requisitos

Instale o **.NET SDK 8.0** (ou superior) no seu Ubuntu:

```bash
# Atualiza os índices de pacotes
sudo apt-get update

# Instala dependências necessárias
sudo apt-get install -y wget

# Baixa o instalador oficial do .NET
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

# Dá permissão de execução ao script
chmod +x dotnet-install.sh

# Instala o SDK 8.0 no diretório padrão do usuário
./dotnet-install.sh --channel 8.0
```

Adicione o .NET ao PATH (adicione estas linhas ao final do arquivo `~/.bashrc`):

```bash
export DOTNET_ROOT="$HOME/.dotnet"
export PATH="$PATH:$HOME/.dotnet"
```

Recarregue o shell e confirme a instalação:

```bash
source ~/.bashrc
dotnet --version
```

> Alternativa (repositório da Microsoft): siga https://learn.microsoft.com/dotnet/core/install/linux-ubuntu

---

## 2. Extrair o projeto

```bash
# Descompacta o arquivo
unzip projeto-canil-dotnet.zip

# Entra no diretório do projeto
cd projeto-canil
```

---

## 3. Compilar

```bash
# Restaura as dependências (não há pacotes externos, apenas o SDK)
dotnet restore

# Compila a solução
dotnet build
```

---

## 4. Executar

```bash
# Executa o menu principal do sistema
dotnet run --project src/ProjetoCanil
```

Para executar a **demonstração de polimorfismo**:

```bash
dotnet run --project src/ProjetoCanil -- polimorfismo
```

---

## 5. Uso do sistema (menu)

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

> Ao escolher a opção `[0]`, o sistema pergunta se deseja salvar antes de sair.

---

## 6. Persistência

- Os dados são salvos no arquivo `canil.txt`, criado automaticamente no **diretório de trabalho** onde o programa é executado.
- Formato CSV: `id;nome;raca;idade;`
- Ao iniciar, o sistema carrega automaticamente os dados existentes e continua a sequência de IDs.

Exemplo de conteúdo de `canil.txt`:

```text
1;REX;LABRADOR;3;
2;BOB;POODLE;5;
3;MAX;VIRA-LATA;12;
```

---

## 7. Estrutura do projeto

```text
projeto-canil/
├── ProjetoCanil.sln
├── README.md
├── TODO.md
├── INSTRUCOES-EXECUCAO-DOTNET.md
├── INSTRUCOESGUIADOPROJETO.md
├── .gitignore
├── legacy-java/                    # Código original em Java (apenas referência)
│   ├── Main.java
│   ├── modelo/
│   ├── repositorio/
│   ├── servico/
│   ├── util/
│   └── teste/
└── src/
    └── ProjetoCanil/
        ├── ProjetoCanil.csproj
        ├── Program.cs                  # Ponto de entrada
        ├── Modelo/
        │   ├── Animal.cs
        │   ├── Cachorro.cs
        │   ├── Gato.cs
        │   ├── FaseVida.cs
        │   ├── Adotavel.cs
        │   └── Vacinavel.cs
        ├── Repositorio/
        │   └── CanilRepository.cs
        ├── Servico/
        │   └── CanilService.cs
        ├── Util/
        │   └── MenuUtil.cs
        └── Testes/
            └── PolimorfismoTest.cs
```

---

## 8. Solução de problemas

**Erro: `dotnet: command not found`**
- Confirme que `$HOME/.dotnet` está no PATH (`echo $PATH`) e recarregue o shell com `source ~/.bashrc`.

**Erro: `Couldn't find a valid ICU package installed on the system`**
- Instale as dependências de globalização:
```bash
sudo apt-get install -y libicu-dev libssl-dev
```

**Acentos aparecem incorretos no terminal**
- O programa já configura `Console.OutputEncoding = Encoding.UTF8`. Garanta que o terminal use UTF-8 (padrão no Ubuntu).

---

## 9. Notas da conversão Java -> C#

| Java                          | C# / .NET                          |
|-------------------------------|------------------------------------|
| Pacote `Bpoo.projeto_canil`   | Namespace `ProjetoCanil.*`         |
| Classe `Main`                 | Classe `Program` (método `Main`)   |
| Getters/Setters               | Properties (`get`/`set`)           |
| `Adotavel` / `Vacinavel`      | `IAdotavel` / `IVacinavel`         |
| Enum `FILHOTE`                | Enum `FaseVida.Filhote`            |
| `ArrayList<T>`                | `List<T>`                          |
| `FileWriter` / `FileReader`   | `StreamWriter` / `StreamReader`    |
| `NumberFormatException`       | `FormatException`                  |
| `equals()` / `hashCode()`     | `Equals()` / `GetHashCode()`       |
| `toString()`                  | `ToString()`                       |
| Método `default` na interface | Método default de interface (C# 8+)|
