using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rando
{
    internal class ColorGradient
    {
        private readonly Color[] gradient = new Color[]
        {
            Color.FromArgb(255, 144, 238, 144), // Vert clair
            Color.FromArgb(255, 162, 216, 128),
            Color.FromArgb(255, 180, 194, 112),
            Color.FromArgb(255, 198, 172, 96),
            Color.FromArgb(255, 216, 150, 80),
            Color.FromArgb(255, 234, 128, 64),
            Color.FromArgb(255, 244, 106, 48),
            Color.FromArgb(255, 248,  84, 36),
            Color.FromArgb(255, 252,  62, 24),
            Color.FromArgb(255, 254,  48, 18),
            Color.FromArgb(255, 255,  32, 12),
            Color.FromArgb(255, 255,  16,  6),
            Color.FromArgb(255, 255,   0,  0)  // Rouge vif
        };
    }
}
