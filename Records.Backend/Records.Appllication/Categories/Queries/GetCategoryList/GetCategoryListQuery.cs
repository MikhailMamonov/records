using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Appllication.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery: IRequest<CategoryListVm>
    {
    }
}
