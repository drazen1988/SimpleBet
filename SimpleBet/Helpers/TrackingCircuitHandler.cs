using Microsoft.AspNetCore.Components.Server.Circuits;

namespace SimpleBet.Helpers
{
    public class TrackingCircuitHandler : CircuitHandler
    {
        private HashSet<Circuit> _circuits = new HashSet<Circuit>();

        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            _circuits.Add(circuit);
            return Task.CompletedTask;
        }

        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            _circuits.Remove(circuit);
            return Task.CompletedTask;
        }

        public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnCircuitClosedAsync(circuit, cancellationToken);
        }

        public int ConnectedCircuits => _circuits.Count;
    }
}
