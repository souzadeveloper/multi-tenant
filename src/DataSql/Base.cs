using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Database = Microsoft.Practices.EnterpriseLibrary.Data.Database;

namespace DataSql
{
    public abstract class Base : IDisposable
    {
        public Database Banco { get; set; }
        protected DbConnection Conexao { get; set; }
        public DbTransaction Transacao { get; set; }

        protected Base()
        {

        }

        protected Base(string chave)
        {
            try
            {
                Banco = new DatabaseProviderFactory().Create(chave);
            }
            catch (Exception ex)
            {
                throw new Exception(chave + " - " + ex.Message);
            }
        }

        protected Base(string chave, ref Database database, ref DbTransaction transaction)
        {
            try
            {
                Banco = new DatabaseProviderFactory().Create(chave);
                database = Banco;

                Conexao = Banco.CreateConnection();
                Conexao.Open();

                transaction = Conexao.BeginTransaction();

                Transacao = transaction;
            }
            catch (Exception ex)
            {
                throw new Exception(chave + " - " + ex.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Conexao?.Close();
            Transacao?.Dispose();
        }
    }
}
