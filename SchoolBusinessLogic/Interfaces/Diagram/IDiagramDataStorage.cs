using SchoolBusinessLogic.ViewModels.Diagram;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interfaces.Diagram
{
    public interface IDiagramDataStorage
    {
        List<DiagramDataViewModel> GetMostPopularMaterials();
    }
}
