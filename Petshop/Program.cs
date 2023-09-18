using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Petshop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criando objeto da classe cadastro
            Cadastro cadastro = new Cadastro();           

            void MenuPrograma()
            {
                Console.WriteLine("---> Bem vindos ao PetShop da Villa <---");
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1 - Cadastrar animal");
                Console.WriteLine("2 - Consultar animal");
                Console.WriteLine("3 - Alterar animal");
                Console.WriteLine("4 - Excluir animal");
                Console.WriteLine("5 - Consultar todos os animais cadastrados");
                Console.WriteLine("6 - Sair do programa");
                int.TryParse(Console.ReadLine(), out int opcao);
                switch (opcao)
                {
                    case 1:
                        cadastro.CadastrarAnimal();
                        MenuPrograma();
                        break;

                    case 2:
                        cadastro.ConsultarAnimal();
                        MenuPrograma();
                        break;

                    case 3:
                        cadastro.AlterarAnimal();
                        MenuPrograma();
                        break;

                    case 4:
                        cadastro.ExcluirAnimal();
                        MenuPrograma();
                        break;
                    case 5:
                        cadastro.ConsultarAnimaisCadastrados();
                        break;
                    case 6:
                        Console.WriteLine("Obrigado por utilizar. Até logo!");                        
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        MenuPrograma();
                        break;
                }
            }
            MenuPrograma();

        }
    }
}
