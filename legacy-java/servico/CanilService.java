package Bpoo.projeto_canil.servico;

import Bpoo.projeto_canil.modelo.Cachorro;
import Bpoo.projeto_canil.modelo.FaseVida;
import Bpoo.projeto_canil.repositorio.CanilRepository;
import Bpoo.projeto_canil.util.MenuUtil;

import java.util.ArrayList;

/**
 * Camada responsável pelas regras de negócio.
 *
 * Realiza cálculos, filtros e estatísticas
 * utilizando os dados fornecidos pelo repositório.
 *
 * @author José Maurício
 * @version 1.0
 */
public class CanilService {

    private CanilRepository repository;

    /**
     * Cria uma instância do serviço.
     *
     * @param repository repositório utilizado pelo serviço.
     */
    public CanilService(CanilRepository repository) {
        this.repository = repository;
    }

    /**
     * Localiza o cachorro com a maior idade no canil.
     * @return O objeto {@link Cachorro} mais velho, ou {@code null} se o canil estiver vazio.
     */
    public Cachorro buscarMaisVelho() {
        // 1. Verificar se está vazio
        if (repository.estaVazio()) {
            return null;
        }
        // 2. Inicializar candidato com primeiro da lista
        ArrayList<Cachorro> cachorros = repository.listarTodos();
        // 3. Loop comparando idades
        Cachorro maisVelho = cachorros.get(0);
        for (Cachorro cachorro : cachorros) {
            if (cachorro.getIdade() > maisVelho.getIdade()) {
                maisVelho = cachorro;
            }
        }
        // 4. Retornar candidato final
        return maisVelho;

    }

    /**
     * Localiza o cachorro mais novo do canil.
     *
     * @return cachorro com menor idade ou null.
     */
    public Cachorro buscarMaisNovo() {
        // Idêntico ao buscarMaisVelho, muda só a comparação
        if (repository.estaVazio()) {
            return null;
        }

        ArrayList<Cachorro> cachorros = repository.listarTodos();

        Cachorro menorIdade = cachorros.get(0);
        for (Cachorro cachorro : repository.listarTodos()) {
            if (cachorro.getIdade() < menorIdade.getIdade()) {
                menorIdade = cachorro;
            }
        }

        return menorIdade;
    }

    /**
     * Calcula a média de idade de todos os cachorros no canil.
     * @return A média das idades como {@code double}.
     */
    public double calcularIdadeMedia() {

        if (repository.estaVazio()) {
            return 0;
        }

        int total = repository.quantidadeTotal();
        int somaTotalIdade = 0;

        for (Cachorro listarTodo : repository.listarTodos()) {
            somaTotalIdade += listarTodo.getIdade();
        }

        double resultado = (double) somaTotalIdade / total;

        return resultado;

    }

    /**
     * Filtra cachorros de acordo com a fase de vida informada.
     * @param fase Fase da vida (ex: "Filhote").
     * @return Uma lista contendo apenas os cachorros daquela fase.
     */
    public ArrayList<Cachorro> listarPorFase(FaseVida fase) {
        // 1. Criar lista resultado vazia
        ArrayList<Cachorro> faseDaVida = new ArrayList<>();
        // 2. Loop pela lista
        for (Cachorro cachorro : repository.listarTodos()) {
            if (cachorro.faseDaVida() == fase) {
                faseDaVida.add(cachorro);
            }
        }
        // 3. Se faseDaVida() == fase → adicionar no resultado
        return faseDaVida;
        // 4. Retornar resultado
    }

    /**
     * Exibe um painel consolidado com as principais estatísticas do canil.
     */
    public void exibirEstatisticas() {
        // Chama os métodos acima e exibe formatado
        MenuUtil.exibirCabecalho("ESTATÍSTICAS DO CANIL");

        System.out.println("TOTAL DE CACHORROS: " + repository.quantidadeTotal());

        System.out.printf("IDADE MÉDIA: %.1f" +
                "%n", calcularIdadeMedia());

        Cachorro maisVelho = buscarMaisVelho();

        if (maisVelho != null) {
            System.out.printf("MAIS VELHO: %s (%d IDADE.)%n",
                    maisVelho.getNome(),
                    maisVelho.getIdade());
        }

        Cachorro maisNovo = buscarMaisNovo();

        if (maisNovo != null) {
            System.out.printf("MAIS NOVO: %s (%d IDADE.)%n",
                    maisNovo.getNome(),
                    maisNovo.getIdade());
        }

        System.out.println("FILHOTES: " + listarPorFase(FaseVida.FILHOTE).size());
        System.out.println("ADULTOS: " + listarPorFase(FaseVida.ADULTO).size());
        System.out.println("IDOSOS: " + listarPorFase(FaseVida.IDOSO).size());
    }

}
