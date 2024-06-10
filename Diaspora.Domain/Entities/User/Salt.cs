using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.User
{
    public class Salt
    {
        public byte[] Value { get; }

        private Salt(byte[] value)
        {
            if (value == null || value.Length == 0)
                throw new ArgumentException("El Valor Del Salt No Debe Ser Nulo O Vacío.", nameof(value));

            Value = value;
        }

        public static Salt Create()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return new Salt(salt);
        }

        public static Salt FromBytes(byte[] bytes)
        {
            return new Salt(bytes);
        }
    }
}
