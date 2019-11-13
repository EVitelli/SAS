using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.Sas.Infra.Core.Exceptions
{
    public class ItemNaoEncontradoException : Exception
    {
        public ItemNaoEncontradoException()
        {
        }

        public ItemNaoEncontradoException(string message)
            : base(message)
        {
        }

    }
}
