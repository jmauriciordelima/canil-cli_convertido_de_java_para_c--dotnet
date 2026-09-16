using System.Text;
using ProjetoCanil.Modelo;
using ProjetoCanil.Repositorio;
using ProjetoCanil.Servico;
using ProjetoCanil.Util;

namespace ProjetoCanil;

/// <summary>
/// Classe principal da aplicação.
/// <para>
/// Responsável por inicializar o sistema,
/// carregar os dados persistidos e controlar
/// o fluxo de execução do programa.
/// </para>
/// </summary>
public class Program
{
    private static readonly CanilRepository Repository = new();
    private static readonly CanilService Service = new(Repository);
    private static bool _executando = true;
    private const string Arquivo = "canil.txt";

    /// <summary>
    /// Ponto de entrada da aplicação.
    /// </summary>
    /// <param name="args">
    /// Argumentos de linha de comando. Ao informar <c>polimorfismo</c>,
    /// executa a demonstração de polimorfismo em vez do menu.
    /// </param>
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        if (args.Length > 0 && args[0].Equals("polimorfismo", StringComparison.OrdinalIgnoreCase))
        {
            Testes.PolimorfismoTest.Executar();
            return;
        }

        IniciarMenu();
    }

    /// <summary>
    /// Executa o loop principal do sistema,
    /// exibindo o menu e processando as
    /// opções selecionadas pelo usuário.
    /// </summary>
    public static void IniciarMenu()
    {
        Repository.CarregarDeArquivo(Arquivo);

        do
        {
            MenuUtil.ExibirMenuPrincipal();
            string? entrada = Console.ReadLine();

            if (entrada is null)
            {
                // Fim da entrada (EOF): encerra o programa de forma graciosa.
                break;
            }

            string entradaMenu = entrada.ToUpper();

            switch (entradaMenu)
            {
                case "1":
                    {
                        MenuUtil.ExibirCabecalho("ADICIONAR CACHORRO");
                        Console.Write("INFORME NOME DO CACHORRO > ");
                        string nome = (Console.ReadLine() ?? string.Empty).ToUpper();
                        Console.Write("INFORME A RAÇA DO CACHORRO > ");
                        string raca = (Console.ReadLine() ?? string.Empty).ToUpper();
                        Console.Write("INFORME A IDADE DO CACHORRO > ");
                        try
                        {
                            int idade = int.Parse(Console.ReadLine() ?? string.Empty);
                            Repository.Adicionar(nome, raca, idade);
                            MenuUtil.ExibirMensagemSucesso($"[{nome}] - ADICIONADO COM SUCESSO.");
                        }
                        catch (FormatException e)
                        {
                            MenuUtil.ExibirMensagemErro(" CARACTERE INVÁLIDO " + e);
                        }

                        break;
                    }

                case "2":
                    {
                        if (Repository.EstaVazio())
                        {
                            MenuUtil.ExibirMensagemInfo("CANIL VAZIO");
                            break;
                        }

                        MenuUtil.ExibirCabecalho("TODOS OS CACHORROS");

                        foreach (var cachorro in Repository.ListarTodos())
                        {
                            cachorro.ExibirInformacoes();
                        }

                        break;
                    }

                case "3":
                    {
                        if (Repository.EstaVazio())
                        {
                            MenuUtil.ExibirMensagemInfo("CANIL VAZIO");
                            break;
                        }

                        MenuUtil.ExibirCabecalho("BUSCAR POR NOME");
                        Console.Write("NOME DO CACHORRO > ");
                        string buscarNomeCachorro = (Console.ReadLine() ?? string.Empty).ToUpper();
                        var cachorro = Repository.BuscarPorNome(buscarNomeCachorro);

                        if (cachorro != null)
                        {
                            cachorro.ExibirInformacoes();
                        }
                        else
                        {
                            MenuUtil.ExibirMensagemErro(" - CACHORRO NÃO ENCONTRADO");
                        }

                        break;
                    }

                case "4":
                    {
                        if (Repository.EstaVazio())
                        {
                            MenuUtil.ExibirMensagemInfo("CANIL VAZIO");
                            break;
                        }

                        MenuUtil.ExibirCabecalho("REMOVER CACHORRO");
                        Console.Write("NOME DO CACHORRO > ");
                        string removerCachorro = (Console.ReadLine() ?? string.Empty).ToUpper();
                        bool sucesso = Repository.RemoverPorNome(removerCachorro);

                        if (sucesso)
                        {
                            MenuUtil.ExibirMensagemSucesso(removerCachorro + " - REMOVIDO COM SUCESSO");
                        }
                        else
                        {
                            MenuUtil.ExibirMensagemErro(removerCachorro + "- NÃO ENCONTRADO");
                        }

                        break;
                    }

                case "5":
                    {
                        MenuUtil.ExibirCabecalho("FAZER ANIVERSÁRIO");
                        Console.Write("NOME DO CACHORRO ANIVERSARIANTE > ");
                        string cachorroAniversariante = (Console.ReadLine() ?? string.Empty).ToUpper();
                        var cachorro = Repository.BuscarPorNome(cachorroAniversariante);

                        if (cachorro != null)
                        {
                            string mensagem = cachorro.FazerAniversario();
                            Console.WriteLine(mensagem);
                        }
                        else
                        {
                            MenuUtil.ExibirMensagemErro("- CACHORRO NÃO ENCONTRADO");
                        }

                        break;
                    }

                case "6":
                    {
                        if (Repository.EstaVazio())
                        {
                            MenuUtil.ExibirMensagemErro("- CANIL VAZIO");
                            break;
                        }

                        MenuUtil.ExibirCabecalho("ESTATÍSTICAS");

                        Service.ExibirEstatisticas();

                        break;
                    }

                case "7":
                    {
                        MenuUtil.ExibirCabecalho("LISTAR POR FASE");

                        Console.WriteLine("""
                            [1] - FILHOTE
                            [2] - ADULTO
                            [3] - IDOSO
                            """);

                        string fase = Console.ReadLine() ?? string.Empty;
                        FaseVida? faseVida = null;

                        switch (fase)
                        {
                            case "1":
                                faseVida = FaseVida.Filhote;
                                break;
                            case "2":
                                faseVida = FaseVida.Adulto;
                                break;
                            case "3":
                                faseVida = FaseVida.Idoso;
                                break;
                            default:
                                MenuUtil.ExibirMensagemErro("- OPÇÃO INVÁLIDA");
                                break;
                        }

                        if (faseVida == null)
                        {
                            break;
                        }

                        var lista = Service.ListarPorFase(faseVida.Value);
                        if (lista.Count == 0)
                        {
                            MenuUtil.ExibirMensagemInfo("NENHUM CACHORRO NESSA FASE");
                        }
                        else
                        {
                            foreach (var cachorro in lista)
                            {
                                cachorro.ExibirInformacoes();
                            }
                        }

                        break;
                    }

                case "8":
                    {
                        if (Repository.EstaVazio())
                        {
                            MenuUtil.ExibirMensagemErro("- CANIL VAZIO");
                            break;
                        }

                        MenuUtil.ExibirCabecalho("MAIS VELHO / MAIS NOVO");

                        var cachorroMaisVelho = Service.BuscarMaisVelho();
                        var cachorroMaisNovo = Service.BuscarMaisNovo();

                        Console.WriteLine($"MAIS VELHO: {cachorroMaisVelho!.Nome} ({cachorroMaisVelho.Idade} IDADE)");
                        Console.WriteLine($"MAIS NOVO: {cachorroMaisNovo!.Nome} ({cachorroMaisNovo.Idade} IDADE)");

                        break;
                    }

                case "9":
                    Repository.SalvarEmArquivo(Arquivo);
                    break;

                case "0":
                    {
                        string resposta;

                        do
                        {
                            Console.WriteLine("DESEJA SALVAR ANTES DE SAIR? (S/N)");
                            resposta = (Console.ReadLine() ?? "N").ToUpper();

                            switch (resposta)
                            {
                                case "S":
                                    Repository.SalvarEmArquivo(Arquivo);
                                    Console.WriteLine("ATÉ LOGO");
                                    MenuUtil.ExibirCabecalho("FINALIZANDO...");
                                    _executando = false;
                                    break;
                                case "N":
                                    Console.WriteLine("ATÉ LOGO");
                                    MenuUtil.ExibirCabecalho("FINALIZANDO...");
                                    _executando = false;
                                    break;
                                default:
                                    MenuUtil.ExibirMensagemErro("OPÇÃO INVÁLIDA! DIGITE APENAS [S] OU [N]");
                                    break;
                            }
                        } while (!resposta.Equals("S", StringComparison.OrdinalIgnoreCase) &&
                                 !resposta.Equals("N", StringComparison.OrdinalIgnoreCase));

                        break;
                    }

                default:
                    if (_executando)
                    {
                        MenuUtil.ExibirMensagemErro("OPÇÃO INVÁLIDA!");
                    }

                    break;
            }

        } while (_executando);
    }
}
