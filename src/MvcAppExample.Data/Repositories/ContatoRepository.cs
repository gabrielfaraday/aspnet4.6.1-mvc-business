using System.Collections.Generic;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Interfaces.Repositories;
using MvcAppExample.Data.Contexts;
using System.Linq;
using System;
using Dapper;

namespace MvcAppExample.Data.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public ICollection<Contato> ObterAtivos()
        {
            var conn = Db.Database.Connection;
            var sql = @"SELECT * " +
                       "  FROM Contatos c " +
                       " LEFT JOIN Telefones t ON t.ContatoId = c.ContatoId" +
                       " WHERE c.Ativo = 1 " +
                       " ORDER BY c.Nome, t.DDD, t.Numero ";

            var lookup = new Dictionary<Guid, Contato>();
            conn.Query<Contato, Telefone, Contato>(sql,
                (c, t) =>
                {
                    Contato contato;

                    if (!lookup.TryGetValue(c.ContatoId, out contato))
                        lookup.Add(c.ContatoId, contato = c);

                    if (contato.Telefones == null)
                        contato.Telefones = new List<Telefone>();

                    if (t != null)
                        contato.Telefones.Add(t);

                    return contato;
                }, splitOn: "ContatoId, TelefoneId").AsQueryable();

            return lookup.Values;
        }

        public Contato ObterPorEmail(string email)
        {
            return Find(c => c.Email == email).SingleOrDefault();
        }

        public override Contato FindById(Guid id)
        {
            var conn = Db.Database.Connection;
            var sql = @"SELECT * " +
                       "  FROM Contatos c " +
                       " LEFT JOIN Telefones t ON t.ContatoId = c.ContatoId" +
                       " WHERE c.ContatoId = @pid" +
                       " ORDER BY c.Nome, t.DDD, t.Numero ";

            var fones = new List<Telefone>();
            var contatos = conn.Query<Contato, Telefone, Contato>(sql,
                (c, t) =>
                {
                    if (t != null)
                        fones.Add(t);

                    return c;
                }, new { pid = id }, splitOn: "ContatoId, TelefoneId");

            var contato = contatos.FirstOrDefault();

            if (contato != null)
                contato.Telefones = fones;

            return contato;
        }

        public override IEnumerable<Contato> GetAll()
        {
            var conn = Db.Database.Connection;

            var sql = @"SELECT * FROM Contatos ORDER BY Nome ";

            return conn.Query<Contato>(sql);
        }

        public override void Delete(Guid id)
        {
            var contato = FindById(id);
            contato.Ativo = false;
            Update(contato);
        }
    }
}
