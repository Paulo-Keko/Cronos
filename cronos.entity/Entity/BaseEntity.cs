using Dapper.Contrib.Extensions;
using System;

namespace cronos.entity.Entity
{
    public abstract class BaseEntity
    {

        [Key]
        public long id { get; protected set; }
        public DateTime created { get; protected set; }
        public DateTime? updated { get; protected set; }
    }
}
