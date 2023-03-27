using Records.Appllication.Records.Queries.GetRecordList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Appllication.Categories.Queries.GetCategoryList
{
    public class CategoryListVm
    {
        public IList<CategoryLookupDto> Categories { get; set; }
    }
}
