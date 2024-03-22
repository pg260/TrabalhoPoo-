using System;

namespace TrabalhoPoo1
{
    public class Menu
    {
        public void PrintMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(
                    "Qual operação você deseja realizar:\n6 - Cadastrar uma prestadora\n5 - Cadastrar um cadastrador\n4 - Cadastrar um cidadão\n3 - Mostrar prestadores Cadastrados\n2 - Mostrar cadastradores cadastrados\n1 - Mostrar cidadãos cadastrados\n0 - Sair");

                var decisao = Console.ReadLine().Trim();

                switch (decisao)
                {
                    case "6":
                    {
                        Console.Clear();
                        Aplication.CadastrarPrestadora();
                    }
                        break;
                    case "5":
                    {
                        Console.Clear();
                        Aplication.CadastrarCadastrador();
                    }
                        break;
                    case "4":
                    {
                        Console.Clear();
                        Aplication.CadastrarCidadao();
                    }
                        break;
                    case "3":
                    {
                        Console.Clear();
                        Aplication.MostrarPrestadores();
                    }
                        break;
                    case "2":
                    {
                        Console.Clear();
                        Aplication.MostrarCadastradores();
                    }
                        break;
                    case "1":
                    {
                        Console.Clear();
                        Aplication.MostrarCidadaos();
                    }
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                    {
                        Console.Clear();
                        PrintMenu();
                        break;
                    }
                }
            }
        }
    }
}