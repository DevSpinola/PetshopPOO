using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Petshop
{
    public class Animal
    {
        //Declaração de variáveis -> atributos
        public String nome;
        public DateTime datanasc;
        public String especie;
        public String raca;
        public float peso;
        public DateTime dataInclusao; // Adicionando atributos importantes para inclusao posterior em um BD 
        public Nullable<DateTime> dataAlteracao;


    }
}
