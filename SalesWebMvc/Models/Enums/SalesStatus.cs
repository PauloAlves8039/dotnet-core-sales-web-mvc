﻿namespace SalesWebMvc.Models.Enums
{
    /// <summary>
    /// Enumerador responsável pelo estado da venda.
    /// </summary>
    public enum SalesStatus : int 
    {
        Pending = 0,
        Billed = 1,
        Canceled = 2
    }
}
