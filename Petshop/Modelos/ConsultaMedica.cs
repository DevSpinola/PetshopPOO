using System;
using System.Collections.Generic;

namespace Petshop.Modelos
{
    internal class ConsultaMedica
    {
        public DateTime DataConsulta { get; set; }
        public string MotivoConsulta { get; set; }
        public string Tratamento { get; set; }
        public Veterinário Veterinario { get; set; }
        public Animal Animal { get; set; }
        public bool Concluida { get; set; }

    }
}