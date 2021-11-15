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
						InserirSerie();
						break;
					case "3":
						//AtualizarSerie();
						break;
					case "4":
						//RemoverSerie();
						break;
					case "5":
						//VisualizarSerie();
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
				Console.Read();
				return;
			}

			foreach (var serie in lista)
			{
				Console.Clear();
				Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
				Console.Read();
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
			Console.Clear();
			Console.WriteLine("  ████████▄   ▄█   ▄██████▄     ");
			Console.WriteLine("  ███   ▀███ ███  ███    ███    ");
			Console.WriteLine("  ███    ███ ███▌ ███    ███    ");
			Console.WriteLine("  ███    ███ ███▌ ███    ███    ");
			Console.WriteLine("  ███    ███ ███▌ ███    ███    ");
			Console.WriteLine("  ███    ███ ███  ███    ███    ");
			Console.WriteLine("  ███   ▄███ ███  ███    ███    ");
			Console.WriteLine("  ████████▀  █▀    ▀██████▀     ");
			Console.WriteLine("       ╔═╗┌─┐┬─┐┬┌─┐┌─┐        ");
			Console.WriteLine("       ╚═╗├┤ ├┬┘│├┤ └─┐        ");
			Console.WriteLine("       ╚═╝└─┘┴└─┴└─┘└─┘        ");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1 - Listar séries");
			Console.WriteLine("2 - Inserir nova série");
			Console.WriteLine("3 - Atualizar série");
			Console.WriteLine("4 - Exluir série");
			Console.WriteLine("5 - Visualizar série");
			Console.WriteLine("C - Limpar tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}