namespace PiGrow.Services
{
    public interface IPiRelayController
    {
        Task SetStateAsync(bool on, CancellationToken cancellationToken = default);
        bool IsOn { get; }
    }
}