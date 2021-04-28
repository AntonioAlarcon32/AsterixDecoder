using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface DataBlock
    {
        int GetLength();

        int GetCategory();

        TimeSpan GetTime();

        string GetTypeOfMessage();

        double[] GetWGS84Coordinates();

    }
}
