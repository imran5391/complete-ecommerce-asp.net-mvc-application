using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService //Actor.cs inherit from the IEntityBase, IActorsService:IEntityBaseRepository, In ActorsService also inherited EntityBaseRepository
    {
        public ActorsService(AppDbContext context) : base(context) { }
        
    }
}
