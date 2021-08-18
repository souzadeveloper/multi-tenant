using Microsoft.Practices.EnterpriseLibrary.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DataSql
{
    public class ClienteDataSql : Base
    {
        public ClienteDataSql() : base("AppWebContexto")
        {
        }

        public ClienteDataSql(ref Database database, ref DbTransaction transacao) : base("AppWebContexto", ref database, ref transacao)
        {
        }

        public List<Cliente> GetClientes()
        {
            var retorno = new List<Cliente>();
            var command = Banco.GetStoredProcCommand("dbo.ClientesSelect");

            using (var dataReader = Banco.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    retorno.Add(new Cliente()
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Nome = dataReader["Nome"].ToString()
                    });
                }

                dataReader.Close();
            }

            return retorno;
        }
    }
}
