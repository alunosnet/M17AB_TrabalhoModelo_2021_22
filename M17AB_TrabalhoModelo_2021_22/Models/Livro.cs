using M17AB_TrabalhoModelo_2021_22.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace M17AB_TrabalhoModelo_2021_22.Models
{
    public class Livro
    {
        public int nlivro { get; set; }
        public string nome { get; set; }
        public int ano { get; set; }
        public DateTime data_aquisicao { get; set; }
        public decimal preco { get; set; }
        public string autor { get; set; }
        public string tipo { get; set; }
        public int estado { get; set; }
        BaseDados bd;

      

        public Livro(int nlivro, string nome, int ano, DateTime data_aquisicao, decimal preco, string autor, string tipo, int estado)
        {
            this.nlivro = nlivro;
            this.nome = nome;
            this.ano = ano;
            this.data_aquisicao = data_aquisicao;
            this.preco = preco;
            this.autor = autor;
            this.tipo = tipo;
            this.estado = estado;
            bd = new BaseDados();
        }

        public Livro()
        {
            bd = new BaseDados();
        }

        public int Adicionar()
        {
            string sql = @"INSERT INTO Livros(nome,ano,data_aquisicao,preco,autor,tipo,estado)
                            VALUES(@nome,@ano,@data_aquisicao,@preco,@autor,@tipo,@estado);
                            SELECT cast(SCOPE_IDENTITY() AS INT);";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                },
                new SqlParameter()
                {
                    ParameterName="@autor",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.autor
                },
                new SqlParameter()
                {
                    ParameterName="@tipo",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.tipo
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.estado
                },
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal DataTable listaTodosLivrosDisponiveis()
        {
            string sql = @"SELECT nlivro,nome,ano,data_aquisicao,preco,
                autor,tipo,
                    case
                        when estado=0 then 'Emprestado'
                        when estado=1 then 'Disponível'
                        when estado=2 then 'Reservado'
                    end as estado
                    FROM Livros
                    WHERE estado=1";
            return bd.devolveSQL(sql);
        }

        internal void removerLivro(int id)
        {
            string sql = $@"DELETE FROM Livros WHERE nlivro={id}";
            bd.executaSQL(sql);
        }

        internal void Atualizar()
        {
            string sql = @"UPDATE Livros SET nome=@nome,ano=@ano,data_aquisicao=@data_aquisicao,
                                    preco=@preco,autor=@autor,tipo=@tipo
                            WHERE nlivro=@nlivro";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                },
                new SqlParameter()
                {
                    ParameterName="@autor",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.autor
                },
                new SqlParameter()
                {
                    ParameterName="@tipo",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.tipo
                },
                new SqlParameter()
                {
                    ParameterName="@nlivro",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nlivro
                },
            };
            bd.executaSQL(sql, parametros);
        }

        public DataTable ListaTodosLivros()
        {
            string sql = @"SELECT nlivro,nome,ano,data_aquisicao,preco,
                autor,tipo,
                    case
                        when estado=0 then 'Emprestado'
                        when estado=1 then 'Disponível'
                        when estado=2 then 'Reservado'
                    end as estado
                    FROM Livros";
            return bd.devolveSQL(sql);
        }  
        internal DataTable devolveLivro(int id)
        {
            string sql = $@"SELECT nlivro,nome,ano,data_aquisicao,preco,
                autor,tipo,
                    case
                        when estado=0 then 'Emprestado'
                        when estado=1 then 'Disponível'
                        when estado=2 then 'Reservado'
                    end as estado
                    FROM Livros
                WHERE nlivro={id}";
            return bd.devolveSQL(sql);
        }
        public DataTable listaLivrosDisponiveis(int? ordena = null)
        {
            string sql = "SELECT * FROM Livros WHERE estado=1";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by autor";
            }
            return bd.devolveSQL(sql);
        }
        internal DataTable listaLivrosDisponiveis(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM Livros WHERE estado=1 and nome like @nome";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by autor";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
        internal DataTable listaLivrosDoAutor(string pesquisa)
        {
            string sql = "SELECT *,1 as prioridade FROM Livros WHERE estado=1 and autor like @nome";
            sql += " UNION SELECT *,2 as prioridade FROM Livros WHERE estado=1 and autor not like @nome order by prioridade";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
        public DataTable devolveDadosLivro(int nlivro)
        {
            string sql = "SELECT * FROM Livros WHERE nlivro=@nlivro";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nlivro",SqlDbType=SqlDbType.Int,Value=nlivro }
            };
            return bd.devolveSQL(sql, parametros);
        }
    }
}