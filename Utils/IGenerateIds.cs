using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Utils
{
    public interface IGenerateIds
    {
        Guid GetEnrollmentId();
    }
}
