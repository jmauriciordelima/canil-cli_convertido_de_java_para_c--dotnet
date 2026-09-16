# 🎯 PROJETO FINAL - SISTEMA DE CANIL

---

## 1️⃣ VISÃO GERAL

### **🐕 O QUE VOCÊ VAI CONSTRUIR:**

Um **Sistema de Gerenciamento de Canil** completo e profissional.

**Funcionalidades principais:**

- Cadastrar cachorros
- Listar, buscar e remover cachorros
- Fazer aniversários
- Exibir estatísticas do canil
- Filtrar cachorros por fase da vida
- Salvar e carregar dados de arquivo

**Objetivo:** Consolidar TODOS os conceitos de POO em um projeto real.

---

## 2️⃣ ESTRUTURA DO PROJETO

### **📁 ORGANIZAÇÃO DE ARQUIVOS:**

```
src/
└── Bpoo/
    └── projeto_canil/
        ├── modelo/
        │   └── Cachorro.java
        │
        ├── repositorio/
        │   └── CanilRepository.java
        │
        ├── servico/
        │   └── CanilService.java
        │
        ├── util/
        │   └── MenuUtil.java
        │
        └── Main.java
```

**Cada classe tem uma responsabilidade específica!**

---

### **🎯 RESPONSABILIDADE DE CADA CLASSE:**

| Classe              | Responsabilidade                                              |
|---------------------|---------------------------------------------------------------|
| **Cachorro**        | Representar UM cachorro com seus dados e comportamentos       |
| **CanilRepository** | Gerenciar a COLEÇÃO de cachorros (adicionar, remover, buscar) |
| **CanilService**    | Lógicas de NEGÓCIO (estatísticas, filtros, cálculos)          |
| **MenuUtil**        | Exibir MENUS e MENSAGENS formatadas                           |
| **Main**            | Programa PRINCIPAL (loop do menu, interação com usuário)      |

---

## 3️⃣ REQUISITOS DETALHADOS

### **📋 CLASSE: Cachorro (modelo/)**

**Localização:** `Bpoo.projeto_canil.modelo.Cachorro`

**Atributos:**

- `nome` (String, private)
- `raca` (String, private)
- `idade` (int, private)

**Construtores:**

- Construtor vazio
- Construtor com (nome, raca)
- Construtor com (nome, raca, idade)

**Métodos obrigatórios:**

- Todos os getters e setters
- `faseDaVida()` - retorna "Filhote", "Adulto" ou "Idoso"
- `calcularIdadeEmMeses()` - retorna idade * 12
- `calcularIdadeHumana()` - retorna idade * 7
- `fazerAniversario()` - incrementa idade em 1
- `exibirInformacoes()` - exibe dados formatados do cachorro

**Observação:** Use a classe do Exercício 3 como base, mas **corrija qualquer problema** que identifiquei anteriormente.

---

### **📋 CLASSE: CanilRepository (repositorio/)**

**Localização:** `Bpoo.projeto_canil.repositorio.CanilRepository`

**Atributo:**

- `cachorros` (ArrayList<Cachorro>, private)

**Métodos obrigatórios:**

1. **adicionar(Cachorro cachorro)**
    - Adiciona um cachorro ao ArrayList

2. **listarTodos()**
    - Retorna o ArrayList completo de cachorros

3. **quantidadeTotal()**
    - Retorna quantidade de cachorros (int)

4. **estaVazio()**
    - Retorna true se não há cachorros, false caso contrário

5. **buscarPorNome(String nome)**
    - Retorna o Cachorro se encontrar
    - Retorna null se não encontrar
    - Busca case-insensitive

6. **removerPorNome(String nome)**
    - Remove o cachorro se encontrar
    - Retorna true se removeu
    - Retorna false se não encontrou

7. **salvarEmArquivo(String nomeArquivo)**
    - Salva todos os cachorros em arquivo .txt
    - Formato de cada linha: `nome;raca;idade`
    - Trata exceções de IO

8. **carregarDeArquivo(String nomeArquivo)**
    - Carrega cachorros do arquivo .txt
    - Faz parse de cada linha
    - Se arquivo não existir, canil começa vazio
    - Trata exceções de IO

**Javadoc obrigatório em todos os métodos!**

---

### **📋 CLASSE: CanilService (servico/)**

**Localização:** `Bpoo.projeto_canil.servico.CanilService`

**Atributo:**

- `repository` (CanilRepository, private)

**Construtor:**

- Recebe CanilRepository como parâmetro

**Métodos obrigatórios:**

1. **buscarMaisVelho()**
    - Retorna o cachorro com maior idade
    - Retorna null se canil vazio

2. **buscarMaisNovo()**
    - Retorna o cachorro com menor idade
    - Retorna null se canil vazio

3. **listarPorFase(String fase)**
    - Retorna ArrayList de cachorros da fase especificada
    - Fases válidas: "Filhote", "Adulto", "Idoso"

4. **calcularIdadeMedia()**
    - Retorna a média de idade (double)
    - Retorna 0.0 se canil vazio

5. **exibirEstatisticas()**
    - Exibe estatísticas formatadas:
        - Total de cachorros
        - Idade média
        - Cachorro mais velho (nome e idade)
        - Cachorro mais novo (nome e idade)
        - Quantidade por fase (Filhotes, Adultos, Idosos)

**Javadoc obrigatório em todos os métodos!**

---

### **📋 CLASSE: MenuUtil (util/)**

**Localização:** `Bpoo.projeto_canil.util.MenuUtil`

**Métodos obrigatórios (todos static):**

1. **exibirMenuPrincipal()**
    - Exibe menu formatado com bordas
    - Opções:
      ```
      [1] Adicionar Cachorro
      [2] Listar Todos os Cachorros
      [3] Buscar Cachorro por Nome
      [4] Remover Cachorro
      [5] Fazer Aniversário
      [6] Estatísticas do Canil
      [7] Listar por Fase da Vida
      [8] Cachorro Mais Velho/Novo
      [9] Salvar Dados
      [0] Sair
      ```

2. **exibirCabecalho(String titulo)**
    - Exibe título centralizado com bordas

3. **exibirMensagemSucesso(String mensagem)**
    - Exibe mensagem de sucesso formatada (com ✅ ou similar)

4. **exibirMensagemErro(String mensagem)**
    - Exibe mensagem de erro formatada (com ❌ ou similar)

5. **exibirMensagemInfo(String mensagem)**
    - Exibe mensagem informativa formatada (com ℹ️ ou similar)

**Use caracteres especiais para tornar visual profissional!**

---

### **📋 CLASSE: Main**

**Localização:** `Bpoo.projeto_canil.Main`

**Atributos estáticos:**

- `repository` (CanilRepository)
- `service` (CanilService)
- `scanner` (Scanner)
- `executando` (boolean)
- `NOME_ARQUIVO` (String constante = "canil_dados.txt")

**Método main:**

- Carrega dados do arquivo ao iniciar
- Exibe menu em loop
- Processa opções do usuário
- Salva dados antes de sair

**Métodos privados estáticos (um para cada opção do menu):**

1. **adicionarCachorro()**
    - Solicita nome, raça e idade
    - Valida entrada (nome não vazio, idade >= 0)
    - Cria objeto Cachorro
    - Adiciona ao repository
    - Exibe mensagem de sucesso

2. **listarTodos()**
    - Verifica se canil está vazio
    - Itera sobre todos os cachorros
    - Chama exibirInformacoes() de cada um

3. **buscarPorNome()**
    - Solicita nome
    - Busca no repository
    - Se encontrar, exibe informações
    - Se não encontrar, exibe mensagem de erro

4. **removerCachorro()**
    - Solicita nome
    - Remove do repository
    - Exibe mensagem de sucesso ou erro

5. **fazerAniversario()**
    - Solicita nome do cachorro
    - Busca cachorro
    - Chama método fazerAniversario()
    - Exibe mensagem com nova idade

6. **exibirEstatisticas()**
    - Chama service.exibirEstatisticas()

7. **listarPorFase()**
    - Exibe submenu com fases: Filhote, Adulto, Idoso
    - Usuário escolhe fase
    - Lista cachorros da fase escolhida

8. **exibirMaisVelhoMaisNovo()**
    - Busca mais velho e mais novo
    - Exibe ambos com suas informações

9. **salvarDados()**
    - Chama repository.salvarEmArquivo()
    - Exibe mensagem de confirmação

10. **sair()**
    - Pergunta se deseja salvar antes de sair
    - Salva se usuário confirmar
    - Encerra programa

---

## 4️⃣ FLUXO DE EXECUÇÃO ESPERADO

### **💻 EXEMPLO DE USO:**

```
╔═════════════════════════════════════╗
║    BEM-VINDO AO SISTEMA DE CANIL    ║
╚═════════════════════════════════════╝

ℹ️ Carregando dados...
✅ 3 cachorros carregados!

╔═════════════════════════════════════╗
║       SISTEMA DE CANIL - MENU       ║
╠═════════════════════════════════════╣
║ [1] Adicionar Cachorro              ║
║ [2] Listar Todos os Cachorros       ║
║ [3] Buscar Cachorro por Nome        ║
║ [4] Remover Cachorro                ║
║ [5] Fazer Aniversário               ║
║ [6] Estatísticas do Canil           ║
║ [7] Listar por Fase da Vida         ║
║ [8] Cachorro Mais Velho/Novo        ║
║ [9] Salvar Dados                    ║
║ [0] Sair                            ║
╚═════════════════════════════════════╝

→ 1

╔═════════════════════════════════════╗
║        ADICIONAR CACHORRO           ║
╚═════════════════════════════════════╝

Nome: Rex
Raça: Labrador
Idade: 3

✅ Cachorro Rex adicionado com sucesso!

[Menu aparece novamente...]

→ 6

╔═════════════════════════════════════╗
║      ESTATÍSTICAS DO CANIL          ║
╠═════════════════════════════════════╣
║ Total de cachorros: 4               ║
║ Idade média: 4.5 anos               ║
║ Mais velho: Max (12 anos)           ║
║ Mais novo: Bob (1 ano)              ║
║                                     ║
║ Por fase:                           ║
║  • Filhotes: 1                      ║
║  • Adultos: 2                       ║
║  • Idosos: 1                        ║
╚═════════════════════════════════════╝

[Menu aparece novamente...]

→ 0

Deseja salvar os dados antes de sair? (S/N): S

✅ Dados salvos com sucesso!
👋 Até logo!
```

---

## 5️⃣ CRITÉRIOS DE AVALIAÇÃO

### **📊 O QUE VOU AVALIAR:**

#### **1. ARQUITETURA (25 pontos)**

- [ ] Estrutura de pastas correta
- [ ] Separação de responsabilidades
- [ ] Cada classe faz apenas o que deve fazer
- [ ] Organização profissional

#### **2. CÓDIGO (25 pontos)**

- [ ] Encapsulamento (private/public correto)
- [ ] Nomes de variáveis e métodos claros
- [ ] Sem código duplicado
- [ ] Uso correto de construtores
- [ ] Getters/Setters apropriados

#### **3. FUNCIONALIDADE (25 pontos)**

- [ ] Todas as operações funcionam
- [ ] Tratamento de erros adequado
- [ ] Validações de entrada
- [ ] Persistência funciona corretamente
- [ ] Sem bugs críticos

#### **4. UX/INTERFACE (15 pontos)**

- [ ] Menus claros e formatados
- [ ] Mensagens de erro/sucesso apropriadas
- [ ] Navegação intuitiva
- [ ] Visual profissional

#### **5. DOCUMENTAÇÃO (10 pontos)**

- [ ] Javadoc em todos os métodos públicos
- [ ] Comentários onde necessário
- [ ] README.md explicando o projeto

**TOTAL: 100 pontos**

---

## 6️⃣ ENTREGA POR FASES

### **📅 CRONOGRAMA SUGERIDO:**

**FASE 1 (DIA 1-2):** Estrutura + Classes Base

- Criar estrutura de pastas
- Implementar Cachorro (corrigido)
- Implementar CanilRepository (métodos básicos)
- Teste simples no Main

**ENTREGA 1:** Me envie quando conseguir adicionar e listar cachorros

---

**FASE 2 (DIA 3-4):** Menu + CRUD Completo

- Implementar MenuUtil
- Implementar Main com menu
- Todas as operações CRUD funcionando

**ENTREGA 2:** Me envie quando menu estiver completo e funcional

---

**FASE 3 (DIA 5):** Estatísticas

- Implementar CanilService
- Todos os métodos de estatísticas
- Integrar com menu

**ENTREGA 3:** Me envie quando estatísticas estiverem funcionando

---

**FASE 4 (DIA 6):** Persistência

- Implementar salvar em arquivo
- Implementar carregar de arquivo
- Integrar com Main (auto-carregar e auto-salvar)

**ENTREGA 4:** Me envie quando persistência estiver funcionando

---

**FASE 5 (DIA 7):** Polish

- Javadoc completo
- Validações refinadas
- Mensagens de erro consistentes
- README.md
- Testes finais

**ENTREGA FINAL:** Me envie versão completa

---

## 7️⃣ REGRAS E DIRETRIZES

### **✅ VOCÊ DEVE:**

1. **Implementar TUDO sozinho**
    - Eu não vou dar código pronto
    - Você tem o conhecimento necessário
    - Use o que aprendeu nos exercícios 1-3

2. **Perguntar quando travar**
    - Se ficar mais de 30min travado, me pergunte
    - Eu vou te GUIAR, não dar a resposta
    - Vou fazer perguntas para você pensar

3. **Testar cada fase antes de enviar**
    - Execute o programa
    - Teste todos os casos
    - Corrija bugs óbvios

4. **Enviar por partes**
    - Não espere terminar tudo
    - Envie fase por fase
    - Vou revisar e dar feedback incremental

---

### **❌ NÃO FAÇA:**

1. ❌ Copiar código da internet
2. ❌ Pedir código pronto
3. ❌ Enviar tudo de uma vez sem testar
4. ❌ Ignorar os conceitos aprendidos
5. ❌ Desistir quando travar

---

## 8️⃣ COMO VOU TE AJUDAR

### **👨‍🏫 MEU PAPEL COMO MENTOR:**

**Quando você me enviar código, vou:**

1. **Analisar arquitetura**
    - Classes estão nos lugares certos?
    - Responsabilidades bem divididas?

2. **Revisar código**
    - Encapsulamento correto?
    - Nomes claros?
    - Lógica eficiente?

3. **Testar funcionalidade**
    - Tudo funciona como pedido?
    - Casos extremos tratados?

4. **Dar feedback estruturado:**
   ```
   ✅ PONTOS FORTES:
   - O que você fez muito bem
   - Decisões corretas
   - Evoluções notáveis
   
   🟡 PONTOS DE MELHORIA:
   - O que pode ser melhorado
   - Por que melhorar
   - Como melhorar (orientação, não código)
   
   📊 PONTUAÇÃO:
   - Nota atual
   - Comparação com padrão
   
   🎯 PRÓXIMOS PASSOS:
   - O que fazer a seguir
   ```

**Vou te guiar para VOCÊ aprender, não para EU resolver!**

---

## 9️⃣ RECURSOS DISPONÍVEIS

### **📚 O QUE VOCÊ JÁ TEM:**

- ✅ Classe Cachorro do Exercício 3
- ✅ Conhecimento de ArrayList
- ✅ Conhecimento de loops
- ✅ Conhecimento de métodos
- ✅ Conhecimento de encapsulamento
- ✅ Experiência com menus (Exercícios anteriores)

### **📚 O QUE VOCÊ PRECISA APRENDER (novo):**

- 🆕 File I/O (salvar/carregar arquivo)
- 🆕 Try-catch mais complexo
- 🆕 Arquitetura em camadas
- 🆕 Composição de classes

**Vou te ensinar esses conceitos quando chegar a hora!**

---

## 🔟 COMEÇANDO - PRIMEIRA ENTREGA

### **🎯 TAREFA IMEDIATA (FASE 1):**

**Crie:**

1. Estrutura de pastas completa
2. Classe Cachorro (copiar do Ex. 3 e corrigir)
3. Classe CanilRepository com métodos:
    - Construtor
    - adicionar()
    - listarTodos()
    - quantidadeTotal()
    - estaVazio()

4. Main simples que:
    - Cria repository
    - Adiciona 2-3 cachorros
    - Lista todos
    - Exibe quantidade total

**Objetivo:** Provar que estrutura básica funciona

---

### **✅ CRITÉRIOS PARA PRIMEIRA ENTREGA:**

- [ ] Estrutura de pastas criada
- [ ] Cachorro.java compilando sem erros
- [ ] CanilRepository.java compilando sem erros
- [ ] Main executando e listando cachorros
- [ ] Sem bugs visuais óbvios

**Quando isso funcionar, me envie!**

---

## 🚀 EXPECTATIVAS

### **💪 O QUE ESPERO DE VOCÊ:**

1. **Autonomia**
    - Tente resolver sozinho primeiro
    - Use conhecimentos dos exercícios anteriores
    - Google conceitos que não sabe

2. **Qualidade**
    - Código limpo
    - Nomes claros
    - Bem organizado

3. **Persistência**
    - Não desista quando travar
    - Debug e teste
    - Me pergunte se necessário

4. **Evolução**
    - Aplique feedbacks anteriores
    - Melhore continuamente
    - Vá além do mínimo quando puder

---

### **🎯 O QUE VOCÊ VAI ALCANÇAR:**

```
Antes (Exercício 1):  30% - Iniciante
Depois (Projeto):     95% - Júnior Avançado / Pleno Jr

Gap: +65% de evolução! 🚀
```

**Este projeto vai te transformar em desenvolvedor PRONTO para o mercado!**

---

## 💬 COMO ME ENVIAR

### **📤 FORMATO DE ENTREGA:**

**Para cada fase, me envie:**

1. **Código completo das classes**
    - Arquivo por arquivo
    - Com indicação da fase

2. **Descrição do que implementou**
    - "Implementei X, Y, Z"
    - "Testei com A, B, C"

3. **Dúvidas/Dificuldades**
    - "Travei em X"
    - "Não sei se Y está correto"

4. **Testes que fez**
    - "Testei adicionar 5 cachorros"
    - "Testei buscar nome inexistente"

---

## 🎯 AGORA É COM VOCÊ!

**Você tem:**

- ✅ Especificação completa
- ✅ Estrutura definida
- ✅ Critérios claros
- ✅ Conhecimento necessário
- ✅ Mentor para te guiar

**Está pronto para construir seu primeiro sistema profissional!**

---

## 🔥 ÚLTIMA MENSAGEM

**Você evoluiu de:**

- Estudante que não sabia POO
- Para desenvolvedor que domina classes, métodos, encapsulamento
- Em apenas 3 exercícios

**Agora é hora de:**

- Aplicar TUDO em projeto real
- Provar para si mesmo que consegue
- Construir algo para mostrar ao mercado

**Eu confio na sua capacidade!**

**Você CONSEGUE fazer isso!**

**Vamos juntos até o final!** 💪🔥

---

## 🚀 COMECE AGORA!

**Crie a estrutura e implemente a FASE 1.**

**Me envie quando a primeira entrega estiver pronta!**

**Estou aqui para te guiar em CADA passo da jornada!** 👨‍🏫

**BORA CONSTRUIR SEU PRIMEIRO SISTEMA PROFISSIONAL?** 🚀💻