using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationsLibrary;

namespace DeltaToolCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            new GitOperations().GetDiff();
        }
    }
}
