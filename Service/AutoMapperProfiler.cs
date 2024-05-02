using AutoMapper;
using Tamagotchi_em_csharp.Model;

namespace Tamagotchi_em_csharp.Service;

public class AutoMapperProfiler : Profile
{
  public AutoMapperProfiler()
  {
    CreateMap<PokemonDetails, PokemonDTO>()
      .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
      .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.Height))
      .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.Weight))
      .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities!.Select(a => new Habilidade { Nome = a.Ability!.Name })));
  }
}

public class MascoteService
{
  private readonly IMapper _mapper;

  public MascoteService(IMapper mapper)
  {
    _mapper = mapper;
  }

  public PokemonDTO CriarPokemon(PokemonDetails pokemon)
  {
    return _mapper.Map<PokemonDTO>(pokemon);
  }
}