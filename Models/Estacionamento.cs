using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace DesafioEstacionamento.Models
{
    public class Estacionamento
    {      
        decimal precoPorHora;
        List<Carro> carro = new List<Carro>();

        public void AdicionarVeiculo(string placa, decimal precoInicial)
        {  
            string p1 = placa.Substring(0,3).ToUpper();  
            string p2 = string.Format("{0,5}",placa.Substring(3)); 
            string plac = $"{p1}-{p2}"; 

            
            string placa1= placa.Insert(3,"-").ToUpper();

            carro.Add(new Carro(){Placa = placa1, PrecoInicial = precoInicial });
        }

       
        public void RemoverVeiculo(){

            Console.WriteLine("SAÍDA DE VEÍCULOS");
            Console.Write("\nDigite a placa: ");
            string? busca = Console.ReadLine();
            string plac = busca!.Insert(3,"-").ToUpper();

            
            int item = carro.FindIndex(0,i => i.Placa == plac);

            
            if (item >= 0)
            {
               decimal valorTaxaInicial = carro[item].PrecoInicial;   
               Console.Write("\nQuantos minutos permaneceu no local?: ");
               int minutos = Convert.ToInt32(Console.ReadLine()); 

               Console.Write("\nQual o valor do estacionamento por MINUTO? R$: ");
               precoPorHora = Convert.ToDecimal(Console.ReadLine());

               Console.Write("\n MENSAGEM DO SISTEMA?: ") ;
               Console.WriteLine(@$"O valor devido para o veículo de placa {carro[item].Placa}
                        é de R$ {valorTaxaInicial+(precoPorHora * minutos)} ");
               Console.WriteLine("\nDeseja dar saída no veículo?");
               Console.Write("Responda 'sim' ou 'não': ");

               if (Console.ReadLine() == "sim")
               {
                carro.RemoveAt(item); 
                Console.Clear();
                Console.WriteLine($"O Veículo de placa ''{plac}'' foi REMOVIDO.");
                Console.Write("Retornado ao MENU...\n");
                return;
               }
               else
               {
                Console.Clear();
                Console.WriteLine($"\nO Veículo da placa '{plac}' NÃO será removido.");
                Console.WriteLine("\nPara remover Veículo, digite a opção 2 ");
                Console.WriteLine("Após os procedimentos responda 'sim'");
                return;
               }
            }
            else 
            {
            Console.WriteLine("\nA placa digitada não foi encontrada. ");
            Console.WriteLine($"Escolha a opção 3 e verifique se a placa '{busca}' existe.");
            return;
            }

        }

        public void ListarVeiculos(string usuario)
        {
            if (carro.Count >=1)
            {                
             Console.WriteLine("\n LISTA DE VEÍCULOS ESTACIONADOS\n");
             carro.ForEach(carro=>Console.WriteLine
              ($" PLACA {carro.Placa} VALOR INICIAL R$ {carro.PrecoInicial}"));
            }
            else
            {
                Console.WriteLine("Não existem Veículos cadastrados");
                Console.WriteLine($"{usuario} escolha a opção 1 ");                
            }
        }


        public class Carro 
        {
           
            public string? Placa {get; set;}
            public decimal PrecoInicial {get; set;}
        }

 }
}