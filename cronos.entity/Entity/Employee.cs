using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;

namespace cronos.entity.Entity
{
    [Table("Employee")]
    public class Employee : BaseEntity
    {
        public string name { get; private set; }
        public string email { get; private set; }

        [JsonConstructor]
        public Employee(long? id, string name, string email)
        {
            this.id = id ?? 0;
            this.name = name;
            this.email = email;
            this.created = new DateTime(DateTime.Now.Ticks);
        }

        public Employee(long id, string name, string email, string created, string updated)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.created = Convert.ToDateTime(created);
            this.updated = updated is null ? null : Convert.ToDateTime(updated);
        }

        public void Update(Employee employee)
        {
            this.name = employee.name;
            this.email = employee.email;
            this.updated = new DateTime(DateTime.Now.Ticks);
        }
    }
}
