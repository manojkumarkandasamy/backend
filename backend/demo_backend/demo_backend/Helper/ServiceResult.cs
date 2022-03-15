using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acima_mbl_bknd.Helpers
{
    public enum ServiceStatus
    {
        Failed,
        Invalid,
        Success
    }

    public class ServiceResult<T>
    {
        public ServiceStatus Status { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
    }
}
