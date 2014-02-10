/*
  LICENSE
  -------
  Copyright (C) 2007-2010 Ray Molenkamp

  This source code is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this source code or the software it produces.

  Permission is granted to anyone to use this source code for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this source code must not be misrepresented; you must not
     claim that you wrote the original source code.  If you use this source code
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original source code.
  3. This notice may not be removed or altered from any source distribution.
*/

using System;
using System.Runtime.InteropServices;
using FortyOne.AudioSwitcher.SoundLibrary.Audio.Interfaces;

namespace FortyOne.AudioSwitcher.SoundLibrary.Audio
{
    /// <summary>
    ///     Property Store class, only supports reading properties at the moment.
    /// </summary>
    internal class PropertyStore
    {
        private readonly IPropertyStore _Store;

        internal PropertyStore(IPropertyStore store)
        {
            _Store = store;
        }

        public int Count
        {
            get
            {
                int Result;
                Marshal.ThrowExceptionForHR(_Store.GetCount(out Result));
                return Result;
            }
        }

        public PropertyStoreProperty this[int index]
        {
            get
            {
                PropVariant result;
                PropertyKey key = Get(index);
                Marshal.ThrowExceptionForHR(_Store.GetValue(ref key, out result));
                return new PropertyStoreProperty(key, result);
            }
        }

        public PropertyStoreProperty this[Guid guid]
        {
            get
            {
                PropVariant result;
                for (int i = 0; i < Count; i++)
                {
                    PropertyKey key = Get(i);
                    if (key.fmtid == guid)
                    {
                        Marshal.ThrowExceptionForHR(_Store.GetValue(ref key, out result));
                        return new PropertyStoreProperty(key, result);
                    }
                }
                return null;
            }
        }

        public bool Contains(Guid guid)
        {
            for (int i = 0; i < Count; i++)
            {
                PropertyKey key = Get(i);
                if (key.fmtid == guid)
                    return true;
            }
            return false;
        }

        public PropertyKey Get(int index)
        {
            PropertyKey key;
            Marshal.ThrowExceptionForHR(_Store.GetAt(index, out key));
            return key;
        }

        public PropVariant GetValue(int index)
        {
            PropVariant result;
            PropertyKey key = Get(index);
            Marshal.ThrowExceptionForHR(_Store.GetValue(ref key, out result));
            return result;
        }
    }
}