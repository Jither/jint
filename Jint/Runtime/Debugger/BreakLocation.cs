using System;

namespace Jint.Runtime.Debugger
{
    public class BreakLocation : IEquatable<BreakLocation>
    {
        public BreakLocation(string source, int line, int column)
        {
            Source = source;
            Line = line;
            Column = column;
        }

        public BreakLocation(int line, int column) : this(null, line, column)
        {

        }

        public BreakLocation(string source, Esprima.Position position) : this(source, position.Line, position.Column)
        {
        }

        public string Source { get; }
        public int Line { get; }
        public int Column { get; }

        public bool Equals(BreakLocation other)
        {
            if (other is null)
            {
                return false;
            }

            return other.Line == Line &&
                other.Column == Column &&
                (other.Source == null || Source == null || other.Source == Source);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BreakLocation);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 33 + Line.GetHashCode();
                hash = hash * 33 + Column.GetHashCode();
                // We don't include Source - null source matches any source
                return hash;
            }
        }

        public static bool operator ==(BreakLocation a, BreakLocation b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(BreakLocation a, BreakLocation b)
        {
            return !Equals(a, b);
        }
    }
}
