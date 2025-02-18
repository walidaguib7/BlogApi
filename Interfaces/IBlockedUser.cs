﻿using BlogApi.Helpers;
using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IBlockedUser
    {
        public Task<List<BlockedUsers>> GetBlockedUsers(string id , UsersQuery query);
        public Task<BlockedUsers> BlockUser(BlockedUsers user);
        public Task<BlockedUsers?> UnBlockUser(string id , string blockedId);
    }
}
