using System;
using System.Threading;
using TrabalhoPoo1.Entities;

namespace TrabalhoPoo1
{
    public static class Aplication
    {
        public static void CadastrarPrestadora()
        {
            var prestadora = new Prestadora();

            Console.WriteLine("Vamos cadastrar uma prestadora:"
                              + "\n1 - Continuar\n2 - Voltar");
            var decisao = Console.ReadLine().Trim();

            if (!VerificarDecisao(decisao)) return;

            prestadora.Id = BandoDeDados.PrestadoraBD.Count + 1;

            Console.WriteLine("Digite o CPNJ da empresa (Somente os números):");
            prestadora.Cnpj = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Digite o NOME da empresa:");
            prestadora.Nome = Console.ReadLine().Trim();

            if (!prestadora.Validar()) return;
            
            BandoDeDados.PrestadoraBD.Add(prestadora);
            
            Console.WriteLine("Prestadora cadastrada no sistema.");
            Thread.Sleep(2000);
        }

        public static void CadastrarCadastrador()
        {
            var cadastrador = new Cadastrador();

            Console.WriteLine("Vamos cadastrar um cadastrador:"
                              + "\n1 - Continuar\n2 - Voltar");
            var decisao = Console.ReadLine().Trim();

            if (!VerificarDecisao(decisao)) return;

            cadastrador.Id = BandoDeDados.CadastradorBD.Count + 1;

            Console.WriteLine("Digite o CPNJ da empresa (Somente os números):");
            var cnpj = int.Parse(Console.ReadLine().Trim());
            var prestadora = BandoDeDados.PrestadoraBD.Find(c => c.Cnpj == cnpj);

            if (prestadora == null)
            {
                Console.WriteLine("Não existe nenhuma prestadora com esse CNPJ");
                return;
            }

            cadastrador.IdPrestadora = prestadora.Id;

            Console.WriteLine("Digite o NOME do cadastrador:");
            cadastrador.Nome = Console.ReadLine().Trim();

            Console.WriteLine("Digite a MATRICULA do cadastrador:");
            cadastrador.Matricula = int.Parse(Console.ReadLine().Trim());

            if (!cadastrador.Validar()) return;
            
            BandoDeDados.CadastradorBD.Add(cadastrador);
            
            Console.WriteLine("Cadastrador cadastrada no sistema.");
            Thread.Sleep(2000);
        }

        public static void CadastrarCidadao()
        {
            var cidadao = new Cidadao();

            Console.WriteLine("Vamos cadastrar um cidadão:"
                              + "\n1 - Continuar\n2 - Voltar");
            var decisao = Console.ReadLine().Trim();

            if (!VerificarDecisao(decisao)) return;

            cidadao.Id = BandoDeDados.CidadaoBD.Count + 1;

            Console.WriteLine("Digite a MATRICULA do cadastrador:");
            var matricula = int.Parse(Console.ReadLine().Trim());
            var cadastrador = BandoDeDados.CadastradorBD.Find(c => c.Matricula == matricula);

            if (cadastrador == null)
            {
                Console.WriteLine("Não existe nenhum cadastrador com essa MATRICULA");
                return;
            }

            cidadao.IdCadastrador = cadastrador.Id;

            Console.WriteLine("Digite o NOME do cidadão:");
            cidadao.Nome = Console.ReadLine().Trim();

            Console.WriteLine("Digite a CPF do cidadão:");
            cidadao.Cpf = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Digite a IDADE do cidadão:");
            cidadao.Idade = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("O cidadão está vacinado?\n1 - Sim\n0 - Não");
            decisao = Console.ReadLine().Trim();

            cidadao.Vacinado = VerificarDecisao(decisao);

            if (!cidadao.Validar()) return;
            
            BandoDeDados.CidadaoBD.Add(cidadao);
            
            Console.WriteLine("Cidadão cadastrada no sistema.");
            Thread.Sleep(2000);
        }

        public static void MostrarPrestadores()
        {
            if (BandoDeDados.PrestadoraBD.Count > 0)
            {
                foreach (var prestadora in BandoDeDados.PrestadoraBD)
                {
                    Console.WriteLine();
                    Console.WriteLine("Id: " + prestadora.Id);
                    Console.WriteLine("CNPJ: " + prestadora.Cnpj);
                    Console.WriteLine("Nome: " + prestadora.Nome);
                }   
            }
            else
            {
                Console.WriteLine("Não foi cadastrado nenhum prestador ainda.");
            }
            
            var decisao = true;
            while (decisao)
            {
                Console.WriteLine("Digite 0 para voltar:");
                var decisaoUser = Console.ReadLine().Trim();
                if (decisaoUser == "0") decisao = false;
            }
        }
        
        public static void MostrarCadastradores()
        {
            if (BandoDeDados.CadastradorBD.Count > 0)
            {

                foreach (var cadastrador in BandoDeDados.CadastradorBD)
                {
                    Console.WriteLine();
                    Console.WriteLine("Id: " + cadastrador.Id);
                    Console.WriteLine("Matricula: " + cadastrador.Matricula);
                    Console.WriteLine("Nome: " + cadastrador.Nome);

                    var nomePrestadora = BandoDeDados.PrestadoraBD.Find(c => c.Id == cadastrador.IdPrestadora);
                    Console.WriteLine("IdPrestadora: " + cadastrador.IdPrestadora);
                    Console.WriteLine("Prestadora: " + nomePrestadora);
                }
            }
            else
            {
                Console.WriteLine("Não foi cadastrado nenhum cadastrador ainda.");
            }

            var decisao = true;
            while (decisao)
            {
                Console.WriteLine("Digite 0 para voltar:");
                var decisaoUser = Console.ReadLine().Trim();
                if (decisaoUser == "0") decisao = false;
            }
        }
        
        public static void MostrarCidadaos()
        {
            if (BandoDeDados.CidadaoBD.Count > 0)
            {

                foreach (var cidadao in BandoDeDados.CidadaoBD)
                {
                    Console.WriteLine();
                    Console.WriteLine("Id: " + cidadao.Id);
                    Console.WriteLine("CPF: " + cidadao.Cpf);
                    Console.WriteLine("Nome: " + cidadao.Nome);
                    Console.WriteLine("Idade: " + cidadao.Idade);
                    Console.WriteLine("Vacinado? " + cidadao.Vacinado);

                    var nomeCadastrador = BandoDeDados.CadastradorBD.Find(c => c.Id == cidadao.IdCadastrador);
                    Console.WriteLine("IdCadastrador: " + cidadao.IdCadastrador);
                    Console.WriteLine("Cadastrador: " + nomeCadastrador);
                }
            }
            else
            {
                Console.WriteLine("Não foi cadastrado nenhum cidadão ainda.");
            }

            var decisao = true;
            while (decisao)
            {
                Console.WriteLine("Digite 0 para voltar:");
                var decisaoUser = Console.ReadLine().Trim();
                if (decisaoUser == "0") decisao = false;
            }
        }

        static bool VerificarDecisao(string decisao)
        {
            switch (decisao)
            {
                case "0":
                    return false;
                case "1":
                    return true;
            }

            return false;
        }
    }
}