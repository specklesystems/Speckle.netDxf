#region netDxf library licensed under the MIT License
// 
//                       netDxf library
// Copyright (c) 2019-2021 Daniel Carvajal (haplokuon@gmail.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// 
#endregion

using System.IO;
using Speckle.netDxf.Collections;
using Speckle.netDxf.Tables;

namespace Speckle.netDxf.Objects
{
    /// <summary>
    /// Represents a DGN underlay definition.
    /// </summary>
    public class UnderlayDgnDefinition :
        UnderlayDefinition
    {
        #region private fields

        private string layout;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <c>UnderlayDgnDefinition</c> class.
        /// </summary>
        /// <param name="file">Underlay file name with full or relative path.</param>
        /// <remarks>
        /// The file extension must match the underlay type.
        /// </remarks>
        public UnderlayDgnDefinition(string file)
            : this(Path.GetFileNameWithoutExtension(file), file)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>UnderlayDgnDefinition</c> class.
        /// </summary>
        /// <param name="name">Underlay definition name.</param>
        /// <param name="file">Underlay file name with full or relative path.</param>
        /// <remarks>
        /// The file extension must match the underlay type.
        /// </remarks>
        public UnderlayDgnDefinition(string name, string file)
            : base(name, file, UnderlayType.DGN)
        {
            this.layout = "Model";
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the layout name to show.
        /// </summary>
        public string Layout
        {
            get { return this.layout; }
            set { this.layout = value; }
        }

        /// <summary>
        /// Gets the owner of the actual underlay DGN definition.
        /// </summary>
        public new UnderlayDgnDefinitions Owner
        {
            get { return (UnderlayDgnDefinitions)base.Owner; }
            internal set { base.Owner = value; }
        }

        #endregion

        #region overrides

        /// <summary>
        /// Creates a new UnderlayDgnDefinition that is a copy of the current instance.
        /// </summary>
        /// <param name="newName">UnderlayDgnDefinition name of the copy.</param>
        /// <returns>A new UnderlayDgnDefinition that is a copy of this instance.</returns>
        public override TableObject Clone(string newName)
        {
            UnderlayDgnDefinition copy = new UnderlayDgnDefinition(newName, this.File)
            {
                Layout = this.layout
            };

            foreach (XData data in this.XData.Values)
            {
                copy.XData.Add((XData)data.Clone());
            }

            return copy;
        }

        /// <summary>
        /// Creates a new UnderlayDgnDefinition that is a copy of the current instance.
        /// </summary>
        /// <returns>A new UnderlayDgnDefinition that is a copy of this instance.</returns>
        public override object Clone()
        {
            return this.Clone(this.Name);
        }

        #endregion
    }
}