namespace Core.Application.Pipelines.Logging;

public interface ILoggableLoginRequest
{
    public string? Password { get; set; }
}
