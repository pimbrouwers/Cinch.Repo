using System;
using System.Collections.Generic;
using System.Text;

namespace Cinch.Repo
{
    public interface IBaseRepo
    {
        IConnectionFactory ConnectionFactory { get; }
    }
}
