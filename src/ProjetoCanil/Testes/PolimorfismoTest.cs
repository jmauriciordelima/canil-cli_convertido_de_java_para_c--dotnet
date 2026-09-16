using ProjetoCanil.Modelo;

namespace ProjetoCanil.Testes;

/// <summary>
/// Demonstração dos conceitos de polimorfismo, interfaces e herança
/// implementados no sistema (equivalente ao <c>PolimorfismoTest</c> original em Java).
/// </summary>
public static class PolimorfismoTest
{
    /// <summary>
    /// Executa as demonstrações de polimorfismo, adoção e vacinação.
    /// </summary>
    public static void Executar()
    {
        var adotaveis = new List<IAdotavel>();
        var animais = new List<Animal>();
        Animal cachorro = new Cachorro(5, "mel", "shin tzu", 1);
        Animal gato = new Gato(6, "melinda", 4, false);

        animais.Add(cachorro);
        animais.Add(gato);

        foreach (var animal in animais)
        {
            animal.ExibirInformacoes();
        }

        IAdotavel cachorroAdotavel = new Cachorro(7, "Toby", "SRD", 3);
        IAdotavel gatoAdotavel = new Gato(8, "Laurinha", 4, false);

        Console.WriteLine($"{cachorroAdotavel.Nome} está disponível? {cachorroAdotavel.EstaDisponivel()}");
        cachorroAdotavel.ProcessoAdocao();
        Console.WriteLine($"{cachorroAdotavel.Nome} está disponível? {cachorroAdotavel.EstaDisponivel()}");

        Console.WriteLine($"{gatoAdotavel.Nome} está disponível? {gatoAdotavel.EstaDisponivel()}");
        gatoAdotavel.ProcessoAdocao();
        Console.WriteLine($"{gatoAdotavel.Nome} está disponível? {gatoAdotavel.EstaDisponivel()}");

        Console.WriteLine("***---------------------***");

        adotaveis.Add(cachorroAdotavel);
        adotaveis.Add(gatoAdotavel);

        foreach (var adotavel in adotaveis)
        {
            adotavel.ProcessoAdocao();
        }

        Console.WriteLine("***---------------------***");

        var cachorroVacinavel = new Cachorro(9, "REX", "SRD", 1);
        var gatoVacinavel = new Gato(10, "Malú", 1, false);

        cachorroVacinavel.AplicarVacina("antirrábica");
        cachorroVacinavel.AplicarVacina("Vermífugos");
        cachorroVacinavel.AplicarVacina("polivalente");

        Console.WriteLine($"{cachorroVacinavel.Nome} - Vacinas: [{string.Join(", ", cachorroVacinavel.ListarVacinas())}]");

        Console.WriteLine("***---------------------***");

        gatoVacinavel.AplicarVacina("antirrábica");
        gatoVacinavel.AplicarVacina("Vermífugos");
        gatoVacinavel.AplicarVacina("polivalente");

        Console.WriteLine($"{gatoVacinavel.Nome} - Vacinas: [{string.Join(", ", gatoVacinavel.ListarVacinas())}]");
    }
}
