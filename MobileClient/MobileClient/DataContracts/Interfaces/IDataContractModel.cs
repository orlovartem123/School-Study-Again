using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.DataContracts.Interfaces
{
    internal interface IDataContractModel
    {
        /// <summary>
        /// Data contract model validation
        /// </summary>
        /// <returns>Errors in format error\n error\n</returns>
        string Validate();
    }
}
