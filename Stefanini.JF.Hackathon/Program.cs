using System;
using System.Threading;

namespace Stefanini.JF.Hackathon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                ImprimirMenu();

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {
                            Console.WriteLine("Cadastrando candidato....");
                            Thread.Sleep(1000);
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
