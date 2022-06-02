using System;
using System.Runtime.InteropServices;

namespace MengeCS
{
    class MengeWrapper
    {
#if DEBUG
        const string dllFile = "MengeCore_d";
#else
        const string dllFile = "MengeCore";
#endif

        [DllImport(dllFile)]
        public static extern bool InitSimulator([MarshalAs(UnmanagedType.LPStr)] String behaveFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String sceneFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String model,
                                                [MarshalAs(UnmanagedType.LPStr)] String pluginPath
                                                );

        [DllImport(dllFile)]
        public static extern float SetTimeStep(float timestep);

        [DllImport(dllFile)]
        public static extern bool DoStep();

        [DllImport(dllFile)]
        public static extern uint AgentCount();

        [DllImport(dllFile)]
        public static extern bool GetAgentPosition(uint i, ref float x, ref float y, ref float z);

        [DllImport(dllFile)]
        public static extern bool GetAgentVelocity(uint i, ref float x, ref float y, ref float z);

        [DllImport(dllFile)]
        public static extern bool GetAgentOrient(uint i, ref float x, ref float y);

        [DllImport(dllFile)]
        public static extern int GetAgentClass(uint i);

        [DllImport(dllFile)]
        public static extern float GetAgentRadius(uint i);

        [DllImport(dllFile)]
        public static extern int ExternalTriggerCount();

        [DllImport(dllFile)]
        public static extern IntPtr ExternalTriggerName(int i);

        [DllImport(dllFile, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FireExternalTrigger([MarshalAs(UnmanagedType.LPStr)] string lpString);
    }
}
