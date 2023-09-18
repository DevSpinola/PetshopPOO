using Petshop.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Petshop
{
    internal class Cadastro
    {
        List<Animal> listaAnimais = new List<Animal>();
        List<Veterinário> listaVet = new List<Veterinário>();
        List<ConsultaMedica> listaConsultas = new List<ConsultaMedica>();

        public void CadastrarAnimal()
        {
            //Método para cadastrar o pet -> animal
            Console.WriteLine("---> Cadastro de Animais <---");
            Console.Write("Digite o nome: ");
            string Nome = Console.ReadLine();

            Console.Write("Digite a espécie: ");
            string Especie = Console.ReadLine();

            Console.Write("Digite a raça: ");
            string Raca = Console.ReadLine();

            Console.Write("Digite a data de nascimento (Formato: dd/mm/aaaa): ");
            DateTime Datanasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o peso: ");
            float Peso = float.Parse(Console.ReadLine());
            Animal animal = new Animal
            {
                nome = Nome,
                especie = Especie,
                raca = Raca,
                datanasc = Datanasc,
                peso = Peso,
                dataInclusao = DateTime.Now
            };
            listaAnimais.Add(animal);
            Console.WriteLine("Animal Cadastrado com Sucesso!");

            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console

        }
        public void AlterarAnimal()
        {
            //Método para alterar dados no animal
            Console.WriteLine("---> Alteração de Cadastro do Animal <---");
            Console.WriteLine("Informe o nome do animal para consultar dados: ");
            string animal = Console.ReadLine().ToUpper();
            if (listaAnimais.Any(a => a.nome.ToUpper() == animal))
            {
                Animal animalEmAlteracao = listaAnimais.First((a => a.nome.ToUpper() == animal));
                Console.Write("Nome: ");
                animalEmAlteracao.nome = Console.ReadLine();

                Console.Write("Digite a espécie: ");
                animalEmAlteracao.especie = Console.ReadLine();

                Console.Write("Digite a raça: ");
                animalEmAlteracao.raca = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        Console.Write("Digite a data de nascimento (Formato: dd/mm/aaaa): ");
                        animalEmAlteracao.datanasc = DateTime.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Formato de Data Inválido, Tente Novamente");
                    }
                }


                Console.Write("Digite o peso: ");
                animalEmAlteracao.peso = float.Parse(Console.ReadLine());

                animalEmAlteracao.dataAlteracao = DateTime.Now;// hora do computador vai ser a dataAlteracao
                Console.WriteLine("Animal Alterado com sucesso");
                Console.WriteLine("Digite alguma tecla para voltar ao Menu");
                Console.ReadKey();
                Console.Clear();// Limpa o Console
            }
            else
            {
                Console.WriteLine($"Nenhum animal com o nome {animal} cadastrado.");
                Console.WriteLine("Pressione alguma tecla para voltar ao Menu");
                Console.ReadKey();
                Console.Clear();// Limpa o Console
            }

        }

        public void ConsultarAnimaisCadastrados()
        {
            listaAnimais.ForEach(animal =>
            {
                Console.WriteLine($"Nome: {animal.nome}, Espécie: {animal.especie}");
            });
        }
        public void ConsultarAnimal()
        {
            //método para consulta os dados
            Console.WriteLine("---> Consultar dados do animal <---");

            Console.WriteLine("Informe o nome do animal para consultar dados: ");
            string animal = Console.ReadLine().ToUpper();
            if (listaAnimais.Any(a => a.nome.ToUpper() == animal))
            {
                Animal AnimalASerListado = listaAnimais.First((a => a.nome.ToUpper() == animal));
                Console.WriteLine("Dados encontrados:");
                Console.WriteLine("Nome: " + AnimalASerListado.nome);
                Console.WriteLine("Data de Nascimento: " + AnimalASerListado.datanasc);
                Console.WriteLine($"Espécie: {AnimalASerListado.especie}");
                Console.WriteLine("Raça: " + AnimalASerListado.raca);
                Console.WriteLine("Peso: " + AnimalASerListado.peso);
                Console.WriteLine($"Data de Registro: {AnimalASerListado.dataInclusao}");
                if (AnimalASerListado.dataAlteracao != null) // Caso tenha dataAlteracao será apontada no console
                {
                    Console.WriteLine($"Ultima alteracão em: {AnimalASerListado.dataAlteracao}");
                }
                Console.WriteLine("Pressione alguma tecla para voltar ao Menu");
                Console.ReadKey();
                Console.Clear();// Limpa o Console
            }
            else
            {
                Console.WriteLine($"Nenhum animal com o nome {animal} cadastrado.");
                Console.WriteLine("Pressione alguma tecla para voltar ao Menu");
                Console.ReadKey();
                Console.Clear();// Limpa o Console
            }

        }
        public void ExcluirAnimal()
        {
            Console.WriteLine("Informe o nome do animal para excluir dados: ");
            string animal = Console.ReadLine().ToUpper();
            if (listaAnimais.Any(a => a.nome.ToUpper() == animal))
            {
                Console.WriteLine("Digite o nome do animal novamente para confirmar a exclusão:");
                if (animal == Console.ReadLine().ToUpper())
                {
                    listaAnimais.Remove(listaAnimais.First((a => a.nome.ToUpper() == animal)));
                }

            }
            else
            {
                Console.WriteLine($"Nenhum animal com o nome {animal} cadastrado.");
            }
        }

        public void AgendarConsulta()
        {
            Console.WriteLine("---->Agendamento Consulta<----");
            Console.WriteLine("Informe o nome do animal que irá a consulta");
            string animal = Console.ReadLine().ToUpper();
            if (listaAnimais.Any(a => a.nome.ToUpper() == animal))
            {
                Animal animalASerConsultado = listaAnimais.First((a => a.nome.ToUpper() == animal));
                Console.WriteLine("Informe a data desejada para agendar (dd/mm/aaaa): ");
                DateTime dataConsulta = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Informe o motivo da consulta: ");
                string motivoConsulta = Console.ReadLine();
                ConsultaMedica novaConsulta = new ConsultaMedica
                {
                    DataConsulta = dataConsulta,
                    MotivoConsulta = motivoConsulta,
                    Animal = animalASerConsultado,
                    Veterinario = listaVet.First(),
                    Concluida = false
                };
                listaConsultas.Add(novaConsulta);
                Console.WriteLine("Consulta Agendada com Sucesso!");
            }
            else
            {
                Console.WriteLine($"Não há nenhum animal com nome {animal} cadastrado");
            }
                        

            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();
        }

        //Metodo para registrar o decorrer da consulta
        public void RegistrarConsulta()
        {
            Console.WriteLine("---->Registro de Consulta do Pet<----");
            Console.WriteLine("Informe o nome do pet: ");
            string animal = Console.ReadLine().ToUpper();
            if (listaConsultas.Any(a => a.Animal.nome == animal))
            {
                ConsultaMedica consultaEmAlteracao = listaConsultas.First(a => a.Animal.nome == animal);
                consultaEmAlteracao.DataConsulta = DateTime.Now;
                Console.WriteLine("Data da Consulta: " + consultaEmAlteracao.DataConsulta);
                Console.WriteLine("Informe o tratamento indicado ou outro(s) procedimento(s):");
                consultaEmAlteracao.Tratamento = Console.ReadLine();
                consultaEmAlteracao.Concluida = true;
            }
            else
            {
                Console.WriteLine("Esse animal não existe ou não possui nenhuma consulta agendada");
            }
            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void ExibirConsulta()
        {
            Console.WriteLine("Informe o nome do pet: ");
            string animal = Console.ReadLine().ToUpper();
            if (listaConsultas.Any(a => a.Animal.nome == animal))
            {
                ConsultaMedica consultaEmExibicao = listaConsultas.First(a => a.Animal.nome == animal);
                Console.WriteLine($"Data da consulta: {consultaEmExibicao.DataConsulta}");
                Console.WriteLine($"Motivo da consulta: {consultaEmExibicao.MotivoConsulta}");
                Console.WriteLine($"Tratamento ou outros procedimentos: {consultaEmExibicao.Tratamento}");
                Console.WriteLine($"Veterinário responsável: {consultaEmExibicao.Veterinario.NomeVet}");
                Console.WriteLine(consultaEmExibicao.Concluida ? "Consulta concluída" : "Consulta ainda não concluída");
            }
            else
            {
                Console.WriteLine("Esse animal não existe ou não possui nenhuma consulta agendada");
            }
            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();

        }

    }
}
