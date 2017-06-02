using MvcAppExample.Business.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MvcAppExample.Data.EntityConfigs
{
    public class TelefoneConfig : EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfig()
        {
            HasKey(t => t.TelefoneId);

            Property(t => t.DDD)
                .IsRequired();

            Property(t => t.Numero)
                .IsRequired();

            HasRequired(t => t.Contato)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.ContatoId);

            Ignore(t => t.ValidationResult);

            ToTable("Telefones");

        }
    }
}
