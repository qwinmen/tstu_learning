#include "stdafx.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;

//
// ????? ???????? ?? ???? ?????? ??????????????? ????????? ???????
// ?????????. ?????????????? ???????? ???? ?????????, ????? ????????
// ????? ???????? ?? ???? ??????.
//
[assembly:AssemblyTitleAttribute("MM5")];
[assembly:AssemblyDescriptionAttribute("")];
[assembly:AssemblyConfigurationAttribute("")];
[assembly:AssemblyCompanyAttribute("Microsoft")];
[assembly:AssemblyProductAttribute("MM5")];
[assembly:AssemblyCopyrightAttribute("Copyright (c) Microsoft 2015")];
[assembly:AssemblyTrademarkAttribute("")];
[assembly:AssemblyCultureAttribute("")];

//
// ???????? ? ?????? ?????? ??????? ?? ????????? ??????? ????????:
//
//      ???????? ????? ??????
//      ?????????????? ????? ??????
//      ????? ??????????
//      ????????
//
// ????? ?????? ??? ???????? ??? ??????? ????? ?????????? ? ????? ???????? ?? ?????????,
// ????????? "*", ??? ???????? ????:

[assembly:AssemblyVersionAttribute("1.0.*")];

[assembly:ComVisible(false)];

[assembly:CLSCompliantAttribute(true)];

[assembly:SecurityPermission(SecurityAction::RequestMinimum, UnmanagedCode = true)];
