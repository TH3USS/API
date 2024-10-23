using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModuloAPI.Entities;

namespace ModuloAPI.Context
{
    public class AgendaContext : DbContext
    {
        //classe que acessa o DB
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options){

        }

        public DbSet<Contato> Contatos { get; set; } //tabela do BD
    }
}