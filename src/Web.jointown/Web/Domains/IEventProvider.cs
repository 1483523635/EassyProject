﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Events;

namespace Web.Domains
{
    public interface IEventProvider
    {
        void LoadFromHistory(IEnumerable<Event> history);
        IEnumerable<Event> GetUnCommitChanges();
    }
}
