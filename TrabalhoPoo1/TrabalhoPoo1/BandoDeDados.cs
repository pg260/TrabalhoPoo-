using System.Collections.Generic;
using TrabalhoPoo1.Entities;

namespace TrabalhoPoo1
{
    public static class BandoDeDados
    {
        public static List<Prestadora> PrestadoraBD { get; set; } = new List<Prestadora>();
        public static List<Cadastrador> CadastradorBD { get; set; } = new List<Cadastrador>();
        public static List<Cidadao> CidadaoBD { get; set; } = new List<Cidadao>();
    }
}