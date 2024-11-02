using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BusinessObject;
using CandidateManagement_DAO;
using CandidateManagement_Service;

namespace Assigment2_SE172166.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;
        private readonly IJobPostingService _jobPostingService;

        public CreateModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            _candidateProfileService = candidateProfileService;
            _jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(_jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public IActionResult OnPost()
        {

            _candidateProfileService.AddCandidateProfile(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
