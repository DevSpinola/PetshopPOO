using Petshop.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Serviços
{
    internal class GerenciamentoVeterinario : GerenciamentoPetShop
    {
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
