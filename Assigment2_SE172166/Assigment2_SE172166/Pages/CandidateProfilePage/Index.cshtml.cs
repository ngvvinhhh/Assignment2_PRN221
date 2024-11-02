using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject;
using CandidateManagement_DAO;
using CandidateManagement_Service;

namespace Assigment2_SE172166.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public IndexModel(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
        }

        public IList<CandidateProfile> CandidateProfile { get; set; } = default!;

        public void OnGet()
        {
            if (_candidateProfileService != null)
            {
                CandidateProfile = _candidateProfileService.GetCandidateProfiles();
            }
        }
    }
}
