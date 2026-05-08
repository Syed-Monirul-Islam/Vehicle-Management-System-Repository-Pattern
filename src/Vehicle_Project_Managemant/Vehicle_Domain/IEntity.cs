using System;

namespace Vehicle_Domain
{
    public interface IEntity<TKey>
    {
        TKey ID { get; set; }
    }
}
