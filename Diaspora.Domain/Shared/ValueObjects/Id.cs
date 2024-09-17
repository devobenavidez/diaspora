using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared.ValueObjects
{
    public abstract class Id
    {
        public int Value { get; private set; }
        private int MIN_VALUE = 0;

        protected Id(int value)
        {
            if (value < MIN_VALUE)
            {
                throw new InvalidIdErrorException("The Id must be greater than zero.");
            }

            Value = value;
        }

        public bool Equals(Id other)
        {
            if (other == null)
            {
                return false;
            }

            return Value == other.Value;
        }
    }
}
