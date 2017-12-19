using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    public interface IGroupProductManager
    {
        List<GroupProductModel> GetGroupProductBranch();
        GroupProductModel GetGroupProductByCode(string code);
    }
}
