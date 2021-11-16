﻿namespace Series
{
	class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
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
					case "2":
						//ListarFilme();
						break;
					case "3":
						InserirSerie();
						break;
					case "4":
						//InserirFilme();
						break;
					case "5":
						AtualizarSerie();
						break;
					case "6":
						//AtualizarFilme();
						break;
					case "7":
						RemoverSerie();
						break;
					case "8":
						//RemoverFilme();
						break;
					case "9":
						VisualizarSerie();
						break;
					case "10":
						//VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Opção escolhida: " + opcaoUsuario);
			Console.Read();
		}

		// Visualizar série
		private static void VisualizarSerie()
		{
			Console.WriteLine("Informe o ID da série pra visualizar: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornarPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		// Exlui o cadastro da série
		private static void RemoverSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
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
			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

		// Listar series cadastradas
		private static void ListarSeries()
		{
			var lista = repositorio.Lista();
			Console.WriteLine("Listando series");
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
			Console.WriteLine("Inserir nova série");

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

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaSerie, ano: entradaAno,
										descricao: entradaDescricao);
			repositorio.Insere(novaSerie);
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
			Console.WriteLine("          ╔═╗┌─┐┬─┐┬┌─┐┌─┐        ");
			Console.WriteLine("          ╚═╗├┤ ├┬┘│├┤ └─┐        ");
			Console.WriteLine("          ╚═╝└─┘┴└─┴└─┘└─┘        ");
			Console.WriteLine();
			Console.WriteLine("	Escolha a opção desejada:			");
			Console.WriteLine();
			Console.WriteLine("1 - Listar séries        2 - Listar filmes");
			Console.WriteLine("3 - Inserir nova série   4 - Inserir novo filme");
			Console.WriteLine("5 - Atualizar série      6 - Atualizar filme");
			Console.WriteLine("7 - Exluir série         8 - Excluir filme");
			Console.WriteLine("9 - Visualizar série    10 - Visualizar filme");
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