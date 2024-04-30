namespace Tamagotchi_em_csharp.Model;

public class PokemonSpecies
{
  public int Count { get; set; }
  public string? Next { get; set; }
  public string? Previous { get; set; }
  public List<PokemonResponseAPI>? Results { get; set; }
}