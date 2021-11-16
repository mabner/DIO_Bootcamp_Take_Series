using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series
{
	public class Filme : EntidadeBase
	{
		// Atributos
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Lancamento { get; set; }
		private bool Excluido { get; set; }

		// Métodos
		public Filme(int id, Genero genero, string titulo, string descricao, int lancamento)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Lancamento = lancamento;
			this.Excluido = false;
		}

		public override string ToString()
		{
			string retorno = "";
			// Emviroment.NewLine insere uma nova linha uvando a forma que o sistema operacional trabalha
			retorno += "Gênero: " + this.Genero + Environment.NewLine;
			retorno += "Título: " + this.Titulo + Environment.NewLine;
			retorno += "Descrição: " + this.Descricao + Environment.NewLine;
			retorno += "Lançamento: " + this.Lancamento + Environment.NewLine;
			retorno += "Excluído: " + this.Excluido + Environment.NewLine;
			return retorno;
		}

		public string retornaTitulo()
		{
			return this.Titulo;
		}

		internal int retornaId()
		{
			return this.Id;
		}

		public bool retornaExcluido()
		{
			return this.Excluido;
		}

		public void Excluir()
		{
			this.Excluido = true;
		}

	}
}