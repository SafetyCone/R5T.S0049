using System;
using System.Threading.Tasks;


namespace R5T.S0049
{
    class Program
    {
        static async Task Main()
        {
            //await RepositoryScripts.Instance.CreateNewRemote();
            //await RepositoryScripts.Instance.ExistsRemote();
            await RepositoryScripts.Instance.DeleteRemote();

            //await RepositoryScripts.Instance.CloneRemoteToLocal();
            //RepositoryScripts.Instance.ExistsLocal();
            //RepositoryScripts.Instance.DeleteLocal();
        }
    }
}