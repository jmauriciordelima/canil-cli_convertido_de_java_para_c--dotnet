package Bpoo.projeto_canil.teste;

import Bpoo.projeto_canil.modelo.Adotavel;
import Bpoo.projeto_canil.modelo.Animal;
import Bpoo.projeto_canil.modelo.Cachorro;
import Bpoo.projeto_canil.modelo.Gato;

import java.util.ArrayList;
import java.util.List;

public class PolimorfismoTest {

    public static void main(String[] args) {

        List<Adotavel> adotaveis = new ArrayList<>();
        ArrayList<Animal> animais = new ArrayList<>();
        Animal cachorro = new Cachorro(5, "mel", "shin tzu", 1);
        Animal gato = new Gato(6, "melinda", 4, false);

        animais.add(cachorro);
        animais.add(gato);

        for (Animal animal : animais) {
            animal.exibirInformacoes();
        }

        Adotavel cachorroAdotavel = new Cachorro(7, "Toby", "SRD", 3);
        Adotavel gatoAdotavel = new Gato(8, "Laurinha", 4, false);

        System.out.println(cachorroAdotavel.getNome() + " está disponível? " + cachorroAdotavel.estaDisponivel());
        cachorroAdotavel.processoAdocao();
        System.out.println(cachorroAdotavel.getNome() + " está disponível? " + cachorroAdotavel.estaDisponivel());

        System.out.println(gatoAdotavel.getNome() + " está disponível? " + gatoAdotavel.estaDisponivel());
        gatoAdotavel.processoAdocao();
        System.out.println(gatoAdotavel.getNome() + " está disponível? " + gatoAdotavel.estaDisponivel());

        System.out.println("***---------------------***");

        adotaveis.add(cachorroAdotavel);
        adotaveis.add(gatoAdotavel);

        for (Adotavel adotavel : adotaveis) {
            adotavel.processoAdocao();
        }


        System.out.println("***---------------------***");

        Cachorro cachorroVacinavel = new Cachorro(9, "REX", "SRD", 1);
        Gato gatoVacinavel = new Gato(10, "Malú", 1, false);

        cachorroVacinavel.aplicarVacina("antirrábica");
        cachorroVacinavel.aplicarVacina("Vermífugos");
        cachorroVacinavel.aplicarVacina("polivalente");

        System.out.println(cachorroVacinavel.getNome() + " - Vacinas: " + cachorroVacinavel.listarVacinas());

        System.out.println("***---------------------***");

        gatoVacinavel.aplicarVacina("antirrábica");
        gatoVacinavel.aplicarVacina("Vermífugos");
        gatoVacinavel.aplicarVacina("polivalente");

        System.out.println(gatoVacinavel.getNome() + " - Vacinas: " + gatoVacinavel.listarVacinas());




    }
}