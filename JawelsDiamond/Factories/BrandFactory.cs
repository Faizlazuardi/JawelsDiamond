using JawelsDiamond.Models;

namespace JawelsDiamond.Factory
{
    public class BrandFactory
    {
        public static MsBrand CreateBrand(string brandName, string brandCountry, string brandClass)
        {
            MsBrand brand = new MsBrand();
            brand.BrandName = brandName;
            brand.BrandCountry = brandCountry;
            brand.BrandClass = brandClass;
            return brand;
        }
    }
}