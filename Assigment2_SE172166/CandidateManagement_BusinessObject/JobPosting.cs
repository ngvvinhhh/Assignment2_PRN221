using System;
using System.Collections.Generic;

namespace CandidateManagement_BusinessObject;

public partial class JobPosting
{
    public string PostingId { get; set; }

    public string JobPostingTitle { get; set; }

    public string Description { get; set; }

    public DateTime? PostedDate { get; set; }

    public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();
}
