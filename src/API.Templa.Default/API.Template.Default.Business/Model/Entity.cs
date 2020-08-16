using System;
using System.Collections.Generic;
using System.Text;

namespace API.Template.Default.Business.Model
{
    public abstract class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
