﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Commands.Product.DeleteProduct
{
    internal class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public string ProductId { get; set; }

    }
}