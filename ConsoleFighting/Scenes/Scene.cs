using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFighting.Scenes
{
    internal abstract class Scene
    {
        public abstract void Show();
        protected void Clear()
        {
            Console.Clear();
        }
    }
}
