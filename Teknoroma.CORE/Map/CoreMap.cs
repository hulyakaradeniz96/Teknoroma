using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.CORE.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();

        }
    }
}
