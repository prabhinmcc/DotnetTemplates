﻿using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Guid { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;

            }
            public async Task Handle(Command command, CancellationToken cancellationToken)
            {
                Activity activity = await _dataContext.Activities.FindAsync(command.Guid);
                _dataContext.Remove(activity);
                await _dataContext.SaveChangesAsync();

            }
        }
    }

}
