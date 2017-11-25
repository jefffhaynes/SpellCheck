﻿using System;
using System.Runtime.InteropServices;
using SpellCheck.Core.Interop;

namespace SpellCheck.Core
{
    /// <summary>
    /// Manages the registration of user dictionaries
    /// </summary>
    public class UserDictionariesRegistrar : IDisposable
    {
        private IUserDictionariesRegistrar _registrar;

        /// <summary>
        /// Maintains user dictionaries
        /// </summary>
        public UserDictionariesRegistrar()
        {
            _registrar = (IUserDictionariesRegistrar)new SpellCheckerFactory();
        }

        /// <summary>
        /// Registers a file to be used as a user dictionary for the current user, until unregistered
        /// </summary>
        /// <param name="dictionaryPath">The path of the dictionary file to be registered</param>
        /// <param name="languageTag">The language for which this dictionary should be used. If left empty, it will be used for any language</param>
        public void RegisterUserDictionary(string dictionaryPath, string languageTag)
        {
            _registrar.RegisterUserDictionary(dictionaryPath, languageTag);
        }

        /// <summary>
        /// Unregisters a previously registered user dictionary. The dictionary will no longer be used by the spell checking functionality.
        /// </summary>
        /// <param name="dictionaryPath">The path of the dictionary file to be unregistered</param>
        /// <param name="languageTag">The language for which this dictionary was used. It must match the language passed to <see cref="RegisterUserDictionary" /></param>
        public void UnregisterUserDictionary(string dictionaryPath, string languageTag)
        {
            _registrar.UnregisterUserDictionary(dictionaryPath, languageTag);
        }

        /// <summary>
        /// Disposes resources used by UserDictionariesRegistrar
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes resources used by UserDictionariesRegistrar
        /// </summary>
        ~UserDictionariesRegistrar()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_registrar != null)
            {
                Marshal.ReleaseComObject(_registrar);
                _registrar = null;
            }
        }
    }
}
