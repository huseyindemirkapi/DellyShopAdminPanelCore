using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
