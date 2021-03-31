using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model;
using System.Linq;
using SolicitudAyuda.Model.Entities;
using System;

namespace ContextExploration
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source=.;Initial Catalog=adp;Connect Timeout=60;Integrated Security=true");

            DataContext context = new DataContext(builder.Options);

            context.Usuarios.Add(new Usuario 
            {
                Login = "test",
                Email = "juanv.santim@gmail.com",
                Disponible = true,
                FechaCreacion = DateTime.Now,
                NombreCompleto = "Juan San5ti",
                SeccionalId = 1,
                
            });

            var existingUser = context.Usuarios.Single(u => u.Id == 2);
            existingUser.NombreCompleto = existingUser.NombreCompleto + " 2";

            context.Usuarios.Remove(context.Usuarios.Single(u => u.Id == 3));

            var modifiedEntries = context.ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .ToList();

            var createdEntries = context.ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity)
                .ToList();

            var deleted = context.ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

        }

 
    }
}
