_**IMPORTANT NOTE:**_ This project is currently in beta and the documentation is currently incomplete. Please bear with us while the documentation is being written.

####SuperScript offers a means of declaring assets in one part of a .NET web solution and have them emitted somewhere else.


When developing web solutions, assets such as JavaScript declarations or HTML templates are frequently written in a location that differs from their desired output location.

For example, all JavaScript declarations should ideally be emitted together just before the HTML document is closed. And if caching is preferred then these declarations should be in an external file with caching headers set.

This is the functionality offered by SuperScript.



##Easily make JavaScript declarations from anywhere in your project

`SuperScript.JavaScript` offers specific types of declarations.

* Arrays
* Comments
* Function calls
* Enumerables (this is actually an object which offers the same functionality as an `enum`)
* Variables - all JavaScript primitives (boolean, integer, object or string)
* Collected script - used by `SuperScript.Container.Mvc` and `SuperScript.Container.WebForms` for declaring blocks of JavaScript

`SuperScript.JavaScript` also contains emitter classes (a `CollectionConverter`, two `CollectionPostModifier`s and an `HtmlWriter`)
which aid emitting of the JavaScript declarations.


###Syntax Options
SuperScript offers a means of writing JavaScript declarations using an inline combination of both dot and fluent notation. For example

```c#
Declarations.AddVariable(opt => opt.AssignExisting(false)     // determines whether 'var' should be included
                                   .Comment("A comment")      // appends a comment on the same line
                                   .EmitterKey("javascript")  // the name of the pipeline which should emit this declaration
                                   .InsertAt(null)            // allows the declaration to be inserted at a specific index
                                   .Name("myVar")             // the name of the variable being declared
                                   .Value("hello world"));    // the value to be assigned to this declaration
```
The above will typically output

```JavaScript
var myVar = "hello world"; /* A comment */
```


##What's in this project?

Below is a list of some of the more important classes in the `SuperScript.JavaScript` project.

* `SuperScript.JavaScript.Declarables.ArrayDeclaration`
* `SuperScript.JavaScript.Declarables.CallDeclaration`
* `SuperScript.JavaScript.Declarables.CollectedScript`
* `SuperScript.JavaScript.Declarables.CommentDeclaration`
* `SuperScript.JavaScript.Declarables.EnumDeclaration`
* `SuperScript.JavaScript.Declarables.ObjectDeclaration`
* `SuperScript.JavaScript.Declarables.StandardDeclaration`
* Converters
  * `SuperScript.JavaScript.Modifiers.Converters.JavaScriptStringify`: Converts the 'Declarations' property of the specified PreModifierArgs into an instance of PostModifierArgs where 
  the 'Emitted' property contains the stringified JavaScript.
* Post Modifiers
  * `SuperScript.JavaScript.Modifiers.Post.JavaScriptMinifier`: Minifies the specified string using Microsoft's WebGrease.
  * `SuperScript.JavaScript.Modifiers.Post.WhenReady`: Adds the contained JavaScript inside a jQuery handler which runs once the DOM has fully loaded.
* Writers
  * `SuperScript.JavaScript.Modifiers.Writers.ScriptTagWriter`: Writes the formatted output of the `PostModifierArgs.Emitted` into an HTML &lt;script&gt; tag.

This project also contains attributes for .NET `enum` types which allow greater control over their client-side representations.

##Dependencies
There are a variety of SuperScript projects, some being dependent upon others.

* [`SuperScript.Common`](https://github.com/Supertext/SuperScript.Common)

  This library contains the core classes which facilitate all other SuperScript modules but which won't produce any meaningful output on its own.



`SuperScript.JavScript` has been made available under the [MIT License](https://github.com/Supertext/SuperScript.JavaScript/blob/master/LICENSE).
