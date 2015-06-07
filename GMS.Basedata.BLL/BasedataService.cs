using GMS.Basedata.Contract;
using GMS.Basedata.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GMS.Framework.Utility;
using System.Data.Objects;
using GMS.Framework.Contract;
using EntityFramework.Extensions;
using GMS.Core.Cache;

namespace GMS.Basedata.BLL
{
    public class BasedataService:IBasedataService
    {
        #region Material CURD
        public Material GetMaterial(int id)
        {
            using (var dbContext = new BasedataDbContext())
            {
                return dbContext.Find<Material>(id);
            }
        }

        public IEnumerable<Material> GetMaterialList(MaterialRequest request = null)
        {
            request = request ?? new MaterialRequest();
            using (var dbContext = new BasedataDbContext())
            {
                IQueryable<Material> materials = dbContext.Materials;
                if (!string.IsNullOrEmpty(request.MaterialName))
                    materials = materials.Where(u => u.MaterialName.Contains(request.MaterialName));

                return materials.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveMaterial(Material material)
        {
            using (var dbContext = new BasedataDbContext())
            {

                if (material.ID > 0)
                {
                    dbContext.Update<Material>(material);
                }
                else
                {
                    dbContext.Insert<Material>(material);
                }
            }
        }

        public void DeleteMaterial(List<int> ids)
        {
            using (var dbContext = new BasedataDbContext())
            {
                dbContext.Materials.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion
    }
}
