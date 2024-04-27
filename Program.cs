using Newtonsoft.Json;
using RestSharp;

internal class Program
{
  private static void Main(string[] args)
  {
    void ExibirLogo()
    {
      Console.WriteLine(@"


▀▀█▀▀ █▀▀█ █▀▄▀█ █▀▀█ █▀▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █░░█ ░▀░ 
░▒█░░ █▄▄█ █░▀░█ █▄▄█ █░▀█ █░░█ ░░█░░ █░░ █▀▀█ ▀█▀ 
░▒█░░ ▀░░▀ ▀░░░▀ ▀░░▀ ▀▀▀▀ ▀▀▀▀ ░░▀░░ ▀▀▀ ▀░░▀ ▀▀▀
");
    }

    void ExibirOpcoesDoMenu()
    {
      ExibirLogo();
      Console.WriteLine("\n1- Listar pokemons");

      Console.Write("\nDigite a sua opção: ");
      string opcaoEscolhida = Console.ReadLine()!;
      int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

      switch (opcaoEscolhidaNumerica)
      {
        case 1:
          BuscarListaDePokemons();
          break;
        default:
          Console.WriteLine("Opção inválida");
          break;
      }
    }

    void BuscarListaDePokemons()
    {
      Console.Clear();

      var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
      RestRequest request = new RestRequest("", Method.Get);
      var response = client.Execute(request);

      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        dynamic? jsonResponse = JsonConvert.DeserializeObject(response.Content!);
        foreach (var pokemon in jsonResponse!.results)
        {
          Console.WriteLine(pokemon.name);
        }
      }
      else Console.WriteLine(response.ErrorMessage);
      Console.ReadKey();
    }

    ExibirOpcoesDoMenu();
  }
}