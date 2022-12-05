using CalculateurEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurEF.Context
{
    public class CalculContext : DbContext
    {    /// Cette classe est le contexte de la base de données qui permet de faire le lien entre les objets et la base de données

        public DbSet<MaquetteEntity> Maquettes { get; set; }
        public DbSet<BlocEntity> Bloc { get; set; }
        public DbSet<UEentity> Ue { get; set; }
        public DbSet<MatiereEntity> matier { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=calcul.db");
        }
    }
}
