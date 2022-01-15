using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace Salak_Gergely_Lab2
{
    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }
    class DoughnutMachine
    {
        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;

        public DoughnutMachine()
        {
            InitializeComponent();
        }

        private DoughnutType mFlavor;
        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }

        public bool Enabled
        {
            set
            {
                doughnutTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                doughnutTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        private System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();
        public Doughnut this[int Index]
        {
            get
            {
                return (Doughnut)mDoughnuts[Index];
            }
            set
            {
                mDoughnuts[Index] = value;
            }
        }

        DispatcherTimer doughnutTimer;

        private void InitializeComponent()
        {
            this.doughnutTimer = new DispatcherTimer();
            this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }

        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            mDoughnuts.Add(aDoughnut);
            DoughnutComplete();
        }

        public void MakeDoughnuts(DoughnutType dFlavor)
        {
            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }
    }

    class Doughnut
    {
        private DoughnutType mFlavor;
        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private float mPrice = .50F;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }
        }
        public Doughnut(DoughnutType aFlavor) // constructor
        {
            mTimeOfCreation = DateTime.Now;
            mFlavor = aFlavor;
        }

        void gigi()
        {
            var x = Price;
            Price = 23;
        }
    }
}
