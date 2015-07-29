using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.BasisData.Contract;
using GMS.BasisData.DAL;
using GMS.Framework.Utility;
using System.Data.Objects;
using GMS.Framework.Contract;
using EntityFramework.Extensions;
using GMS.Core.Cache;

namespace GMS.BasisData.BLL
{
    public class BasisDataService : IBasisDataService
    {
        #region ClassificationCURD
        public void DeleteClassification(List<int> ids)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                dbContext.Materials.Where(u => ids.Contains(u.ClassificationID ?? 0)).Delete();
                dbContext.Classifications.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        public Classification GetClassification(int id)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                return dbContext.Find<Classification>(id);
            }
        }

        public IEnumerable<Classification> GetClassificationList(ClassificationRequest request = null)
        {
            request = request ?? new ClassificationRequest();
            using (var dbContext = new BasisDataDbContext())
            {
                IQueryable<Classification> classification = dbContext.Classifications;

                if (!string.IsNullOrEmpty(request.Name))
                    classification = classification.Where(u => u.Name.Contains(request.Name));

                if (!string.IsNullOrEmpty(request.Code))
                    classification = classification.Where(u => u.Code == request.Code);

                return classification.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }

        }

        public void SaveClassification(Classification classification)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                if (classification.ID > 0)
                {
                    dbContext.Update<Classification>(classification);
                }
                else
                {
                    dbContext.Insert<Classification>(classification);
                }
            }
        }
        #endregion

        #region MaterCURD
        public void DeleteMaterial(List<int> ids)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                dbContext.MaterialSuppliers.Where(u => ids.Contains(u.MaterialID)).Delete();
                dbContext.Materials.Where(u => ids.Contains(u.ID)).Delete();
            }
        }





        

        public Material GetMaterial(int id)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                return dbContext.Find<Material>(id);
            }
        }

        public IEnumerable<Material> GetMaterialList(MaterialRequest request = null)
        {
            request = request ?? new MaterialRequest();
            using (var dbContext = new BasisDataDbContext())
            {
                IQueryable<Material> material = dbContext.Materials;

                if (!string.IsNullOrEmpty(request.Name))
                    material = material.Where(u => u.Name.Contains(request.Name));

                if (request.ClassificationID > 0)
                    material = material.Where(u => u.ClassificationID == request.ClassificationID);
                if (request.IsAvailability != null)
                {
                    material = material.Where(u => u.IsAvailability == request.IsAvailability);
                }

                return material.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveMaterial(Material material)
        {
            using (var dbContext = new BasisDataDbContext())
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
#endregion

        #region SupplierCURD
        public Supplier GetSupplier(int id)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                return dbContext.Find<Supplier>(id);
            }
        }

        public void DeleteSupplier(List<int> ids)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                dbContext.MaterialSuppliers.Where(u => ids.Contains(u.SupplierID)).Delete();

                dbContext.Suppliers.Where(u => ids.Contains(u.ID)).Delete();
            }
        }

        public IEnumerable<Supplier> GetSupplierList(SupplierRequest request = null)
        {
            request = request ?? new SupplierRequest();
            using (var dbContext = new BasisDataDbContext())
            {
                IQueryable<Supplier> supplier = dbContext.Suppliers;

                if (!string.IsNullOrEmpty(request.Name))
                    supplier = supplier.Where(u => u.Name.Contains(request.Name));
                if (!string.IsNullOrEmpty(request.Contact))
                    supplier = supplier.Where(u => u.Contact.Contains(request.Contact));
                if (!string.IsNullOrEmpty(request.Address))
                    supplier = supplier.Where(u => u.Address.Contains(request.Address));
                return supplier.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        

        

        public void SaveSupplier(Supplier supplier)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                if (supplier.ID > 0)
                {
                    dbContext.Update<Supplier>(supplier);
                }
                else
                {
                    dbContext.Insert<Supplier>(supplier);
                }
            }
        }

        #endregion

        #region MaterialSupplierCURD
        public void DeleteMaterialSupplier(int mid, int sid)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                dbContext.MaterialSuppliers.Where(u => u.SupplierID == sid && u.MaterialID == mid).Delete();
            }
        }

        public MaterialSupplier GetMaterialSupplier(int mid, int sid)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                IQueryable<MaterialSupplier> materialSupplier = dbContext.MaterialSuppliers;

                materialSupplier = materialSupplier.Where(u => u.MaterialID == mid && u.SupplierID == sid);

                return materialSupplier.FirstOrDefault();
            }
        }

        public IEnumerable<MaterialSupplier> GetMaterialSupplierList(MaterialSupplierRequest request = null)
        {
            request = request ?? new MaterialSupplierRequest();
            using (var dbContext = new BasisDataDbContext())
            {
                IQueryable<MaterialSupplier> supplier = dbContext.MaterialSuppliers;

                if (request.MaterialID > 0)
                    supplier = supplier.Where(u => u.MaterialID == request.MaterialID);
                if (request.SupplierID > 0)
                    supplier = supplier.Where(u => u.SupplierID == request.SupplierID);
                if (!string.IsNullOrEmpty(request.MaterialName))
                    supplier = supplier.Where(u => u.MaterialName.Contains(request.MaterialName));
                if (!string.IsNullOrEmpty(request.SupplierName))
                    supplier = supplier.Where(u => u.SupplierName.Contains(request.SupplierName));
                if (request.Price > 0.0)
                    supplier = supplier.Where(u => u.Price >= request.Price);
                return supplier.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveMaterialSupplier(MaterialSupplier materialSupplier)
        {
            using (var dbContext = new BasisDataDbContext())
            {
                MaterialSupplier supplier = GetMaterialSupplier(materialSupplier.MaterialID, materialSupplier.SupplierID);
                if (supplier != null)
                {
                    materialSupplier.ID = supplier.ID;
                    dbContext.Update<MaterialSupplier>(materialSupplier);
                }
                else
                {
                    dbContext.Insert<MaterialSupplier>(materialSupplier);
                }
            }
        }
        #endregion
    }
}
