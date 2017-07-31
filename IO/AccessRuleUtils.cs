using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace CarLib.IO
{
    /// <summary>
    /// Utilities class to adding/removing access rule for specified directory.
    /// </summary>
    public static class AccessRuleUtils
    {
        /// <summary>
        /// Set full control access rule for Everyone on specified directory.
        /// </summary>
        /// <param name="targetDirectory">The directory to set access rule.</param>
        /// <exception cref="ArgumentException">Occurred when the directory argument is invalid.</exception>
        /// <exception cref="DirectoryNotFoundException">Occurred when the directory does not exist on disk.</exception>
        public static void SetFullControlForEveryone(string targetDirectory)
        {
            if (string.IsNullOrWhiteSpace(targetDirectory))
            {
                throw new ArgumentException("The target directory is null or whitespace only.");
            }

            if (!Directory.Exists(targetDirectory))
            {
                throw new DirectoryNotFoundException(
                    string.Format("Directory '{0}' not found on disk.", targetDirectory));
            }

            DirectorySecurity directorySecurity = Directory.GetAccessControl(targetDirectory);

            // Using this instead of the "Everyone" string means we work on non-English systems.
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var accessRule = new FileSystemAccessRule(
                everyone,
                FileSystemRights.Modify | FileSystemRights.Synchronize,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, 
                PropagationFlags.None,
                AccessControlType.Allow);

            directorySecurity.AddAccessRule(accessRule);

            Directory.SetAccessControl(targetDirectory, directorySecurity);
        }
    }
}
