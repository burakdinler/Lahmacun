using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            //Process.Start("git", "init");
            //Process.Start("git","remote add origin https://github.com/burakdinler/Lahmacun.git");
            //Process.Start("git", "fetch");
            //Process.Start("git", "archive --output=archived_changes.zip HEAD $(git diff --diff-filter=ACMRTUXB --name-only 95a1550a d4fea7b8)");


            string rootPath = Repository.Init("D:\\Deneme\\");
            //var repo = new Repository("D:\\Deneme\\");
            //repo.Network.Remotes.Add("origin", "https://github.com/burakdinler/Lahmacun.git");
            string logMessage = "";
            using (var repo = new Repository(rootPath))
            {
                var remote = repo.Network.Remotes["origin"];
                var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                Commands.Fetch(repo, remote.Name, refSpecs, null, logMessage);
            }

            Console.WriteLine(logMessage);
        }
    }
}
