using System.Globalization;
using ProjetoCanil.Modelo;
using ProjetoCanil.Repositorio;
using ProjetoCanil.Util;

namespace ProjetoCanil.Servico;

/// <summary>
/// Camada responsável pelas regras de negócio.
/// <para>
/// Realiza cálculos, filtros e estatísticas
/// utilizando os dados fornecidos pelo repositório.
/// </para>
/// </summary>
public class CanilService
{
    private readonly CanilRepository _repository;

    /// <summary>
    /// Cria uma instância do serviço.
    /// </summary>
    /// <param name="repository">Repositório utilizado pelo serviço.</param>
    public CanilService(CanilRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Localiza o cachorro com a maior idade no canil.
    /// </summary>
    /// <returns>O objeto <see cref="Cachorro"/> mais velho, ou <c>null</c> se o canil estiver vazio.</returns>
    public Cachorro? BuscarMaisVelho()
    {
        // 1. Verificar se está vazio
        if (_repository.EstaVazio())
        {
            return null;
        }

        // 2. Inicializar candidato com primeiro da lista
        var cachorros = _repository.ListarTodos();

        // 3. Loop comparando idades
        var maisVelho = cachorros[0];
        foreach (var cachorro in cachorros)
        {
            if (cachorro.Idade > maisVelho.Idade)
            {
                maisVelho = cachorro;
            }
        }

        // 4. Retornar candidato final
        return maisVelho;
    }

    /// <summary>
    /// Localiza o cachorro mais novo do canil.
    /// </summary>
    /// <returns>Cachorro com menor idade ou <c>null</c>.</returns>
    public Cachorro? BuscarMaisNovo()
    {
        // Idêntico ao buscarMaisVelho, muda só a comparação
        if (_repository.EstaVazio())
        {
            return null;
        }

        var cachorros = _repository.ListarTodos();

        var menorIdade = cachorros[0];
        foreach (var cachorro in _repository.ListarTodos())
        {
            if (cachorro.Idade < menorIdade.Idade)
            {
                menorIdade = cachorro;
            }
        }

        return menorIdade;
    }

    /// <summary>
    /// Calcula a média de idade de todos os cachorros no canil.
    /// </summary>
    /// <returns>A média das idades como <c>double</c>.</returns>
    public double CalcularIdadeMedia()
    {
        if (_repository.EstaVazio())
        {
            return 0;
        }

        int total = _repository.QuantidadeTotal();
        int somaTotalIdade = 0;

        foreach (var listarTodo in _repository.ListarTodos())
        {
            somaTotalIdade += listarTodo.Idade;
        }

        double resultado = (double)somaTotalIdade / total;

        return resultado;
    }

    /// <summary>
    /// Filtra cachorros de acordo com a fase de vida informada.
    /// </summary>
    /// <param name="fase">Fase da vida (ex: <see cref="FaseVida.Filhote"/>).</param>
    /// <returns>Uma lista contendo apenas os cachorros daquela fase.</returns>
    public List<Cachorro> ListarPorFase(FaseVida fase)
    {
        // 1. Criar lista resultado vazia
        var faseDaVida = new List<Cachorro>();

        // 2. Loop pela lista
        foreach (var cachorro in _repository.ListarTodos())
        {
            if (cachorro.FaseDaVida() == fase)
            {
                faseDaVida.Add(cachorro);
            }
        }

        // 3. Se FaseDaVida() == fase → adicionar no resultado
        return faseDaVida;
        // 4. Retornar resultado
    }

    /// <summary>
    /// Exibe um painel consolidado com as principais estatísticas do canil.
    /// </summary>
    public void ExibirEstatisticas()
    {
        // Chama os métodos acima e exibe formatado
        MenuUtil.ExibirCabecalho("ESTATÍSTICAS DO CANIL");

        Console.WriteLine("TOTAL DE CACHORROS: " + _repository.QuantidadeTotal());

        Console.WriteLine($"IDADE MÉDIA: {CalcularIdadeMedia().ToString("F1", CultureInfo.InvariantCulture)}");

        var maisVelho = BuscarMaisVelho();

        if (maisVelho != null)
        {
            Console.WriteLine($"MAIS VELHO: {maisVelho.Nome} ({maisVelho.Idade} IDADE.)");
        }

        var maisNovo = BuscarMaisNovo();

        if (maisNovo != null)
        {
            Console.WriteLine($"MAIS NOVO: {maisNovo.Nome} ({maisNovo.Idade} IDADE.)");
        }

        Console.WriteLine("FILHOTES: " + ListarPorFase(FaseVida.Filhote).Count);
        Console.WriteLine("ADULTOS: " + ListarPorFase(FaseVida.Adulto).Count);
        Console.WriteLine("IDOSOS: " + ListarPorFase(FaseVida.Idoso).Count);
    }
}
