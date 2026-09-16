package Bpoo.projeto_canil;

import Bpoo.projeto_canil.modelo.Cachorro;
import Bpoo.projeto_canil.modelo.FaseVida;
import Bpoo.projeto_canil.repositorio.CanilRepository;
import Bpoo.projeto_canil.servico.CanilService;
import Bpoo.projeto_canil.util.MenuUtil;

import java.util.List;
import java.util.Scanner;

/**
 * Classe principal da aplicação.
 * <p>
 * Responsável por inicializar o sistema,
 * carregar os dados persistidos e controlar
 * o fluxo de execução do programa.
 *
 * @author José Maurício
 * @version 1.0
 */
public class Main {

    private static final CanilRepository repository = new CanilRepository();
    private static final CanilService service = new CanilService(repository);
    private static final Scanner scanner = new Scanner(System.in);
    private static boolean executando = true;
    private static final String ARQUIVO = "canil.txt";

    /**
     * Ponto de entrada da aplicação.
     *
     * @param args argumentos recebidos pela JVM.
     */
    public static void main(String[] args) {

        iniciarMenu();

    }

    /**
     * Executa o loop principal do sistema,
     * exibindo o menu e processando as
     * opções selecionadas pelo usuário.
     */
    public static void iniciarMenu() {

        repository.carregarDeArquivo(ARQUIVO);

        do {
            MenuUtil.exibirMenuPrincipal();
            String entradaMenu = scanner.nextLine().toUpperCase();
            switch (entradaMenu) {
                case "1": {
                    MenuUtil.exibirCabecalho("ADICIONAR CACHORRO");
                    System.out.print("INFORME NOME DO CACHORRO > ");
                    String nome = scanner.nextLine().toUpperCase();
                    System.out.print("INFORME A RAÇA DO CACHORRO > ");
                    String raca = scanner.nextLine().toUpperCase();
                    System.out.print("INFORME A IDADE DO CACHORRO > ");
                    try {
                        int idade = Integer.parseInt(scanner.nextLine());
                        repository.adicionar(nome, raca, idade);
                        MenuUtil.exibirMensagemSucesso("[" + nome + "] - ADICIONADO COM SUCESSO.");
                    } catch (NumberFormatException e) {
                        MenuUtil.exibirMensagemErro(" CARACTERE INVÁLIDO " + e);
                    }

                    break;
                }

                case "2": {

                    if (repository.estaVazio()) {
                        MenuUtil.exibirMensagemInfo("CANIL VAZIO");
                        break;
                    }

                    MenuUtil.exibirCabecalho("TODOS OS CACHORROS");

                    for (Cachorro cachorro : repository.listarTodos()) {
                        cachorro.exibirInformacoes();
                    }

                    break;
                }

                case "3": {

                    if (repository.estaVazio()) {
                        MenuUtil.exibirMensagemInfo("CANIL VAZIO");
                        break;
                    }

                    MenuUtil.exibirCabecalho("BUSCAR POR NOME");
                    System.out.print("NOME DO CACHORRO > ");
                    String buscarNomeCachorro = scanner.nextLine().toUpperCase();
                    Cachorro cachorro = repository.buscarPorNome(buscarNomeCachorro);

                    if (cachorro != null) {
                        cachorro.exibirInformacoes();
                    } else {
                        MenuUtil.exibirMensagemErro(" - CACHORRO NÃO ENCONTRADO");
                    }

                    break;

                }

                case "4": {

                    if (repository.estaVazio()) {
                        MenuUtil.exibirMensagemInfo("CANIL VAZIO");
                        break;
                    }

                    MenuUtil.exibirCabecalho("REMOVER CACHORRO");
                    System.out.print("NOME DO CACHORRO > ");
                    String removerCachorro = scanner.nextLine().toUpperCase();
                    boolean sucesso = repository.removerPorNome(removerCachorro);

                    if (sucesso) {
                        MenuUtil.exibirMensagemSucesso(removerCachorro + " - REMOVIDO COM SUCESSO");
                    } else {
                        MenuUtil.exibirMensagemErro(removerCachorro + "- NÃO ENCONTRADO");
                    }

                    break;

                }

                case "5": {

                    MenuUtil.exibirCabecalho("FAZER ANIVERSÁRIO");
                    System.out.print("NOME DO CACHORRO ANIVERSARIANTE > ");
                    String cachorroAniversariante = scanner.nextLine().toUpperCase();
                    Cachorro cachorro = repository.buscarPorNome(cachorroAniversariante);

                    if (cachorro != null) {
                        String mensagem = cachorro.fazerAniversario();
                        System.out.println(mensagem);
                    } else {
                        MenuUtil.exibirMensagemErro("- CACHORRO NÃO ENCONTRADO");
                    }

                    break;

                }

                case "6": {

                    if (repository.estaVazio()) {
                        MenuUtil.exibirMensagemErro("- CANIL VAZIO");
                        break;
                    }

                    MenuUtil.exibirCabecalho("ESTATÍSTICAS");

                    service.exibirEstatisticas();

                    break;
                }

                case "7": {
                    MenuUtil.exibirCabecalho("LISTAR POR FASE");


                    System.out.println("""
                            [1] - FILHOTE
                            [2] - ADULTO
                            [3] - IDOSO
                            """);

                    String fase = scanner.nextLine();
                    FaseVida faseVida = null;

                    switch (fase) {

                        case "1":
                            faseVida = FaseVida.FILHOTE;
                            break;
                        case "2":
                            faseVida = FaseVida.ADULTO;
                            break;
                        case "3":
                            faseVida = FaseVida.IDOSO;
                            break;
                        default:
                            MenuUtil.exibirMensagemErro("- OPÇÃO INVÁLIDA");
                            break;
                    }

                    if (faseVida == null) {
                        break;
                    }

                    List<Cachorro> lista = service.listarPorFase(faseVida);
                    if (lista.isEmpty()) {
                        MenuUtil.exibirMensagemInfo("NENHUM CACHORRO NESSA FASE");
                    } else {
                        for (Cachorro cachorro : lista) {
                            cachorro.exibirInformacoes();
                        }
                    }

                    break;
                }

                case "8": {

                    if (repository.estaVazio()) {
                        MenuUtil.exibirMensagemErro("- CANIL VAZIO");
                        break;
                    }

                    MenuUtil.exibirCabecalho("MAIS VELHO / MAIS NOVO");

                    Cachorro cachorroMaisVelho = service.buscarMaisVelho();
                    Cachorro cachorroMaisNovo = service.buscarMaisNovo();

                    System.out.printf("MAIS VELHO: %s (%d IDADE)%n",
                            cachorroMaisVelho.getNome(),
                            cachorroMaisVelho.getIdade());

                    System.out.printf("MAIS NOVO: %s (%d IDADE)%n",
                            cachorroMaisNovo.getNome(),
                            cachorroMaisNovo.getIdade());

                    break;
                }

                case "9":
                    repository.salvarEmArquivo(ARQUIVO);
                    break;

                case "0":

                    String resposta;

                    do {

                        System.out.println("DESEJA SALVAR ANTES DE SAIR? (S/N)");
                        resposta = scanner.nextLine().toUpperCase();

                        switch (resposta) {

                            case "S":
                                repository.salvarEmArquivo(ARQUIVO);
                                System.out.println("ATÉ LOGO");
                                MenuUtil.exibirCabecalho("FINALIZANDO...");
                                executando = false;
                                break;
                            case "N":
                                System.out.println("ATÉ LOGO");
                                MenuUtil.exibirCabecalho("FINALIZANDO...");
                                executando = false;
                                break;

                            default:
                                MenuUtil.exibirMensagemErro("OPÇÃO INVÁLIDA! DIGITE APENAS [S] OU [N]");
                                break;
                        }

                    } while ((!resposta.equalsIgnoreCase("S") && !resposta.equalsIgnoreCase("N")));

                    break;

                default:
                    if (executando) {
                        MenuUtil.exibirMensagemErro("OPÇÃO INVÁLIDA!");
                    }


            }

        } while (executando);
    }
}
