using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace AutomationClientApp1
{
    public static class Launcher
    {
        private static Process targetProcess;
        private static AutomationElement window;

        public static void Launch(string applicationPath, string processName)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(applicationPath);
                startInfo.WorkingDirectory = Path.GetDirectoryName(applicationPath);
                startInfo.UseShellExecute = false;
                targetProcess = Process.Start(startInfo);
                int runningTime = 0;
                while (targetProcess.MainWindowHandle.Equals(IntPtr.Zero))
                {
                    if (runningTime > 5000)
                    {
                        throw new Exception("Could not launch " + applicationPath);
                    }
                    Thread.Sleep(100);
                    runningTime += 100;
                    targetProcess.Refresh();
                }

                window = AutomationElement.FromHandle(targetProcess.MainWindowHandle);
            }
            catch
            {
                window = null;
                UnloadApp();
            }
        }

        public static void UnloadApp()
        {
            if (targetProcess != null)
            {
                targetProcess.Kill();
                targetProcess.Dispose();
                targetProcess = null;
            }
        }

        public static AutomationElement FindControlByAutomationId(string id)
        {
            Condition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, id, PropertyConditionFlags.IgnoreCase);
            TreeWalker treeWalker = new TreeWalker(condition);
            return treeWalker.GetFirstChild(window);
        }

        public static string GetGridItem(string id, int row, int column)
        {
            var aeListView = FindControlByAutomationId(id);
            var aeGrid = aeListView.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
            var item = aeGrid.GetItem(row, column);
            return item?.Current.Name;
        }

        public static string GetTableItem(string id, int row, int column)
        {
            var aeListView = FindControlByAutomationId(id);
            var aeTable = aeListView.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
            var item = aeTable.GetItem(row, column);
            return item?.Current.Name;
        }
    }
}
