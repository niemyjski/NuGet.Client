// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace NuGet.VisualStudio
{
    /// <summary>
    /// contain information about project where we're executing nuget actions
    /// </summary>
    [ComImport]
    [Guid("7ce0caae-1b99-4cd1-80bf-348972975bcf")]
    public interface IVsPackageProjectMetadata
    {
        /// <summary>
        /// guid for batch events of the project
        /// </summary>
        string Guid { get; }

        /// <summary>
        /// name of the project
        /// </summary>
        string Name { get; }

        /// <summary>
        /// full path of the project
        /// </summary>
        string FullPath { get; }

        /// <summary>
        /// target framework of the project
        /// </summary>
        string TargetFramework { get; }
    }
}
