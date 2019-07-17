using System;
using System.Runtime.InteropServices;

namespace chsarp_rust
{
    public static class RustLib
    {
        private const string RUST_LIB = "rust_lib";

        public static string GetString()
        {
            var ptr = GetStringPtr();

            try
            {
                return Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
            }
            finally
            {
                FreeStringPtr(ptr);
            }
        }

        [DllImport(RUST_LIB, CallingConvention = CallingConvention.Cdecl, EntryPoint = "get_struct")]
        public static extern TestStruct GetStruct();

        [DllImport(RUST_LIB, CallingConvention = CallingConvention.Cdecl, EntryPoint = "get_string")]
        private static extern IntPtr GetStringPtr();

        [DllImport(RUST_LIB, CallingConvention = CallingConvention.Cdecl, EntryPoint = "free_string")]
        private static extern void FreeStringPtr(IntPtr ptr);

        [StructLayout(LayoutKind.Sequential)]
        public ref struct TestStruct
        {
            public long IntVal;
        }
    }
}
