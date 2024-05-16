using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;

namespace DFC.Common.SharedContent.Pkg.Netcore.Middleware
{
    public interface IFunctionContextAccessor
    {
        FunctionContext FunctionContext { get; set; }
    }
}
