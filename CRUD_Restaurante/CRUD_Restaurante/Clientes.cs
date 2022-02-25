using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUD_Restaurante
{
    class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cidade { get; set; }


    }
}
