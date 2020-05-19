using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBI.Model.Secretariat;

namespace PBI.Data.EF.Mapping
{
    public class LetterMapping : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {
            builder.HasKey(r => r.ID);
            builder.ToTable("Letter");
        }
    }
}