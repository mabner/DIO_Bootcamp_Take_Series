namespace Series
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
						AtualizarSerie();
						break;
					case "4":
						RemoverSerie();
						break;
					case "5":
						VisualizarSerie();
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
				Console.Read();
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.Clear();
				Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
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
			Console.WriteLine("Escolha a opção desejada:");
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