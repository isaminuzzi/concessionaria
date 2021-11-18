using System;
using System.Collections.Generic;

namespace Concessionaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tSeja bem vindo(a) a Concessionária Vitual!");

            List<Carro> listaCarros = new List<Carro>();
            List<Manutencao> listaPecas = new List<Manutencao>();
            List<Cliente> clienteVenda = new List<Cliente>();
            bool sair = false;
            int id = 1;

            //laço de repetição com switch 
            while (!sair)
            {

                int opcao = Menu();
                switch (opcao)
                {
                    case 1:
                        insereCarro(listaCarros, id++);
                        break;
                    case 2:
                        pesquisa(listaCarros);
                        break;
                    case 3:
                        pesquisaKm(listaCarros);
                        break;
                    case 4:
                        filtrarStatus(listaCarros);
                        break;
                    case 5:
                        adicionaManutencao(listaPecas, listaCarros);
                        break;
                    case 6:
                        vendeCarro(listaCarros, clienteVenda);
                        break;
                    case 7:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente");
                        Menu();
                        break;
                }
            }
            //Menu de opções
            static int Menu()
            {
                Console.WriteLine("\n\n\t--------------------------------");
                Console.WriteLine("\n\t\tMENU DE OPÇÕES:\n");
                Console.WriteLine("\t1. Inserir novo carro." +
                    "\n\t2. Pesquisar carro por Modelo/Marca/Cor." +
                    "\n\t3. Pesquisar carro por quilômetros rodados." +
                    "\n\t4. Filtrar carros por status (em estoque/vendido)." +
                    "\n\t5. Adicionar manutenção em um dos carros." +
                    "\n\t6. Vender um carro." +
                    "\n\t7. Sair do menu");

                Console.WriteLine("\nQual opção deseja escolher?");
                //transformando de string para inteiro
                int opcaoMenu = Int32.Parse(Console.ReadLine());
                Console.Clear();

                return opcaoMenu;
            }
            //função de listar todos os carros inseridos
            static void listar(List<Carro> listaCarros)
            {
                listaCarros.ForEach(delegate (Carro carros)
                {
                    Console.WriteLine(carros);
                });
            }

            //função de inserir carro, incrementa o id
            static void insereCarro(List<Carro> listaCarros, int id)
            {
                Console.WriteLine("Digite o modelo do carro:");
                string _modelo = Console.ReadLine();
                Console.WriteLine("Digite a marca do carro:");
                string _marca = Console.ReadLine();
                Console.WriteLine("Digite a quantidade de quilômetros rodados:");
                string _kmRodado = Console.ReadLine();
                double kmDouble;
                //verificação do valor inserido - apenas numeros
                while (!double.TryParse(_kmRodado, out kmDouble))
                {
                    Console.WriteLine("Valor inválido! Tente novamente.");
                    _kmRodado = Console.ReadLine();
                }
                Console.WriteLine("Digite a cor do carro:");
                string _cor = Console.ReadLine();
                //adiciona informações na lista
                listaCarros.Add(new Carro(_modelo, _marca, kmDouble, _cor, id));
            }

            //função pesquisa por modelo, marca e cor
            static void pesquisa(List<Carro> listaCarros)
            {
                Console.WriteLine("Gostaria de pesquisar por:  \n1.Modelo \n2.Marca \n3.Cor");
                Console.WriteLine("Digite a sua opção: ");
                string opcao = Console.ReadLine();

                if (opcao.Equals("1"))
                {
                    Console.WriteLine("\nDigite a Modelo que esta buscando. ");
                    string pesquisaModelo = Console.ReadLine();
                    //lista local
                    List<Carro> carroModelo = new List<Carro>();
                    //lista recebendo o valor da busca - varrendo o carros.Modelo
                    carroModelo = listaCarros.FindAll(carros => carros.Modelo.Equals(pesquisaModelo));
                    Console.WriteLine(string.Join(",  ", carroModelo));
                    if (carroModelo.Count == 0)
                    {
                        Console.WriteLine("Não existe um carro com esse modelo.");
                    }
                }

                if(opcao.Equals("2"))
                {
                    Console.WriteLine("\nDigite a Marca que esta buscando. ");
                    string pesquisaMarca = Console.ReadLine();
                    //lista local
                    List<Carro> carroMarca = new List<Carro>();
                    //lista recebendo o valor da busca - varrendo o carros.Marca
                    carroMarca = listaCarros.FindAll(carros => carros.Marca.Equals(pesquisaMarca));
                    Console.WriteLine(string.Join(",  ", carroMarca));
                    if (carroMarca.Count == 0)
                    {
                        Console.WriteLine("Não existe um carro com a marca procurada.");
                    }
                }

                if (opcao.Equals("3"))
                {
                    Console.WriteLine("\nDigite a Cor que esta buscando. ");
                    //valor que usuário deseja buscar
                    string pesquisaCor = Console.ReadLine();
                    //lista local
                    List<Carro> carroCor = new List<Carro>();
                    //lista recebendo o valor da busca - varrendo o carros.Cor
                    carroCor = listaCarros.FindAll(carros => carros.Cor.Equals(pesquisaCor));
                    Console.WriteLine(string.Join(",  ", carroCor));
                    if(carroCor.Count == 0)
                    {
                        Console.WriteLine("Não existe um carro com a cor procurada.");
                    }
                }

            }

            static void pesquisaKm(List<Carro> listaCarros)
            {
                Console.WriteLine("Digite a quantidade máxima de quilometros rodados do carro: ");
                string pesquisaKm = Console.ReadLine();
                List<Carro> carroKm = new List<Carro>();
                carroKm = listaCarros.FindAll(carros => (carros.KmRodado <= Int32.Parse(pesquisaKm)));
                Console.WriteLine(string.Join(",  ", carroKm));
            }

            //função de filtrar por status - vendido ou em estoque
            //o carro inserido ja inicia com o status EM ESTOQUE
            static void filtrarStatus(List<Carro> listaCarros)
            {
                Console.WriteLine("Gostaria de filtrar por:  \n1.Vendidos \n2.Em estoque");
                Console.WriteLine("Digite a sua opção: ");
                string opcao = Console.ReadLine();

                if (opcao.Equals("1"))
                {
                    //lista local que armazena os carros vendidos
                    List<Carro> vendidos = new List<Carro>();
                    //se statusVendido (bool) for true - ja foi vendido
                    vendidos = listaCarros.FindAll(carros => carros.StatusVendido.Equals(true));
                    Console.WriteLine(string.Join(",  ", vendidos));
                }
                if (opcao.Equals("2"))
                {
                    //lista local que armazena os carros em estoque
                    List<Carro> estoque = new List<Carro>();
                    //se statusVendido (bool) for false - ainda nao foi vendido
                    estoque = listaCarros.FindAll(carros => carros.StatusVendido.Equals(false));
                    Console.WriteLine(string.Join(",  ", estoque));
                }

            }

            //função de adicionar manutenção em um carro ja inserido
            static void adicionaManutencao(List<Manutencao> pecas, List<Carro> listaCarros)
            { 
                //escolhe o carro por id
                Console.WriteLine("Escolha qual carro voce deseja adicionar manutenção.");
                //printa lista de todos os carros para o usuário decidir em qual vai adicionar manutenção
                listar(listaCarros);
                Console.WriteLine("Digite o ID do carro.");
                int idPesquisa = Int32.Parse(Console.ReadLine());
                //varre a lista buscando o carro pelo id inserido
                Carro carroManutencao = listaCarros.Find(carros => carros.Id == (idPesquisa));
                //coletando informações
                Console.WriteLine("Qual o nome da oficina?");
                string _nomeOficina = Console.ReadLine();
                Console.WriteLine("Qual a data da manutenção?");
                string _dataManutencao = Console.ReadLine();
                Console.WriteLine("Quantas peças foram trocadas?");
                //insere a quantidade de peças que foram trocadas
                int quantPecas = Int32.Parse(Console.ReadLine());
                List<string> pecasTrocadas = new List<string>();
                string pecasManutencao;
                //laço de repetição para inserir as peças
                for (int i = 0; i < quantPecas; i++)
                {
                    Console.WriteLine("Digite o nome da peça " + (i+1));
                    pecasManutencao = Console.ReadLine();
                    pecasTrocadas.Add(pecasManutencao);

                }
                //adiciona na lista de peças
                pecas.Add(new Manutencao(_nomeOficina, _dataManutencao, pecasTrocadas));
                carroManutencao.Manutencao = pecas;
                Console.WriteLine("");

                //printa na tela
                Console.WriteLine(string.Join(",  ", carroManutencao));
                for (int i = 0; i < pecas.Count; i++)
                {
                    Console.WriteLine(pecas[i]);
                }
                
            }

            //função de vender carro
            static void vendeCarro(List<Carro> listaCarros, List<Cliente> clienteVenda)
            {
                Console.WriteLine("Escolha qual carro voce deseja vender.");
                //lista todos os carros e o seu status
                listar(listaCarros);
                //selecona atraves do id
                Console.WriteLine("Digite o ID do carro.");
                int idPesquisa = Int32.Parse(Console.ReadLine());
                //busca na lista de carros atraves do id
                Carro carroVenda = listaCarros.Find(carros => carros.Id == idPesquisa);
                //altera o status do carro para VENDIDO
                carroVenda.StatusVendido = true;
                //insere nome e cpf do cliente que comprou o veiculo
                Console.WriteLine("Digite o nome do cliente:");
                string nomeCliente = Console.ReadLine();
                Console.WriteLine("Digite o CPF do cliente:");
                string cpf = Console.ReadLine();
                //adiciona as informaçoes
                clienteVenda.Add(new Cliente(nomeCliente, cpf));
                //printa na tela
                Console.WriteLine(string.Join(",  ", carroVenda));
                Console.WriteLine(string.Join(",  ", clienteVenda));

            }
        }
    }
}
