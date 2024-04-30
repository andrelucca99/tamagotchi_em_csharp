using Tamagotchi_em_csharp.Model;

namespace Tamagotchi_em_csharp.View;

public class TamagotchiView
{
  public void MensagemInicial()
  {
    Console.WriteLine(@"
▀▀█▀▀ █▀▀█ █▀▄▀█ █▀▀█ █▀▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █░░█ ░▀░ 
░▒█░░ █▄▄█ █░▀░█ █▄▄█ █░▀█ █░░█ ░░█░░ █░░ █▀▀█ ▀█▀ 
░▒█░░ ▀░░▀ ▀░░░▀ ▀░░▀ ▀▀▀▀ ▀▀▀▀ ░░▀░░ ▀▀▀ ▀░░▀ ▀▀▀
");
    Thread.Sleep(1500);
    Console.Write("Digite seu nome: ");
    string? jogador = Console.ReadLine();
    Console.WriteLine($"\nSeja bem vindo(a)! {jogador}, \nescolha uma das opções abaixo:");
  }

  public void ExibirOpcoesDoMenu()
  {
    Console.WriteLine();
    Console.WriteLine(@"
█▀▄▀█ █▀▀ █▄░█ █░█   █ █▄░█ █ █▀▀ █ ▄▀█ █░░
█░▀░█ ██▄ █░▀█ █▄█   █ █░▀█ █ █▄▄ █ █▀█ █▄▄");
    Console.WriteLine();
    Console.WriteLine("1- Adotar um pokémon virtual");
    Console.WriteLine("2- Ver seus pokémons");
    Console.WriteLine("3- Sair");
    Console.Write("\nDigite a sua opção: ");
  }

  public int OpcaoEscolhidaDoJogador()
  {
    int opcaoEscolhida = int.Parse(Console.ReadLine()!);

    if (opcaoEscolhida < 1 || opcaoEscolhida > 4)
      Console.WriteLine("Opção inválida.");

    return opcaoEscolhida;
  }

  public void MenuDeAdocaoDePokemons()
  {
    Console.WriteLine();
    Console.WriteLine(@"
█▀▄▀█ █▀▀ █▄░█ █░█   █▀▄ █▀▀   ▄▀█ █▀▄ █▀█ █▀▀ ▄▀█ █▀█ ▀
█░▀░█ ██▄ █░▀█ █▄█   █▄▀ ██▄   █▀█ █▄▀ █▄█ █▄▄ █▀█ █▄█ ▄");
    Console.WriteLine();
    Console.WriteLine("1 - Ver lista de pokémons");
    Console.WriteLine("2 - Ver detalhes do pokémon");
    Console.WriteLine("3 - Adotar pokémon");
    Console.WriteLine("4- Voltar ao menu inicial");
    Console.Write("\nDigite a sua opção: ");
  }

  public void ExibirListaDePokemons(List<PokemonResponseAPI> pokemons)
  {
    Console.Clear();
    Console.WriteLine(@"
█░░ █ █▀ ▀█▀ ▄▀█   █▀▄ █▀▀   █▀█ █▀█ █▄▀ █▀▀ █▀▄▀█ █▀█ █▄░█ █▀
█▄▄ █ ▄█ ░█░ █▀█   █▄▀ ██▄   █▀▀ █▄█ █░█ ██▄ █░▀░█ █▄█ █░▀█ ▄█");

    for (int i = 0; i < pokemons.Count; i++)
    {
      Console.WriteLine($"{(i + 1)}. {pokemons[i].Name}");
    }
  }

  public void ExibirDetailsDoPokemon(PokemonDetails details)
  {
    Console.Clear();
    Console.WriteLine(@"
█▀▄ █▀▀ ▀█▀ ▄▀█ █░░ █░█ █▀▀ █▀   █▀▄ █▀█   █▀ █▀▀ █░█   █▀█ █▀█ █▄▀ █▀▀ █▀▄▀█ █▀█ █▄░█ ▀
█▄▀ ██▄ ░█░ █▀█ █▄▄ █▀█ ██▄ ▄█   █▄▀ █▄█   ▄█ ██▄ █▄█   █▀▀ █▄█ █░█ ██▄ █░▀░█ █▄█ █░▀█ ▄");
    Console.WriteLine($"\nNome: {details!.Name}");
    Console.WriteLine($"Altura: {details!.Height}");
    Console.WriteLine($"Peso: {details!.Weight}");
    Console.WriteLine("Habilidades: ");
    foreach (var item in details.Abilities!)
    {
      Console.WriteLine($"- {item.Ability!.Name}");
    }
  }

  public bool ConfirmarAdocao()
  {
    Console.Write("\nVocê deseja adotar este pokémon? (s/n): ");
    string? resposta = Console.ReadLine();
    return resposta!.ToLower() == "s";
  }

  public void ExibirPokemonsAdotados(List<PokemonDetails> pokemonsAdotados)
  {
    Console.Clear();
    Console.WriteLine(@"
█▀█ █▀█ █▄▀ █▀▀ █▀▄▀█ █▀█ █▄░█ █▀   ▄▀█ █▀▄ █▀█ ▀█▀ ▄▀█ █▀▄ █▀█ █▀ ▀
█▀▀ █▄█ █░█ ██▄ █░▀░█ █▄█ █░▀█ ▄█   █▀█ █▄▀ █▄█ ░█░ █▀█ █▄▀ █▄█ ▄█ ▄");
    Console.WriteLine();

    if (pokemonsAdotados.Count == 0)
    {
      Console.WriteLine("Você ainda não adotou nenhum pokémon.");
    }
    else
    {
      for (int i = 0; i < pokemonsAdotados.Count; i++)
      {
        Console.WriteLine($"{(i + 1)}. {pokemonsAdotados[i].Name}");
      }
    }
  }

  public int ExibirPokemonEscolhido(List<PokemonResponseAPI> pokemon)
  {
    int escolha;
    while (true)
    {
      Console.Write($"Escolha um pokémon pelo numero (1- {pokemon.Count}): ");
      if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemon.Count) break;

      Console.WriteLine("Escolha inválida.");
    }

    return escolha - 1;
  }

  public void EncerraJogo()
  {
    Console.Clear();
    Console.WriteLine(@"
█▀▀ █ █▄░█ ▄▀█ █░░ █ ▀█ ▄▀█ █▄░█ █▀▄ █▀█   ░░█ █▀█ █▀▀ █▀█ ░ ░ ░
█▀░ █ █░▀█ █▀█ █▄▄ █ █▄ █▀█ █░▀█ █▄▀ █▄█   █▄█ █▄█ █▄█ █▄█ ▄ ▄ ▄");
    Thread.Sleep(3000);
    Console.Clear();
    Console.WriteLine(@"──────▄▀▄─────▄▀▄
─────▄█░░▀▀▀▀▀░░█▄
─▄▄──█░░░░░░░░░░░█──▄▄
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█" + @"
▀█▀ █▀▀ █░█ ▄▀█ █░█   ▄▀█ █▀▄▀█ █ █▀▀ █▀█ █
░█░ █▄▄ █▀█ █▀█ █▄█   █▀█ █░▀░█ █ █▄█ █▄█ ▄");
  }
}