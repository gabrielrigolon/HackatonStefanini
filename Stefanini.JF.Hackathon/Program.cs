using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Stefanini.JF.Hackathon.Models;

namespace Stefanini.JF.Hackathon
{
    public class Program
    {
        public static List<Candidato> candidatos = new List<Candidato>();

        public static List<Cidade> cidades = new List<Cidade>
        {
            new Cidade() {Nome = "Juiz de Fora"},
            new Cidade() {Nome = "Bicas"},
            new Cidade() {Nome = "Ibitipoca"},
            new Cidade() {Nome = "Santos Dumont"}

        };

        public static Enem enem = new Enem();

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

                    case 2:
                        {

                            candidatos.Add(GerarCandidato());

                            break;
                        }

                    case 3:
                        {


                            Console.WriteLine("Digite o número de vagas ofertadas: ");

                            var verificador = false;

                            do
                            {
                                verificador = int.TryParse(Console.ReadLine(), out var vagasParse);

                                enem.NumeroVagas = vagasParse;

                                if (enem.NumeroVagas <= 0 || !verificador)
                                    Console.WriteLine("O número de vagas deverá ser maior que zero. Por favor, digite novamente");

                            } while (enem.NumeroVagas <= 0 || !verificador);

                            break;
                        }

                    case 4:
                        {

                            ListarAprovados();

                            break;
                        }
                    case 5:
                    {
                        CandidatosPorCidades();
                        break;
                    }
                }

            };
        }

        public static Candidato CadastrarCandidato()
        {
            var cand = new Candidato();

            cand.Status = true;

            Console.WriteLine("Cadastrando candidato....\n");
            Thread.Sleep(1000);

            do
            {
                Console.Write("Digite o nome do candidato: ");
                cand.Nome = Console.ReadLine();
                Console.WriteLine("\n");

                if (cand.Nome.Any(char.IsDigit))
                    Console.WriteLine("O nome não pode receber caracteres numéricos. Por favor, digite novamente");

            } while (cand.Nome.Any(char.IsDigit));



            var verificador = false;
            do
            {
                Console.Write("Digite a nota do candidato: ");
                verificador = double.TryParse(Console.ReadLine(), out var valorParseado);
                cand.Nota = valorParseado;

                if ((cand.Nota < 0 || cand.Nota > 100) || !verificador)
                    Console.WriteLine("A nota deverá ser maior que zero e menor 100. Por favor, digite novamente");

            } while ((cand.Nota < 0 || cand.Nota > 100) || !verificador);

            Console.WriteLine("\n");

            var random = new Random();
            var index = random.Next(4);

            cand.Cidade = cidades.ElementAt(index);
            Console.WriteLine($"Cidade do candidato: {cand.Cidade.Nome}");

            cand.Id = candidatos.Count + 1;

            return cand;
        }


        public static string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public static Candidato GerarCandidato()
        {
            var random = new Random();
            var index = random.Next(4);

            Candidato candidatoAleatorio = new Candidato();
            candidatoAleatorio.Status = true;
            candidatoAleatorio.Nome = RandomString(5, true);
            candidatoAleatorio.Nota = random.Next(101);
            candidatoAleatorio.Cidade = cidades.ElementAt(index);

            return candidatoAleatorio;
        }


        public static void ListarAprovados()
        {

            foreach (var candidato in candidatos.OrderByDescending(x => x.Nota))
            {
                if (candidato.Nota == 0)
                    candidato.Status = false;

                else if (candidato.Nota > 0 && enem.NumeroVagas < candidatos.Count)
                    candidato.Status = true;

                Console.WriteLine($"{candidato.Nome} | {candidato.Nota} | {candidato.Status} ;");
            }

            Console.ReadLine();

        }

        public static void CandidatosPorCidades()
        {
            foreach (var cidade in cidades)
            {
                cidade.ComecarContagemAprovados();
            }

            foreach (var candidato in candidatos)
            {
                
                if (candidato.Status)
                {
                    candidato.Cidade.AumentarCandidatoAprovado();
                }
            }

            foreach (var cidade in cidades)
            {
                Console.WriteLine("Candidatos aprovados por cidade");
                Console.WriteLine($"{cidade.Nome}: {cidade.CandidatosAprovados*(enem.NumeroVagas/100)}");
            }

            Console.ReadLine();

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
