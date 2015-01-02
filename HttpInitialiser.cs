using System;
using System.Collections.Generic;
using System.Web;
using SuperScript.Declarables;
using SuperScript.Emitters;

namespace SuperScript.JavaScript
{
    /// <summary>
    /// This class is instantiated for each HTTP request. [This is wired-up in the web.config.]
    /// </summary>
    public class HttpInitialiser : IHttpModule
    {
        private bool _initialised;
        private readonly object _obj = new object();


        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        #endregion


        public void Init(HttpApplication context)
        {
            if (_initialised) return;

            lock (_obj)
            {
                if (_initialised) return;

                InitEvents(context);
                _initialised = true;
            }
        }


        /// <summary>
        /// Custom handler for wiring-up events.
        /// </summary>
        /// <param name="context">
        /// The current HttpContext.
        /// </param>
        public void InitEvents(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
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
        public virtual void OnBeginRequest(object s, EventArgs e)
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