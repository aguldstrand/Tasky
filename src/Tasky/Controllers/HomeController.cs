using Microsoft.AspNet.Mvc;

namespace Tasky.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        /*
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
        */

        [HttpGet]
        public IActionResult Index(int? project, int? sprint)
        {
            return View();
        }
    }
}
