using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project.code {
    public static class Globals
    {
        public static readonly string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";
    }
    
    public static class Game {
        public static Player player = null;

    }
}
