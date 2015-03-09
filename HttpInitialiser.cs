using SuperScript.Declarables;
using SuperScript.Emitters;
using System.Collections.Generic;
using System.Threading;
using System.Web;


namespace SuperScript.JavaScript
{
    /// <summary>
    /// This class is instantiated for each HTTP request, and is used to instantiate any SuperScript.JavaScript declarables
    /// which are declared in the configuration file.
    /// </summary>
    public class HttpInitialiser : IHttpModule
    {
        private readonly object _initSync = new object();
        private static int _initialized;


        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        #endregion


        public void Init(HttpApplication context)
        {
            // Prevent the initialization pipeline to be executed several times.
            if (Interlocked.CompareExchange(ref _initialized, 0, 0) == 0)
            {
                lock (_initSync)
                {
                    if (Interlocked.CompareExchange(ref _initialized, 0, 0) == 0)
                    {
                        OneTimeInitialization(context);
                        Interlocked.Exchange(ref _initialized, 1);
                    }
                }
            }
        }


        /// <summary>
        /// <para>Adds any instances of <see cref="DeclarationBase"/> which were configured in the web.config to the</para>
        /// <para><see cref="IList{DeclarationBase}"/> for the current HTTP context.</para>
        /// </summary>
        /// <remarks>
        /// <para>The web.config section where these <see cref="DeclarationBase"/> instances were declared can also</para>
        /// <para>contain instances of <see cref="IEmitter"/>. However, the <see cref="SuperScript.JavaScript.Configuration.Settings"/></para>
        /// <para>singleton automatically adds these to the central collection of <see cref="IEmitter"/>s in <see cref="SuperScript.Configuration.Settings"/>.</para>
        /// </remarks>
        protected virtual void OneTimeInitialization(HttpApplication context)
        {
            // Add the configured default declarations, if any.
            var defaultDecs = Configuration.Settings.Instance.Declarations;
            foreach (var declaration in defaultDecs)
            {
                // we can specify type DeclarationBase here because we're no interested in the return objects.
                SuperScript.Declarations.AddDeclaration<Declarables.DeclarationBase>(declaration);
            }
        }
    }
}