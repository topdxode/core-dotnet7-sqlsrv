using System;
namespace core_dotnet7_sqlsrv.Interfaces
{
    public interface IEntity
    {
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}

