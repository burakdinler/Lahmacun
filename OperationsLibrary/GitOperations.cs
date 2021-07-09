using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace OperationsLibrary
{
    public class GitOperations
    {
        public void GetDiff()
        {
            Process.Start("git","init");
            Process.Start("git","remote add origin https://github.com/burakdinler/Lahmacun.git");
            Process.Start("git", "archive -o D:\\Deneme\\Project\\update.zip HEAD $(git diff --name-only HEAD^)");
        }
    }
}
