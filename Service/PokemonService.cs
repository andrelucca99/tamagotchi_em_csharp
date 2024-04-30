using Newtonsoft.Json;
using RestSharp;
using Tamagotchi_em_csharp.Model;

namespace Tamagotchi_em_csharp.Service;

public class PokemonService
{
  public List<PokemonResponseAPI> ObeterPokemons()
  {
    var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
    RestRequest request = new RestRequest("", Method.Get);
    var response = client.Execute(request);

    dynamic? jsonResponse = JsonConvert.DeserializeObject<PokemonSpecies>(response.Content!);

    return jsonResponse!.Results;
  }

  public static PokemonDetails ObeterDetailsPokemon(PokemonResponseAPI pokemon)
  {
    var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon.Name}");
    RestRequest request = new RestRequest("", Method.Get);
    var response = client.Execute(request);

    return JsonConvert.DeserializeObject<PokemonDetails>(response.Content!)!;
  }
}