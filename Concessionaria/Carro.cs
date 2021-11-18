using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    public class Carro
    {
        private string _modelo;
        private string _marca;
        private double _kmRodado;
        private string _cor;
        private bool _vendido = false;
        private int _id;
        private Cliente _vendidoPara;
        private List<Manutencao> _manutencao;


        public string Modelo 
        { 
            get { return _modelo; }
            set { _modelo = value; }
        }
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        public double KmRodado 
        {
            get { return _kmRodado; } 
            set { _kmRodado = value; }
        }
        public string Cor 
        {
            get { return _cor; } 
            set { _cor = value; }
        }
        public bool StatusVendido
        {
            get { return _vendido; }
            set { _vendido = value; }
        }

        public Cliente VendidoPara 
        {
            get { return _vendidoPara; } 
            set { _vendidoPara = VendidoPara; }
        }
        public int Id 
        {
            get { return _id; }
            set { _id = value; }
        }
        public List <Manutencao> Manutencao 
        {
            get { return _manutencao; }
            set { _manutencao = value; } 
        }

        //construtor do carro - define as variéveis de entrada
        public Carro(string modelo, string marca, double kmRodado, string cor, int id)
        {
            _modelo = modelo;
            _marca = marca;
            _kmRodado = kmRodado;
            _cor = cor;
            _id = id;
        }

        //metodo com sobrecarga - parametros a mais (lista de manutenção)
        public Carro(string modelo, string marca, double kmRodado, string cor, int id, List<Manutencao> manutencao)
        {
            _modelo = modelo;
            _marca = marca;
            _kmRodado = kmRodado;
            _cor = cor;
            _id = id;
            _manutencao = manutencao;
        }

        public override string ToString()
        {
            return "\nModelo: " + _modelo + "\nMarca: " + _marca + "\nQuilometros Rodados: " + _kmRodado + "\nCor: " + _cor + "\nId:" + Id + "\nStatus - " + $"{(StatusVendido == false ? "Em estoque " : "Vendido para: ")}" + (string.Join(",  ", VendidoPara));
        }

    }
}
