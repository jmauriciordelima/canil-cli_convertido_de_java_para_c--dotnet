namespace ProjetoCanil.Modelo;

/// <summary>
/// Define as categorias de faixa etária para os animais do canil.
/// <para>
/// Esta enumeração é utilizada para classificar os cachorros com base em sua idade,
/// auxiliando na aplicação de regras de negócio específicas para cada estágio de vida.
/// </para>
/// </summary>
public enum FaseVida
{
    /// <summary>
    /// Representa cachorros em estágio inicial de desenvolvimento.
    /// Geralmente aplicado para idades até 2 anos.
    /// </summary>
    Filhote,

    /// <summary>
    /// Representa cachorros em sua fase madura.
    /// Geralmente aplicado para idades entre 3 e 10 anos.
    /// </summary>
    Adulto,

    /// <summary>
    /// Representa cachorros em estágio avançado de idade.
    /// Geralmente aplicado para idades acima de 10 anos.
    /// </summary>
    Idoso
}

/// <summary>
/// Extensões utilitárias para <see cref="FaseVida"/>.
/// </summary>
public static class FaseVidaExtensions
{
    /// <summary>
    /// Retorna o nome da fase em letras maiúsculas, preservando
    /// a mesma exibição do enum original escrito em Java.
    /// </summary>
    /// <param name="fase">A fase da vida a ser formatada.</param>
    /// <returns>Nome da fase em maiúsculas.</returns>
    public static string ParaExibicao(this FaseVida fase)
    {
        return fase.ToString().ToUpperInvariant();
    }
}
