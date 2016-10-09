﻿using Ldme.Models.Models;

namespace Ldme.Common.Factories
{
    public class PlayerFactory
    {
        public Player GetInitialPlayer(string email)
        {
            return new Player { Name = email.Split('@')[0], Gold = 20, Honor = 5 };
        }
    }
}
