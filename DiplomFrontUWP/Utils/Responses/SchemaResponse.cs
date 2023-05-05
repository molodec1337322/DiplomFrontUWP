using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomFrontUWP.Utils.Responses
{
    public class SchemaResponse
    {
        public int id { get; set; }
        public string description { get; set; }
        public string createdAt { get; set; }
        public string text { get; set; }
        public List<ExperimentResponse> experiments { get; set; }
    }
}
