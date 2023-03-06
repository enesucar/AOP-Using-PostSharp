using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Transactions;

namespace WebAPI.Aspects
{
    [PSerializable]
    public class TransactionAspect : MethodInterceptionAspect
    {
        public async override Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await args.ProceedAsync();
                    transactionScope.Complete();
                }
                catch
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
