// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using NuGet.ProjectManagement;

namespace NuGet.VisualStudio
{
    internal class VsPackageProjectMetadata : IVsPackageProjectMetadata
    {
        public VsPackageProjectMetadata(NuGetProject project)
        {
            Guid = project.Guid;

            string name;
            Name = project.TryGetMetadata(NuGetProjectMetadataKeys.Name, out name) ? name : string.Empty;

            string fullPath;
            FullPath = project.TryGetMetadata(NuGetProjectMetadataKeys.FullPath, out fullPath) ? fullPath : string.Empty;

            string targetFramework;
            TargetFramework = project.TryGetMetadata(NuGetProjectMetadataKeys.TargetFramework, out targetFramework) ? targetFramework : string.Empty;
        }

        public string Guid { get; }

        public string Name { get; }

        public string FullPath { get; }

        public string TargetFramework { get; }
    }
}