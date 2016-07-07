// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NuGet.ProjectManagement
{
    /// <summary>
    /// Package events relayed to the public IVsPackageInstallerEvents
    /// </summary>
    public class PackageEvents
    {
        /// <summary>
        /// Raised when a package is about to be installed into the current solution.
        /// </summary>
        public event EventHandler<PackageEventArgs> PackageInstalling;

        /// <summary>
        /// Raised after a package has been installed into the current solution.
        /// </summary>
        public event EventHandler<PackageEventArgs> PackageInstalled;

        /// <summary>
        /// Raised when a package is about to be uninstalled from the current solution.
        /// </summary>
        public event EventHandler<PackageEventArgs> PackageUninstalling;

        /// <summary>
        /// Raised after a package has been uninstalled from the current solution.
        /// </summary>
        public event EventHandler<PackageEventArgs> PackageUninstalled;

        /// <summary>
        /// Raised after a package has been installed into a project within the current solution.
        /// </summary>
        public event EventHandler<PackageEventArgs> PackageReferenceAdded;

        /// <summary>
        /// Raised after a package has been uninstalled from a project within the current solution.
        /// </summary>
        public event EventHandler<PackageEventArgs> PackageReferenceRemoved;

        /// <summary>
        /// Raised when batch processing of install/ uninstall packages starts at a project level
        /// </summary>
        public event EventHandler<PackageEventArgs> BatchStart;

        /// <summary>
        /// Raised when batch processing of install/ uninstall packages ends at a project level
        /// </summary>
        public event EventHandler<PackageEventArgs> BatchEnd;

        internal PackageEvents()
        {
        }

        internal void NotifyInstalling(PackageEventArgs e)
        {
            PackageInstalling?.Invoke(this, e);
        }

        internal void NotifyInstalled(PackageEventArgs e)
        {
            PackageInstalled?.Invoke(this, e);
        }

        internal void NotifyUninstalling(PackageEventArgs e)
        {
            PackageUninstalling?.Invoke(this, e);
        }

        internal void NotifyUninstalled(PackageEventArgs e)
        {
            PackageUninstalled?.Invoke(this, e);
        }

        internal void NotifyReferenceAdded(PackageEventArgs e)
        {
            PackageReferenceAdded?.Invoke(this, e);
        }

        internal void NotifyReferenceRemoved(PackageEventArgs e)
        {
            PackageReferenceRemoved?.Invoke(this, e);
        }

        internal void NotifyBatchStart(PackageEventArgs e)
        {
            BatchStart?.Invoke(this, e);
        }

        internal void NotifyBatchEnd(PackageEventArgs e)
        {
            BatchEnd?.Invoke(this, e);
        }

    }
}
