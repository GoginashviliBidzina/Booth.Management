﻿using System.Collections.Generic;

namespace Booth.Application.Infrastructure
{
    public class CommandExecutionResult : ExecutionResult
    {
        public IEnumerable<string> Errors { get; set; }
    }
}