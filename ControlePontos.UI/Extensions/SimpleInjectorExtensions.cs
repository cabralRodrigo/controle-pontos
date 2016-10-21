using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ControlePontos.Extensions
{
    internal static class SimpleInjectorExtensions
    {
        public static void RegisterDisposable(this Container container, params Type[] forms)
        {
            foreach (var form in forms)
                container.Register(form);

            foreach (var form in forms)
            {
                var registration = container.GetRegistration(form).Registration;
                registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Winforms registration supression.");
            }
        }

        public static void RegisterSingletonCollection<T>(this Container container, Assembly assembly, Dictionary<Type, Type> tipos) where T : class
        {
            var interfaceTipos = container.GetTypesToRegister(typeof(T), new[] { assembly });

            var interfaceRegistros = (
                from tipo in interfaceTipos
                select Lifestyle.Singleton.CreateRegistration(tipo, container)
            ).ToList();

            container.RegisterCollection<T>(interfaceRegistros);

            foreach (var tipo in tipos)
            {
                var tipoRegistro = interfaceRegistros.Single(w => w.ImplementationType == tipo.Value);
                container.AddRegistration(tipo.Key, tipoRegistro);
            }
        }
    }
}