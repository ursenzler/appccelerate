﻿//-------------------------------------------------------------------------------
// <copyright file="IDriveExtension.cs" company="Appccelerate">
//   Copyright (c) 2008-2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.IO.Access
{
    using System;
    using System.Runtime.CompilerServices;

    using Appccelerate.IO.Access.Internals;

    [CompilerGenerated]
    public interface IDriveExtension
    {
        void BeginGetDrives();

        void EndGetDrives(DriveInfo[] result);

        void FailGetDrives(ref Exception exception);
    }
}