using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bimeh.Api.Models
{
    public class CreateRequestModel
    {
        [Required]
        public string Title { get; set; }
        public List<CoverageModel> Coverages { get; set; }

        public class CoverageModel
        {
            public int CoverageId { get; set; }
            public long Amount { get; set; }
        }
    }
}
