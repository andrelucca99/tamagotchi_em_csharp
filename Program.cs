using Newtonsoft.Json;
using RestSharp;
using Tamagotchi_em_csharp;
using Tamagotchi_em_csharp.Menu;

public class Program
{
  static void Main(string[] args)
  {

    Menu menu = new();
    PokemonService pokemonService = new();
    List<PokemonResponseAPI> pokemonsDisponiveis = pokemonService.ObeterPokemons();
    List<PokemonDetails> pokemonsAdotados = new List<PokemonDetails>();

    menu.MensagemInicial();

    while (true)
    {
      menu.ExibirOpcoesDoMenu();
      int escolha = menu.OpcaoEscolhidaDoJogador();

      switch (escolha)
      {
        case 1:
          while (true)
          {
            menu.MenuDeAdocaoDePokemons();
            escolha = menu.OpcaoEscolhidaDoJogador();
            switch (escolha)
            {
              case 1:
                menu.ExibirListaDePokemons(pokemonsDisponiveis);
                break;
              case 2:
                menu.ExibirListaDePokemons(pokemonsDisponiveis);
                int indicePokemon = menu.ExibirPokemonEscolhido(pokemonsDisponiveis);
                PokemonDetails detalhes = PokemonService.ObeterDetailsPokemon(pokemonsDisponiveis[indicePokemon]);
                menu.ExibirDetailsDoPokemon(detalhes);
                break;
              case 3:
                menu.ExibirListaDePokemons(pokemonsDisponiveis);
                indicePokemon = menu.ExibirPokemonEscolhido(pokemonsDisponiveis);
                detalhes = PokemonService.ObeterDetailsPokemon(pokemonsDisponiveis[indicePokemon]);
                menu.ExibirDetailsDoPokemon(detalhes);
                if (menu.ConfirmarAdocao())
                {
                  pokemonsAdotados.Add(detalhes);
                  Console.WriteLine($"{detalhes.Name}, EU ESCOLHO VOCÊ!!!");
                  Console.WriteLine($"Parabéns! Você acabou de adotar seu Pokémon");
                }
                break;
              case 4:
                break;
            }
            if (escolha == 4) break;
          }
          break;
        case 2:
          menu.ExibirPokemonsAdotados(pokemonsAdotados);
          break;
        case 3:
          menu.EncerraJogo();
          return;
      }
    }
  }
}