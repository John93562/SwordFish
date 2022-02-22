using Swordfish.Login.Commands;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Swordfish.WPF.Logic.Commands
{
    public class NavigateToBrowserCommand : AsyncCommandBase
    {
        
        public override async Task ExecuteMethod(object parameter)
        {
            await Task.Run(() =>
            {
                if (parameter is string)
                {
                    string par = (string)parameter;
                    Process myProcess = new Process();

                    try
                    {
                        myProcess.StartInfo.UseShellExecute = true;
                      

                        myProcess.StartInfo.FileName = par;
                        myProcess.Start();
                    }
                    catch (Exception eχ)
                    {
                        Console.WriteLine(eχ.Message);
                    }


                }
            });
        }
    }

}
