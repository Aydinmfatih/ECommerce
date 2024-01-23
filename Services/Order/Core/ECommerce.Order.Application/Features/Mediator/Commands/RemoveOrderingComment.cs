using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Commands
{
    public class RemoveOrderingComment:IRequest
    {
        public int Id { get; set; }
        public RemoveOrderingComment(int id)
        {
            Id=id;
        }
    }
}
