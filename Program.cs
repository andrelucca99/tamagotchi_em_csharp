using Newtonsoft.Json;
using RestSharp;

internal class Program
{
  protected static string Url { get; } = "https://pokeapi.co/api/v2/pokemon/";
  private static void Main(string[] args)
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
          BuscarListaDePokemons();
          break;
        case 2:
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

    void BuscarListaDePokemons()
    {
      Console.Clear();
      ExibirLogo(@"
█░░ █ █▀ ▀█▀ ▄▀█   █▀▄ █▀▀   █▀█ █▀█ █▄▀ █▀▀ █▀▄▀█ █▀█ █▄░█ █▀
█▄▄ █ ▄█ ░█░ █▀█   █▄▀ ██▄   █▀▀ █▄█ █░█ ██▄ █░▀░█ █▄█ █░▀█ ▄█");

      // var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
      var client = new RestClient(Url);
      RestRequest request = new RestRequest("", Method.Get);
      var response = client.Execute(request);

      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        dynamic? jsonResponse = JsonConvert.DeserializeObject(response.Content!);
        Console.WriteLine();

        int indice = 1;
        foreach (var pokemon in jsonResponse!.results)
        {
          Console.WriteLine($"{indice} - {pokemon.name}");
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

      var client = new RestClient($"{Url}{pokemon}");
      RestRequest request = new RestRequest("", Method.Get);
      var response = client.Execute(request);

      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        dynamic? jsonResponse = JsonConvert.DeserializeObject(response.Content!);
        Console.WriteLine($"Id: {jsonResponse!.id}");
        Console.WriteLine($"Nome: {jsonResponse!.name}");
        Console.WriteLine($"Tamanho: {jsonResponse!.height}");
        Console.WriteLine($"Largura: {jsonResponse!.weight}");
      }
      else Console.WriteLine(response.ErrorMessage);

      Console.Write("\nAperte a tecla 'ENTRE' para voltar ao menu principal");
      Console.ReadKey();
      Console.Clear();
      ExibirOpcoesDoMenu();
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