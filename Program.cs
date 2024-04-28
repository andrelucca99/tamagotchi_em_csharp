using Newtonsoft.Json;
using RestSharp;
using Tamagotchi_em_csharp;

public class Program
{
  protected static string Url { get; } = "https://pokeapi.co/api/v2/pokemon/";
  public static void Main(string[] args)
  {
    void ExibirLogo(string logo)
    {
      Console.WriteLine($@"{logo}");
    }

    void ExibirOpcoesDoMenu()
    {
      ExibirLogo(@"
▀▀█▀▀ █▀▀█ █▀▄▀█ █▀▀█ █▀▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █░░█ ░▀░ 
░▒█░░ █▄▄█ █░▀░█ █▄▄█ █░▀█ █░░█ ░░█░░ █░░ █▀▀█ ▀█▀ 
░▒█░░ ▀░░▀ ▀░░░▀ ▀░░▀ ▀▀▀▀ ▀▀▀▀ ░░▀░░ ▀▀▀ ▀░░▀ ▀▀▀
");
      Console.WriteLine("\n1- Lista de pokémons");
      Console.WriteLine("\n2- Buscar pokémon");
      Console.WriteLine("\n3- Sair");

      Console.Write("\nDigite a sua opção: ");
      string opcaoEscolhida = Console.ReadLine()!;
      int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

      switch (opcaoEscolhidaNumerica)
      {
        case 1:
          ListaDePokemons();
          break;
        case 2:
          Console.Clear();
          Console.Write("Digite o Id ou Nome do pokemon: ");
          BuscarPokemon(Console.ReadLine()!);
          break;
        case 3:
          EncerraJogo();
          break;
        default:
          Console.WriteLine("Opção inválida");
          break;
      }
    }

    void ListaDePokemons()
    {
      Console.Clear();
      ExibirLogo(@"
█░░ █ █▀ ▀█▀ ▄▀█   █▀▄ █▀▀   █▀█ █▀█ █▄▀ █▀▀ █▀▄▀█ █▀█ █▄░█ █▀
█▄▄ █ ▄█ ░█░ █▀█   █▄▀ ██▄   █▀▀ █▄█ █░█ ██▄ █░▀░█ █▄█ █░▀█ ▄█");

      var client = new RestClient(Url);
      RestRequest request = new RestRequest("", Method.Get);
      var response = client.Execute(request);

      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        dynamic? jsonResponse = JsonConvert.DeserializeObject<PokemonSpecies>(response.Content!);
        Console.WriteLine("\n");

        int indice = 1;
        foreach (var pokemon in jsonResponse!.Results)
        {
          Console.WriteLine($"{indice} - {pokemon.Name}");
          indice++;
        }
      }
      else Console.WriteLine(response.ErrorMessage);

      Console.Write("\nDigite o número ou nome do pokemon para mais detalhes: ");
      BuscarPokemon(Console.ReadLine()!);
    }

    void BuscarPokemon(string pokemon)
    {
      Console.Clear();
      ExibirLogo(@"
█▀▄ ▄▀█ █▀▄ █▀█ █▀   █▀▄ █▀█   █▀█ █▀█ █▄▀ █▀▀ █▀▄▀█ █▀█ █▄░█
█▄▀ █▀█ █▄▀ █▄█ ▄█   █▄▀ █▄█   █▀▀ █▄█ █░█ ██▄ █░▀░█ █▄█ █░▀█");

      Console.WriteLine("\n");
      var client = new RestClient($"{Url}{pokemon}");
      RestRequest request = new RestRequest("", Method.Get);
      var response = client.Execute(request);

      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        dynamic? jsonResponse = JsonConvert.DeserializeObject<PokemonDetails>(response.Content!);
        ExibirDetailsDoPokemon(jsonResponse!);
      }
      else Console.WriteLine(response.ErrorMessage);

      Console.Write("\nAperte a tecla 'ENTRE' para voltar ao menu principal");
      Console.ReadKey();
      Console.Clear();
      ExibirOpcoesDoMenu();
    }

    void ExibirDetailsDoPokemon(dynamic pokemon)
    {
      Console.WriteLine($"'{pokemon!.Name}', eu escolho você!!! \n");
      ExibirLogo(@"𝘿𝙚𝙩𝙖𝙡𝙝𝙚𝙨 𝙙𝙤 𝙨𝙚𝙪 𝙥𝙤𝙠𝙚́𝙢𝙤𝙣:");
      Console.WriteLine($"Nome: {pokemon!.Name}");
      Console.WriteLine($"Altura: {pokemon!.Height}");
      Console.WriteLine($"Peso: {pokemon!.Weight}");
      Console.WriteLine("Habilidades: ");
      foreach (var item in pokemon!.Abilities)
      {
        Console.WriteLine($"- {item.Ability.Name}");
      }
    }

    void EncerraJogo()
    {
      Console.Clear();
      ExibirLogo(@"
█▀▀ █ █▄░█ ▄▀█ █░░ █ ▀█ ▄▀█ █▄░█ █▀▄ █▀█   ░░█ █▀█ █▀▀ █▀█ ░ ░ ░
█▀░ █ █░▀█ █▀█ █▄▄ █ █▄ █▀█ █░▀█ █▄▀ █▄█   █▄█ █▄█ █▄█ █▄█ ▄ ▄ ▄");
      Thread.Sleep(3000);
      Console.Clear();
      ExibirLogo(@"──────▄▀▄─────▄▀▄
─────▄█░░▀▀▀▀▀░░█▄
─▄▄──█░░░░░░░░░░░█──▄▄
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█" + @"
▀█▀ █▀▀ █░█ ▄▀█ █░█   ▄▀█ █▀▄▀█ █ █▀▀ █▀█ █
░█░ █▄▄ █▀█ █▀█ █▄█   █▀█ █░▀░█ █ █▄█ █▄█ ▄");
    }

    ExibirOpcoesDoMenu();
  }
}