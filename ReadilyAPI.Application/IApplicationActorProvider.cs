using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application
{
    public interface IApplicationActorProvider
    {
        IApplicationActor GetActor();
    }
}
