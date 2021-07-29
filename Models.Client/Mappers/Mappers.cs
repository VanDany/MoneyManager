﻿using Models.Client.Data;
using G = Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Mappers
{
    internal static class Mappers
    {
        internal static G.Category ToGlobal(this Category entity)
        {
            return new G.Category()
            {
                Id = entity.Id,
                Name = entity.Name,
                BudgetLimit = entity.BudgetLimit,
                UserId = entity.UserId
            };
        }

        internal static Category ToClient(this G.Category entity)
        {
            return new Category(entity.Id, entity.Name, entity.BudgetLimit, entity.UserId);
        }
        internal static User ToClient(this G.User entity)
        {
            return new User(entity.Id, entity.Username, entity.EmailAddress, entity.Xp, entity.Level, entity.Token);
        }

        internal static G.User ToGlobal(this User entity)
        {
            return new G.User() { Id = entity.Id, Username = entity.Username, EmailAddress = entity.EmailAddress, Password = entity.Password, Xp = entity.Xp, Level = entity.Level, Token = entity.Token };
        }
    }
}
