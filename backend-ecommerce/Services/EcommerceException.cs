using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_ecommerce.Services
{
    public class EcommerceException : Exception
    {
        public EcommerceException(string mensaje) : base(mensaje) { }

    }
    public class CustomerNotFound : EcommerceException
    {
        public CustomerNotFound(int id) : base($"El cliente con ID {id} no fue encontrado.") { }

    }

    public class CustomerDuplicado : EcommerceException
    {
        public CustomerDuplicado(string email) : base($"Ya existe un cliente con el email {email}.") { }

    }

    public class ProductoNotFound : EcommerceException
    {
        public ProductoNotFound(int id) : base($"El producto con ID: {id} no fue encontrado") { }
    }
    public class ProductoDuplicado : EcommerceException
    {
        public ProductoDuplicado(string nombre) : base($"Ya existe un producto con el nombre {nombre}.") { }

    }
}