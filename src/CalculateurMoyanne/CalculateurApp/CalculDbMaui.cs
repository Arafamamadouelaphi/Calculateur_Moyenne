using System;
using CalculateurEF.Context;
using Microsoft.EntityFrameworkCore;

namespace CalculateurApp

{
	public class CalculDbMaui:CalculContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={ DataBase_constante.DatabasePath}");
            }
        }
    }
}

