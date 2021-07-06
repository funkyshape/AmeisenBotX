﻿using AmeisenBotX.Memory;
using System;

namespace AmeisenBotX.Core.Hook.Modules
{
    public abstract class RunAsmHookModule : IHookModule
    {
        public RunAsmHookModule(Action<IntPtr> onUpdate, Action<IHookModule> tick, IMemoryApi memoryApi, uint allocSize)
        {
            MemoryApi = memoryApi;
            AllocSize = allocSize;
            OnDataUpdate = onUpdate;
            Tick = tick;
        }

        ~RunAsmHookModule()
        {
            if (AsmAddress != IntPtr.Zero) { MemoryApi.FreeMemory(AsmAddress); }
        }

        public IntPtr AsmAddress { get; set; }

        public Action<IntPtr> OnDataUpdate { get; set; }

        public Action<IHookModule> Tick { get; set; }

        protected uint AllocSize { get; }

        protected IMemoryApi MemoryApi { get; }

        public abstract IntPtr GetDataPointer();

        public virtual bool Inject()
        {
            if (PrepareAsm()
                && MemoryApi.AllocateMemory(AllocSize, out IntPtr address))
            {
                AsmAddress = address;
                return MemoryApi.InjectAssembly(address);
            }
            else
            {
                return false;
            }
        }

        protected abstract bool PrepareAsm();
    }
}