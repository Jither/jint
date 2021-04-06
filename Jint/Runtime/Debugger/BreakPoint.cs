using System;

namespace Jint.Runtime.Debugger
{
    // Not sealing BreakPoint. It's useful to be able to add additional properties on a derived BreakPoint class (e.g. a breakpoint ID)
    // that may still be added to Jint's breakpoint collection.
    public class BreakPoint
    {
        public BreakPoint(string source, int line, int column)
        {
            Location = new BreakLocation(source, line, column);
        }

        public BreakPoint(string source, int line, int column, string condition) : this(source, line, column)
        {
            Condition = condition;
        }

        public BreakPoint(int line, int column) : this(null, line, column)
        {
        }

        public BreakPoint(int line, int column, string condition) : this(null, line, column, condition)
        {
        }

        public BreakLocation Location { get; }
        public string Condition { get; }
    }
}
