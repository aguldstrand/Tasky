using Microsoft.AspNet.Mvc;
using System.Collections.Immutable;
using System.Linq;
using Tasky.Api.Models;
using Tasky.Services;
using Tasky.ViewModels.Home;

namespace Tasky.Api.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ProjectsController projects;
        private readonly SprintsController sprints;
        private readonly IssuesController issues;
        private readonly CommentsController comments;
        private readonly AttachmentsController attachments;
        private readonly UsersController users;

        public HomeController(ProjectsController projects,SprintsController sprints,IssuesController issues,CommentsController comments, AttachmentsController attachments, UsersController users)
        {
            this.projects = projects;
            this.sprints = sprints;
            this.issues = issues;
            this.comments = comments;
            this.attachments = attachments;
            this.users = users;
        }

        [HttpGet]
        public IActionResult Index(int? project, int? sprint)
        {
            var outp = new IndexVM(
                project: project,
                sprint: sprint,
                projects: projects.Get(),
                sprints: project == null ? ImmutableArray<IdentityWrapper<Project, Sprint>>.Empty : sprints.Get(project.Value),
                issues: project == null || sprint == null ? ImmutableArray<IndexVM.IssueVM>.Empty : issues.Get(project.Value, sprint.Value)
                    .Select(issue => new IndexVM.IssueVM(
                        issue: issue,
                        comments: comments.Get(issue.ParentId1, issue.ParentId2, issue.Id).Length,
                        assignee: string.Join("", users.Get(issue.Value.Assignee).Value.Name.Split(' ').Select(s => s.FirstOrDefault())).ToUpper(),
                        attachments: attachments.Get(issue.ParentId1, issue.ParentId2, issue.Id).Length))
                    .ToImmutableArray());

            return View(outp);
        }
    }
}
