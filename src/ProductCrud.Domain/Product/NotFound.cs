using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ProductCrud.Product
{
    internal class NotFound
    {
    }
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(string details)
             : base(ProductCrudDomainErrorCodes.ProducNotFoundCode,
                   ProductCrudDomainErrorCodes.ProducNotFoundMessage)
        {
            WithData("details", details);
        }
    }
}
