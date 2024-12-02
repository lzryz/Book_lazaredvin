using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_lazaredvin
{
    internal class Author
    {
        public string Name { get; private set; }
        public Guid Id { get; private set; }

        public Author(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
    }
}
