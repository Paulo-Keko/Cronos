using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;

namespace cronos.entity.Entity
{
    [Table("Post")]
    public class Post : BaseEntity
    {
        public string title { get; private set; }
        public string description { get; private set; }

        [JsonConstructor]
        public Post(long? id, string title, string description)
        {
            this.id = id ?? 0;
            this.title = title;
            this.description = description;
            this.created = DateTime.UtcNow;
        }

        public Post(long id, string title, string description, string created, string updated)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.created = Convert.ToDateTime(created);
            this.updated = updated is null ? null : Convert.ToDateTime(updated);
        }

        public void Update(Post post)
        {
            this.title = post.title;
            this.description = post.description;
            this.updated = new DateTime(DateTime.Now.Ticks);
        }
    }
}
