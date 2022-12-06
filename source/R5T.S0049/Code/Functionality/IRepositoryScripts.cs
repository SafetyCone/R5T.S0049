using System;
using System.Threading.Tasks;

using R5T.F0033;
using R5T.F0042;
using R5T.F0047;
using R5T.T0132;


namespace R5T.S0049
{
	[FunctionalityMarker]
	public partial interface IRepositoryScripts : IFunctionalityMarker
	{
        public async Task DeleteRepository_SpecifyLocalDirectory()
        {
            /// Inputs
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.Example";
            var isPrivate = false;
            var repositoriesDirectoryPath =
                DirectoryPaths.Instance.TemporaryRepositoriesPath
                ;


            /// Run.
            var localRepositoryDirectoryPath = F0057.RepositoryDirectoryPathOperator.Instance.GetRepositoryDirectoryPath_FromRepositoriesDirectoryPath(
                repositoriesDirectoryPath,
                name);

            await Instances.RepositoryOperations.DeleteRepository(
                owner,
                name,
                isPrivate,
                localRepositoryDirectoryPath);
        }

        public async Task CreateRepository()
        {
            // Inputs
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.Example";
            var description = "An example repository.";
            var isPrivate = true;


            /// Run.
            var repositoryContext = F0089.RepositoryContextOperations.Instance.GetRepositoryContext(
                owner,
                name,
                description,
                isPrivate);

            var remoteRepsitoryUrl = await Instances.RepositoryOperations.CreateRepository(
                repositoryContext);

            /// Show outputs.
            Instances.WindowsExplorerOperator.OpenDirectoryInExplorer(
                repositoryContext.LocalDirectoryPath);

            Instances.WebOperator.OpenUrlInDefaultBrowser(
                remoteRepsitoryUrl);
        }

        public async Task CreateRepository_SpecifyLocalDirectory()
        {
            /// Inputs
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.Example";
            var description = "An example repository.";
            var isPrivate = true;
            var repositoriesDirectoryPath =
                DirectoryPaths.Instance.TemporaryRepositoriesPath
                ;


            /// Run.
            var repositoryNameContext = F0089.RepositoryContextOperations.Instance.GetRepositoryContext(
                name,
                isPrivate);

            var localRepositoryDirectoryPath = F0057.RepositoryDirectoryPathOperator.Instance.GetRepositoryDirectoryPath_FromRepositoriesDirectoryPath(
                repositoriesDirectoryPath,
                repositoryNameContext.PrivacyAdjustedRepositoryName);

            var repositoryContext = await Instances.RepositoryOperations.CreateRepository(
                owner,
                repositoryNameContext.PrivacyAdjustedRepositoryName,
                description,
                isPrivate,
                localRepositoryDirectoryPath);

            /// Show outputs.
            Instances.WindowsExplorerOperator.OpenDirectoryInExplorer(
                localRepositoryDirectoryPath);

            Instances.WebOperator.OpenUrlInDefaultBrowser(
                repositoryContext.RemoteUrl);
        }

        /// <summary>
        /// Non-idempotently clones a remote GitHub repository to a local repository directory.
        /// (Will error if the repository already exists.)
        /// </summary>
        public async Task CloneRemoteToLocal()
		{
            /// Inputs.
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.S0051";
            var isPrivate = true;

            /// Run.
            var gitHubRepositoryName = F0044.RepositoryNameOperator.Instance.AdjustName_ForPrivacy(name, isPrivate);

			// Safety check is not needed, since clone method is non-idempotent.

			string localRepositoryDirectoryPath = await RemoteRepositoryOperator.Instance.CloneToLocal(
				owner,
				gitHubRepositoryName);

            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                Z0015.FilePaths.Instance.OutputTextFilePath,
                $"{gitHubRepositoryName}: Local GitHub repository directory path:\n\t{localRepositoryDirectoryPath}");
        }

		/// <summary>
		/// Non-idempotently create a new remote GitHub repository.
		/// (Will error if the repository already exists.)
		/// </summary>
		public async Task CreateNewRemote()
		{
			/// Inputs.
			var owner =
				//GitHubOwners.Instance.DavidCoats
				GitHubOwners.Instance.SafetyCone
				;
			var name = "R5T.S0051";
			var description = "Test repository";
			var isPrivate = true;


            /// Run.
            var gitHubRepositoryName = F0044.RepositoryNameOperator.Instance.AdjustName_ForPrivacy(name, isPrivate);

            var repositoryUrl = await RemoteRepositoryOperator.Instance.CreateRepository_NonIdempotent(
				owner,
                gitHubRepositoryName,
				description,
				isPrivate);

			NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
				Z0015.FilePaths.Instance.OutputTextFilePath,
				$"GitHub repository HTML URL:\n\t{repositoryUrl}");
		}

        public void DeleteLocal()
        {
            /// Inputs.
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.S0051";
            var isPrivate = true;


            /// Run.
            var gitHubRepositoryName = F0044.RepositoryNameOperator.Instance.AdjustName_ForPrivacy(name, isPrivate);

            var repositoryLocalDirectoryPath = LocalRepositoryOperator.Instance.Delete(
                owner,
                gitHubRepositoryName);

            var gitHubOwnedRepositoryName = F0046.RepositoryNameOperator.Instance.GetOwnedRepositoryName(
                owner,
                gitHubRepositoryName);

            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                Z0015.FilePaths.Instance.OutputTextFilePath,
                $"{gitHubOwnedRepositoryName} - Deleted local repository:\n\t{repositoryLocalDirectoryPath}");
        }

		/// <summary>
		/// Deletes a remote repository.
		/// </summary>
		public async Task DeleteRemote()
		{
            /// Inputs.
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.S0051";
            var isPrivate = true;


			/// Run.
			var gitHubRepositoryName = F0044.RepositoryNameOperator.Instance.AdjustName_ForPrivacy(name, isPrivate);

			await RemoteRepositoryOperator.Instance.DeleteRepository_NonIdempotent(
				owner,
				gitHubRepositoryName);

			var gitHubOwnedRepositoryName = F0046.RepositoryNameOperator.Instance.GetOwnedRepositoryName(
				owner,
				gitHubRepositoryName);

            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                Z0015.FilePaths.Instance.OutputTextFilePath,
                $"{gitHubOwnedRepositoryName} - Deleted repository");
        }

		public void ExistsLocal()
		{
            /// Inputs.
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.S0050";
            var isPrivate = false;


            /// Run.
            var gitHubRepositoryName = F0044.RepositoryNameOperator.Instance.AdjustName_ForPrivacy(name, isPrivate);

            var exists = LocalRepositoryOperator.Instance.RepositoryExists(
                owner,
                gitHubRepositoryName);

            var existsString = exists
                ? "Exists"
                : "<Not found>"
                ;

            var gitHubOwnedRepositoryName = F0046.RepositoryNameOperator.Instance.GetOwnedRepositoryName(
                owner,
                gitHubRepositoryName);

            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                Z0015.FilePaths.Instance.OutputTextFilePath,
                $"{gitHubOwnedRepositoryName}: {existsString}, local GitHub repository");
        }

		/// <summary>
		/// Checks whether a remote GitHub repository exists.
		/// </summary>
		public async Task ExistsRemote()
		{
            /// Inputs.
            var owner =
                //GitHubOwners.Instance.DavidCoats
                GitHubOwners.Instance.SafetyCone
                ;
            var name = "R5T.S0050";
            var isPrivate = true;


            /// Run.
            var gitHubRepositoryName = F0044.RepositoryNameOperator.Instance.AdjustName_ForPrivacy(name, isPrivate);

			var exists = await RemoteRepositoryOperator.Instance.RepositoryExists(
				owner,
				gitHubRepositoryName);

            var gitHubOwnedRepositoryName = F0046.RepositoryNameOperator.Instance.GetOwnedRepositoryName(
                owner,
                gitHubRepositoryName);

			var existsString = exists
				? "Exists"
				: "<Not found>"
				;

            NotepadPlusPlusOperator.Instance.WriteTextAndOpen(
                Z0015.FilePaths.Instance.OutputTextFilePath,
                $"{gitHubOwnedRepositoryName}: {existsString}, remote GitHub repository");
        }
	}
}