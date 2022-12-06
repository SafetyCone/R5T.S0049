using System;


namespace R5T.S0049
{
    public static class Instances
    {
        public static F0080.IRepositoryOperations RepositoryOperations { get; } = F0080.RepositoryOperations.Instance;
        public static F0000.IWebOperator WebOperator { get; } = F0000.WebOperator.Instance;
        public static F0034.IWindowsExplorerOperator WindowsExplorerOperator { get; } = F0034.WindowsExplorerOperator.Instance;
    }
}