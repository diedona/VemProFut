﻿using MediatR;

namespace VemProFut.Api.Teams.List
{
    public class ListHandler : IRequestHandler<ListRequest, IEnumerable<ListResponse>>
    {
        public async Task<IEnumerable<ListResponse>> Handle(ListRequest request, CancellationToken cancellationToken)
        {
            throw new Exception("ERRO FATAL");

            await Task.CompletedTask;
            return new List<ListResponse>()
            {
                new(Guid.NewGuid(), "Embodied Goats"),
                new(Guid.NewGuid(), "La'vrour Sevil")
            }.AsEnumerable();
        }
    }
}
