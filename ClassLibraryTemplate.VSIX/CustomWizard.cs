namespace ClassLibraryTemplate.VSIX
{
    using EnvDTE;
    using Microsoft.VisualStudio.TemplateWizard;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Custom Winzard Class.
    /// </summary>
    public class CustomWizard : IWizard
    {
        /// <summary>
        /// Runs custom wizard logic before opening an item in the template.
        /// </summary>
        /// <param name="projectItem">The project item that will be opened.</param>
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        /// <summary>
        ///  Runs custom wizard logic when a project has finished generating.
        /// </summary>
        /// <param name="project">The project that finished generating.</param>
        public void ProjectFinishedGenerating(Project project)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when a project item has finished generating.
        /// </summary>
        /// <param name="projectItem">The project item that finished generating.</param>
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when the wizard has completed all tasks.
        /// </summary>
        public void RunFinished()
        {
        }

        /// <summary>
        ///  Runs custom wizard logic at the beginning of a template wizard run.
        /// </summary>
        /// <param name="automationObject">The automation object being used by the template wizard.</param>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        /// <param name="runKind">A Microsoft.VisualStudio.TemplateWizard.WizardRunKind indicating the type of wizard run.</param>
        /// <param name="customParams">The custom parameters with which to perform parameter replacement in the project.</param>
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            this.SetupCustomParameters(replacementsDictionary);
        }

        /// <summary>
        ///  Indicates whether the specified project item should be added to the project.
        /// </summary>
        /// <param name="filePath">The path to the project item.</param>
        /// <returns>true if the project item should be added to the project; otherwise, false.</returns>
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        /// <summary>
        /// Sets up costum parameters.
        /// </summary>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        private void SetupCustomParameters(Dictionary<string, string> replacementsDictionary)
        {
            try
            {
                var solutionDirectory = replacementsDictionary["$solutiondirectory$"];
                var projectDirectory = replacementsDictionary["$destinationdirectory$"] + "\\";

                var solutionDirPath = new Uri(solutionDirectory);
                var projectDirPath = new Uri(projectDirectory);

                var diff = projectDirPath.MakeRelativeUri(solutionDirPath);
                var relativePath = diff.OriginalString.Replace("/", "\\");

                replacementsDictionary.Add("$relativepathfromsolutiondirectory$", relativePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}