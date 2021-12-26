using System;

namespace Series
{
	class Program
	{
		// Repositórios
		static SerieRepositorio repositorioSeries = new SerieRepositorio();
		static FilmeRepositorio repositorioFilmes = new FilmeRepositorio();

		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();
			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "6":
						ListarFilme();
						break;
					case "2":
						InserirSerie();
						break;
					case "7":
						InserirFilme();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "8":
						AtualizarFilme();
						break;
					case "4":
						RemoverSerie();
						break;
					case "9":
						RemoverFilme();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "10":
						VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						Console.WriteLine("Opção inválida");
						break;
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Opção escolhida: " + opcaoUsuario);
			Console.Read();
		}

		// Visualizar filme
		private static void VisualizarFilme()
		{
			Console.WriteLine("Informe o ID do filme pra visualizar: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorioFilmes.RetornarPorId(indiceFilme);

			Console.WriteLine(filme);
		}

		// Remover filme
		private static void RemoverFilme()
		{
			Console.Write("Digite o ID do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioFilmes.Exclui(indiceFilme);
		}

		// Atualizar filme
		private static void AtualizarFilme()
		{
			Console.Write("Digite o ID do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero do filme: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de lançamento do filme: ");
			int entradaLancamento = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											lancamento: entradaLancamento,
											descricao: entradaDescricao);
			// Passa o ID e os dados pra atualizar um filme
			repositorioFilmes.Atualiza(indiceFilme, atualizaFilme);
		}

		// Inserir novo filme
		private static void InserirFilme()
		{
			Console.WriteLine("█ Inserir novo filme █");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Escolha o gênero: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o título do filme: ");
			string entradaFilme = Console.ReadLine();

			Console.WriteLine("Digite o ano de lançamento do filme: ");
			int entradaLancamento = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioFilmes.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaFilme, lancamento: entradaLancamento,
										descricao: entradaDescricao);
			repositorioFilmes.Insere(novoFilme);
		}

		// Listar filmes
		private static void ListarFilme()
		{
			var lista = repositorioFilmes.Lista();
			Console.WriteLine("█ Listando filmes █");
			Console.WriteLine();

			if (lista.Count == 0)
			{
				Console.Clear();
				Console.WriteLine("Nenhum filme cadastrado. Pressione qualquer tecla pra retornar ao menu principal");
				Console.ReadLine();
				Console.Clear();
				return;
			}

			foreach (var filme in lista)
			{
				var excluido = filme.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		// Visualizar série
		private static void VisualizarSerie()
		{
			Console.WriteLine("Informe o ID da série pra visualizar: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorioSeries.RetornarPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		// Exlui o cadastro da série
		private static void RemoverSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorioSeries.Exclui(indiceSerie);
		}

		// Atualizar série cadastrada
		private static void AtualizarSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero da série: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);
			// Passa o ID e os dados pra atualizar
			repositorioSeries.Atualiza(indiceSerie, atualizaSerie);
		}

		// Listar series cadastradas
		private static void ListarSeries()
		{
			var lista = repositorioSeries.Lista();
			Console.WriteLine("█ Listando series █");
			Console.WriteLine();

			if (lista.Count == 0)
			{
				Console.Clear();
				Console.WriteLine("Nenhuma serie cadastrada. Pressione qualquer tecla pra retornar ao menu principal");
				Console.ReadLine();
				Console.Clear();
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		// Inserir nova série
		private static void InserirSerie()
		{
			Console.WriteLine("█ Inserir nova série █");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Escolha o gênero: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o título da série: ");
			string entradaSerie = Console.ReadLine();

			Console.WriteLine("Digite o ano de inicio da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorioSeries.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaSerie, ano: entradaAno,
										descricao: entradaDescricao);
			repositorioSeries.Insere(novaSerie);
		}

		// Menu
		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("     ████████▄   ▄█   ▄██████▄     ");
			Console.WriteLine("     ███   ▀███ ███  ███    ███    ");
			Console.WriteLine("     ███    ███ ███▌ ███    ███    ");
			Console.WriteLine("     ███    ███ ███▌ ███    ███    ");
			Console.WriteLine("     ███    ███ ███▌ ███    ███    ");
			Console.WriteLine("     ███    ███ ███  ███    ███    ");
			Console.WriteLine("     ███   ▄███ ███  ███    ███    ");
			Console.WriteLine("     ████████▀  █▀    ▀██████▀     ");
			Console.WriteLine("     +-+-+-+-+-+ +-+-+-+-+-+-+-+   ");
			Console.WriteLine("     |M|e|d|i|a| |M|a|n|a|g|e|r|   ");
			Console.WriteLine("     +-+-+-+-+-+ +-+-+-+-+-+-+-+   ");
			Console.WriteLine();
			Console.WriteLine("     Escolha a opção desejada:     ");
			Console.WriteLine();
			Console.WriteLine("1 - Listar séries        6 - Listar filmes");
			Console.WriteLine("2 - Inserir nova série   7 - Inserir novo filme");
			Console.WriteLine("3 - Atualizar série      8 - Atualizar filme");
			Console.WriteLine("4 - Exluir série         9 - Excluir filme");
			Console.WriteLine("5 - Visualizar série    10 - Visualizar filme");
			Console.WriteLine();
			Console.WriteLine("C - Limpar tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}