using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    public interface ISubSubjectManager
    {
        List<SubSubjectModel> GetAllSubSubject();
        SubSubjectModel GetSubSubjectByID(int id);
    }
}
