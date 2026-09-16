package Bpoo.projeto_canil.modelo;

/**
 * Define o contrato para animais que podem ser adotados no sistema.
 */
public interface Adotavel {

    /**
     * Obtém o nome do animal.
     * @return nome do animal.
     */
    String getNome();

    /**
     * Verifica se o animal está disponível para adoção.
     * @return {@code true} se disponível, {@code false} caso contrário.
     */
    boolean estaDisponivel();

    /**
     * Atualiza o status de disponibilidade do animal.
     * @param disponivel novo status.
     */
    void setDisponivel(boolean disponivel);

    /**
     * Executa o processo de adoção, alterando o status para indisponível.
     */
    default void processoAdocao() {
        setDisponivel(false);
        System.out.println(getNome() + " FOI ADOTADO!");
    }
}
