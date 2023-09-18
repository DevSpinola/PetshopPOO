using System;
using System.Threading;


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
                Console.Clear();
                Console.WriteLine("---> Bem vindos ao PetShop da Villa <---");
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1 - Acessar aba Animais");
                Console.WriteLine("2 - Acessar aba Veterinario");
                Console.WriteLine("3 - Acessar aba Consulta Medica");
                Console.WriteLine("4 - Sair do programa");
                int.TryParse(Console.ReadLine(), out int opcao);
                switch (opcao)
                {
                    case 1:
                        MenuAnimal();
                        break;

                    case 2:
                        MenuVeterinario();
                        break;

                    case 3:
                        MenuConsulta();
                        break;

                    case 4:
                        Console.WriteLine("Obrigado por utilizar. Até logo!");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        MenuPrograma();
                        break;
                }
            }
            void MenuAnimal()
            {
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1 - Cadastrar animal");
                Console.WriteLine("2 - Consultar animal");
                Console.WriteLine("3 - Alterar animal");
                Console.WriteLine("4 - Excluir animal");
                Console.WriteLine("5 - Consultar todos os animais cadastrados");
                Console.WriteLine("6 - Voltar ao Menu Principal");
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
                        MenuPrograma();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        MenuPrograma();
                        break;
                }
                MenuPrograma();

            }
            void MenuVeterinario()
            {
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1 - Cadastrar Veterinario");
                Console.WriteLine("2 - Consultar Veterinario");
                Console.WriteLine("3 - Alterar Veterinario");
                Console.WriteLine("4 - Excluir Veterinario");
                Console.WriteLine("5 - Consultar todos os Veterinarios cadastrados");
                Console.WriteLine("6 - Voltar ao Menu Principal");
                int.TryParse(Console.ReadLine(), out int opcao);
                switch (opcao)
                {
                    case 1:
                        cadastro.CadastrarVet();
                        MenuPrograma();
                        break;

                    case 2:
                        cadastro.ConsultarVet();
                        MenuPrograma();
                        break;

                    case 3:
                        cadastro.AlterarVet();
                        MenuPrograma();
                        break;

                    case 4:
                        cadastro.ExcluirVet();
                        MenuPrograma();
                        break;
                    case 5:
                        cadastro.ConsultarVetCadastrados();
                        MenuPrograma();
                        break;
                    case 6:
                        MenuPrograma();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        MenuPrograma();
                        break;
                }

            }
            void MenuConsulta()
            {
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1 - Agendar Consulta");
                Console.WriteLine("2 - Registrar Consulta");
                Console.WriteLine("3 - Exibir Consulta");
                Console.WriteLine("4 - Voltar ao Menu Principal");
                int.TryParse(Console.ReadLine(), out int opcao);
                switch (opcao)
                {
                    case 1:
                        cadastro.AgendarConsulta();
                        MenuPrograma();
                        break;
                    case 2:
                        cadastro.RegistrarConsulta();
                        MenuPrograma();
                        break;
                    case 3:
                        cadastro.ExibirConsulta();
                        MenuPrograma();
                        break;
                    case 4:
                        MenuPrograma();
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
