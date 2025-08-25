using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _Novabrush{
    public static class Globals {
        public static TextBlock MousePositionLabel { get; private set; }
        public static Canvas CanvasPanelLabel { get; private set; }

        public static void Initialize(MainWindow mainWindow){
            MousePositionLabel = mainWindow.lbl_MousePos;
            CanvasPanelLabel = mainWindow.MainCanvas;
        }
    }
}
