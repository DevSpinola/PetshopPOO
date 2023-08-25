using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Petshop
{
    class Animais
    {
        //Declaração de variáveis -> atributos
        private String nome;
        private DateTime datanasc;
        private String especie;
        private String raca;
        private float peso;
        private DateTime dataInclusao; // Adicionando atributos importantes para inclusao posterior em um BD 
        private Nullable<DateTime> dataAlteracao;

        public void cadastrar()
        {
            //Método para cadastrar o pet -> animal
            Console.WriteLine("---> Cadastro de Animais <---");
            Console.Write("Digite o nome: ");
            nome = Console.ReadLine();

            Console.Write("Digite a espécie: ");
            especie = Console.ReadLine();

            Console.Write("Digite a raça: ");
            raca = Console.ReadLine();

            Console.Write("Digite a data de nascimento (Formato: dd/mm/aaaa): ");
            datanasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o peso: ");
            peso = float.Parse(Console.ReadLine());

            dataInclusao = DateTime.Now;// Pega a hora do computador
            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

        public void alterar()
        {
            //Método para alterar dados no animal
            Console.WriteLine("---> Alteração de Cadastro do Animal <---");
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            Console.Write("Digite a espécie: ");
            especie = Console.ReadLine();

            Console.Write("Digite a raça: ");
            raca = Console.ReadLine();

            Console.Write("Digite a data de nascimento. \n Formato: dd/mm/aaaa");
            datanasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o peso: ");
            peso = float.Parse(Console.ReadLine());

            dataAlteracao = DateTime.Now;// hora do computador vai ser a dataAlteracao
            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

        public void consultar()
        {
            //método para consulta os dados
            Console.WriteLine("---> Consultar dados do animal <---");

            do
            {
                Console.WriteLine("Informe o nome do animal para consultar dados: ");
                string consultaAnimal = Console.ReadLine().ToUpper();

                if (consultaAnimal == nome.ToUpper())
                {
                    Console.WriteLine("Dados encontrados:");
                    Console.WriteLine("Nome: " + nome);
                    Console.WriteLine("Data de Nascimento: " + datanasc.Date);
                    Console.WriteLine($"Espécie: {especie}");
                    Console.WriteLine("Raça: " + raca);
                    Console.WriteLine("Peso: " + peso);
                    Console.WriteLine($"Data de Registro: {dataInclusao}");
                    if (dataAlteracao != null) // Caso tenha dataAlteracao será apontada no console
                    {
                        Console.WriteLine($"Ultima alteracão em: {dataAlteracao}");
                    }
                    Console.WriteLine("Digite alguma tecla para voltar ao Menu");
                    Console.ReadKey();
                    Console.Clear();// Limpa o Console
                    break;
                }
                else
                {
                    Console.WriteLine("Nenhum animal cadastrado.");
                }
            }while(true);


        }

        public void excluir()
        {
            //Método para excluir os dados do animal
            nome = null;
            especie = null;
            raca = null;
            peso = 0;
            datanasc = DateTime.MinValue;
            dataInclusao = DateTime.MinValue;// Limpa as Datas 
            dataAlteracao = null;
        }
     
    }
}
