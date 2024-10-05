namespace CleanArchitecture.Application.Exceptions
{
    public class NotFoundException
        (
            string claseName, 
            object key
        ) 
        : ApplicationException($"Entity \"{claseName}\" ({key}) no fue encontrado")
    {
    }
}
