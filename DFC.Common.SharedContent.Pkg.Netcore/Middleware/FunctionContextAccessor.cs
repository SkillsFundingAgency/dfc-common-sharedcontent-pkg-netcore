using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;

namespace DFC.Common.SharedContent.Pkg.Netcore.Middleware
{
    public class FunctionContextAccessor : IFunctionContextAccessor
    {
        private static AsyncLocal<FunctionContextRedirect> _currentContext = new AsyncLocal<FunctionContextRedirect>();

        public virtual FunctionContext FunctionContext
        {
            get
            {
                return _currentContext.Value?.HeldContext;
            }
            set
            {
                var holder = _currentContext.Value;
                if (holder != null)
                {
                    // Clear current context trapped in the AsyncLocals, as its done.
                    holder.HeldContext = null;
                }

                if (value != null)
                {
                    // Use an object indirection to hold the context in the AsyncLocal,
                    // so it can be cleared in all ExecutionContexts when its cleared.
                    _currentContext.Value = new FunctionContextRedirect { HeldContext = value };
                }
            }
        }

        private class FunctionContextRedirect
        {
            public FunctionContext HeldContext;
        }
    }
}
