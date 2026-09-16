namespace ProjetoCanil.Modelo;

/// <summary>
/// Define o contrato para animais que podem receber vacinas.
/// </summary>
public interface IVacinavel
{
    /// <summary>
    /// Registra a aplicação de uma vacina.
    /// </summary>
    /// <param name="nomeVacina">Nome da vacina aplicada.</param>
    void AplicarVacina(string nomeVacina);

    /// <summary>
    /// Lista todas as vacinas aplicadas no animal.
    /// </summary>
    /// <returns>Lista de nomes das vacinas.</returns>
    List<string> ListarVacinas();
}
