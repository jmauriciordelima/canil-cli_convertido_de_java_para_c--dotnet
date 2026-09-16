namespace ProjetoCanil.Modelo;

/// <summary>
/// Define o contrato para animais que podem ser adotados no sistema.
/// </summary>
public interface IAdotavel
{
    /// <summary>
    /// Obtém o nome do animal.
    /// </summary>
    string Nome { get; }

    /// <summary>
    /// Verifica se o animal está disponível para adoção.
    /// </summary>
    /// <returns><c>true</c> se disponível, <c>false</c> caso contrário.</returns>
    bool EstaDisponivel();

    /// <summary>
    /// Atualiza o status de disponibilidade do animal.
    /// </summary>
    /// <param name="disponivel">Novo status.</param>
    void SetDisponivel(bool disponivel);

    /// <summary>
    /// Executa o processo de adoção, alterando o status para indisponível.
    /// </summary>
    void ProcessoAdocao()
    {
        SetDisponivel(false);
        Console.WriteLine($"{Nome} FOI ADOTADO!");
    }
}
