// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace NuGet.VisualStudio
{
    /// <summary>
    /// Contains batch events which are raised when packages are installed or uninstalled from projects and the current
    /// solution.
    /// </summary>
    [ComImport]
    [Guid("3b76690b-eb3e-4cfa-b5af-6574c567c842")]
    public interface IVsPackageInstallerProjectEvents
    {
        /// <summary>
        /// Raised when installing/ uninstalling packages in a batch starts for a project
        /// </summary>
        event VsPackageProjectEventHandler BatchStart;

        /// <summary>
        /// Raised when installing/ uninstalling packages in a batch ends for a project
        /// </summary>
        event VsPackageProjectEventHandler BatchEnd;

    }
}