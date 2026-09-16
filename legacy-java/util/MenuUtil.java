package Bpoo.projeto_canil.util;

/**
 * Classe utilitária responsável pela exibição
 * e formatação da interface textual do sistema.
 *
 * Todos os métodos são estáticos.
 *
 * @author José Maurício
 * @version 1.0
 */
public class MenuUtil {

    /**
     * Desenha o menu principal no console com formatação estruturada.
     */
    public static void exibirMenuPrincipal() {
        System.out.println("""
                ╔════════════════════════════════╗
                ║    SISTEMA DE CANIL - MENU     ║
                ╠════════════════════════════════╣
                ║ [1] Adicionar Cachorro         ║
                ║ [2] Listar Todos os Cachorros  ║
                ║ [3] Buscar Cachorro por Nome   ║
                ║ [4] Remover Cachorro           ║
                ║ [5] Fazer Aniversário          ║
                ║ [6] Estatísticas do Canil      ║
                ║ [7] Listar por Fase da Vida    ║
                ║ [8] Cachorro Mais Velho/Novo   ║
                ║ [9] Salvar Dados               ║
                ║ [0] Sair                       ║
                ╚════════════════════════════════╝
                
                """);
    }

    /**
     * Centraliza títulos de seções para melhor legibilidade no terminal.
     *
     * @param titulo Título a ser exibido.
     */
    public static void exibirCabecalho(String titulo) {
        int largura = 32;
        int sobrando = largura - titulo.length();
        int esquerda = sobrando / 2;
        int direita = sobrando - esquerda;
        String linha = "║" + " ".repeat(esquerda) + titulo + " ".repeat(direita) + "║";

        System.out.println("╔════════════════════════════════╗");
        System.out.println(linha);
        System.out.println("╚════════════════════════════════╝");
    }

    /**
     * Exibe mensagens de feedback positivo.
     *
     * @param mensagem Texto da mensagem de sucesso.
     */
    public static void exibirMensagemSucesso(String mensagem) {
        System.out.println("✅ " + mensagem);
    }

    /**
     * Exibe uma mensagem de erro formatada.
     *
     * @param mensagem texto da mensagem.
     */
    public static void exibirMensagemErro(String mensagem) {
        System.out.println("❌ " + mensagem);
    }

    /**
     * Exibe uma mensagem informativa formatada.
     *
     * @param mensagem texto da mensagem.
     */
    public static void exibirMensagemInfo(String mensagem) {
        System.out.println("ℹ\uFE0F " + mensagem);
    }
}
