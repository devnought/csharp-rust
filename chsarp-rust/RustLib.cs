using System;
using System.Runtime.InteropServices;

namespace chsarp_rust
{
    public static class RustLib
    {
        public static string GetString()
        {
            var ptr = get_string();

            try
            {
                return PtrToString(ptr);
            }
            finally
            {
                get_string_free(ptr);
            }
        }

        [DllImport("rust_lib", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr get_string();

        [DllImport("rust_lib", CallingConvention = CallingConvention.Cdecl)]
        private static extern void get_string_free(IntPtr ptr);

        private static string PtrToString(IntPtr ptr) =>
            Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
    }
}
