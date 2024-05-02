namespace Tamagotchi_em_csharp.Model;

public class PokemonDTO
{
  public int Alimentacao { get; set; }
  public int Humor { get; set; }
  public int Energia { get; set; }
  public int Saude { get; set; }
  public int Altura { get; set; }
  public int Peso { get; set; }
  public string? Nome { get; set; }
  public List<Habilidade>? Habilidades { get; set; }

  public PokemonDTO()
  {
    var rand = new Random();
    Alimentacao = rand.Next(11);
    Humor = rand.Next(11);
    Energia = rand.Next(11);
    Saude = rand.Next(11);
  }

  public void Alimentar()
  {
    Alimentacao = Math.Min(Alimentacao + 2, 10);
    Energia = Math.Max(Energia - 1, 0);

    Console.WriteLine("Pokémon Alimentado!");
  }

  public void Brincar()
  {
    Humor = Math.Min(Humor + 3, 10);
    Energia = Math.Max(Energia - 2, 0);
    Alimentacao = Math.Max(Alimentacao - 1, 0);

    Console.WriteLine("Pokémon Feliz!");
  }

  public void Descansar()
  {
    Energia = Math.Min(Energia + 4, 10);
    Humor = Math.Max(Humor - 1, 0);

    Console.WriteLine("Pokémon Vai Dormir!");
  }

  public void DarCarinho()
  {
    Humor = Math.Min(Humor + 2, 10);
    Saude = Math.Min(Saude + 1, 10);

    Console.WriteLine("Pokémon Amado!");
  }

  public void MostrarStatus()
  {
    Console.WriteLine("Status do Mascote:");
    Console.WriteLine($"Alimentação: {Alimentacao}");
    Console.WriteLine($"Humor: {Humor}");
    Console.WriteLine($"Energia: {Energia}");
    Console.WriteLine($"Saúde: {Saude}");
  }
}

public class Habilidade
{
  public string? Nome { get; set; }
}