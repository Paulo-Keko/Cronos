using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;

namespace cronos.entity.Entity
{
    [Table("Department")]
    public class Department : BaseEntity
    {
        public string name { get; private set; }

        [JsonConstructor]
        public Department(long? id, string name)
        {
            this.id = id ?? 0;
            this.name = name;
            this.created = new DateTime(DateTime.Now.Ticks);
        }

        public Department(long id, string name, string created, string updated)
        {
            this.id = id;
            this.name = name;
            this.created = Convert.ToDateTime(created);
            this.updated = updated is null ? null : Convert.ToDateTime(updated);
        }

        public void Update(Department department)
        {
            this.name = department.name;
            this.updated = new DateTime(DateTime.Now.Ticks);
        }
    }
}
