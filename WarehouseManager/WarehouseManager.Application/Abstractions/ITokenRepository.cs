using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Application.Features.Login;
using WarehouseManager.Application.Features.Register;

namespace WarehouseManager.Application.Abstractions
{
    public interface ITokenRepository
    {
        public Task<string> GenerateTokenAsync(UserLoginDto dto);
    }
}
