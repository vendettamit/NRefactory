// 
// CodeAction.cs
//  
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc. (http://xamarin.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	/// <summary>
	/// A code action provides a code transformation with a description.
	/// </summary>
	public class CodeAction
	{
		/// <summary>
		/// Gets the description.
		/// </summary>
		public string Description {
			get;
			private set;
		}

		/// <summary>
		/// Gets the code transformation.
		/// </summary>
		public Action<Script> Run {
			get;
			private set;
		}

		/// <summary>
		/// Gets the action start location.
		/// </summary>
		public TextLocation Start {
			get;
			private set;
		}

		/// <summary>
		/// Gets the action end location.
		/// </summary>
		public TextLocation End {
			get;
			private set;
		}
		
		/// <summary>
		/// This property is used to identify which actions are "siblings", ie which actions
		/// are the same kind of fix. This is useful when supporting batch fixing of issues that
		/// have more than one possible action to choose from.
		/// </summary>
		/// <value>The sibling key.</value>
		public object SiblingKey {
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ICSharpCode.NRefactory.CSharp.Refactoring.CodeAction"/> class.
		/// </summary>
		/// <param name='description'>
		/// The description.
		/// </param>
		/// <param name='action'>
		/// The code transformation.
		/// </param>
		/// <param name='astNode'>
		/// A node that specifies the start/end positions for the code action.
		/// </param>
		public CodeAction (string description, Action<Script> action, AstNode astNode, object siblingKey = null)
		{
			if (action == null)
				throw new ArgumentNullException ("action");
			if (description == null)
				throw new ArgumentNullException ("description");
			if (astNode == null)
				throw new ArgumentNullException("astNode");
			Description = description;
			Run = action;
			Start = astNode.StartLocation;
			End = astNode.EndLocation;
			// The default sibling key.
			SiblingKey = siblingKey ?? "none";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ICSharpCode.NRefactory.CSharp.Refactoring.CodeAction"/> class.
		/// </summary>
		/// <param name='description'>
		/// The description.
		/// </param>
		/// <param name='action'>
		/// The code transformation.
		/// </param>
		/// <param name='start'>Start position for the code action.</param>
		/// <param name='end'>End position for the code action.</param>
		public CodeAction (string description, Action<Script> action, TextLocation start, TextLocation end, object siblingKey = null)
		{
			if (action == null)
				throw new ArgumentNullException ("action");
			if (description == null)
				throw new ArgumentNullException ("description");
			Description = description;
			Run = action;
			this.Start = start;
			this.End = end;
			SiblingKey = siblingKey ?? "none";
		}
	}
}

