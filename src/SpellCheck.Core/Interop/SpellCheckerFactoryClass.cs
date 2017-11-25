﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpellCheck.Core.Interop
{
    [Guid("7AB36653-1796-484B-BDFA-E74F1DB7C1DC")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class SpellCheckerFactoryClass : ISpellCheckerFactory, SpellCheckerFactory, IUserDictionariesRegistrar
    {
        [DispId(1610678272)]
        public extern virtual IEnumString SupportedLanguages { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual int IsSupported([MarshalAs(UnmanagedType.LPWStr), In] string languageTag);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public extern virtual ISpellChecker CreateSpellChecker([MarshalAs(UnmanagedType.LPWStr), In] string languageTag);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual void RegisterUserDictionary([MarshalAs(UnmanagedType.LPWStr), In] string dictionaryPath, [MarshalAs(UnmanagedType.LPWStr), In] string languageTag);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual void UnregisterUserDictionary([MarshalAs(UnmanagedType.LPWStr), In] string dictionaryPath, [MarshalAs(UnmanagedType.LPWStr), In] string languageTag);
    }
}
