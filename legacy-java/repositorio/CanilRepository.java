package Bpoo.projeto_canil.repositorio;

import Bpoo.projeto_canil.modelo.Cachorro;
import Bpoo.projeto_canil.util.MenuUtil;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Responsável pela persistência e gerenciamento dos dados dos cachorros.
 * <p>
 * Esta classe atua como a camada de acesso aos dados, gerenciando tanto a
 * lista em memória quanto a persistência em arquivos físicos.
 * Também é responsável por garantir a unicidade dos identificadores (IDs)
 * dos cachorros cadastrados.
 * </p>
 *
 * @author José Maurício
 * @version 1.1
 */
public class CanilRepository {

    private int proximoId = 1;
    private ArrayList<Cachorro> cachorros;

    /**
     * Construtor padrão que inicializa um repositório vazio.
     * <p>
     * Garante que a lista interna de cachorros esteja pronta para receber dados.
     * </p>
     */
    public CanilRepository() {
        this.cachorros = new ArrayList<>();
    }

    /**
     * Adiciona um novo cachorro ao sistema.
     * <p>
     * Este método cria uma nova instância de {@link Cachorro} utilizando o identificador
     * atual do sistema, incrementa o contador de IDs para a próxima inserção e
     * armazena o objeto na lista de cachorros.
     * </p>
     *
     * @param nome  O nome do cachorro a ser cadastrado.
     * @param raca  A raça do cachorro.
     * @param idade A idade inicial do cachorro em anos.
     */
    public void adicionar(String nome, String raca, int idade) {
        Cachorro cachorro = new Cachorro(proximoId, nome, raca, idade);
        proximoId++;
        cachorros.add(cachorro);
    }

    /**
     * Recupera todos os cachorros armazenados.
     *
     * @return Uma {@link List} contendo todos os cachorros.
     */
    public ArrayList<Cachorro> listarTodos() {

        return cachorros;
    }

    /**
     * Verifica se existem cachorros cadastrados.
     *
     * @return true se não houver registros.
     */
    public boolean estaVazio() {

        return cachorros.isEmpty();
    }

    /**
     * Retorna a quantidade total de cachorros.
     *
     * @return número de registros cadastrados.
     */
    public int quantidadeTotal() {

        return cachorros.size();
    }

    /**
     * Busca um cachorro pelo nome.
     *
     * @param nome Nome para busca (case-insensitive).
     * @return O objeto Cachorro encontrado ou null caso não exista.
     */
    public Cachorro buscarPorNome(String nome) {

        for (Cachorro c : cachorros) {
            if (c.getNome().equalsIgnoreCase(nome)) {
                return c;
            }
        }
        return null;
    }

    /**
     * Remove um cachorro do repositório baseado no nome.
     *
     * @param nome Nome do cachorro a ser removido.
     * @return true se removido com sucesso, false caso contrário.
     */
    public boolean removerPorNome(String nome) {

        Cachorro c = buscarPorNome(nome);

        if (c != null) {
            return cachorros.remove(c);
        }

        return false;

    }

    /**
     * Salva todos os registros atuais em um arquivo texto especificado.
     * <p>
     * O formato de salvamento inclui o ID, nome, raça e idade do animal.
     * </p>
     *
     * @param arquivoCachorros O caminho ou nome do arquivo onde os dados serão salvos.
     */
    public void salvarEmArquivo(String arquivoCachorros) {
        try (PrintWriter escrever = new PrintWriter(new BufferedWriter(new FileWriter(arquivoCachorros)))) {
            for (Cachorro c : cachorros) {
                escrever.printf("%d;%s;%s;%d;%n",
                        c.getId(),
                        c.getNome(),
                        c.getRaca(),
                        c.getIdade());

            }

            MenuUtil.exibirMensagemSucesso(" - ARQUIVO SALVO COM SUCESSO");

        } catch (IOException e) {
            MenuUtil.exibirMensagemErro("ERRO AO SALVAR O ARQUIVO: " + e.getMessage());
        }
    }

    /**
     * Carrega os registros persistidos de um arquivo texto.
     * <p>
     * Ao carregar, este método automaticamente atualiza o contador interno
     * ({@code proximoId}) para assegurar que novos registros continuem a
     * sequência correta. Caso o arquivo não exista, retorna uma lista vazia.
     * </p>
     *
     * @param arquivoCachorro O caminho ou nome do arquivo de dados.
     * @return Uma lista contendo os cachorros carregados do arquivo.
     */
    public List<Cachorro> carregarDeArquivo(String arquivoCachorro) {
        this.cachorros = new ArrayList<>();
        File arquivo = new File(arquivoCachorro);

        if (!arquivo.exists()) {
            return cachorros;
        }

        try (BufferedReader ler = new BufferedReader(new FileReader(arquivo))) {
            String linha;
            while ((linha = ler.readLine()) != null) {
                String[] dados = linha.split(";");
                if (dados.length == 4) {
                    int id = Integer.parseInt(dados[0]);
                    String nome = dados[1];
                    String raca = dados[2];
                    int idade = Integer.parseInt(dados[3]);

                    cachorros.add(new Cachorro(id, nome, raca, idade));

                    if (id >= proximoId) {
                        proximoId = id + 1;
                    }
                }
            }

        } catch (IOException | NumberFormatException e) {
            MenuUtil.exibirMensagemErro("ERRO AO LER O ARQUIVO: " + e.getMessage());
        }
        return cachorros;
    }

}