namespace ProjetoCanil.Modelo;

/// <summary>
/// Classe base abstrata para os animais cadastrados no sistema.
/// <para>
/// Concentra os atributos e comportamentos comuns a todos os animais,
/// delegando às subclasses a classificação da fase da vida e a
/// exibição das informações detalhadas.
/// </para>
/// </summary>
public abstract class Animal
{
    /// <summary>
    /// Identificador único persistido.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do animal.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Idade em anos.
    /// </summary>
    public int Idade { get; set; }

    /// <summary>
    /// Construtor para criação de um Animal.
    /// </summary>
    /// <param name="id">Identificador único persistido.</param>
    /// <param name="nome">Nome do animal.</param>
    /// <param name="idade">Idade em anos.</param>
    protected Animal(int id, string nome, int idade)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
    }

    /// <summary>
    /// Realiza o aniversário do animal, incrementando sua idade.
    /// </summary>
    /// <returns>Uma mensagem formatada informando a nova idade.</returns>
    public string FazerAniversario()
    {
        Idade++;

        return $"{Nome} FEZ ANIVERSÁRIO, SUA NOVA IDADE AGORA É {FormatarMensagemIdade()}";
    }

    /// <summary>
    /// Formata a idade utilizando singular ou plural.
    /// </summary>
    /// <returns>Idade formatada para exibição.</returns>
    protected string FormatarMensagemIdade()
    {
        if (Idade == 1)
        {
            return $"{Idade} ANO.";
        }

        return $"{Idade} ANOS.";
    }

    /// <summary>
    /// Determina a fase da vida do animal.
    /// </summary>
    /// <returns>A fase da vida correspondente à idade.</returns>
    public abstract FaseVida FaseDaVida();

    /// <summary>
    /// Exibe as informações detalhadas do animal no console.
    /// </summary>
    public abstract void ExibirInformacoes();
}
