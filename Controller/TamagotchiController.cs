using Tamagotchi_em_csharp.Model;
using Tamagotchi_em_csharp.Service;
using Tamagotchi_em_csharp.View;

namespace Tamagotchi_em_csharp.Controller;

public class TamagotchiController
{
  private TamagotchiView menu { get; set; }
  private PokemonService pokemonService { get; set; }
  private List<PokemonResponseAPI> pokemonsDisponiveis { get; set; }
  private List<PokemonDetails> pokemonsAdotados { get; set; }

  public TamagotchiController()
  {
    menu = new TamagotchiView();
    pokemonService = new PokemonService();
    pokemonsDisponiveis = pokemonService.ObeterPokemons();
    pokemonsAdotados = new List<PokemonDetails>();
  }

  public void Jogar()
  {
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
                  Console.Clear();
                  Console.WriteLine($"{detalhes.Name}, EU ESCOLHO VOCÊ!!!");
                  Console.WriteLine($"Parabéns! Você acabou de adotar seu Pokémon");
                  Thread.Sleep(3000);
                  Console.Clear();
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