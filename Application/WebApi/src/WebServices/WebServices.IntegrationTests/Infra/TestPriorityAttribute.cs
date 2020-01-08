namespace WebServices.IntegrationTests
{
    using System;

    /// <summary>
    /// TestPriorityAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestPriorityAttribute : Attribute
    {
        /// <summary>
        /// TestPriorityAttribute
        /// </summary>
        /// <param name="priority">priority</param>
        public TestPriorityAttribute(int priority)
        {
            Priority = priority;
        }

        /// <summary>
        /// Priority order.
        /// </summary>
        public int Priority { get; private set; }
    }
}
