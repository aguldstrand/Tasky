using System.Collections.Immutable;
using Tasky.Api.Models;
using Tasky.Services;

namespace Tasky.ViewModels.Home
{
    public class IndexVM
    {
        public int? Project { get; }
        public int? Sprint { get; }
        public ImmutableArray<IdentityWrapper<Project>> Projects { get; }
        public ImmutableArray<IdentityWrapper<Project, Sprint>> Sprints { get; }
        public ImmutableArray<IssueVM> Issues { get; }

        public IndexVM(
            int? project,
            int? sprint,
            ImmutableArray<IdentityWrapper<Project>> projects,
            ImmutableArray<IdentityWrapper<Project, Sprint>> sprints,
            ImmutableArray<IssueVM> issues)
        {
            Project = project;
            Sprint = sprint;
            Projects = projects;
            Sprints = sprints;
            Issues = issues;
        }

        public class IssueVM
        {
            public IdentityWrapper<Project, Sprint, Issue> Issue { get; }
            public int Comments { get; }
            public int Attachments { get; }
            public string Assignee { get; }

            public IssueVM(IdentityWrapper<Project, Sprint, Issue> issue, int comments, int attachments, string assignee)
            {
                Issue = issue;
                Comments = comments;
                Attachments = attachments;
                Assignee = assignee;
            }
        }
    }
}
