using Diaspora.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Shared
{
    public abstract class Id
    {
        public int Value { get; private set; }
        private int MIN_VALUE = 0;

        protected Id(int value)
        {
            if (value <= this.MIN_VALUE)
            {
                throw new InvalidIdErrorException("El Id Debe Ser Mayo A Cero.");
            }

            this.Value = value;
        }

        public bool Equals(Id other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Value == other.Value;
        }
    }
}
