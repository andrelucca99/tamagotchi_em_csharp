using Tamagotchi_em_csharp.Controller;

public class Program
{
  static void Main(string[] args)
  {
    TamagotchiController tamagotchiController = new();
    tamagotchiController.Jogar();
  }
}