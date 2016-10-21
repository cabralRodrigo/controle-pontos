using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyCompany("Fabrikam Technologies")]
[assembly: AssemblyProduct("Controle de Pontos")]
[assembly: AssemblyCopyright("Copyright © Rodrigo Cabral 2016")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

[assembly: AssemblyVersion("1.12.0")]