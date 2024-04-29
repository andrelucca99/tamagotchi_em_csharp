namespace Tamagotchi_em_csharp.Menu;

public class Menu
{
  public void MensagemInicial()
  {
    Console.WriteLine(@"
▀▀█▀▀ █▀▀█ █▀▄▀█ █▀▀█ █▀▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █░░█ ░▀░ 
░▒█░░ █▄▄█ █░▀░█ █▄▄█ █░▀█ █░░█ ░░█░░ █░░ █▀▀█ ▀█▀ 
░▒█░░ ▀░░▀ ▀░░░▀ ▀░░▀ ▀▀▀▀ ▀▀▀▀ ░░▀░░ ▀▀▀ ▀░░▀ ▀▀▀
");
    Console.Write("Digite seu nome: ");
    string? jogador = Console.ReadLine();
    Console.WriteLine($"\nSeja bem vindo(a)! {jogador}, esolha uma das opções abaixo: ");
  }

  public void ExibirOpcoesDoMenu()
  {
    Console.WriteLine("\n Menu Inicial");
    Console.WriteLine("\n1- Adotar um pokémon virtual");
    Console.WriteLine("\n2- Ver seus pokémons");
    Console.WriteLine("\n3- Sair");
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
    Console.WriteLine("\nMenu de adoção: ");
    Console.WriteLine("\n1 - Ver lista de pokémons");
    Console.WriteLine("\n2 - Ver detalhes do pokémon");
    Console.WriteLine("\n3 - Adotar pokémon");
    Console.WriteLine("\n4- Voltar ao menu inicial");
    Console.Write("\nDigite a sua opção: ");
  }

  public void ExibirListaDePokemons(List<PokemonResponseAPI> pokemons)
  {
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
    Console.WriteLine(@"𝘿𝙚𝙩𝙖𝙡𝙝𝙚𝙨 𝙙𝙤 𝙨𝙚𝙪 𝙥𝙤𝙠𝙚́𝙢𝙤𝙣:");
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
    Console.WriteLine("Pokémons Adotados:");

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