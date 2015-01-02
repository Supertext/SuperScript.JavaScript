using SuperScript.ExtensionMethods;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Post;

namespace SuperScript.JavaScript.Modifiers.Post
{
	/// <summary>
	/// Adds the contained JavaScript inside a jQuery handler which runs once the DOM has fully loaded.
	/// </summary>
	public class WhenReady : CollectionPostModifier
	{
		private const string whenReadyOpen = "$(function() {\n";
		private const string whenReadyClose = "\n});";


		#region Properties

		/// <summary>
		/// <para>Gets or sets the JavaScript string which closes the closure.</para>
		/// <para>Default is "});".</para>
		/// </summary>
		public string WhenReadyClose { get; set; }


		/// <summary>
		/// <para>Gets or sets the JavaScript string which opens the closure.</para>
		/// <para>Default is "$(function() {".</para>
		/// </summary>
		public string WhenReadyOpen { get; set; }

		#endregion


		/// <summary>
		/// Wraps the contents in a jQuery DOM-ready closure.
		/// </summary>
		/// <param name="args">
		/// An instance of <see cref="PostModifierArgs"/> where the <see cref="PostModifierArgs.Emitted"/> property contains the JavaScript to be enclosed.
		/// </param>
		/// <returns>A string containing the specified JavaScript in minified form.</returns>
		public override PostModifierArgs Process(PostModifierArgs args)
		{
			if (!this.ShouldEmitForCurrentContext())
			{
				return args;
			}

			args.Emitted = WhenReadyOpen + args.Emitted + WhenReadyClose;

			return args;
		}


		#region Constructors

		/// <summary>
		/// Default constructor for <see cref="WhenReady"/> which sets default values of properties.
		/// </summary>
		public WhenReady()
		{
			WhenReadyClose = whenReadyClose;
			WhenReadyOpen = whenReadyOpen;
		}

		#endregion
	}
}