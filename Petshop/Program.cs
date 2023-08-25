using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criando objeto
            Animais obj = new Animais();

            bool continuar = true;

            while (continuar)
            {
                //Tela principal com menu
                Console.WriteLine("---> Bem vindos ao PetShop da Villa <---");
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1 - Cadastrar animal");
                Console.WriteLine("2 - Consultar animal");
                Console.WriteLine("3 - Alterar animal");
                Console.WriteLine("4 - Excluir animal");
                Console.WriteLine("5 - Sair do programa");

                int opcao = int.Parse(Console.ReadLine());
            
                switch (opcao)
                {
                    case 1:
                        obj.cadastrar();
                        break;

                    case 2:
                        obj.consultar();
                        break;

                    case 3:
                        obj.alterar();
                        break;

                    case 4:
                        obj.excluir();
                        break;

                    case 5:
                        Console.WriteLine("Obrigado por utilizar. Até logo!");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
