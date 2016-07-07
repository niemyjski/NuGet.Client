// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.Composition;
using NuGet.ProjectManagement;

namespace NuGet.VisualStudio
{
    /// <summary>
    /// Contains batch events to be raised when performing multiple packages install/ uninstall in a project
    /// </summary>
    [Export(typeof(IVsPackageInstallerProjectEvents))]
    [Export(typeof(VsPackageInstallerProjectEvents))]
    public class VsPackageInstallerProjectEvents : IVsPackageInstallerProjectEvents
    {
        public event VsPackageProjectEventHandler BatchStart;

        public event VsPackageProjectEventHandler BatchEnd;

        private readonly PackageEvents _eventSource;

        [ImportingConstructor]
        public VsPackageInstallerProjectEvents(IPackageEventsProvider eventProvider)
        {
            _eventSource = eventProvider.GetPackageEvents();

            _eventSource.BatchStart += NotifyBatchStart;
            _eventSource.BatchEnd += NotifyBatchEnd;
        }

        private void NotifyBatchStart(object sender, PackageEventArgs e)
        {
            BatchStart?.Invoke(new VsPackageProjectMetadata(e.Project));
        }

        private void NotifyBatchEnd(object sender, PackageEventArgs e)
        {
            BatchEnd?.Invoke(new VsPackageProjectMetadata(e.Project));
        }

    }
}
