using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;

namespace GMS.BasisData.Contract
{
    public interface IBasisDataService
    {
        Material GetMaterial(int id);
        IEnumerable<Material> GetMaterialList(MaterialRequest request = null);
        void SaveMaterial(Material material);
        void DeleteMaterial(List<int> ids);

        Classification GetClassification(int id);
        IEnumerable<Classification> GetClassificationList(ClassificationRequest request = null);
        void SaveClassification(Classification classification);
        void DeleteClassification(List<int> ids);

        Supplier GetSupplier(int id);
        IEnumerable<Supplier> GetSupplierList(SupplierRequest request = null);
        void SaveSupplier(Supplier supplier);
        void DeleteSupplier(List<int> ids);

        MaterialSupplier GetMaterialSupplier(int mid,int sid);
        IEnumerable<MaterialSupplier> GetMaterialSupplierList(MaterialSupplierRequest request = null);
        void SaveMaterialSupplier(MaterialSupplier materialSupplier);
        void DeleteMaterialSupplier(int mid, int sid);
    }
}
