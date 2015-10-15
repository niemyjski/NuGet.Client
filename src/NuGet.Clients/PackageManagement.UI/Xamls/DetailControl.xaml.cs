// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace NuGet.PackageManagement.UI
{
    // The DataContext of this control is DetailControlModel, i.e. either
    // PackageSolutionDetailControlModel or PackageDetailControlModel.
    public partial class DetailControl : UserControl
    {
        private PackageManagerControl _control;

        public DetailControl()
        {
            InitializeComponent();
            // !!! _solutionView.MaxHeight = _self.FontSize * 15; 
            // !!! need to make it resizable

            DataContextChanged += PackageSolutionDetailControl_DataContextChanged;
        }

        private void PackageSolutionDetailControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is DetailControlModel)
            {
                _root.Visibility = Visibility.Visible;
            }
            else
            {
                _root.Visibility = Visibility.Collapsed;
            }
        }

        private void ExecuteOpenLicenseLink(object sender, ExecutedRoutedEventArgs e)
        {
            var hyperlink = e.OriginalSource as Hyperlink;
            if (hyperlink != null
                && hyperlink.NavigateUri != null)
            {
                Control.Model.UIController.LaunchExternalLink(hyperlink.NavigateUri);
                e.Handled = true;
            }
        }

        public void ScrollToHome()
        {
            _root.ScrollToHome();
        }

        public void Refresh()
        {
            var model = DataContext as DetailControlModel;
            model?.Refresh();
        }

        private void ProjectInstallButtonClicked(object sender, EventArgs e)
        {
            var model = (DetailControlModel)DataContext;
            var userAction = new UserAction(
                NuGetProjectActionType.Install,
                model.Id,
                model.SelectedVersion.Version);
            ExecuteUserAction(userAction);
        }

        private void ProjectUninstallButtonClicked(object sender, EventArgs e)
        {
            var model = (PackageDetailControlModel)DataContext;
            var userAction = new UserAction(
                NuGetProjectActionType.Uninstall,
                model.Id,
                model.InstalledVersion);
            ExecuteUserAction(userAction);
        }


        private void SolutionInstallButtonClicked(object sender, EventArgs e)
        {
            var model = (PackageSolutionDetailControlModel)DataContext;            
            var userAction = new UserAction(
                NuGetProjectActionType.Install,
                model.Id,
                model.SelectedVersion.Version);
            ExecuteUserAction(userAction);
        }

        private void SolutionUninstallButtonClicked(object sender, EventArgs e)
        {
            var model = (PackageSolutionDetailControlModel)DataContext;

            var userAction = new UserAction(
                NuGetProjectActionType.Uninstall,
                model.Id,
                null);
            ExecuteUserAction(userAction);
        }        

        private void ExecuteUserAction(UserAction action)
        {
            Control.ExecuteAction(
                action,
                nugetUi =>
                {
                    var model = (DetailControlModel)DataContext;

                    // Set the properties by reading the current options on the UI
                    nugetUi.FileConflictAction = model.Options.SelectedFileConflictAction.Action;
                    nugetUi.DependencyBehavior = model.Options.SelectedDependencyBehavior.Behavior;
                    nugetUi.RemoveDependencies = model.Options.RemoveDependencies;
                    nugetUi.ForceRemove = model.Options.ForceRemove;
                    nugetUi.Projects = model.GetSelectedProjects(action.Action);
                    nugetUi.DisplayPreviewWindow = model.Options.ShowPreviewWindow;
                });
        }

        public PackageManagerControl Control
        {
            get { return _control; }

            set
            {
                if (_control == null)
                {
                    // register with the UI controller the first time we get the control model
                    var controller = value.Model.UIController as NuGetUI;
                    if (controller != null)
                    {
                        controller.DetailControl = this;
                    }
                }

                _control = value;
            }
        }
    }
}