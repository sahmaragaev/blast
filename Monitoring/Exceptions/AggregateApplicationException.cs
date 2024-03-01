namespace Monitoring.Exceptions;

public abstract class AggregateApplicationException : AggregateException, IApplicationException
{
    public AggregateApplicationException() : base() { }

    public AggregateApplicationException(string message, params Exception[] innerExceptions) : base(message, innerExceptions) { }

    public virtual string ErrorCode => base.GetType().Name.Replace(nameof(Exception), string.Empty, StringComparison.OrdinalIgnoreCase);
}