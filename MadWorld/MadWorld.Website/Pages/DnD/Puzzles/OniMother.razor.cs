using System;
using System.Collections.Immutable;
using MadWorld.Website.Models.DnD.OniMother;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.DnD.Puzzles
{
	public partial class OniMother
	{
		private readonly ImmutableList<string> _colors
			= ImmutableList.CreateRange(new List<string>() { "Blue", "Red" , "Green", "Yellow" });

        private List<Totem> _totems { get; set; } = new();

        protected override void OnInitialized()
        {
            _totems.Add(new() { IndexColor = 0, Name = "A" });
            _totems.Add(new() { IndexColor = 2, Name = "B" });
            _totems.Add(new() { IndexColor = 0, Name = "C" });
            _totems.Add(new() { IndexColor = 3, Name = "D" });
            _totems.Add(new() { IndexColor = 1, Name = "E" });

            base.OnInitialized();
        }

        public void Press(Totem totem)
        {
            switch(totem.Name)
            {
                case "A":
                    PressA();
                    break;
                case "B":
                    PressB(true);
                    break;
                case "C":
                    PressC(true);
                    break;
                case "D":
                    PressD();
                    break;
                case "E":
                    PressE(true);
                    break;
                default:
                    break;
            }
        }

        public static void PressA()
        {
            // Nothing will change
        }

        public void PressB(bool triggerOtherTotem)
        {
            ChangeColorTotem("B");

            if (triggerOtherTotem)
            {
                PressC(false);
                PressD();
                PressE(false);
            }
        }

        public void PressC(bool triggerOtherTotem)
        {
            ChangeColorTotem("C");

            if (triggerOtherTotem)
            {
                PressD();
            }
        }

        public void PressD()
        {
            ChangeColorTotem("D");
        }

        public void PressE(bool triggerOtherTotem)
        {
            ChangeColorTotem("E");

            if (triggerOtherTotem)
            {
                PressD();
            }
        }

        private void ChangeColorTotem(string name)
        {
            Totem totem = _totems.FirstOrDefault(t => t.Name == name, new Totem());
            totem.IndexColor = FindNewColorIndex(totem.IndexColor);
        }

        private string GetColorName(Totem totem) => _colors[totem.IndexColor];

        private static int FindNewColorIndex(int currentIndex)
        {
            if (currentIndex is < 0 or >= 3)
            {
                return 0;
            }

            return ++currentIndex;
        }
    }
}

