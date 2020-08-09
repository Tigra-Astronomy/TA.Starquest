using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MS.Gamification.Tests.TestHelpers
    {
    internal static class ControllerExtensions
        {
        /// <summary>
        /// Validates a model as if it had been posted to the controller.
        /// Taken from Stack Overflow at http://stackoverflow.com/a/3892968
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="controller"></param>
        /// <param name="modelObject"></param>
        public static void ValidateModel<TModel>(this Controller controller, TModel modelObject)
            {
            if (controller.ControllerContext == null)
                controller.ControllerContext = new ControllerContext();

            Type type = controller.GetType();
            MethodInfo tryValidateModelMethod =
                type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Where(
                    mi => mi.Name == "TryValidateModel" && mi.GetParameters().Count() == 1).First();

            tryValidateModelMethod.Invoke(controller, new object[] {modelObject});
            }
        }
    }

