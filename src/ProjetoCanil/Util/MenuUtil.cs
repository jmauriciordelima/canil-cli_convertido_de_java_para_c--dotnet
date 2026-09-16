namespace ProjetoCanil.Util;

/// <summary>
/// Classe utilitária responsável pela exibição
/// e formatação da interface textual do sistema.
/// <para>
/// Todos os métodos são estáticos.
/// </para>
/// </summary>
public static class MenuUtil
{
    /// <summary>
    /// Desenha o menu principal no console com formatação estruturada.
    /// </summary>
    public static void ExibirMenuPrincipal()
    {
        Console.WriteLine("""
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

    /// <summary>
    /// Centraliza títulos de seções para melhor legibilidade no terminal.
    /// </summary>
    /// <param name="titulo">Título a ser exibido.</param>
    public static void ExibirCabecalho(string titulo)
    {
        int largura = 32;
        int sobrando = largura - titulo.Length;
        int esquerda = sobrando / 2;
        int direita = sobrando - esquerda;
        string linha = "║" + new string(' ', esquerda) + titulo + new string(' ', direita) + "║";

        Console.WriteLine("╔════════════════════════════════╗");
        Console.WriteLine(linha);
        Console.WriteLine("╚════════════════════════════════╝");
    }

    /// <summary>
    /// Exibe mensagens de feedback positivo.
    /// </summary>
    /// <param name="mensagem">Texto da mensagem de sucesso.</param>
    public static void ExibirMensagemSucesso(string mensagem)
    {
        Console.WriteLine("✅ " + mensagem);
    }

    /// <summary>
    /// Exibe uma mensagem de erro formatada.
    /// </summary>
    /// <param name="mensagem">Texto da mensagem.</param>
    public static void ExibirMensagemErro(string mensagem)
    {
        Console.WriteLine("❌ " + mensagem);
    }

    /// <summary>
    /// Exibe uma mensagem informativa formatada.
    /// </summary>
    /// <param name="mensagem">Texto da mensagem.</param>
    public static void ExibirMensagemInfo(string mensagem)
    {
        Console.WriteLine("ℹ\uFE0F " + mensagem);
    }
}
