using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Service.Command.Client.Delete
{
    public class DeleteClientCommand : ICommand
    {
        public int ClientId { get; set; }

        public DeleteClientCommand() { }

        public DeleteClientCommand(int clientId)
        {
            ClientId = clientId;
        }
    }
}
