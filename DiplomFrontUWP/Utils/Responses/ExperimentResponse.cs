using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomFrontUWP.Utils.Responses
{
    public class ExperimentResponse
    {
        public int Id { get; set; }
        public string startedAt { get; set; }
        public string endedAt { get; set; }
        public string videoPath { get; set; }
        public string resultPath { get; set; }
        public string schemaId { get; set; }
        public string handlerId { get; set; }
    }
}
