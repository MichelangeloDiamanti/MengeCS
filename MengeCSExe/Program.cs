﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MengeCS;
using System.Runtime.InteropServices;

namespace MengeCSExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Run4Square();
            //RunUserEvent();
        }

        /// <summary>
        /// Runs the 4square example for 20 time steps.
        /// </summary>
        static void Run4Square()
        {
            Simulator sim = new Simulator();
            String scene = "4square";
            String mengePath = @"D:\visual-studio-projects\Menge\";
            String mengePluginPath = @"D:\visual-studio-projects\Menge\projects\VS2017\Plugins\build\lib\x64";
            String behaveXml = String.Format(@"{0}examples\core\{1}\{1}B.xml", mengePath, scene);
            String sceneXml = String.Format(@"{0}examples\core\{1}\{1}S.xml", mengePath, scene);
            if (sim.Initialize(behaveXml, sceneXml, "helbing", mengePluginPath))
            {
                System.Console.WriteLine("New simulator created.");
                System.Console.WriteLine("\t{0} agents", sim.AgentCount);
                for (int i = 0; i < 20; ++i)
                {
                    System.Console.WriteLine("Step {0}", i + 1);
                    if (!sim.DoStep())
                    {
                        System.Console.WriteLine("Simulation done...quitting");
                        break;
                    }
                    for (int a = 0; a < sim.AgentCount; ++a)
                    {
                        Agent agt = sim.GetAgent(a);
                        Vector3 p = agt.Position;
                        Vector3 v = agt.Velocity;
                        System.Console.WriteLine("\tGTime {4} Agent {0} at ({1}, {2} moving a5 {3} m/s)", a, p.X, p.Z, v, sim.GlobalTime);
                    }
                }

            }
            else
            {
                System.Console.WriteLine("Error initializing simulation");
            }

            System.Console.ReadLine();
        }

        /// <summary>
        /// Runs the userEvent.xml example. Invokes the external triggers every few time steps.
        /// </summary>
        static void RunUserEvent()
        {
            Simulator sim = new Simulator();
            String scene = "userEvent";
            String mengePath = @"E:\work\projects\menge_fork\";
            String behaveXml = String.Format(@"{0}examples\core\{1}\{1}B.xml", mengePath, scene);
            String sceneXml = String.Format(@"{0}examples\core\{1}\{1}S.xml", mengePath, scene);
            if (sim.Initialize(behaveXml, sceneXml, "orca"))
            {
                System.Console.WriteLine("Simulator has {0} external triggers", sim.Triggers.Count);
                System.Console.WriteLine("New simulator created.");
                System.Console.WriteLine("\t{0} agents", sim.AgentCount);
                for (int i = 0; i < 20; ++i)
                {
                    if ( i % 3 == 0 )
                    {
                        int triggerIndex = (i / 3) % sim.Triggers.Count;
                        ExternalTrigger trigger = sim.Triggers[triggerIndex];
                        System.Console.WriteLine("Firing trigger: {0}", trigger.Name);
                        trigger.Fire();
                    }
                    System.Console.WriteLine("Step {0}", i + 1);
                    if (!sim.DoStep())
                    {
                        System.Console.WriteLine("Simulation done...quitting");
                        break;
                    }
                    for (int a = 0; a < sim.AgentCount; ++a)
                    {
                        Agent agt = sim.GetAgent(a);
                        Vector3 p = agt.Position;
                        Vector3 v = agt.Velocity;
                        System.Console.WriteLine("\tAgent {0} at ({1}, {2} moving a5 {3} m/s)", a, p.X, p.Z, v.Length());
                    }
                }

            }
            else
            {
                System.Console.WriteLine("Error initializing simulation");
            }
        }
    }
}
