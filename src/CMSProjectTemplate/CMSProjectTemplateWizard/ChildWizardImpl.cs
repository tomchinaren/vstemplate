using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using System.Windows.Forms;

namespace CMSProjectTemplateWizard
{
    public class ChildWizardImpl : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string safeprojectname = RootWizardImpl.GlobalParameters.Where(p => p.Key == "$safeprojectname$").First().Value;
            var msg = replacementsDictionary["$safeprojectname$"] + " to>> " + safeprojectname;
            replacementsDictionary["$safeprojectname$"] = safeprojectname;


            MessageBox.Show(msg);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
