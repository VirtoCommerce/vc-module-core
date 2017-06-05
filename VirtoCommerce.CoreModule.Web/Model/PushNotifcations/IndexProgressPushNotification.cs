using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Platform.Core.PushNotifications;

namespace VirtoCommerce.CoreModule.Web.Model.PushNotifcations
{
    public class IndexProgressPushNotification : PushNotification
    {
        public IndexProgressPushNotification(string creator)
            : base(creator)
        {
            Errors = new List<string>();
        }
        public string DocumentType { get; set; }
        /// <summary>
        /// Gets or sets the job finish date and time.
        /// </summary>
        /// <value>
        /// The finished.
        /// </value>
        public DateTime? Finished { get; set; }
        /// <summary>
        /// Gets or sets the total count of objects to process.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public long TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the count of processed objects.
        /// </summary>
        /// <value>
        /// The processed count.
        /// </value>
        public long ProcessedCount { get; set; }
        /// <summary>
        /// Gets or sets the count of errors during processing.
        /// </summary>
        /// <value>
        /// The error count.
        /// </value>
        public long ErrorCount { get; set; }
        /// <summary>
        /// Gets or sets the errors that has occurred during processing.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public ICollection<string> Errors { get; set; }
    }
}