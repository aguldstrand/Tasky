using System.Collections.Immutable;
using Tasky.Api.Models;
using Tasky.Services;

namespace Tasky.ViewModels.Home
{
    public class Index
    {
        public int? Project { get; }
        public int? Sprint { get; }
        public ImmutableArray<IdentityWrapper<Project>> Projects { get; }
        public ImmutableArray<IdentityWrapper<Project, Sprint>> Sprints { get; }
        public ImmutableArray<IdentityWrapper<Project, Sprint, Issue>> Issues { get; }

        public Index(
            int? project,
            int? sprint,
            ImmutableArray<IdentityWrapper<Project>> projects,
            ImmutableArray<IdentityWrapper<Project, Sprint>> sprints,
            ImmutableArray<IdentityWrapper<Project, Sprint, Issue>> issues)
        {
            Project = project;
            Sprint = sprint;
            Projects = projects;
            Sprints = sprints;
            Issues = issues;
        }
    }
}
