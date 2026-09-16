using ProjetoCanil.Modelo;
using ProjetoCanil.Util;

namespace ProjetoCanil.Repositorio;

/// <summary>
/// Responsável pela persistência e gerenciamento dos dados dos cachorros.
/// <para>
/// Esta classe atua como a camada de acesso aos dados, gerenciando tanto a
/// lista em memória quanto a persistência em arquivos físicos.
/// Também é responsável por garantir a unicidade dos identificadores (IDs)
/// dos cachorros cadastrados.
/// </para>
/// </summary>
public class CanilRepository
{
    private int _proximoId = 1;
    private List<Cachorro> _cachorros;

    /// <summary>
    /// Construtor padrão que inicializa um repositório vazio.
    /// <para>
    /// Garante que a lista interna de cachorros esteja pronta para receber dados.
    /// </para>
    /// </summary>
    public CanilRepository()
    {
        _cachorros = new List<Cachorro>();
    }

    /// <summary>
    /// Adiciona um novo cachorro ao sistema.
    /// <para>
    /// Este método cria uma nova instância de <see cref="Cachorro"/> utilizando o identificador
    /// atual do sistema, incrementa o contador de IDs para a próxima inserção e
    /// armazena o objeto na lista de cachorros.
    /// </para>
    /// </summary>
    /// <param name="nome">O nome do cachorro a ser cadastrado.</param>
    /// <param name="raca">A raça do cachorro.</param>
    /// <param name="idade">A idade inicial do cachorro em anos.</param>
    public void Adicionar(string nome, string raca, int idade)
    {
        var cachorro = new Cachorro(_proximoId, nome, raca, idade);
        _proximoId++;
        _cachorros.Add(cachorro);
    }

    /// <summary>
    /// Recupera todos os cachorros armazenados.
    /// </summary>
    /// <returns>Uma lista contendo todos os cachorros.</returns>
    public List<Cachorro> ListarTodos()
    {
        return _cachorros;
    }

    /// <summary>
    /// Verifica se existem cachorros cadastrados.
    /// </summary>
    /// <returns><c>true</c> se não houver registros.</returns>
    public bool EstaVazio()
    {
        return _cachorros.Count == 0;
    }

    /// <summary>
    /// Retorna a quantidade total de cachorros.
    /// </summary>
    /// <returns>Número de registros cadastrados.</returns>
    public int QuantidadeTotal()
    {
        return _cachorros.Count;
    }

    /// <summary>
    /// Busca um cachorro pelo nome.
    /// </summary>
    /// <param name="nome">Nome para busca (case-insensitive).</param>
    /// <returns>O objeto Cachorro encontrado ou <c>null</c> caso não exista.</returns>
    public Cachorro? BuscarPorNome(string nome)
    {
        foreach (var c in _cachorros)
        {
            if (string.Equals(c.Nome, nome, StringComparison.OrdinalIgnoreCase))
            {
                return c;
            }
        }

        return null;
    }

    /// <summary>
    /// Remove um cachorro do repositório baseado no nome.
    /// </summary>
    /// <param name="nome">Nome do cachorro a ser removido.</param>
    /// <returns><c>true</c> se removido com sucesso, <c>false</c> caso contrário.</returns>
    public bool RemoverPorNome(string nome)
    {
        var c = BuscarPorNome(nome);

        if (c != null)
        {
            return _cachorros.Remove(c);
        }

        return false;
    }

    /// <summary>
    /// Salva todos os registros atuais em um arquivo texto especificado.
    /// <para>
    /// O formato de salvamento inclui o ID, nome, raça e idade do animal.
    /// </para>
    /// </summary>
    /// <param name="arquivoCachorros">O caminho ou nome do arquivo onde os dados serão salvos.</param>
    public void SalvarEmArquivo(string arquivoCachorros)
    {
        try
        {
            using var escrever = new StreamWriter(arquivoCachorros);

            foreach (var c in _cachorros)
            {
                escrever.WriteLine($"{c.Id};{c.Nome};{c.Raca};{c.Idade};");
            }

            MenuUtil.ExibirMensagemSucesso(" - ARQUIVO SALVO COM SUCESSO");
        }
        catch (IOException e)
        {
            MenuUtil.ExibirMensagemErro("ERRO AO SALVAR O ARQUIVO: " + e.Message);
        }
    }

    /// <summary>
    /// Carrega os registros persistidos de um arquivo texto.
    /// <para>
    /// Ao carregar, este método automaticamente atualiza o contador interno
    /// (<c>_proximoId</c>) para assegurar que novos registros continuem a
    /// sequência correta. Caso o arquivo não exista, retorna uma lista vazia.
    /// </para>
    /// </summary>
    /// <param name="arquivoCachorro">O caminho ou nome do arquivo de dados.</param>
    /// <returns>Uma lista contendo os cachorros carregados do arquivo.</returns>
    public List<Cachorro> CarregarDeArquivo(string arquivoCachorro)
    {
        _cachorros = new List<Cachorro>();

        if (!File.Exists(arquivoCachorro))
        {
            return _cachorros;
        }

        try
        {
            using var ler = new StreamReader(arquivoCachorro);

            string? linha;
            while ((linha = ler.ReadLine()) != null)
            {
                // RemoveEmptyEntries reproduz o comportamento do split do Java,
                // que descarta os campos vazios gerados pelo ';' final de cada linha.
                var dados = linha.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (dados.Length == 4)
                {
                    int id = int.Parse(dados[0]);
                    string nome = dados[1];
                    string raca = dados[2];
                    int idade = int.Parse(dados[3]);

                    _cachorros.Add(new Cachorro(id, nome, raca, idade));

                    if (id >= _proximoId)
                    {
                        _proximoId = id + 1;
                    }
                }
            }
        }
        catch (Exception e) when (e is IOException || e is FormatException)
        {
            MenuUtil.ExibirMensagemErro("ERRO AO LER O ARQUIVO: " + e.Message);
        }

        return _cachorros;
    }
}
