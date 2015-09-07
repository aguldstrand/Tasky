using Microsoft.AspNet.Mvc;
using System.Collections.Immutable;
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

        public HomeController(ProjectsController projects,SprintsController sprints,IssuesController issues,CommentsController comments, AttachmentsController attachments)
        {
            this.projects = projects;
            this.sprints = sprints;
            this.issues = issues;
            this.comments = comments;
            this.attachments = attachments;
        }

        [HttpGet]
        public IActionResult Index(int? project, int? sprint)
        {
            var outp = new Index(
                project: project,
                sprint: sprint,
                projects: projects.Get(),
                sprints: project == null ? ImmutableArray<IdentityWrapper<Project, Sprint>>.Empty : sprints.Get(project.Value),
                issues: project == null || sprint == null ? ImmutableArray<IdentityWrapper<Project, Sprint, Issue>>.Empty :issues.Get(project.Value, sprint.Value));

            return View(outp);
        }
    }
}
