using DataSql;
using Models;
using System.Collections.Generic;

namespace Repository
{
    public class ClienteRepository
    {
        public List<Cliente> GetClientes()
        {
            using (var clienteDataSql = new ClienteDataSql())
                return clienteDataSql.GetClientes();
        }
    }
}
