using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.models
{
    public interface Entity<ID>
    {
        ID Id { get; set; }
    }
}
