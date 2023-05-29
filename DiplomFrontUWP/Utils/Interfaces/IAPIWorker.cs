using DiplomFrontUWP.Utils.Responces;
using DiplomFrontUWP.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomFrontUWP.Utils.Interfaces
{
    internal interface IAPIWorker
    {
        Task<string> GetTest();
        Task<List<USBPortsResponse>> GetAvaliableUSBPorts();
        Task<List<SchemaResponse>> GetSchemasList();
        Task<string> PutNewExperiment(string description, string schemaText);

        Task<string> StartExperiment(string USBPort, string side1, string side2, string side3, string side4, string side5, string side6, string side7, string side8, string isSaving);
        Task<List<ExperimentResponse>> GetExperimentsHistoryList();

        Task<List<string>> GetAnalyzatorsList();

        Task<string> AnalyzeExperement(int experimentId, string analyzatorName);
    }
}
