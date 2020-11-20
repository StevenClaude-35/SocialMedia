using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialMediaCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Commentarios");
            builder.HasKey(e => e.CommentId);

            builder.ToTable("Comment");

            builder.Property(e => e.CommentId)
            .HasColumnName("IdCommentario")
            .ValueGeneratedNever();

            builder.Property(e => e.PostId)
           .HasColumnName("IdPublicacion");

            builder.Property(e => e.UserId)
           .HasColumnName("IdUsuario");

            builder.Property(e => e.IsActive)
           .HasColumnName("Activo");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date)
            .HasColumnName("Fecha")
            .HasColumnType("datetime");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        }
    }
}
