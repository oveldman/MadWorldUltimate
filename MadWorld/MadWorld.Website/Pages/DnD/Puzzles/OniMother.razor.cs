using System;
using System.Collections.Immutable;
using System.Timers;
using MadWorld.Website.Models.DnD.OniMother;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.DnD.Puzzles
{
	public partial class OniMother
	{
		private readonly ImmutableList<string> _colors
			= ImmutableList.CreateRange(new List<string>() { "Blue", "Red" , "Green", "Yellow" });

        private List<Totem> Totems { get; set; } = new();

        private int WaitSeconde { get; set; } = 0;
        private bool Blocked { get; set; } = false;

        private System.Timers.Timer _timer { get; set; } = new();

        private bool DoorOpen { get; set; } = false;

        protected override void OnInitialized()
        {
            Totems.Add(new() { IndexColor = 0, Name = "A" });
            Totems.Add(new() { IndexColor = 2, Name = "B" });
            Totems.Add(new() { IndexColor = 0, Name = "C" });
            Totems.Add(new() { IndexColor = 3, Name = "D" });
            Totems.Add(new() { IndexColor = 1, Name = "E" });

            base.OnInitialized();
        }

        private void Press(Totem totem)
        {
            if (Blocked || DoorOpen)
            {
                return;
            }

            Blocked = true;

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

            SetBlockTimer();
            CheckIfDoorOpen();
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
            Totem totem = Totems.FirstOrDefault(t => t.Name == name, new Totem());
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

        private void SetBlockTimer()
        {
            _timer = new();
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent!);
            _timer.Interval = 1000;
            _timer.Enabled = true;
            WaitSeconde = 0;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            WaitSeconde--;

            if (WaitSeconde < 0)
            {
                StopTimerAndUnblock();
            }

            StateHasChanged();
        }

        private void StopTimerAndUnblock()
        {
            WaitSeconde = 0;
            Blocked = false;
            _timer.Stop();
        }

        private void CheckIfDoorOpen()
        {
            DoorOpen = Totems.All(t => t.IndexColor == 0);
        }
    }
}

