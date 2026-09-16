package Bpoo.projeto_canil.modelo;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

/**
 * Representa um gato no sistema, estendendo a entidade base {@link Animal}.
 * <p>
 * Esta classe gerencia atributos específicos de felinos, como o estado de castração,
 * e implementa regras de negócio específicas para o cálculo da idade humana e
 * classificação da fase da vida.
 * </p>
 *
 * @author José Maurício
 * @version 1.0
 */
public class Gato extends Animal implements Adotavel, Vacinavel {

    /**
     * Indica se o gato passou pelo procedimento de castração.
     */
    private boolean castrado = false;
    private boolean disponivel = true;
    private List<String> vacinas = new ArrayList<>();

    /**
     * Construtor para inicializar um gato básico.
     *
     * @param id    Identificador único.
     * @param nome  Nome do gato.
     * @param idade Idade em anos.
     */
    public Gato(int id, String nome, int idade) {
        super(id, nome, idade);
    }

    /**
     * Construtor completo para inicializar um gato incluindo o status de castração.
     *
     * @param id       Identificador único.
     * @param nome     Nome do gato.
     * @param idade    Idade em anos.
     * @param castrado {@code true} se o animal for castrado, {@code false} caso contrário.
     */
    public Gato(int id, String nome, int idade, boolean castrado) {
        super(id, nome, idade);
        this.castrado = castrado;
    }

    /**
     * Calcula e retorna a fase da vida do gato baseada em sua idade.
     *
     * @return {@link FaseVida#FILHOTE}, {@link FaseVida#ADULTO} ou {@link FaseVida#IDOSO}.
     */
    @Override
    public FaseVida faseDaVida() {
        if (getIdade() <= 1) {
            return FaseVida.FILHOTE;
        } else if ((getIdade() > 1) && (getIdade() <= 10)) {
            return FaseVida.ADULTO;
        } else {
            return FaseVida.IDOSO;
        }
    }

    /**
     * Exibe no console as informações detalhadas do gato, incluindo
     * cálculos de idade humana e status de castração.
     */
    @Override
    public void exibirInformacoes() {
        System.out.printf("""
                ID: %d\
                
                NOME: %s\
                
                IDADE: %d\
                
                FASE DA VIDA: %s\
                
                CASTRADO?: %b\
                
                IDADE HUMANA: %d\
                
                %s É UM GATO DE %s\
                
                
                """, getId(), getNome(), getIdade(), faseDaVida(), isCastrado(), calcularIdadeHumana(), getNome(), formatarMensagemIdade());

    }

    /**
     * Calcula a equivalência da idade do gato em anos humanos, considerando
     * a aceleração do desenvolvimento nos primeiros anos de vida.
     *
     * @return idade equivalente em anos humanos.
     */
    public int calcularIdadeHumana() {
        if (getIdade() <= 1) {
            return 15;
        } else if (getIdade() == 2) {
            return 24;
        } else {
            return 24 + ((getIdade() - 2) * 4);
        }
    }

    /**
     * Verifica o status de castração.
     *
     * @return {@code true} se castrado, {@code false} caso contrário.
     */
    public boolean isCastrado() {
        return castrado;
    }

    /**
     * Define o status de castração.
     *
     * @param castrado novo status de castração.
     */
    public void setCastrado(boolean castrado) {
        this.castrado = castrado;
    }

    /**
     * Retorna a representação textual do objeto Gato.
     *
     * @return String formatada contendo o estado do objeto.
     */
    @Override
    public String toString() {
        return "GATO [ID: " + getId() + ", NOME: " + getNome() + ", CASTRADO: " + isCastrado() + ", IDADE: " + getIdade() + "]";
    }

    /**
     * Compara este objeto com outro para verificar igualdade lógica.
     * Dois gatos são considerados iguais se possuírem o mesmo ID.
     *
     * @param o Objeto a ser comparado.
     * @return {@code true} se os objetos forem iguais, {@code false} caso contrário.
     */
    @Override
    public boolean equals(Object o) {
        if (o == null || getClass() != o.getClass()) return false;
        Gato gato = (Gato) o;
        return getId() == gato.getId();
    }

    /**
     * Gera o código hash do objeto baseado no ID.
     *
     * @return hash code do ID.
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