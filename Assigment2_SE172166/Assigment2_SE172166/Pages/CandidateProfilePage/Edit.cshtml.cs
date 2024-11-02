using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BusinessObject;
using CandidateManagement_Service;

namespace Assigment2_SE172166.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;
        private readonly IJobPostingService _jobPostingService;

        public EditModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            _candidateProfileService = candidateProfileService;
            _jobPostingService = jobPostingService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            CandidateProfile = _candidateProfileService.GetCandidateProfile(id);
            if (CandidateProfile == null)
            {
                return NotFound();
            }

            PopulateJobPostingDropDown();
            return Page();
        }

        public IActionResult OnPost()
        {
            PopulateJobPostingDropDown();


            try
            {
                _candidateProfileService.UpdateCandidateProfile(CandidateProfile);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Update failed: {ex.Message}");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private void PopulateJobPostingDropDown()
        {
            var postings = _jobPostingService.GetJobPostings();
            ViewData["PostingId"] = new SelectList(postings, "PostingId", "JobPostingTitle");
        }

        private bool CandidateProfileExists(string id)
        {
            return _candidateProfileService.GetCandidateProfile(id) != null;
        }
    }
}
