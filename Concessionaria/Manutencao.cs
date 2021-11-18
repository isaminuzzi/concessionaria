using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    public class Manutencao
    {
        private string _nomeOficina;
        private string _dataManutencao;
        private string _pecas;
        //lista de manutenções
        List <string> Pecas = new List<string>();

        public string NomeOficina 
        {
            get{ return _nomeOficina; }
            set{_nomeOficina = value;}
        }
        public string DataManutecao
        {
            get { return _dataManutencao; }
            set { _dataManutencao = value; }
        }

        //construtor
        public Manutencao (string oficina, string data, List<string> manutencoes)
        {
            _nomeOficina = oficina;
            _dataManutencao = data;
            Pecas = manutencoes;
        }
        public override string ToString()
        {
            return "Nome da Oficina: " + _nomeOficina + "\nData de Manutenção: " + _dataManutencao + "\nPeças trocadas: " + string.Join(",  ", Pecas);
        }

    }
}
