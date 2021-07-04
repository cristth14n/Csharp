 using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcoesUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSeries();
                        break;
                    
                    case "3":
                       AtualizarSeries();
                        break;
                    
                    case "4":
                        ExcluirSeries();
                        break;

                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("Escolha uma opção correta amigo!");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

                opcaoUsuario = ObterOpcoesUsuario();

            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Obrigado por utilizar nossa ferramenta.");
            Console.ReadLine();
        }
        
        //////////////////////////////////////////////////////////////
        
        private static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine("###### Listar Séries ######");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" ************** Nenhuma série cadastrada. **************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#Id {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
            Console.ReadKey();
            Console.Clear();
        }

        //////////////////////////////////////////////////////////////
        private static void InserirSeries()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ************** Inserir Nova Série **************");
            Console.WriteLine();
            Console.WriteLine(" ************************************************");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.WriteLine(" ************************************************");
            Console.Write("Insira o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Insira o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Insira o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Insira uma descrição para a serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaserie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Insere(novaserie);
            Console.WriteLine("");
            msgSucesso();
            Console.ReadKey();
            Console.Clear();
        }

        //////////////////////////////////////////////////////////////
        private static void AtualizarSeries()
        {
            Console.Clear();
            Console.WriteLine(" ************** Atualizar Série **************");
            Console.WriteLine();
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Insira o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Insira o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Insira o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Insira uma descrição para a serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine("");
            msgSucesso();
            Console.ReadKey();
            Console.Clear();
        }

        //////////////////////////////////////////////////////////////
        private static void ExcluirSeries()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Digite o id da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
            Console.WriteLine("");
            msgSucesso();
            Console.ReadKey();
            Console.Clear();
        }

        //////////////////////////////////////////////////////////////
        private static void VisualizarSeries()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Digite o id da série: ");
            Console.WriteLine();
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine("************************************************");
            Console.WriteLine(serie);
            Console.WriteLine("************************************************");
            Console.ReadKey();
            Console.Clear();
        }
        //////////////////////////////////////////////////////////////
        private static string ObterOpcoesUsuario()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            
            
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar todos dados da série");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");
            Console.Write("Olá, informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.ResetColor();
            Console.WriteLine("");
            return opcaoUsuario;
        }
        private static void msgSucesso()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Sucesso!!");
            Console.ResetColor();
        }
    }
}
