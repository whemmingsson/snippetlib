using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using SnippetLib.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SnippetLib.Business
{
    public class SnippetRepository : ISnippetRepository
    {
        private readonly IConfiguration _configuration;

        private SqlConnection Connection => new SqlConnection(_configuration.GetConnectionString("SnippetDB"));

        public SnippetRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Snippet> GetAll()
        {
            using var con = Connection;
            return con.GetAll<Snippet>();
        }

        public Snippet GetById(int id)
        {
            using var con = Connection;
            return con.Get<Snippet>(id);
        }

        public long Add(Snippet snippet)
        {
            using var con = Connection;
            return con.Insert<Snippet>(snippet);
        }

        public bool Update(Snippet snippet)
        {
            using var con = Connection;
            return con.Update<Snippet>(snippet);
        }

        public bool Delete(Snippet snippet)
        {
            using var con = Connection;
            return con.Delete<Snippet>(snippet);
        }
    }
}
