using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Domain.Configurations;

public class HttpClientPolicyConfiguration
{
    public int RetryCount { get; set; }
    public int RetryDelayInMs { get; set; }
    public int RetryTimeoutInSeconds { get; set; }
    public int BreakDurationInSeconds { get; set; }
    public int MaxAttemptBeforeBreak { get; set; }
    public int HandlerTimeoutInMinutes { get; set; }
}