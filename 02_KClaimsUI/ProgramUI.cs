using _02_KClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaimsUI
{
    public class ProgramUI
    {
        ClaimRepo _claimRepo = new ClaimRepo();
    }
    public void Run()
    {
        RunMenu();
    }
    public void RunMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();

            Console.WriteLine("Weclome to Komodo Claims Department, Please select you option \n" +
                "1. See All Claims \n" +
                "2. Review Next Claim \n" +
                "3. Enter New Claim");
            int input = int.Parse(Console.ReadLine());
            

        }
    }
}
