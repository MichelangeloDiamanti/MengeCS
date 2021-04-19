using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MengeCS
{
    class MengeWrapper
    {
        [DllImport("MengeCore_d.dll")]
        public static extern bool InitSimulator([MarshalAs(UnmanagedType.LPStr)] String behaveFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String sceneFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String model,
                                                [MarshalAs(UnmanagedType.LPStr)] String pluginPath
                                                );
        
        [DllImport("MengeCore_d.dll")]
        public static extern float SetTimeStep(float timestep);

        [DllImport("MengeCore_d.dll")]
        public static extern bool DoStep();

        [DllImport("MengeCore_d.dll")]
        public static extern uint AgentCount();

        [DllImport("MengeCore_d.dll")]
        public static extern bool GetAgentPosition(uint i, ref float x, ref float y, ref float z);

        [DllImport("MengeCore_d.dll")]
        public static extern bool GetAgentVelocity(uint i, ref float x, ref float y, ref float z);

        [DllImport("MengeCore_d.dll")]
        public static extern bool GetAgentOrient(uint i, ref float x, ref float y );

        [DllImport("MengeCore_d.dll")]
        public static extern int GetAgentClass(uint i);

        [DllImport("MengeCore_d.dll")]
        public static extern float GetAgentRadius(uint i);

        [DllImport("MengeCore_d.dll")]
        public static extern int ExternalTriggerCount();

        [DllImport("MengeCore_d.dll")]
        public static extern IntPtr ExternalTriggerName(int i);

        [DllImport("MengeCore_d.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FireExternalTrigger([MarshalAs(UnmanagedType.LPStr)] string lpString);



        [DllImport("MengeCore_d.dll")]
        public static extern float GetGlobalTime();
    }
}
