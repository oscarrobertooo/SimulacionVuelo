using Microsoft.AspNetCore.SignalR;


namespace SimulacionVuelo.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(double tiempoEstimadoLLegada, double climaExterior, double comburete, double combustible, string horaTierra, double tiempoEnVuelo, double velocidad, double posicionNave)
        {
            await Clients.All.SendAsync("ReceiveMessage", tiempoEstimadoLLegada, climaExterior, comburete, combustible, horaTierra, tiempoEnVuelo, velocidad, posicionNave);
        }

    }
}
