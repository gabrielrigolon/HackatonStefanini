using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Stefanini.JF.Hackathon.Models;

namespace Stefanini.JF.Hackathon
{
    public class Program
    {
        public static List<Candidato> candidatos = new List<Candidato>();

        public static List<Cidade> cidades = new List<Cidade>();
        public static void Main(string[] args)
        {
            var opcao = -1;

            while (opcao != 0)
            {
                ImprimirMenu();

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {

                            candidatos.Add(CadastrarCandidato());

                            Console.WriteLine("Candidato cadastrado com sucesso!");
                            Thread.Sleep(1000);
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                            Console.ReadKey();
                            break;

                        }
                }

            };
        }

        public static Candidato CadastrarCandidato()
        {
            var cand = new Candidato();

            Console.WriteLine("Cadastrando candidato....\n");
            Thread.Sleep(1000);

            Console.Write("Digite o nome do candidato: ");
            cand.Nome = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Digite a nota do candidato: ");
            cand.Nota = Console.Read();
            Console.WriteLine("\n");

            Console.WriteLine($"Cidade do candidato: {cand.Cidade.Nome}");

            cand.Id = candidatos.Count + 1;

            return cand;
        }



        public static void ImprimirMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("0 - SAIR");
            Console.WriteLine("1 - CADASTRAR NOTA DO CANDIDATO");
            Console.WriteLine("2 - GERAR CANDIDATOS ALEATORIAMENTE");
            Console.WriteLine("3 - INSERIR NUMERO DE VAGAS");
            Console.WriteLine("4 - EXIBIR CANDIDATOS APROVADOS");
            Console.WriteLine("5 - EXIBIR PORCENTAGEM DE APROVADOS POR CIDADE");
            Console.WriteLine();
            Console.Write("ESCOLHA UMA OPÇÃO: ");
        }
    }
}
