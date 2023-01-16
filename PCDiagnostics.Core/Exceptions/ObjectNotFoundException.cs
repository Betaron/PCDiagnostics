namespace PCDiagnostics.Core.Exceptions;

public class ObjectNotFoundException : Exception
{
	internal string message;
	public ObjectNotFoundException(string message = "Object not found.") : base()
	{
		this.message = message;
	}
}
