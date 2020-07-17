using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkService.Domain.Abstractions;

namespace WorkService.Infrastructure.Core.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext context)
        {
            var domainEntities = context.ChangeTracker.Entries<Entity>().Where(q => q.Entity.DomainEvents != null && q.Entity.DomainEvents.Any());

            var domainEvents = domainEntities.SelectMany(q => q.Entity.DomainEvents).ToList();

            domainEntities.ToList().ForEach(entity =>
            {
                entity.Entity.ClearDomainEvents();
            });

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }


        }

    }
}
