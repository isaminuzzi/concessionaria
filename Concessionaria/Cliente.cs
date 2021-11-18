using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    public class Cliente
    {
        private string _nome;
        private string _cpf;
        public string Nome { get; set; }
        public string CPF { get; set; }

        //construtor do cliente
        public Cliente(string nome, string cpf)
        {
            _nome = nome;
            _cpf = cpf;
        }

        public override string ToString()
        {
            return "\nNome: " + _nome + "\tCPF: " + _cpf;
        }
    }
}
