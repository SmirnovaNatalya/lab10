using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class VRGame: Game, IInit
    {
        public bool vrHeadset;
        public bool vrControllers;

        public bool VRHeadset { get; private set; }

        public bool VRControllers { get; private set; }

        public VRGame()
        {
            vrHeadset = true;
            vrControllers = true;
        }
        public VRGame(string name, int minNumberPlayers, int maxNumberPlayers, bool vrHeadset, bool vrControllers)
        {
            VRHeadset = vrHeadset;
            VRControllers = vrControllers;
        }

        public override void VirtualShow()
        {
            base.VirtualShow();
            Console.WriteLine($"Необходимость в VR шлеме: {vrHeadset}, необходимость в контроллерах: {vrControllers}");
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Необходимость шлема (true/false): ");
            VRHeadset = bool.Parse(Console.ReadLine());

            Console.Write("Необходимость контроллеров (true/false): ");
            VRControllers = bool.Parse(Console.ReadLine());
        }
        public override object RandomInit()
        {
            base.RandomInit();
            VRHeadset = rnd.Next(1, 2) == 1;
            VRControllers = rnd.Next(1, 2) == 1;
            return new VRGame(Name, MinNumberPlayers, MaxNumberPlayers, VRHeadset, VRControllers);
        }
    }
}
