using CryptoBotClone.APIs.Common;
using CryptoBotClone.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoBotClone.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindManyArgs : FindManyInput<User, UserWhereInput> { }
