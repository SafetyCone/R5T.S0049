using System;
using System.Threading.Tasks;


namespace R5T.S0049
{
    class Program
    {
        static async Task Main()
        {
            /// Remote.
            //await RepositoryScripts.Instance.CreateNewRemote();
            //await RepositoryScripts.Instance.ExistsRemote();
            //await RepositoryScripts.Instance.DeleteRemote();

            /// Local.
            //await RepositoryScripts.Instance.CloneRemoteToLocal();
            //RepositoryScripts.Instance.ExistsLocal();
            //RepositoryScripts.Instance.DeleteLocal();

            /// Joint.
            await RepositoryScripts.Instance.CreateRepository_SpecifyLocalDirectory();
            await RepositoryScripts.Instance.DeleteRepository_SpecifyLocalDirectory();
        }
    }
}