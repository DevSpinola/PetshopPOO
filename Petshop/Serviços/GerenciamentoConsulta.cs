using Petshop.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Serviços
{
    internal class GerenciamentoConsulta : GerenciamentoPetShop
    {
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
