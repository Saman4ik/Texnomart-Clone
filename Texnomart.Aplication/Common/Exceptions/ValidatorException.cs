﻿namespace Texnomart.Aplication.Common.Exceptions;

public class ValidatorException : Exception
{
    public ValidatorException(string message)
        : base(message)
    {
    }
}
