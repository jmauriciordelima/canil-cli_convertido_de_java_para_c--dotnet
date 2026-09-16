package Bpoo.projeto_canil.modelo;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

/**
 * Entidade que representa um cachorro cadastrado no sistema.
 * <p>
 * Contém informações básicas como nome, raça e idade,
 * além de regras de negócio relacionadas à fase da vida
 * e cálculos derivados da idade.
 *
 * @author José Maurício
 * @version 1.0
 */
public class Cachorro extends Animal implements Adotavel, Vacinavel {

    private String raca;
    private boolean disponivel = true;
    private List<String> vacinas = new ArrayList<>();

    /**
     * Construtor completo para a criação de uma nova instância de {@link Cachorro}.
     *
     * @param id    O identificador único do cachorro.
     * @param nome  O nome atribuído ao animal.
     * @param raca  A raça específica do animal.
     * @param idade A idade do animal em anos.
     */
    public Cachorro(int id, String nome, String raca, int idade) {
        super(id, nome, idade);
        this.raca = raca;
    }

    /**
     * Determina a fase da vida do cachorro com base na idade.
     *
     * @return Uma String indicando se é "Filhote", "Adulto" ou "Idoso".
     */
    @Override
    public FaseVida faseDaVida() {

        if (getIdade() > 10) {
            return FaseVida.IDOSO;
        } else if (getIdade() <= 10 && getIdade() > 2) {
            return FaseVida.ADULTO;
        } else {
            return FaseVida.FILHOTE;
        }

    }

    /**
     * Calcula a idade do cachorro em meses.
     *
     * @return idade total em meses.
     */
    private int calcularIdadeEmMeses() {
        return getIdade() * 12;
    }

    /**
     * Calcula a equivalência da idade do cachorro em anos humanos.
     * Considera a média comum de 7 anos humanos para cada ano canino.
     *
     * @return idade equivalente em anos humanos.
     */
    private int calcularIdadeHumana() {
        return getIdade() * 7;
    }

    /**
     * Exibe no console as informações detalhadas do cachorro,
     * incluindo cálculos de idade humana e meses.
     */
    @Override
    public void exibirInformacoes() {
        System.out.printf("""
                ID: %d\
                
                NOME: %s\
                
                IDADE: %d\
                
                FASE DA VIDA: %s\
                
                IDADE EM MESES: %d\
                
                IDADE HUMANA: %d\
                
                %s É UM %s DE %s\
                
                
                """, getId(), getNome(), getIdade(), faseDaVida(), calcularIdadeEmMeses(), calcularIdadeHumana(), getNome(), getRaca(), formatarMensagemIdade());
    }

    /**
     * Retorna a raça do cachorro.
     *
     * @return Uma String representando a raça.
     */
    public String getRaca() {
        return raca;
    }

    /**
     * Define a raça do cachorro.
     *
     * @param raca A nova raça a ser atribuída.
     */
    public void setRaca(String raca) {
        this.raca = raca;
    }

    /**
     * Retorna uma representação textual detalhada do objeto Cachorro.
     *
     * @return String contendo ID, nome, raça e idade do animal.
     */
    @Override
    public String toString() {
        return "CACHORRO [ID: " + getId() + ", NOME: " + getNome() + ", RAÇA: " + getRaca() + ", IDADE: " + getIdade() + "]";
    }

    /**
     * Compara este objeto com outro para verificar igualdade lógica.
     * Dois cachorros são considerados iguais se possuírem o mesmo ID.
     *
     * @param o Objeto a ser comparado.
     * @return {@code true} se os objetos forem iguais, {@code false} caso contrário.
     */
    @Override
    public boolean equals(Object o) {
        if (o == null || getClass() != o.getClass()) return false;
        Cachorro cachorro = (Cachorro) o;
        return getId() == cachorro.getId();
    }

    /**
     * Gera o código hash do objeto baseado no ID.
     *
     * @return O valor do hash code calculado a partir do ID.
     */
    @Override
    public int hashCode() {
        return Objects.hashCode(getId());
    }


    /**
     * Verifica se o animal está disponível para adoção.
     *
     * @return {@code true} se o animal estiver disponível, {@code false} caso contrário.
     */
    @Override
    public boolean estaDisponivel() {
        return disponivel;
    }

    /**
     * Define o status de disponibilidade do animal para adoção.
     *
     * @param disponivel O novo status de disponibilidade.
     */
    @Override
    public void setDisponivel(boolean disponivel) {
        this.disponivel = disponivel;
    }

    /**
     * Registra a aplicação de uma vacina no histórico do animal.
     *
     * @param nomeVacina O nome da vacina a ser registrada.
     */
    @Override
    public void aplicarVacina(String nomeVacina) {
        vacinas.add(nomeVacina);
    }

    /**
     * Retorna a lista de todas as vacinas aplicadas no animal.
     *
     * @return Uma lista contendo os nomes das vacinas aplicadas.
     */
    @Override
    public List<String> listarVacinas() {
        return vacinas;
    }
}
