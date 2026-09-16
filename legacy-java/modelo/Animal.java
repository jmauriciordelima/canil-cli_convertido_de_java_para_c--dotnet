package Bpoo.projeto_canil.modelo;

public abstract class Animal {
    private int id;
    private String nome;
    private int idade;

    /**
     * Construtor para criação de um Animal.
     *
     * @param id    Identificador único persistido.
     * @param nome  Nome do animal.
     * @param idade Idade em anos.
     */
    public Animal(int id, String nome, int idade) {
        this.id = id;
        this.nome = nome;
        this.idade = idade;
    }

    /**
     * Retorna o id
     *
     * @return Um inteiro representando o id.
     */
    public int getId() {
        return id;
    }

    /**
     * @return nome do animal.
     */
    public String getNome() {
        return nome;
    }

    /**
     * Retorna a idade atual do Animal em anos.
     *
     * @return Um inteiro representando a idade.
     */
    public int getIdade() {
        return idade;
    }

    /**
     * Atualiza o id do animal.
     *
     * @param id Um novo id para o animal.
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * Define o nome do animal.
     *
     * @param nome novo nome.
     */
    public void setNome(String nome) {
        this.nome = nome;
    }

    /**
     * Atualiza a idade do animal.
     *
     * @param idade A nova idade a ser definida.
     */
    public void setIdade(int idade) {
        this.idade = idade;
    }

    /**
     * Realiza o aniversário do animal, incrementando sua idade.
     *
     * @return Uma mensagem formatada informando a nova idade.
     */
    public String fazerAniversario() {
        setIdade((getIdade() + 1));

        return String.format("%s FEZ ANIVERSÁRIO, SUA NOVA IDADE AGORA É %s", getNome(), formatarMensagemIdade());
    }

    /**
     * Formata a idade utilizando singular ou plural.
     *
     * @return idade formatada para exibição.
     */
    protected String formatarMensagemIdade() {
        if (getIdade() == 1) {
            return getIdade() + " ANO.";
        }

        return getIdade() + " ANOS.";
    }


    public abstract FaseVida faseDaVida();

    public abstract void exibirInformacoes();

}
