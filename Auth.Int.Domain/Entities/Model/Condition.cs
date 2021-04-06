﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Int.Domain.Entities.Model
{
    public class Condition
    {
        public ConditionOperator Operator { get; set; }
        public IDictionary<ConditionKey, string> KeyPairs { get; set; }
    }
}
