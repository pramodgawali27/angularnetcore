using System.Runtime.Intrinsics.X86;
using System.Collections.Specialized;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndTypesSpecification:BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpecification(ProductSpecParam productParams):
        base(x=>
        (string.IsNullOrEmpty(productParams.Search)|| x.Name.ToLower().Contains(productParams.Search)) &&
           (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) && 
           (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

            AddOrderBy(x=>x.Name);
            ApplyPaging(productParams.PageSize*(productParams.PageIndex-1),
            productParams.PageSize);
            if(!string.IsNullOrEmpty(productParams.Sort)){
                switch(productParams.Sort){
                    case "PriceAsc":
                         AddOrderBy(x=>x.Price);
                         break;
                    case "PriceDesc":
                         AddOrderByDesc(x=>x.Price);
                         break;
                    default: 
                          AddOrderBy(x=>x.Name);  
                          break;
                }
            }

        }

        public ProductsWithBrandsAndTypesSpecification(int id):
            base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }
}
