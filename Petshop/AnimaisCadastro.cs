using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop
{
    internal class AnimaisCadastro 
    {
        List<Animal> lista = new List<Animal>();

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
            lista.Add(animal);
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
            if (lista.Any(a => a.nome.ToUpper() == animal))
            {
                Animal animalEmAlteracao = lista.First((a => a.nome.ToUpper() == animal));
                Console.Write("Nome: ");
                animalEmAlteracao.nome = Console.ReadLine();

                Console.Write("Digite a espécie: ");
                animalEmAlteracao.especie = Console.ReadLine();

                Console.Write("Digite a raça: ");
                animalEmAlteracao.raca = Console.ReadLine();

                Console.Write("Digite a data de nascimento. \n Formato: dd/mm/aaaa");
                animalEmAlteracao.datanasc = DateTime.Parse(Console.ReadLine());

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
            lista.ForEach(animal =>
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
            if (lista.Any(a => a.nome.ToUpper() == animal))
            {
                Animal AnimalASerListado = lista.First((a => a.nome.ToUpper() == animal));
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
            if (lista.Any(a => a.nome.ToUpper() == animal))
            {
                Console.WriteLine("Digite o nome do animal novamente para confirmar a exclusão:");
                if (animal == Console.ReadLine().ToUpper())
                {
                    lista.Remove(lista.First((a => a.nome.ToUpper() == animal)));
                }

            }
            else
            {
                Console.WriteLine($"Nenhum animal com o nome {animal} cadastrado.");
            }
        }

    }
}
