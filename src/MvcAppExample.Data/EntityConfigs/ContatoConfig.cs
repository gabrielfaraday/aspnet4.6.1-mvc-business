using MvcAppExample.Business.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace MvcAppExample.Data.EntityConfigs
{
    public class ContatoConfig : EntityTypeConfiguration<Contato>
    {
        public ContatoConfig()
        {
            HasKey(c => c.ContatoId);
            //HasKey(c => new {c.ClienteId, c.CPF}); --> chave composta

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_EMAIL") { IsUnique = true }));

            Ignore(c => c.ValidationResult);

            ToTable("Contatos");
        }
    }
}
