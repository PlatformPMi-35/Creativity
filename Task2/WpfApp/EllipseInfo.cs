//-----------------------------------------------------------------------
// <copyright file="EllipseInfo.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp
{
    /// <summary>
    /// Represents Ellipse with top left point
    /// </summary>
    [Serializable]
    public class EllipseInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "EllipseInfo"/> class.
        /// Constructor without parameters
        /// </summary>
        public EllipseInfo()
        {
            this.Shape = new Ellipse();
        }

        /// <summary>
        /// Gets or sets top left point if ellipse
        /// </summary>
        public Point TopLeft { get; set; }

        /// <summary>
        /// Gets or sets name of ellipse
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets object of <see cref="Ellipse"/> class
        /// </summary>
        [XmlIgnore]
        public Ellipse Shape { get; set; }
    }
}
