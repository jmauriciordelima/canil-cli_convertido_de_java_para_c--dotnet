CONVERSÃO PARA .NET / C# (CONCLUÍDA):
├─ [x] Instalar .NET SDK 8
├─ [x] Criar solution e projeto console (src/ProjetoCanil)
├─ [x] Converter modelo (Animal, Cachorro, Gato, FaseVida, IAdotavel, IVacinavel)
├─ [x] Converter repositório (CanilRepository)
├─ [x] Converter serviço (CanilService)
├─ [x] Converter util (MenuUtil)
├─ [x] Converter Main para Program.cs
├─ [x] Portar PolimorfismoTest (execução via `-- polimorfismo`)
├─ [x] Compilar sem warnings/erros
├─ [x] Validar menu, persistência e demo de polimorfismo
└─ [x] Atualizar README

---

FASE 1 - ESTRUTURA (DIA 1):
├─ [x] Criar estrutura de pastas
├─ [x] Copiar e corrigir classe Cachorro
├─ [ ] Criar CanilRepository básico
├─ [ ] Criar Main de teste
└─ [ ] Testar adicionar e listar

FASE 2 - MENU (DIA 2):
├─ [ ] Criar MenuUtil
├─ [ ] Adicionar métodos de busca/remoção
├─ [ ] Implementar menu interativo
├─ [ ] Implementar adicionar cachorro
├─ [ ] Implementar listar todos
├─ [ ] Implementar buscar por nome
└─ [ ] Implementar remover

FASE 3 - ESTATÍSTICAS (DIA 3-4):
├─ [ ] Criar CanilService
├─ [ ] Implementar buscarMaisVelho()
├─ [ ] Implementar buscarMaisNovo()
├─ [ ] Implementar listarPorFase()
├─ [ ] Implementar calcularIdadeMedia()
├─ [ ] Implementar exibirEstatisticas()
└─ [ ] Adicionar opção no menu

FASE 4 - PERSISTÊNCIA (DIA 5-6):
├─ [ ] Implementar salvarEmArquivo()
├─ [ ] Implementar carregarDeArquivo()
├─ [ ] Carregar dados ao iniciar
├─ [ ] Salvar antes de sair
└─ [ ] Testar salvar/carregar

FASE 5 - POLISH (DIA 7):
├─ [ ] Javadoc em todas as classes
├─ [ ] Mensagens de erro consistentes
├─ [ ] Validações completas
├─ [ ] README.md do projeto
└─ [ ] Testar todos os fluxos