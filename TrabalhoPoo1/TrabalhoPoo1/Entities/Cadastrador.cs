using System;

namespace TrabalhoPoo1.Entities
{
    public class Cadastrador
    {
        public int Id { get; set; }
        public int IdPrestadora { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }

        public bool Validar(){
            if(BandoDeDados.PrestadoraBD.Find(c => c.Id == IdPrestadora) == null){
                Console.WriteLine("Não existe nenhuma prestadora com esse ID.");
                return false;
            }

            if(BandoDeDados.CadastradorBD.Find(c => c.Matricula == Matricula) != null){
                Console.WriteLine("Já existe um cadastrador com essa MATRICULA.");
                return false;
            }

            return true;
        }
    }
}