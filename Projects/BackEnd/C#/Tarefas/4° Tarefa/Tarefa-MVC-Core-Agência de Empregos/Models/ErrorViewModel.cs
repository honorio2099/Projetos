using System;

namespace Tarefa_MVC_Core_Agência_de_Empregos.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
