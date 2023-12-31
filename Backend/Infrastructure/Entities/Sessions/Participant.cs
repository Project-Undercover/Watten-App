﻿using Infrastructure.Entities.Shared;
using Infrastructure.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities.Sessions
{
    public class Participant : Entity
    {
        [ForeignKey(nameof(Session))]
        public Guid SessionId { get; set; }

        [ForeignKey(nameof(Child))]
        public Guid ChildId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }



        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Session Session { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Child Child { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; }
    }
}
