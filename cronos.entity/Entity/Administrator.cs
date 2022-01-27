using cronos.infrastructure.Tools;
using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;

namespace cronos.entity.Entity
{
    [Table("Administrator")]
    public class Administrator : BaseEntity
    {
        public string email { get; private set; }
        public string password { get; private set; }        

        [JsonConstructor]
        public Administrator(string email, string password)
        {
            this.email = email;
            this.password = password.Encrypt();
            this.created = new DateTime(DateTime.Now.Ticks);
        }

        public Administrator(long id, string email, string password, string created, string updated)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.created = Convert.ToDateTime(created);
            this.updated = updated is null ? null : Convert.ToDateTime(updated);
        }
    }
}
