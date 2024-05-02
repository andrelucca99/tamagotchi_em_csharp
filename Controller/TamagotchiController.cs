using AutoMapper;
using Tamagotchi_em_csharp.Model;
using Tamagotchi_em_csharp.Service;
using Tamagotchi_em_csharp.View;

namespace Tamagotchi_em_csharp.Controller;

public class TamagotchiController
{
  private TamagotchiView menu { get; set; }
  private PokemonService pokemonService { get; set; }
  private List<PokemonResponseAPI> pokemonsDisponiveis { get; set; }
  private List<PokemonDTO> pokemonsAdotados { get; set; }

  IMapper mapper { get; set; }

  public TamagotchiController()
  {
    var config = new MapperConfiguration(cfg =>
    {
      cfg.AddProfile<AutoMapperProfiler>();
    });

    mapper = config.CreateMapper();

    menu = new TamagotchiView();
    pokemonService = new PokemonService();
    pokemonsDisponiveis = pokemonService.ObeterPokemons();
    pokemonsAdotados = new List<PokemonDTO>();
  }

  public void Jogar()
  {
    menu.MensagemInicial();

    while (true)
    {
      menu.ExibirOpcoesDoMenu();
      int escolha = menu.OpcaoEscolhidaDoJogador(4);

      switch (escolha)
      {
        case 1:
          while (true)
          {
            menu.MenuDeAdocaoDePokemons();
            escolha = menu.OpcaoEscolhidaDoJogador(4);
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
                  PokemonDTO newPokemon = mapper.Map<PokemonDTO>(detalhes);
                  pokemonsAdotados.Add(newPokemon);
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
          if (pokemonsAdotados.Count == 0)
          {
            Console.WriteLine("Você não tem nenhum pokémon adotado.");
            break;
          }

          Console.WriteLine("Escolha um pokémon para interagir");
          for (int i = 0; i < pokemonsAdotados.Count; i++)
          {
            Console.WriteLine($"{i + 1} - {pokemonsAdotados[i].Nome}");
          }

          int indicePokemon2 = menu.OpcaoEscolhidaDoJogador(pokemonsAdotados.Count) - 1;
          PokemonDTO pokemonEscolhido = pokemonsAdotados[indicePokemon2];

          int opcaoInteracao = 0;
          while (opcaoInteracao != 4)
          {
            menu.MostrarMenuInteracao();
            opcaoInteracao = menu.OpcaoEscolhidaDoJogador(4);

            switch (opcaoInteracao)
            {
              case 1:
                pokemonEscolhido.MostrarStatus();
                break;
              case 2:
                pokemonEscolhido.Alimentar();
                break;
              case 3:
                pokemonEscolhido.Brincar();
                break;
            }
          }
          break;
        case 3:
          menu.ExibirPokemonsAdotados(pokemonsAdotados);
          break;
        case 4:
          menu.EncerraJogo();
          return;
      }
    }
  }
}