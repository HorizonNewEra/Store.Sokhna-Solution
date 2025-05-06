using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Sokhna.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Data.Configurations
{
    public class PactsConfigurations : IEntityTypeConfiguration<Pact>
    {
        void IEntityTypeConfiguration<Pact>.Configure(EntityTypeBuilder<Pact> builder)
        {
            
        }
    }
}
