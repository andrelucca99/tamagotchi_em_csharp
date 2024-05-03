using Newtonsoft.Json;
using RestSharp;
using Tamagotchi_em_csharp.Model;

namespace Tamagotchi_em_csharp.Service;

public class PokemonService
{
  public List<PokemonResponseAPI> ObeterPokemons()
  {
    try
    {
      var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
      RestRequest request = new RestRequest("", Method.Get);
      var response = client.Execute(request);

      if (!response.IsSuccessful)
        Console.WriteLine($"Erro na requisição do Pokémon: {response.Content}");

      dynamic? jsonResponse = JsonConvert.DeserializeObject<PokemonSpecies>(response.Content!);
      return jsonResponse!.Results;

    }
    catch (Exception ex)
    {
      Console.WriteLine($"Erro: {ex.Message}");
      throw;
    }
  }

  public static PokemonDetails ObeterDetailsPokemon(PokemonResponseAPI pokemon)
  {
    try
    {
      var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon.Name}");
      RestRequest request = new RestRequest("", Method.Get);
      var response = client.Execute(request);

      if (!response.IsSuccessful)
        Console.WriteLine($"Erro na requisição do Pokémon: {response.Content}");

      return JsonConvert.DeserializeObject<PokemonDetails>(response.Content!)!;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Erro: {ex.Message}");
      throw;
    }
  }
}