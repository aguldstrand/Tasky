using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Tasky.Models;
using Tasky.Services;

namespace Tasky.ViewModels.Home
{
    public class Index
    {
        public ImmutableArray<IdentityWrapper<Project>> Projects { get; }
        public ImmutableArray<IdentityWrapper<Project, Sprint>> Sprints { get; }
        public ImmutableArray<IdentityWrapper<Project, Sprint, Issue>> Issues { get; }
    }
}
