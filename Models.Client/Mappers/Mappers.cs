using Models.Client.Data;
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
        internal static G.Account ToGlobal(this Account entity)
        {
            return new G.Account()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Description = entity.Description
            };
        }

        internal static Account ToClient(this G.Account entity)
        {
            return new Account(entity.Id, entity.UserId, entity.Description);
        }
        internal static G.Transaction ToGlobal(this Transaction entity)
        {
            return new G.Transaction()
            {
                Id = entity.Id,
                UserAccountId = entity.UserAccountId,
                DateTransact = entity.DateTransact,
                Description = entity.Description,
                ExpenseOrIncome = entity.ExpenseOrIncome,
                Amount = entity.Amount,
                CategoryId = entity.CategoryId
            };
        }

        internal static Transaction ToClient(this G.Transaction entity)
        {
            return new Transaction(entity.Id, entity.UserAccountId, entity.DateTransact, entity.Description, entity.ExpenseOrIncome, entity.Amount, entity.CategoryId);
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
