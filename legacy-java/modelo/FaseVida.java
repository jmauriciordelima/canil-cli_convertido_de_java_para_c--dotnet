package Bpoo.projeto_canil.modelo;


/**
 * Define as categorias de faixa etária para os animais do canil.
 * <p>
 * Esta enumeração é utilizada para classificar os cachorros com base em sua idade,
 * auxiliando na aplicação de regras de negócio específicas para cada estágio de vida.
 * </p>
 *
 * @author José Maurício
 * @version 1.0
 */
public enum FaseVida {

    /**
     * Representa cachorros em estágio inicial de desenvolvimento.
     * Geralmente aplicado para idades até 2 anos.
     */
    FILHOTE,

    /**
     * Representa cachorros em sua fase madura.
     * Geralmente aplicado para idades entre 3 e 10 anos.
     */
    ADULTO,

    /**
     * Representa cachorros em estágio avançado de idade.
     * Geralmente aplicado para idades acima de 10 anos.
     */
    IDOSO;

}
