using SimpleSeoMonitor.Domain.Interfaces;

namespace SimpleSeoMonitor.Domain.Core
{
    public class QueryExecutor(IServiceProvider serviceProvider) : IQueryExecutor
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            if (handlerType == null)
                throw new InvalidOperationException($"Handler for query type: {query.GetType().Name} & result type: {typeof(TResult).Name} not found");

            dynamic handler = _serviceProvider.GetService(handlerType);
            if (handler == null)
                throw new InvalidOperationException($"Failed to instantiate handler for query type {query.GetType().Name} and result type {typeof(TResult).Name}");

            return handler.HandleAsync((dynamic)query);
        }
    }
}
