using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual IEnumerable<Basket> Baskets { get; set; } = new HashSet<Basket>();
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
    }
}
