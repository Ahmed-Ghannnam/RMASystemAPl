using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMASystem.DAL
{
    /// <span class="code-SummaryComment"><summary></span>
    /// Provides a description for an enumerated type.
    /// <span class="code-SummaryComment"></summary></span>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field,
     AllowMultiple = false)]
    public sealed class EnumEngDescriptionAttribute : Attribute
    {
        private string engDescription;

        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the description stored in this attribute.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><value>The description stored in the attribute.</value></span>
        public string EngDescription
        {
            get
            {
                return this.engDescription;
            }
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Initializes a new instance of the
        /// <span class="code-SummaryComment"><see cref="EnumEngDescriptionAttribute"/> class.</span>
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="description">The description to store in this attribute.</span>
        /// <span class="code-SummaryComment"></param></span>
        public EnumEngDescriptionAttribute(string description)
            : base()
        {
            this.engDescription = description;
        }
    }


    /// <span class="code-SummaryComment"><summary></span>
    /// Provides a description for an enumerated type.
    /// <span class="code-SummaryComment"></summary></span>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field,
     AllowMultiple = false)]
    public sealed class EnumArbDescriptionAttribute : Attribute
    {
        private string arbDescription;

        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the description stored in this attribute.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><value>The description stored in the attribute.</value></span>
        public string ArbDescription
        {
            get
            {
                return this.arbDescription;
            }
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Initializes a new instance of the
        /// <span class="code-SummaryComment"><see cref="EnumArbDescriptionAttribute"/> class.</span>
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="description">The description to store in this attribute.</span>
        /// <span class="code-SummaryComment"></param></span>
        public EnumArbDescriptionAttribute(string description)
            : base()
        {
            this.arbDescription = description;
        }
    }
}
