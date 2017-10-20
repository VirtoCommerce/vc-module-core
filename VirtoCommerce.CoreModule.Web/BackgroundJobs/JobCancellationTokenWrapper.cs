using System;
using Hangfire;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Web.BackgroundJobs
{
    public class JobCancellationTokenWrapper : ICancellationToken
    {
        public IJobCancellationToken JobCancellationToken { get; }

        public JobCancellationTokenWrapper(IJobCancellationToken jobCancellationToken)
        {
            JobCancellationToken = jobCancellationToken ?? throw new ArgumentNullException(nameof(jobCancellationToken));
        }

        public virtual void ThrowIfCancellationRequested()
        {
            JobCancellationToken.ThrowIfCancellationRequested();
        }
    }
}
