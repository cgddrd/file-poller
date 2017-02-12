using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcher
{
    interface IFileTracker
    {

        string FilePath
        {
            get;
            set;
        }

    }
}
