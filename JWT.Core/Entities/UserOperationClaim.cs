﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Core.Entities
{
   public class UserOperationClaim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}