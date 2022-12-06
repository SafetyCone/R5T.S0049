using System;

using R5T.T0131;


namespace R5T.S0049
{
	[ValuesMarker]
	public partial interface IDirectoryPaths : IValuesMarker
	{
		public string TemporaryRepositoriesPath => @"C:\Temp\Repositories";
    }
}