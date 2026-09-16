namespace ProjetoCanil.Modelo;

/// <summary>
/// Representa um gato no sistema, estendendo a entidade base <see cref="Animal"/>.
/// <para>
/// Esta classe gerencia atributos específicos de felinos, como o estado de castração,
/// e implementa regras de negócio específicas para o cálculo da idade humana e
/// classificação da fase da vida.
/// </para>
/// </summary>
public class Gato : Animal, IAdotavel, IVacinavel
{
    /// <summary>
    /// Indica se o gato passou pelo procedimento de castração.
    /// </summary>
    public bool Castrado { get; set; }

    /// <summary>
    /// Indica se o gato está disponível para adoção.
    /// </summary>
    public bool Disponivel { get; set; } = true;

    private readonly List<string> _vacinas = new();

    /// <summary>
    /// Construtor para inicializar um gato básico.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <param name="nome">Nome do gato.</param>
    /// <param name="idade">Idade em anos.</param>
    public Gato(int id, string nome, int idade) : base(id, nome, idade)
    {
    }

    /// <summary>
    /// Construtor completo para inicializar um gato incluindo o status de castração.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <param name="nome">Nome do gato.</param>
    /// <param name="idade">Idade em anos.</param>
    /// <param name="castrado"><c>true</c> se o animal for castrado, <c>false</c> caso contrário.</param>
    public Gato(int id, string nome, int idade, bool castrado) : base(id, nome, idade)
    {
        Castrado = castrado;
    }

    /// <summary>
    /// Calcula e retorna a fase da vida do gato baseada em sua idade.
    /// </summary>
    /// <returns><see cref="FaseVida.Filhote"/>, <see cref="FaseVida.Adulto"/> ou <see cref="FaseVida.Idoso"/>.</returns>
    public override FaseVida FaseDaVida()
    {
        if (Idade <= 1)
        {
            return FaseVida.Filhote;
        }
        else if (Idade is > 1 and <= 10)
        {
            return FaseVida.Adulto;
        }
        else
        {
            return FaseVida.Idoso;
        }
    }

    /// <summary>
    /// Exibe no console as informações detalhadas do gato, incluindo
    /// cálculos de idade humana e status de castração.
    /// </summary>
    public override void ExibirInformacoes()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"NOME: {Nome}");
        Console.WriteLine($"IDADE: {Idade}");
        Console.WriteLine($"FASE DA VIDA: {FaseDaVida().ParaExibicao()}");
        Console.WriteLine($"CASTRADO?: {Castrado}");
        Console.WriteLine($"IDADE HUMANA: {CalcularIdadeHumana()}");
        Console.WriteLine($"{Nome} É UM GATO DE {FormatarMensagemIdade()}");
        Console.WriteLine();
    }

    /// <summary>
    /// Calcula a equivalência da idade do gato em anos humanos, considerando
    /// a aceleração do desenvolvimento nos primeiros anos de vida.
    /// </summary>
    /// <returns>Idade equivalente em anos humanos.</returns>
    public int CalcularIdadeHumana()
    {
        if (Idade <= 1)
        {
            return 15;
        }
        else if (Idade == 2)
        {
            return 24;
        }
        else
        {
            return 24 + ((Idade - 2) * 4);
        }
    }

    /// <summary>
    /// Retorna a representação textual do objeto Gato.
    /// </summary>
    /// <returns>String formatada contendo o estado do objeto.</returns>
    public override string ToString()
    {
        return $"GATO [ID: {Id}, NOME: {Nome}, CASTRADO: {Castrado}, IDADE: {Idade}]";
    }

    /// <summary>
    /// Compara este objeto com outro para verificar igualdade lógica.
    /// Dois gatos são considerados iguais se possuírem o mesmo ID.
    /// </summary>
    /// <param name="obj">Objeto a ser comparado.</param>
    /// <returns><c>true</c> se os objetos forem iguais, <c>false</c> caso contrário.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
        {
            return false;
        }

        var gato = (Gato)obj;
        return Id == gato.Id;
    }

    /// <summary>
    /// Gera o código hash do objeto baseado no ID.
    /// </summary>
    /// <returns>Hash code do ID.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Verifica se o animal está disponível para adoção.
    /// </summary>
    /// <returns><c>true</c> se o animal estiver disponível, <c>false</c> caso contrário.</returns>
    public bool EstaDisponivel()
    {
        return Disponivel;
    }

    /// <summary>
    /// Define o status de disponibilidade do animal para adoção.
    /// </summary>
    /// <param name="disponivel">O novo status de disponibilidade.</param>
    public void SetDisponivel(bool disponivel)
    {
        Disponivel = disponivel;
    }

    /// <summary>
    /// Registra a aplicação de uma vacina no histórico do animal.
    /// </summary>
    /// <param name="nomeVacina">O nome da vacina a ser registrada.</param>
    public void AplicarVacina(string nomeVacina)
    {
        _vacinas.Add(nomeVacina);
    }

    /// <summary>
    /// Retorna a lista de todas as vacinas aplicadas no animal.
    /// </summary>
    /// <returns>Uma lista contendo os nomes das vacinas aplicadas.</returns>
    public List<string> ListarVacinas()
    {
        return _vacinas;
    }
}
