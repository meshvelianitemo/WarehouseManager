using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Application.Features.Login
{
    public class UserLoginDto
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set;  }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
