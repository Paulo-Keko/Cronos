using System;
using System.Data;

namespace cronos.repository.Repository.Base
{
    public interface IDBContext : IDisposable
    {
        IDbConnection connection { get; }
    }
}
