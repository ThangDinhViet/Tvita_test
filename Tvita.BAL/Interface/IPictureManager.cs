using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    interface IPictureManager
    {
        List<PictureModel> GetAllPicture();
        PictureModel GetPictureByID(int id);
    }
}
