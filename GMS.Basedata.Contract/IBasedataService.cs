using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Basedata.Contract
{
    public interface IBasedataService
    {
        Material GetMaterial(int id);
        IEnumerable<Material> GetMaterialList(MaterialRequest request = null);
        void SaveMaterial(Material material);
        void DeleteMaterial(List<int> ids);
    }
}
