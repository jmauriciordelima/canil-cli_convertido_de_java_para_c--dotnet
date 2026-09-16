namespace ProjetoCanil.Modelo;

/// <summary>
/// Entidade que representa um cachorro cadastrado no sistema.
/// <para>
/// Contém informações básicas como nome, raça e idade,
/// além de regras de negócio relacionadas à fase da vida
/// e cálculos derivados da idade.
/// </para>
/// </summary>
public class Cachorro : Animal, IAdotavel, IVacinavel
{
    /// <summary>
    /// Raça específica do animal.
    /// </summary>
    public string Raca { get; set; }

    /// <summary>
    /// Indica se o cachorro está disponível para adoção.
    /// </summary>
    public bool Disponivel { get; set; } = true;

    private readonly List<string> _vacinas = new();

    /// <summary>
    /// Construtor completo para a criação de uma nova instância de <see cref="Cachorro"/>.
    /// </summary>
    /// <param name="id">O identificador único do cachorro.</param>
    /// <param name="nome">O nome atribuído ao animal.</param>
    /// <param name="raca">A raça específica do animal.</param>
    /// <param name="idade">A idade do animal em anos.</param>
    public Cachorro(int id, string nome, string raca, int idade) : base(id, nome, idade)
    {
        Raca = raca;
    }

    /// <summary>
    /// Determina a fase da vida do cachorro com base na idade.
    /// </summary>
    /// <returns>A fase da vida: <see cref="FaseVida.Filhote"/>, <see cref="FaseVida.Adulto"/> ou <see cref="FaseVida.Idoso"/>.</returns>
    public override FaseVida FaseDaVida()
    {
        if (Idade > 10)
        {
            return FaseVida.Idoso;
        }
        else if (Idade is <= 10 and > 2)
        {
            return FaseVida.Adulto;
        }
        else
        {
            return FaseVida.Filhote;
        }
    }

    /// <summary>
    /// Calcula a idade do cachorro em meses.
    /// </summary>
    /// <returns>Idade total em meses.</returns>
    private int CalcularIdadeEmMeses()
    {
        return Idade * 12;
    }

    /// <summary>
    /// Calcula a equivalência da idade do cachorro em anos humanos.
    /// Considera a média comum de 7 anos humanos para cada ano canino.
    /// </summary>
    /// <returns>Idade equivalente em anos humanos.</returns>
    private int CalcularIdadeHumana()
    {
        return Idade * 7;
    }

    /// <summary>
    /// Exibe no console as informações detalhadas do cachorro,
    /// incluindo cálculos de idade humana e meses.
    /// </summary>
    public override void ExibirInformacoes()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"NOME: {Nome}");
        Console.WriteLine($"IDADE: {Idade}");
        Console.WriteLine($"FASE DA VIDA: {FaseDaVida().ParaExibicao()}");
        Console.WriteLine($"IDADE EM MESES: {CalcularIdadeEmMeses()}");
        Console.WriteLine($"IDADE HUMANA: {CalcularIdadeHumana()}");
        Console.WriteLine($"{Nome} É UM {Raca} DE {FormatarMensagemIdade()}");
        Console.WriteLine();
    }

    /// <summary>
    /// Retorna uma representação textual detalhada do objeto Cachorro.
    /// </summary>
    /// <returns>String contendo ID, nome, raça e idade do animal.</returns>
    public override string ToString()
    {
        return $"CACHORRO [ID: {Id}, NOME: {Nome}, RAÇA: {Raca}, IDADE: {Idade}]";
    }

    /// <summary>
    /// Compara este objeto com outro para verificar igualdade lógica.
    /// Dois cachorros são considerados iguais se possuírem o mesmo ID.
    /// </summary>
    /// <param name="obj">Objeto a ser comparado.</param>
    /// <returns><c>true</c> se os objetos forem iguais, <c>false</c> caso contrário.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
        {
            return false;
        }

        var cachorro = (Cachorro)obj;
        return Id == cachorro.Id;
    }

    /// <summary>
    /// Gera o código hash do objeto baseado no ID.
    /// </summary>
    /// <returns>O valor do hash code calculado a partir do ID.</returns>
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
