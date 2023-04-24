﻿using DiplomFrontUWP.Utils.Responces;
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
        Task<List<SchemaResponse>> GetExperimentsList();
        Task<string> PutNewExperiment(string description, string videoSaveRoot, string schemaText);

        Task<string> StartExperiment(string USBPort, string Direction, string Deformation, string PauseDuration, string side);
    }
}
