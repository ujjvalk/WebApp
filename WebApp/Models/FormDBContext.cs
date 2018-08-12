using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class FormDBContext:DbContext
    {
        public DbSet<FormModel> formModels { get; set; }
        public DbSet<AllForm> Forms { get; set; }
    }
}