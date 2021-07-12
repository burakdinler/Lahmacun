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


            string rootPath = "D:\\Deneme\\";
            string url = "https://github.com/burakdinler/Lahmacun.git";
            string logMessage = "";
            try
            {
                Repository.Clone(url, rootPath);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }

            using (var repo = new Repository(rootPath))
            {
                var remote = repo.Network.Remotes["origin"];
                var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                Commands.Fetch(repo, remote.Name, refSpecs, null, logMessage);
            }

            List<string> hashes = new List<string>();
            using (var repo = new Repository(rootPath))
            {
                int j = 0;
                foreach (Commit repoCommit in repo.Commits)
                {
                    hashes.Add(repoCommit.Sha.Substring(0, 8));
                    Console.WriteLine(hashes[j]);
                    j++;
                }

                for (int i = 0; i < hashes.Count; i++)
                {
                    try
                    {
                        //git archive --output=archived_changes.zip HEAD $(git diff --diff-filter=ACMRTUXB --name-only hash1 hash2)

                        //ProcessStartInfo commandInfo = new ProcessStartInfo();
                        //commandInfo.WorkingDirectory = rootPath;
                        //commandInfo.UseShellExecute = false;
                        //commandInfo.RedirectStandardInput = true;
                        //commandInfo.RedirectStandardOutput = true;
                        //commandInfo.FileName = "git.exe";
                        //Process process = Process.Start("git",string.Format("archive --output=archived_changes{0}.zip HEAD $("+Process.Start("git",  string.Format("diff --diff-filter=ACMRTUXB --name-only {0} {1}", hashes[i], hashes[i + 1]) +")"),i.ToString()));
                        //process.Close();


                        //Process p1 = Process.Start("git",
                        //  string.Format("diff --diff-filter=ACMRTUXB --name-only {0} {1}", hashes[i], hashes[i + 1]) +
                        //    ")");

                        //Process.Start("git",
                        //    string.Format("archive--output = archived_changes{0}.zip HEAD $()", i.ToString()));

                        Process p1 = new Process();

                        p1.StartInfo.UseShellExecute = false;
                        p1.StartInfo.FileName = "D:\\52HertzAppCodes\\DeltaToolFW\\DeltaToolFW\\OperationsLibrary\\gitdiff.bat";

                        p1.StartInfo.WorkingDirectory = rootPath;


                        p1.StartInfo.RedirectStandardOutput = true;

                        p1.StartInfo.Arguments = ""+i.ToString()+" "+hashes[i]+" "+hashes[i+1];
                        p1.Start();
                    }
                    catch (Exception e)
                    {

                    }
                }


            }

            Console.WriteLine(logMessage);
        }
    }
}
