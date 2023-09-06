using AutoMapper;
using Gamax.Application.Contracts.Persistence;
using Gamax.Domain.Entities;
using MediatR;

namespace Gamax.Application.Features.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserCommandResponse = new CreateUserCommandResponse();

            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createUserCommandResponse.Success = false;
                createUserCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createUserCommandResponse.Success)
            {
                var user = _mapper.Map<User>(request);
                user = await _userRepository.AddAsync(user);
                createUserCommandResponse.User = _mapper.Map<CreateUserDto>(user);
            }

            return createUserCommandResponse;


        }
    }
}
