using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace NonRelational.Pages
{
    public class MainPageModel : PageModel
    {
        public List<Topic> Topics { get; set; }

        public void OnGet()
        {
            // Populate the topics, for example from a database or any other source
            Topics = new List<Topic>
            {
                new Topic { Id = 1, Name = "Mathematics" },
                new Topic { Id = 2, Name = "Geography" },
                // Add other topics
            };
        }
    }

    // Simple topic model, you can expand this as needed
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
