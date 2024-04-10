using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class PostResponse : IRequest<QuestionResponse>
    {
        public QuestionResponse? UserResponse { get; set; }
    }

    public class PostResponseHandler : IRequestHandler<PostResponse, QuestionResponse>
    {
        private IDynamicContext _dynamicContext;

        public PostResponseHandler(IDynamicContext dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }


        public async Task<QuestionResponse> Handle(PostResponse request, CancellationToken cancellationToken)
        {
            var addedResponse = await _dynamicContext.QuestionResponses.AddAsync(request.UserResponse);
            await _dynamicContext.SaveChangesAsync();

            return addedResponse.Entity;
        }
    }
}
