using System;

namespace TrabalhoPoo1.Entities
{
    public class Prestadora
    {
        public int Id { get; set; }
        public int Cnpj { get; set; }
        public string Nome { get; set; }

        public bool Validar(){
            if(BandoDeDados.PrestadoraBD.Find(c => c.Cnpj == Cnpj) != null){
                Console.WriteLine("Já existe uma prestadora com esse CNPJ.");
                return false;
            }

            return true;
        }
    }
}