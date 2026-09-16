package Bpoo.projeto_canil.modelo;

import java.util.List;

/**
 * Define o contrato para animais que podem receber vacinas.
 */
public interface Vacinavel {

    /**
     * Registra a aplicação de uma vacina.
     * @param nomeVacina nome da vacina aplicada.
     */
    void aplicarVacina(String nomeVacina);

    /**
     * Lista todas as vacinas aplicadas no animal.
     * @return lista de nomes das vacinas.
     */
    List<String> listarVacinas();
}
