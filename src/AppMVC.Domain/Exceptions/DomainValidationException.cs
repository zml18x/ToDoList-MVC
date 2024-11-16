﻿namespace AppMVC.Domain.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException(string message) : base(message){}

    public DomainValidationException(string message, Exception innerException) : base(message, innerException){}
}