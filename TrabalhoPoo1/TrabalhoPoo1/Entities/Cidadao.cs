using System;

namespace TrabalhoPoo1.Entities
{
    public class Cidadao
    {
        public int Id { get; set; }
        public int IdCadastrador { get; set; }
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Vacinado { get; set; }

        public bool Validar(){
            if(BandoDeDados.CadastradorBD.Find(c => c.Id == IdCadastrador) == null){
                Console.WriteLine("Não existe nenhuma prestadora com esse ID.");
                return false;
            }

            if(BandoDeDados.CidadaoBD.Find(c => c.Cpf == Cpf) != null){
                Console.WriteLine("Já existe um cidadão com esse CPF.");
                return false;
            }

            return true;
        }
    }
}