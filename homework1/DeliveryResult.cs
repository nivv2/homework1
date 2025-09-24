using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstproject
{
    internal class DeliveryResult
    {
        private bool Success;
        private string Comment;
        
        public DeliveryResult(bool success, string comment) {
            Success = success;
            Comment = comment;
        }
    }
}
