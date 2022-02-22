using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swordfish.Logic.Models
{
    public class RemoveMessageWithId
    {
        public RemoveMessageWithId(string id, int milisecondsToAutoDelete)
        {
            Id = id;
            MilisecondsToAutoDelete = milisecondsToAutoDelete;
        }

        public string Id { get; set; }
        public int MilisecondsToAutoDelete { get; set; }
    }
}
