namespace Monitoring.Exceptions;

public abstract class ApplicationException : Exception, IApplicationException
{
    public ApplicationException() : base() { }

    public ApplicationException(string message) : base(message) { }

    public virtual string ErrorCode => base.GetType().Name.Replace(nameof(Exception), string.Empty, StringComparison.OrdinalIgnoreCase);
}