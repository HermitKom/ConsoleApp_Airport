using airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airport.program.lab.Dispatcher;

namespace airport
{
    internal class program
    {
        abstract class Airport
        {

            public double speedC;
            public double altitudeC;
            public double loadC;
            public float speedM;
            public float altitudeM;
            public float loadM;
            public double Speed { get { return speedC; } set { speedC = value; } }
            public double Altitude { get { return altitudeC; } set { altitudeC = value; } }
            public void speedControl()
            {
                Console.WriteLine("Enter by what number do you want to change the speed,now it is {0}", speedC);
                bool pass = false;
                float enter;
                do
                {
                    if (!float.TryParse(Console.ReadLine(), out enter))
                    {
                        Console.WriteLine("Not a valid float, please enter another number");
                    }
                    else if (speedC + enter > speedM)
                    {
                        Console.WriteLine("You have exceeded the maximum, please enter another number");
                    }
                    else if (speedC + enter < 0)
                    {
                        Console.WriteLine("Сannot be negative, please enter another number");
                    }
                    else
                    {
                        Console.WriteLine("Your speed was {0} , you increased it for {1} . Max speed is {2} ", speedC, enter, speedM);
                        pass = true;
                        speedC += enter;
                    }
                }
                while (pass != true);

                Console.WriteLine("Now it is {0}", speedC);

            }
            public void altitudeControl()
            {
                Console.WriteLine("Enter by what number do you want to change the altitude,now it is {0}", altitudeC);
                bool pass = false;
                float enter;
                do
                {
                    if (!float.TryParse(Console.ReadLine(), out enter))
                    {
                        Console.WriteLine("Not a valid float, please enter another number");
                    }
                    else if (altitudeC + enter > altitudeM)
                    {
                        Console.WriteLine("You have exceeded the maximum, please enter another number");
                    }
                    else if (altitudeC + enter < 0)
                    {
                        Console.WriteLine("Сannot be negative, please enter another number");
                    }
                    else
                    {
                        Console.WriteLine("Your altitude was {0} , you increased it for {1} . Max altitude is {2} ", altitudeC, enter, altitudeM);
                        altitudeC += enter;
                        pass = true;
                    }
                }
                while (pass != true);
                Console.WriteLine("Now it is {0}", altitudeC);

            }

            public void dropLoad(ref double loadC)
            {

                if (loadC != 0)
                {
                    loadC = 0;
                    Console.WriteLine("Now load is {0}", loadC);
                }
                else
                {
                    Console.WriteLine("You have no cargo");
                }
            }
            public void loadControl()
            {
                float enter;
                bool pass = false;
                do
                {
                    if (altitudeC == 0)
                    {
                        Console.WriteLine("Enter by what number do you want to change the load");


                        if (!float.TryParse(Console.ReadLine(), out enter))
                        {
                            Console.WriteLine("Not a valid float, please enter another number");
                        }
                        else if (loadC + enter > loadM)
                        {
                            Console.WriteLine("You have exceeded the maximum, please enter another number");
                        }
                        else if (loadC + enter < 0)
                        {
                            Console.WriteLine("Сannot be negative, please enter another number");
                        }
                        else
                        {
                            Console.WriteLine("Your load was {0} , you increased it for {1} . Max load is {2} ", loadC, enter, loadM);
                            pass = true;

                            loadC += enter;
                        }


                        Console.WriteLine("Now it is {0}", loadC);


                    }
                    else
                    {
                        Console.WriteLine("You must be on the ground to load");
                        pass = true;
                    }
                }
                while (pass != true);



            }
            virtual public void Info()
            {
                Console.WriteLine("Current altitude ={0},Current speed ={1},Current load ={2} ", altitudeC, speedC, loadC);
            }

        }

        class MyCopter : Airport
        {

            int helnumb;
            public float screws = 0;

            private static int CopterNumber = 0;

            public MyCopter(float speedM, float altitudeM, float loadM, float screws)
            {
                this.screws = screws;
                this.speedM = speedM;
                this.altitudeM = altitudeM;
                this.loadM = loadM;
                altitudeC = 0;
                speedC = 0;
                loadC = 0;
                CopterNumber++;
                helnumb = CopterNumber;
            }
            public MyCopter(float speedM, float altitudeM, float loadM)
            {
                this.screws = 1;
                this.speedM = speedM;
                this.altitudeM = altitudeM;
                this.loadM = loadM;
                altitudeC = 0;
                speedC = 0;
                loadC = 0;
                CopterNumber++;
                helnumb = CopterNumber;
            }
            public int LoadC { get { return LoadC; } set { LoadC = value; } }
            public double SpeedC
            {
                get
                { return SpeedC; }
                set { SpeedC = value; }
            }
            public double AltitudeC { get { return AltitudeC; } set { AltitudeC = value; } }
            public static int
            CopterCount
            {
                get { return CopterNumber; }
                set
                {
                    CopterNumber = value;
                }
            }
            new public void Info()
            {
                Console.WriteLine("Current altitude ={0},Current speed ={1},Current load ={2} ", altitudeC, speedC, loadC);
            }

            public void MakeALanding()
            {
                altitudeC = 0;
                speedC = 0;
                Console.WriteLine("Helicopter number {0} landed", helnumb);
            }
            public void MakeATakeOff()
            {
                altitudeC = 400;
                speedC = 0;
                Console.WriteLine("Helicopter number {0} took off", helnumb);
            }
        }

        class MyCargoplane : Airport
        {
            int planenumb;

            private static int PlaneNumber = 0;

            public MyCargoplane(float speedM, float altitudeM, float loadM)
            {
                this.speedM = speedM;
                this.altitudeM = altitudeM;
                this.loadM = loadM;
                altitudeC = 0;
                speedC = 0;
                loadC = 0;
                PlaneNumber++;
                planenumb = PlaneNumber;
            }

            public int LoadC { get { return LoadC; } set { LoadC = value; } }
            public double SpeedC
            {
                get
                { return SpeedC; }
                set { SpeedC = value; }
            }
            public double AltitudeC { get { return AltitudeC; } set { AltitudeC = value; } }
            public static int
            CopterCount
            {
                get { return PlaneNumber; }
                set
                {
                    PlaneNumber = value;
                }
            }

            new public void Info()
            {
                Console.WriteLine("Current altitude = {0},Current speed ={1},Current load ={2} ", altitudeC, speedC, loadC);
            }
            public void MakeALanding()
            {
                altitudeC = 0;
                speedC = 0;
                Console.WriteLine("Airplane number {0} landed", planenumb);


            }
            public void MakeATakeOff()
            {
                altitudeC = 400;
                speedC = 200;
                Console.WriteLine("Airplane number {0} took off", planenumb);
            }

        }
        public class lab
        {
            static public void tab1()
            {
                Console.WriteLine("+------------------+");
                Console.WriteLine("(S)Speed control");
                Console.WriteLine("+------------------+");
                Console.WriteLine("(A)Altitude control");
                Console.WriteLine("+------------------+");
                Console.WriteLine("(L)Load control");
                Console.WriteLine("+------------------+");
                Console.WriteLine("(D)Drop load");
                Console.WriteLine("+------------------+");
                Console.WriteLine("(Q)Quit");
                Console.WriteLine("+------------------+");

                Console.WriteLine("Enter letter:");

            }
            static void Main()
            {
                Console.WriteLine("Nikita, Ivanovs, 4101BDA"); Console.WriteLine(DateTime.Now);
                MyCopter h1 = new MyCopter(400, 3000, 4000, 2);
                MyCopter h2 = new MyCopter(450, 3400, 3000);
                MyCargoplane a1 = new MyCargoplane(1400, 5000, 12000);
                MyCargoplane a2 = new MyCargoplane(1360, 4500, 11100);
                MyCargoplane a3 = new MyCargoplane(1200, 7000, 14000);

                var choosen = 'l';
                var choosen2 = 'l';
                var choosen1 = 'l';
                var choosen3 = 'l';
                var choosen4 = 'l';
                var choosen5 = 'l';
                var choosen6 = 'l';
                var choosen7 = 'l';
                MyCargoplane choseA = a1;
                MyCopter choseH = h1;

                Dispatcher d = new Dispatcher();


                do
                {
                    Console.WriteLine("Choose which aircraft do you want to take control of?");

                    Console.WriteLine("#1 Plane:");
                    a1.Info();
                    Console.WriteLine("#2 Plane:");
                    a2.Info();
                    Console.WriteLine("#3 Plane:");
                    a3.Info();

                    Console.WriteLine("#1 Copter:");
                    h1.Info();
                    Console.WriteLine("#2 Copter:");
                    h2.Info();
                    Console.WriteLine("+------------------+");

                    Console.WriteLine("Choose which aircraft do you want to take control of?");
                    Console.WriteLine("+--------------------------------+");
                    Console.WriteLine("(L)Comand or aircrafts to land");
                    Console.WriteLine("+--------------------------------+");
                    Console.WriteLine("(T)Comand or aircrafts to take off");
                    Console.WriteLine("+--------------------------------+");
                    Console.WriteLine("(A)Airplane");
                    Console.WriteLine("+--------------------------------+");
                    Console.WriteLine("(H)Helicopter");
                    Console.WriteLine("+--------------------------------+");
                    Console.WriteLine("(Q)Quit");
                    Console.WriteLine("+--------------------------------+");

                    Console.WriteLine("Enter letter:");
                    choosen = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    switch (Char.ToLower(choosen))
                    {
                        case 't':
                            d.TakeOffEvent += new AircraftsHandler(a1.MakeATakeOff);
                            d.TakeOffEvent += new AircraftsHandler(a2.MakeATakeOff);
                            d.TakeOffEvent += new AircraftsHandler(a3.MakeATakeOff);
                            d.TakeOffEvent += new AircraftsHandler(h1.MakeATakeOff);
                            d.TakeOffEvent += new AircraftsHandler(h2.MakeATakeOff);

                            d.TakeOffCommand();
                            break;
                        case 'l':
                            d.TakeOffEvent += new AircraftsHandler(a1.MakeALanding);
                            d.TakeOffEvent += new AircraftsHandler(a2.MakeALanding);
                            d.TakeOffEvent += new AircraftsHandler(a3.MakeALanding);
                            d.TakeOffEvent += new AircraftsHandler(h1.MakeALanding);
                            d.TakeOffEvent += new AircraftsHandler(h2.MakeALanding);

                            d.TakeOffCommand();
                            break;
                        case 'a':

                            do
                            {
                                Console.WriteLine("Choose which airplane do you want to take control of?");

                                Console.WriteLine("+------------------+");
                                Console.WriteLine("(1)First Airplane");
                                Console.WriteLine("+------------------+");
                                Console.WriteLine("(2)Second Airplane");
                                Console.WriteLine("+------------------+");
                                Console.WriteLine("(3)Third Airplane");
                                Console.WriteLine("+------------------+");
                                Console.WriteLine("(Q)Quit");
                                Console.WriteLine("+------------------+");

                                Console.WriteLine("Enter number:");
                                choosen1 = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (Char.ToLower(choosen1))
                                {
                                    case '1':
                                        choseA = a1;

                                        do
                                        {
                                            tab1();
                                            choosen2 = Console.ReadKey().KeyChar;
                                            Console.WriteLine();
                                            switch (Char.ToLower(choosen2))
                                            {
                                                case 's':
                                                    choseA.speedControl();
                                                    choseA = a1;
                                                    break;
                                                case 'a':
                                                    choseA.altitudeControl();
                                                    choseA = a1;
                                                    break;
                                                case 'l':
                                                    choseA.loadControl();
                                                    choseA = a1;
                                                    break;
                                                case 'd':
                                                    choseA.dropLoad(ref choseA.loadC);
                                                    choseA = a1;
                                                    break;
                                                case 'q':
                                                    choosen1 = 'q';
                                                    break;
                                                default:
                                                    Console.WriteLine("Enter correct input.");
                                                    break;

                                            }
                                        }
                                        while (choosen2 != 'q');
                                        break;
                                    case '2':
                                        choseA = a2;

                                        do
                                        {
                                            tab1();
                                            choosen3 = Console.ReadKey().KeyChar;
                                            Console.WriteLine();
                                            switch (Char.ToLower(choosen3))
                                            {
                                                case 's':
                                                    choseA.speedControl();
                                                    choseA = a2;
                                                    break;
                                                case 'a':
                                                    choseA.altitudeControl();
                                                    choseA = a2;
                                                    break;
                                                case 'l':
                                                    choseA.loadControl();
                                                    choseA = a2;
                                                    break;
                                                case 'd':
                                                    choseA.dropLoad(ref choseA.loadC);
                                                    choseA = a2;
                                                    break;
                                                case 'q':
                                                    choosen1 = 'q';
                                                    break;
                                                default:
                                                    Console.WriteLine("Enter correct input.");
                                                    break;

                                            }
                                        }
                                        while (choosen3 != 'q');
                                        break;
                                    case '3':
                                        choseA = a3;

                                        do
                                        {
                                            tab1();
                                            choosen4 = Console.ReadKey().KeyChar;
                                            Console.WriteLine();
                                            switch (Char.ToLower(choosen4))
                                            {
                                                case 's':
                                                    choseA.speedControl();
                                                    choseA = a3;
                                                    break;
                                                case 'a':
                                                    choseA.altitudeControl();
                                                    choseA = a3;
                                                    break;
                                                case 'l':
                                                    choseA.loadControl();
                                                    choseA = a3;
                                                    break;
                                                case 'd':
                                                    choseA.dropLoad(ref choseA.loadC);
                                                    choseA = a3;
                                                    break;
                                                case 'q':
                                                    choosen1 = 'q';
                                                    break;
                                                default:
                                                    Console.WriteLine("Enter correct input.");
                                                    break;

                                            }
                                        }
                                        while (choosen4 != 'q');
                                        break;
                                    case 'q':
                                        break;
                                    default:
                                        Console.WriteLine("Enter correct input.");
                                        break;

                                }
                            }
                            while (choosen1 != 'q');

                            break;

                        case 'h':

                            do
                            {
                                Console.WriteLine("Choose which helicopter do you want to take control of?");


                                Console.WriteLine("+------------------+");
                                Console.WriteLine("(1)First Copter");
                                Console.WriteLine("+------------------+");
                                Console.WriteLine("(2)Second Copter");
                                Console.WriteLine("+------------------+");
                                Console.WriteLine("(Q)Quit");
                                Console.WriteLine("+------------------+");

                                Console.WriteLine("Enter number:");
                                choosen5 = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (Char.ToLower(choosen5))
                                {
                                    case '1':
                                        choseH = h1;

                                        do
                                        {
                                            tab1();
                                            choosen6 = Console.ReadKey().KeyChar;
                                            Console.WriteLine();
                                            switch (Char.ToLower(choosen6))
                                            {
                                                case 's':
                                                    choseH.speedControl();
                                                    choseH = h1;
                                                    break;
                                                case 'a':
                                                    choseH.altitudeControl();
                                                    choseH = h1;
                                                    break;
                                                case 'l':
                                                    choseH.loadControl();
                                                    choseH = h1;
                                                    break;
                                                case 'd':
                                                    choseH.dropLoad(ref choseH.loadC);
                                                    choseH = h1;
                                                    break;
                                                case 'q':
                                                    choosen5 = 'q';
                                                    break;
                                                default:
                                                    Console.WriteLine("Enter correct input.");
                                                    break;

                                            }
                                        }
                                        while (choosen6 != 'q');
                                        break;
                                    case '2':
                                        choseH = h2;

                                        do
                                        {
                                            tab1();
                                            choosen7 = Console.ReadKey().KeyChar;
                                            Console.WriteLine();
                                            switch (Char.ToLower(choosen7))
                                            {
                                                case 's':
                                                    choseH.speedControl();
                                                    choseH = h2;
                                                    break;
                                                case 'a':
                                                    choseH.altitudeControl();
                                                    choseH = h2;
                                                    break;
                                                case 'l':
                                                    choseH.loadControl();
                                                    choseH = h2;
                                                    break;
                                                case 'd':
                                                    choseH.dropLoad(ref choseH.loadC);
                                                    choseH = h2;
                                                    break;
                                                case 'q':
                                                    choosen5 = 'q';
                                                    break;
                                                default:
                                                    Console.WriteLine("Enter correct input.");
                                                    break;

                                            }
                                        }
                                        while (choosen7 != 'q');
                                        break;
                                    case 'q':
                                        break;
                                    default:
                                        Console.WriteLine("Enter correct input.");
                                        break;

                                }
                            }
                            while (choosen5 != 'q');
                            break;
                        case 'q':
                            break;
                        default:
                            Console.WriteLine("Enter correct input.");
                            break;


                    }
                }
                while (choosen != 'q');
            }


            public class Dispatcher
            {
                public delegate void AircraftsHandler();
                // Event - command to take off
                public event AircraftsHandler TakeOffEvent;
                public void TakeOffCommand()
                {
                    if (TakeOffEvent != null)
                        TakeOffEvent();
                }
                // Event - Landing Team
                public event AircraftsHandler LandingEvent;
                public void LandingCommand()
                {
                    if (LandingEvent != null)
                        LandingEvent();
                }
            }
        }




    }


}




