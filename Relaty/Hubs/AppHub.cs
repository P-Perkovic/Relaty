using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Hubs
{
    public class AppHub : Hub, IAppHub
    {
        private IHubContext<AppHub> _context;

        public AppHub(IHubContext<AppHub> context)
        {
            _context = context;
        }

        public async Task Refresh()
        {
            await _context.Clients.All.SendAsync("Refresh");
        }
    }
}
