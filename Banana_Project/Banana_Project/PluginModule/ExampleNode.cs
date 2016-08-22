using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banana_Project.PluginModule
{
    public class ExampleNode
    {
        private string pluginName = null;
        private string exampleName = null;

        public ExampleNode(string _pluginName , string _exampleName)
        {
            pluginName = _pluginName;
            exampleName = _exampleName; 
        }

        public string PluginName
        {
            get
            {
                return pluginName;
            }
        }

        public string ExampleName
        {
            get
            {
                return exampleName;
            }
        }
    }

}
