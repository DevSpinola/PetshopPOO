using Petshop.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petshop
{
    internal class Cadastro
    {
        List<Animal> listaAnimais = new List<Animal>();
        List<Veterinário> listaVet = new List<Veterinário>();
        List<ConsultaMedica> listaConsultas = new List<ConsultaMedica>();
        // Metodos Animais --------------------------------------------------------------------------------------------------------------------------------
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
            Console.WriteLine("Informe o nome do animal para alterar dados: ");
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
            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
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
            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }
        // Metodos Consulta --------------------------------------------------------------------------------------------------------------------------------
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
        // Métodos Vet --------------------------------------------------------------------------------------------------------------------------------
        public void CadastrarVet()
        {
            Console.WriteLine("-->Cadastro de Veterinários<--");
            Console.WriteLine("Nome do veterinário: ");
            string nomeVet = Console.ReadLine();
            Console.WriteLine("Especialidade: ");
            string especialidade = Console.ReadLine();
            Console.WriteLine("Número do CRMV:");
            int CRMV = int.Parse(Console.ReadLine());
            Console.WriteLine("Dias da semana de trabalho: ");
            string diasTrabalho = Console.ReadLine();

            // Cria um objeto Veterinário com os dados informados pelo usuário.
            Veterinário veterinario = new Veterinário
            {
                NomeVet = nomeVet,
                Especialidade = especialidade,
                CRMV = CRMV,
                DiasTrabalho = diasTrabalho
            };

            // Adiciona o veterinário à lista de veterinários.
            listaVet.Add(veterinario);

            Console.WriteLine("Veterinário Cadastrado com Sucesso!");

            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

        public void ConsultarVet()
        {
            Console.WriteLine($"Nome do veterinário: ");
            string nomeVetConsulta = Console.ReadLine();

            // Verifica se um veterinário com o nome informado existe na lista.
            if (listaVet.Any(a => a.NomeVet == nomeVetConsulta))
            {
                // Encontra o primeiro veterinário com o nome informado.
                Veterinário veterinarioASerConsultado = listaVet.First(a => a.NomeVet == nomeVetConsulta);

                // Exibe os detalhes do veterinário encontrado.
                Console.WriteLine($"Nome:{veterinarioASerConsultado.NomeVet}");
                Console.WriteLine($"Especialidade: {veterinarioASerConsultado.Especialidade}");
                Console.WriteLine($"Número do CRMV: {veterinarioASerConsultado.CRMV}");
                Console.WriteLine($"Dias da semana de trabalho: {veterinarioASerConsultado.DiasTrabalho}");
            }
            else
            {
                Console.WriteLine($"Veterinário {nomeVetConsulta} não existe!");
            }

            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

        public void AlterarVet()
        {
            Console.WriteLine("--> Alteração de dados Veterinário <--");
            try
            {
                Console.WriteLine($"Nome do veterinário a ser alterado: ");
                string nomeVetConsulta = Console.ReadLine();

                // Verifica se um veterinário com o nome informado existe na lista.
                if (listaVet.Any(a => a.NomeVet == nomeVetConsulta))
                {
                    // Encontra o primeiro veterinário com o nome informado.
                    Veterinário veterinarioEmAlteracao = listaVet.First(a => a.NomeVet == nomeVetConsulta);                    

                    Console.WriteLine("Novo Nome: ");
                    veterinarioEmAlteracao.NomeVet = Console.ReadLine();
                    Console.WriteLine("Especialidade: ");
                    veterinarioEmAlteracao.Especialidade = Console.ReadLine();
                    Console.WriteLine("Número do CRMV:");
                    veterinarioEmAlteracao.CRMV = int.Parse(Console.ReadLine());
                    Console.WriteLine("Dias da semana de trabalho: ");
                    veterinarioEmAlteracao.DiasTrabalho = Console.ReadLine();
                    
                }
                else
                {
                    Console.WriteLine("Veterinário não existe!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de dados inválido");
            }

            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }
        public void ExcluirVet()
        {
            Console.WriteLine("--> Exclusão do Veterinário<--");
            Console.WriteLine($"Nome do veterinário a ser excluído: ");
            string nomeVetConsulta = Console.ReadLine();

            // Verifica se um veterinário com o nome informado existe na lista.
            if (listaVet.Any(a => a.NomeVet == nomeVetConsulta))
            {
                Console.WriteLine($"Digite {nomeVetConsulta} novamente para confirmar a exclusão");

                // Lê o nome novamente para confirmar a exclusão.
                if (nomeVetConsulta == Console.ReadLine())
                {
                    // Encontra o veterinário a ser excluído.
                    Veterinário veterinarioASerExcluido = listaVet.First(a => a.NomeVet == nomeVetConsulta);

                    // Remove o veterinário da lista e verifica se a remoção foi bem-sucedida.
                    bool removeu = listaVet.Remove(veterinarioASerExcluido);
                    Console.WriteLine(removeu ? "Veterinário removido com sucesso" : "O Veterinário não foi removido");
                }
            }
            else
            {
                Console.WriteLine("Veterinário não existe!");
            }

            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

        public void ConsultarVetCadastrados()
        {
            // Percorre a lista de veterinários e exibe seus nomes e especialidades.
            listaVet.ForEach(veterinario =>
            {
                Console.WriteLine($"Nome: {veterinario.NomeVet}, Especialidade: {veterinario.Especialidade}");
            });

            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

    }
}
