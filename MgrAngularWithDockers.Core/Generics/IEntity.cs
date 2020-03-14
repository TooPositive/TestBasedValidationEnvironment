using System;
using System.Collections.Generic;
using System.Text;

namespace MgrAngularWithDockers.Core.Generics
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
